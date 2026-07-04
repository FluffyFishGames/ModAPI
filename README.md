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

# ModAPI(v1) v2.0.9620 - 20260621

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

<details>
<summary><b>Architecture</b></summary>

### Runtime Split

| Component | Target | Runtime | Reason |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop application, full modern API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Shared library |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Permanently fixed** — PE header must read `v2.0.50727` |
| Mod DLLs (user) | .NET Framework 4.8 | Game Mono 2.0 (patched) | Built with 4.8, PE header patched at Apply time |

### Developer Tools

Standalone WPF utilities for project management. Not distributed to end users.

| Tool | Project | Purpose |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Updates `AssemblyInfo.cs` and `App.xaml.cs` version simultaneously |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Manages language files — add, edit, deactivate, built-in conversion |

**VersionTool — Version Management**

A standalone WPF tool for updating the version number with a single click.

- Automatically displays the current version (read from `App.xaml.cs`)
- Enter a new version and click **Apply Version** to update both files simultaneously
- Format validation: only `X.X.XXXX` format accepted

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Language System**

```
resources/langs/langs.json          ← Language registry (builtin / active flags)
resources/langs/Language.XX.xaml    ← Translation keys per language
resources/langs/Language.XX.png     ← Flag image (36×24, from flagcdn.com/h24/)
```

Built-in conversion flow (Update button):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() rewritten (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml registered (ModAPI\ModAPI.csproj)
  → Next build: language fully embedded, available offline
```

### Debug / Release Build Split

All file validation and assembly processing branches on the build configuration via `#if DEBUG` / `#else`.

| Location | Debug Build | Release Build |
|---|---|---|
| `CheckSteam()` | `File.Exists()` only — dummy files pass | `FileValidator.IsValidSteamExe()` — PE header + min 1 MB |
| `CheckGamePath()` | `File.Exists()` only — dummy files pass | `FileValidator.IsValidAssemblyDll()` — PE header + CLR metadata + min 8 KB |
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
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR metadata header (data directory #14) | 8 KB |

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
</details>

<details>
<summary><b>Theme System [Detailed Reference](Docs/v2.0.9613_themes_en.md)</b></summary>

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
| ![01. Classic theme](https://github.com/user-attachments/assets/dc81132a-149c-4d0b-a7bb-a04a900e878b) | ![02. Light theme](https://github.com/user-attachments/assets/0d6925ec-f8b2-4f8a-a1d6-c082a5aa3378) |
|**03. Dark theme**|**04. Diablo theme**|
| ![03. Dark theme](https://github.com/user-attachments/assets/53abe172-ee66-4f3e-9c36-830b2d659b4d) | ![04. Diablo theme](https://github.com/user-attachments/assets/8c30f223-e564-45dc-8389-c51bfc60b3eb) |
|**05. Nebula theme**|**06. Sunset theme**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/4ff565dd-516b-4951-9d47-6027ac9e3e29) | ![06. Sunset theme](https://github.com/user-attachments/assets/192a6f16-b041-4422-8b64-4f8522f27c15) |
|**07. Ocean theme**|**08. Nordic theme**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/50a47588-bc62-4cfc-91a0-a44f87c45867) | ![08. Nordic theme](https://github.com/user-attachments/assets/81e98f6b-2897-4fd5-bee9-604c04dc26ff) |
|**09. Citrus theme**|**10. Bloom theme**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/64ccb11d-4ab0-41a2-8e00-4f7910558372) | ![10. Bloom theme](https://github.com/user-attachments/assets/265c9249-4d43-4f77-86d6-ccc4037071f7) |

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
</details>

<details>
<summary><b>Project Structure</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Persistent UI settings
├── theme.cfg                            # Current theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Main UI — 6 tabs, Themes, Settings, Steam path,
│   │                                    #   0-byte download guard, slider debounce, silent config reads
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
│   ├── Mod.cs                           # Mod file loading, LF/CRLF header parsing, diagnostic log
│   ├── ModLib.cs                        # BaseModLib generation + remapping (#if DEBUG split)
│   ├── Models/
│   │   └── ModProject.cs                # Project create/build/apply + null guards
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   corrupted mod retry prevention
│   │   ├── ModViewModel.cs              # GameId from folder path
│   │   ├── ModProjectsViewModel.cs      # Dispose() for DispatcherTimer
│   │   └── SettingsViewModel.cs         # Default true for UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mono 2.0 assembly version mapping (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Name-based resolver with caching
│   └── MonoHelper.cs                    # Mono.Cecil IL helper utilities
├── resources/
│   ├── langs/                           # 13 language files + langs.json (LangTool.* keys added v2.0.9620)
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
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt with silent parameter
├── Data/
│   ├── Game.cs                          # ApplyMods backup auto-creation, conditional resolver,
│   │                                    #   game folder fallback, lightweight constructor + ModLib init fix
│   └── ModLib.cs                        # #if DEBUG split, game folder fallback for IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # PE header + CLR metadata validation (Release only, min 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Standalone WPF version update tool
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Version input, Apply button, current version display
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Standalone WPF language management tool
├── App.xaml / App.xaml.cs              # Language load/switch, langtool.cfg
├── MainWindow.xaml / .cs               # Main UI — language list, edit panel, path selector
├── AddLanguageDialog.xaml / .cs        # ISO 3166-1 country selector ComboBox
├── ModApiDialog.xaml / .cs             # ModAPI-style custom dialog (Info/Warning/Confirm/Ask)
├── Models/
│   ├── LanguageEntry.cs                # Language entry model (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # langs.json root model
│   └── IsoCountry.cs                   # ISO country model for ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # langs.json read/write
    ├── FlagDownloader.cs               # flagcdn.com h24 flag download
    ├── XamlGenerator.cs                # Language.XX.xaml generate/save/parse
    ├── MissingKeyDetector.cs           # English-reference missing key detection
    ├── IsoCountryList.cs               # ISO 3166-1 full country list (196 countries, offline)
    └── BuiltinCodeWriter.cs            # CreateDefaultLangsJson() rewrite + ModAPI.csproj registration

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generates dummy game/steam structure
├── dummy_games\{GameId}\               # Dummy game install paths
├── dummy_steam\Steam.exe               # Dummy Steam executable
└── gamefiles\original\{GameId}\        # Dummy backup paths for ModLib
```

---

</details>

<details>
<summary><b>Installation & Setup</b></summary>

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

</details>

<details>
<summary><b>Tab Overview</b></summary>

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

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Language Management Tool)

A standalone WPF tool for managing ModAPI language files. Added to the solution as `LangTool\MODAPI_LangTool.csproj`.

**Location**: `LangTool\MODAPI_LangTool.csproj`

**Core Features**

| Feature | Description |
|---|---|
| Language list | Displays all languages from `langs.json` with status icons (🔒 built-in / 🚫 inactive / ✅ active) |
| Language add | Select country from ISO 3166-1 ComboBox → flag auto-downloaded from `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` auto-generated from English template |
| Language edit | `isoCode` / `langCode` locked; `langName` and translation keys editable when active |
| Deactivate / Activate | Toggles `active` flag in `langs.json` — file preserved, hidden from ModAPI list |
| Update (built-in) | Converts `builtin: false` → `true` — irreversible, 2-step confirmation — auto-rewrites `CreateDefaultLangsJson()` in source and registers `Language.XX.xaml` in `ModAPI.csproj` |
| Missing key detection | Compares against English reference — shows missing / empty key count and translation progress |
| Built-in protection | `builtin: true` languages are read-only — no edit, deactivate, or update allowed |
| Inactive protection | `active: false` languages are read-only until reactivated |
| Language UI | LangTool itself supports all 13 ModAPI languages — language selector in top-right corner with flag |
| Path memory | Selected ModAPI root path saved to `langtool.cfg` — auto-loaded on next launch |
| Custom dialogs | All popups use ModAPI-style dark-themed `ModApiDialog` instead of system MessageBox |

**langs.json Structure**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Flag Image Convention**

```
ISO code (lowercase) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                     resources/langs/
```

**Update Button Behavior**

When the Update button is clicked on a non-built-in active language:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` rewritten with all current `builtin: true` languages
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` registered
4. Next build — language fully embedded, available offline

**Language Keys Added** (`Lang.LangTool.*`)

53 new keys added to all 13 language files covering all LangTool UI strings, dialog messages, and status texts.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Version Update Tool)

A standalone WPF tool for updating the version number with a single click.

**Location**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

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

**StatusBar Version Display**

- `VersionLabel.Text` references `App.Version` instead of a hardcoded descriptor
- Updating the version with VersionTool and rebuilding reflects immediately in the StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Logging System — Two-File Separation (`ModAPI.log` / `ModAPI.detailed.log`)

Developer-only diagnostic logs were previously gated with `#if DEBUG`, which meant they were invisible in Release builds exactly when troubleshooting a user's issue required them most. A two-file system replaces this:

| File | Contents |
|---|---|
| `ModAPI.log` | User-facing core log — unchanged in appearance, no noisier than before |
| `ModAPI.detailed.log` | Every log call, always, in Release and Debug alike — for diagnosing user-reported issues |

**`Debug.cs`** — `Log()` has a `detailedOnly` parameter. When `true`, the message is written only to `ModAPI.detailed.log`; all prior `#if DEBUG` blocks were converted to this flag instead of being compiled out entirely, so they're always captured in the detailed file even in Release. This results in a 4-tier severity model:

| Tier | Meaning |
|---|---|
| Verbose (`detailedOnly: true`) | Repetitive/mechanical traces — per-type, per-file, per-method |
| Notice | Human-readable flow — progress and success messages |
| Warning | Potential issues, not yet failures |
| Error | Confirmed failures |

**Sources of log noise identified and converted to `detailedOnly: true`:**

| File | What was flooding `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | `FindMods()` scan/skip/queue messages repeating every 1-second poll |
| `Game.cs` | `UpdateVersions()` TLS/URL trace lines, Cecil type-map entries |
| `ModLib.cs` | Cecil per-type/per-method assembly processing (`Validating`, `Processing`, `Changed ... accessibility`) — was responsible for the vast majority of `ModAPI.log` volume (tens of thousands of lines for a single Green Hell mod build) |
| `Mod.cs` | Full mod header XML dump (`configuration.ToString()`) logged in full on every mod load |

**Checksum mismatch logging — summarized instead of per-item:** `Header.Verify()` previously logged one `Mismatched checksum at "..."` line per incompatible `InjectInto`/`AddMethod`/`AddField`/`AddClass` entry, which could mean dozens of lines for a single outdated mod. It now logs a single Warning-level summary to `ModAPI.log` (e.g. `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), while the full per-item breakdown remains available in `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>What Changed in v2.0.9620</b></summary>

## What Changed in v2.0.9620

### MODAPI_LangTool Added

A standalone WPF tool for managing ModAPI language files was added (`LangTool\MODAPI_LangTool.csproj`) — see the **Lang Tool** section above for full details.

---

### Bug Fixes

| # | File | Issue | Fix |
|---|---|---|---|
| 1 | `App.xaml.cs` | French language mixed into .NET exception messages on non-English Windows | `CultureInfo.InvariantCulture` fixed at `App()` constructor startup |
| 2 | `Game.cs` | SSL/TLS error on `UpdateVersions()` — could not create SSL/TLS secure channel | TLS 1.2 explicitly set via `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Green Hell `GamePathNotSet` popup despite path being configured | `App.Game.GamePath` empty → reads saved path from `Configuration` |
| 4 | `ModsViewModel.cs` | Mod files not appearing in list when manually placed in `mods\TheForest\` | Filename pattern validation diagnostic log added |
| 5 | `MainWindow.xaml.cs` | `MixedGameMods` popup blocked multi-game mod selection | Removed blocking popup — replaced with `SelectGameDialog` |

---

### New Features

#### Start Game — Game Selection Popup (`SelectGameDialog`)

When mods from different games are selected, or when **All** filter is active, a game selection popup appears instead of blocking the launch.

**Trigger conditions:**
- `All` filter selected + Start Game clicked
- Mods from 2 or more different games are activated simultaneously

**Behavior:**
- Shows only games with configured paths + existing executable
- Selected game's mods only are applied — other game mods are completely ignored
- Radio button syncs to selected game after popup closes (`SyncModGameFilterRadioButton`)

**New files**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Game Integrity Verification (Release build only, `#if !DEBUG`)

Three-layer integrity check runs on every Start Game before launch:

| Layer | Method | On Failure |
|---|---|---|
| A — PE Header | `FileValidator.IsValidGameExe()` | Blocked + `GameExeCorrupted` popup |
| B — Assembly Checksum | MD5 → `Versions.xml` comparison | Blocked + `GameAssemblyTampered` popup |
| C — Digital Signature | `HasDigitalSignature()` | Warning + user choice (`GameIntegrityWarning`) |

**New files**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**New methods added to `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — MD5 hash of Assembly-CSharp.dll (+ firstpass if exists)
- `HasDigitalSignature(path)` — Authenticode signature check

---

### Diagnostic Logs Added

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 items, Release + Debug)

| # | Phase | Type | Content |
|---|---|---|---|
| 1 | TLS setting | Notice | Protocol before/after |
| 2 | Download start | Notice | Server list |
| 3 | URL attempt | Notice | Each URL being tried |
| 4 | Download success | Notice | URL, response length, protocol used |
| 5 | WebException | Error | URL, HTTP status, protocol, detail |
| 6 | Other exception | Error | URL, exception type, detail |
| 7 | Download complete | Notice | Success count / total servers |
| 8 | Parse success | Notice | Files and versions count before/after |
| 9 | Parse failure | Error | Exception type and detail |
| 10 | Save success | Notice | Save path, total versions/files count |
| 11 | Save failure | Error | Path, exception type, detail |
| 12 | No responses | Error | Servers tried, protocol |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 items, `#if DEBUG` only)

| # | Situation | Type | Content |
|---|---|---|---|
| 1 | Scan start | Notice | Mods folder path, total files found |
| 2 | Already loaded | Notice | Filename |
| 3 | Not .mod file | Notice | Filename |
| 4 | Pattern match success | Notice | Queued filename |
| 5 | Pattern match failure | Warning | Filename + reason + expected format |
| 6 | Scan complete | Notice | Queued count / total files |
| 7 | Exception | Error | Exception detail |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 items, Release + Debug)

| # | Situation | Type | Content |
|---|---|---|---|
| 1 | Popup condition | Notice | Current filter, selected game IDs, needGameSelect |
| 2 | Candidate games | Notice | Popup candidate ID list |
| 3 | Path not set | Notice | Game skipped — path not configured |
| 4 | Not in Configuration | Notice | Game skipped — not in Configuration.Games |
| 5 | Install confirmed | Notice | Game + executable path |
| 6 | Exe not found | Warning | Game skipped — executable missing |
| 7 | No installed games | Error | 0 candidates → GamePathNotSet |
| 8 | Auto-selected | Notice | Single candidate auto-selected |
| 9 | User cancelled | Notice | SelectGameDialog cancelled |
| 10 | Game selected + mods | Notice | Selected game, collected mod count/list |

---

### Developer / User Log Separation (`#if DEBUG`)

| File | Log | Reason |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Repeats every 1 second — 81% of total log volume |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Developer-only internal detail |

Release log retains: Download success/failure, parse/save results, pattern match failures, exceptions, integrity check results.

---

### Version Table Update — Architecture

#### Design Intent

```
Game receives Steam update
  → Assembly-CSharp.dll changes
  → ModAPI checks Versions.xml for known checksum
  → If not found → downloads latest Versions.xml from server
  → New version auto-registered without ModAPI reinstall
```

#### Connection Structure

```
Settings tab → KeepVersionsData checkbox
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → UpdateVersions() called
      → Downloads Versions.xml from VersionUpdateDomains[]
      → Overwrites local configs\games\{GameId}\Versions.xml
```

#### GitHub Raw URL Integration

Instead of relying solely on `modapi.survivetheforest.net`, GitHub Raw URL is now used as the primary source for direct management:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — directly managed, priority 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Legacy server — fallback, priority 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Item | Detail |
|---|---|
| Primary | GitHub Raw URL — push to update immediately |
| Fallback | Legacy server — used when GitHub unavailable |
| Path | `ModAPI/configs/games/{GameId}/Versions.xml` in repository |
| Modified file | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Versions.xml Updates

| Game | File | Change |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Checksum corrected (was incorrect SHA-256 uppercase) — `2.9.5b114117` with correct MD5 |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID: 20229486) added — 128-char MD5 checksum |

---

### New Language Keys (13 languages)

| Key | English Value |
|---|---|
| `Lang.Windows.SelectGame.Title` | Select Game |
| `Lang.Windows.SelectGame.Message` | Select the game to launch: |
| `Lang.Windows.GameExeCorrupted.Title` | Executable Corrupted |
| `Lang.Windows.GameExeCorrupted.Text` | The game executable failed validation... |
| `Lang.Windows.GameAssemblyTampered.Title` | Game Files Tampered |
| `Lang.Windows.GameAssemblyTampered.Text` | The game assembly checksum does not match... |
| `Lang.Windows.GameNoSignature.Title` | Integrity Warning |
| `Lang.Windows.GameNoSignature.Text` | The game executable has no digital signature... |
| `Lang.Windows.GameNoSignature.Continue` | Continue Anyway |
| `Lang.Windows.GameNoSignature.Cancel` | Cancel |
| `Lang.Savegames.*` (133 keys) | English values added to 12 languages (DE already translated) |

---

### Files Modified

| File | Path | Change |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` fixed at startup |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, integrity check, MixedGameMods removed, radio sync, 10 logs |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | New |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | New |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Filename diagnostic log, #if DEBUG separation |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, UpdateVersions 12 logs, GitHub URL, #if DEBUG separation |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 new keys + 133 Savegames keys (515 total, all languages matched) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Checksum corrected |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12` added |
| `LangTool\` (13 files) | Solution root | New |
| `ModAPI.sln` | Solution root | LangTool registered |

---

### Additional Fixes & Logging System Overhaul (2026-06-21)

#### StartGame Validation — Full Redesign

Validation order corrected to a strict 3-step sequence, and the game-selection popup now reflects mods that are activated regardless of whether the game path is configured.

| Step | Check | Failure Popup |
|---|---|---|
| 1 | Steam installed | SteamNotFound |
| 2 | Selected game's path configured + executable exists | GamePathNotSet |
| 3 | At least one mod activated for the selected game | NoModSelected |

- **All filter / multi-game mods selected** → popup always lists every game with an activated mod, **including ones with no configured path** — selecting an unconfigured game now correctly shows `GamePathNotSet` instead of silently excluding it or showing the wrong error
- **Single-game filter** → path and mod checks run directly against that game, in the same 1→2→3 order

#### Critical Bug Fixes

| # | File | Issue | Fix |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` merged responses from **all** successful servers (GitHub + legacy), doubling checksums (64 → 128 chars) when both succeeded — caused false `GameAssemblyTampered` blocks | Only the first successful server's response is parsed; remaining servers are skipped once one succeeds |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` used `App.Game` (currently active filter) instead of the mod's own game — deleting a Green Hell mod while The Forest was active searched the wrong `Managed` folder and silently skipped deletion | Now resolves the deployed DLL path from `mod.Game` (the mod's actual game instance), with a `Configuration` path fallback if `GamePath` is empty |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Re-downloading a previously deleted mod restored its activation badge as checked — deleting a mod never cleared its persisted `Selected`/`Version` keys or the in-memory ViewModel cache | Added `RemoveKey()` / `RemoveKeysWithPrefix()` to `Configuration.cs`; `DeleteMod_Click` now force-resets `ModViewModel.Selected = false` and removes all `Mods.{GameId}.{ModId}.*` keys on delete |
| 4 | `ModsViewModel.cs` | Deleting a mod while a specific game filter (not "All") was selected left the mod visible in the list until switching to "All" and back | `FilteredMods` change notification was missing after `_Mods.RemoveAt()` in the file-deletion polling loop; now fires whenever a mod is actually removed |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | An unhandled exception while building or showing the no-signature warning popup could silently crash ModAPI with no error logged | Popup construction/display and message formatting wrapped in try-catch; on failure, the warning is logged and the user is safely allowed to continue (missing signature is advisory, not a hard block) |

#### Digital Signature Warning — Message Clarified

`GameNoSignature` text now names the specific game and clarifies that a missing signature is expected for indie titles and does not affect gameplay, instead of implying possible tampering. Updated across all 13 language files with a `{0}` placeholder for the game's display name (e.g. "The Forest", "Green Hell").

#### Logging System — Two-File Separation

`#if DEBUG`-gated diagnostic logs were converted to a `detailedOnly` flag and split across `ModAPI.log` (user-facing) and `ModAPI.detailed.log` (always-on full detail) — see the **Log** section above for the full breakdown.

#### Files Modified (Additional)

| File | Path | Change |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | StartGame validation redesign, DeleteMod_Click game-instance fix, GameIntegrityWarning try-catch, display-name mapping |
| `Game.cs` | `ModAPI_Shared\Data\` | UpdateVersions single-response fix |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | `FilteredMods` change notification on delete, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 call sites) |
| `Mod.cs` | `ModAPI\Data\` | Header XML dump moved to `detailedOnly`, checksum mismatch summarization |
| `Debug.cs` | `ModAPI_Shared\` | `detailedOnly` parameter, dual-file writer, 4-tier logging guide comment |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | `{0}` game-name placeholder, try-catch safety |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` rewritten with game-name placeholder |

---


</details>

<details>
<summary><b>What Changed in v2.0.9619</b></summary>

### Bug Fixes

- **Mod apply hang with empty backup folder**: `gamefiles\original\` empty → automatic backup creation from game install path before assembly reading
- **File lock (IOException) on game DLLs**: Assembly resolver conditionally excludes game folder when backup exists — prevents Cecil from holding file locks during `DirectoryCopy`
- **Corrupted mod infinite retry loop**: Failed `.mod` files (corrupted header) caused 1-second re-scan loop — now registered in `LoadedFiles` to prevent re-scan
- **LF line-ending mod files rejected**: Header parser `EndsWith("</Mod>\r")` failed for Unix-style `.mod` files — now uses `TrimEnd` to handle both CRLF and LF
- **Small DLL validation failure**: `Assembly-UnityScript-firstpass.dll` (21 KB) rejected by `FileValidator` — minimum assembly size lowered from 64 KB to 8 KB
- **Unnecessary WARNING logs**: Unconfigured game paths and first-run config keys generated noise — `silent` parameter added to `GetPath`/`GetString`/`GetInt`

### Improvements

- **Zero-byte download detection**: Popup alert + temp file cleanup when server returns empty `.mod` file (`Lang.Windows.DownloadEmpty`)
- **Slider save debounce**: `ModListWidth` / `ProjectListWidth` save to `ui.cfg` only once (500 ms after drag ends) instead of every pixel change
- **Conditional game folder creation**: `mods/` and `projects/` folders created only for games with configured paths — not all 5 unconditionally
- **Header parsing diagnostic log**: Shows line count and content preview on `.mod` file parse failure for troubleshooting

### New Language Keys (13 languages)

| Key | English Value |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Files Modified

| File | Path | Change |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Backup auto-creation, conditional resolver, game folder fallback |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Game folder fallback for IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `silent` parameter on GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | 0-byte download guard, slider debounce, silent config reads, conditional folder creation |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Corrupted mod retry prevention |
| `Mod.cs` | `ModAPI\Data\` | LF/CRLF header parsing, diagnostic log |
| 13× `Language.XX.xaml` | `resources\langs\` | `DownloadEmpty` popup keys |

---

</details>

<details>
<summary><b>What Changed in v2.0.9618</b></summary>


### MODAPI_VersionTool Added

A standalone WPF tool for updating the version number with a single click was added (`VersionTool\MODAPI_VersionTool.csproj`) — see the **Version Tool** section above for full details.

- `VersionLabel.Text` now references `App.Version` instead of the hardcoded `Version.Descriptor`, so updates are reflected in the StatusBar immediately after a rebuild.

---

</details>

<details>
<summary><b>What Changed in v2.0.9617</b></summary>


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

</details>

<details>
<summary><b>What Changed in v2.0.9616</b></summary>

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

</details>

<details>
<summary><b>What Changed in v2.0.9615</b></summary>

### Settings Tab Game Path Expand Fixed

- **Card expand height**: The window bottom now grows by exactly the height of the input field when expanding a game path card
- **`UpdateWindowHeight()` improved**: Calls `UpdateLayout()` before `SizeToContent.Height` measurement; temporarily sets `TextureLayer1` to `Collapsed` when background texture is active to prevent 4K image original size from affecting height calculation
- **Inner Grid Row fix**: Changed the last Row of the game paths panel inner Grid from `Height="*"` to `Height="Auto"` — removes unnecessary bottom whitespace

---

</details>

<details>
<summary><b>What Changed in v2.0.9614</b></summary>

### Maximize Button Behavior Fixed

- **Maximize**: Uses `SystemParameters.WorkArea` for manual maximization instead of `WindowState.Maximized` — fits exactly to the current screen resolution without overlapping the taskbar
- **Restore**: Saves `Left`, `Top`, `Width`, `Height`, and `MaxWidth` before maximizing and restores them when the restore button is clicked
- **`MaxWidth` handling**: Set to `∞` on maximize, restored to saved value on normalize

---

</details>

<details>
<summary><b>What Changed in v2.0.9613</b></summary>

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

</details>

<details>
<summary><b>What Changed in v2.0.9612</b></summary>

### Theme Module Separation

- **New `Themes/` folder**: Moved `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml`, and `FluentStylesClassic.xaml` to `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — Classic theme uses `Dictionary.xaml` only; Light/Dark/other Fluent themes load corresponding XAML
- **`ModAPI.csproj`**: Updated theme XAML paths to `Themes\` subdirectory; registered `FluentStylesClassic.xaml`

---

</details>

<details>
<summary><b>What Changed in v2.0.9611</b></summary>

### Bug Fix

- **Mod list width not applied after theme switch**: Fixed an issue where the Mod list width was not applied after switching between Light/Dark themes and restarting — added `ApplyModListWidth(width)` call inside `InitModListWidth()`

---

</details>

<details>
<summary><b>What Changed in v2.0.9610</b></summary>

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

## Planned for Future Releases

| # | Feature | Description |
|---|---|---|
| 1 | ModAPI Auto-Update | Automatically download and apply new ModAPI releases |
| 2 | ModAPI VersionsData Table Update | Automatically update the game VersionsData table when new game patches are released |

---

</details>

<details>
<summary><b>What Changed in v2.0.9600</b></summary>

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

</details>

---

## Version History

<details>
<summary><b>Phase 6-3 — Theme System Expansion, Settings Improvements, Stability & Tools</b></summary>

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool & core fixes**
- MODAPI_LangTool added (standalone WPF language management tool)
- SSL/TLS fix (TLS 1.2)
- French locale fix (`CultureInfo.InvariantCulture`)
- Green Hell `GamePathNotSet` fix
- SelectGameDialog (All filter + mixed-game mod launch)
- MixedGameMods blocking removed
- 3-layer game integrity check (PE header / assembly checksum / digital signature)
- Developer vs user log separation
- UpdateVersions 12 logs + FindMods 7 logs + StartGame 10 logs
- GitHub Raw URL as primary `VersionUpdateDomains`
- GH `Versions.xml` checksum corrected
- TheForest `Versions.xml` `1.12` added
- 515 keys across all 13 language files

**Additional fixes (2026-06-21)**
- StartGame validation order fixed (Steam → game path → mods)
- Game-selection popup now lists unconfigured-path games correctly
- UpdateVersions single-response fix (no more doubled checksums)
- `DeleteMod` now resolves the mod's own game instance instead of the active filter
- Deleted mods no longer leave a stale "Selected" badge on re-download
- Mod list now refreshes immediately on delete under any game filter
- `GameIntegrityWarning` popup hardened against unhandled-exception crashes
- Digital-signature warning message now names the game and clarifies it's expected for indie titles
- Two-file logging system (`ModAPI.log` / `ModAPI.detailed.log`) replaces `#if DEBUG`-gated logs so Release builds can still capture full diagnostic detail without cluttering the user-facing log

### v2.0.9619 — 2026-05-25

- Backup auto-creation from game install path
- File lock fix (conditional resolver)
- Corrupted mod infinite retry prevention
- LF line-ending mod compatibility
- 0-byte download detection with popup
- Slider save debounce (500 ms)
- Conditional game folder creation
- `FileValidator` min assembly size 64 KB → 8 KB
- `silent` parameter on `GetPath`/`GetString`/`GetInt`
- Header parsing diagnostic log
- `DownloadEmpty` language keys (13 languages)

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

</details>

<details>
<summary><b>Phase 6-2 — Settings, Safety, Crash Fixes & Debug/Release Split</b></summary>

### v2.0.9610 — 2026-04-13

- Multi-game XML corrected (GH, Subnautica, EscapeThePacific)
- `Versions.xml` added
- Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync)
- Game path null safety (6 sites)
- Startup popups replaced by Settings tab
- Mods tab 5-step Start Game validation (Steam always first)
- Dev tab 3-step ModLib validation
- `GameModsMismatch` popup added
- Lightweight constructor `ModLibrary` null fix
- `SwitchDevGame` `GamePath` fix
- `FileValidator` PE header verification (Release)
- `#if DEBUG` build split (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- Persistent `ui.cfg`
- 5-key font system
- Multiple crash fixes
- Language keys updated

</details>

<details>
<summary><b>Phase 6-1 — Multi-Game & Mods Redesign</b></summary>

### v2.0.9600 — 2026-04-09
> 5 game filters, Mods tab 3-column layout, auto width, lightweight `Game` constructor, `ModsViewModel` game filtering, 4 XML files registered, build warnings cleaned, Welcome tab, language flags standardized

</details>

<details>
<summary><b>Phase 5-6B — C# 7.3 & Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Black screen fixed, polyfill finalized, ValueTuple removed, C# 7.3 verified

</details>

<details>
<summary><b>Phase 5-5 — Assembly Resolution</b></summary>

### v2.0.9561 — 2026-03-06
> C# 7.3 support, PE header patching, polyfill pipeline, assembly resolution restored

</details>

<details>
<summary><b>Phase 5-1 — Downloads Tab & 13 Languages</b></summary>

### v2.0.9552 — 2026-02-25
> Downloads tab, icon modernization, theme unification, 13-language support

</details>

<details>
<summary><b>Earlier Phases</b></summary>

### Phase 3 — UI Redesign & Theme System
v2.0.9500
> Theme system (Classic/Light/Dark), Fluent Design UI, SubWindow system

### Phase 4 — Code Cleanup
v2.0.9400
> Code cleanup, login removal, legacy modernization

### Phase 2 — Build Environment & Fluent Design
v2.0.9300
> Build environment, UnityEngine stub DLL, ModernWpf integration

### Phase 1 — .NET 4.8 Migration
v2.0.9200
> .NET Framework 4.8 migration

### v1.x
Original FluffyFish release

</details>

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
