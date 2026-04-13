[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9610 - 20260413

**Ferramenta de Gerenciamento de Mods do The Forest — Edição Atualizada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemanha)
> Atualização: zzangae (República da Coreia)

---

## Visão Geral

ModAPI é um aplicativo de desktop para gerenciar mods de **5 jogos oficialmente suportados**. Esta edição atualizada inclui suporte a múltiplos jogos, uma aba de Configurações completamente redesenhada, configuração do caminho do Steam, configurações de UI persistentes, sistema dinâmico de tamanho de fonte, validação de início de jogo, separação de builds Debug/Release e numerosas correções de falhas verificadas em testes no jogo.

---

## Jogos Suportados

### The Forest

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

---

### Subnautica

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

---

### RAFT

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

---

### Escape The Pacific

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

---

### Green Hell

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

---

## Arquitetura

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

### Theme System

| Theme | File | Description |
|---|---|---|
| Classic | `Dictionary.xaml` | Original ModAPI design (texture background) |
| Light | `FluentStylesLight.xaml` | Bright tone + blue accent |
| Dark | `FluentStyles.xaml` | Dark tone + blue accent (default) |

Theme changes require an app restart. `SaveAllSettings()` is called automatically before restart.

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

### File Structure

```
ModAPI/
├── App.xaml / App.xaml.cs              # Theme load/apply
├── Dictionary.xaml                      # Classic theme + fallback resources
├── FluentStyles.xaml                    # Dark theme
├── FluentStylesLight.xaml               # Light theme
├── ui.cfg                               # Persistent UI settings
├── theme.cfg                            # Current theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Main UI — 5 tabs, Settings, Steam path
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Game path popup (dynamic GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # First-run setup + default initialization
│       └── (14 other SubWindows)
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
├── resources/langs/                     # 13 language files
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Full rewrite v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Full rewrite v2.0.9610
    │   ├── GH.xml                       # Full rewrite v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — not supported
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica
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

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generates dummy game/steam structure
├── dummy_games\{GameId}\               # Dummy game install paths
├── dummy_steam\Steam.exe               # Dummy Steam executable
└── gamefiles\original\{GameId}\        # Dummy backup paths for ModLib
```

---

## Instalação e Configuração

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

## Visão Geral das Abas

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

### Settings Tab
Centralized configuration — 4 rows:

| Row | Content |
|---|---|
| 0 | Language / Font Size / Theme / Max Width / Mod List Width / Project List Width |
| 1 | Keep VersionsData / Auto Update / Steam Connection / Always On Top |
| 2 | Steam Installation Path (TextBox + Browse + Save) |
| 3 | Game Installation Paths — expandable card per game (TextBox + Browse + Save) |

---

## Alterações na v2.0.9610

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

## Planejado para Versões Futuras

| # | Feature | Description |
|---|---|---|
| 1 | Atualização automática do ModAPI | Baixar e aplicar automaticamente novas versões do ModAPI |
| 2 | Atualização da tabela VersionsData do ModAPI | Atualizar automaticamente a tabela VersionsData quando novos patches do jogo forem lançados |

---

## Alterações na v2.0.9600

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

## Principais Alterações por Fase

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

---

## Histórico de Versões

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

## Requisitos de Compilação

| Requirement | Version | Notes |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI projects |
| .NET Framework SDK | 3.5 | BaseModLib only |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licença

GNU General Public License v3.0 — segue a licença original.
