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

# ModAPI(v1) v2.0.9618 - 20260425

**The Forest Mod-Verwaltungstool — Upgrade-Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Deutschland)
> Upgrade: zzangae (Republik Korea)

---

## Übersicht

ModAPI ist eine Desktop-Anwendung zur Verwaltung von Mods für **5 offiziell unterstützte Spiele**. Diese Upgrade-Edition umfasst Multi-Spiel-Unterstützung, ein vollständig neu gestaltetes Settings-Tab, Steam-Pfadkonfiguration, persistente UI-Einstellungen, ein dynamisches Schriftgrößensystem, Spielstart-Validierung, Debug/Release-Build-Trennung und zahlreiche durch In-Game-Tests verifizierte Absturzbehebungen.

---

## Unterstützte Spiele

| Spiel | Engine | Version | Steam ID | Ausführbare Datei |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Element | Wert |
|---|---|
| Engine | Unity 5 (Upgrade von Unity 4) |
| Neueste Version | v1.12 (VR) |
| Letztes Update | 11. September 2019 — VR-Support-Patch; keine weiteren größeren Inhaltsupdates |
| Ausführbare Datei | `TheForest.exe` |
| Datenordner | `TheForest_Data/Managed/` |
| Mods-Ordner | `mods/TheForest/` |
| Projektordner | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — vollständig unterstützt |

The Forest wurde von Unity 4 auf Unity 5 aktualisiert, was Grafik und Physik erheblich verbesserte. Der VR-Patch im September 2019 war das letzte größere Update. Das Spiel befindet sich in einem stabilen, finalisierten Zustand — ideal für Modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Element | Wert |
|---|---|
| Engine | Unity (integrierte Codebasis, vereinheitlicht mit Below Zero 2022) |
| Neueste Version | 2025 Patch (v18810395) |
| Letztes Update | 12. August 2025 — Fehlerbehebungen und Leistungsverbesserungen neben der Mobilveröffentlichung |
| Ausführbare Datei | `Subnautica.exe` |
| Datenordner | `Subnautica_Data/Managed/` |
| Mods-Ordner | `mods/Subnautica/` |
| Projektordner | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — unterstützt |

Ursprünglich auf Unity 5 aufgebaut, erhielt Subnautica Ende 2022 das 'Living Large'-Update (v2.0), das die Engine-Codebasis mit Below Zero für verbesserte Optimierung und Stabilität zusammenführte. Hinweis: Das kommende *Subnautica 2* verwendet Unreal Engine 5.

> **XML in v2.0.9610 neu geschrieben**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` zu `copyAssembly` hinzugefügt.
</details>

<details>
<summary><b>RAFT</b></summary>

| Element | Wert |
|---|---|
| Engine | Unity |
| Neueste Version | v1.1.02 (Beta) / v1.09 (Stabil) |
| Letztes Update | März 2026 — Voice-Chat und Multiplayer-Fehlerbehebungen über Beta-Branch |
| Ausführbare Datei | `Raft.exe` |
| Datenordner | `Raft_Data/Managed/` |
| Mods-Ordner | `mods/Raft/` |
| Projektordner | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — unterstützt |
| Versions.xml | `1.1.01` (mit Prüfsumme) |

Nach dem offiziellen Story-Abschluss in v1.0: *The Final Chapter* wurden weiterhin Patches für Netzwerk-Code-Verbesserungen und Stabilität veröffentlicht.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Element | Wert |
|---|---|
| Engine | Unity 6 (migriert von Unity 2021/2022 Ende 2025) |
| Neueste Version | v0.67.0.0 |
| Letztes Update | 26. Juni 2025 — Überarbeitung der Inselverteilung und Engine-Update; laufende Hotfixes bis 2026 |
| Ausführbare Datei | `EscapeThePacific.exe` |
| Datenordner | `EscapeThePacific_Data/Managed/` |
| Mods-Ordner | `mods/EscapeThePacific/` |
| Projektordner | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — unterstützt |

Ende 2025 wurde ein umfassender Systemumbau mit Unity 6-Migration abgeschlossen, der dynamischere Umgebungen ermöglicht. Das Spiel befindet sich weiterhin in aktiver Early-Access-Entwicklung.

> **XML in v2.0.9610 neu geschrieben**: `extends="GenericUnityGame"` entfernt; `includeAssembly` auf nur `Assembly-CSharp.dll` gesetzt — verhindert `Assembly-CSharp-firstpass.dll` Vererbungsfehler.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Element | Wert |
|---|---|
| Engine | Unity 2019 |
| Neueste Version | v2.9.5 |
| Letztes Update | 4. Februar 2026 — Steam Deck-Optimierung und Textlesbarkeitsverbesserungen |
| Ausführbare Datei | `GH.exe` |
| Datenordner | `GH_Data/Managed/` |
| Mods-Ordner | `mods/GH/` |
| Projektordner | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — unterstützt |
| Versions.xml | `2.9.5` (mit Prüfsumme) |

Während der Entwicklung wurde die Engine schrittweise von Unity 2017 → 2018 → 2019 aktualisiert. Der Hotfix im Februar 2026 konzentrierte sich auf Steam Deck-Kompatibilität und UI-Textlesbarkeit.

> **XML in v2.0.9610 neu geschrieben**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` hinzugefügt; nicht existierende `DOTweenPro.dll` entfernt.
</details>

---

## Architektur

### Laufzeit-Aufteilung

| Komponente | Ziel | Laufzeit | Grund |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop-Anwendung, vollständige moderne API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Gemeinsame Bibliothek |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Dauerhaft festgelegt** — PE-Header muss `v2.0.50727` enthalten |
| Mod-DLLs (Benutzer) | .NET Framework 4.8 | Game Mono 2.0 (gepatcht) | Mit 4.8 erstellt, PE-Header wird beim Anwenden gepatcht |

### Debug / Release Build-Aufteilung

Alle Dateivalidierungen und Assembly-Verarbeitungen verzweigen über `#if DEBUG` / `#else` basierend auf der Build-Konfiguration.

| Stelle | Debug-Build | Release-Build |
|---|---|---|
| `CheckSteam()` | Nur `File.Exists()` — Dummy-Dateien bestehen | `FileValidator.IsValidSteamExe()` — PE-Header + min. 1 MB |
| `CheckGamePath()` | Nur `File.Exists()` — Dummy-Dateien bestehen | `FileValidator.IsValidAssemblyDll()` — PE-Header + CLR-Metadaten + min. 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — Cecil-Parsing wird übersprungen | Vollständiges Mono.Cecil-Parsing + IL-Modifikation + `module.Write()` |
| `ModLib.Create()` — Datei nicht gefunden | Warnung protokollieren, überspringen und fortfahren | Fehler protokollieren, mit Popup abbrechen |

**Debug-Tests** verwenden `create_dummy_Debug_games.ps1`, um 0-Byte-Platzhalterdateien unter `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` und `bin\Debug\gamefiles\original\` zu generieren. Diese bestehen `File.Exists()`-Prüfungen und ermöglichen vollständige UI-Workflow-Tests ohne echte Spielinstallation.

**Release-Builds** wenden `FileValidator` (PE-Header + .NET CLR-Metadaten-Verifizierung) an, um 0-Byte-Dateien, Textdateien und beliebige Binärdateien abzulehnen. Nur gültige Windows-Executables und .NET-Assemblies bestehen.

### FileValidator — PE-Header-Verifizierung

`ModAPI_Shared\Utils\FileValidator.cs` — wird nur in Release-Builds angewendet.

| Methode | Prüfungen | Min. Größe |
|---|---|---|
| `IsValidSteamExe(path)` | MZ-Signatur + PE\0\0-Signatur | 1 MB |
| `IsValidGameExe(path)` | MZ-Signatur + PE\0\0-Signatur | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR-Metadaten-Header (Datenverzeichnis #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Assembly-Remapping-Pipeline

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

### Assembly-Resolver-Fallback

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### C# 7.3 Feature-Unterstützung

| Feature | Status | Hinweise |
|---|---|---|
| Pattern Matching (`is`, `switch`) | ✅ | Im Spiel verifiziert |
| String-Interpolation (`$""`) | ✅ | Im Spiel verifiziert |
| Inline-`out`-Variable | ✅ | Im Spiel verifiziert |
| `async` / `await` | ✅ | Über AsyncBridge + System.Threading Polyfills |
| Tupel (`ValueTuple`) | ❌ Hartes Limit | Mono 2.0 `mscorlib` ABI — keine Umgehung möglich |

### Theme System

Ab v2.0.9613 wurde die Theme-Auswahl aus dem Settings-Tab in einen eigenen **Themes-Tab** verschoben. Zum Hinzufügen eines neuen Themes genügt eine Zeile im `App.xaml.cs`-Dictionary.

| Index | ID | Datei | Palette |
|---|---|---|---|
| 0 | `classic` | Nur `Dictionary.xaml` | Originales ModAPI-Texturhintergrund |
| 1 | `light` | `FluentStylesLight.xaml` | Heller Ton + blauer Akzent |
| 2 | `dark` | `FluentStyles.xaml` | Dunkler Ton + blauer Akzent (Standard) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rot + Schwarz |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dunkler Weltraum |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Heller Sonnenuntergang |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dunkler Ozean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Helles Nordisch |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Helles Zitrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Helles Blühen |

Theme-Änderungen lösen einen automatischen App-Neustart aus. (gespeichert in `theme.cfg`)

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

### Hintergrundtextur

Wählen Sie im **Background Texture**-Bereich des Themes-Tabs ein Bild aus, um es als App-weiten Hintergrund zu verwenden. Unterstützte Formate: `.png` / `.jpg` / `.jpeg`, max 50MB, 4K oder niedriger. Das Bild wird als JPEG Q75 komprimiert, mit einem 16-Byte Magic-Header versehen und als `resources\textures\ui_bg\bg.dat` (Hidden-Attribut) gespeichert. SHA-256-Hash zur Integritätsprüfung; bei Manipulation automatisches Zurücksetzen + Warnungs-Popup.

Bei aktiviertem Hintergrund wird die UI-Transparenz in zwei Schichten verarbeitet: Layer 1 (MergedDictionaries-Overlay) für `{DynamicResource}`-Panels, Layer 2 (WalkStyleBackgrounds) für `{StaticResource}`-basierte Panels mit Halbtransparenz.

### Schriftgrößensystem

| Ressourcen-Schlüssel | Basis | Beschreibung |
|---|---|---|
| `AppBaseFontSize` | 13 | Normaler Text |
| `AppBaseHeaderFontSize` | 16 | Überschriften, Panel-Titel |
| `AppBaseSmallFontSize` | 12 | Sekundäre Beschriftungen |
| `AppBaseTinyFontSize` | 10 | Hinweistext |
| `AppBaseLargeFontSize` | 20 | Großer Anzeigetext |

### Persistente UI-Konfiguration — `ui.cfg`

| Schlüssel | Standard | Beschreibung |
|-----|---------|-------------|
| `ModListWidth` | `150` | Mods-Tab Listenbreite (px) |
| `ProjectListWidth` | `150` | Entwicklungs-Tab Projektlistenbreite (px) |
| `AppFontSize` | `13` | Globale UI-Schriftgröße (px) |
| `AlwaysOnTop` | `false` | Fenster immer im Vordergrund |
| `TexturePath` | *(keine)* | Originaldateiname der Hintergrundtextur (nur Anzeige) |
| `TextureHash` | *(keine)* | SHA-256-Hash der Hintergrundtextur |
| `TextureActive` | `false` | Aktivierungsstatus der Hintergrundtextur |
| `GamePathReset_{GameId}` | *(keine)* | Spielpfad-Reset-Flag |
| `SteamPathReset` | *(keine)* | Steam-Pfad-Reset-Flag |

### Dateistruktur

```
ModAPI/
├── App.xaml / App.xaml.cs              # Theme-Registrierung, Theme-IDs, Theme-Anwendung
├── ui.cfg                               # Persistente UI-Einstellungen
├── theme.cfg                            # Aktuelles Theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Haupt-UI — 6 Tabs, Themes, Einstellungen, Steam-Pfad
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Spielpfad-Popup (dynamisches GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # Ersteinrichtung + Standardinitialisierung
│       └── (14 weitere SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Classic-Theme
│   ├── FluentStyles.xaml                # Dark-Theme
│   ├── FluentStylesLight.xaml           # Light-Theme
│   ├── FluentStylesDiablo.xaml          # Diablo-Theme
│   ├── FluentStylesNebula.xaml          # Nebula-Theme
│   ├── FluentStylesSunset.xaml          # Sunset-Theme
│   ├── FluentStylesOcean.xaml           # Ocean-Theme
│   ├── FluentStylesNordic.xaml          # Nordic-Theme
│   ├── FluentStylesCitrus.xaml          # Citrus-Theme
│   └── FluentStylesBloom.xaml           # Bloom-Theme
├── Data/
│   ├── Game.cs                          # Assembly-Patching, Null-Schutz, Resolver-Fallback
│   ├── ModLib.cs                        # BaseModLib-Generierung + Remapping (#if DEBUG Aufteilung)
│   ├── Models/
│   │   └── ModProject.cs                # Projekt erstellen/bauen/anwenden + Null-Schutz
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Gefilterte Mods, ausgewählter Mod, ausgewählter Spielfilter
│   │   ├── ModViewModel.cs              # GameId aus Ordnerpfad
│   │   ├── ModProjectsViewModel.cs      # Dispose() für DispatcherTimer
│   │   └── SettingsViewModel.cs         # Standard true für UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mono 2.0 Assembly-Versionszuordnung (20 Assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Namensbasierter Resolver mit Caching
│   └── MonoHelper.cs                    # Mono.Cecil IL-Hilfsprogramme
├── resources/
│   ├── langs/                           # 13 Sprachdateien
│   └── textures/ui_bg/
│       └── bg.dat                       # Komprimiertes und gesichertes Hintergrundbild (zur Laufzeit generiert)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Vollständige Neufassung v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Vollständige Neufassung v2.0.9610
    │   ├── GH.xml                       # Vollständige Neufassung v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — nicht unterstützt
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Leichtgewichtiger Konstruktor + ModLibrary-Initialisierungsfix
│   └── ModLib.cs                        # #if DEBUG Aufteilung für Cecil-Parsing
└── Utils/
    └── FileValidator.cs                 # PE-Header + CLR-Metadaten-Validierung (nur Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Eigenständiges WPF-Versionsaktualisierungstool

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generiert Dummy-Spiel/Steam-Struktur
├── dummy_games\{GameId}\               # Dummy-Spielinstallationspfade
├── dummy_steam\Steam.exe               # Dummy-Steam-Ausführbare Datei
└── gamefiles\original\{GameId}\        # Dummy-Sicherungspfade für ModLib
```

---

## Installation & Einrichtung

### Schritt 1 — Voraussetzungen

| Element | Erforderlich |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (unter Windows 11 vorinstalliert; [Download](https://dotnet.microsoft.com/download/dotnet-framework/net48) für Windows 10) |
| Steam | Erforderlich — muss im Settings-Tab konfiguriert werden |
| Mindestens ein unterstütztes Spiel | Erforderlich — muss im Settings-Tab konfiguriert werden |

### Schritt 2 — ModAPI installieren

1. Neueste Version von GitHub herunterladen
2. In einen beliebigen Ordner entpacken (z.B. `C:\ModAPI\`)
3. `ModAPI.exe` ausführen
4. Beim ersten Start erscheint der **Welcome**-Bildschirm — Einstellungen konfigurieren und **Continue** klicken

### Schritt 3 — Steam-Pfad konfigurieren (Settings-Tab)

1. Zum **Settings**-Tab wechseln
2. **Steam Installation Path** suchen
3. **Browse** klicken → `Steam.exe` auswählen
4. **Save** klicken

### Schritt 4 — Spielpfade konfigurieren (Settings-Tab)

1. Auf den Header einer Spielkarte klicken, um sie aufzuklappen
2. **Browse** klicken → den Spielstammordner auswählen (wo sich die `.exe` befindet)
3. **Save** klicken

| Spiel | Ausführbare Datei | Beispielpfad |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Schritt 5 — Mods herunterladen (Downloads-Tab)

1. Zum **Downloads**-Tab wechseln
2. Ein Spiel aus dem Spielfilter auswählen
3. Nach einem Mod suchen und **Download** klicken

> **Offline**: `.mod`-Dateien manuell von `modapi.survivetheforest.net` herunterladen und im entsprechenden Ordner ablegen:

| Spiel | Ordner |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Schritt 6 — Mods anwenden & Spiel starten (Mods-Tab)

1. Zum **Mods**-Tab wechseln
2. Ein Spiel aus dem **Spielfilter** (Spalte 0) auswählen
3. Mods in der **Mod-Liste** (Spalte 1) aktivieren
4. **Start Game** klicken

Folgende Prüfungen werden automatisch vor dem Start ausgeführt:

| # | Prüfung | Fehler-Popup |
|---|---|---|
| 1 | Steam-Pfad konfiguriert und gültig | SteamNotFound |
| 2 | `mods/`-Ordner-Spiel stimmt mit Settings-Spielpfad überein | GameModsMismatch |
| 3 | Mindestens ein Mod ausgewählt | NoModSelected |
| 4 | Keine gemischten Spiel-Mods in der Auswahl | MixedGameMods |
| 5 | Spielpfad konfiguriert und Ausführbare Datei existiert | GamePathNotSet / GameNotInstalled |

---

## Tab-Übersicht

### Welcome-Tab
Ersteinrichtungsbildschirm (Tab-Index 0). Konfiguration von AutoUpdate, Steam-Verbindung und VersionsData-Tabelleneinstellungen. Bei nachfolgenden Starts bietet dieser Tab Community-Links und Versionshinweise.

### Mods-Tab
Primärer Mod-Verwaltungs-Workflow — 3-Spalten-Layout:

| Spalte | Inhalt |
|---|---|
| Spalte 0 | Spielfilter — Radiobuttons für 5 unterstützte Spiele |
| Spalte 1 | Mod-Liste — installierte Mods mit Versionsauswahl und Aktivierungscheckbox |
| Spalte 2 | Information — Details zum ausgewählten Mod, Beschreibung, Versionshistorie |

### Downloads-Tab
Mods von `modapi.survivetheforest.net` durchsuchen und herunterladen.

- **Spielfilter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Kategoriefilter**: 12 Kategorien (Bugfixes, Balancing, Cheats, …)
- **Suche**: nach Mod-Name, Beschreibung oder Autor
- **Offline-Modus**: zeigt Ordneranweisungen für alle 5 unterstützten Spiele an

### Development-Tab
Mod-Entwicklungs-Workflow — Spielfilter-Panel (Spalte 0) deckt alle 5 unterstützten Spiele ab.

- Mod-Projekte pro Spiel erstellen, bauen und anwenden
- Sprachressourcen-Verwaltung
- ModLib-Generierung mit 3-Stufen-Validierung (Steam → Projekt → Spielpfad)
- Sicherer Spielwechsel über leichtgewichtigen `Game`-Konstruktor (kein `Verify()`-Aufruf)

### Themes-Tab
Theme-Auswahl und Hintergrundtextur-Verwaltung.

- **Theme-Auswahl**: 10 Themes (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Hintergrundtextur**: Bild als App-weiten Hintergrund auswählen (JPEG-Kompression + Sicherheitsverarbeitung)
- Bei aktiver Hintergrundtextur wird die Theme-Auswahl gesperrt

### Settings-Tab
Zentralisierte Konfiguration — 4 Zeilen:

| Zeile | Inhalt |
|---|---|
| 0 | Sprache / Schriftgröße / Theme / Maximale Breite / Mod-Listenbreite / Projektlistenbreite |
| 1 | VersionsData beibehalten / Auto-Update / Steam-Verbindung / Immer im Vordergrund |
| 2 | Steam-Installationspfad (TextBox + Durchsuchen + Speichern + Zurücksetzen) |
| 3 | Spielinstallationspfade — aufklappbare Karte pro Spiel (TextBox + Durchsuchen + Speichern + Zurücksetzen) |

---

## Änderungen in v2.0.9618

### Version Update Tool (MODAPI_VersionTool)

Ein eigenständiges WPF-Tool zum Aktualisieren der Versionsnummer mit einem Klick.

**Speicherort**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Funktionen**
- Zeigt automatisch die aktuelle Version an (gelesen aus `App.xaml.cs`)
- Neue Version eingeben und **Apply Version** klicken — beide Dateien werden gleichzeitig aktualisiert
- Formatvalidierung: nur `X.X.XXXX`-Format akzeptiert

**Geänderte Dateien**

| Datei | Pfad | Änderung |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Verwendung**
1. `MODAPI_VersionTool.exe` ausführen
2. Neue Version eingeben (z.B. `2.0.9619`)
3. **Apply Version** klicken
4. ModAPI-Lösung in Visual Studio neu erstellen

### StatusBar-Versionsanzeige behoben

- `VersionLabel.Text` referenziert jetzt `App.Version` statt dem hartcodierten `Version.Descriptor`
- Nach Versionsänderung mit VersionTool und Neuerstellung wird die StatusBar sofort aktualisiert

---

## Änderungen in v2.0.9617

### Settings Tab — Pfad-Reset-Buttons hinzugefügt

Ein **Reset**-Button wurde zum Steam-Installationspfad und zu jeder Spielinstallationspfad-Zeile hinzugefügt.

**Steam-Pfad-Zeile**
```
[TextBox] [Browse] [Save] [Reset]
```

**Spielpfad-Zeile (pro Spiel)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Reset-Verhalten**
- Leert die Pfad-TextBox sofort
- Speichert ein Reset-Flag in `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox bleibt nach Neustart leer
- Umgeht die Einschränkung, dass Configuration XML keine leeren Strings speichert

**Browse Auto-Speicherung**
- Vorher: Nach Browse musste separat der Save-Button geklickt werden
- Nachher: Automatische Speicherung bei Dateiauswahl — wird auch nach Wechsel zum Mods-Tab übernommen

**Neuer Sprachschlüssel**

| Schlüssel | Wert |
|---|---|
| `Lang.Options.Labels.PathReset` | Zurücksetzen |

---

## Änderungen in v2.0.9616

### Versions.xml — 4 Spiele hinzugefügt / aktualisiert

| Spiel | Dateipfad | BuildID | Bemerkung |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Neu erstellt |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Prüfsumme aktualisiert |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Neu erstellt |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Prüfsumme aktualisiert |

### Prüfsummen-Zusammensetzungsregeln

Das Prüfsummenformat unterscheidet sich je nachdem, ob `Assembly-CSharp-firstpass.dll` für jedes Spiel existiert.

| Spiel | firstpass.dll | Prüfsummenformat |
|---|---|---|
| GH | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| Subnautica | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| EscapeThePacific | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| Raft | ❌ Nicht vorhanden | Nur `Assembly-CSharp MD5` (32 Zeichen) |

### Versions.xml-Aktualisierungsverfahren bei Spiel-Update

Einen neuen `<version>`-Eintrag hinzufügen, ohne bestehende Einträge zu entfernen.

**Step 1 — Neue BuildID finden**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Spiel | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Step 2 — Neue Prüfsumme extrahieren**
```powershell
# Spiele mit firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Beide Hash-Werte in Reihenfolge verketten (firstpass zuerst)

# Spiele ohne firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Step 3 — Eintrag zu Versions.xml hinzufügen**
```xml
<version id="{neue BuildID}">
    <checksum>{neue Prüfsumme}</checksum>
</version>
```

---

## Änderungen in v2.0.9615

### Settings Tab Spielpfad-Aufklappen behoben

- **Karten-Aufklapphöhe**: Der untere Fensterrand wächst jetzt exakt um die Höhe des Eingabefelds beim Aufklappen einer Spielpfad-Karte
- **`UpdateWindowHeight()` verbessert**: Ruft `UpdateLayout()` vor der `SizeToContent.Height`-Messung auf; setzt `TextureLayer1` temporär auf `Collapsed` bei aktiver Hintergrundtextur, um zu verhindern, dass die 4K-Bildoriginalgröße die Höhenberechnung beeinflusst
- **Innere Grid Row-Korrektur**: Letzte Row des Spielpfad-Panels von `Height="*"` auf `Height="Auto"` geändert — entfernt unnötigen unteren Leerraum

---

## Änderungen in v2.0.9614

### Maximieren-Button-Verhalten behoben

- **Maximieren**: Verwendet `SystemParameters.WorkArea` für manuelle Maximierung statt `WindowState.Maximized` — passt exakt an die aktuelle Bildschirmauflösung ohne Taskleisten-Überlappung
- **Wiederherstellen**: Speichert `Left`, `Top`, `Width`, `Height` und `MaxWidth` vor dem Maximieren und stellt sie beim Klick auf den Wiederherstellen-Button wieder her
- **`MaxWidth`-Behandlung**: Auf `∞` beim Maximieren gesetzt, gespeicherter Wert beim Normalisieren wiederhergestellt

---

## Änderungen in v2.0.9613

### Neuer Themes-Tab

Tab-Reihenfolge ist jetzt:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Die Theme-Auswahl-UI wurde vom Settings-Tab in einen eigenen **Themes-Tab** verschoben.
Symbol: Segoe MDL2 Assets `&#xE790;` (Palette)

### Theme Registry (Datengesteuerte Struktur)

Ein neues Theme hinzuzufügen erfordert nur **eine Zeile** im `App.xaml.cs`-Dictionary.
Alle Switch-Anweisungen wurden entfernt — keine Code-Änderungen an anderer Stelle nötig.

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

`ThemeSelector` ComboBox-Einträge werden automatisch aus der `ThemeIds`-Schleife generiert.
Sprachschlüssel-Konvention: `Lang.Options.Theme.{PascalCase}` (z.B. `Lang.Options.Theme.Nebula`)

### Unterstützte Themes

| Index | ID | Datei | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` allein | Originales ModAPI-Texturhintergrund |
| 1 | `light` | `FluentStylesLight.xaml` | Heller Ton + blauer Akzent |
| 2 | `dark` | `FluentStyles.xaml` | Dunkler Ton + blauer Akzent (Standard) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rot + Schwarz |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dunkler Weltraum |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Heller Sonnenuntergang |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dunkler Ozean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Helles Nordisch |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Helles Zitrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Helles Blühen |

Theme-Änderungen lösen einen automatischen App-Neustart aus. (gespeichert in `theme.cfg`)

### Hintergrundtextur-Feature

Wählen Sie ein Bild im **Background Texture**-Bereich des Themes-Tabs aus, um es als App-weiten Hintergrund zu verwenden. Funktioniert mit jedem ausgewählten Theme.

**Unterstützte Eingabeformate**: `.png` / `.jpg` / `.jpeg`, bis zu 50MB, 4K-Auflösung oder niedriger

**Bildverarbeitungs-Pipeline**

```
Vom Benutzer ausgewähltes Bild (.png / .jpg / .jpeg, max 50MB, 4K oder niedriger)
  ↓
JPEG Q75 Kompression (Speicherpuffer)
  ↓
16-Byte Magic-Header eingefügt
  "MODAPI" + "BG" + Version + Padding (FF 00 FE 00)
  ↓
Gespeichert als resources\textures\ui_bg\bg.dat (Hidden-Attribut)
  ↓
SHA-256 Hash → in ui.cfg als TextureHash gespeichert
```

**Sicherheitsschichten**

| Schicht | Methode | Wirkung |
|---|---|---|
| Magic-Header | 16 Bytes vor JPEG-Signatur (FF D8 FF) eingefügt | Externe Viewer können die Datei nicht erkennen |
| Hidden-Attribut | `FileAttributes.Hidden` | Im Explorer standardmäßig ausgeblendet |
| SHA-256 Integrität | Hash beim Laden verifiziert | Manipulation löst automatisches Zurücksetzen + Warnungs-Popup aus |

**Verhalten bei Manipulationserkennung**
1. `bg.dat` gelöscht
2. `ui.cfg`-Schlüssel `TexturePath`, `TextureHash`, `TextureActive` zurückgesetzt
3. TextBox und Toggle zurückgesetzt
4. `Lang.Windows.TextureTampered`-Popup angezeigt

**ui.cfg-Schlüssel**

| Schlüssel | Wert | Beschreibung |
|---|---|---|
| `TexturePath` | Dateiname (nur Anzeige) | Originaldateiname in TextBox angezeigt |
| `TextureHash` | SHA-256 hex | Integritätsprüfungs-Hash |
| `TextureActive` | `true` / `false` | Aktivierungsstatus |

**Transparenzverarbeitung**

Bei aktivem Hintergrundbild werden UI-Hintergründe in zwei Schichten verarbeitet.

- **Layer 1 — MergedDictionaries-Overlay**: Panels, die `{DynamicResource FluentBgBrush}` etc. referenzieren, werden automatisch transparent gemacht. Wiederherstellung durch einen einzelnen `Remove()`-Aufruf bei Deaktivierung.

  Zielschlüssel: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — Visueller Baum-Durchlauf (`WalkStyleBackgrounds`)**: `{StaticResource}`-Elemente in Fluent-Themes werden von Layer 1 nicht beeinflusst, daher wird der visuelle Baum direkt durchlaufen, um halbtransparente Pinsel basierend auf Originalfarben anzuwenden.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=vollständig transparent, 255=undurchsichtig → 100 ≈ 39% undurchsichtig
  ```

  Verarbeitet: `Panel` (außer Grid), `Border`, `ListBox` / `ListView`

  Ausgeschlossen: `Grid` (Hintergrund beibehalten, Kinder durchlaufen), `TabPanel` (Tab-Header-Schutz), `ButtonBase` / `ComboBox`, `Collapsed`-Elemente

  Wiederherstellung: Style Setter-Quelle → `ClearValue()`, XAML-Lokalwert-Quelle → Original-Pinsel direkt wiederherstellen

**Tab-Wechsel**

WPF TabControl lädt Tab-Inhalte verzögert, daher wird `WalkStyleBackgrounds(this)` bei Tab-Wechsel mit `ContextIdle`-Priorität erneut ausgeführt. Bereits verarbeitete Elemente werden per `ContainsKey`-Check übersprungen.

**ThemeSelector-Sperre**

Bei aktiver Hintergrundtextur wird ein `ThemeSelectorOverlay`-Border über dem Theme-Selector angezeigt, um Interaktion zu blockieren.

- XAML: `ThemeSelectorOverlay`-Border über ThemeSelector hinzugefügt (`IsHitTestVisible=True`)
- Aktiv: `ThemeSelectorOverlay.Visibility = Visible`
- Inaktiv: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` ebenfalls durch `_textureActive`-Flag geschützt

**UI-Zustandsfluss**

```
Bild ausgewählt (Browse)
  → bg.dat erstellt → Toggle entsperrt → automatisch aktiviert → TextureLayer1 angezeigt
  → SaveAndClearBrushes() → ThemeSelectorOverlay angezeigt

Toggle deaktiviert
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay ausgeblendet
  → TextureLayer1 ausgeblendet

Clear-Button
  → bg.dat gelöscht → Toggle gesperrt → TextureLayer1 ausgeblendet → Pinsel wiederhergestellt
  → GC.Collect() (gibt 4K-Bildspeicher frei)
```

**Neue Sprachschlüssel**

| Schlüssel | Beschreibung |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 neue Theme-Namen |
| `Lang.Options.Labels.TextureBackground` | Hintergrundtextur-Label |
| `Lang.Options.Labels.TextureEnable` | Aktivieren-Label |
| `Lang.Options.Labels.TextureClear` | Zurücksetzen-Button |
| `Lang.Windows.TextureTooLarge` | Dateigröße überschritten Warnung |
| `Lang.Windows.TextureTampered` | Manipulation erkannt Warnung |

**Dateistruktur**

```
ModAPI\
├── App.xaml.cs                    # Theme-Registrierung, Theme-IDs, Theme-Anwendung
├── Windows\
│   ├── MainWindow.xaml            # Themes-Tab, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Theme- & Textur-Logik
├── Themes\
│   ├── Dictionary.xaml            # Classic Theme
│   ├── FluentStyles.xaml          # Dark Theme
│   ├── FluentStylesLight.xaml     # Light Theme
│   ├── FluentStylesDiablo.xaml    # Diablo Theme
│   ├── FluentStylesNebula.xaml    # Nebula Theme
│   ├── FluentStylesSunset.xaml    # Sunset Theme
│   ├── FluentStylesOcean.xaml     # Ocean Theme
│   ├── FluentStylesNordic.xaml    # Nordic Theme
│   ├── FluentStylesCitrus.xaml    # Citrus Theme
│   └── FluentStylesBloom.xaml     # Bloom Theme
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Komprimiertes & gesichertes Hintergrundbild (Laufzeit-generiert)
```

**Bekannte Designeinschränkungen**

| Element | Details |
|---|---|
| `IsEnabled=false` bei ComboBox | Verursacht `ElementNotEnabledException`-Crash → `IsHitTestVisible`-Overlay-Ansatz verwendet |
| Direkter `MergedDictionaries`-Schlüsselaustausch | Crash während Layout-Pass → nur `Add`/`Remove`-Muster |
| Überschreiben versteckter Dateien | `Access Denied` → muss `FileAttributes.Normal` vor dem Schreiben zurücksetzen |
| `{StaticResource}`-Hintergründe | Nicht von Layer 1 betroffen → erfordert WalkStyleBackgrounds (Layer 2) |

---

## Änderungen in v2.0.9612

### Theme-Modul-Trennung

- **Neuer `Themes/`-Ordner**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` und `FluentStylesClassic.xaml` nach `ModAPI\Themes\` verschoben
- **`App.xaml.cs`**: `ApplyTheme()` — Classic-Theme verwendet nur `Dictionary.xaml`; Light/Dark/andere Fluent-Themes laden entsprechendes XAML
- **`ModAPI.csproj`**: Theme-XAML-Pfade auf `Themes\`-Unterverzeichnis aktualisiert; `FluentStylesClassic.xaml` registriert

---

## Änderungen in v2.0.9611

### Fehlerbehebung

- **Mod-Listenbreite nach Theme-Wechsel nicht angewendet**: Problem behoben, bei dem die Mod-Listenbreite nach Wechsel zwischen Light/Dark-Themes und Neustart nicht angewendet wurde — `ApplyModListWidth(width)`-Aufruf in `InitModListWidth()` hinzugefügt

---

## Änderungen in v2.0.9610

### Hinzugefügt

#### Spiel-XML & Versionskonfiguration

| # | Datei | Änderung |
|---|------|--------|
| 1 | `GH.xml` | Vollständig neu geschrieben — nicht existierende `DOTweenPro.dll` entfernt; `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` hinzugefügt |
| 2 | `Subnautica.xml` | Vollständig neu geschrieben — `extends="GenericUnityGame"` entfernt; `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` hinzugefügt |
| 3 | `EscapeThePacific.xml` | Vollständig neu geschrieben — `extends="GenericUnityGame"` entfernt; `includeAssembly` → nur `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Erstellt — Version `1.1.01` mit Prüfsumme |
| 5 | `GH/Versions.xml` | Erstellt — Version `2.9.5` mit Prüfsumme |
| 6 | `Subnautica/Versions.xml` | Erstellt — keine Prüfsumme (zu häufige Updates) |

#### Kritische Fehlerbehebungen

| # | Typ | Problem | Lösung |
|---|------|-------|-----|
| 1 | Hänger | `extends="GenericUnityGame"` verursachte `Assembly-CSharp-firstpass.dll`-Vererbung → `CreateModLibrary` hing fest | `extends` aus allen Nicht-TheForest-XML entfernt |
| 2 | Absturz | `ResolutionException: XGamingRuntime.XUserGamertagComponent` beim Subnautica-Anwenden | `XGamingRuntime.dll`, `XblPCSandbox.dll` zu `copyAssembly` hinzugefügt |
| 3 | Absturz | Resolver schlug bei nach Backup hinzugefügten DLLs in `copyAssembly` fehl | `Game.cs`: tatsächlicher Installationsordner als Resolver-Fallback hinzugefügt |
| 4 | Absturz | `IOException`: `BaseModLib.dll`-Dateisperre zwischen `CreateModLibrary` und `ApplyMods` | Wiederholungsschleife: max 10 × 500ms Lesen + max 30 × 500ms Existenzprüfung |
| 5 | Absturz | `NullReferenceException` — `typesMap` entry.Value null (Spiel nicht installiert) | `if (entry.Value == null) continue` hinzugefügt |
| 6 | Absturz | `NullReferenceException` — leichtgewichtiger `Game`-Konstruktor ohne `ModLibrary = new ModLib(this)` → `CreateModLibrary()`-Absturz | `ModLibrary = new ModLib(this)` zum leichtgewichtigen Konstruktor hinzugefügt |
| 7 | Absturz | `SwitchDevGame()` — `App.Game.GamePath` leer nach leichtgewichtigem Konstruktor → `CreateModLibrary`-Absturz | `App.Game.GamePath = savedPath` nach leichtgewichtigem Konstruktor gesetzt |
| 8 | Falsches Spiel | `EscapeThePacific`-Mods als TheForest klassifiziert | `ModsViewModel`: `GameId` aus Ordnerpfad extrahiert |
| 9 | Falscher Pfad | `GetGameFolder()` → `""` → löst zum Laufwerksstamm auf (z.B. `E:\`) | Null/Leer-Prüfung an allen 6 Aufrufstellen |

#### Debug / Release Build-Aufteilung

- **`FileValidator.cs`** — neue Datei `ModAPI_Shared\Utils\FileValidator.cs`; registriert in `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — PE-Header (MZ + PE\0\0) + mindestens 1 MB
  - `IsValidGameExe()` — PE-Header + mindestens 512 KB
  - `IsValidAssemblyDll()` — PE-Header + .NET CLR-Metadaten-Header + mindestens 64 KB
- **`CheckSteam()`** — `#if DEBUG`: nur `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: nur `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` ohne Cecil / `#else`: vollständiges Cecil-Parsing + IL-Modifikation
- **`ModLib.Create()` Datei nicht gefunden** — `#if DEBUG`: Warnung protokollieren, überspringen / `#else`: Fehler protokollieren, abbrechen

#### Debug-Tests

- **`create_dummy_Debug_games.ps1`** — PowerShell-Skript für `bin\Debug\`; erstellt 0-Byte-Platzhalterdateien für alle 5 Spiele unter `dummy_games\`, `dummy_steam\` und `gamefiles\original\` — ermöglicht vollständige UI-Workflow-Tests ohne echte Spielinstallation

#### Settings-Tab

- **Steam-Pfad-Karte** — in die Spielinstallationspfade-Karte integriert; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Spielpfade-Panel** — `BuildGamePathsPanel()` mit aufklappbaren Karten pro Spiel; TextBox verwendet `HorizontalAlignment=Stretch`
- **Alle aufklappen / Alle zuklappen**-Button
- **ImmerImVordergrund**-Checkbox (gespeichert in `ui.cfg`)
- **Mod-/Projektlistenbreite**-Schieberegler — Start bei Minimum `150`; gespeichert in `ui.cfg`
- **Schriftgröße**-ComboBox — FHD 10–16, 4K 10–22, 8K 10–28
- **Checkbox-Synchronisierung** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions werden jetzt korrekt synchronisiert
- **`_uiInitialized`-Flag** — verhindert vorzeitige `ui.cfg`-Schreibvorgänge während des WPF-Starts

#### Mods-Tab — Spielstart-Validierung

Fünf-Stufen-Validierung bei jedem Spielstart-Klick, unabhängig vom Mod-Listenstatus:

| Schritt | Prüfung | Popup |
|---|---|---|
| 1 | Steam-Pfad im Settings-Tab gültig (`Steam.exe` existiert) | SteamNotFound |
| 2 | `mods/{GameId}/`-Ordner-Spiel stimmt mit konfiguriertem Spiel in den Einstellungen überein | GameModsMismatch |
| 3 | Mindestens ein Mod ausgewählt | NoModSelected |
| 4 | Keine gemischten Spiel-Mods in der Auswahl | MixedGameMods |
| 5 | Spielpfad konfiguriert + Ausführbare Datei existiert | GamePathNotSet / GameNotInstalled |

#### Development-Tab — ModLib-Validierung

Drei-Stufen-Validierung beim Klick auf Mod-Bibliothek-Regenerierung:

| Schritt | Prüfung | Popup |
|---|---|---|
| 1 | Steam-Pfad im Settings-Tab gültig | SteamNotFound |
| 2 | Mindestens ein Projekt existiert | NoProjectWarning |
| 3 | `App.Game.GamePath` gesetzt | GamePathNotSet |

#### Downloads-Tab
- Debug-String durch `Lang.Downloads.Status.NoDownloads` ersetzt
- Einheitliches Padding für alle Statusmeldungen
- Offline-Handbuchtext für 5 unterstützte Spiele aktualisiert; Zeilenumbruch über zwei TextBlocks

#### Ersteinrichtung & Spielpfadsystem
- `FirstSetup.Check()` — Standard `true` für `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — erstellt `mods/`- und `projects/`-Ordner für alle 5 Spiele
- `SpecifyGamePath` — `GameNameLabel` zeigt welches Spiel; `NavigateToSettings()` leitet zum Settings-Tab weiter

#### Neue / Aktualisierte Sprachschlüssel

| Schlüssel | Englischer Wert |
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

### Nicht enthalten

| Feature | Grund |
|---|---|
| Auto-Update (neueste Version beibehalten) | Serverseitige Infrastruktur nicht verfügbar |
| Update-Suche | Serverseitige Infrastruktur nicht verfügbar |

### Entfernt

| Element | Grund |
|---|---|
| `SpecifyGamePath`-Popup beim Start | Alle Pfade im Settings-Tab konfiguriert |
| `SpecifySteamPath`-Popup beim Start | Steam-Pfad im Settings-Tab konfiguriert |
| Login-System | Original-Server nicht mehr in Betrieb (entfernt in v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Nicht funktionsfähig auf Mono 2.0 (entfernt in v2.0.9586) |
| `UseSteam`-Bedingung bei Steam-Prüfung | Steam wird jetzt bei Spielstart und Mod-Bibliothek-Regenerierung immer zuerst validiert |

---

## Geplante zukünftige Versionen

| # | Feature | Beschreibung |
|---|---|---|
| 1 | ModAPI Auto-Update | Neue ModAPI-Versionen automatisch herunterladen und anwenden |
| 2 | ModAPI VersionsData-Tabelle Update | VersionsData-Tabelle automatisch aktualisieren, wenn neue Spiel-Patches erscheinen |

---

## Änderungen in v2.0.9600

### Hinzugefügt

- **Downloads-Tab**: 5 Spielfilter (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome-Tab**: an der linken Position hinzugefügt (Index 0)
- **Mods-Tab**: 3-Spalten-Layout (WrapPanel → vertikale Liste); automatische Breitenanpassung; Mod-Name-Umbruch
- **`ModsViewModel`**: spielspezifische Filterung, `ResolveGame()` für korrekte `Game`-Instanz pro Mod
- **`Game.cs`**: leichtgewichtiger Konstruktor `new Game(config, true)` — nur Identifikation, kein `Verify()`
- **Build**: 4 Spiel-XML-Dateien registriert in `ModAPI.csproj` mit `CopyToOutputDirectory=Always`
- **Build**: Warnungen bereinigt — CS0168, CS0618, CS0252
- **Spiel-XML**: TheForest, Raft, GH DLL-Listen korrigiert
- **Sprach-Flags**: Bildgrößen über alle 13 Sprachbadges standardisiert

### Entfernt

| Element | Grund |
|---|---|
| `extends="GenericUnityGame"` in Spiel-XML-Dateien | Verursachte fehlerhafte Vererbung von `Assembly-CSharp-firstpass.dll` — entfernt aus Subnautica, Raft, EscapeThePacific, GH |
| `WrapPanel`-Layout im Mods-Tab | Ersetzt durch 3-Spalten-Grid-Layout (Spielfilter / Mod-Liste / Information) |

---

## Wichtige Änderungen nach Phase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Alle 5 Projekte von .NET 4.5 → 4.8 migriert.

### Phase 2 *(v2.0.9300)* — Build-Umgebung & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, UnityEngine-Stub-DLL.

### Phase 3 *(v2.0.9500)* — UI-Redesign & Theme-System
3-Theme-System, `theme.cfg`, Fenster-Drag-Fix, Hyperlink-Unterstützung.

### Phase 4 *(v2.0.9400)* — Code-Bereinigung
Login-System entfernt, Update-Mechanismus modernisiert.

### Phase 5-1 *(v2.0.9552)* — Downloads-Tab & 13 Sprachen
Downloads-Tab, Segoe MDL2 Assets Icons, 13-Sprachen-Unterstützung.

### Phase 5-5 *(v2.0.9561)* — Assembly-Auflösung
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, PE-Header-Patching.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Schwarzer Bildschirm behoben, `ValueTuple` entfernt, C# 7.3 im Spiel verifiziert.

### Phase 6-1 *(v2.0.9600)* — Multi-Spiel & Mods-Redesign
5 Spielfilter, 3-Spalten-Mods-Tab, leichtgewichtiger `Game`-Konstruktor, XML registriert.

### Phase 6-2 *(v2.0.9610)* — Settings, Sicherheit, Absturzbehebungen & Debug/Release-Aufteilung
XML korrigiert, Steam-Pfad, Spielpfad-Sicherheit, Spielstart 5-Stufen-Validierung, ModLib 3-Stufen-Validierung, `FileValidator` PE-Header-Verifizierung, `#if DEBUG` Build-Aufteilung, `create_dummy_Debug_games.ps1`, leichtgewichtiger Konstruktor `ModLibrary`-Fix, `SwitchDevGame` GamePath-Fix, 5-Spiele-Ordner-Erstellung, Absturzbehebungen.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme-System-Erweiterung, Settings-Verbesserungen & Werkzeuge
Themes-Tab hinzugefügt, 10 Themes + Hintergrundtextur-Feature, Themes/-Ordner-Trennung, Maximieren-Button-Fix, Spielpfad-Aufklapp-Fix, Versions.xml 4-Spiele-Update, Pfad-Reset-Buttons, Browse Auto-Speicherung, MODAPI_VersionTool.

---

## Versionshistorie

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool hinzugefügt (eigenständiges WPF-Versions-Update-Tool), StatusBar-Versionsanzeige mit App.Version verknüpft

### v2.0.9617 — 2026-04-24
Steam/Spielpfad-Reset-Buttons im Settings-Tab hinzugefügt, Browse Auto-Speicherung, Reset-Status über ui.cfg-Flag erhalten

### v2.0.9616 — 2026-04-18
Versions.xml für 4 Spiele erstellt/aktualisiert (Subnautica, Raft, EscapeThePacific, GH), Prüfsummen-Zusammensetzungsregeln festgelegt, Spiel-Update-Verfahren dokumentiert

### v2.0.9615 — 2026-04-18
Settings-Tab Spielpfad-Karten-Aufklapphöhe behoben, UpdateWindowHeight Hintergrundtextur-Interferenz verhindert

### v2.0.9614 — 2026-04-18
Maximieren-Button WorkArea-basierte manuelle Maximierung, vorherige Größe/Position Speicherung und Wiederherstellung

### v2.0.9613 — 2026-04-18
Themes-Tab hinzugefügt, Theme-Registry datengesteuerte Struktur, 10 Themes unterstützt, Hintergrundtextur-Feature (Kompression, Sicherheit, 2-Schicht-Transparenz), ThemeSelector-Sperr-Overlay, 12 neue Sprachschlüssel

### v2.0.9612 — 2026-04-18
Themes/-Ordner-Trennung, Theme-XAML-Modularisierung

### v2.0.9611 — 2026-04-18
Mod-Listenbreite nach Theme-Wechsel nicht angewendet behoben

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

## Build-Anforderungen

| Anforderung | Version | Hinweise |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI-Projekte |
| .NET Framework SDK | 3.5 | Nur BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Lizenz

GNU General Public License v3.0 — folgt der ursprünglichen Lizenz.
