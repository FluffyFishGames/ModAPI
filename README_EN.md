# ModAPI(v1) v2.0.9552 - 20260225

**The Forest Mod Management Tool — Upgraded Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germany)
> Upgrade: zzangae (Republic of Korea)

---

## Overview

ModAPI is a desktop application for managing mods for The Forest. This upgraded edition includes .NET Framework 4.8 migration, Windows 11 Fluent Design UI, a 3-theme system, enhanced multilingual support, and a full Downloads tab implementation.

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

#### Fluent UI Redesign
- Complete **MainWindow.xaml** restructuring
  - Fluent Design-based layout, colors, typography
  - Redesigned tab controls, status bar, caption buttons
- Runtime fixes: SplashScreen freezing, tab switching, icon states, window dragging

#### 3-Theme System

| Theme | Style File | Description |
|-------|-----------|-------------|
| Classic | Dictionary.xaml only | Original ModAPI design (texture background) |
| Light | FluentStylesLight.xaml | Bright tone + blue accent |
| Dark | FluentStyles.xaml | Dark tone + blue accent (default) |

- Added **Theme Selector ComboBox** in Settings tab
- Theme change triggers **confirmation popup** → **auto restart**
- Theme setting saved/loaded via `theme.cfg` file

#### Window Drag / SubWindows / Hyperlinks
- Root Grid `MouseLeftButtonDown` event for direct drag handling
- ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm popups
- Theme-specific link colors: Dark/Classic (`#FFD700`), Light (`#0078D4`)

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

#### Downloads Tab
- Loads mod list from 3 sources (`mods.json`, `versions.xml`, HTML parsing)
- Search functionality (filter by mod name/description/author)
- **Game filter** (All / The Forest / Dedicated Server / VR)
- **Category filter** (All / Bugfixes / Balancing / Cheats, etc. — 12 categories)
- Version selection split-panel UI
- Direct `.mod` file download → game folder installation
- Column sorting (click name/category/author) and resizing
- Mod deletion (DLL + staging file cleanup)

#### Icon Modernization (All Themes)
- All button PNG icons → **Segoe MDL2 Assets** font icons
- Applied across MainWindow.xaml + 14 SubWindow files
- Font icons inherit Foreground color, ensuring visibility across all themes

| Original PNG | Font Icon | Usage |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Add / Start Game |
| Icon_Delete | &#xE74D; | Delete |
| Icon_Refresh | &#xE72C; | Refresh |
| Icon_Download | &#xE896; | Download |
| Icon_Continue/Accept | &#xE8FB; | Confirm/Continue |
| Icon_Decline | &#xE711; | Cancel/Close |
| Icon_Information | &#xE946; | Information |
| Icon_Warning | &#xE7BA; | Warning |
| Icon_Error | &#xEA39; | Error |
| Icon_Browse | &#xED25; | Browse |
| Icon_CreateMod | &#xE713; | Create Mod |

#### Unified Controls Across All Themes

| Control | Classic | Dark | Light |
|---------|---------|------|-------|
| CheckBox | Toggle (Gold) | Toggle (AccentBrush) | Toggle (AccentBrush) |
| RadioButton | Circle (Gold) | Circle (AccentBrush) | Circle (AccentBrush) |
| ComboBox | Scale9 original | Fluent custom | Fluent custom |

#### Theme Visibility Fixes
- Light: AccentButton text forced White, tab icon Opacity adjustment
- Dark/Light: ComboBoxItem `TextElement.Foreground` approach for selected text visibility
- Classic: Fluent fallback resources added to Dictionary.xaml

---

## File Structure

```
ModAPI/
├── App.xaml / App.xaml.cs          # Theme load/save/apply
├── Dictionary.xaml                  # Original styles + toggle/radio/fallback resources
├── FluentStyles.xaml                # Dark theme + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Light theme + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # Main UI + Downloads tab + theme selector
│   └── SubWindows/                  # 16 SubWindows (all with font icons)
├── resources/
│   ├── langs/                       # 13 language files
│   └── textures/Icons/flags/        # Flag icons (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # Stub DLL
```

---

## Build Requirements

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## License

GNU General Public License v3.0 — follows the original license.
