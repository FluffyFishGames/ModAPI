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

# ModAPI(v1) v2.0.9618 - 20260425

**The Forest Mod Management Tool — Upgraded Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germany)
> Upgrade: zzangae (Republic of Korea)

---

## Overview

ModAPI is a desktop application for managing mods for **5 officially supported games**. This upgraded edition includes multi-game support, a fully redesigned Settings tab, Steam path configuration, persistent UI settings, a dynamic font size system, game start validation, Debug/Release build split, and numerous crash fixes verified through in-game testing.

---

## Supported Games

| Game | Engine | Version | Steam ID | Executable |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Item | Value |
|---|---|
| Engine | Unity 5 (upgraded from Unity 4) |
| Latest Version | v1.12 (VR) |
| Last Update | September 11, 2019 — VR support patch; no further major content updates |
| Executable | `TheForest.exe` |
| Data Folder | `TheForest_Data/Managed/` |
| Mods Folder | `mods/TheForest/` |
| Projects Folder | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — fully supported |

The Forest was upgraded from Unity 4 to Unity 5, significantly improving visuals and physics. The September 2019 VR patch was the final major update. The game now remains in a stable, finalized state — ideal for modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Item | Value |
|---|---|
| Engine | Unity (integrated codebase, unified with Below Zero in 2022) |
| Latest Version | 2025 Patch (v18810395) |
| Last Update | August 12, 2025 — bug fixes and performance improvements alongside mobile release |
| Executable | `Subnautica.exe` |
| Data Folder | `Subnautica_Data/Managed/` |
| Mods Folder | `mods/Subnautica/` |
| Projects Folder | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — supported |

Originally built on Unity 5, Subnautica received the 'Living Large' update (v2.0) in late 2022 which merged the engine codebase with Below Zero for improved optimization and stability. Note: the upcoming *Subnautica 2* uses Unreal Engine 5.

> **XML rewritten in v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` added to `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Item | Value |
|---|---|
| Engine | Unity |
| Latest Version | v1.1.02 (Beta) / v1.09 (Stable) |
| Last Update | March 2026 — voice chat and multiplayer bug fixes via beta branch |
| Executable | `Raft.exe` |
| Data Folder | `Raft_Data/Managed/` |
| Mods Folder | `mods/Raft/` |
| Projects Folder | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — supported |
| Versions.xml | `1.1.01` (with checksum) |

After the official story conclusion in v1.0: *The Final Chapter*, patches have continued for network code improvements and stability. A beta branch update in March 2026 addressed voice chat and multiplayer issues.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Item | Value |
|---|---|
| Engine | Unity 6 (migrated from Unity 2021/2022 in late 2025) |
| Latest Version | v0.67.0.0 |
| Last Update | June 26, 2025 — island distribution rework and engine update; hotfixes ongoing into 2026 |
| Executable | `EscapeThePacific.exe` |
| Data Folder | `EscapeThePacific_Data/Managed/` |
| Mods Folder | `mods/EscapeThePacific/` |
| Projects Folder | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — supported |

Completed a major system rebuild and Unity 6 migration in late 2025, enabling more dynamic environments. The game remains in active Early Access development.

> **XML rewritten in v2.0.9610**: `extends="GenericUnityGame"` removed; `includeAssembly` set to `Assembly-CSharp.dll` only — prevents `Assembly-CSharp-firstpass.dll` inheritance errors.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Item | Value |
|---|---|
| Engine | Unity 2019 |
| Latest Version | v2.9.5 |
| Last Update | February 4, 2026 — Steam Deck optimization and text readability improvements |
| Executable | `GH.exe` |
| Data Folder | `GH_Data/Managed/` |
| Mods Folder | `mods/GH/` |
| Projects Folder | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — supported |
| Versions.xml | `2.9.5` (with checksum) |

Developed through Unity 2017 → 2018 → 2019 across its lifecycle. The February 2026 hotfix focused on Steam Deck compatibility and UI readability.

> **XML rewritten in v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` added; non-existent `DOTweenPro.dll` removed.
</details>

---

## Architecture

### Runtime Split

| Component | Target | Runtime | Reason |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop application, full modern API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Shared library |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Permanently fixed** — PE header must read `v2.0.50727` |
| Mod DLLs (user) | .NET Framework 4.8 | Game Mono 2.0 (patched) | Built with 4.8, PE header patched at Apply time |

### Debug / Release Build Split

All file validation and assembly processing branches on the build configuration via `#if DEBUG` / `#else`.

| Location | Debug Build | Release Build |
|---|---|---|
| `CheckSteam()` | `File.Exists()` only — dummy files pass | `FileValidator.IsValidSteamExe()` — PE header + min 1 MB |
| `CheckGamePath()` | `File.Exists()` only — dummy files pass | `FileValidator.IsValidAssemblyDll()` — PE header + CLR metadata + min 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — skip Cecil parsing | Full Mono.Cecil parse + IL modification + `module.Write()` |
| `ModLib.Create()` — file not found | Log warning, skip and continue | Log error, abort with popup |

**Debug testing** uses `create_dummy_Debug_games.ps1` to generate 0-byte placeholder files under `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\`, and `bin\Debug\gamefiles\original\`. These pass `File.Exists()` checks and allow full UI workflow testing without a real game installation.

**Release builds** apply `FileValidator` (PE header + .NET CLR metadata verification) to reject 0-byte files, text files, and arbitrary binaries. Only valid Windows executables and .NET assemblies pass.

### FileValidator — PE Header Verification

`ModAPI_Shared\Utils\FileValidator.cs` — applied in Release builds only.

| Method | Checks | Min Size |
|---|---|---|
| `IsValidSteamExe(path)` | MZ signature + PE\0\0 signature | 1 MB |
| `IsValidGameExe(path)` | MZ signature + PE\0\0 signature | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR metadata header (data directory #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Assembly Remapping Pipeline

```
[Mod Developer builds with .NET 4.8]
  → Mod DLL: PE header v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, etc.
  → modModule.RuntimeVersion = "v2.0.50727"
      PE header: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → PE header accepted ✅  →  References resolved ✅
```

### Assembly Resolver Fallback

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### C# 7.3 Feature Support

| Feature | Status | Notes |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ | In-game verified |
| String interpolation (`$""`) | ✅ | In-game verified |
| `out` variable inline | ✅ | In-game verified |
| `async` / `await` | ✅ | Via AsyncBridge + System.Threading polyfills |
| Tuples (`ValueTuple`) | ❌ Hard limit | Mono 2.0 `mscorlib` ABI — no workaround |

### Theme System [Detailed Reference](Docs/v2.0.9613_themes_en.md)

As of v2.0.9613, the theme selection UI has been moved from the Settings tab to a dedicated **Themes tab**. Adding a new theme requires only one line in the `App.xaml.cs` dictionary.

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` only | Original ModAPI texture background |
| 1 | `light` | `FluentStylesLight.xaml` | Light tone + blue accent |
| 2 | `dark` | `FluentStyles.xaml` | Dark tone + blue accent (default) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Red + black |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dark space |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Bright sunset |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dark ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Bright Nordic |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Bright citrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Bright floral |

Theme changes trigger an automatic app restart. (saved to `theme.cfg`)

| Theme | Theme |
| :---: | :---: |
|**01. Classic theme**|**02. Light theme**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Dark theme**|**04. Diablo theme**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Nebula theme**|**06. Sunset theme**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Ocean theme**|**08. Nordic theme**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Citrus theme**|**10. Bloom theme**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### Background Texture

Select an image in the **Background Texture** card on the Themes tab to apply it as the app-wide background. Supported formats: `.png` / `.jpg` / `.jpeg`, up to 50MB, 4K resolution or below. The image is compressed as JPEG Q75 with a 16-byte magic header and saved as `resources\textures\ui_bg\bg.dat` (Hidden attribute). SHA-256 hash for integrity verification; tampering triggers automatic reset + warning popup.

When the background is active, UI transparency is processed in two layers: Layer 1 (MergedDictionaries overlay) for `{DynamicResource}` panels, Layer 2 (WalkStyleBackgrounds) for `{StaticResource}`-based panels with semi-transparency.

### Font Size System

| Resource Key | Base | Description |
|---|---|---|
| `AppBaseFontSize` | 13 | Normal text |
| `AppBaseHeaderFontSize` | 16 | Headers, panel titles |
| `AppBaseSmallFontSize` | 12 | Secondary labels |
| `AppBaseTinyFontSize` | 10 | Hint text |
| `AppBaseLargeFontSize` | 20 | Large display text |

### Persistent UI Configuration — `ui.cfg`

| Key | Default | Description |
|-----|---------|-------------|
| `ModListWidth` | `150` | Mods tab list width (px) |
| `ProjectListWidth` | `150` | Development tab project list width (px) |
| `AppFontSize` | `13` | Global UI font size (px) |
| `AlwaysOnTop` | `false` | Window always-on-top |
| `TexturePath` | *(none)* | Background texture original filename (display only) |
| `TextureHash` | *(none)* | Background texture SHA-256 hash |
| `TextureActive` | `false` | Background texture activation state |
| `GamePathReset_{GameId}` | *(none)* | Game path reset flag |
| `SteamPathReset` | *(none)* | Steam path reset flag |

### File Structure

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Persistent UI settings
├── theme.cfg                            # Current theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Main UI — 6 tabs, Themes, Settings, Steam path
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Game path popup (dynamic GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # First-run setup + default initialization
│       └── (14 other SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Classic theme
│   ├── FluentStyles.xaml                # Dark theme
│   ├── FluentStylesLight.xaml           # Light theme
│   ├── FluentStylesDiablo.xaml          # Diablo theme
│   ├── FluentStylesNebula.xaml          # Nebula theme
│   ├── FluentStylesSunset.xaml          # Sunset theme
│   ├── FluentStylesOcean.xaml           # Ocean theme
│   ├── FluentStylesNordic.xaml          # Nordic theme
│   ├── FluentStylesCitrus.xaml          # Citrus theme
│   └── FluentStylesBloom.xaml           # Bloom theme
├── Data/
│   ├── Game.cs                          # Assembly patching, null guards, resolver fallback
│   ├── ModLib.cs                        # BaseModLib generation + remapping (#if DEBUG split)
│   ├── Models/
│   │   └── ModProject.cs                # Project create/build/apply + null guards
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter
│   │   ├── ModViewModel.cs              # GameId from folder path
│   │   ├── ModProjectsViewModel.cs      # Dispose() for DispatcherTimer
│   │   └── SettingsViewModel.cs         # Default true for UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mono 2.0 assembly version mapping (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Name-based resolver with caching
│   └── MonoHelper.cs                    # Mono.Cecil IL helper utilities
├── resources/
│   ├── langs/                           # 13 language files
│   └── textures/ui_bg/
│       └── bg.dat                       # Compressed & secured background image (runtime-generated)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Full rewrite v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Full rewrite v2.0.9610
    │   ├── GH.xml                       # Full rewrite v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — not supported
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Lightweight constructor + ModLibrary init fix
│   └── ModLib.cs                        # #if DEBUG split for Cecil parsing
└── Utils/
    └── FileValidator.cs                 # PE header + CLR metadata validation (Release only)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Standalone WPF version update tool

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generates dummy game/steam structure
├── dummy_games\{GameId}\               # Dummy game install paths
├── dummy_steam\Steam.exe               # Dummy Steam executable
└── gamefiles\original\{GameId}\        # Dummy backup paths for ModLib
```

---

## Installation & Setup

### Step 1 — Prerequisites

| Item | Required |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (pre-installed on Windows 11; [download](https://dotnet.microsoft.com/download/dotnet-framework/net48) for Windows 10) |
| Steam | Required — must be configured in Settings tab |
| At least one supported game | Required — must be configured in Settings tab |

### Step 2 — Install ModAPI

1. Download the latest release from GitHub
2. Extract to any folder (e.g. `C:\ModAPI\`)
3. Run `ModAPI.exe`
4. On first launch the **Welcome** screen appears — configure preferences and click **Continue**

### Step 3 — Configure Steam Path (Settings Tab)

1. Go to the **Settings** tab
2. Find **Steam Installation Path**
3. Click **Browse** → select `Steam.exe`
4. Click **Save**

### Step 4 — Configure Game Paths (Settings Tab)

1. Click a game card header to expand it
2. Click **Browse** → select the game root folder (where the `.exe` is located)
3. Click **Save**

| Game | Executable | Example Path |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Step 5 — Download Mods (Downloads Tab)

1. Go to the **Downloads** tab
2. Select a game from the game filter
3. Browse or search for a mod and click **Download**

> **Offline**: Download `.mod` files manually from `modapi.survivetheforest.net` and place them in the corresponding folder:

| Game | Folder |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Step 6 — Apply Mods & Start Game (Mods Tab)

1. Go to the **Mods** tab
2. Select a game from **Game Filter** (Col 0)
3. Check mods to activate in **Mod List** (Col 1)
4. Click **Start Game**

The following checks run automatically before launch:

| # | Check | Failure Popup |
|---|---|---|
| 1 | Steam path configured and valid | SteamNotFound |
| 2 | `mods/` folder game matches Settings game path | GameModsMismatch |
| 3 | At least one mod selected | NoModSelected |
| 4 | No mixed-game mods in selection | MixedGameMods |
| 5 | Game path configured and executable exists | GamePathNotSet / GameNotInstalled |

---

## Tab Overview

### Welcome Tab
First-run setup screen (tab index 0). Configure AutoUpdate, Steam connection, and VersionsData table preferences. On subsequent launches this tab provides community links and release notes.

### Mods Tab
Primary mod management workflow — 3-column layout:

| Column | Content |
|---|---|
| Col 0 | Game Filter — radio buttons for 5 supported games |
| Col 1 | Mod List — installed mods with version picker and activation checkbox |
| Col 2 | Information — selected mod details, description, version history |

### Downloads Tab
Browse and download mods from `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 categories (Bugfixes, Balancing, Cheats, …)
- **Search**: by mod name, description, or author
- **Offline mode**: displays folder instructions for all 5 supported games

### Development Tab
Mod development workflow — game filter panel (Col 0) covers all 5 supported games.

- Create, build, and apply mod projects per game
- Language resource management
- ModLib generation with 3-step validation (Steam → project → game path)
- Safe game switching via lightweight `Game` constructor (no `Verify()` call)

### Themes Tab
Theme selection and background texture management.

- **Theme selection**: 10 themes (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Background texture**: Select an image as the app-wide background (JPEG compression + security processing)
- When background texture is active, theme selection is locked

### Settings Tab
Centralized configuration — 4 rows:

| Row | Content |
|---|---|
| 0 | Language / Font Size / Max Width / Mod List Width / Project List Width |
| 1 | Keep VersionsData / Auto Update / Steam Connection / Always On Top |
| 2 | Steam Installation Path (TextBox + Browse + Save + Reset) |
| 3 | Game Installation Paths — expandable card per game (TextBox + Browse + Save + Reset) |

---

## What Changed in v2.0.9618

### Version Update Tool (MODAPI_VersionTool)

A standalone WPF tool for updating the version number with a single click.

**Location**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Features**
- Automatically displays the current version (read from `App.xaml.cs`)
- Enter a new version and click **Apply Version** to update both files simultaneously
- Format validation: only `X.X.XXXX` format accepted

**Files Modified**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Usage**
1. Run `MODAPI_VersionTool.exe`
2. Enter new version (e.g. `2.0.9619`)
3. Click **Apply Version**
4. Rebuild the ModAPI solution in Visual Studio

### StatusBar Version Display Fixed

- `VersionLabel.Text` now references `App.Version` instead of the hardcoded `Version.Descriptor`
- Updating the version with VersionTool and rebuilding now reflects immediately in the StatusBar

---

## What Changed in v2.0.9617

### Settings Tab — Path Reset Buttons Added

A **Reset** button has been added to the Steam installation path and each game installation path row.

**Steam path row**
```
[TextBox] [Browse] [Save] [Reset]
```

**Game path row (per game)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Reset behavior**
- Clears the path TextBox immediately
- Saves a reset flag to `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox remains empty after restart
- Works around Configuration XML not persisting empty strings

**Browse auto-save**
- Before: required a separate Save button click after Browse
- After: automatically saved on file selection — reflected even after switching to the Mods tab

**New language key**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## What Changed in v2.0.9616

### Versions.xml — 4 Games Added / Updated

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Newly created |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum updated |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Newly created |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum updated |

### Checksum Composition Rules

The checksum format differs depending on whether `Assembly-CSharp-firstpass.dll` exists for each game.

| Game | firstpass.dll | Checksum Format |
|---|---|---|
| GH | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| Subnautica | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| EscapeThePacific | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| Raft | ❌ Not present | `Assembly-CSharp MD5` only (32 chars) |

### Versions.xml Update Procedure on Game Update

Add a new `<version>` entry without removing existing entries.

**Step 1 — Find new BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Step 2 — Extract new checksum**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Step 3 — Add entry to Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## What Changed in v2.0.9615

### Settings Tab Game Path Expand Fixed

- **Card expand height**: The window bottom now grows by exactly the height of the input field when expanding a game path card
- **`UpdateWindowHeight()` improved**: Calls `UpdateLayout()` before `SizeToContent.Height` measurement; temporarily sets `TextureLayer1` to `Collapsed` when background texture is active to prevent 4K image original size from affecting height calculation
- **Inner Grid Row fix**: Changed the last Row of the game paths panel inner Grid from `Height="*"` to `Height="Auto"` — removes unnecessary bottom whitespace

---

## What Changed in v2.0.9614

### Maximize Button Behavior Fixed

- **Maximize**: Uses `SystemParameters.WorkArea` for manual maximization instead of `WindowState.Maximized` — fits exactly to the current screen resolution without overlapping the taskbar
- **Restore**: Saves `Left`, `Top`, `Width`, `Height`, and `MaxWidth` before maximizing and restores them when the restore button is clicked
- **`MaxWidth` handling**: Set to `∞` on maximize, restored to saved value on normalize

---

## What Changed in v2.0.9613

### New Themes Tab

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

The theme selection UI has been moved from the Settings tab to a dedicated **Themes tab**.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Theme Registry (Data-Driven Structure)

Adding a new theme now requires only **one line** in the `App.xaml.cs` dictionary.
All switch statements have been removed — no code changes needed elsewhere.

```csharp
// App.xaml.cs
public static readonly Dictionary<string, string> ThemeRegistry = new Dictionary<string, string>
{
    { "classic", null },
    { "light",   "FluentStylesLight.xaml" },
    { "dark",    "FluentStyles.xaml" },
    { "diablo",  "FluentStylesDiablo.xaml" },
    { "nebula",  "FluentStylesNebula.xaml" },
    { "sunset",  "FluentStylesSunset.xaml" },
    { "ocean",   "FluentStylesOcean.xaml" },
    { "nordic",  "FluentStylesNordic.xaml" },
    { "citrus",  "FluentStylesCitrus.xaml" },
    { "bloom",   "FluentStylesBloom.xaml" },
};

public static readonly List<string> ThemeIds = new List<string>(new[]
{
    "classic", "light", "dark", "diablo",
    "nebula", "sunset", "ocean", "nordic", "citrus", "bloom"
});
```

`ThemeSelector` ComboBox items are auto-generated from the `ThemeIds` loop.
Language key convention: `Lang.Options.Theme.{PascalCase}` (e.g. `Lang.Options.Theme.Nebula`)

### Supported Themes

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` only | Original ModAPI texture background |
| 1 | `light` | `FluentStylesLight.xaml` | Light tone + blue accent |
| 2 | `dark` | `FluentStyles.xaml` | Dark tone + blue accent (default) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Red + black |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dark space |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Bright sunset |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dark ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Bright Nordic |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Bright citrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Bright floral |

Theme changes trigger an automatic app restart. (saved to `theme.cfg`)

### Background Texture Feature

Select an image in the **Background Texture** card on the Themes tab to apply it as the app-wide background. Works with any theme selected.

**Supported input formats**: `.png` / `.jpg` / `.jpeg`, up to 50MB, 4K resolution or below

**Image processing pipeline**

```
User-selected image (.png / .jpg / .jpeg, max 50MB, 4K or below)
  ↓
JPEG Q75 compression (memory buffer)
  ↓
16-byte magic header inserted
  "MODAPI" + "BG" + version + padding (FF 00 FE 00)
  ↓
Saved as resources\textures\ui_bg\bg.dat (Hidden attribute)
  ↓
SHA-256 hash → stored in ui.cfg as TextureHash
```

**Security layers**

| Layer | Method | Effect |
|---|---|---|
| Magic header | 16 bytes prepended before JPEG signature (FF D8 FF) | External viewers cannot recognize the file |
| Hidden attribute | `FileAttributes.Hidden` | Hidden from Explorer by default |
| SHA-256 integrity | Hash verified on load | Tampering triggers automatic reset + warning popup |

**Tampering detection behavior**
1. `bg.dat` deleted
2. `ui.cfg` keys `TexturePath`, `TextureHash`, `TextureActive` reset
3. TextBox and toggle reset
4. `Lang.Windows.TextureTampered` popup displayed

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**Transparency processing**

When the background image is active, UI backgrounds are processed in two layers.

- **Layer 1 — MergedDictionaries overlay**: Panels referencing `{DynamicResource FluentBgBrush}` etc. are automatically made transparent. Restored with a single `Remove()` call on deactivation.

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — Visual tree walk (`WalkStyleBackgrounds`)**: `{StaticResource}` elements in Fluent themes are unaffected by Layer 1, so the visual tree is traversed directly to apply semi-transparent brushes based on original colors.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  Processed: `Panel` (except Grid), `Border`, `ListBox` / `ListView`

  Excluded: `Grid` (background preserved, children traversed), `TabPanel` (tab header protection), `ButtonBase` / `ComboBox`, `Collapsed` elements

  Restore: Style Setter source → `ClearValue()`, XAML local value source → restore original brush directly

**Tab switching**

WPF TabControl lazy-loads tab content, so `WalkStyleBackgrounds(this)` is re-run at `ContextIdle` priority on tab change. Already-processed elements are skipped via `ContainsKey` check.

**ThemeSelector lock**

When background texture is active, a `ThemeSelectorOverlay` Border is shown over the theme selector to block interaction.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` also guarded by `_textureActive` flag

**UI state flow**

```
Image selected (Browse)
  → bg.dat created → toggle unlocked → auto-activate → TextureLayer1 shown
  → SaveAndClearBrushes() → ThemeSelectorOverlay shown

Toggle deactivated
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay hidden
  → TextureLayer1 hidden

Clear button
  → bg.dat deleted → toggle locked → TextureLayer1 hidden → brushes restored
  → GC.Collect() (releases 4K image memory)
```

**New language keys**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**File structure**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Themes tab, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Theme & texture logic
├── Themes\
│   ├── Dictionary.xaml            # Classic theme
│   ├── FluentStyles.xaml          # Dark theme
│   ├── FluentStylesLight.xaml     # Light theme
│   ├── FluentStylesDiablo.xaml    # Diablo theme
│   ├── FluentStylesNebula.xaml    # Nebula theme
│   ├── FluentStylesSunset.xaml    # Sunset theme
│   ├── FluentStylesOcean.xaml     # Ocean theme
│   ├── FluentStylesNordic.xaml    # Nordic theme
│   ├── FluentStylesCitrus.xaml    # Citrus theme
│   └── FluentStylesBloom.xaml     # Bloom theme
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Compressed & secured background image (runtime-generated)
```

**Known design constraints**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Direct `MergedDictionaries` key replacement | Crashes during layout pass → `Add`/`Remove` pattern only |
| Overwriting Hidden file | `Access Denied` → must reset `FileAttributes.Normal` before writing |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## What Changed in v2.0.9612

### Theme Module Separation

- **New `Themes/` folder**: Moved `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml`, and `FluentStylesClassic.xaml` to `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — Classic theme uses `Dictionary.xaml` only; Light/Dark/other Fluent themes load corresponding XAML
- **`ModAPI.csproj`**: Updated theme XAML paths to `Themes\` subdirectory; registered `FluentStylesClassic.xaml`

---

## What Changed in v2.0.9611

### Bug Fix

- **Mod list width not applied after theme switch**: Fixed an issue where the Mod list width was not applied after switching between Light/Dark themes and restarting — added `ApplyModListWidth(width)` call inside `InitModListWidth()`

---

## What Changed in v2.0.9610

### Added

#### Game XML & Versions Configuration

| # | File | Change |
|---|------|--------|
| 1 | `GH.xml` | Full rewrite — removed non-existent `DOTweenPro.dll`; added `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Full rewrite — removed `extends="GenericUnityGame"`; added `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Full rewrite — removed `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Created — version `1.1.01` with checksum |
| 5 | `GH/Versions.xml` | Created — version `2.9.5` with checksum |
| 6 | `Subnautica/Versions.xml` | Created — no checksum (updates too frequently) |

#### Critical Bug Fixes

| # | Type | Issue | Fix |
|---|------|-------|-----|
| 1 | Hang | `extends="GenericUnityGame"` caused `Assembly-CSharp-firstpass.dll` inheritance → `CreateModLibrary` stalled | Removed `extends` from all non-TheForest XML |
| 2 | Crash | `ResolutionException: XGamingRuntime.XUserGamertagComponent` during Subnautica apply | Added `XGamingRuntime.dll`, `XblPCSandbox.dll` to `copyAssembly` |
| 3 | Crash | Resolver failed on DLLs added to `copyAssembly` after backup created | `Game.cs`: actual install folder added as resolver fallback |
| 4 | Crash | `IOException`: `BaseModLib.dll` file-lock between `CreateModLibrary` and `ApplyMods` | Retry loop: max 10 × 500ms read + max 30 × 500ms existence wait |
| 5 | Crash | `NullReferenceException` — `typesMap` entry.Value null (game not installed) | Added `if (entry.Value == null) continue` |
| 6 | Crash | `NullReferenceException` — lightweight `Game` constructor missing `ModLibrary = new ModLib(this)` → `CreateModLibrary()` crash | Added `ModLibrary = new ModLib(this)` to lightweight constructor |
| 7 | Crash | `SwitchDevGame()` — `App.Game.GamePath` empty after lightweight constructor → `CreateModLibrary` crash | Set `App.Game.GamePath = savedPath` after lightweight constructor |
| 8 | Wrong Game | `EscapeThePacific` mods classified as TheForest | `ModsViewModel`: `GameId` extracted from folder path |
| 9 | Wrong Path | `GetGameFolder()` → `""` → resolves to drive root (e.g. `E:\`) | Null/empty guard at all 6 call sites |

#### Debug / Release Build Split

- **`FileValidator.cs`** — new file `ModAPI_Shared\Utils\FileValidator.cs`; registered in `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — PE header (MZ + PE\0\0) + minimum 1 MB
  - `IsValidGameExe()` — PE header + minimum 512 KB
  - `IsValidAssemblyDll()` — PE header + .NET CLR metadata header + minimum 64 KB
- **`CheckSteam()`** — `#if DEBUG`: `File.Exists()` only / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: `File.Exists()` only / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` skip Cecil / `#else`: full Cecil parse + IL modification
- **`ModLib.Create()` file not found** — `#if DEBUG`: log warning, skip / `#else`: log error, abort

#### Debug Testing

- **`create_dummy_Debug_games.ps1`** — PowerShell script for `bin\Debug\`; creates 0-byte placeholder files for all 5 games under `dummy_games\`, `dummy_steam\`, and `gamefiles\original\` — enables full UI workflow testing without real game installation

#### Settings Tab

- **Steam path card** — integrated into Game Installation Paths card; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Game paths panel** — `BuildGamePathsPanel()` with per-game expandable cards; TextBox uses `HorizontalAlignment=Stretch`
- **Expand All / Collapse All** button
- **AlwaysOnTop** checkbox (saved to `ui.cfg`)
- **Mod/Project List Width** sliders — start at minimum `150`; saved to `ui.cfg`
- **Font Size** ComboBox — FHD 10–16, 4K 10–22, 8K 10–28
- **Checkbox sync** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions now sync correctly
- **`_uiInitialized` flag** — prevents premature `ui.cfg` writes during WPF startup

#### Mods Tab — Start Game Validation

Five-step validation runs on every Start Game click, regardless of mod list state:

| Step | Check | Popup |
|---|---|---|
| 1 | Settings tab Steam path valid (`Steam.exe` exists) | SteamNotFound |
| 2 | `mods/{GameId}/` folder game matches Settings configured game | GameModsMismatch |
| 3 | At least one mod selected | NoModSelected |
| 4 | No mixed-game mods in selection | MixedGameMods |
| 5 | Game path configured + executable exists | GamePathNotSet / GameNotInstalled |

#### Development Tab — ModLib Validation

Three-step validation on Mod Library Regeneration click:

| Step | Check | Popup |
|---|---|---|
| 1 | Settings tab Steam path valid | SteamNotFound |
| 2 | At least one project exists | NoProjectWarning |
| 3 | `App.Game.GamePath` set | GamePathNotSet |

#### Downloads Tab
- Debug string replaced with `Lang.Downloads.Status.NoDownloads`
- Consistent padding for all status messages
- Offline manual text updated for 5 supported games; line-break via two TextBlocks

#### First Setup & Game Path System
- `FirstSetup.Check()` — default `true` for `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — creates `mods/` and `projects/` folders for all 5 games
- `SpecifyGamePath` — `GameNameLabel` shows which game; `NavigateToSettings()` routes to Settings tab

#### New / Updated Language Keys

| Key | English Value |
|-----|---------------|
| `Lang.Downloads.Status.NoDownloads` | No downloadable files for this mod. |
| `Lang.Options.Labels.ModListWidth` | Mod List Width |
| `Lang.Options.Labels.ProjectListWidth` | Project List Width |
| `Lang.Options.Labels.FontSize` | Font Size |
| `Lang.Options.Labels.MaxWidth` | Max Width |
| `Lang.Development.Labels.GameFilter` | Game Filter |
| `Lang.Options.Labels.SteamPath` | Steam Installation Path |
| `Lang.Windows.SteamNotFound.Title` | Steam Not Found |
| `Lang.Windows.SteamNotFound.Text` | Steam is not installed. Please configure Steam in the Settings tab. |
| `Lang.Windows.GameModsMismatch.Title` | Game Mismatch |
| `Lang.Windows.GameModsMismatch.Text` | The game in the mods folder does not match the game configured in the Settings tab. |
| `Lang.Downloads.Offline.Manual2` | (e.g. mods/TheForest, mods/Subnautica, …) |

### Not Included

| Feature | Reason |
|---|---|
| Auto-update (keep latest version) | Server-side infrastructure not available |
| Update search | Server-side infrastructure not available |

### Removed

| Item | Reason |
|---|---|
| `SpecifyGamePath` popup on startup | All paths configured in Settings tab |
| `SpecifySteamPath` popup on startup | Steam path configured in Settings tab |
| Login system | Original server no longer operational (removed in v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Non-functional on Mono 2.0 (removed in v2.0.9586) |
| `UseSteam` condition on Steam check | Steam is now always validated first on Start Game and Mod Library Regeneration |

---

## Planned for Future Releases

| # | Feature | Description |
|---|---|---|
| 1 | ModAPI Auto-Update | Automatically download and apply new ModAPI releases |
| 2 | ModAPI VersionsData Table Update | Automatically update the game VersionsData table when new game patches are released |

---

## What Changed in v2.0.9600

### Added

- **Downloads tab**: 5 game filters (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome tab**: added at leftmost position (index 0)
- **Mods tab**: 3-column layout (WrapPanel → vertical list); automatic width adjustment; mod name wrapping
- **`ModsViewModel`**: game-specific filtering, `ResolveGame()` for correct `Game` instance per mod
- **`Game.cs`**: lightweight constructor `new Game(config, true)` — identification only, no `Verify()`
- **Build**: 4 game XML files registered in `ModAPI.csproj` with `CopyToOutputDirectory=Always`
- **Build**: warnings cleaned — CS0168, CS0618, CS0252
- **Game XML**: TheForest, Raft, GH DLL lists corrected
- **Language flags**: image sizes standardized across all 13 language badges

### Removed

| Item | Reason |
|---|---|
| `extends="GenericUnityGame"` in game XML files | Caused `Assembly-CSharp-firstpass.dll` to be incorrectly inherited — removed from Subnautica, Raft, EscapeThePacific, GH |
| `WrapPanel` layout in Mods tab | Replaced with 3-column Grid layout (Game Filter / Mod List / Information) |

---

## Key Changes by Phase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
All 5 projects migrated from .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, UnityEngine stub DLL.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
3-theme system, `theme.cfg`, window drag fix, hyperlink support.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Login system removed, update mechanism modernized.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Downloads tab, Segoe MDL2 Assets icons, 13-language support.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, PE header patching.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Black screen fixed, `ValueTuple` removed, C# 7.3 in-game verified.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 game filters, 3-column Mods tab, lightweight `Game` constructor, XML registered.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML corrected, Steam path, game path safety, Start Game 5-step validation, ModLib 3-step validation, `FileValidator` PE header verification, `#if DEBUG` build split, `create_dummy_Debug_games.ps1`, lightweight constructor `ModLibrary` fix, `SwitchDevGame` GamePath fix, 5-game folder creation, crash fixes.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Themes tab added, 10 themes + background texture feature, Themes/ folder separation, maximize button fix, game path expand fix, Versions.xml 4-game update, path reset buttons, Browse auto-save, MODAPI_VersionTool.

---

## Version History

### v2.0.9618 — 2026-04-25
Added MODAPI_VersionTool (standalone WPF version update tool), StatusBar version display linked to App.Version

### v2.0.9617 — 2026-04-24
Added Steam/game path reset buttons in Settings tab, Browse auto-save, reset state preserved via ui.cfg flag

### v2.0.9616 — 2026-04-18
Versions.xml created/updated for 4 games (Subnautica, Raft, EscapeThePacific, GH), checksum composition rules established, game update procedure documented

### v2.0.9615 — 2026-04-18
Settings tab game path card expand height accuracy fixed, UpdateWindowHeight background texture interference prevention

### v2.0.9614 — 2026-04-18
Maximize button WorkArea-based manual maximize, previous size/position save and restore

### v2.0.9613 — 2026-04-18
Themes tab added, theme registry data-driven structure, 10 themes supported, background texture feature (compression, security, 2-layer transparency), ThemeSelector lock overlay, 12 new language keys

### v2.0.9612 — 2026-04-18
Themes/ folder separation, theme XAML modularization

### v2.0.9611 — 2026-04-18
Fixed Mod list width not applied after theme switch

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 game filters, Mods tab 3-column layout, auto width, lightweight `Game` constructor, `ModsViewModel` game filtering, 4 XML files registered, build warnings cleaned, Welcome tab, language flags standardized

### v2.0.9586 — 2026-03-31
Black screen fixed, polyfill finalized, ValueTuple removed, C# 7.3 verified

### v2.0.9561 — 2026-03-06
C# 7.3 support, PE header patching, polyfill pipeline, assembly resolution restored

### v2.0.9552 — 2026-02-25
Downloads tab, icon modernization, theme unification, 13-language support

### v2.0.9500
Theme system (Classic/Light/Dark), Fluent Design UI, SubWindow system

### v2.0.9400
Code cleanup, login removal, legacy modernization

### v2.0.9300
Build environment, UnityEngine stub DLL, ModernWpf integration

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Build Requirements

| Requirement | Version | Notes |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI projects |
| .NET Framework SDK | 3.5 | BaseModLib only |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## License

GNU General Public License v3.0 — follows the original license.
