[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md) [![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md) [![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md) [![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md) [![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md) [![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md) [![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md) [![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md) [![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md) [![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md) [![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md) [![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md) [![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9621 - 20260728

**The Forest Mod-Management-Tool — Erweiterte Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Deutschland)
> Erweiterung: zzangae (Republik Korea)

---

## Überblick

ModAPI ist eine Desktop-Anwendung zur Verwaltung von Mods für **5 offiziell unterstützte Spiele**. Diese erweiterte Edition umfasst Multi-Game-Unterstützung, einen vollständig neu gestalteten Settings-Tab, Steam-Pfadkonfiguration, dauerhafte UI-Einstellungen, ein dynamisches Schriftgrößensystem, Startvalidierung für Spiele, eine Trennung von Debug-/Release-Builds sowie zahlreiche durch In-Game-Tests verifizierte Absturzkorrekturen.

---

## Unterstützte Spiele

| Spiel | Engine | Version | Steam-ID | Ausführbare Datei |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025-Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Punkt | Wert |
|---|---|
| Engine | Unity 5 (aktualisiert von Unity 4) |
| Neueste Version | v1.12 (VR) |
| Letztes Update | 11. September 2019 — VR-Unterstützungspatch; seitdem keine größeren Inhaltsupdates |
| Ausführbare Datei | `TheForest.exe` |
| Datenordner | `TheForest_Data/Managed/` |
| Mods-Ordner | `mods/TheForest/` |
| Projektordner | `projects/TheForest/` |
| Steam-App-ID | `242760` |
| IL2CPP | ❌ Mono — vollständig unterstützt |

The Forest wurde von Unity 4 auf Unity 5 aktualisiert, wodurch Grafik und Physik deutlich verbessert wurden. Der VR-Patch vom September 2019 war das letzte große Update. Das Spiel befindet sich seitdem in einem stabilen, abgeschlossenen Zustand — ideal für Modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Punkt | Wert |
|---|---|
| Engine | Unity (2022 mit Below Zero zu einer gemeinsamen Codebasis vereint) |
| Neueste Version | 2025-Patch (v18810395) |
| Letztes Update | 12. August 2025 — Fehlerbehebungen und Leistungsverbesserungen im Zuge der Mobile-Veröffentlichung |
| Ausführbare Datei | `Subnautica.exe` |
| Datenordner | `Subnautica_Data/Managed/` |
| Mods-Ordner | `mods/Subnautica/` |
| Projektordner | `projects/Subnautica/` |
| Steam-App-ID | `264710` |
| IL2CPP | ❌ Mono — unterstützt |

Subnautica basierte ursprünglich auf Unity 5 und erhielt Ende 2022 das „Living Large"-Update (v2.0), das die Engine-Codebasis mit Below Zero zusammenführte und Optimierung sowie Stabilität verbesserte. Hinweis: Der kommende Nachfolger *Subnautica 2* verwendet die Unreal Engine 5.

> **XML in v2.0.9610 neu geschrieben**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` zu `copyAssembly` hinzugefügt.
</details>

<details>
<summary><b>RAFT</b></summary>

| Punkt | Wert |
|---|---|
| Engine | Unity |
| Neueste Version | v1.1.02 (Beta) / v1.09 (Stable) |
| Letztes Update | März 2026 — Fehlerbehebungen für Voice-Chat und Mehrspielermodus über den Beta-Branch |
| Ausführbare Datei | `Raft.exe` |
| Datenordner | `Raft_Data/Managed/` |
| Mods-Ordner | `mods/Raft/` |
| Projektordner | `projects/Raft/` |
| Steam-App-ID | `648800` |
| IL2CPP | ❌ Mono — unterstützt |
| Versions.xml | `1.1.01` (mit Prüfsumme) |

Nach dem offiziellen Abschluss der Story in v1.0: *The Final Chapter* wurden weiterhin Patches für Netzwerkcode-Verbesserungen und Stabilität veröffentlicht. Ein Update des Beta-Branchs im März 2026 behob Probleme mit Voice-Chat und Mehrspielermodus.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Punkt | Wert |
|---|---|
| Engine | Unity 6 (Ende 2025 von Unity 2021/2022 migriert) |
| Neueste Version | v0.67.0.0 |
| Letztes Update | 26. Juni 2025 — Überarbeitung der Inselverteilung und Engine-Update; Hotfixes laufen bis 2026 weiter |
| Ausführbare Datei | `EscapeThePacific.exe` |
| Datenordner | `EscapeThePacific_Data/Managed/` |
| Mods-Ordner | `mods/EscapeThePacific/` |
| Projektordner | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — unterstützt |

Ende 2025 wurde ein umfassender Systemumbau sowie die Migration zu Unity 6 abgeschlossen, wodurch dynamischere Umgebungen ermöglicht werden. Das Spiel befindet sich weiterhin in aktiver Early-Access-Entwicklung.

> **XML in v2.0.9610 neu geschrieben**: `extends="GenericUnityGame"` entfernt; `includeAssembly` auf ausschließlich `Assembly-CSharp.dll` gesetzt — verhindert Vererbungsfehler durch `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Punkt | Wert |
|---|---|
| Engine | Unity 2019 |
| Neueste Version | v2.9.5 |
| Letztes Update | 4. Februar 2026 — Steam-Deck-Optimierung und Verbesserungen der Textlesbarkeit |
| Ausführbare Datei | `GH.exe` |
| Datenordner | `GH_Data/Managed/` |
| Mods-Ordner | `mods/GH/` |
| Projektordner | `projects/GH/` |
| Steam-App-ID | `763790` |
| IL2CPP | ❌ Mono — unterstützt |
| Versions.xml | `2.9.5` (mit Prüfsumme) |

Über den Lebenszyklus hinweg entwickelt mit Unity 2017 → 2018 → 2019. Der Hotfix vom Februar 2026 konzentrierte sich auf Steam-Deck-Kompatibilität und UI-Lesbarkeit.

> **XML in v2.0.9610 neu geschrieben**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` hinzugefügt; nicht vorhandene `DOTweenPro.dll` entfernt.
</details>

---

<details>
<summary><b>Architektur</b></summary>

### Laufzeit-Trennung

| Komponente | Ziel | Laufzeitumgebung | Grund |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop-Anwendung, vollständig moderne API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Gemeinsam genutzte Bibliothek |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Dauerhaft fixiert** — PE-Header muss `v2.0.50727` anzeigen |
| Mod-DLLs (Benutzer) | .NET Framework 4.8 | Game Mono 2.0 (gepatcht) | Mit 4.8 erstellt, PE-Header wird beim Anwenden gepatcht |

### Entwicklertools

Eigenständige WPF-Dienstprogramme für die Projektverwaltung. Werden nicht an Endanwender verteilt.

| Tool | Projekt | Zweck |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Aktualisiert `AssemblyInfo.cs` und `App.xaml.cs`-Version gleichzeitig |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Verwaltung von Sprachdateien — hinzufügen, bearbeiten, deaktivieren, fest integrieren |

**VersionTool — Versionsverwaltung**

Ein eigenständiges WPF-Tool zur Aktualisierung der Versionsnummer mit einem Klick.

- Zeigt automatisch die aktuelle Version an (gelesen aus `App.xaml.cs`)
- Neue Version eingeben und **Apply Version** klicken, um beide Dateien gleichzeitig zu aktualisieren
- Formatvalidierung: Es wird nur das Format `X.X.XXXX` akzeptiert

| Datei | Pfad | Änderung |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Sprachsystem**

```
resources/langs/langs.json          ← Sprachregister (builtin / active Flags)
resources/langs/Language.XX.xaml    ← Übersetzungsschlüssel pro Sprache
resources/langs/Language.XX.png     ← Flaggenbild (36×24, von flagcdn.com/h24/)
```

Ablauf der festen Integration (Update-Button):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() neu geschrieben (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml registriert (ModAPI\ModAPI.csproj)
  → Nächster Build: Sprache vollständig integriert, offline verfügbar
```

### Trennung von Debug-/Release-Builds

Alle Dateivalidierungen und Assembly-Verarbeitungen verzweigen über `#if DEBUG` / `#else` je nach Build-Konfiguration.

| Ort | Debug-Build | Release-Build |
|---|---|---|
| `CheckSteam()` | nur `File.Exists()` — Dummy-Dateien werden akzeptiert | `FileValidator.IsValidSteamExe()` — PE-Header + min. 1 MB |
| `CheckGamePath()` | nur `File.Exists()` — Dummy-Dateien werden akzeptiert | `FileValidator.IsValidAssemblyDll()` — PE-Header + CLR-Metadaten + min. 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — Cecil-Parsing wird übersprungen | Vollständiges Mono.Cecil-Parsing + IL-Änderung + `module.Write()` |
| `ModLib.Create()` — Datei nicht gefunden | Warnung protokollieren, überspringen und fortfahren | Fehler protokollieren, mit Popup abbrechen |

**Beim Debug-Testing** wird `create_dummy_Debug_games.ps1` verwendet, um 0-Byte-Platzhalterdateien unter `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` und `bin\Debug\gamefiles\original\` zu erzeugen. Diese bestehen die `File.Exists()`-Prüfung und ermöglichen einen vollständigen UI-Workflow-Test ohne echte Spielinstallation.

**Release-Builds** wenden `FileValidator` (PE-Header + .NET-CLR-Metadatenprüfung) an, um 0-Byte-Dateien, Textdateien und beliebige Binärdateien abzulehnen. Nur gültige Windows-Ausführungsdateien und .NET-Assemblies werden akzeptiert.

### FileValidator — PE-Header-Verifizierung

`ModAPI_Shared\Utils\FileValidator.cs` — wird nur in Release-Builds angewendet.

| Methode | Prüfungen | Mindestgröße |
|---|---|---|
| `IsValidSteamExe(path)` | MZ-Signatur + PE\0\0-Signatur | 1 MB |
| `IsValidGameExe(path)` | MZ-Signatur + PE\0\0-Signatur | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR-Metadaten-Header (Datenverzeichnis #14) | 8 KB |

```
Geprüftes PE-Header-Layout:
[0x00] 4D 5A          ← "MZ" DOS-Signatur
[0x3C] XX XX XX XX   ← PE-Header-Offset (Little-Endian)
[offset] 50 45 00 00 ← "PE\0\0"-Signatur
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET-CLR-Header vorhanden
```

### Assembly-Remapping-Pipeline

```
[Mod-Entwickler erstellt mit .NET 4.8]
  → Mod-DLL: PE-Header v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0 usw.
  → modModule.RuntimeVersion = "v2.0.50727"
      PE-Header: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → PE-Header akzeptiert ✅  →  Referenzen aufgelöst ✅
```

### Assembly-Resolver-Fallback

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← Backup-Ordner
2. {ActualGameInstallPath}/{AssemblyPath}        ← Spielinstallationsordner (Fallback)
```

### Unterstützung für C#-7.3-Funktionen

| Funktion | Status | Anmerkungen |
|---|---|---|
| Mustervergleich (`is`, `switch`) | ✅ | im Spiel verifiziert |
| String-Interpolation (`$""`) | ✅ | im Spiel verifiziert |
| Inline-`out`-Variable | ✅ | im Spiel verifiziert |
| `async` / `await` | ✅ | über AsyncBridge + System.Threading-Polyfills |
| Tupel (`ValueTuple`) | ❌ Harte Grenze | Mono 2.0 `mscorlib`-ABI — keine Umgehungsmöglichkeit |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Seit v2.0.9613 wurde die Themenauswahl-UI aus dem Settings-Tab in einen eigenen **Themes-Tab** verschoben. Ein neues Theme hinzuzufügen erfordert nur eine Zeile im `App.xaml.cs`-Dictionary.

| Index | ID | Datei | Farbpalette |
|---|---|---|---|
| 0 | `classic` | nur `Dictionary.xaml` | Original-ModAPI-Texturhintergrund |
| 1 | `light` | `FluentStylesLight.xaml` | Heller Ton + blauer Akzent |
| 2 | `dark` | `FluentStyles.xaml` | Dunkler Ton + blauer Akzent (Standard) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rot + Schwarz |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dunkler Weltraum |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Heller Sonnenuntergang |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dunkler Ozean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Heller nordischer Stil |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Helles Zitrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Helle Blüte |

Ein Themenwechsel löst einen automatischen App-Neustart aus. (gespeichert in `theme.cfg`)

| Theme | Theme |
| :---: | :---: |
|**01. Classic-Theme**|**02. Light-Theme**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Dark-Theme**|**04. Diablo-Theme**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Nebula-Theme**|**06. Sunset-Theme**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Ocean-Theme**|**08. Nordic-Theme**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Citrus-Theme**|**10. Bloom-Theme**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### Hintergrundtextur

Wählen Sie im Themes-Tab in der Karte **Background Texture** ein Bild aus, um es als appweiten Hintergrund anzuwenden. Unterstützte Formate: `.png` / `.jpg` / `.jpeg`, bis zu 50 MB, 4K-Auflösung oder darunter. Das Bild wird als JPEG mit Q75 komprimiert, mit einem 16-Byte-Magic-Header versehen und als `resources\textures\ui_bg\bg.dat` (Hidden-Attribut) gespeichert. SHA-256-Hash zur Integritätsprüfung; Manipulation löst automatisches Zurücksetzen + Warn-Popup aus.

Wenn der Hintergrund aktiv ist, wird die UI-Transparenz in zwei Schichten verarbeitet: Schicht 1 (MergedDictionaries-Overlay) für `{DynamicResource}`-Panels, Schicht 2 (WalkStyleBackgrounds) für auf `{StaticResource}` basierende Panels mit Halbtransparenz.

### Schriftgrößensystem

| Ressourcenschlüssel | Basiswert | Beschreibung |
|---|---|---|
| `AppBaseFontSize` | 13 | Normaler Text |
| `AppBaseHeaderFontSize` | 16 | Überschriften, Panel-Titel |
| `AppBaseSmallFontSize` | 12 | Sekundäre Beschriftungen |
| `AppBaseTinyFontSize` | 10 | Hinweistext |
| `AppBaseLargeFontSize` | 20 | Große Anzeigetexte |

### Dauerhafte UI-Konfiguration — `ui.cfg`

| Schlüssel | Standard | Beschreibung |
|-----|---------|-------------|
| `ModListWidth` | `150` | Listenbreite im Mods-Tab (px) |
| `ProjectListWidth` | `150` | Projektlistenbreite im Development-Tab (px) |
| `AppFontSize` | `13` | Globale UI-Schriftgröße (px) |
| `AlwaysOnTop` | `false` | Fenster immer im Vordergrund |
| `TexturePath` | *(keiner)* | Ursprünglicher Dateiname der Hintergrundtextur (nur Anzeige) |
| `TextureHash` | *(keiner)* | SHA-256-Hash der Hintergrundtextur |
| `TextureActive` | `false` | Aktivierungsstatus der Hintergrundtextur |
| `GamePathReset_{GameId}` | *(keiner)* | Flag zum Zurücksetzen des Spielpfads |
| `SteamPathReset` | *(keiner)* | Flag zum Zurücksetzen des Steam-Pfads |
</details>

<details>
<summary><b>Projektstruktur</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Dauerhafte UI-Einstellungen
├── theme.cfg                            # Aktuelles Theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Haupt-UI — 6 Tabs, Themes, Settings, Steam-Pfad,
│   │                                    #   Schutz vor 0-Byte-Downloads, Slider-Debounce, stilles Konfigurationslesen
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup für Spielpfad (dynamisches GameNameLabel)
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
│   ├── Mod.cs                           # Mod-Dateiladen, LF/CRLF-Header-Parsing, Diagnoseprotokoll
│   ├── ModLib.cs                        # BaseModLib-Erzeugung + Remapping (#if-DEBUG-Trennung)
│   ├── Models/
│   │   └── ModProject.cs                # Projekt erstellen/bauen/anwenden + Null-Schutz
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   Schutz vor erneutem Versuch bei beschädigten Mods
│   │   ├── ModViewModel.cs              # GameId aus Ordnerpfad
│   │   ├── ModProjectsViewModel.cs      # Dispose() für DispatcherTimer
│   │   └── SettingsViewModel.cs         # Standardwert true für UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mono-2.0-Assembly-Versionszuordnung (20 Assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Namensbasierter Resolver mit Caching
│   └── MonoHelper.cs                    # Mono.Cecil-IL-Hilfsprogramme
├── resources/
│   ├── langs/                           # 13 Sprachdateien + langs.json (LangTool.*-Schlüssel in v2.0.9620 hinzugefügt)
│   └── textures/ui_bg/
│       └── bg.dat                       # Komprimiertes & gesichertes Hintergrundbild (zur Laufzeit erzeugt)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Vollständig neu geschrieben in v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Vollständig neu geschrieben in v2.0.9610
    │   ├── GH.xml                       # Vollständig neu geschrieben in v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — nicht unterstützt
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt mit silent-Parameter
├── Data/
│   ├── Game.cs                          # Automatische Backup-Erstellung für ApplyMods, bedingter Resolver,
│   │                                    #   Fallback auf Spielordner, Korrektur des leichtgewichtigen Konstruktors + ModLib-Initialisierung
│   └── ModLib.cs                        # #if-DEBUG-Trennung, Fallback auf Spielordner für IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # PE-Header + CLR-Metadatenvalidierung (nur Release, min. 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Eigenständiges WPF-Versionsupdate-Tool
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Versionseingabe, Apply-Button, Anzeige der aktuellen Version
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Eigenständiges WPF-Sprachverwaltungstool
├── App.xaml / App.xaml.cs              # Sprachladen/-wechsel, langtool.cfg
├── MainWindow.xaml / .cs               # Haupt-UI — Sprachliste, Bearbeitungspanel, Pfadauswahl
├── AddLanguageDialog.xaml / .cs        # ISO-3166-1-Länderauswahl-ComboBox
├── ModApiDialog.xaml / .cs             # Benutzerdefinierter Dialog im ModAPI-Stil (Info/Warnung/Bestätigung/Frage)
├── Models/
│   ├── LanguageEntry.cs                # Modell für Spracheintrag (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Wurzelmodell für langs.json
│   └── IsoCountry.cs                   # ISO-Ländermodell für ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Lesen/Schreiben von langs.json
    ├── FlagDownloader.cs               # Flaggendownload von flagcdn.com h24
    ├── XamlGenerator.cs                # Erzeugen/Speichern/Parsen von Language.XX.xaml
    ├── MissingKeyDetector.cs           # Erkennung fehlender Schlüssel anhand der englischen Referenz
    ├── IsoCountryList.cs               # Vollständige ISO-3166-1-Länderliste (196 Länder, offline)
    └── BuiltinCodeWriter.cs            # Neuschreiben von CreateDefaultLangsJson() + Registrierung in ModAPI.csproj

bin\Debug\                               # Nur für Debug-Tests
├── create_dummy_Debug_games.ps1         # Erzeugt Dummy-Spiel-/Steam-Struktur
├── dummy_games\{GameId}\               # Dummy-Spielinstallationspfade
├── dummy_steam\Steam.exe               # Dummy-Steam-Ausführungsdatei
└── gamefiles\original\{GameId}\        # Dummy-Backup-Pfade für ModLib
```

---

</details>

<details>
<summary><b>Installation & Einrichtung</b></summary>

### Schritt 1 — Voraussetzungen

| Punkt | Erforderlich |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (unter Windows 11 vorinstalliert; für Windows 10 [herunterladen](https://dotnet.microsoft.com/download/dotnet-framework/net48)) |
| Steam | Erforderlich — muss im Settings-Tab konfiguriert werden |
| Mindestens ein unterstütztes Spiel | Erforderlich — muss im Settings-Tab konfiguriert werden |

### Schritt 2 — ModAPI installieren

1. Neueste Version von GitHub herunterladen
2. In einen beliebigen Ordner entpacken (z. B. `C:\ModAPI\`)
3. `ModAPI.exe` ausführen
4. Beim ersten Start erscheint der **Welcome**-Bildschirm — Einstellungen konfigurieren und **Continue** klicken

### Schritt 3 — Steam-Pfad konfigurieren (Settings-Tab)

1. Zum Tab **Settings** wechseln
2. **Steam Installation Path** suchen
3. **Browse** klicken → `Steam.exe` auswählen
4. **Save** klicken

### Schritt 4 — Spielpfade konfigurieren (Settings-Tab)

1. Auf die Kopfzeile einer Spielkarte klicken, um sie zu erweitern
2. **Browse** klicken → das Stammverzeichnis des Spiels auswählen (wo sich die `.exe` befindet)
3. **Save** klicken

| Spiel | Ausführbare Datei | Beispielpfad |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Schritt 5 — Mods herunterladen (Downloads-Tab)

1. Zum Tab **Downloads** wechseln
2. Ein Spiel im Spielfilter auswählen
3. Mod durchsuchen oder suchen und **Download** klicken

> **Offline**: Laden Sie `.mod`-Dateien manuell von `modapi.survivetheforest.net` herunter und legen Sie sie im entsprechenden Ordner ab:

| Spiel | Ordner |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Schritt 6 — Mods anwenden & Spiel starten (Mods-Tab)

1. Zum Tab **Mods** wechseln
2. Im **Game Filter** ein Spiel auswählen (Spalte 0)
3. In der **Mod List** die zu aktivierenden Mods ankreuzen (Spalte 1)
4. **Start Game** klicken

Vor dem Start werden automatisch folgende Prüfungen durchgeführt:

| # | Prüfung | Popup bei Fehler |
|---|---|---|
| 1 | Steam-Pfad konfiguriert und gültig | SteamNotFound |
| 2 | Spiel im `mods/`-Ordner stimmt mit dem Settings-Spielpfad überein | GameModsMismatch |
| 3 | Mindestens ein Mod ausgewählt | NoModSelected |
| 4 | Keine gemischten Mods verschiedener Spiele in der Auswahl | MixedGameMods |
| 5 | Spielpfad konfiguriert und ausführbare Datei vorhanden | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Tab-Überblick</b></summary>

### Welcome-Tab
Ersteinrichtungsbildschirm (Tab-Index 0). Konfiguration von AutoUpdate, Steam-Verbindung und VersionsData-Tabellenpräferenzen. Bei späteren Starts bietet dieser Tab Community-Links und Release-Notes.

### Mods-Tab
Primärer Mod-Verwaltungsworkflow — 3-Spalten-Layout:

| Spalte | Inhalt |
|---|---|
| Spalte 0 | Game Filter — Optionsfelder für die 5 unterstützten Spiele |
| Spalte 1 | Mod List — installierte Mods mit Versionsauswahl und Aktivierungs-Checkbox |
| Spalte 2 | Information — Details, Beschreibung und Versionshistorie des ausgewählten Mods |

### Downloads-Tab
Mods von `modapi.survivetheforest.net` durchsuchen und herunterladen.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 Kategorien (Bugfixes, Balancing, Cheats, …)
- **Search**: nach Mod-Name, Beschreibung oder Autor
- **Offline mode**: zeigt Ordneranweisungen für alle 5 unterstützten Spiele an

### Development-Tab
Mod-Entwicklungsworkflow — das Game-Filter-Panel (Spalte 0) deckt alle 5 unterstützten Spiele ab.

- Erstellen, Bauen und Anwenden von Mod-Projekten je Spiel
- Verwaltung von Sprachressourcen
- ModLib-Erzeugung mit 3-stufiger Validierung (Steam → Projekt → Spielpfad)
- Sicherer Spielwechsel über einen leichtgewichtigen `Game`-Konstruktor (kein `Verify()`-Aufruf)

### Themes-Tab
Themenauswahl und Verwaltung der Hintergrundtextur.

- **Themenauswahl**: 10 Themes (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Hintergrundtextur**: Ein Bild als appweiten Hintergrund auswählen (JPEG-Komprimierung + Sicherheitsverarbeitung)
- Bei aktiver Hintergrundtextur ist die Themenauswahl gesperrt

### Settings-Tab
Zentrale Konfiguration — 4 Zeilen:

| Zeile | Inhalt |
|---|---|
| 0 | Sprache / Schriftgröße / Maximale Breite / Mod-List-Breite / Project-List-Breite |
| 1 | VersionsData beibehalten / Automatisches Update / Steam-Verbindung / Immer im Vordergrund |
| 2 | Steam Installation Path (Textfeld + Browse + Save + Reset) |
| 3 | Game Installation Paths — je Spiel erweiterbare Karte (Textfeld + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Sprachverwaltungstool)

Ein eigenständiges WPF-Tool zur Verwaltung von ModAPI-Sprachdateien. Als `LangTool\MODAPI_LangTool.csproj` zur Solution hinzugefügt.

**Ort**: `LangTool\MODAPI_LangTool.csproj`

**Kernfunktionen**

| Funktion | Beschreibung |
|---|---|
| Sprachliste | Zeigt alle Sprachen aus `langs.json` mit Statussymbolen (🔒 fest integriert / 🚫 inaktiv / ✅ aktiv) |
| Sprache hinzufügen | Land in der ISO-3166-1-ComboBox auswählen → Flagge wird automatisch von `flagcdn.com/h24/{iso}.png` heruntergeladen → `Language.XX.xaml` wird automatisch aus der englischen Vorlage erzeugt |
| Sprache bearbeiten | `isoCode` / `langCode` gesperrt; `langName` und Übersetzungsschlüssel im aktiven Zustand bearbeitbar |
| Deaktivieren / Aktivieren | Schaltet das `active`-Flag in `langs.json` um — Datei bleibt erhalten, wird aus der ModAPI-Liste ausgeblendet |
| Update (fest integrieren) | Wandelt `builtin: false` → `true` um — nicht umkehrbar, zweistufige Bestätigung — schreibt `CreateDefaultLangsJson()` im Quellcode automatisch neu und registriert `Language.XX.xaml` in `ModAPI.csproj` |
| Erkennung fehlender Schlüssel | Vergleich mit der englischen Referenz — zeigt Anzahl fehlender/leerer Schlüssel und Übersetzungsfortschritt |
| Schutz fest integrierter Sprachen | Sprachen mit `builtin: true` sind schreibgeschützt — kein Bearbeiten, Deaktivieren oder Aktualisieren möglich |
| Schutz inaktiver Sprachen | Sprachen mit `active: false` sind bis zur Reaktivierung schreibgeschützt |
| Sprach-UI | LangTool selbst unterstützt alle 13 ModAPI-Sprachen — Sprachauswahl mit Flagge oben rechts |
| Pfadmerkung | Ausgewählter ModAPI-Stammpfad wird in `langtool.cfg` gespeichert — beim nächsten Start automatisch geladen |
| Benutzerdefinierte Dialoge | Alle Popups verwenden den dunkel gestalteten `ModApiDialog` im ModAPI-Stil statt der System-MessageBox |

**Struktur von langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Konvention für Flaggenbilder**

```
ISO-Code (Kleinbuchstaben) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                            resources/langs/
```

**Verhalten des Update-Buttons**

Beim Klick auf den Update-Button bei einer nicht fest integrierten, aktiven Sprache:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` wird mit allen aktuell fest integrierten (`builtin: true`) Sprachen neu geschrieben
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` wird registriert
4. Nächster Build — Sprache vollständig integriert, offline verfügbar

**Hinzugefügte Sprachschlüssel** (`Lang.LangTool.*`)

53 neue Schlüssel für alle LangTool-UI-Texte, Dialogmeldungen und Statustexte wurden zu allen 13 Sprachdateien hinzugefügt.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Versionsaktualisierungstool)

Ein eigenständiges WPF-Tool zur Aktualisierung der Versionsnummer mit einem Klick.

**Ort**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Funktionen**
- Zeigt automatisch die aktuelle Version an (gelesen aus `App.xaml.cs`)
- Neue Version eingeben und **Apply Version** klicken, um beide Dateien gleichzeitig zu aktualisieren
- Formatvalidierung: Es wird nur das Format `X.X.XXXX` akzeptiert

**Geänderte Dateien**

| Datei | Pfad | Änderung |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Verwendung**
1. `MODAPI_VersionTool.exe` ausführen
2. Neue Version eingeben (z. B. `2.0.9619`)
3. **Apply Version** klicken
4. Die ModAPI-Solution in Visual Studio neu erstellen

**StatusBar-Versionsanzeige**

- `VersionLabel.Text` verweist nun auf `App.Version` statt auf einen fest codierten Bezeichner
- Nach Aktualisierung der Version mit VersionTool und einem Rebuild wird dies sofort in der StatusBar angezeigt

---

</details>

<details>
<summary><b>Log</b></summary>

### Protokollsystem — Trennung in zwei Dateien (`ModAPI.log` / `ModAPI.detailed.log`)

Entwicklerspezifische Diagnoseprotokolle waren bisher an `#if DEBUG` gebunden, wodurch sie in Release-Builds genau dann unsichtbar waren, wenn sie zur Fehlersuche bei einem Benutzerproblem am dringendsten benötigt wurden. Ein Zwei-Dateien-System ersetzt dies:

| Datei | Inhalt |
|---|---|
| `ModAPI.log` | Kernprotokoll für den Benutzer — unverändert im Erscheinungsbild, nicht ausführlicher als zuvor |
| `ModAPI.detailed.log` | Jeder Protokollaufruf, immer, sowohl in Release als auch in Debug — zur Diagnose gemeldeter Benutzerprobleme |

**`Debug.cs`** — `Log()` besitzt einen `detailedOnly`-Parameter. Ist dieser `true`, wird die Meldung nur in `ModAPI.detailed.log` geschrieben; alle bisherigen `#if DEBUG`-Blöcke wurden auf dieses Flag umgestellt, statt vollständig herauskompiliert zu werden, sodass sie auch im Release stets in der Detaildatei erfasst werden. Daraus ergibt sich ein 4-stufiges Schweregradmodell:

| Stufe | Bedeutung |
|---|---|
| Verbose (`detailedOnly: true`) | Repetitive/mechanische Traces — pro Typ, pro Datei, pro Methode |
| Notice | Menschenlesbarer Ablauf — Fortschritts- und Erfolgsmeldungen |
| Warning | Mögliche Probleme, noch keine Fehler |
| Error | Bestätigte Fehler |

**Identifizierte Quellen von Protokollrauschen, umgestellt auf `detailedOnly: true`:**

| Datei | Was `ModAPI.log` überflutete |
|---|---|
| `ModsViewModel.cs` | `FindMods()`-Scan-/Skip-/Queue-Meldungen, die bei jedem 1-Sekunden-Poll wiederholt wurden |
| `Game.cs` | TLS/URL-Trace-Zeilen von `UpdateVersions()`, Cecil-Typzuordnungseinträge |
| `ModLib.cs` | Cecils Assembly-Verarbeitung pro Typ/Methode (`Validating`, `Processing`, `Changed ... accessibility`) — verantwortlich für den überwiegenden Teil des `ModAPI.log`-Umfangs (Zehntausende Zeilen für einen einzelnen Green-Hell-Mod-Build) |
| `Mod.cs` | Vollständiger Dump der Mod-Header-XML (`configuration.ToString()`), der bei jedem Mod-Laden protokolliert wurde |

**Protokollierung von Prüfsummen-Abweichungen — als Zusammenfassung statt pro Eintrag:** `Header.Verify()` protokollierte bisher pro inkompatiblem `InjectInto`/`AddMethod`/`AddField`/`AddClass`-Eintrag eine Zeile `Mismatched checksum at "..."`, was bei einem einzigen veralteten Mod Dutzende Zeilen bedeuten konnte. Jetzt wird eine einzelne Zusammenfassung auf Warning-Ebene in `ModAPI.log` protokolliert (z. B. `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), während die vollständige Aufschlüsselung pro Eintrag weiterhin in `ModAPI.detailed.log` verfügbar ist.

---

</details>

<details open>
<summary><b>Änderungen in v2.0.9621</b></summary>

## Änderungen in v2.0.9621

### Neue Funktionen

#### Steam-Bibliotheks-weite automatische Erkennung

`FindGamePath()` durchsucht jetzt, wenn ein Spiel über die fest hinterlegten `SearchPaths` nicht gefunden wird, **alle im System registrierten Steam-Bibliotheken** (einmal aus `libraryfolders.vdf` geparst, für die Sitzung zwischengespeichert). Dies gilt für alle 5 unterstützten Spiele, nicht nur für das aktuell aktive.

- Neu: `Game.GetSteamLibraryFolders()` — parst `libraryfolders.vdf`, statisch pro Sitzung zwischengespeichert
- Gesteuert durch die Checkbox **Steam-Verbindung**: deaktiviert (Standard bei Neuinstallation) → automatische Erkennung wird für alle 5 Spiele übersprungen, Pfade bleiben leer bis manuell gesetzt. Aktiviert → alle 5 Spiele werden konsistent über dieselbe Methode durchsucht.

#### Automatische Erkennung von Mods für das falsche Spiel

Eine `.mod`-Datei im falschen Spieleordner (z. B. ein Green-Hell-Mod, der nach `mods\TheForest\` kopiert wurde) wird jetzt automatisch erkannt, statt einen Apply-Vorgang stillschweigend zu beschädigen.

- `Game.CheckModGameCompatibility()` (innerhalb von `ApplyMods()`) prüft vor der Injektion, ob jeder von einem Mod deklarierte `AddMethod`/`AddField`/`InjectInto`-Typ tatsächlich in den echten Assemblies des Zielspiels existiert. Nicht passende Mods werden automatisch von diesem Apply ausgeschlossen; der Rest wird normal angewendet.
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` führen dieselbe Prüfung schon beim Laden des Mods aus (leichtgewichtig — liest die Assembly-Bytes in den Speicher, extrahiert Typnamen, gibt die Datei sofort wieder frei). Nicht passende Mods zeigen im Mods-Tab ein **⚠-Warnsymbol** mit Tooltip, noch bevor Apply geklickt wird.
- Wurden Mods ausgeschlossen und/oder letztlich nichts angewendet, zeigt Start Game ein einziges kombiniertes Popup statt mehrerer nacheinander; das Spiel wird nicht gestartet, wenn null Mods übrig bleiben (`Game.LastAppliedModCount`).

#### Einstellungen-Tab — Entwicklerprotokoll / Protokolle beim Start leeren

Zwei neue Checkboxen, nach **Steam-Verbindung** und vor **Immer im Vordergrund**:

| Schlüssel | Beschreibung |
|---|---|
| `Lang.Options.Labels.DevLog` | Aktiviert `ModAPI.dev.log` (umbenannt von `ModAPI.detailed.log`) — entspricht dem Start mit `--dev` |
| `Lang.Options.Labels.ClearLogsOnStart` | Leert den Ordner `logs\` bei jedem Start |

`Debug.ClearLogs()` schließt offene Log-Streams, bevor Dateien gelöscht werden, um "Datei wird verwendet"-Fehler zu vermeiden.

#### Globale Protokollierung nicht abgefangener Ausnahmen

`App.xaml.cs` hängt sich jetzt in `DispatcherUnhandledException` (UI-Thread) und `AppDomain.UnhandledException` (Hintergrund-Threads) ein. Ausnahmen, die die App bisher spurlos abstürzen ließen, werden jetzt mit Typ, Meldung und vollständigem Stack-Trace protokolliert, bevor der Prozess beendet wird.

---

### Kritische Fehlerbehebungen

| # | Datei | Problem | Behebung |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` löste einen explizit zurückgesetzten (leeren) Pfad zu `RootPath` statt zu `""` auf, da `Path.GetFullPath(RootPath + Trenner + "")` zu `RootPath` reduziert wird | Leere gespeicherte Werte geben jetzt sofort `""` zurück, vor der Pfadverknüpfung |
| 2 | `MainWindow.xaml.cs` | Die Validierungsreihenfolge von Start Game unterschied sich zwischen "Alle"-Filter und spezifischem Filter, wodurch manchmal ein Mod- oder Spielauswahl-Popup vor einem grundlegenderen Problem (fehlender Steam-/Spielpfad) erschien | Beide Pfade folgen jetzt derselben Reihenfolge: Steam → Spielpfad → Mod-Auswahl → Spielauswahl |
| 3 | `MainWindow.xaml.cs` | Die Mod-Erfassung für Start Game ignorierte den aktiven Spielfilter — angehakte Mods eines anderen (unsichtbaren) Spiels wurden trotzdem gezählt und lösten das falsche Popup aus | Die Mod-Erfassung berücksichtigt jetzt den aktuellen Filter; nur "Alle" aggregiert über alle Spiele |
| 4 | `ModsViewModel.cs` | `Mod.Mods` war nur nach `{ModId}-{Version}` indiziert, sodass identische Dateinamen in zwei verschiedenen Spielordnern kollidierten — `Load()` des zweiten wurde nie aufgerufen | Schlüssel enthält jetzt die GameId: `{GameId}-{ModId}-{Version}` |
| 5 | `ModsViewModel.cs` | Nach Fix #4 gruppierte `UpdateMods()` Listeneinträge weiterhin nur nach ModId und fasste zwei gleichnamige Mods verschiedener Spiele zu einem Eintrag zusammen — Absturz mit `ArgumentException: An item with the same key has already been added`, wenn beide dieselbe Version deklarierten | Die Anzeige-Gruppierung vergleicht jetzt auch die GameId |
| 6 | `Game.cs` | Green Hells `Versions.xml`-Liste `<files>` enthält dieselben zwei Dateien doppelt mit unterschiedlicher Groß-/Kleinschreibung (`_Data`/`_data`); `CheckFiles` war ein großschreibungsempfindliches `HashSet<string>`, sodass beide gehasht wurden und die Prüfsumme verdoppelten, was falsche Integritätsfehler erzeugte | `CheckFiles` verwendet jetzt `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | Der Schritt "alte Dateien entfernen" in `ModLib.Create()` hatte keinen Wiederholungsschutz gegen eine gesperrte `BaseModLib.dll`, und `Game.CreateModLibrary()` hatte keinerlei Ausnahmebehandlung — eine Sperre stürzte die gesamte App in einem Hintergrund-Thread ab | 10×500ms-Wiederholungsschleife beim Löschschritt hinzugefügt; `CreateModLibrary()` umschließt den Aufruf jetzt mit try/catch |
| 8 | `MainWindow.xaml.cs` | Wenn `ApplyMods()` mit null tatsächlich angewendeten Mods abschloss (z. B. alle ausgeschlossen), signalisierte es den Abschluss trotzdem wie ein echter Erfolg, sodass das Spiel ohne jede Modifikation gestartet wurde | `Game.LastAppliedModCount` unterscheidet "nichts angewendet" von "N angewendet"; Start wird bei 0 übersprungen |
| 9 | `MainWindow.xaml.cs` | Die Fensterhöhe wurde weder bei Schriftgrößenänderung noch beim Laden einer gespeicherten großen Schriftgröße beim Start noch beim Wechsel zum Einstellungen-Tab (`Tabs_SelectionChanged` war leer) neu berechnet — bei großen Schriftgrößen wurde die unterste Spielpfad-Karte abgeschnitten | Höhenberechnung an allen drei Stellen hinzugefügt |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` hatte keine Obergrenze — das gleichzeitige Aufklappen aller 5 Spielpfad-Karten konnte das Fenster auf Vollbildgröße oder darüber vergrößern | Höhe jetzt auf `SystemParameters.WorkArea.Height` begrenzt |
| 11 | `MainWindow.xaml.cs` | Die Ordner `mods\`/`projects\` wurden bei jedem Start bedingungslos für alle 5 Spiele erstellt, unabhängig davon, ob das Spiel installiert war | Ordner werden jetzt nur für Spiele mit verifiziertem Pfad und vorhandener ausführbarer Datei erstellt |
| 12 | `Game.cs` | `UpdateVersions()` konnte das Speichern von `Versions.xml` fehlschlagen, wenn der Zielordner noch nicht existierte (bisher verdeckt, da alle 5 Ordner bereits vorab eingecheckt sind) | Ordner wird unmittelbar vor dem Speichern über `Directory.CreateDirectory()` erstellt |

---

### Einstellungen-Tab — Standardwerte beim ersten Start geändert

`AutoUpdate`, `UseSteam` (Steam-Verbindung) und `UpdateVersionsTable` (VersionsData aktuell halten) sind bei einer Neuinstallation jetzt standardmäßig **deaktiviert** (zuvor standardmäßig aktiviert). Diese drei Funktionen sind serverseitig noch unvollständig und daher jetzt Opt-in — passend zu `DevLog`/`ClearLogsOnStart`.

### UI

- Checkbox-Zeile im Einstellungen-Tab (`SettingsCheckboxes`): `StackPanel` → `WrapPanel`, sodass Beschriftungen bei großen Schriftgrößen umbrechen statt abgeschnitten zu werden.

### Neue Sprachschlüssel (13 Sprachen)

| Schlüssel | Englischer Wert |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### Geänderte Dateien

| Datei | Pfad | Änderung |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\\Windows\\` | Einheitliche Start-Game-Validierungsreihenfolge, filterbewusste Mod-Erfassung, kombiniertes Ergebnis-Popup, durch UseSteam gesteuerte automatische Erkennung für 4 Spiele über Steam-Bibliothek, Fensterhöhen-Korrekturen (Schriftgröße / Tab-Wechsel / Obergrenze) |
| `MainWindow.xaml` | `ModAPI\\Windows\\` | Einstellungen-Tab DevLog/ClearLogsOnStart-Checkboxen, `WrapPanel` |
| `Game.cs` | `ModAPI_Shared\\Data\\` | Steam-Bibliothekssuche, großschreibungsunabhängiges `CheckFiles`, Mod-Kompatibilitätsprüfungen (umfassend + leichtgewichtig), `LastAppliedModCount`/`LastExcludedModsSummary`, Ausnahmebehandlung in `CreateModLibrary()`, durch UseSteam gesteuerte automatische Erkennung |
| `ModLib.cs` | `ModAPI_Shared\\Data\\` | Wiederholungsschleife beim Löschen alter Dateien |
| `Mod.cs` | `ModAPI_Shared\\Data\\` | Feld `GameMismatchReason` |
| `Configuration.cs` | `ModAPI_Shared\\Configurations\\` | Korrektur des `GetPath()`-Leerstring-Fehlers |
| `Debug.cs` | `ModAPI_Shared\\` | Umbenennung in `ModAPI.dev.log`, Feld `DevMode`, `ClearLogs()` |
| `App.xaml.cs` | `ModAPI\\` | Globale Ausnahmebehandler, Anbindung von `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\\Data\\ViewModels\\` | Spielspezifische `Mod.Mods`-Schlüssel, spielspezifische Anzeigegruppierung, Konflikt-Badge, Unterdrückung von Log-Spam |
| `ModViewModel.cs` | `ModAPI\\Data\\ViewModels\\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\\Data\\ViewModels\\` | `DevLog`/`ClearLogsOnStart`, Opt-in-Standardwerte für 3 bestehende Checkboxen |
| `FirstSetup.xaml` | `ModAPI\\Windows\\SubWindows\\` | Standardwerte von 3 Checkboxen auf deaktiviert geändert |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\\Windows\\SubWindows\\` | Neu |
| 13x `Language.XX.xaml` | `ModAPI\\resources\\langs\\` | 8 neue Schlüssel |

---

</details>

<details>
<summary><b>Änderungen in v2.0.9620</b></summary>

## Änderungen in v2.0.9620

### MODAPI_LangTool hinzugefügt

Ein eigenständiges WPF-Tool zur Verwaltung von ModAPI-Sprachdateien wurde hinzugefügt (`LangTool\MODAPI_LangTool.csproj`) — vollständige Details siehe Abschnitt **Lang Tool** oben.

---

### Fehlerbehebungen

| # | Datei | Problem | Behebung |
|---|---|---|---|
| 1 | `App.xaml.cs` | Französische Sprache mischte sich in .NET-Ausnahmemeldungen auf nicht-englischem Windows | `CultureInfo.InvariantCulture` beim Start des `App()`-Konstruktors fixiert |
| 2 | `Game.cs` | SSL/TLS-Fehler bei `UpdateVersions()` — sicherer SSL/TLS-Kanal konnte nicht erstellt werden | TLS 1.2 explizit über `ServicePointManager.SecurityProtocol` gesetzt |
| 3 | `MainWindow.xaml.cs` | `GamePathNotSet`-Popup bei Green Hell, obwohl der Pfad konfiguriert war | `App.Game.GamePath` leer → gespeicherter Pfad wird aus `Configuration` gelesen |
| 4 | `ModsViewModel.cs` | Mod-Dateien, die manuell in `mods\TheForest\` abgelegt wurden, erschienen nicht in der Liste | Diagnoseprotokoll zur Validierung des Dateinamensmusters hinzugefügt |
| 5 | `MainWindow.xaml.cs` | `MixedGameMods`-Popup blockierte die Auswahl von Mods mehrerer Spiele | Blockierendes Popup entfernt — ersetzt durch `SelectGameDialog` |

---

### Neue Funktionen

#### Spielstart — Spielauswahl-Popup (`SelectGameDialog`)

Wenn Mods aus unterschiedlichen Spielen ausgewählt sind oder der **All**-Filter aktiv ist, erscheint statt einer Blockierung des Starts ein Spielauswahl-Popup.

**Auslösebedingungen:**
- `All`-Filter ausgewählt + Start Game geklickt
- Mods aus 2 oder mehr verschiedenen Spielen gleichzeitig aktiviert

**Verhalten:**
- Zeigt nur Spiele mit konfigurierten Pfaden und vorhandener ausführbarer Datei
- Es werden nur die Mods des ausgewählten Spiels angewendet — Mods anderer Spiele werden vollständig ignoriert
- Optionsfeld synchronisiert sich nach Schließen des Popups mit dem ausgewählten Spiel (`SyncModGameFilterRadioButton`)

**Neue Dateien**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Spielintegritätsprüfung (nur Release-Build, `#if !DEBUG`)

Vor jedem Spielstart wird eine dreistufige Integritätsprüfung durchgeführt:

| Ebene | Methode | Bei Fehlschlag |
|---|---|---|
| A — PE-Header | `FileValidator.IsValidGameExe()` | Blockiert + `GameExeCorrupted`-Popup |
| B — Assembly-Prüfsumme | MD5 → Vergleich mit `Versions.xml` | Blockiert + `GameAssemblyTampered`-Popup |
| C — Digitale Signatur | `HasDigitalSignature()` | Warnung + Benutzerentscheidung (`GameIntegrityWarning`) |

**Neue Dateien**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Neue Methoden in `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — MD5-Hash von Assembly-CSharp.dll (+ firstpass, falls vorhanden)
- `HasDigitalSignature(path)` — Prüfung der Authenticode-Signatur

---

### Neue Diagnoseprotokolle

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 Einträge, Release + Debug)

| # | Phase | Typ | Inhalt |
|---|---|---|---|
| 1 | TLS-Einstellung | Notice | Protokoll vorher/nachher |
| 2 | Download-Start | Notice | Serverliste |
| 3 | URL-Versuch | Notice | Jede versuchte URL |
| 4 | Download erfolgreich | Notice | URL, Antwortlänge, verwendetes Protokoll |
| 5 | WebException | Error | URL, HTTP-Status, Protokoll, Detail |
| 6 | Sonstige Ausnahme | Error | URL, Ausnahmetyp, Detail |
| 7 | Download abgeschlossen | Notice | Erfolgsanzahl / Gesamtzahl der Server |
| 8 | Parsing erfolgreich | Notice | Anzahl Dateien und Versionen vorher/nachher |
| 9 | Parsing fehlgeschlagen | Error | Ausnahmetyp und Detail |
| 10 | Speichern erfolgreich | Notice | Speicherpfad, Gesamtanzahl Versionen/Dateien |
| 11 | Speichern fehlgeschlagen | Error | Pfad, Ausnahmetyp, Detail |
| 12 | Keine Antwort | Error | Versuchte Server, Protokoll |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 Einträge, nur `#if DEBUG`)

| # | Situation | Typ | Inhalt |
|---|---|---|---|
| 1 | Scan-Start | Notice | Mods-Ordnerpfad, Gesamtzahl gefundener Dateien |
| 2 | Bereits geladen | Notice | Dateiname |
| 3 | Keine .mod-Datei | Notice | Dateiname |
| 4 | Mustervergleich erfolgreich | Notice | In die Warteschlange eingereihter Dateiname |
| 5 | Mustervergleich fehlgeschlagen | Warning | Dateiname + Grund + erwartetes Format |
| 6 | Scan abgeschlossen | Notice | Anzahl in Warteschlange / Gesamtzahl Dateien |
| 7 | Ausnahme | Error | Ausnahmedetail |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 Einträge, Release + Debug)

| # | Situation | Typ | Inhalt |
|---|---|---|---|
| 1 | Popup-Bedingung | Notice | Aktueller Filter, ausgewählte Spiel-IDs, needGameSelect |
| 2 | Kandidatenspiele | Notice | Liste der Popup-Kandidaten-IDs |
| 3 | Pfad nicht gesetzt | Notice | Spiel übersprungen — Pfad nicht konfiguriert |
| 4 | Nicht in Configuration | Notice | Spiel übersprungen — nicht in Configuration.Games |
| 5 | Installation bestätigt | Notice | Spiel + Pfad der ausführbaren Datei |
| 6 | Exe nicht gefunden | Warning | Spiel übersprungen — ausführbare Datei fehlt |
| 7 | Keine installierten Spiele | Error | 0 Kandidaten → GamePathNotSet |
| 8 | Automatisch ausgewählt | Notice | Einzelner Kandidat automatisch ausgewählt |
| 9 | Vom Benutzer abgebrochen | Notice | SelectGameDialog abgebrochen |
| 10 | Spiel ausgewählt + Mods | Notice | Ausgewähltes Spiel, gesammelte Mod-Anzahl/Liste |

---

### Trennung von Entwickler-/Benutzerprotokollen (`#if DEBUG`)

| Datei | Protokoll | Grund |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Wiederholt sich jede Sekunde — 81 % des gesamten Protokollumfangs |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Interne Details nur für Entwickler |

Im Release-Protokoll verbleiben: Download-Erfolg/-Fehlschlag, Parsing-/Speicherergebnisse, fehlgeschlagene Mustervergleiche, Ausnahmen, Ergebnisse der Integritätsprüfung.

---

### Aktualisierung der Versionstabelle — Architektur

#### Designabsicht

```
Spiel erhält Steam-Update
  → Assembly-CSharp.dll ändert sich
  → ModAPI prüft Versions.xml auf bekannte Prüfsumme
  → Falls nicht gefunden → neueste Versions.xml wird vom Server heruntergeladen
  → Neue Version wird ohne ModAPI-Neuinstallation automatisch registriert
```

#### Verbindungsstruktur

```
Settings-Tab → KeepVersionsData-Checkbox
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → UpdateVersions() aufgerufen
      → Lädt Versions.xml von VersionUpdateDomains[] herunter
      → Überschreibt lokale configs\games\{GameId}\Versions.xml
```

#### GitHub-Raw-URL-Integration

Statt sich ausschließlich auf `modapi.survivetheforest.net` zu verlassen, wird nun die GitHub-Raw-URL als primäre Quelle für die direkte Verwaltung genutzt:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — direkt verwaltet, Priorität 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Legacy-Server — Fallback, Priorität 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Punkt | Detail |
|---|---|
| Primär | GitHub-Raw-URL — bei Push sofort aktualisiert |
| Fallback | Legacy-Server — verwendet, wenn GitHub nicht verfügbar ist |
| Pfad | `ModAPI/configs/games/{GameId}/Versions.xml` im Repository |
| Geänderte Datei | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Versions.xml-Aktualisierungen

| Spiel | Datei | Änderung |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Prüfsumme korrigiert (war fehlerhaft in SHA-256-Großschreibung) — `2.9.5b114117` mit korrekter MD5 |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID: 20229486) hinzugefügt — 128-stellige MD5-Prüfsumme |

---

### Neue Sprachschlüssel (13 Sprachen)

| Schlüssel | Englischer Wert |
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
| `Lang.Savegames.*` (133 Schlüssel) | Englische Werte zu 12 Sprachen hinzugefügt (DE bereits übersetzt) |

---

### Geänderte Dateien

| Datei | Pfad | Änderung |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` beim Start fixiert |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, Integritätsprüfung, MixedGameMods entfernt, Radio-Sync, 10 Protokolle |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Neu |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Neu |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Diagnoseprotokoll für Dateinamen, #if-DEBUG-Trennung |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 UpdateVersions-Protokolle, GitHub-URL, #if-DEBUG-Trennung |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 neue Schlüssel + 133 Savegames-Schlüssel (515 insgesamt, alle Sprachen abgeglichen) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Prüfsumme korrigiert |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12` hinzugefügt |
| `LangTool\` (13 Dateien) | Solution-Stammverzeichnis | Neu |
| `ModAPI.sln` | Solution-Stammverzeichnis | LangTool registriert |

---

### Zusätzliche Korrekturen & Überarbeitung des Protokollsystems (2026-06-21)

#### StartGame-Validierung — Vollständige Neugestaltung

Die Validierungsreihenfolge wurde auf eine strenge 3-Schritt-Sequenz korrigiert, und das Spielauswahl-Popup berücksichtigt nun aktivierte Mods unabhängig davon, ob der Spielpfad konfiguriert ist.

| Schritt | Prüfung | Popup bei Fehler |
|---|---|---|
| 1 | Steam installiert | SteamNotFound |
| 2 | Pfad des ausgewählten Spiels konfiguriert + ausführbare Datei vorhanden | GamePathNotSet |
| 3 | Mindestens ein Mod für das ausgewählte Spiel aktiviert | NoModSelected |

- **All-Filter / mehrere Spiel-Mods ausgewählt** → Popup listet immer alle Spiele mit einem aktivierten Mod auf, **auch solche ohne konfigurierten Pfad** — die Auswahl eines nicht konfigurierten Spiels zeigt nun korrekt `GamePathNotSet`, statt es stillschweigend auszuschließen oder einen falschen Fehler anzuzeigen
- **Filter für ein einzelnes Spiel** → Pfad- und Mod-Prüfungen laufen direkt für dieses Spiel in derselben Reihenfolge 1→2→3

#### Kritische Fehlerbehebungen

| # | Datei | Problem | Behebung |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` führte Antworten **aller** erfolgreichen Server (GitHub + Legacy) zusammen, wodurch Prüfsummen bei Erfolg beider Server verdoppelt wurden (64 → 128 Zeichen) — verursachte fälschliche `GameAssemblyTampered`-Blockaden | Es wird nur die Antwort des zuerst erfolgreichen Servers geparst; weitere Server werden übersprungen, sobald einer erfolgreich war |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` verwendete `App.Game` (aktuell aktiver Filter) statt des eigenen Spiels des Mods — beim Löschen eines Green-Hell-Mods während The Forest aktiv war, wurde der falsche `Managed`-Ordner durchsucht und die Löschung stillschweigend übersprungen | Löst den bereitgestellten DLL-Pfad nun aus `mod.Game` (der tatsächlichen Spielinstanz des Mods) auf, mit Fallback auf `Configuration`, falls `GamePath` leer ist |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Erneutes Herunterladen eines zuvor gelöschten Mods stellte dessen Aktivierungsabzeichen als angehakt wieder her — beim Löschen eines Mods wurden dessen dauerhaft gespeicherte `Selected`/`Version`-Schlüssel oder der ViewModel-Cache im Speicher nie geleert | `RemoveKey()` / `RemoveKeysWithPrefix()` zu `Configuration.cs` hinzugefügt; `DeleteMod_Click` setzt beim Löschen nun zwangsweise `ModViewModel.Selected = false` zurück und entfernt alle `Mods.{GameId}.{ModId}.*`-Schlüssel |
| 4 | `ModsViewModel.cs` | Das Löschen eines Mods bei aktivem spezifischem Spielfilter (nicht „All") ließ den Mod bis zum Wechsel zu „All" und zurück sichtbar in der Liste | Die `FilteredMods`-Änderungsbenachrichtigung fehlte nach `_Mods.RemoveAt()` in der Polling-Schleife zur Dateilöschung; wird nun bei jeder tatsächlichen Entfernung eines Mods ausgelöst |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Eine unbehandelte Ausnahme beim Erstellen oder Anzeigen des Popups für die fehlende Signatur konnte ModAPI stillschweigend zum Absturz bringen, ohne dass ein Fehler protokolliert wurde | Popup-Erstellung/-Anzeige und Nachrichtenformatierung in try-catch eingebettet; bei Fehlschlag wird die Warnung protokolliert und dem Benutzer wird sicher gestattet fortzufahren (eine fehlende Signatur ist ein Hinweis, kein hartes Hindernis) |

#### Warnung zur digitalen Signatur — Meldung präzisiert

Der `GameNoSignature`-Text nennt nun das jeweilige Spiel und stellt klar, dass eine fehlende Signatur bei Indie-Titeln zu erwarten ist und das Spielerlebnis nicht beeinträchtigt, statt eine mögliche Manipulation zu suggerieren. In allen 13 Sprachdateien mit einem `{0}`-Platzhalter für den Anzeigenamen des Spiels aktualisiert (z. B. „The Forest", „Green Hell").

#### Protokollsystem — Trennung in zwei Dateien

Die an `#if DEBUG` gebundenen Diagnoseprotokolle wurden auf ein `detailedOnly`-Flag umgestellt und in `ModAPI.log` (für den Benutzer) und `ModAPI.detailed.log` (immer vollständig) aufgeteilt — vollständige Aufschlüsselung siehe Abschnitt **Log** oben.

#### Geänderte Dateien (zusätzlich)

| Datei | Pfad | Änderung |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Neugestaltung der StartGame-Validierung, Korrektur der Spielinstanz in DeleteMod_Click, try-catch für GameIntegrityWarning, Zuordnung der Anzeigenamen |
| `Game.cs` | `ModAPI_Shared\Data\` | Korrektur der Einzelantwort bei UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | `FilteredMods`-Änderungsbenachrichtigung beim Löschen, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 Aufrufstellen) |
| `Mod.cs` | `ModAPI\Data\` | Header-XML-Dump nach `detailedOnly` verschoben, Zusammenfassung bei Prüfsummen-Abweichungen |
| `Debug.cs` | `ModAPI_Shared\` | `detailedOnly`-Parameter, Zwei-Dateien-Schreiber, Kommentar mit 4-Stufen-Protokollierungsleitfaden |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | `{0}`-Platzhalter für Spielname, try-catch-Absicherung |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` mit Spielname-Platzhalter neu geschrieben |

---


</details>

<details>
<summary><b>Änderungen in v2.0.9619</b></summary>

### Fehlerbehebungen

- **Mod-Anwendung blieb bei leerem Backup-Ordner hängen**: `gamefiles\original\` leer → automatische Backup-Erstellung aus dem Spielinstallationspfad vor dem Lesen der Assembly
- **Dateisperre (IOException) bei Spiel-DLLs**: Der Assembly-Resolver schließt den Spielordner bedingt aus, wenn ein Backup existiert — verhindert, dass Cecil während `DirectoryCopy` Dateisperren hält
- **Endlosschleife bei erneutem Versuch für beschädigte Mods**: Fehlgeschlagene `.mod`-Dateien (beschädigter Header) verursachten eine 1-Sekunden-Neuscan-Schleife — werden nun in `LoadedFiles` registriert, um erneutes Scannen zu verhindern
- **Mod-Dateien mit LF-Zeilenumbrüchen abgelehnt**: Header-Parser `EndsWith("</Mod>\r")` scheiterte bei `.mod`-Dateien im Unix-Stil — verwendet nun `TrimEnd`, um sowohl CRLF als auch LF zu verarbeiten
- **Validierungsfehler bei kleinen DLLs**: `Assembly-UnityScript-firstpass.dll` (21 KB) wurde von `FileValidator` abgelehnt — Mindestgröße für Assemblies von 64 KB auf 8 KB gesenkt
- **Unnötige WARNING-Protokolle**: Nicht konfigurierte Spielpfade und Konfigurationsschlüssel beim Ersteinrichten erzeugten Rauschen — `silent`-Parameter zu `GetPath`/`GetString`/`GetInt` hinzugefügt

### Verbesserungen

- **Erkennung von 0-Byte-Downloads**: Popup-Warnung + Bereinigung temporärer Dateien, wenn der Server eine leere `.mod`-Datei zurückgibt (`Lang.Windows.DownloadEmpty`)
- **Debounce beim Slider-Speichern**: `ModListWidth` / `ProjectListWidth` wird nur noch einmal (500 ms nach Ende des Ziehens) statt bei jeder Pixeländerung in `ui.cfg` gespeichert
- **Bedingte Erstellung von Spielordnern**: `mods/`- und `projects/`-Ordner werden nur für Spiele mit konfigurierten Pfaden erstellt — nicht mehr bedingungslos für alle 5
- **Diagnoseprotokoll beim Header-Parsing**: Zeigt bei einem Parsing-Fehler einer `.mod`-Datei Zeilenanzahl und Inhaltsvorschau zur Fehlersuche an

### Neue Sprachschlüssel (13 Sprachen)

| Schlüssel | Englischer Wert |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Geänderte Dateien

| Datei | Pfad | Änderung |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Automatische Backup-Erstellung, bedingter Resolver, Fallback auf Spielordner |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Fallback auf Spielordner für IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `silent`-Parameter bei GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Schutz vor 0-Byte-Downloads, Slider-Debounce, stilles Konfigurationslesen, bedingte Ordnererstellung |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Schutz vor erneutem Versuch bei beschädigten Mods |
| `Mod.cs` | `ModAPI\Data\` | LF/CRLF-Header-Parsing, Diagnoseprotokoll |
| 13× `Language.XX.xaml` | `resources\langs\` | `DownloadEmpty`-Popup-Schlüssel |

---

</details>

<details>
<summary><b>Änderungen in v2.0.9618</b></summary>


### MODAPI_VersionTool hinzugefügt

Ein eigenständiges WPF-Tool zur Aktualisierung der Versionsnummer mit einem Klick wurde hinzugefügt (`VersionTool\MODAPI_VersionTool.csproj`) — vollständige Details siehe Abschnitt **Version Tool** oben.

- `VersionLabel.Text` verweist nun auf `App.Version` statt auf den fest codierten `Version.Descriptor`, sodass Aktualisierungen nach einem Rebuild sofort in der StatusBar sichtbar sind.

---

</details>

<details>
<summary><b>Änderungen in v2.0.9617</b></summary>


### Settings-Tab — Reset-Buttons für Pfade hinzugefügt

Ein **Reset**-Button wurde zur Steam-Installationspfad-Zeile sowie zu jeder Spielinstallationspfad-Zeile hinzugefügt.

**Steam-Pfad-Zeile**
```
[TextBox] [Browse] [Save] [Reset]
```

**Spielpfad-Zeile (je Spiel)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Reset-Verhalten**
- Leert das Pfad-Textfeld sofort
- Speichert ein Reset-Flag in `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Textfeld bleibt nach dem Neustart leer
- Umgeht das Problem, dass Configuration-XML keine leeren Zeichenketten speichert

**Automatisches Speichern bei Browse**
- Vorher: Nach Browse war ein separater Klick auf Save erforderlich
- Nachher: Automatisches Speichern bei Dateiauswahl — bleibt auch nach Wechsel zum Mods-Tab erhalten

**Neuer Sprachschlüssel**

| Schlüssel | Wert |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Änderungen in v2.0.9616</b></summary>

### Versions.xml — 4 Spiele hinzugefügt/aktualisiert

| Spiel | Dateipfad | BuildID | Anmerkungen |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Neu erstellt |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Prüfsumme aktualisiert |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Neu erstellt |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Prüfsumme aktualisiert |

### Regeln zur Zusammensetzung der Prüfsumme

Das Prüfsummenformat unterscheidet sich je nachdem, ob `Assembly-CSharp-firstpass.dll` für das jeweilige Spiel existiert.

| Spiel | firstpass.dll | Prüfsummenformat |
|---|---|---|
| GH | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| Subnautica | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| EscapeThePacific | ✅ Vorhanden | `firstpass MD5` + `Assembly-CSharp MD5` verkettet (64 Zeichen) |
| Raft | ❌ Nicht vorhanden | nur `Assembly-CSharp MD5` (32 Zeichen) |

### Ablauf zur Aktualisierung von Versions.xml bei Spielupdates

Fügen Sie einen neuen `<version>`-Eintrag hinzu, ohne bestehende Einträge zu entfernen.

**Schritt 1 — Neue BuildID finden**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Spiel | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Schritt 2 — Neue Prüfsumme extrahieren**
```powershell
# Spiele mit firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Beide Hash-Werte in Reihenfolge verketten (firstpass zuerst)

# Spiele ohne firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Schritt 3 — Eintrag zu Versions.xml hinzufügen**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Änderungen in v2.0.9615</b></summary>

### Erweiterung des Spielpfads im Settings-Tab korrigiert

- **Erweiterungshöhe der Karte**: Der untere Rand des Fensters wächst beim Erweitern einer Spielpfadkarte nun exakt um die Höhe des Eingabefelds
- **Verbesserung von `UpdateWindowHeight()`**: Ruft `UpdateLayout()` vor der Messung von `SizeToContent.Height` auf; setzt `TextureLayer1` bei aktiver Hintergrundtextur vorübergehend auf `Collapsed`, um zu verhindern, dass die Originalgröße eines 4K-Bilds die Höhenberechnung beeinflusst
- **Korrektur der inneren Grid-Zeile**: Die letzte Zeile des inneren Grids des Spielpfad-Panels wurde von `Height="*"` auf `Height="Auto"` geändert — entfernt unnötigen Leerraum am unteren Rand

---

</details>

<details>
<summary><b>Änderungen in v2.0.9614</b></summary>

### Verhalten der Maximieren-Schaltfläche korrigiert

- **Maximieren**: Verwendet `SystemParameters.WorkArea` für manuelles Maximieren statt `WindowState.Maximized` — passt sich exakt an die aktuelle Bildschirmauflösung an, ohne die Taskleiste zu überlappen
- **Wiederherstellen**: Speichert `Left`, `Top`, `Width`, `Height` und `MaxWidth` vor dem Maximieren und stellt sie beim Klick auf die Wiederherstellen-Schaltfläche wieder her
- **Verarbeitung von `MaxWidth`**: Beim Maximieren auf `∞` gesetzt, beim Normalisieren auf den gespeicherten Wert zurückgesetzt

---

</details>

<details>
<summary><b>Änderungen in v2.0.9613</b></summary>

### Neuer Themes-Tab

Die Tab-Reihenfolge lautet nun:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Die Themenauswahl-UI wurde aus dem Settings-Tab in einen eigenen **Themes-Tab** verschoben.
Symbol: Segoe MDL2 Assets `&#xE790;` (Palette)

### Theme-Registry (datengesteuerte Struktur)

Ein neues Theme hinzuzufügen erfordert nun nur noch **eine Zeile** im `App.xaml.cs`-Dictionary.
Alle switch-Anweisungen wurden entfernt — an anderer Stelle sind keine Codeänderungen erforderlich.

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

`ThemeSelector`-ComboBox-Einträge werden automatisch aus der `ThemeIds`-Schleife erzeugt.
Konvention für Sprachschlüssel: `Lang.Options.Theme.{PascalCase}` (z. B. `Lang.Options.Theme.Nebula`)

### Unterstützte Themes

| Index | ID | Datei | Farbpalette |
|---|---|---|---|
| 0 | `classic` | nur `Dictionary.xaml` | Original-ModAPI-Texturhintergrund |
| 1 | `light` | `FluentStylesLight.xaml` | Heller Ton + blauer Akzent |
| 2 | `dark` | `FluentStyles.xaml` | Dunkler Ton + blauer Akzent (Standard) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rot + Schwarz |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Dunkler Weltraum |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Heller Sonnenuntergang |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Dunkler Ozean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Heller nordischer Stil |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Helles Zitrus |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Helle Blüte |

Ein Themenwechsel löst einen automatischen App-Neustart aus. (gespeichert in `theme.cfg`)

### Funktion der Hintergrundtextur

Wählen Sie im Themes-Tab in der Karte **Background Texture** ein Bild aus, um es als appweiten Hintergrund anzuwenden. Funktioniert mit jedem ausgewählten Theme.

**Unterstützte Eingabeformate**: `.png` / `.jpg` / `.jpeg`, bis zu 50 MB, 4K-Auflösung oder darunter

**Bildverarbeitungspipeline**

```
Vom Benutzer ausgewähltes Bild (.png / .jpg / .jpeg, max. 50 MB, 4K oder darunter)
  ↓
JPEG-Q75-Komprimierung (Speicherpuffer)
  ↓
16-Byte-Magic-Header eingefügt
  "MODAPI" + "BG" + Version + Padding (FF 00 FE 00)
  ↓
Gespeichert als resources\textures\ui_bg\bg.dat (Hidden-Attribut)
  ↓
SHA-256-Hash → in ui.cfg als TextureHash gespeichert
```

**Sicherheitsebenen**

| Ebene | Methode | Effekt |
|---|---|---|
| Magic-Header | 16 Bytes vor der JPEG-Signatur (FF D8 FF) vorangestellt | Externe Betrachter können die Datei nicht erkennen |
| Hidden-Attribut | `FileAttributes.Hidden` | im Explorer standardmäßig ausgeblendet |
| SHA-256-Integrität | Hash wird beim Laden überprüft | Manipulation löst automatisches Zurücksetzen + Warn-Popup aus |

**Verhalten bei Manipulationserkennung**
1. `bg.dat` gelöscht
2. `ui.cfg`-Schlüssel `TexturePath`, `TextureHash`, `TextureActive` zurückgesetzt
3. Textfeld und Schalter zurückgesetzt
4. `Lang.Windows.TextureTampered`-Popup angezeigt

**ui.cfg-Schlüssel**

| Schlüssel | Wert | Beschreibung |
|---|---|---|
| `TexturePath` | Dateiname (nur Anzeige) | im Textfeld angezeigter Originaldateiname |
| `TextureHash` | SHA-256-Hex | Integritätsprüfungs-Hash |
| `TextureActive` | `true` / `false` | Aktivierungsstatus |

**Transparenzverarbeitung**

Wenn das Hintergrundbild aktiv ist, werden UI-Hintergründe in zwei Schichten verarbeitet.

- **Schicht 1 — MergedDictionaries-Overlay**: Panels, die `{DynamicResource FluentBgBrush}` usw. referenzieren, werden automatisch transparent gemacht. Bei Deaktivierung mit einem einzigen `Remove()`-Aufruf wiederhergestellt.

  Zielschlüssel: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Schicht 2 — Durchlauf des visuellen Baums (`WalkStyleBackgrounds`)**: `{StaticResource}`-Elemente in Fluent-Themes sind von Schicht 1 nicht betroffen, daher wird der visuelle Baum direkt durchlaufen, um halbtransparente Pinsel basierend auf den Originalfarben anzuwenden.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=vollständig transparent, 255=undurchsichtig → 100 ≈ 39 % undurchsichtig
  ```

  Verarbeitet: `Panel` (außer Grid), `Border`, `ListBox` / `ListView`

  Ausgeschlossen: `Grid` (Hintergrund bleibt erhalten, Kinder werden durchlaufen), `TabPanel` (Schutz des Tab-Headers), `ButtonBase` / `ComboBox`, `Collapsed`-Elemente

  Wiederherstellung: Style-Setter-Quelle → `ClearValue()`, XAML-Lokalwertquelle → ursprünglicher Pinsel wird direkt wiederhergestellt

**Tab-Wechsel**

Da WPFs TabControl den Tab-Inhalt lazy lädt, wird `WalkStyleBackgrounds(this)` beim Tab-Wechsel mit `ContextIdle`-Priorität erneut ausgeführt. Bereits verarbeitete Elemente werden per `ContainsKey`-Prüfung übersprungen.

**ThemeSelector-Sperre**

Bei aktiver Hintergrundtextur wird ein `ThemeSelectorOverlay`-Rahmen über der Themenauswahl angezeigt, um Interaktionen zu blockieren.

- XAML: `ThemeSelectorOverlay`-Rahmen über ThemeSelector hinzugefügt (`IsHitTestVisible=True`)
- Aktiv: `ThemeSelectorOverlay.Visibility = Visible`
- Inaktiv: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` wird ebenfalls durch das `_textureActive`-Flag geschützt

**UI-Zustandsablauf**

```
Bild ausgewählt (Browse)
  → bg.dat erstellt → Schalter entsperrt → automatisch aktiviert → TextureLayer1 angezeigt
  → SaveAndClearBrushes() → ThemeSelectorOverlay angezeigt

Schalter deaktiviert
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay ausgeblendet
  → TextureLayer1 ausgeblendet

Clear-Button
  → bg.dat gelöscht → Schalter gesperrt → TextureLayer1 ausgeblendet → Pinsel wiederhergestellt
  → GC.Collect() (gibt 4K-Bildspeicher frei)
```

**Neue Sprachschlüssel**

| Schlüssel | Beschreibung |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 neue Themennamen |
| `Lang.Options.Labels.TextureBackground` | Beschriftung für Hintergrundtextur |
| `Lang.Options.Labels.TextureEnable` | Beschriftung für Aktivieren |
| `Lang.Options.Labels.TextureClear` | Clear-Button |
| `Lang.Windows.TextureTooLarge` | Warnung bei überschrittener Dateigröße |
| `Lang.Windows.TextureTampered` | Warnung bei erkannter Manipulation |

**Dateistruktur**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Themes-Tab, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Theme- & Texturlogik
├── Themes\
│   ├── Dictionary.xaml            # Classic-Theme
│   ├── FluentStyles.xaml          # Dark-Theme
│   ├── FluentStylesLight.xaml     # Light-Theme
│   ├── FluentStylesDiablo.xaml    # Diablo-Theme
│   ├── FluentStylesNebula.xaml    # Nebula-Theme
│   ├── FluentStylesSunset.xaml    # Sunset-Theme
│   ├── FluentStylesOcean.xaml     # Ocean-Theme
│   ├── FluentStylesNordic.xaml    # Nordic-Theme
│   ├── FluentStylesCitrus.xaml    # Citrus-Theme
│   └── FluentStylesBloom.xaml     # Bloom-Theme
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Komprimiertes & gesichertes Hintergrundbild (zur Laufzeit erzeugt)
```

**Bekannte Designeinschränkungen**

| Punkt | Details |
|---|---|
| `IsEnabled=false` bei ComboBox | Verursacht `ElementNotEnabledException`-Absturz → `IsHitTestVisible`-Overlay-Ansatz verwendet |
| Direktes Ersetzen von `MergedDictionaries`-Schlüsseln | Absturz während des Layout-Durchlaufs → nur `Add`/`Remove`-Muster |
| Überschreiben einer versteckten Datei | `Access Denied` → vor dem Schreiben muss `FileAttributes.Normal` zurückgesetzt werden |
| `{StaticResource}`-Hintergründe | Nicht von Schicht 1 betroffen → WalkStyleBackgrounds (Schicht 2) erforderlich |

---

</details>

<details>
<summary><b>Änderungen in v2.0.9612</b></summary>

### Trennung der Theme-Module

- **Neuer Ordner `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` und `FluentStylesClassic.xaml` nach `ModAPI\Themes\` verschoben
- **`App.xaml.cs`**: `ApplyTheme()` — Classic-Theme verwendet nur `Dictionary.xaml`; Light/Dark/andere Fluent-Themes laden die entsprechende XAML
- **`ModAPI.csproj`**: Theme-XAML-Pfade auf das Unterverzeichnis `Themes\` aktualisiert; `FluentStylesClassic.xaml` registriert

---

</details>

<details>
<summary><b>Änderungen in v2.0.9611</b></summary>

### Fehlerbehebung

- **Mod-List-Breite nach Themenwechsel nicht angewendet**: Problem behoben, bei dem die Mod-List-Breite nach dem Wechsel zwischen Light-/Dark-Theme und Neustart nicht angewendet wurde — `ApplyModListWidth(width)`-Aufruf innerhalb von `InitModListWidth()` hinzugefügt

---

</details>

<details>
<summary><b>Änderungen in v2.0.9610</b></summary>

### Hinzugefügt

#### Spiel-XML & Versions-Konfiguration

| # | Datei | Änderung |
|---|------|--------|
| 1 | `GH.xml` | Vollständig neu geschrieben — nicht vorhandene `DOTweenPro.dll` entfernt; `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` hinzugefügt |
| 2 | `Subnautica.xml` | Vollständig neu geschrieben — `extends="GenericUnityGame"` entfernt; `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` hinzugefügt |
| 3 | `EscapeThePacific.xml` | Vollständig neu geschrieben — `extends="GenericUnityGame"` entfernt; `includeAssembly` → nur `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Erstellt — Version `1.1.01` mit Prüfsumme |
| 5 | `GH/Versions.xml` | Erstellt — Version `2.9.5` mit Prüfsumme |
| 6 | `Subnautica/Versions.xml` | Erstellt — ohne Prüfsumme (aktualisiert sich zu häufig) |

#### Kritische Fehlerbehebungen

| # | Typ | Problem | Behebung |
|---|------|-------|-----|
| 1 | Hänger | `extends="GenericUnityGame"` verursachte Vererbung von `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` blieb hängen | `extends` aus allen Nicht-TheForest-XML-Dateien entfernt |
| 2 | Absturz | `ResolutionException: XGamingRuntime.XUserGamertagComponent` beim Anwenden von Subnautica | `XGamingRuntime.dll`, `XblPCSandbox.dll` zu `copyAssembly` hinzugefügt |
| 3 | Absturz | Resolver scheiterte bei DLLs, die nach der Backup-Erstellung zu `copyAssembly` hinzugefügt wurden | `Game.cs`: tatsächlicher Installationsordner als Resolver-Fallback hinzugefügt |
| 4 | Absturz | `IOException`: Dateisperre von `BaseModLib.dll` zwischen `CreateModLibrary` und `ApplyMods` | Wiederholungsschleife: max. 10 × 500 ms Lesen + max. 30 × 500 ms Warten auf Vorhandensein |
| 5 | Absturz | `NullReferenceException` — `typesMap`-Eintrag.Value null (Spiel nicht installiert) | `if (entry.Value == null) continue` hinzugefügt |
| 6 | Absturz | `NullReferenceException` — leichtgewichtiger `Game`-Konstruktor fehlt `ModLibrary = new ModLib(this)` → `CreateModLibrary()`-Absturz | `ModLibrary = new ModLib(this)` zum leichtgewichtigen Konstruktor hinzugefügt |
| 7 | Absturz | `SwitchDevGame()` — `App.Game.GamePath` nach leichtgewichtigem Konstruktor leer → `CreateModLibrary`-Absturz | `App.Game.GamePath = savedPath` nach leichtgewichtigem Konstruktor gesetzt |
| 8 | Falsches Spiel | `EscapeThePacific`-Mods als TheForest eingestuft | `ModsViewModel`: `GameId` aus Ordnerpfad extrahiert |
| 9 | Falscher Pfad | `GetGameFolder()` → `""` → wird als Laufwerksstammverzeichnis aufgelöst (z. B. `E:\`) | Null/Leer-Schutz an allen 6 Aufrufstellen |

#### Trennung von Debug-/Release-Builds

- **`FileValidator.cs`** — neue Datei `ModAPI_Shared\Utils\FileValidator.cs`; in `ModAPI_Shared.csproj` registriert
  - `IsValidSteamExe()` — PE-Header (MZ + PE\0\0) + Mindestgröße 1 MB
  - `IsValidGameExe()` — PE-Header + Mindestgröße 512 KB
  - `IsValidAssemblyDll()` — PE-Header + .NET-CLR-Metadaten-Header + Mindestgröße 64 KB
- **`CheckSteam()`** — `#if DEBUG`: nur `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: nur `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` ohne Cecil / `#else`: vollständiges Cecil-Parsing + IL-Änderung
- **`ModLib.Create()` Datei nicht gefunden** — `#if DEBUG`: Warnung protokollieren, überspringen / `#else`: Fehler protokollieren, abbrechen

#### Debug-Tests

- **`create_dummy_Debug_games.ps1`** — PowerShell-Skript für `bin\Debug\`; erstellt 0-Byte-Platzhalterdateien für alle 5 Spiele unter `dummy_games\`, `dummy_steam\` und `gamefiles\original\` — ermöglicht vollständigen UI-Workflow-Test ohne echte Spielinstallation

#### Settings-Tab

- **Steam-Pfad-Karte** — in die Karte Game Installation Paths integriert; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Spielpfad-Panel** — `BuildGamePathsPanel()` mit je Spiel erweiterbaren Karten; Textfeld verwendet `HorizontalAlignment=Stretch`
- **Expand All / Collapse All**-Button
- **AlwaysOnTop**-Checkbox (in `ui.cfg` gespeichert)
- **Mod/Project-List-Width**-Slider — starten bei Mindestwert `150`; in `ui.cfg` gespeichert
- **Font-Size**-ComboBox — FHD 10–16, 4K 10–22, 8K 10–28
- **Checkbox-Synchronisierung** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions synchronisieren nun korrekt
- **`_uiInitialized`-Flag** — verhindert vorzeitige `ui.cfg`-Schreibvorgänge während des WPF-Starts

#### Mods-Tab — Validierung beim Spielstart

Bei jedem Klick auf Start Game läuft unabhängig vom Zustand der Mod-Liste eine 5-stufige Validierung:

| Schritt | Prüfung | Popup |
|---|---|---|
| 1 | Steam-Pfad im Settings-Tab gültig (`Steam.exe` vorhanden) | SteamNotFound |
| 2 | Spiel im `mods/{GameId}/`-Ordner stimmt mit dem in Settings konfigurierten Spiel überein | GameModsMismatch |
| 3 | Mindestens ein Mod ausgewählt | NoModSelected |
| 4 | Keine gemischten Mods verschiedener Spiele in der Auswahl | MixedGameMods |
| 5 | Spielpfad konfiguriert + ausführbare Datei vorhanden | GamePathNotSet / GameNotInstalled |

#### Development-Tab — ModLib-Validierung

Dreistufige Validierung beim Klick auf Mod Library Regeneration:

| Schritt | Prüfung | Popup |
|---|---|---|
| 1 | Steam-Pfad im Settings-Tab gültig | SteamNotFound |
| 2 | Mindestens ein Projekt vorhanden | NoProjectWarning |
| 3 | `App.Game.GamePath` gesetzt | GamePathNotSet |

#### Downloads-Tab
- Debug-Zeichenkette durch `Lang.Downloads.Status.NoDownloads` ersetzt
- Einheitlicher Innenabstand für alle Statusmeldungen
- Offline-Anleitungstext für die 5 unterstützten Spiele aktualisiert; Zeilenumbruch über zwei TextBlocks

#### First Setup & Spielpfadsystem
- `FirstSetup.Check()` — Standardwert `true` für `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — erstellt `mods/`- und `projects/`-Ordner für alle 5 Spiele
- `SpecifyGamePath` — `GameNameLabel` zeigt an, um welches Spiel es sich handelt; `NavigateToSettings()` leitet zum Settings-Tab weiter

#### Neue/aktualisierte Sprachschlüssel

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

| Funktion | Grund |
|---|---|
| Automatisches Update (aktuelle Version beibehalten) | Server-seitige Infrastruktur nicht verfügbar |
| Update-Suche | Server-seitige Infrastruktur nicht verfügbar |

### Entfernt

| Punkt | Grund |
|---|---|
| `SpecifyGamePath`-Popup beim Start | Alle Pfade werden im Settings-Tab konfiguriert |
| `SpecifySteamPath`-Popup beim Start | Steam-Pfad wird im Settings-Tab konfiguriert |
| Login-System | Ursprünglicher Server nicht mehr in Betrieb (in v2.0.9400 entfernt) |
| `Portable.System.ValueTuple.dll` | Funktioniert nicht unter Mono 2.0 (in v2.0.9586 entfernt) |
| `UseSteam`-Bedingung bei der Steam-Prüfung | Steam wird nun bei Start Game und Mod Library Regeneration stets zuerst überprüft |

## Geplant für zukünftige Versionen

| # | Funktion | Beschreibung |
|---|---|---|
| 1 | ModAPI-Auto-Update | Neue ModAPI-Releases automatisch herunterladen und anwenden |
| 2 | Aktualisierung der ModAPI-VersionsData-Tabelle | Automatische Aktualisierung der VersionsData-Tabelle des Spiels bei neuen Spiel-Patches |

---

</details>

<details>
<summary><b>Änderungen in v2.0.9600</b></summary>

### Hinzugefügt

- **Downloads-Tab**: 5 Spielfilter (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome-Tab**: an äußerster linker Position hinzugefügt (Index 0)
- **Mods-Tab**: 3-Spalten-Layout (WrapPanel → vertikale Liste); automatische Breitenanpassung; Umbruch von Mod-Namen
- **`ModsViewModel`**: spielspezifische Filterung, `ResolveGame()` für die korrekte `Game`-Instanz pro Mod
- **`Game.cs`**: leichtgewichtiger Konstruktor `new Game(config, true)` — nur zur Identifikation, ohne `Verify()`
- **Build**: 4 Spiel-XML-Dateien mit `CopyToOutputDirectory=Always` in `ModAPI.csproj` registriert
- **Build**: Warnungen bereinigt — CS0168, CS0618, CS0252
- **Spiel-XML**: DLL-Listen für TheForest, Raft, GH korrigiert
- **Sprachflaggen**: Bildgrößen bei allen 13 Sprachbadges vereinheitlicht

### Entfernt

| Punkt | Grund |
|---|---|
| `extends="GenericUnityGame"` in Spiel-XML-Dateien | Führte zu fehlerhafter Vererbung von `Assembly-CSharp-firstpass.dll` — aus Subnautica, Raft, EscapeThePacific, GH entfernt |
| `WrapPanel`-Layout im Mods-Tab | Durch 3-Spalten-Grid-Layout ersetzt (Game Filter / Mod List / Information) |

---

</details>

---

## Versionshistorie

<details>
<summary><b>Phase 6-3 — Erweiterung des Themensystems, Verbesserungen der Einstellungen, Stabilität & Tools</b></summary>

### v2.0.9621 — 2026-07-28

- Steam-Bibliotheks-weite automatische Erkennung für alle 5 Spiele, gesteuert durch die Checkbox Steam-Verbindung
- Automatische Erkennung und Ausschluss von Mods, die für ein anderes Spiel gebaut wurden (Liste + zur Apply-Zeit), mit ⚠-Badge im Mods-Tab
- Kombiniertes Ergebnis-Popup für ausgeschlossene Mods / keine angewendeten Mods statt gestapelter Popups; Spiel startet nicht mehr bei null angewendeten Mods
- Globale Protokollierung nicht abgefangener Ausnahmen (UI-Thread + Hintergrund-Threads)
- `ModAPI.dev.log` ersetzt `ModAPI.detailed.log`; neue Schalter im Einstellungen-Tab für Entwicklerprotokoll und Protokolle beim Start leeren
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` sind bei Neuinstallation jetzt standardmäßig deaktiviert
- Behoben: Leer-Pfad-Fehler in `Configuration.GetPath()`, uneinheitliche Start-Game-Validierungsreihenfolge, filterunabhängige Mod-Erfassung, spielübergreifende `Mod.Mods`-Schlüsselkollisionen und der daraus resultierende `UpdateMods()`-Absturz, doppelte Green-Hell-Prüfsumme (`_Data`/`_data`), `BaseModLib.dll`-Dateisperren-Absturz, bedingungslose Erstellung der Ordner `mods\`/`projects\`, fehlgeschlagenes Speichern von `Versions.xml` bei fehlendem Ordner, keine Neuberechnung der Fensterhöhe bei Schriftgrößenänderung / Tab-Wechsel, unbegrenzte Fensterhöhe bei "Alle aufklappen"

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool & Kernkorrekturen**
- MODAPI_LangTool hinzugefügt (eigenständiges WPF-Sprachverwaltungstool)
- SSL/TLS-Korrektur (TLS 1.2)
- Korrektur der französischen Spracheinstellung (`CultureInfo.InvariantCulture`)
- Korrektur von `GamePathNotSet` bei Green Hell
- SelectGameDialog (All-Filter + Start mit gemischten Spiel-Mods)
- Blockierung durch MixedGameMods entfernt
- 3-stufige Spielintegritätsprüfung (PE-Header / Assembly-Prüfsumme / digitale Signatur)
- Trennung von Entwickler- und Benutzerprotokollen
- 12 UpdateVersions-Protokolle + 7 FindMods-Protokolle + 10 StartGame-Protokolle
- GitHub-Raw-URL als primäre `VersionUpdateDomains`
- Prüfsumme in GH-`Versions.xml` korrigiert
- `1.12` zu TheForest-`Versions.xml` hinzugefügt
- 515 Schlüssel über alle 13 Sprachdateien hinweg

**Zusätzliche Korrekturen (2026-06-21)**
- Reihenfolge der StartGame-Validierung korrigiert (Steam → Spielpfad → Mods)
- Spielauswahl-Popup listet nun Spiele mit nicht konfiguriertem Pfad korrekt auf
- Korrektur der Einzelantwort bei UpdateVersions (keine verdoppelten Prüfsummen mehr)
- `DeleteMod` löst nun die eigene Spielinstanz des Mods auf, statt den aktiven Filter zu verwenden
- Gelöschte Mods hinterlassen beim erneuten Herunterladen kein veraltetes „Selected"-Abzeichen mehr
- Mod-Liste wird nun bei jedem Filter unabhängig von der Spielfilterung sofort nach dem Löschen aktualisiert
- `GameIntegrityWarning`-Popup gegen Abstürze durch unbehandelte Ausnahmen abgesichert
- Warnmeldung zur digitalen Signatur nennt nun das Spiel und stellt klar, dass dies bei Indie-Titeln zu erwarten ist
- Zwei-Dateien-Protokollsystem (`ModAPI.log` / `ModAPI.detailed.log`) ersetzt die an `#if DEBUG` gebundenen Protokolle, sodass Release-Builds weiterhin vollständige Diagnosedetails erfassen können, ohne das benutzerseitige Protokoll zu überladen

### v2.0.9619 — 2026-05-25

- Automatische Backup-Erstellung aus dem Spielinstallationspfad
- Korrektur der Dateisperre (bedingter Resolver)
- Schutz vor Endlosschleife bei beschädigten Mods
- Kompatibilität mit Mod-Dateien mit LF-Zeilenumbrüchen
- Erkennung von 0-Byte-Downloads mit Popup
- Debounce beim Slider-Speichern (500 ms)
- Bedingte Erstellung von Spielordnern
- Mindestgröße für Assemblies in `FileValidator` von 64 KB auf 8 KB gesenkt
- `silent`-Parameter bei `GetPath`/`GetString`/`GetInt`
- Diagnoseprotokoll beim Header-Parsing
- `DownloadEmpty`-Sprachschlüssel (13 Sprachen)

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool hinzugefügt (eigenständiges WPF-Versionsupdate-Tool), StatusBar-Versionsanzeige mit App.Version verknüpft

### v2.0.9617 — 2026-04-24
Steam-/Spielpfad-Reset-Buttons im Settings-Tab hinzugefügt, automatisches Speichern bei Browse, Reset-Status über ui.cfg-Flag erhalten

### v2.0.9616 — 2026-04-18
Versions.xml für 4 Spiele erstellt/aktualisiert (Subnautica, Raft, EscapeThePacific, GH), Regeln zur Prüfsummenzusammensetzung festgelegt, Verfahren für Spielupdates dokumentiert

### v2.0.9615 — 2026-04-18
Genauigkeit der Erweiterungshöhe der Spielpfadkarte im Settings-Tab korrigiert, Beeinträchtigung von UpdateWindowHeight durch Hintergrundtextur verhindert

### v2.0.9614 — 2026-04-18
Manuelles Maximieren der Maximieren-Schaltfläche auf Basis von WorkArea, Speichern und Wiederherstellen von vorheriger Größe/Position

### v2.0.9613 — 2026-04-18
Themes-Tab hinzugefügt, datengesteuerte Struktur der Theme-Registry, 10 Themes unterstützt, Funktion für Hintergrundtextur (Komprimierung, Sicherheit, 2-Schicht-Transparenz), ThemeSelector-Sperrüberlagerung, 12 neue Sprachschlüssel

### v2.0.9612 — 2026-04-18
Trennung des Themes/-Ordners, Modularisierung der Theme-XAML

### v2.0.9611 — 2026-04-18
Korrektur: Mod-List-Breite nach Themenwechsel nicht angewendet

</details>

<details>
<summary><b>Phase 6-2 — Einstellungen, Sicherheit, Absturzkorrekturen & Debug-/Release-Trennung</b></summary>

### v2.0.9610 — 2026-04-13

- Multi-Game-XML korrigiert (GH, Subnautica, EscapeThePacific)
- `Versions.xml` hinzugefügt
- Settings-Tab neu gestaltet (Steam-Pfad, Spielpfad-Panel, Breiten-Slider, Schriftgröße, Checkbox-Synchronisierung)
- Null-Sicherheit für Spielpfad (6 Stellen)
- Start-Popups durch Settings-Tab ersetzt
- 5-stufige Start-Game-Validierung im Mods-Tab (Steam stets zuerst)
- 3-stufige ModLib-Validierung im Dev-Tab
- `GameModsMismatch`-Popup hinzugefügt
- Korrektur des `ModLibrary`-Null-Fehlers im leichtgewichtigen Konstruktor
- Korrektur von `GamePath` in `SwitchDevGame`
- `FileValidator`-PE-Header-Verifizierung (Release)
- `#if DEBUG`-Build-Trennung (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- Dauerhafte `ui.cfg`
- 5-stufiges Schriftgrößensystem
- Mehrere Absturzkorrekturen
- Sprachschlüssel aktualisiert

</details>

<details>
<summary><b>Phase 6-1 — Multi-Game & Neugestaltung von Mods</b></summary>

### v2.0.9600 — 2026-04-09
> 5 Spielfilter, 3-Spalten-Layout im Mods-Tab, automatische Breite, leichtgewichtiger `Game`-Konstruktor, Spielfilterung in `ModsViewModel`, 4 registrierte XML-Dateien, bereinigte Build-Warnungen, Welcome-Tab, standardisierte Sprachflaggen

</details>

<details>
<summary><b>Phase 5-6B — C# 7.3 & Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Schwarzer Bildschirm behoben, Polyfill finalisiert, ValueTuple entfernt, C# 7.3 verifiziert

</details>

<details>
<summary><b>Phase 5-5 — Assembly-Auflösung</b></summary>

### v2.0.9561 — 2026-03-06
> C#-7.3-Unterstützung, PE-Header-Patching, Polyfill-Pipeline, Assembly-Auflösung wiederhergestellt

</details>

<details>
<summary><b>Phase 5-1 — Downloads-Tab & 13 Sprachen</b></summary>

### v2.0.9552 — 2026-02-25
> Downloads-Tab, Modernisierung der Symbole, Vereinheitlichung der Themes, Unterstützung für 13 Sprachen

</details>

<details>
<summary><b>Frühere Phasen</b></summary>

### Phase 3 — UI-Neugestaltung & Themensystem
v2.0.9500
> Themensystem (Classic/Light/Dark), Fluent-Design-UI, SubWindow-System

### Phase 4 — Codebereinigung
v2.0.9400
> Codebereinigung, Entfernung des Logins, Modernisierung von Altlasten

### Phase 2 — Build-Umgebung & Fluent Design
v2.0.9300
> Build-Umgebung, UnityEngine-Stub-DLL, ModernWpf-Integration

### Phase 1 — Migration auf .NET 4.8
v2.0.9200
> Migration auf .NET Framework 4.8

### v1.x
Ursprüngliche FluffyFish-Version

</details>

---

## Build-Anforderungen

| Anforderung | Version | Anmerkungen |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI-Projekte |
| .NET Framework SDK | 3.5 | nur BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Lizenz

GNU General Public License v3.0 — folgt der Originallizenz.
