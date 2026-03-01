[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**The Forest Mod-Verwaltungstool — Upgrade-Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Deutschland)
> Upgrade: zzangae (Republik Korea)

---

## Überblick

ModAPI ist eine Desktop-Anwendung zur Verwaltung von Mods für The Forest. Diese Upgrade-Edition umfasst die Migration auf .NET Framework 4.8, Windows 11 Fluent Design UI, ein 3-Themen-System, erweiterte Mehrsprachigkeitsunterstützung und eine vollständige Implementierung des Download-Tabs.

---

## Wichtige Änderungen

### Phase 1 — .NET Framework 4.8 Upgrade

- Alle Projekte (5) von `.NET Framework 4.5` → `4.8` migriert
- `TargetFrameworkVersion`, `App.config`, `packages.config` in allen Projekten aktualisiert
- Assembly-Version vereinheitlicht

### Phase 2 — Build-Umgebung & Fluent Design Grundlage

- **ModernWpf 0.9.6** NuGet-Paket eingeführt
- **FluentStyles.xaml** erstellt — Windows 11 Fluent Design Override-Schicht
  - Fluent-Farbpalette, Typografie, Schaltflächen, Tabs, Comboboxen, Scrollbar-Stile
  - Window-, SubWindow-, SplashScreen-Vorlagen
- **UnityEngine Stub-DLL** kompiliert
  - Fehlende Typen hinzugefügt: `WWW`, `Event`, `TextEditor`, `Physics` usw.
- Abhängigkeitsreferenzen korrigiert und erfolgreichen Build bestätigt

### Phase 3 — UI-Neugestaltung & Themen-System

#### Fluent UI Neugestaltung
- Vollständige Umstrukturierung von **MainWindow.xaml**
  - Fluent Design-basiertes Layout, Farben, Typografie
  - Neugestaltete Tab-Steuerelemente, Statusleiste, Titelleisten-Schaltflächen
- Laufzeit-Korrekturen: SplashScreen-Einfrieren, Tab-Wechsel, Symbol-Zustände, Fenster-Ziehen

#### 3-Themen-System

| Thema | Stil-Datei | Beschreibung |
|-------|-----------|--------------|
| Klassisch | Nur Dictionary.xaml | Originales ModAPI-Design (Textur-Hintergrund) |
| Hell | FluentStylesLight.xaml | Heller Ton + Blau-Akzent |
| Dunkel | FluentStyles.xaml | Dunkler Ton + Blau-Akzent (Standard) |

- **Themen-Auswahl-ComboBox** im Einstellungen-Tab hinzugefügt
- Themenwechsel löst **Bestätigungsdialog** → **automatischen Neustart** aus
- Themen-Einstellung wird über `theme.cfg`-Datei gespeichert/geladen

#### Fenster-Ziehen / SubWindows / Hyperlinks
- Root Grid `MouseLeftButtonDown`-Ereignis für direkte Zieh-Behandlung
- ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm Dialoge
- Themenspezifische Link-Farben: Dunkel/Klassisch (`#FFD700`), Hell (`#0078D4`)

### Phase 4 — Code-Bereinigung & Legacy-Entfernung

- Login-System entfernt (Server nicht mehr in Betrieb)
- Update-Mechanismus modernisiert
- Ungenutzten Code bereinigt
- SubWindow-UI korrigiert (Spielpfad-Dialoge usw.)

### Phase 5 — Mehrsprachigkeitsunterstützung Erweiterung (13 Sprachen)

| Sprache | Datei | Sprache | Datei |
|---------|-------|---------|-------|
| Koreanisch | Language.KR.xaml | Italienisch | Language.IT.xaml |
| Englisch | Language.EN.xaml | Japanisch | Language.JA.xaml |
| Deutsch | Language.DE.xaml | Portugiesisch | Language.PT.xaml |
| Spanisch | Language.ES.xaml | Vietnamesisch | Language.VI.xaml |
| Französisch | Language.FR.xaml | Chinesisch (Vereinfacht) | Language.ZH.xaml |
| Polnisch | Language.PL.xaml | Chinesisch (Traditionell) | Language.ZH-TW.xaml |
| Russisch | Language.RU.xaml | | |

### Phase 5-1 — Download-Tab & Themen-Vervollständigung

#### Download-Tab
- Mod-Liste wird aus 3 Quellen geladen (`mods.json`, `versions.xml`, HTML-Parsing)
- Suchfunktion (Filtern nach Mod-Name/Beschreibung/Autor)
- **Spielfilter** (Alle / The Forest / Dedizierter Server / VR)
- **Kategoriefilter** (Alle / Fehlerbehebungen / Balancing / Cheats usw. — 12 Kategorien)
- Versionsauswahl Split-Panel UI
- Direkter `.mod`-Datei-Download → Installation im Spielordner
- Spaltensortierung (Klick auf Name/Kategorie/Autor) und Größenänderung
- Mod-Löschung (DLL + Staging-Datei-Bereinigung)

#### Symbol-Modernisierung (Alle Themen)
- Alle Schaltflächen-PNG-Symbole → **Segoe MDL2 Assets** Schrift-Symbole
- Angewendet auf MainWindow.xaml + 14 SubWindow-Dateien
- Schrift-Symbole erben die Vordergrundfarbe und gewährleisten Sichtbarkeit in allen Themen

| Original-PNG | Schrift-Symbol | Verwendung |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Hinzufügen / Spiel starten |
| Icon_Delete | &#xE74D; | Löschen |
| Icon_Refresh | &#xE72C; | Aktualisieren |
| Icon_Download | &#xE896; | Herunterladen |
| Icon_Continue/Accept | &#xE8FB; | Bestätigen/Fortfahren |
| Icon_Decline | &#xE711; | Abbrechen/Schließen |
| Icon_Information | &#xE946; | Information |
| Icon_Warning | &#xE7BA; | Warnung |
| Icon_Error | &#xEA39; | Fehler |
| Icon_Browse | &#xED25; | Durchsuchen |
| Icon_CreateMod | &#xE713; | Mod erstellen |

#### Vereinheitlichte Steuerelemente über alle Themen

| Steuerelement | Klassisch | Dunkel | Hell |
|---------------|-----------|--------|------|
| Kontrollkästchen | Schalter (Gold) | Schalter (AccentBrush) | Schalter (AccentBrush) |
| Optionsfeld | Kreis (Gold) | Kreis (AccentBrush) | Kreis (AccentBrush) |
| Combobox | Scale9 Original | Fluent Benutzerdefiniert | Fluent Benutzerdefiniert |

#### Themen-Sichtbarkeitskorrekturen
- Hell: AccentButton-Text erzwungen Weiß, Tab-Symbol-Deckkraft angepasst
- Dunkel/Hell: ComboBoxItem `TextElement.Foreground`-Ansatz für Sichtbarkeit des ausgewählten Textes
- Klassisch: Fluent-Fallback-Ressourcen zu Dictionary.xaml hinzugefügt

---

## Dateistruktur

```
ModAPI/
├── App.xaml / App.xaml.cs          # Thema laden/speichern/anwenden
├── Dictionary.xaml                  # Original-Stile + Schalter/Radio/Fallback-Ressourcen
├── FluentStyles.xaml                # Dunkles Thema + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Helles Thema + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # Haupt-UI + Download-Tab + Themen-Auswahl
│   └── SubWindows/                  # 16 SubWindows (alle mit Schrift-Symbolen)
├── resources/
│   ├── langs/                       # 13 Sprachdateien
│   └── textures/Icons/flags/        # Flaggen-Symbole (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # Stub-DLL
```

---

## Build-Anforderungen

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Lizenz

GNU General Public License v3.0 — folgt der Originallizenz.
