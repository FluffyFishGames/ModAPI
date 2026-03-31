[![English](https://img.shields.io/badge/English-🇺🇸-blue)](README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](Docs/README.ko.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](Docs/README.de.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](Docs/README.es.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](Docs/README.fr.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](Docs/README.pl.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](Docs/README.ru.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](Docs/README.it.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](Docs/README.jp.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](Docs/README.pt.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](Docs/README.vi.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](Docs/README.zh-CN.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](Docs/README.zh-TW.md)

# ModAPI(v1) v2.0.9586 - 20260331

**The Forest Mod Management Tool — Upgraded Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germany)
> Upgrade: zzangae (Republic of Korea)

---

## Overview

ModAPI is a desktop application for managing mods for The Forest. This upgraded edition includes .NET Framework 4.8 migration, Windows 11 Fluent Design UI, a 3-theme system, enhanced multilingual support, a full Downloads tab implementation, and C# 7.3 mod development support.

---

## What Changed in v2.0.9586

The following issues were identified and resolved after v2.0.9561. All findings are based on in-game testing.

| # | Category | Issue | Resolution |
|---|---|---|---|
| 1 | **Critical** | Black screen on game main menu after applying mods | Confirmed fixed — assembly remapping pipeline now correctly patches PE headers and reference tables |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` included but non-functional | Removed entirely — Mono 2.0's `mscorlib` emits IL referencing `ValueTuple` directly; no polyfill can override it |
| 3 | **Polyfill** | Wrong filename: `System.Threading.Tasks.dll` | Corrected to `System.Threading.dll` — actual filename from `TaskParallelLibrary 1.0.2856` NuGet |
| 4 | **Polyfill** | `Game.cs` copy destination bug: files copied to `Managed\polyfills\` instead of `Managed\` | Fixed by using `Path.GetFileName()` to extract filename only for the flat destination path |
| 5 | **Build** | PostBuild target missing polyfill auto-copy | `BaseModLib.csproj` PostBuild now auto-copies `AsyncBridge.dll` and `System.Threading.dll` to `bin\{Config}\libs\polyfills\` |
| 6 | **C# 7.3** | Tuple (`ValueTuple`) support attempted and failed | Definitively removed from all configs — tuples are an architectural hard limit on Mono 2.0 |
| 7 | **C# 7.3** | In-game verification of remaining C# 7.3 features | Confirmed working in real gameplay: pattern matching, string interpolation, `out` variable inline |

### C# 7.3 Final Feature Matrix

| Feature | Status | Notes |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Confirmed | Tested in-game via `TEST_MOD.log` |
| String interpolation (`$""`) | ✅ Confirmed | Tested in-game via `TEST_MOD.log` |
| `out` variable inline | ✅ Confirmed | Tested in-game via `TEST_MOD.log` |
| Expression-bodied members (`=>`) | ✅ | Compiler-handled, no runtime dependency |
| Local functions | ✅ | Compiler-handled, no runtime dependency |
| `nameof` | ✅ | Compiler-handled, no runtime dependency |
| Null-conditional (`?.`, `??`) | ✅ | Compiler-handled, no runtime dependency |
| `async`/`await` | ✅ | Via AsyncBridge + System.Threading polyfills |
| Tuples (`ValueTuple`) | ❌ Hard limit | Mono 2.0 `mscorlib` ABI — no workaround exists |

### Final Polyfill Configuration

| DLL | NuGet Package | Destination | Purpose |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` for .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge dependency |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Portable.System.ValueTuple~~ | ~~Removed~~ | ~~Tuple support — non-functional on Mono 2.0~~ |

---

## Runtime Architecture — .NET / Mono Design Decision

ModAPI operates across two distinct runtime environments. Understanding this separation is essential for contributors.

### Runtime Split

| Component | Target | Runtime | Reason |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop application, full modern API access |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Shared library for ModAPI desktop |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Permanently fixed — see below** |
| Mod DLLs (user) | .NET Framework 4.8 | Game Mono 2.0 (patched) | Built with 4.8, PE header patched at Apply time |

### Why BaseModLib Must Stay at .NET 3.5

The Forest runs on **Unity 5.6.x**, which embeds **Mono 2.0** (`mono.dll`, CLR Runtime `v2.0.50727`). This runtime is physically embedded in the game executable and cannot be replaced externally.

When a DLL is compiled targeting .NET 4.8, its PE header contains `CLR Runtime v4.0.30319`. Mono 2.0 inspects this header before loading and **refuses to load any DLL with a v4.x PE header**, resulting in a black screen.

`RemapAllReferences()` (Mono.Cecil) can patch assembly reference versions inside a DLL, but it **cannot modify the PE header CLR Runtime field**. Therefore, BaseModLib must be compiled with .NET 3.5 so its PE header reads `v2.0.50727`, which Mono 2.0 accepts.

```
v3.5 build  →  PE header: CLR Runtime v2.0.50727  ←  Mono 2.0 accepts  ✅
v4.8 build  →  PE header: CLR Runtime v4.0.30319  ←  Mono 2.0 rejects  ❌  (black screen)
```

### Why Mono 2.0 Cannot Be Upgraded

Unity 5.6.x embeds `Mono/mono.dll` compiled and ABI-linked against its own engine internals. Replacing this DLL with a newer Mono version causes an immediate crash because the Unity engine binary expects the exact ABI of its bundled Mono. The Forest is a released, no-longer-updated game — a Unity engine upgrade is not possible.

### Assembly Remapping Pipeline

Mod DLLs built with .NET 4.8 go through the following pipeline at Apply time:

```
[Mod Developer builds with .NET 4.8]
  → Mod DLL: PE header v4.0.30319, references mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      patches reference table: mscorlib 4.0.0.0 → 2.0.0.0, etc.
  → modModule.RuntimeVersion = "v2.0.50727"
      patches PE header: v4.0.30319 → v2.0.50727

[Game runtime — Mono 2.0]
  → PE header accepted ✅
  → Assembly references resolved ✅
```

### Polyfill Deployment Pipeline

```
[BaseModLib PostBuild]
  New_MODAPI2\libs\polyfills\AsyncBridge.dll
  New_MODAPI2\libs\polyfills\System.Threading.dll
    → auto-copied to bin\{Config}\libs\polyfills\

[ModAPI Apply — Game.cs]
  bin\{Config}\libs\polyfills\AsyncBridge.dll
  bin\{Config}\libs\polyfills\System.Threading.dll
    → Path.GetFileName() extracts filename only
    → flat-copied to TheForest_Data\Managed\AsyncBridge.dll
    → flat-copied to TheForest_Data\Managed\System.Threading.dll
```

---

## Key Changes

### Phase 1 — .NET Framework 4.8 Upgrade

- Migrated all projects (5) from `.NET Framework 4.5` → `4.8`
- Updated `TargetFrameworkVersion`, `App.config`, `packages.config` across all projects
- Unified assembly version

### Phase 2 — Build Environment & Fluent Design Foundation

- Introduced **ModernWpf 0.9.6** NuGet package
- Created **FluentStyles.xaml** — Windows 11 Fluent Design override layer
  - Fluent color palette, typography, buttons, tabs, comboboxes, scrollbar styles
  - Window, SubWindow, SplashScreen templates
- Compiled **UnityEngine stub DLL**
  - Added missing types: `WWW`, `Event`, `TextEditor`, `Physics`, etc.
- Fixed dependency references and confirmed successful build

### Phase 3 — UI Redesign & Theme System

#### 3-Theme System

| Theme | Style File | Description |
|-------|-----------|-------------|
| Classic | Dictionary.xaml only | Original ModAPI design (texture background) |
| Light | FluentStylesLight.xaml | Bright tone + blue accent |
| Dark | FluentStyles.xaml | Dark tone + blue accent (default) |

- Added **Theme Selector ComboBox** in Settings tab
- Theme change triggers **confirmation popup** → **auto restart**
- Theme setting saved/loaded via `theme.cfg` file

### Phase 4 — Code Cleanup & Legacy Removal

- Removed login system (server no longer operational)
- Modernized update mechanism
- Cleaned up unused code
- Fixed SubWindow UI (game path dialogs, etc.)

### Phase 5 — Multilingual Support Expansion (13 Languages)

| Language | File | Language | File |
|----------|------|----------|------|
| Korean | Language.KR.xaml | Italian | Language.IT.xaml |
| English | Language.EN.xaml | Japanese | Language.JA.xaml |
| German | Language.DE.xaml | Portuguese | Language.PT.xaml |
| Spanish | Language.ES.xaml | Vietnamese | Language.VI.xaml |
| French | Language.FR.xaml | Chinese (Simplified) | Language.ZH.xaml |
| Polish | Language.PL.xaml | Chinese (Traditional) | Language.ZH-TW.xaml |
| Russian | Language.RU.xaml | | |

### Phase 5-1 — Downloads Tab & Theme Completion

- Loads mod list from 3 sources (`mods.json`, `versions.xml`, HTML parsing)
- Search functionality (filter by mod name/description/author)
- **Game filter** (All / The Forest / Dedicated Server / VR)
- **Category filter** (All / Bugfixes / Balancing / Cheats, etc. — 12 categories)
- Direct `.mod` file download → game folder installation
- All button PNG icons → **Segoe MDL2 Assets** font icons

### Phase 5-5 — Assembly Resolution Restoration

- **`AssemblyVersionMap.cs`** — new shared utility mapping 20 system assemblies to correct Mono 2.0 versions and public key tokens
- **`CustomAssemblyResolver.cs`** — rewritten with name-based matching and Dictionary caching
- **`ModLib.cs`** — removed Silverlight hardcoding, replaced with `AssemblyVersionMap.RemapAllReferences()`
- **`Game.cs`** — replaced `@HOTFIX` loop with `RemapAllReferences()` + `RemoveDuplicateReferences()`
- **`ModProject.cs`** — updated with v3.5→v4.8 template, `UpgradeProjectFile()`, system assembly filtering
- Fixed `CS0723` build error: `ModAPI.Version` shadowing `System.Version`

### Phase 5-6 — C# 7.3 Mod Development Support

- **`BaseModLib.csproj`**: `.NET 3.5` permanently fixed + `<LangVersion>7.3</LangVersion>` added
- **`ModProject.cs`**: `modModule.RuntimeVersion = "v2.0.50727"` added after `RemapAllReferences()`
- **`Game.cs`**: polyfill DLL auto-deployment to `TheForest_Data/Managed/` during Apply
- **`BaseModLib.csproj` PostBuild**: polyfill DLLs auto-copied from `libs/polyfills/` to ModAPI libs folder on build

### Phase 5-6B — Black Screen Fix & Polyfill Pipeline Finalization

- **Black screen resolved**: assembly remapping pipeline confirmed working end-to-end in real gameplay
- **`Portable.System.ValueTuple.dll` removed**: Mono 2.0 `mscorlib` ABI makes tuple polyfill impossible — definitive architectural conclusion
- **`System.Threading.dll` filename corrected**: was incorrectly named `System.Threading.Tasks.dll`
- **`Game.cs` copy path bug fixed**: destination now uses `Path.GetFileName()` for flat copy into `Managed/`
- **C# 7.3 in-game verification completed**: pattern matching, string interpolation, `out` variable inline all confirmed via `TEST_MOD.log`

---

## Version History

| Version | Date | Summary |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Black screen fix confirmed, polyfill pipeline finalized, ValueTuple removed, filename/path bugs fixed, C# 7.3 in-game verified |
| v2.0.9561 | 2026-03-06 | C# 7.3 mod dev support, PE header patching, polyfill pipeline, assembly resolution restoration |
| v2.0.9552 | 2026-02-25 | Downloads tab, icon modernization, theme unification, 13-language support |
| v2.0.9500 | — | Theme system (Classic/Light/Dark), Fluent Design UI, SubWindow system |
| v2.0.9400 | — | Code cleanup, login removal, legacy modernization |
| v2.0.9300 | — | Build environment, UnityEngine stub DLL, ModernWpf integration |
| v2.0.9200 | — | .NET Framework 4.8 migration |
| v1.x | — | Original FluffyFish release |

---

## File Structure

```
ModAPI/
├── App.xaml / App.xaml.cs              # Theme load/save/apply
├── Dictionary.xaml                      # Original styles + toggle/radio/fallback resources
├── FluentStyles.xaml                    # Dark theme + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml               # Light theme + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs            # Main UI + Downloads tab + theme selector
│   └── SubWindows/                      # 16 SubWindows (all with font icons)
├── Data/
│   ├── Game.cs                          # Game assembly patching + polyfill deployment
│   ├── ModLib.cs                        # BaseModLib generation + assembly remapping
│   ├── Models/
│   │   └── ModProject.cs                # Mod project create/build/apply + PE header patch
│   └── AssemblyVersionMap.cs            # Mono 2.0 assembly version mapping (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Name-based assembly resolver with caching
│   └── MonoHelper.cs                    # Mono.Cecil IL helper utilities
├── resources/
│   ├── langs/                           # 13 language files
│   └── textures/Icons/flags/            # Flag icons (16x11 PNG)
└── libs/
    ├── UnityEngine.dll                  # Stub DLL for BaseModLib compilation
    └── polyfills/                       # C# 7.3 runtime polyfills
        ├── AsyncBridge.dll              # async/await for .NET 3.5
        └── System.Threading.dll         # AsyncBridge dependency

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3 + PostBuild polyfill copy
├── Attributes/                          # ModAPI attributes (ExecuteOnGameStart, Priority, etc.)
├── Mod.cs / Mods.cs                     # Mod base classes
├── Log.cs / Input.cs / Interface.cs     # ModAPI runtime APIs
└── libs/
    └── polyfills/                       # Source polyfill DLLs (copied by PostBuild)
        ├── AsyncBridge.dll
        └── System.Threading.dll
```

---

## Build Requirements

| Requirement | Version | Notes |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | For ModAPI projects |
| .NET Framework SDK | 3.5 | For BaseModLib only |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — place in `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## License

GNU General Public License v3.0 — follows the original license.
