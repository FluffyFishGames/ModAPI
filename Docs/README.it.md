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

# ModAPI(v1) v2.0.9620 - 20260621

**Strumento di Gestione Mod per The Forest — Edizione Migliorata**

> Originale: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germania)
> Miglioramento: zzangae (Repubblica di Corea)

---

## Panoramica

ModAPI è un'applicazione desktop per la gestione delle mod di **5 giochi ufficialmente supportati**. Questa edizione migliorata include supporto multi-gioco, una scheda Settings completamente ridisegnata, configurazione del percorso Steam, impostazioni dell'interfaccia persistenti, un sistema dinamico di dimensione del carattere, validazione all'avvio del gioco, separazione delle build Debug/Release e numerose correzioni di arresti anomali verificate tramite test in-game.

---

## Giochi Supportati

| Gioco | Motore | Versione | ID Steam | Eseguibile |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Patch 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 5 (aggiornato da Unity 4) |
| Ultima versione | v1.12 (VR) |
| Ultimo aggiornamento | 11 settembre 2019 — patch di supporto VR; nessun ulteriore aggiornamento importante dei contenuti |
| Eseguibile | `TheForest.exe` |
| Cartella dati | `TheForest_Data/Managed/` |
| Cartella mod | `mods/TheForest/` |
| Cartella progetti | `projects/TheForest/` |
| ID app Steam | `242760` |
| IL2CPP | ❌ Mono — completamente supportato |

The Forest è stato aggiornato da Unity 4 a Unity 5, migliorando notevolmente la grafica e la fisica. La patch VR di settembre 2019 è stato l'ultimo grande aggiornamento. Il gioco rimane ora in uno stato stabile e definitivo, ideale per il modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity (base di codice integrata, unificata con Below Zero nel 2022) |
| Ultima versione | Patch 2025 (v18810395) |
| Ultimo aggiornamento | 12 agosto 2025 — correzioni di bug e miglioramenti delle prestazioni insieme al rilascio mobile |
| Eseguibile | `Subnautica.exe` |
| Cartella dati | `Subnautica_Data/Managed/` |
| Cartella mod | `mods/Subnautica/` |
| Cartella progetti | `projects/Subnautica/` |
| ID app Steam | `264710` |
| IL2CPP | ❌ Mono — supportato |

Originariamente costruito su Unity 5, Subnautica ha ricevuto l'aggiornamento "Living Large" (v2.0) alla fine del 2022, che ha unificato la base di codice del motore con Below Zero per una migliore ottimizzazione e stabilità. Nota: il prossimo *Subnautica 2* utilizza Unreal Engine 5.

> **XML riscritto nella v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` aggiunti a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity |
| Ultima versione | v1.1.02 (Beta) / v1.09 (Stable) |
| Ultimo aggiornamento | Marzo 2026 — correzioni di bug per chat vocale e multiplayer tramite il ramo beta |
| Eseguibile | `Raft.exe` |
| Cartella dati | `Raft_Data/Managed/` |
| Cartella mod | `mods/Raft/` |
| Cartella progetti | `projects/Raft/` |
| ID app Steam | `648800` |
| IL2CPP | ❌ Mono — supportato |
| Versions.xml | `1.1.01` (con checksum) |

Dopo la conclusione ufficiale della storia nella v1.0: *The Final Chapter*, le patch sono continuate per migliorare il codice di rete e la stabilità. Un aggiornamento del ramo beta a marzo 2026 ha risolto problemi di chat vocale e multiplayer.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 6 (migrato da Unity 2021/2022 alla fine del 2025) |
| Ultima versione | v0.67.0.0 |
| Ultimo aggiornamento | 26 giugno 2025 — rielaborazione della distribuzione delle isole e aggiornamento del motore; hotfix in corso fino al 2026 |
| Eseguibile | `EscapeThePacific.exe` |
| Cartella dati | `EscapeThePacific_Data/Managed/` |
| Cartella mod | `mods/EscapeThePacific/` |
| Cartella progetti | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — supportato |

Ha completato una ricostruzione importante del sistema e la migrazione a Unity 6 alla fine del 2025, consentendo ambienti più dinamici. Il gioco rimane in sviluppo attivo in Accesso Anticipato.

> **XML riscritto nella v2.0.9610**: `extends="GenericUnityGame"` rimosso; `includeAssembly` impostato solo su `Assembly-CSharp.dll` — previene errori di ereditarietà di `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 2019 |
| Ultima versione | v2.9.5 |
| Ultimo aggiornamento | 4 febbraio 2026 — ottimizzazione per Steam Deck e miglioramenti della leggibilità del testo |
| Eseguibile | `GH.exe` |
| Cartella dati | `GH_Data/Managed/` |
| Cartella mod | `mods/GH/` |
| Cartella progetti | `projects/GH/` |
| ID app Steam | `763790` |
| IL2CPP | ❌ Mono — supportato |
| Versions.xml | `2.9.5` (con checksum) |

Sviluppato attraverso Unity 2017 → 2018 → 2019 nel corso del suo ciclo di vita. L'hotfix di febbraio 2026 si è concentrato sulla compatibilità con Steam Deck e sulla leggibilità dell'interfaccia.

> **XML riscritto nella v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` aggiunti; `DOTweenPro.dll` (inesistente) rimosso.
</details>

---

<details>
<summary><b>Architettura</b></summary>

### Separazione del Runtime

| Componente | Destinazione | Runtime | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Applicazione desktop, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Libreria condivisa |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fissato permanentemente** — l'intestazione PE deve indicare `v2.0.50727` |
| DLL delle mod (utente) | .NET Framework 4.8 | Game Mono 2.0 (patchato) | Compilato con 4.8, intestazione PE patchata al momento dell'applicazione |

### Strumenti per Sviluppatori

Utilità WPF autonome per la gestione dei progetti. Non distribuite agli utenti finali.

| Strumento | Progetto | Scopo |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Aggiorna simultaneamente la versione di `AssemblyInfo.cs` e `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Gestisce i file di lingua — aggiunta, modifica, disattivazione, integrazione nativa |

**VersionTool — Gestione delle Versioni**

Uno strumento WPF autonomo per aggiornare il numero di versione con un solo clic.

- Mostra automaticamente la versione attuale (letta da `App.xaml.cs`)
- Inserire una nuova versione e fare clic su **Apply Version** per aggiornare entrambi i file simultaneamente
- Validazione del formato: viene accettato solo il formato `X.X.XXXX`

| File | Percorso | Modifica |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Sistema Linguistico**

```
resources/langs/langs.json          ← Registro delle lingue (flag builtin / active)
resources/langs/Language.XX.xaml    ← Chiavi di traduzione per lingua
resources/langs/Language.XX.png     ← Immagine della bandiera (36×24, da flagcdn.com/h24/)
```

Flusso di integrazione nativa (pulsante Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() riscritto (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml registrato (ModAPI\ModAPI.csproj)
  → Prossima compilazione: lingua completamente integrata, disponibile offline
```

### Separazione delle Build Debug / Release

Tutta la validazione dei file e l'elaborazione degli assembly si ramificano in base alla configurazione di build tramite `#if DEBUG` / `#else`.

| Posizione | Build Debug | Build Release |
|---|---|---|
| `CheckSteam()` | solo `File.Exists()` — i file fittizi passano | `FileValidator.IsValidSteamExe()` — intestazione PE + min. 1 MB |
| `CheckGamePath()` | solo `File.Exists()` — i file fittizi passano | `FileValidator.IsValidAssemblyDll()` — intestazione PE + metadati CLR + min. 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — analisi Cecil saltata | Analisi completa Mono.Cecil + modifica IL + `module.Write()` |
| `ModLib.Create()` — file non trovato | Registra avviso, salta e continua | Registra errore, interrompe con popup |

**I test Debug** utilizzano `create_dummy_Debug_games.ps1` per generare file segnaposto di 0 byte in `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` e `bin\Debug\gamefiles\original\`. Questi superano i controlli `File.Exists()` e consentono di testare l'intero flusso di lavoro dell'interfaccia senza un'installazione reale del gioco.

**Le build Release** applicano `FileValidator` (verifica dell'intestazione PE + metadati CLR .NET) per rifiutare file di 0 byte, file di testo e file binari arbitrari. Solo eseguibili Windows validi e assembly .NET validi passano.

### FileValidator — Verifica dell'Intestazione PE

`ModAPI_Shared\Utils\FileValidator.cs` — applicato solo nelle build Release.

| Metodo | Controlli | Dimensione minima |
|---|---|---|
| `IsValidSteamExe(path)` | Firma MZ + firma PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Firma MZ + firma PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + intestazione metadati CLR (directory dati #14) | 8 KB |

```
Layout dell'intestazione PE verificato:
[0x00] 4D 5A          ← firma DOS "MZ"
[0x3C] XX XX XX XX   ← offset dell'intestazione PE (little-endian)
[offset] 50 45 00 00 ← firma "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← presenza dell'intestazione CLR .NET
```

### Pipeline di Rimappatura degli Assembly

```
[Lo sviluppatore della mod compila con .NET 4.8]
  → DLL della mod: intestazione PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, ecc.
  → modModule.RuntimeVersion = "v2.0.50727"
      intestazione PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → intestazione PE accettata ✅  →  riferimenti risolti ✅
```

### Fallback del Resolver degli Assembly

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← cartella di backup
2. {ActualGameInstallPath}/{AssemblyPath}        ← cartella di installazione del gioco (fallback)
```

### Supporto alle Funzionalità di C# 7.3

| Funzionalità | Stato | Note |
|---|---|---|
| Corrispondenza di pattern (`is`, `switch`) | ✅ | Verificato in gioco |
| Interpolazione di stringhe (`$""`) | ✅ | Verificato in gioco |
| Variabile `out` inline | ✅ | Verificato in gioco |
| `async` / `await` | ✅ | Tramite AsyncBridge + polyfill System.Threading |
| Tuple (`ValueTuple`) | ❌ Limite rigido | ABI `mscorlib` di Mono 2.0 — nessuna soluzione alternativa |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

A partire dalla v2.0.9613, l'interfaccia di selezione del tema è stata spostata dalla scheda Settings a una scheda **Themes** dedicata. Aggiungere un nuovo tema richiede solo una riga nel dizionario `App.xaml.cs`.

| Indice | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | solo `Dictionary.xaml` | Sfondo con texture originale di ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono chiaro + accento blu |
| 2 | `dark` | `FluentStyles.xaml` | Tono scuro + accento blu (predefinito) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rosso + nero |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Spazio scuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Tramonto luminoso |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano scuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordico luminoso |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumi luminosi |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floreale luminoso |

Il cambio di tema provoca un riavvio automatico dell'applicazione. (salvato in `theme.cfg`)

| Tema | Tema |
| :---: | :---: |
|**01. Tema Classic**|**02. Tema Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/dc81132a-149c-4d0b-a7bb-a04a900e878b) | ![02. Light theme](https://github.com/user-attachments/assets/0d6925ec-f8b2-4f8a-a1d6-c082a5aa3378) |
|**03. Tema Dark**|**04. Tema Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/53abe172-ee66-4f3e-9c36-830b2d659b4d) | ![04. Diablo theme](https://github.com/user-attachments/assets/8c30f223-e564-45dc-8389-c51bfc60b3eb) |
|**05. Tema Nebula**|**06. Tema Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/4ff565dd-516b-4951-9d47-6027ac9e3e29) | ![06. Sunset theme](https://github.com/user-attachments/assets/192a6f16-b041-4422-8b64-4f8522f27c15) |
|**07. Tema Ocean**|**08. Tema Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/50a47588-bc62-4cfc-91a0-a44f87c45867) | ![08. Nordic theme](https://github.com/user-attachments/assets/81e98f6b-2897-4fd5-bee9-604c04dc26ff) |
|**09. Tema Citrus**|**10. Tema Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/64ccb11d-4ab0-41a2-8e00-4f7910558372) | ![10. Bloom theme](https://github.com/user-attachments/assets/265c9249-4d43-4f77-86d6-ccc4037071f7) |

### Texture di Sfondo

Selezionare un'immagine nella scheda **Background Texture** della scheda Themes per applicarla come sfondo dell'intera applicazione. Formati supportati: `.png` / `.jpg` / `.jpeg`, fino a 50 MB, risoluzione 4K o inferiore. L'immagine viene compressa come JPEG Q75 con un'intestazione magica di 16 byte e salvata come `resources\textures\ui_bg\bg.dat` (attributo Hidden). Hash SHA-256 per la verifica dell'integrità; la manomissione attiva un ripristino automatico + popup di avviso.

Quando lo sfondo è attivo, la trasparenza dell'interfaccia viene elaborata in due livelli: Livello 1 (sovrapposizione MergedDictionaries) per i pannelli `{DynamicResource}`, Livello 2 (WalkStyleBackgrounds) per i pannelli basati su `{StaticResource}` con semi-trasparenza.

### Sistema di Dimensione del Carattere

| Chiave risorsa | Base | Descrizione |
|---|---|---|
| `AppBaseFontSize` | 13 | Testo normale |
| `AppBaseHeaderFontSize` | 16 | Intestazioni, titoli dei pannelli |
| `AppBaseSmallFontSize` | 12 | Etichette secondarie |
| `AppBaseTinyFontSize` | 10 | Testo di suggerimento |
| `AppBaseLargeFontSize` | 20 | Testo di visualizzazione grande |

### Configurazione Persistente dell'Interfaccia — `ui.cfg`

| Chiave | Predefinito | Descrizione |
|-----|---------|-------------|
| `ModListWidth` | `150` | Larghezza della lista nella scheda Mods (px) |
| `ProjectListWidth` | `150` | Larghezza della lista progetti nella scheda Development (px) |
| `AppFontSize` | `13` | Dimensione carattere globale dell'interfaccia (px) |
| `AlwaysOnTop` | `false` | Finestra sempre in primo piano |
| `TexturePath` | *(nessuno)* | Nome file originale della texture di sfondo (solo visualizzazione) |
| `TextureHash` | *(nessuno)* | Hash SHA-256 della texture di sfondo |
| `TextureActive` | `false` | Stato di attivazione della texture di sfondo |
| `GamePathReset_{GameId}` | *(nessuno)* | Flag di ripristino del percorso del gioco |
| `SteamPathReset` | *(nessuno)* | Flag di ripristino del percorso Steam |
</details>

<details>
<summary><b>Struttura del Progetto</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Impostazioni persistenti dell'interfaccia
├── theme.cfg                            # Tema attuale
├── Windows/
│   ├── MainWindow.xaml / .cs            # Interfaccia principale — 6 schede, Themes, Settings, percorso Steam,
│   │                                    #   protezione da download di 0 byte, debounce dello slider, letture silenziose della configurazione
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup del percorso del gioco (GameNameLabel dinamico)
│       ├── FirstSetup.xaml / .cs        # Configurazione iniziale + inizializzazione dei valori predefiniti
│       └── (altre 14 SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Tema Classic
│   ├── FluentStyles.xaml                # Tema Dark
│   ├── FluentStylesLight.xaml           # Tema Light
│   ├── FluentStylesDiablo.xaml          # Tema Diablo
│   ├── FluentStylesNebula.xaml          # Tema Nebula
│   ├── FluentStylesSunset.xaml          # Tema Sunset
│   ├── FluentStylesOcean.xaml           # Tema Ocean
│   ├── FluentStylesNordic.xaml          # Tema Nordic
│   ├── FluentStylesCitrus.xaml          # Tema Citrus
│   └── FluentStylesBloom.xaml           # Tema Bloom
├── Data/
│   ├── Mod.cs                           # Caricamento file mod, analisi intestazione LF/CRLF, log diagnostico
│   ├── ModLib.cs                        # Generazione BaseModLib + rimappatura (separazione #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Creazione/compilazione/applicazione progetto + protezioni null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   prevenzione dei nuovi tentativi per mod corrotte
│   │   ├── ModViewModel.cs              # GameId dal percorso della cartella
│   │   ├── ModProjectsViewModel.cs      # Dispose() per DispatcherTimer
│   │   └── SettingsViewModel.cs         # Valore predefinito true per UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mappatura delle versioni assembly Mono 2.0 (20 assembly)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolver basato sul nome con caching
│   └── MonoHelper.cs                    # Utilità di supporto IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 file di lingua + langs.json (chiavi LangTool.* aggiunte in v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Immagine di sfondo compressa e protetta (generata a runtime)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Riscrittura completa in v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Riscrittura completa in v2.0.9610
    │   ├── GH.xml                       # Riscrittura completa in v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — non supportato
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt con parametro silent
├── Data/
│   ├── Game.cs                          # Creazione automatica del backup per ApplyMods, resolver condizionale,
│   │                                    #   fallback alla cartella del gioco, correzione del costruttore leggero + inizializzazione ModLib
│   └── ModLib.cs                        # Separazione #if DEBUG, fallback alla cartella del gioco per IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Validazione dell'intestazione PE + metadati CLR (solo Release, min. 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Strumento WPF autonomo per l'aggiornamento della versione
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Inserimento versione, pulsante Apply, visualizzazione versione attuale
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Strumento WPF autonomo per la gestione delle lingue
├── App.xaml / App.xaml.cs              # Caricamento/cambio lingua, langtool.cfg
├── MainWindow.xaml / .cs               # Interfaccia principale — lista lingue, pannello di modifica, selettore percorso
├── AddLanguageDialog.xaml / .cs        # ComboBox di selezione paese ISO 3166-1
├── ModApiDialog.xaml / .cs             # Finestra di dialogo personalizzata in stile ModAPI (Info/Avviso/Conferma/Domanda)
├── Models/
│   ├── LanguageEntry.cs                # Modello della voce lingua (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Modello radice di langs.json
│   └── IsoCountry.cs                   # Modello paese ISO per ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Lettura/scrittura di langs.json
    ├── FlagDownloader.cs               # Download bandiera da flagcdn.com h24
    ├── XamlGenerator.cs                # Generazione/salvataggio/analisi di Language.XX.xaml
    ├── MissingKeyDetector.cs           # Rilevamento chiavi mancanti rispetto al riferimento inglese
    ├── IsoCountryList.cs               # Lista completa dei paesi ISO 3166-1 (196 paesi, offline)
    └── BuiltinCodeWriter.cs            # Riscrittura di CreateDefaultLangsJson() + registrazione in ModAPI.csproj

bin\Debug\                               # Solo per i test Debug
├── create_dummy_Debug_games.ps1         # Genera una struttura fittizia di gioco/Steam
├── dummy_games\{GameId}\               # Percorsi di installazione fittizi dei giochi
├── dummy_steam\Steam.exe               # Eseguibile Steam fittizio
└── gamefiles\original\{GameId}\        # Percorsi di backup fittizi per ModLib
```

---

</details>

<details>
<summary><b>Installazione e Configurazione</b></summary>

### Passaggio 1 — Prerequisiti

| Elemento | Richiesto |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstallato su Windows 11; [scaricare](https://dotnet.microsoft.com/download/dotnet-framework/net48) per Windows 10) |
| Steam | Richiesto — deve essere configurato nella scheda Settings |
| Almeno un gioco supportato | Richiesto — deve essere configurato nella scheda Settings |

### Passaggio 2 — Installare ModAPI

1. Scaricare l'ultima versione da GitHub
2. Estrarre in una cartella qualsiasi (ad es. `C:\ModAPI\`)
3. Eseguire `ModAPI.exe`
4. Al primo avvio appare la schermata **Welcome** — configurare le preferenze e fare clic su **Continue**

### Passaggio 3 — Configurare il Percorso Steam (Scheda Settings)

1. Andare alla scheda **Settings**
2. Cercare **Steam Installation Path**
3. Fare clic su **Browse** → selezionare `Steam.exe`
4. Fare clic su **Save**

### Passaggio 4 — Configurare i Percorsi dei Giochi (Scheda Settings)

1. Fare clic sull'intestazione di una scheda di gioco per espanderla
2. Fare clic su **Browse** → selezionare la cartella radice del gioco (dove si trova il `.exe`)
3. Fare clic su **Save**

| Gioco | Eseguibile | Percorso di esempio |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Passaggio 5 — Scaricare le Mod (Scheda Downloads)

1. Andare alla scheda **Downloads**
2. Selezionare un gioco nel filtro giochi
3. Cercare o sfogliare una mod e fare clic su **Download**

> **Offline**: scaricare manualmente i file `.mod` da `modapi.survivetheforest.net` e posizionarli nella cartella corrispondente:

| Gioco | Cartella |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Passaggio 6 — Applicare le Mod e Avviare il Gioco (Scheda Mods)

1. Andare alla scheda **Mods**
2. Selezionare un gioco in **Game Filter** (colonna 0)
3. Selezionare le mod da attivare in **Mod List** (colonna 1)
4. Fare clic su **Start Game**

I seguenti controlli vengono eseguiti automaticamente prima dell'avvio:

| # | Controllo | Popup in caso di fallimento |
|---|---|---|
| 1 | Percorso Steam configurato e valido | SteamNotFound |
| 2 | Il gioco nella cartella `mods/` corrisponde al percorso di gioco in Settings | GameModsMismatch |
| 3 | Almeno una mod selezionata | NoModSelected |
| 4 | Nessuna mescolanza di mod di giochi diversi nella selezione | MixedGameMods |
| 5 | Percorso del gioco configurato ed eseguibile esistente | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Panoramica delle Schede</b></summary>

### Scheda Welcome
Schermata di configurazione iniziale (indice scheda 0). Configurare AutoUpdate, la connessione Steam e le preferenze della tabella VersionsData. Negli avvii successivi, questa scheda offre link della community e note di rilascio.

### Scheda Mods
Flusso di lavoro principale per la gestione delle mod — layout a 3 colonne:

| Colonna | Contenuto |
|---|---|
| Colonna 0 | Game Filter — pulsanti radio per i 5 giochi supportati |
| Colonna 1 | Mod List — mod installate con selettore versione e casella di attivazione |
| Colonna 2 | Information — dettagli, descrizione e cronologia versioni della mod selezionata |

### Scheda Downloads
Sfogliare e scaricare mod da `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 categorie (correzioni di bug, bilanciamento, trucchi, …)
- **Search**: per nome mod, descrizione o autore
- **Offline mode**: mostra le istruzioni delle cartelle per tutti i 5 giochi supportati

### Scheda Development
Flusso di lavoro per lo sviluppo di mod — il pannello del filtro gioco (colonna 0) copre tutti i 5 giochi supportati.

- Creazione, compilazione e applicazione di progetti mod per gioco
- Gestione delle risorse linguistiche
- Generazione di ModLib con validazione in 3 passaggi (Steam → progetto → percorso gioco)
- Cambio gioco sicuro tramite un costruttore `Game` leggero (senza chiamata a `Verify()`)

### Scheda Themes
Selezione del tema e gestione della texture di sfondo.

- **Selezione tema**: 10 temi (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Texture di sfondo**: selezionare un'immagine come sfondo dell'intera applicazione (compressione JPEG + elaborazione di sicurezza)
- Quando la texture di sfondo è attiva, la selezione del tema è bloccata

### Scheda Settings
Configurazione centralizzata — 4 righe:

| Riga | Contenuto |
|---|---|
| 0 | Lingua / Dimensione carattere / Larghezza massima / Larghezza Mod List / Larghezza Project List |
| 1 | Mantenere VersionsData / Aggiornamento automatico / Connessione Steam / Sempre in primo piano |
| 2 | Steam Installation Path (casella di testo + Browse + Save + Reset) |
| 3 | Game Installation Paths — scheda espandibile per gioco (casella di testo + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Strumento di Gestione delle Lingue)

Uno strumento WPF autonomo per gestire i file di lingua di ModAPI. Aggiunto alla soluzione come `LangTool\MODAPI_LangTool.csproj`.

**Posizione**: `LangTool\MODAPI_LangTool.csproj`

**Funzionalità Principali**

| Funzionalità | Descrizione |
|---|---|
| Lista lingue | Mostra tutte le lingue da `langs.json` con icone di stato (🔒 integrato / 🚫 inattivo / ✅ attivo) |
| Aggiunta lingua | Selezionare un paese dal ComboBox ISO 3166-1 → la bandiera viene scaricata automaticamente da `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` viene generato automaticamente dal modello inglese |
| Modifica lingua | `isoCode` / `langCode` bloccati; `langName` e le chiavi di traduzione sono modificabili quando attivo |
| Disattivare / Attivare | Attiva/disattiva il flag `active` in `langs.json` — il file viene conservato, nascosto dalla lista di ModAPI |
| Aggiornamento (integrazione nativa) | Converte `builtin: false` → `true` — irreversibile, conferma in 2 passaggi — riscrive automaticamente `CreateDefaultLangsJson()` nel codice sorgente e registra `Language.XX.xaml` in `ModAPI.csproj` |
| Rilevamento chiavi mancanti | Confronta con il riferimento inglese — mostra il numero di chiavi mancanti/vuote e il progresso della traduzione |
| Protezione integrati | Le lingue con `builtin: true` sono di sola lettura — non è possibile modificare, disattivare o aggiornare |
| Protezione inattivi | Le lingue con `active: false` sono di sola lettura fino alla riattivazione |
| Interfaccia lingua | LangTool stesso supporta tutte le 13 lingue di ModAPI — selettore lingua con bandiera in alto a destra |
| Memorizzazione percorso | Il percorso radice di ModAPI selezionato viene salvato in `langtool.cfg` — caricato automaticamente al prossimo avvio |
| Finestre di dialogo personalizzate | Tutti i popup usano il `ModApiDialog` a tema scuro in stile ModAPI invece della MessageBox di sistema |

**Struttura di langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Convenzione delle Immagini delle Bandiere**

```
Codice ISO (minuscolo) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                        resources/langs/
```

**Comportamento del Pulsante Update**

Quando si fa clic sul pulsante Update per una lingua attiva non integrata:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` viene riscritto con tutte le lingue attualmente `builtin: true`
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` registrato
4. Prossima compilazione — lingua completamente integrata, disponibile offline

**Chiavi di Lingua Aggiunte** (`Lang.LangTool.*`)

53 nuove chiavi aggiunte a tutti i 13 file di lingua che coprono tutte le stringhe dell'interfaccia di LangTool, i messaggi di dialogo e i testi di stato.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Strumento di Aggiornamento Versione)

Uno strumento WPF autonomo per aggiornare il numero di versione con un solo clic.

**Posizione**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Funzionalità**
- Mostra automaticamente la versione attuale (letta da `App.xaml.cs`)
- Inserire una nuova versione e fare clic su **Apply Version** per aggiornare entrambi i file simultaneamente
- Validazione del formato: viene accettato solo il formato `X.X.XXXX`

**File Modificati**

| File | Percorso | Modifica |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Utilizzo**
1. Eseguire `MODAPI_VersionTool.exe`
2. Inserire la nuova versione (ad es. `2.0.9619`)
3. Fare clic su **Apply Version**
4. Ricompilare la soluzione ModAPI in Visual Studio

**Visualizzazione della Versione nella StatusBar**

- `VersionLabel.Text` ora fa riferimento a `App.Version` invece di un descrittore codificato in modo fisso
- L'aggiornamento della versione con VersionTool e una ricompilazione si riflettono immediatamente nella StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Sistema di Logging — Separazione in Due File (`ModAPI.log` / `ModAPI.detailed.log`)

I log diagnostici riservati agli sviluppatori erano in precedenza limitati da `#if DEBUG`, il che li rendeva invisibili nelle build Release proprio quando erano più necessari per risolvere un problema di un utente. Un sistema a due file sostituisce questo approccio:

| File | Contenuto |
|---|---|
| `ModAPI.log` | Log principale orientato all'utente — aspetto invariato, non più rumoroso di prima |
| `ModAPI.detailed.log` | Ogni chiamata di log, sempre, sia in Release che in Debug — per diagnosticare i problemi segnalati dagli utenti |

**`Debug.cs`** — `Log()` ha un parametro `detailedOnly`. Quando è `true`, il messaggio viene scritto solo in `ModAPI.detailed.log`; tutti i blocchi `#if DEBUG` precedenti sono stati convertiti in questo flag invece di essere completamente esclusi dalla compilazione, quindi vengono sempre catturati nel file dettagliato anche in Release. Ciò comporta un modello di gravità a 4 livelli:

| Livello | Significato |
|---|---|
| Verbose (`detailedOnly: true`) | Tracce ripetitive/meccaniche — per tipo, per file, per metodo |
| Notice | Flusso leggibile dall'uomo — messaggi di avanzamento e successo |
| Warning | Problemi potenziali, non ancora fallimenti |
| Error | Fallimenti confermati |

**Fonti di rumore nei log identificate e convertite in `detailedOnly: true`:**

| File | Cosa inondava `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Messaggi di scansione/salto/coda di `FindMods()` ripetuti ad ogni polling di 1 secondo |
| `Game.cs` | Righe di traccia TLS/URL di `UpdateVersions()`, voci di mappatura dei tipi Cecil |
| `ModLib.cs` | Elaborazione degli assembly per tipo/metodo di Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — responsabile della stragrande maggioranza del volume di `ModAPI.log` (decine di migliaia di righe per una singola compilazione di mod Green Hell) |
| `Mod.cs` | Dump completo dell'XML di intestazione della mod (`configuration.ToString()`) registrato integralmente ad ogni caricamento della mod |

**Log delle discrepanze del checksum — riepilogato invece che per elemento:** `Header.Verify()` in precedenza registrava una riga `Mismatched checksum at "..."` per ogni voce incompatibile `InjectInto`/`AddMethod`/`AddField`/`AddClass`, il che poteva significare decine di righe per una singola mod obsoleta. Ora registra un unico riepilogo di livello Warning in `ModAPI.log` (ad es. `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), mentre la ripartizione completa per elemento rimane disponibile in `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Modifiche nella v2.0.9620</b></summary>

## Modifiche nella v2.0.9620

### Aggiunto MODAPI_LangTool

È stato aggiunto uno strumento WPF autonomo per gestire i file di lingua di ModAPI (`LangTool\MODAPI_LangTool.csproj`) — vedere la sezione **Lang Tool** sopra per i dettagli completi.

---

### Correzioni di Bug

| # | File | Problema | Correzione |
|---|---|---|---|
| 1 | `App.xaml.cs` | Il francese si mescolava ai messaggi di eccezione .NET su Windows non inglese | `CultureInfo.InvariantCulture` fissato all'avvio del costruttore `App()` |
| 2 | `Game.cs` | Errore SSL/TLS in `UpdateVersions()` — impossibile creare un canale sicuro SSL/TLS | TLS 1.2 impostato esplicitamente tramite `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Popup `GamePathNotSet` per Green Hell nonostante il percorso configurato | `App.Game.GamePath` vuoto → legge il percorso salvato da `Configuration` |
| 4 | `ModsViewModel.cs` | I file mod non apparivano nella lista quando posizionati manualmente in `mods\TheForest\` | Aggiunto log diagnostico di validazione del pattern del nome file |
| 5 | `MainWindow.xaml.cs` | Il popup `MixedGameMods` bloccava la selezione di mod multi-gioco | Popup bloccante rimosso — sostituito con `SelectGameDialog` |

---

### Nuove Funzionalità

#### Avvio del Gioco — Popup di Selezione Gioco (`SelectGameDialog`)

Quando sono selezionate mod di giochi diversi, o quando il filtro **All** è attivo, appare un popup di selezione del gioco invece di bloccare l'avvio.

**Condizioni di attivazione:**
- Filtro `All` selezionato + clic su Start Game
- Mod di 2 o più giochi diversi attivate simultaneamente

**Comportamento:**
- Mostra solo i giochi con percorsi configurati ed eseguibile esistente
- Vengono applicate solo le mod del gioco selezionato — le mod di altri giochi vengono completamente ignorate
- Il pulsante radio si sincronizza con il gioco selezionato dopo la chiusura del popup (`SyncModGameFilterRadioButton`)

**Nuovi file**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Verifica dell'Integrità del Gioco (solo build Release, `#if !DEBUG`)

Prima di ogni avvio del gioco viene eseguito un controllo di integrità a tre livelli:

| Livello | Metodo | In caso di fallimento |
|---|---|---|
| A — Intestazione PE | `FileValidator.IsValidGameExe()` | Bloccato + popup `GameExeCorrupted` |
| B — Checksum dell'assembly | Confronto MD5 → `Versions.xml` | Bloccato + popup `GameAssemblyTampered` |
| C — Firma digitale | `HasDigitalSignature()` | Avviso + scelta dell'utente (`GameIntegrityWarning`) |

**Nuovi file**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Nuovi metodi aggiunti a `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 di Assembly-CSharp.dll (+ firstpass se presente)
- `HasDigitalSignature(path)` — controllo della firma Authenticode

---

### Nuovi Log Diagnostici

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 elementi, Release + Debug)

| # | Fase | Tipo | Contenuto |
|---|---|---|---|
| 1 | Impostazione TLS | Notice | Protocollo prima/dopo |
| 2 | Inizio download | Notice | Elenco server |
| 3 | Tentativo URL | Notice | Ogni URL tentata |
| 4 | Download riuscito | Notice | URL, lunghezza risposta, protocollo utilizzato |
| 5 | WebException | Error | URL, stato HTTP, protocollo, dettaglio |
| 6 | Altra eccezione | Error | URL, tipo di eccezione, dettaglio |
| 7 | Download completato | Notice | Conteggio successi / totale server |
| 8 | Analisi riuscita | Notice | Conteggio file e versioni prima/dopo |
| 9 | Analisi fallita | Error | Tipo di eccezione e dettaglio |
| 10 | Salvataggio riuscito | Notice | Percorso di salvataggio, totale versioni/file |
| 11 | Salvataggio fallito | Error | Percorso, tipo di eccezione, dettaglio |
| 12 | Nessuna risposta | Error | Server tentati, protocollo |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 elementi, solo `#if DEBUG`)

| # | Situazione | Tipo | Contenuto |
|---|---|---|---|
| 1 | Inizio scansione | Notice | Percorso cartella mod, totale file trovati |
| 2 | Già caricato | Notice | Nome file |
| 3 | Non un file .mod | Notice | Nome file |
| 4 | Corrispondenza pattern riuscita | Notice | Nome file accodato |
| 5 | Corrispondenza pattern fallita | Warning | Nome file + motivo + formato previsto |
| 6 | Scansione completata | Notice | Conteggio in coda / totale file |
| 7 | Eccezione | Error | Dettaglio eccezione |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 elementi, Release + Debug)

| # | Situazione | Tipo | Contenuto |
|---|---|---|---|
| 1 | Condizione popup | Notice | Filtro attuale, ID giochi selezionati, needGameSelect |
| 2 | Giochi candidati | Notice | Elenco ID candidati per il popup |
| 3 | Percorso non impostato | Notice | Gioco saltato — percorso non configurato |
| 4 | Non presente in Configuration | Notice | Gioco saltato — non presente in Configuration.Games |
| 5 | Installazione confermata | Notice | Gioco + percorso eseguibile |
| 6 | Exe non trovato | Warning | Gioco saltato — eseguibile mancante |
| 7 | Nessun gioco installato | Error | 0 candidati → GamePathNotSet |
| 8 | Selezione automatica | Notice | Candidato unico selezionato automaticamente |
| 9 | Annullato dall'utente | Notice | SelectGameDialog annullato |
| 10 | Gioco selezionato + mod | Notice | Gioco selezionato, conteggio/elenco mod raccolte |

---

### Separazione dei Log Sviluppatore / Utente (`#if DEBUG`)

| File | Log | Motivo |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Si ripete ogni secondo — 81% del volume totale di logging |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Dettaglio interno riservato agli sviluppatori |

Il log Release conserva: successo/fallimento del download, risultati di analisi/salvataggio, fallimenti di corrispondenza pattern, eccezioni, risultati del controllo di integrità.

---

### Aggiornamento della Tabella delle Versioni — Architettura

#### Intento Progettuale

```
Il gioco riceve un aggiornamento Steam
  → Assembly-CSharp.dll cambia
  → ModAPI controlla Versions.xml per un checksum conosciuto
  → Se non trovato → scarica il Versions.xml più recente dal server
  → La nuova versione viene registrata automaticamente senza reinstallare ModAPI
```

#### Struttura di Connessione

```
Scheda Settings → casella di controllo KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → chiamata a UpdateVersions()
      → scarica Versions.xml da VersionUpdateDomains[]
      → sovrascrive il configs\games\{GameId}\Versions.xml locale
```

#### Integrazione dell'URL Raw di GitHub

Invece di affidarsi esclusivamente a `modapi.survivetheforest.net`, l'URL Raw di GitHub viene ora utilizzato come fonte primaria per la gestione diretta:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — gestito direttamente, priorità 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Server legacy — fallback, priorità 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Elemento | Dettaglio |
|---|---|
| Primario | URL Raw di GitHub — aggiornato immediatamente ad ogni push |
| Fallback | Server legacy — utilizzato quando GitHub non è disponibile |
| Percorso | `ModAPI/configs/games/{GameId}/Versions.xml` nel repository |
| File modificato | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Aggiornamenti di Versions.xml

| Gioco | File | Modifica |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Checksum corretto (era un SHA-256 errato in maiuscolo) — `2.9.5b114117` con MD5 corretto |
| The Forest | `configs\games\TheForest\Versions.xml` | Aggiunto `1.12` (BuildID: 20229486) — checksum MD5 a 128 caratteri |

---

### Nuove Chiavi di Lingua (13 lingue)

| Chiave | Valore inglese |
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
| `Lang.Savegames.*` (133 chiavi) | Valori inglesi aggiunti a 12 lingue (DE già tradotto) |

---

### File Modificati

| File | Percorso | Modifica |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` fissato all'avvio |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, controllo di integrità, MixedGameMods rimosso, sincronizzazione radio, 10 log |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nuovo |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nuovo |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Log diagnostico del nome file, separazione #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 log di UpdateVersions, URL GitHub, separazione #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 nuove chiavi + 133 chiavi Savegames (515 in totale, tutte le lingue allineate) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Checksum corretto |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | Aggiunto `1.12` |
| `LangTool\` (13 file) | Radice della soluzione | Nuovo |
| `ModAPI.sln` | Radice della soluzione | LangTool registrato |

---

### Correzioni Aggiuntive e Revisione del Sistema di Logging (2026-06-21)

#### Validazione StartGame — Riprogettazione Completa

L'ordine di validazione è stato corretto in una sequenza rigorosa a 3 passaggi, e il popup di selezione del gioco ora riflette le mod attivate indipendentemente dal fatto che il percorso del gioco sia configurato.

| Passaggio | Controllo | Popup in caso di fallimento |
|---|---|---|
| 1 | Steam installato | SteamNotFound |
| 2 | Percorso del gioco selezionato configurato + eseguibile esistente | GamePathNotSet |
| 3 | Almeno una mod attivata per il gioco selezionato | NoModSelected |

- **Filtro All / mod di più giochi selezionate** → il popup elenca sempre tutti i giochi con una mod attivata, **inclusi quelli senza percorso configurato** — selezionare un gioco non configurato ora mostra correttamente `GamePathNotSet` invece di escluderlo silenziosamente o mostrare l'errore sbagliato
- **Filtro per un singolo gioco** → i controlli di percorso e mod vengono eseguiti direttamente per quel gioco, nello stesso ordine 1→2→3

#### Correzioni Critiche di Bug

| # | File | Problema | Correzione |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` univa le risposte di **tutti** i server riusciti (GitHub + legacy), raddoppiando i checksum (64 → 128 caratteri) quando entrambi avevano successo — causava falsi blocchi `GameAssemblyTampered` | Viene analizzata solo la risposta del primo server riuscito; i server rimanenti vengono saltati non appena uno ha successo |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` utilizzava `App.Game` (filtro attivo attuale) invece del gioco proprio della mod — eliminare una mod di Green Hell mentre The Forest era attivo cercava nella cartella `Managed` sbagliata e saltava silenziosamente l'eliminazione | Ora risolve il percorso della DLL distribuita da `mod.Game` (l'istanza di gioco effettiva della mod), con un fallback su `Configuration` se `GamePath` è vuoto |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Riscaricare una mod precedentemente eliminata ripristinava il suo badge di attivazione come selezionato — l'eliminazione di una mod non cancellava mai le sue chiavi persistenti `Selected`/`Version` né la cache ViewModel in memoria | Aggiunto `RemoveKey()` / `RemoveKeysWithPrefix()` a `Configuration.cs`; `DeleteMod_Click` ora forza `ModViewModel.Selected = false` e rimuove tutte le chiavi `Mods.{GameId}.{ModId}.*` all'eliminazione |
| 4 | `ModsViewModel.cs` | Eliminare una mod mentre era selezionato un filtro di gioco specifico (non "All") lasciava la mod visibile nella lista fino a passare a "All" e tornare indietro | Mancava la notifica di modifica di `FilteredMods` dopo `_Mods.RemoveAt()` nel ciclo di polling per l'eliminazione dei file; ora si attiva ogni volta che una mod viene effettivamente rimossa |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Un'eccezione non gestita durante la costruzione o la visualizzazione del popup di avviso di firma mancante poteva far arrestare silenziosamente ModAPI senza alcun errore registrato | La costruzione/visualizzazione del popup e la formattazione dei messaggi sono state avvolte in un try-catch; in caso di fallimento, l'avviso viene registrato e l'utente può continuare in sicurezza (la firma mancante è informativa, non un blocco rigido) |

#### Avviso di Firma Digitale — Messaggio Chiarito

Il testo di `GameNoSignature` ora nomina il gioco specifico e chiarisce che una firma mancante è prevista per i titoli indie e non influisce sul gameplay, invece di suggerire una possibile manomissione. Aggiornato in tutti i 13 file di lingua con un segnaposto `{0}` per il nome visualizzato del gioco (ad es. "The Forest", "Green Hell").

#### Sistema di Logging — Separazione in Due File

I log diagnostici limitati da `#if DEBUG` sono stati convertiti in un flag `detailedOnly` e divisi tra `ModAPI.log` (orientato all'utente) e `ModAPI.detailed.log` (sempre in dettaglio completo) — vedere la sezione **Log** sopra per la ripartizione completa.

#### File Modificati (Aggiuntivi)

| File | Percorso | Modifica |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Riprogettazione della validazione StartGame, correzione dell'istanza di gioco in DeleteMod_Click, try-catch per GameIntegrityWarning, mappatura dei nomi visualizzati |
| `Game.cs` | `ModAPI_Shared\Data\` | Correzione della risposta singola in UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Notifica di modifica di `FilteredMods` all'eliminazione, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 punti di chiamata) |
| `Mod.cs` | `ModAPI\Data\` | Dump XML di intestazione spostato in `detailedOnly`, riepilogo delle discrepanze di checksum |
| `Debug.cs` | `ModAPI_Shared\` | Parametro `detailedOnly`, scrittore a doppio file, commento guida al logging a 4 livelli |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Segnaposto `{0}` per il nome del gioco, sicurezza try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` riscritto con segnaposto per il nome del gioco |

---


</details>

<details>
<summary><b>Modifiche nella v2.0.9619</b></summary>

### Correzioni di Bug

- **Blocco nell'applicazione delle mod con cartella di backup vuota**: `gamefiles\original\` vuota → creazione automatica del backup dal percorso di installazione del gioco prima della lettura dell'assembly
- **Blocco file (IOException) sulle DLL del gioco**: il resolver degli assembly esclude condizionalmente la cartella del gioco quando esiste un backup — impedisce a Cecil di mantenere blocchi di file durante `DirectoryCopy`
- **Ciclo di nuovo tentativo infinito per mod corrotte**: i file `.mod` falliti (intestazione corrotta) causavano un ciclo di riscansione di 1 secondo — ora registrati in `LoadedFiles` per prevenire la riscansione
- **File mod con terminazione di riga LF rifiutati**: l'analizzatore di intestazione `EndsWith("</Mod>\r")` falliva per i file `.mod` in stile Unix — ora usa `TrimEnd` per gestire sia CRLF che LF
- **Fallimento di validazione per DLL piccole**: `Assembly-UnityScript-firstpass.dll` (21 KB) veniva rifiutato da `FileValidator` — dimensione minima dell'assembly ridotta da 64 KB a 8 KB
- **Log WARNING non necessari**: percorsi di gioco non configurati e chiavi di configurazione al primo avvio generavano rumore — parametro `silent` aggiunto a `GetPath`/`GetString`/`GetInt`

### Miglioramenti

- **Rilevamento download di 0 byte**: avviso popup + pulizia dei file temporanei quando il server restituisce un file `.mod` vuoto (`Lang.Windows.DownloadEmpty`)
- **Debounce del salvataggio dello slider**: `ModListWidth` / `ProjectListWidth` viene salvato in `ui.cfg` solo una volta (500 ms dopo la fine del trascinamento) invece che ad ogni cambio di pixel
- **Creazione condizionale delle cartelle di gioco**: le cartelle `mods/` e `projects/` vengono create solo per i giochi con percorsi configurati — non più incondizionatamente per tutti i 5
- **Log diagnostico di analisi dell'intestazione**: mostra il numero di righe e un'anteprima del contenuto in caso di fallimento dell'analisi di un file `.mod`, per facilitare la risoluzione dei problemi

### Nuove Chiavi di Lingua (13 lingue)

| Chiave | Valore inglese |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### File Modificati

| File | Percorso | Modifica |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Creazione automatica del backup, resolver condizionale, fallback alla cartella del gioco |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Fallback alla cartella del gioco per IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Parametro `silent` su GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Protezione da download di 0 byte, debounce dello slider, letture silenziose della configurazione, creazione condizionale delle cartelle |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Prevenzione dei nuovi tentativi per mod corrotte |
| `Mod.cs` | `ModAPI\Data\` | Analisi intestazione LF/CRLF, log diagnostico |
| 13× `Language.XX.xaml` | `resources\langs\` | Chiavi popup `DownloadEmpty` |

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9618</b></summary>


### Aggiunto MODAPI_VersionTool

È stato aggiunto uno strumento WPF autonomo per aggiornare il numero di versione con un solo clic (`VersionTool\MODAPI_VersionTool.csproj`) — vedere la sezione **Version Tool** sopra per i dettagli completi.

- `VersionLabel.Text` ora fa riferimento a `App.Version` invece del `Version.Descriptor` codificato in modo fisso, quindi gli aggiornamenti si riflettono immediatamente nella StatusBar dopo una ricompilazione.

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9617</b></summary>


### Scheda Settings — Aggiunti Pulsanti di Ripristino del Percorso

È stato aggiunto un pulsante **Reset** alla riga del percorso di installazione Steam e a ogni riga del percorso di installazione del gioco.

**Riga del percorso Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Riga del percorso del gioco (per gioco)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamento di Reset**
- Cancella immediatamente la casella di testo del percorso
- Salva un flag di ripristino in `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- La casella di testo rimane vuota dopo il riavvio
- Aggira il problema per cui Configuration XML non persiste le stringhe vuote

**Salvataggio automatico di Browse**
- Prima: era necessario un clic separato su Save dopo Browse
- Dopo: salvataggio automatico alla selezione del file — riflesso anche dopo il passaggio alla scheda Mods

**Nuova chiave di lingua**

| Chiave | Valore |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9616</b></summary>

### Versions.xml — 4 Giochi Aggiunti / Aggiornati

| Gioco | Percorso file | BuildID | Note |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Nuovamente creato |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum aggiornato |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Nuovamente creato |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum aggiornato |

### Regole di Composizione del Checksum

Il formato del checksum differisce a seconda che `Assembly-CSharp-firstpass.dll` esista o meno per ciascun gioco.

| Gioco | firstpass.dll | Formato checksum |
|---|---|---|
| GH | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenati (64 caratteri) |
| Subnautica | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenati (64 caratteri) |
| EscapeThePacific | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenati (64 caratteri) |
| Raft | ❌ Non presente | solo `Assembly-CSharp MD5` (32 caratteri) |

### Procedura di Aggiornamento di Versions.xml al Momento dell'Aggiornamento del Gioco

Aggiungere una nuova voce `<version>` senza rimuovere le voci esistenti.

**Passaggio 1 — Trovare il nuovo BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Gioco | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Passaggio 2 — Estrarre il nuovo checksum**
```powershell
# Giochi con firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenare entrambi i valori Hash in ordine (firstpass prima)

# Giochi senza firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Passaggio 3 — Aggiungere la voce a Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9615</b></summary>

### Corretta l'Espansione del Percorso del Gioco nella Scheda Settings

- **Altezza di espansione della scheda**: la parte inferiore della finestra ora cresce esattamente dell'altezza del campo di input quando si espande una scheda del percorso di gioco
- **Miglioramento di `UpdateWindowHeight()`**: chiama `UpdateLayout()` prima della misurazione di `SizeToContent.Height`; imposta temporaneamente `TextureLayer1` su `Collapsed` quando la texture di sfondo è attiva per evitare che le dimensioni originali di un'immagine 4K influenzino il calcolo dell'altezza
- **Correzione della riga Grid interna**: l'ultima riga del Grid interno del pannello dei percorsi di gioco è stata cambiata da `Height="*"` a `Height="Auto"` — rimuove lo spazio vuoto inutile nella parte inferiore

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9614</b></summary>

### Corretto il Comportamento del Pulsante Massimizza

- **Massimizza**: usa `SystemParameters.WorkArea` per la massimizzazione manuale invece di `WindowState.Maximized` — si adatta esattamente alla risoluzione dello schermo attuale senza sovrapporsi alla barra delle applicazioni
- **Ripristina**: salva `Left`, `Top`, `Width`, `Height` e `MaxWidth` prima della massimizzazione e li ripristina al clic sul pulsante di ripristino
- **Gestione di `MaxWidth`**: impostato su `∞` alla massimizzazione, ripristinato al valore salvato alla normalizzazione

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9613</b></summary>

### Nuova Scheda Themes

L'ordine delle schede è ora:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

L'interfaccia di selezione del tema è stata spostata dalla scheda Settings a una scheda **Themes** dedicata.
Icona: Segoe MDL2 Assets `&#xE790;` (tavolozza)

### Registro dei Temi (Struttura Basata sui Dati)

Aggiungere un nuovo tema ora richiede solo **una riga** nel dizionario `App.xaml.cs`.
Tutte le istruzioni switch sono state rimosse — non sono necessarie modifiche al codice altrove.

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

Gli elementi ComboBox di `ThemeSelector` vengono generati automaticamente dal ciclo `ThemeIds`.
Convenzione delle chiavi di lingua: `Lang.Options.Theme.{PascalCase}` (ad es. `Lang.Options.Theme.Nebula`)

### Temi Supportati

| Indice | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | solo `Dictionary.xaml` | Sfondo con texture originale di ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono chiaro + accento blu |
| 2 | `dark` | `FluentStyles.xaml` | Tono scuro + accento blu (predefinito) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rosso + nero |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Spazio scuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Tramonto luminoso |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano scuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordico luminoso |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumi luminosi |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floreale luminoso |

Il cambio di tema provoca un riavvio automatico dell'applicazione. (salvato in `theme.cfg`)

### Funzionalità Texture di Sfondo

Selezionare un'immagine nella scheda **Background Texture** della scheda Themes per applicarla come sfondo dell'intera applicazione. Funziona con qualsiasi tema selezionato.

**Formati di input supportati**: `.png` / `.jpg` / `.jpeg`, fino a 50 MB, risoluzione 4K o inferiore

**Pipeline di Elaborazione dell'Immagine**

```
Immagine selezionata dall'utente (.png / .jpg / .jpeg, max 50 MB, 4K o inferiore)
  ↓
Compressione JPEG Q75 (buffer di memoria)
  ↓
Inserita intestazione magica di 16 byte
  "MODAPI" + "BG" + versione + riempimento (FF 00 FE 00)
  ↓
Salvata come resources\textures\ui_bg\bg.dat (attributo Hidden)
  ↓
Hash SHA-256 → memorizzato in ui.cfg come TextureHash
```

**Livelli di Sicurezza**

| Livello | Metodo | Effetto |
|---|---|---|
| Intestazione magica | 16 byte anteposti prima della firma JPEG (FF D8 FF) | I visualizzatori esterni non possono riconoscere il file |
| Attributo Hidden | `FileAttributes.Hidden` | Nascosto da Esplora file per impostazione predefinita |
| Integrità SHA-256 | Hash verificato al caricamento | La manomissione attiva un ripristino automatico + popup di avviso |

**Comportamento di Rilevamento della Manomissione**
1. `bg.dat` eliminato
2. Chiavi `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` ripristinate
3. Casella di testo e interruttore ripristinati
4. Popup `Lang.Windows.TextureTampered` mostrato

**Chiavi ui.cfg**

| Chiave | Valore | Descrizione |
|---|---|---|
| `TexturePath` | Nome file (solo visualizzazione) | Nome file originale mostrato nella casella di testo |
| `TextureHash` | Esadecimale SHA-256 | Hash di verifica dell'integrità |
| `TextureActive` | `true` / `false` | Stato di attivazione |

**Elaborazione della Trasparenza**

Quando l'immagine di sfondo è attiva, gli sfondi dell'interfaccia vengono elaborati in due livelli.

- **Livello 1 — Sovrapposizione MergedDictionaries**: i pannelli che fanno riferimento a `{DynamicResource FluentBgBrush}`, ecc., diventano automaticamente trasparenti. Ripristinati con una singola chiamata a `Remove()` alla disattivazione.

  Chiavi target: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Livello 2 — Attraversamento dell'albero visivo (`WalkStyleBackgrounds`)**: gli elementi `{StaticResource}` nei temi Fluent non sono influenzati dal Livello 1, quindi l'albero visivo viene attraversato direttamente per applicare pennelli semi-trasparenti basati sui colori originali.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=completamente trasparente, 255=opaco → 100 ≈ 39% opaco
  ```

  Elaborati: `Panel` (tranne Grid), `Border`, `ListBox` / `ListView`

  Esclusi: `Grid` (sfondo conservato, figli attraversati), `TabPanel` (protezione intestazione scheda), `ButtonBase` / `ComboBox`, elementi `Collapsed`

  Ripristino: origine Setter di stile → `ClearValue()`, origine valore locale XAML → ripristina direttamente il pennello originale

**Cambio Scheda**

Poiché il TabControl WPF carica in modo differito il contenuto delle schede, `WalkStyleBackgrounds(this)` viene rieseguito con priorità `ContextIdle` al cambio scheda. Gli elementi già elaborati vengono saltati tramite un controllo `ContainsKey`.

**Blocco di ThemeSelector**

Quando la texture di sfondo è attiva, un bordo `ThemeSelectorOverlay` viene mostrato sopra il selettore di temi per bloccare l'interazione.

- XAML: bordo `ThemeSelectorOverlay` aggiunto sopra ThemeSelector (`IsHitTestVisible=True`)
- Attivo: `ThemeSelectorOverlay.Visibility = Visible`
- Inattivo: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` è anche protetto dal flag `_textureActive`

**Flusso di Stato dell'Interfaccia**

```
Immagine selezionata (Browse)
  → bg.dat creato → interruttore sbloccato → attivazione automatica → TextureLayer1 mostrato
  → SaveAndClearBrushes() → ThemeSelectorOverlay mostrato

Interruttore disattivato
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay nascosto
  → TextureLayer1 nascosto

Pulsante Clear
  → bg.dat eliminato → interruttore bloccato → TextureLayer1 nascosto → pennelli ripristinati
  → GC.Collect() (libera la memoria dell'immagine 4K)
```

**Nuove Chiavi di Lingua**

| Chiave | Descrizione |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nuovi nomi di temi |
| `Lang.Options.Labels.TextureBackground` | Etichetta texture di sfondo |
| `Lang.Options.Labels.TextureEnable` | Etichetta attivazione |
| `Lang.Options.Labels.TextureClear` | Pulsante Clear |
| `Lang.Windows.TextureTooLarge` | Avviso dimensione file superata |
| `Lang.Windows.TextureTampered` | Avviso manomissione rilevata |

**Struttura dei File**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Scheda Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Logica di tema e texture
├── Themes\
│   ├── Dictionary.xaml            # Tema Classic
│   ├── FluentStyles.xaml          # Tema Dark
│   ├── FluentStylesLight.xaml     # Tema Light
│   ├── FluentStylesDiablo.xaml    # Tema Diablo
│   ├── FluentStylesNebula.xaml    # Tema Nebula
│   ├── FluentStylesSunset.xaml    # Tema Sunset
│   ├── FluentStylesOcean.xaml     # Tema Ocean
│   ├── FluentStylesNordic.xaml    # Tema Nordic
│   ├── FluentStylesCitrus.xaml    # Tema Citrus
│   └── FluentStylesBloom.xaml     # Tema Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Immagine di sfondo compressa e protetta (generata a runtime)
```

**Vincoli di Progettazione Noti**

| Elemento | Dettagli |
|---|---|
| `IsEnabled=false` su ComboBox | Causa un arresto anomalo `ElementNotEnabledException` → utilizzato l'approccio di sovrapposizione `IsHitTestVisible` |
| Sostituzione diretta delle chiavi `MergedDictionaries` | Si arresta in modo anomalo durante il passaggio di layout → solo il pattern `Add`/`Remove` |
| Sovrascrittura di un file nascosto | `Access Denied` → è necessario reimpostare `FileAttributes.Normal` prima della scrittura |
| Sfondi `{StaticResource}` | Non influenzati dal Livello 1 → richiedono WalkStyleBackgrounds (Livello 2) |

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9612</b></summary>

### Separazione del Modulo Temi

- **Nuova cartella `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` e `FluentStylesClassic.xaml` spostati in `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — il tema Classic usa solo `Dictionary.xaml`; i temi Light/Dark/altri Fluent caricano l'XAML corrispondente
- **`ModAPI.csproj`**: percorsi XAML dei temi aggiornati alla sottodirectory `Themes\`; `FluentStylesClassic.xaml` registrato

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9611</b></summary>

### Correzione di Bug

- **Larghezza di Mod List non applicata dopo il cambio di tema**: corretto un problema per cui la larghezza della lista mod non veniva applicata dopo un cambio tra i temi Light/Dark e un riavvio — aggiunta la chiamata `ApplyModListWidth(width)` all'interno di `InitModListWidth()`

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9610</b></summary>

### Aggiunto

#### XML dei Giochi e Configurazione Versions

| # | File | Modifica |
|---|------|--------|
| 1 | `GH.xml` | Riscrittura completa — rimosso `DOTweenPro.dll` inesistente; aggiunti `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Riscrittura completa — rimosso `extends="GenericUnityGame"`; aggiunti `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Riscrittura completa — rimosso `extends="GenericUnityGame"`; `includeAssembly` → solo `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Creato — versione `1.1.01` con checksum |
| 5 | `GH/Versions.xml` | Creato — versione `2.9.5` con checksum |
| 6 | `Subnautica/Versions.xml` | Creato — senza checksum (si aggiorna troppo frequentemente) |

#### Correzioni Critiche di Bug

| # | Tipo | Problema | Correzione |
|---|------|-------|-----|
| 1 | Blocco | `extends="GenericUnityGame"` causava l'ereditarietà di `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` si bloccava | Rimosso `extends` da tutti gli XML non-TheForest |
| 2 | Crash | `ResolutionException: XGamingRuntime.XUserGamertagComponent` durante l'applicazione su Subnautica | Aggiunti `XGamingRuntime.dll`, `XblPCSandbox.dll` a `copyAssembly` |
| 3 | Crash | Il resolver falliva su DLL aggiunte a `copyAssembly` dopo la creazione del backup | `Game.cs`: aggiunta la cartella di installazione effettiva come fallback del resolver |
| 4 | Crash | `IOException`: blocco file di `BaseModLib.dll` tra `CreateModLibrary` e `ApplyMods` | Ciclo di nuovo tentativo: max 10 × 500 ms di lettura + max 30 × 500 ms di attesa di esistenza |
| 5 | Crash | `NullReferenceException` — entry.Value di `typesMap` nullo (gioco non installato) | Aggiunto `if (entry.Value == null) continue` |
| 6 | Crash | `NullReferenceException` — al costruttore `Game` leggero mancava `ModLibrary = new ModLib(this)` → crash di `CreateModLibrary()` | Aggiunto `ModLibrary = new ModLib(this)` al costruttore leggero |
| 7 | Crash | `SwitchDevGame()` — `App.Game.GamePath` vuoto dopo il costruttore leggero → crash di `CreateModLibrary` | Impostato `App.Game.GamePath = savedPath` dopo il costruttore leggero |
| 8 | Gioco errato | Mod di `EscapeThePacific` classificate come TheForest | `ModsViewModel`: `GameId` estratto dal percorso della cartella |
| 9 | Percorso errato | `GetGameFolder()` → `""` → risolto alla radice dell'unità (ad es. `E:\`) | Protezione null/vuoto in tutti i 6 punti di chiamata |

#### Separazione delle Build Debug / Release

- **`FileValidator.cs`** — nuovo file `ModAPI_Shared\Utils\FileValidator.cs`; registrato in `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — intestazione PE (MZ + PE\0\0) + minimo 1 MB
  - `IsValidGameExe()` — intestazione PE + minimo 512 KB
  - `IsValidAssemblyDll()` — intestazione PE + intestazione metadati CLR .NET + minimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` senza Cecil / `#else`: analisi Cecil completa + modifica IL
- **`ModLib.Create()` file non trovato** — `#if DEBUG`: registra avviso, salta / `#else`: registra errore, interrompe

#### Test Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell per `bin\Debug\`; crea file segnaposto di 0 byte per tutti i 5 giochi in `dummy_games\`, `dummy_steam\` e `gamefiles\original\` — consente di testare l'intero flusso di lavoro dell'interfaccia senza un'installazione reale del gioco

#### Scheda Settings

- **Scheda percorso Steam** — integrata nella scheda Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Pannello percorsi gioco** — `BuildGamePathsPanel()` con schede espandibili per gioco; la casella di testo usa `HorizontalAlignment=Stretch`
- Pulsante **Expand All / Collapse All**
- Casella di controllo **AlwaysOnTop** (salvata in `ui.cfg`)
- Slider **Mod/Project List Width** — iniziano al minimo `150`; salvati in `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronizzazione delle caselle di controllo** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions ora si sincronizzano correttamente
- **Flag `_uiInitialized`** — previene scritture premature di `ui.cfg` durante l'avvio di WPF

#### Scheda Mods — Validazione all'Avvio del Gioco

Ad ogni clic su Start Game viene eseguita una validazione in cinque passaggi, indipendentemente dallo stato della lista mod:

| Passaggio | Controllo | Popup |
|---|---|---|
| 1 | Percorso Steam nella scheda Settings valido (`Steam.exe` esiste) | SteamNotFound |
| 2 | Il gioco nella cartella `mods/{GameId}/` corrisponde al gioco configurato in Settings | GameModsMismatch |
| 3 | Almeno una mod selezionata | NoModSelected |
| 4 | Nessuna mescolanza di mod di giochi diversi nella selezione | MixedGameMods |
| 5 | Percorso del gioco configurato + eseguibile esistente | GamePathNotSet / GameNotInstalled |

#### Scheda Development — Validazione ModLib

Validazione in tre passaggi al clic su Mod Library Regeneration:

| Passaggio | Controllo | Popup |
|---|---|---|
| 1 | Percorso Steam nella scheda Settings valido | SteamNotFound |
| 2 | Almeno un progetto esistente | NoProjectWarning |
| 3 | `App.Game.GamePath` impostato | GamePathNotSet |

#### Scheda Downloads
- Stringa di debug sostituita con `Lang.Downloads.Status.NoDownloads`
- Padding coerente per tutti i messaggi di stato
- Testo manuale offline aggiornato per i 5 giochi supportati; interruzione di riga tramite due TextBlock

#### First Setup e Sistema di Percorso del Gioco
- `FirstSetup.Check()` — valore predefinito `true` per `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crea le cartelle `mods/` e `projects/` per tutti i 5 giochi
- `SpecifyGamePath` — `GameNameLabel` mostra di quale gioco si tratta; `NavigateToSettings()` reindirizza alla scheda Settings

#### Chiavi di Lingua Nuove/Aggiornate

| Chiave | Valore inglese |
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

### Non Incluso

| Funzionalità | Motivo |
|---|---|
| Aggiornamento automatico (mantenere l'ultima versione) | Infrastruttura lato server non disponibile |
| Ricerca di aggiornamenti | Infrastruttura lato server non disponibile |

### Rimosso

| Elemento | Motivo |
|---|---|
| Popup `SpecifyGamePath` all'avvio | Tutti i percorsi sono configurati nella scheda Settings |
| Popup `SpecifySteamPath` all'avvio | Il percorso Steam è configurato nella scheda Settings |
| Sistema di login | Il server originale non è più operativo (rimosso in v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Non funziona su Mono 2.0 (rimosso in v2.0.9586) |
| Condizione `UseSteam` nel controllo Steam | Steam viene ora sempre convalidato per primo in Start Game e Mod Library Regeneration |

## Pianificato per le Prossime Versioni

| # | Funzionalità | Descrizione |
|---|---|---|
| 1 | Aggiornamento automatico di ModAPI | Scaricare e applicare automaticamente le nuove versioni di ModAPI |
| 2 | Aggiornamento della tabella VersionsData di ModAPI | Aggiornare automaticamente la tabella VersionsData del gioco quando vengono rilasciate nuove patch |

---

</details>

<details>
<summary><b>Modifiche nella v2.0.9600</b></summary>

### Aggiunto

- **Scheda Downloads**: 5 filtri gioco (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Scheda Welcome**: aggiunta nella posizione più a sinistra (indice 0)
- **Scheda Mods**: layout a 3 colonne (WrapPanel → lista verticale); regolazione automatica della larghezza; a capo dei nomi mod
- **`ModsViewModel`**: filtraggio specifico per gioco, `ResolveGame()` per l'istanza `Game` corretta per mod
- **`Game.cs`**: costruttore leggero `new Game(config, true)` — solo identificazione, senza `Verify()`
- **Compilazione**: 4 file XML di gioco registrati in `ModAPI.csproj` con `CopyToOutputDirectory=Always`
- **Compilazione**: avvisi ripuliti — CS0168, CS0618, CS0252
- **XML di gioco**: liste DLL di TheForest, Raft, GH corrette
- **Bandiere lingua**: dimensioni immagine standardizzate su tutti i 13 badge lingua

### Rimosso

| Elemento | Motivo |
|---|---|
| `extends="GenericUnityGame"` nei file XML di gioco | Causava l'ereditarietà errata di `Assembly-CSharp-firstpass.dll` — rimosso da Subnautica, Raft, EscapeThePacific, GH |
| Layout `WrapPanel` nella scheda Mods | Sostituito con un layout Grid a 3 colonne (Game Filter / Mod List / Information) |

---

</details>

---

## Cronologia delle Versioni

<details>
<summary><b>Fase 6-3 — Espansione del Sistema Temi, Miglioramenti delle Impostazioni, Stabilità e Strumenti</b></summary>

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool e correzioni principali**
- MODAPI_LangTool aggiunto (strumento WPF autonomo per la gestione delle lingue)
- Correzione SSL/TLS (TLS 1.2)
- Correzione delle impostazioni locali francesi (`CultureInfo.InvariantCulture`)
- Correzione di `GamePathNotSet` per Green Hell
- SelectGameDialog (filtro All + avvio multi-gioco di mod)
- Blocco tramite MixedGameMods rimosso
- Controllo di integrità del gioco a 3 livelli (intestazione PE / checksum assembly / firma digitale)
- Separazione dei log sviluppatore e utente
- 12 log UpdateVersions + 7 log FindMods + 10 log StartGame
- URL Raw di GitHub come `VersionUpdateDomains` principale
- Checksum di `Versions.xml` di GH corretto
- `1.12` aggiunto a `Versions.xml` di TheForest
- 515 chiavi in tutti i 13 file di lingua

**Correzioni aggiuntive (2026-06-21)**
- Corretto l'ordine di validazione StartGame (Steam → percorso gioco → mod)
- Il popup di selezione gioco ora elenca correttamente i giochi con percorso non configurato
- Corretta la risposta singola in UpdateVersions (niente più checksum duplicati)
- `DeleteMod` ora risolve la propria istanza di gioco della mod invece del filtro attivo
- Le mod eliminate non lasciano più un badge "Selected" obsoleto al riscaricamento
- La lista mod ora si aggiorna immediatamente all'eliminazione, sotto qualsiasi filtro di gioco
- Popup `GameIntegrityWarning` rafforzato contro i crash da eccezioni non gestite
- Il messaggio di avviso sulla firma digitale ora nomina il gioco e chiarisce che è previsto per i titoli indie
- Il sistema di logging a due file (`ModAPI.log` / `ModAPI.detailed.log`) sostituisce i log limitati da `#if DEBUG`, in modo che le build Release possano comunque catturare tutti i dettagli diagnostici senza sovraccaricare il log orientato all'utente

### v2.0.9619 — 2026-05-25

- Creazione automatica del backup dal percorso di installazione del gioco
- Corretto il blocco file (resolver condizionale)
- Prevenzione del ciclo infinito per mod corrotte
- Compatibilità con mod con terminazione di riga LF
- Rilevamento download di 0 byte con popup
- Debounce del salvataggio dello slider (500 ms)
- Creazione condizionale delle cartelle di gioco
- Dimensione minima dell'assembly in `FileValidator` ridotta da 64 KB a 8 KB
- Parametro `silent` su `GetPath`/`GetString`/`GetInt`
- Log diagnostico di analisi dell'intestazione
- Chiavi di lingua `DownloadEmpty` (13 lingue)

### v2.0.9618 — 2026-04-25
Aggiunto MODAPI_VersionTool (strumento WPF autonomo per l'aggiornamento della versione), visualizzazione versione nella StatusBar collegata ad App.Version

### v2.0.9617 — 2026-04-24
Aggiunti pulsanti di ripristino percorso Steam/gioco nella scheda Settings, salvataggio automatico di Browse, stato di ripristino preservato tramite flag ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml creato/aggiornato per 4 giochi (Subnautica, Raft, EscapeThePacific, GH), regole di composizione del checksum stabilite, procedura di aggiornamento del gioco documentata

### v2.0.9615 — 2026-04-18
Corretta la precisione dell'altezza di espansione della scheda del percorso di gioco nella scheda Settings, prevenuta l'interferenza di UpdateWindowHeight con la texture di sfondo

### v2.0.9614 — 2026-04-18
Massimizzazione manuale del pulsante Massimizza basata su WorkArea, salvataggio e ripristino della dimensione/posizione precedente

### v2.0.9613 — 2026-04-18
Aggiunta la scheda Themes, struttura del registro temi basata sui dati, supportati 10 temi, funzionalità texture di sfondo (compressione, sicurezza, trasparenza a 2 livelli), sovrapposizione di blocco ThemeSelector, 12 nuove chiavi di lingua

### v2.0.9612 — 2026-04-18
Separazione della cartella Themes/, modularizzazione XAML dei temi

### v2.0.9611 — 2026-04-18
Corretto: larghezza di Mod List non applicata dopo il cambio di tema

</details>

<details>
<summary><b>Fase 6-2 — Impostazioni, Sicurezza, Correzioni di Crash e Separazione Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- XML multi-gioco corretto (GH, Subnautica, EscapeThePacific)
- Aggiunto `Versions.xml`
- Scheda Settings riprogettata (percorso Steam, pannello percorsi gioco, slider larghezza, dimensione carattere, sincronizzazione caselle di controllo)
- Sicurezza null del percorso gioco (6 punti)
- Popup di avvio sostituiti dalla scheda Settings
- Validazione in 5 passaggi dell'avvio gioco nella scheda Mods (Steam sempre per primo)
- Validazione ModLib in 3 passaggi nella scheda Dev
- Aggiunto popup `GameModsMismatch`
- Corretto il null di `ModLibrary` nel costruttore leggero
- Corretto `GamePath` in `SwitchDevGame`
- Verifica dell'intestazione PE di `FileValidator` (Release)
- Separazione build `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- `ui.cfg` persistente
- Sistema carattere a 5 chiavi
- Molteplici correzioni di crash
- Chiavi di lingua aggiornate

</details>

<details>
<summary><b>Fase 6-1 — Multi-Gioco e Riprogettazione delle Mod</b></summary>

### v2.0.9600 — 2026-04-09
> 5 filtri gioco, layout a 3 colonne nella scheda Mods, larghezza automatica, costruttore `Game` leggero, filtraggio gioco in `ModsViewModel`, 4 file XML registrati, avvisi di compilazione ripuliti, scheda Welcome, bandiere lingua standardizzate

</details>

<details>
<summary><b>Fase 5-6B — C# 7.3 e Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Corretta schermata nera, polyfill finalizzato, ValueTuple rimosso, C# 7.3 verificato

</details>

<details>
<summary><b>Fase 5-5 — Risoluzione degli Assembly</b></summary>

### v2.0.9561 — 2026-03-06
> Supporto C# 7.3, patching intestazione PE, pipeline polyfill, risoluzione assembly ripristinata

</details>

<details>
<summary><b>Fase 5-1 — Scheda Downloads e 13 Lingue</b></summary>

### v2.0.9552 — 2026-02-25
> Scheda Downloads, modernizzazione icone, unificazione temi, supporto per 13 lingue

</details>

<details>
<summary><b>Fasi Precedenti</b></summary>

### Fase 3 — Riprogettazione dell'Interfaccia e Sistema Temi
v2.0.9500
> Sistema temi (Classic/Light/Dark), interfaccia Fluent Design, sistema SubWindow

### Fase 4 — Pulizia del Codice
v2.0.9400
> Pulizia del codice, rimozione del login, modernizzazione del codice legacy

### Fase 2 — Ambiente di Compilazione e Fluent Design
v2.0.9300
> Ambiente di compilazione, DLL stub UnityEngine, integrazione ModernWpf

### Fase 1 — Migrazione a .NET 4.8
v2.0.9200
> Migrazione a .NET Framework 4.8

### v1.x
Versione originale di FluffyFish

</details>

---

## Requisiti di Compilazione

| Requisito | Versione | Note |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Progetti ModAPI |
| .NET Framework SDK | 3.5 | Solo BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licenza

GNU General Public License v3.0 — segue la licenza originale.
