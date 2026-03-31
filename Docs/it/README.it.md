[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)
# ModAPI(v1) v2.0.9552 - 20260225

**Strumento di Gestione Mod di The Forest — Edizione Aggiornata**

> Originale: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germania)
> Aggiornamento: zzangae (Repubblica di Corea)

---

## Panoramica

ModAPI è un'applicazione desktop per la gestione delle mod di The Forest. Questa edizione aggiornata include la migrazione a .NET Framework 4.8, l'interfaccia Windows 11 Fluent Design, un sistema a 3 temi, supporto multilingue migliorato e un'implementazione completa della scheda Download.

---

## Modifiche Principali

### Fase 1 — Aggiornamento a .NET Framework 4.8

- Migrazione di tutti i progetti (5) da `.NET Framework 4.5` → `4.8`
- Aggiornamento di `TargetFrameworkVersion`, `App.config`, `packages.config` in tutti i progetti
- Versione assembly unificata

### Fase 2 — Ambiente di Build e Fondamenta Fluent Design

- Introduzione del pacchetto NuGet **ModernWpf 0.9.6**
- Creazione di **FluentStyles.xaml** — livello di override Windows 11 Fluent Design
  - Palette colori Fluent, tipografia, pulsanti, schede, combobox, stili delle barre di scorrimento
  - Template Window, SubWindow, SplashScreen
- Compilazione della **DLL stub UnityEngine**
  - Aggiunti tipi mancanti: `WWW`, `Event`, `TextEditor`, `Physics`, ecc.
- Corretti i riferimenti alle dipendenze e confermata la compilazione riuscita

### Fase 3 — Riprogettazione UI e Sistema di Temi

#### Riprogettazione Fluent UI
- Ristrutturazione completa di **MainWindow.xaml**
  - Layout, colori e tipografia basati su Fluent Design
  - Controlli delle schede, barra di stato e pulsanti della barra del titolo ridisegnati
- Correzioni runtime: blocco dello SplashScreen, cambio schede, stati delle icone, trascinamento finestra

#### Sistema a 3 Temi

| Tema | File di Stile | Descrizione |
|------|--------------|-------------|
| Classico | Solo Dictionary.xaml | Design originale di ModAPI (sfondo texture) |
| Chiaro | FluentStylesLight.xaml | Tono luminoso + accento blu |
| Scuro | FluentStyles.xaml | Tono scuro + accento blu (predefinito) |

- Aggiunto **ComboBox di selezione tema** nella scheda Impostazioni
- Il cambio tema attiva **dialogo di conferma** → **riavvio automatico**
- Impostazione del tema salvata/caricata tramite file `theme.cfg`

#### Trascinamento Finestra / SubWindows / Hyperlink
- Evento `MouseLeftButtonDown` sulla Root Grid per la gestione diretta del trascinamento
- Dialoghi ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Colori dei link specifici per tema: Scuro/Classico (`#FFD700`), Chiaro (`#0078D4`)

### Fase 4 — Pulizia del Codice e Rimozione Elementi Legacy

- Rimosso il sistema di login (server non più operativo)
- Modernizzato il meccanismo di aggiornamento
- Pulito il codice inutilizzato
- Corretta la UI SubWindow (dialoghi percorso gioco, ecc.)

### Fase 5 — Espansione del Supporto Multilingue (13 Lingue)

| Lingua | File | Lingua | File |
|--------|------|--------|------|
| Coreano | Language.KR.xaml | Italiano | Language.IT.xaml |
| Inglese | Language.EN.xaml | Giapponese | Language.JA.xaml |
| Tedesco | Language.DE.xaml | Portoghese | Language.PT.xaml |
| Spagnolo | Language.ES.xaml | Vietnamita | Language.VI.xaml |
| Francese | Language.FR.xaml | Cinese (Semplificato) | Language.ZH.xaml |
| Polacco | Language.PL.xaml | Cinese (Tradizionale) | Language.ZH-TW.xaml |
| Russo | Language.RU.xaml | | |

### Fase 5-1 — Scheda Download e Completamento Temi

#### Scheda Download
- Caricamento dell'elenco mod da 3 fonti (`mods.json`, `versions.xml`, parsing HTML)
- Funzionalità di ricerca (filtra per nome/descrizione/autore della mod)
- **Filtro gioco** (Tutti / The Forest / Server Dedicato / VR)
- **Filtro categoria** (Tutti / Correzioni bug / Bilanciamento / Trucchi, ecc. — 12 categorie)
- UI a pannello diviso per la selezione della versione
- Download diretto dei file `.mod` → installazione nella cartella del gioco
- Ordinamento colonne (clic su nome/categoria/autore) e ridimensionamento
- Eliminazione mod (pulizia DLL + file di staging)

#### Modernizzazione delle Icone (Tutti i Temi)
- Tutte le icone PNG dei pulsanti → icone font **Segoe MDL2 Assets**
- Applicato su MainWindow.xaml + 14 file SubWindow
- Le icone font ereditano il colore di primo piano, garantendo visibilità in tutti i temi

| PNG Originale | Icona Font | Utilizzo |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Aggiungi / Avvia Gioco |
| Icon_Delete | &#xE74D; | Elimina |
| Icon_Refresh | &#xE72C; | Aggiorna |
| Icon_Download | &#xE896; | Scarica |
| Icon_Continue/Accept | &#xE8FB; | Conferma/Continua |
| Icon_Decline | &#xE711; | Annulla/Chiudi |
| Icon_Information | &#xE946; | Informazione |
| Icon_Warning | &#xE7BA; | Avviso |
| Icon_Error | &#xEA39; | Errore |
| Icon_Browse | &#xED25; | Sfoglia |
| Icon_CreateMod | &#xE713; | Crea Mod |

#### Controlli Unificati in Tutti i Temi

| Controllo | Classico | Scuro | Chiaro |
|-----------|----------|-------|--------|
| Casella di controllo | Interruttore (Oro) | Interruttore (AccentBrush) | Interruttore (AccentBrush) |
| Pulsante radio | Cerchio (Oro) | Cerchio (AccentBrush) | Cerchio (AccentBrush) |
| ComboBox | Scale9 originale | Fluent personalizzato | Fluent personalizzato |

#### Correzioni di Visibilità dei Temi
- Chiaro: testo AccentButton forzato Bianco, regolazione Opacity icone schede
- Scuro/Chiaro: approccio `TextElement.Foreground` ComboBoxItem per la visibilità del testo selezionato
- Classico: risorse di fallback Fluent aggiunte a Dictionary.xaml

---

## Struttura dei File

```
ModAPI/
├── App.xaml / App.xaml.cs          # Caricamento/salvataggio/applicazione tema
├── Dictionary.xaml                  # Stili originali + risorse interruttore/radio/fallback
├── FluentStyles.xaml                # Tema scuro + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Tema chiaro + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # UI principale + scheda download + selettore tema
│   └── SubWindows/                  # 16 SubWindows (tutti con icone font)
├── resources/
│   ├── langs/                       # 13 file di lingua
│   └── textures/Icons/flags/        # Icone bandiere (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Requisiti di Build

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Licenza

GNU General Public License v3.0 — segue la licenza originale.
