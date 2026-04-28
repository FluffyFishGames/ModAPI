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

**Strumento di Gestione Mod di The Forest — Edizione Aggiornata**

> Originale: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germania)
> Aggiornamento: zzangae (Repubblica di Corea)

---

## Panoramica

ModAPI è un'applicazione desktop per la gestione dei mod di **5 giochi ufficialmente supportati**. Questa edizione aggiornata include supporto multi-gioco, una scheda Impostazioni completamente riprogettata, configurazione del percorso Steam, impostazioni UI persistenti, sistema di dimensione del carattere dinamico, validazione dell'avvio del gioco, separazione build Debug/Release e numerose correzioni di crash verificate in gioco.

---

## Giochi Supportati

| Gioco | Motore | Versione | Steam ID | Eseguibile |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 5 (aggiornato da Unity 4) |
| Ultima Versione | v1.12 (VR) |
| Ultimo Aggiornamento | 11 settembre 2019 — patch supporto VR; nessun ulteriore aggiornamento di contenuto importante |
| Eseguibile | `TheForest.exe` |
| Cartella Dati | `TheForest_Data/Managed/` |
| Cartella Mod | `mods/TheForest/` |
| Cartella Progetti | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — completamente supportato |

The Forest è stato aggiornato da Unity 4 a Unity 5, migliorando significativamente la grafica e la fisica. La patch VR di settembre 2019 è stato l'ultimo aggiornamento importante. Il gioco rimane in uno stato stabile e finalizzato — ideale per il modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity (base di codice integrata, unificata con Below Zero nel 2022) |
| Ultima Versione | 2025 Patch (v18810395) |
| Ultimo Aggiornamento | 12 agosto 2025 — correzioni di bug e miglioramenti delle prestazioni con il rilascio mobile |
| Eseguibile | `Subnautica.exe` |
| Cartella Dati | `Subnautica_Data/Managed/` |
| Cartella Mod | `mods/Subnautica/` |
| Cartella Progetti | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — supportato |

Originariamente costruito su Unity 5, Subnautica ha ricevuto l'aggiornamento 'Living Large' (v2.0) alla fine del 2022 che ha unificato la base di codice del motore con Below Zero per ottimizzazione e stabilità migliorate. Nota: il prossimo *Subnautica 2* utilizza Unreal Engine 5.

> **XML riscritto in v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` aggiunti a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity |
| Ultima Versione | v1.1.02 (Beta) / v1.09 (Stabile) |
| Ultimo Aggiornamento | Marzo 2026 — correzioni chat vocale e multiplayer tramite ramo beta |
| Eseguibile | `Raft.exe` |
| Cartella Dati | `Raft_Data/Managed/` |
| Cartella Mod | `mods/Raft/` |
| Cartella Progetti | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — supportato |
| Versions.xml | `1.1.01` (con checksum) |

Dopo la conclusione ufficiale della storia in v1.0: *The Final Chapter*, le patch sono continuate per miglioramenti del codice di rete e stabilità.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 6 (migrato da Unity 2021/2022 alla fine del 2025) |
| Ultima Versione | v0.67.0.0 |
| Ultimo Aggiornamento | 26 giugno 2025 — rielaborazione distribuzione isole e aggiornamento motore; hotfix in corso fino al 2026 |
| Eseguibile | `EscapeThePacific.exe` |
| Cartella Dati | `EscapeThePacific_Data/Managed/` |
| Cartella Mod | `mods/EscapeThePacific/` |
| Cartella Progetti | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — supportato |

Completata una ricostruzione importante del sistema e migrazione a Unity 6 alla fine del 2025, abilitando ambienti più dinamici. Il gioco rimane in sviluppo attivo di Accesso Anticipato.

> **XML riscritto in v2.0.9610**: `extends="GenericUnityGame"` rimosso; `includeAssembly` impostato solo su `Assembly-CSharp.dll` — previene errori di ereditarietà di `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Elemento | Valore |
|---|---|
| Motore | Unity 2019 |
| Ultima Versione | v2.9.5 |
| Ultimo Aggiornamento | 4 febbraio 2026 — ottimizzazione Steam Deck e miglioramenti leggibilità del testo |
| Eseguibile | `GH.exe` |
| Cartella Dati | `GH_Data/Managed/` |
| Cartella Mod | `mods/GH/` |
| Cartella Progetti | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — supportato |
| Versions.xml | `2.9.5` (con checksum) |

Sviluppato con aggiornamenti progressivi del motore Unity 2017 → 2018 → 2019. L'hotfix di febbraio 2026 si è concentrato sulla compatibilità con Steam Deck e la leggibilità del testo dell'UI.

> **XML riscritto in v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` aggiunti; `DOTweenPro.dll` inesistente rimosso.
</details>

---

## Architettura

### Separazione del Tempo di Esecuzione

| Componente | Obiettivo | Tempo di Esecuzione | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Applicazione desktop, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Libreria condivisa |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fissato permanentemente** — l'header PE deve contenere `v2.0.50727` |
| DLL Mod (utente) | .NET Framework 4.8 | Game Mono 2.0 (patchato) | Compilato con 4.8, header PE patchato all'applicazione |

### Separazione di Compilazione Debug / Release

Tutte le validazioni dei file e l'elaborazione degli assembly si ramificano in base alla configurazione di compilazione tramite `#if DEBUG` / `#else`.

| Posizione | Compilazione Debug | Compilazione Release |
|---|---|---|
| `CheckSteam()` | Solo `File.Exists()` — i file fittizi passano | `FileValidator.IsValidSteamExe()` — header PE + min 1 MB |
| `CheckGamePath()` | Solo `File.Exists()` — i file fittizi passano | `FileValidator.IsValidAssemblyDll()` — header PE + metadati CLR + min 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — analisi Cecil omessa | Analisi completa Mono.Cecil + modifica IL + `module.Write()` |
| `ModLib.Create()` — file non trovato | Registrare avviso, saltare e continuare | Registrare errore, interrompere con popup |

**I test Debug** usano `create_dummy_Debug_games.ps1` per generare file di 0 byte sotto `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` e `bin\Debug\gamefiles\original\`. Questi superano i controlli `File.Exists()` e permettono test completi del flusso di lavoro dell'UI senza installazione reale del gioco.

**Le compilazioni Release** applicano `FileValidator` (verifica header PE + metadati CLR .NET) per rifiutare file di 0 byte, file di testo e binari arbitrari. Solo gli eseguibili Windows validi e gli assembly .NET passano.

### FileValidator — Verifica dell'Header PE

`ModAPI_Shared\Utils\FileValidator.cs` — applicato solo nelle compilazioni Release.

| Metodo | Verifiche | Dimensione Min. |
|---|---|---|
| `IsValidSteamExe(path)` | Firma MZ + firma PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Firma MZ + firma PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + header metadati CLR (directory dati #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline di Rimappatura degli Assembly

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

### Fallback del Risolutore di Assembly

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Supporto delle Funzionalità C# 7.3

| Funzionalità | Stato | Note |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ | Verificato in gioco |
| Interpolazione di stringhe (`$""`) | ✅ | Verificato in gioco |
| Variabile `out` inline | ✅ | Verificato in gioco |
| `async` / `await` | ✅ | Tramite AsyncBridge + polyfill System.Threading |
| Tuple (`ValueTuple`) | ❌ Limite assoluto | ABI `mscorlib` Mono 2.0 — nessuna soluzione |

### Theme System

A partire da v2.0.9613, l'interfaccia di selezione dei temi è stata spostata dalla scheda Settings a una **scheda Themes** dedicata. Per aggiungere un nuovo tema basta una sola riga nel dizionario di `App.xaml.cs`.

| Indice | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` solo | Sfondo texture originale ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono chiaro + accento blu |
| 2 | `dark` | `FluentStyles.xaml` | Tono scuro + accento blu (predefinito) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rosso + nero |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Spazio scuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Tramonto luminoso |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano scuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordico luminoso |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumi luminoso |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floreale luminoso |

Le modifiche al tema attivano un riavvio automatico dell'app. (salvato in `theme.cfg`)

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

### Texture di Sfondo

Selezionare un'immagine nella scheda **Background Texture** della scheda Themes per applicarla come sfondo dell'intera applicazione. Formati supportati: `.png` / `.jpg` / `.jpeg`, max 50MB, risoluzione 4K o inferiore. L'immagine viene compressa come JPEG Q75 con un header magico di 16 byte e salvata come `resources\textures\ui_bg\bg.dat` (attributo Hidden). Hash SHA-256 per la verifica dell'integrità; al rilevamento di manomissione, reset automatico + popup di avviso.

Quando lo sfondo è attivo, la trasparenza dell'UI viene elaborata in due livelli: Layer 1 (overlay MergedDictionaries) per i pannelli `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) per i pannelli basati su `{StaticResource}` con semi-trasparenza.

### Sistema di Dimensione del Carattere

| Chiave Risorsa | Base | Descrizione |
|---|---|---|
| `AppBaseFontSize` | 13 | Testo normale |
| `AppBaseHeaderFontSize` | 16 | Intestazioni, titoli di pannello |
| `AppBaseSmallFontSize` | 12 | Etichette secondarie |
| `AppBaseTinyFontSize` | 10 | Testo suggerimento |
| `AppBaseLargeFontSize` | 20 | Testo di visualizzazione grande |

### Configurazione Persistente dell'UI — `ui.cfg`

| Chiave | Predefinito | Descrizione |
|-----|---------|-------------|
| `ModListWidth` | `150` | Larghezza lista mod (px) |
| `ProjectListWidth` | `150` | Larghezza lista progetti (px) |
| `AppFontSize` | `13` | Dimensione carattere globale UI (px) |
| `AlwaysOnTop` | `false` | Finestra sempre in primo piano |
| `TexturePath` | *(nessuno)* | Nome file originale texture di sfondo (solo visualizzazione) |
| `TextureHash` | *(nessuno)* | Hash SHA-256 texture di sfondo |
| `TextureActive` | `false` | Stato di attivazione texture di sfondo |
| `GamePathReset_{GameId}` | *(nessuno)* | Flag di reset percorso gioco |
| `SteamPathReset` | *(nessuno)* | Flag di reset percorso Steam |

### Struttura dei File

```
ModAPI/
├── App.xaml / App.xaml.cs              # Registro temi, ID temi, applicazione tema
├── ui.cfg                               # Impostazioni UI persistenti
├── theme.cfg                            # Tema corrente
├── Windows/
│   ├── MainWindow.xaml / .cs            # UI principale — 6 schede, Temi, Impostazioni, percorso Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup percorso gioco (GameNameLabel dinamico)
│       ├── FirstSetup.xaml / .cs        # Configurazione iniziale + inizializzazione predefinita
│       └── (14 altre sotto-finestre)
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
│   ├── Game.cs                          # Patching assembly, guardie null, fallback del risolutore
│   ├── ModLib.cs                        # Generazione BaseModLib + rimappatura (#if DEBUG separazione)
│   ├── Models/
│   │   └── ModProject.cs                # Creazione/compilazione/applicazione progetto + guardie null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Mod filtrati, mod selezionato, filtro gioco selezionato
│   │   ├── ModViewModel.cs              # GameId dal percorso cartella
│   │   ├── ModProjectsViewModel.cs      # Dispose() per DispatcherTimer
│   │   └── SettingsViewModel.cs         # Predefinito true per UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mappatura versioni assembly Mono 2.0 (20 assembly)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Risolutore basato su nome con cache
│   └── MonoHelper.cs                    # Utilità helper IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 file di lingua
│   └── textures/ui_bg/
│       └── bg.dat                       # Immagine di sfondo compressa e protetta (generata a runtime)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Riscrittura completa v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Riscrittura completa v2.0.9610
    │   ├── GH.xml                       # Riscrittura completa v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — non supportato
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Costruttore leggero + correzione inizializzazione ModLibrary
│   └── ModLib.cs                        # Separazione #if DEBUG per analisi Cecil
└── Utils/
    └── FileValidator.cs                 # Validazione header PE + metadati CLR (solo Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Strumento autonomo di aggiornamento versione WPF

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Genera struttura fittizia gioco/Steam
├── dummy_games\{GameId}\               # Percorsi fittizi di installazione giochi
├── dummy_steam\Steam.exe               # Eseguibile Steam fittizio
└── gamefiles\original\{GameId}\        # Percorsi fittizi di backup per ModLib
```

---

## Installazione e Configurazione

### Passo 1 — Prerequisiti

| Elemento | Richiesto |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstallato su Windows 11; [scarica](https://dotnet.microsoft.com/download/dotnet-framework/net48) per Windows 10) |
| Steam | Richiesto — deve essere configurato nella scheda Settings |
| Almeno un gioco supportato | Richiesto — deve essere configurato nella scheda Settings |

### Passo 2 — Installare ModAPI

1. Scaricare l'ultima versione da GitHub
2. Estrarre in una cartella qualsiasi (es. `C:\ModAPI\`)
3. Eseguire `ModAPI.exe`
4. Al primo avvio appare la schermata **Welcome** — configurare le preferenze e cliccare su **Continue**

### Passo 3 — Configurare il percorso Steam (scheda Settings)

1. Andare alla scheda **Settings**
2. Trovare **Steam Installation Path**
3. Cliccare su **Browse** → selezionare `Steam.exe`
4. Cliccare su **Save**

### Passo 4 — Configurare i percorsi dei giochi (scheda Settings)

1. Cliccare sull'intestazione della scheda di un gioco per espanderla
2. Cliccare su **Browse** → selezionare la cartella radice del gioco (dove si trova il `.exe`)
3. Cliccare su **Save**

| Gioco | Eseguibile | Percorso di Esempio |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Passo 5 — Scaricare Mod (scheda Downloads)

1. Andare alla scheda **Downloads**
2. Selezionare un gioco dal filtro giochi
3. Cercare un mod e cliccare su **Download**

> **Offline**: Scaricare i file `.mod` manualmente da `modapi.survivetheforest.net` e posizionarli nella cartella corrispondente:

| Gioco | Cartella |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Passo 6 — Applicare i Mod e Avviare il Gioco (scheda Mods)

1. Andare alla scheda **Mods**
2. Selezionare un gioco dal **Filtro Giochi** (Colonna 0)
3. Attivare i mod nella **Lista Mod** (Colonna 1)
4. Cliccare su **Start Game**

I seguenti controlli vengono eseguiti automaticamente prima dell'avvio:

| # | Controllo | Popup di Errore |
|---|---|---|
| 1 | Percorso Steam configurato e valido | SteamNotFound |
| 2 | Gioco nella cartella `mods/` corrisponde al percorso in Settings | GameModsMismatch |
| 3 | Almeno un mod selezionato | NoModSelected |
| 4 | Nessun mod di giochi misti nella selezione | MixedGameMods |
| 5 | Percorso del gioco configurato e eseguibile esiste | GamePathNotSet / GameNotInstalled |

---

## Panoramica delle Schede

### Scheda Welcome
Schermata di configurazione iniziale (indice scheda 0). Configurare AutoUpdate, connessione Steam e preferenze della tabella VersionsData. Nei lanci successivi questa scheda fornisce link della community e note di rilascio.

### Scheda Mods
Flusso di lavoro principale per la gestione dei mod — layout a 3 colonne:

| Colonna | Contenuto |
|---|---|
| Colonna 0 | Filtro Giochi — pulsanti radio per 5 giochi supportati |
| Colonna 1 | Lista Mod — mod installati con selettore di versione e casella di attivazione |
| Colonna 2 | Informazioni — dettagli del mod selezionato, descrizione, cronologia versioni |

### Scheda Downloads
Sfogliare e scaricare mod da `modapi.survivetheforest.net`.

- **Filtro giochi**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Filtro categorie**: 12 categorie (Bugfixes, Balancing, Cheats, …)
- **Ricerca**: per nome mod, descrizione o autore
- **Modalità offline**: mostra le istruzioni delle cartelle per tutti i 5 giochi supportati

### Scheda Development
Flusso di lavoro per lo sviluppo di mod — il pannello filtro giochi (Colonna 0) copre tutti i 5 giochi supportati.

- Creare, compilare e applicare progetti mod per gioco
- Gestione delle risorse linguistiche
- Generazione ModLib con validazione in 3 passaggi (Steam → progetto → percorso gioco)
- Cambio gioco sicuro tramite costruttore leggero `Game` (senza chiamata `Verify()`)

### Scheda Themes
Selezione dei temi e gestione delle texture di sfondo.

- **Selezione tema**: 10 temi (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Texture di sfondo**: Selezionare un'immagine come sfondo dell'intera applicazione (compressione JPEG + elaborazione di sicurezza)
- Quando la texture di sfondo è attiva, la selezione del tema è bloccata

### Scheda Settings
Configurazione centralizzata — 4 righe:

| Riga | Contenuto |
|---|---|
| 0 | Lingua / Dimensione carattere / Tema / Larghezza massima / Larghezza lista mod / Larghezza lista progetti |
| 1 | Mantieni VersionsData / Aggiornamento auto / Connessione Steam / Sempre in primo piano |
| 2 | Percorso di installazione Steam (TextBox + Sfoglia + Salva + Reimposta) |
| 3 | Percorsi di installazione giochi — scheda espandibile per gioco (TextBox + Sfoglia + Salva + Reimposta) |

---

## Modifiche in v2.0.9618

### Strumento di Aggiornamento Versione (MODAPI_VersionTool)

Uno strumento WPF autonomo per aggiornare il numero di versione con un singolo clic.

**Posizione**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Funzionalità**
- Visualizza automaticamente la versione corrente (letta da `App.xaml.cs`)
- Inserire una nuova versione e fare clic su **Apply Version** per aggiornare entrambi i file simultaneamente
- Validazione formato: accettato solo il formato `X.X.XXXX`

**File Modificati**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Utilizzo**
1. Run `MODAPI_VersionTool.exe`
2. Enter new version (e.g. `2.0.9619`)
3. Click **Apply Version**
4. Rebuild the ModAPI solution in Visual Studio

### Correzione Visualizzazione Versione StatusBar

- `VersionLabel.Text` now references `App.Version` instead of the hardcoded `Version.Descriptor`
- Updating the version with VersionTool and rebuilding now reflects immediately in the StatusBar

---

## Modifiche in v2.0.9617

### Scheda Settings — Pulsanti Reset Percorso Aggiunti

Un pulsante **Reset** è stato aggiunto al percorso di installazione di Steam e a ogni riga di percorso di installazione del gioco.

**Riga percorso Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Riga percorso gioco (per gioco)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamento del reset**
- Cancella immediatamente il TextBox del percorso
- Salva un flag di reset in `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Il TextBox rimane vuoto dopo il riavvio
- Aggira la limitazione di Configuration XML che non salva stringhe vuote

**Auto-salvataggio Browse**
- Prima: richiedeva un clic separato sul pulsante Save dopo Browse
- Dopo: salvataggio automatico alla selezione del file — reflected even after switching to the Mods tab

**Nuova chiave di lingua**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## Modifiche in v2.0.9616

### Versions.xml — 4 Giochi Aggiunti / Aggiornati

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Newly created |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum updated |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Newly created |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum updated |

### Regole di Composizione Checksum

Il formato del checksum varia a seconda che `Assembly-CSharp-firstpass.dll` exists for each game.

| Game | firstpass.dll | Checksum Format |
|---|---|---|
| GH | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| Subnautica | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| EscapeThePacific | ✅ Present | `firstpass MD5` + `Assembly-CSharp MD5` concatenated (64 chars) |
| Raft | ❌ Not present | `Assembly-CSharp MD5` only (32 chars) |

### Procedura di Aggiornamento Versions.xml

Aggiungere una nuova voce `<version>` senza rimuovere le voci esistenti.

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

## Modifiche in v2.0.9615

### Correzione Espansione Percorso Gioco nella Scheda Settings

- **Card expand height**: The window bottom now grows by exactly the height of the input field when expanding a game path card
- **`UpdateWindowHeight()` improved**: Calls `UpdateLayout()` before `SizeToContent.Height` measurement; temporarily sets `TextureLayer1` to `Collapsed` when background texture is active to prevent 4K image original size from affecting height calculation
- **Inner Grid Row fix**: Changed the last Row of the game paths panel inner Grid from `Height="*"` to `Height="Auto"` — removes unnecessary bottom whitespace

---

## Modifiche in v2.0.9614

### Correzione Comportamento Pulsante Massimizza

- **Maximize**: Uses `SystemParameters.WorkArea` for manual maximization instead of `WindowState.Maximized` — fits exactly to the current screen resolution without overlapping the taskbar
- **Restore**: Saves `Left`, `Top`, `Width`, `Height`, and `MaxWidth` before maximizing and restores them when the restore button is clicked
- **`MaxWidth` handling**: Set to `∞` on maximize, restored to saved value on normalize

---

## Modifiche in v2.0.9613

### Nuova Scheda Themes

L'ordine delle schede è ora:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

L'interfaccia di selezione temi è stata spostata dalla scheda Settings a una **scheda Themes** dedicata.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Registro Temi (Struttura Guidata dai Dati)

L'aggiunta di un nuovo tema richiede ora solo **una riga** in the `App.xaml.cs` dictionary.
Tutte le istruzioni switch sono state rimosse — nessuna modifica del codice necessaria altrove.

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

### Temi Supportati

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

Le modifiche al tema attivano un riavvio automatico dell'app. (saved to `theme.cfg`)

### Funzione Texture di Sfondo

Selezionare un'immagine nel riquadro **Background Texture** della scheda Themes per applicarla come sfondo dell'intera applicazione. Funziona con qualsiasi tema selezionato.

**Formati di input supportati**: `.png` / `.jpg` / `.jpeg`, up to 50MB, 4K resolution or below

**Pipeline di elaborazione immagine**

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

**Livelli di sicurezza**

| Layer | Method | Effect |
|---|---|---|
| Magic header | 16 bytes prepended before JPEG signature (FF D8 FF) | External viewers cannot recognize the file |
| Hidden attribute | `FileAttributes.Hidden` | Hidden from Explorer by default |
| SHA-256 integrity | Hash verified on load | Tampering triggers automatic reset + warning popup |

**Comportamento al rilevamento di manomissione**
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

**Elaborazione trasparenza**

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

**Cambio scheda**

WPF TabControl lazy-loads tab content, so `WalkStyleBackgrounds(this)` is re-run at `ContextIdle` priority on tab change. Already-processed elements are skipped via `ContainsKey` check.

**Blocco ThemeSelector**

When background texture is active, a `ThemeSelectorOverlay` Border is shown over the theme selector to block interaction.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` also guarded by `_textureActive` flag

**Flusso stato UI**

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

**Nuove chiavi di lingua**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**Struttura file**

```
ModAPI\
├── App.xaml.cs                    # Registro temi, ID temi, applicazione tema
├── Windows\
│   ├── MainWindow.xaml            # Scheda Themes, overlay selettore tema, livello texture 1
│   └── MainWindow.xaml.cs         # Logica tema e texture
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

**Vincoli di progettazione noti**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Direct `MergedDictionaries` key replacement | Crashes during layout pass → `Add`/`Remove` pattern only |
| Overwriting Hidden file | `Access Denied` → must reset `FileAttributes.Normal` before writing |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## Modifiche in v2.0.9612

### Separazione Modulo Temi

- **New `Themes/` folder**: Moved `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml`, and `FluentStylesClassic.xaml` to `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — Classic theme uses `Dictionary.xaml` only; Light/Dark/other Fluent themes load corresponding XAML
- **`ModAPI.csproj`**: Updated theme XAML paths to `Themes\` subdirectory; registered `FluentStylesClassic.xaml`

---

## Modifiche in v2.0.9611

### Correzione Bug

- **Mod list width not applied after theme switch**: Fixed an issue where the Mod list width was not applied after switching between Light/Dark themes and restarting — added `ApplyModListWidth(width)` call inside `InitModListWidth()`

---

---

## Modifiche in v2.0.9610

### Aggiunto

#### Configurazione XML Giochi e Versioni

| # | File | Modifica |
|---|------|--------|
| 1 | `GH.xml` | Riscrittura completa — rimosso l'inesistente `DOTweenPro.dll`; added `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Riscrittura completa — rimosso `extends="GenericUnityGame"`; added `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Riscrittura completa — rimosso `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Creato — versione `1.1.01` with checksum |
| 5 | `GH/Versions.xml` | Creato — versione `2.9.5` with checksum |
| 6 | `Subnautica/Versions.xml` | Creato — senza checksum (aggiornamenti troppo frequenti) |

#### Correzioni di Bug Critici

| # | Tipo | Problema | Correzione |
|---|------|-------|-----|
| 1 | Blocco | `extends="GenericUnityGame"` caused `Assembly-CSharp-firstpass.dll` inheritance → `CreateModLibrary` stalled | Removed `extends` from all non-TheForest XML |
| 2 | Crash | `ResolutionException: XGamingRuntime.XUserGamertagComponent` during Subnautica apply | Added `XGamingRuntime.dll`, `XblPCSandbox.dll` to `copyAssembly` |
| 3 | Crash | Il risolutore ha fallito on DLLs added to `copyAssembly` after backup created | `Game.cs`: actual install folder added as resolver fallback |
| 4 | Crash | `IOException`: `BaseModLib.dll` file-lock between `CreateModLibrary` and `ApplyMods` | Retry loop: max 10 × 500ms read + max 30 × 500ms existence wait |
| 5 | Crash | `NullReferenceException` — `typesMap` entry.Value null (game not installed) | Added `if (entry.Value == null) continue` |
| 6 | Crash | `NullReferenceException` — costruttore leggero `Game` constructor missing `ModLibrary = new ModLib(this)` → `CreateModLibrary()` crash | Added `ModLibrary = new ModLib(this)` to lightweight constructor |
| 7 | Crash | `SwitchDevGame()` — `App.Game.GamePath` empty after lightweight constructor → `CreateModLibrary` crash | Set `App.Game.GamePath = savedPath` after lightweight constructor |
| 8 | Gioco Errato | `EscapeThePacific` mods classified as TheForest | `ModsViewModel`: `GameId` extracted from folder path |
| 9 | Percorso Errato | `GetGameFolder()` → `""` → resolves to drive root (e.g. `E:\`) | Null/empty guard at all 6 call sites |

#### Separazione di Compilazione Debug / Release

- **`FileValidator.cs`** — nuovo file `ModAPI_Shared\Utils\FileValidator.cs`; registrato in `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — header PE (MZ + PE\0\0) + minimo 1 MB
  - `IsValidGameExe()` — header PE + minimo 512 KB
  - `IsValidAssemblyDll()` — header PE + header metadati CLR .NET + minimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` Cecil omesso / `#else`: analisi Cecil completa + modifica IL
- **`ModLib.Create()` file non trovato** — `#if DEBUG`: registrare avviso, saltare / `#else`: registrare errore, interrompere

#### Test Debug

- **`create_dummy_Debug_games.ps1`** — Script PowerShell per `bin\Debug\`; crea file di 0 byte per tutti i 5 giochi sotto `dummy_games\`, `dummy_steam\` e `gamefiles\original\` — permette test completi del flusso di lavoro dell'UI senza installazione reale del gioco

#### Scheda Settings

- **Scheda percorso Steam** — integrata nella scheda Percorsi di Installazione Giochi; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Game paths panel** — `BuildGamePathsPanel()` with per-game expandable cards; TextBox utilizza `HorizontalAlignment=Stretch`
- Pulsante **Espandi Tutto / Comprimi Tutto**
- Casella **Sempre in Primo Piano** (salvata in `ui.cfg`)
- Cursori **Larghezza Lista Mod/Progetti** — inizio al minimo `150`; salvato in `ui.cfg`
- ComboBox **Dimensione Carattere** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronizzazione caselle** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions ora si sincronizzano correttamente
- **Flag `_uiInitialized`** — previene scritture premature di `ui.cfg` durante l'avvio WPF

#### Scheda Mods — Validazione Avvio Gioco

La validazione in cinque passaggi viene eseguita ad ogni clic di Avvio Gioco, indipendentemente dallo stato della lista mod:

| Passaggio | Controllo | Popup |
|---|---|---|
| 1 | Percorso Steam nella scheda Settings valido (`Steam.exe` esiste) | SteamNotFound |
| 2 | Gioco nella cartella `mods/{GameId}/` corrisponde al gioco configurato in Settings | GameModsMismatch |
| 3 | Almeno un mod selezionato | NoModSelected |
| 4 | Nessun mod di giochi misti nella selezione | MixedGameMods |
| 5 | Percorso gioco configurato + eseguibile esiste | GamePathNotSet / GameNotInstalled |

#### Scheda Development — Validazione ModLib

Validazione in tre passaggi al clic di Rigenerazione Libreria Mod:

| Passaggio | Controllo | Popup |
|---|---|---|
| 1 | Percorso Steam nella scheda Settings valido | SteamNotFound |
| 2 | Almeno un progetto esiste | NoProjectWarning |
| 3 | `App.Game.GamePath` impostato | GamePathNotSet |

#### Scheda Downloads
- Stringa di debug sostituita con `Lang.Downloads.Status.NoDownloads`
- Padding coerente per tutti i messaggi di stato
- Testo manuale offline aggiornato per 5 giochi supportati; interruzione di riga tramite due TextBlocks

#### Configurazione Iniziale e Sistema Percorsi Giochi
- `FirstSetup.Check()` — valore predefinito `true` per `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crea le cartelle `mods/` e `projects/` per tutti i 5 giochi
- `SpecifyGamePath` — `GameNameLabel` mostra quale gioco; `NavigateToSettings()` reindirizza alla scheda Settings

#### Chiavi di Lingua Nuove / Aggiornate

| Chiave | Valore Inglese |
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
| Aggiornamento auto (mantenere ultima versione) | Infrastruttura lato server non disponibile |
| Ricerca aggiornamenti | Infrastruttura lato server non disponibile |

### Rimosso

| Elemento | Motivo |
|---|---|
| Popup `SpecifyGamePath` all'avvio | Tutti i percorsi configurati nella scheda Settings |
| Popup `SpecifySteamPath` all'avvio | Percorso Steam configurato nella scheda Settings |
| Sistema di login | Server originale non più operativo (rimosso in v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Non funzionale su Mono 2.0 (rimosso in v2.0.9586) |
| Condizione `UseSteam` sul controllo Steam | Steam viene ora sempre validato per primo all'Avvio Gioco e alla Rigenerazione Libreria Mod |

---

## Pianificato per Versioni Future

| # | Funzionalità | Descrizione |
|---|---|---|
| 1 | Aggiornamento automatico di ModAPI | Scarica e applica automaticamente le nuove versioni di ModAPI |
| 2 | Aggiornamento tabella VersionsData | Aggiorna automaticamente la tabella VersionsData quando vengono rilasciate nuove patch del gioco |

---

## Modifiche in v2.0.9600

### Aggiunto

- **Scheda Downloads**: 5 filtri giochi (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Scheda Welcome**: aggiunta nella posizione più a sinistra (indice 0)
- **Scheda Mods**: layout a 3 colonne (WrapPanel → lista verticale); regolazione automatica larghezza; a capo del nome mod
- **`ModsViewModel`**: filtro specifico per gioco, `ResolveGame()` per l'istanza `Game` corretta per mod
- **`Game.cs`**: costruttore leggero `new Game(config, true)` — solo identificazione, senza `Verify()`
- **Build**: 4 file XML giochi registrati in `ModAPI.csproj` con `CopyToOutputDirectory=Always`
- **Build**: avvisi puliti — CS0168, CS0618, CS0252
- **XML Giochi**: liste DLL di TheForest, Raft, GH corrette
- **Flag lingue**: dimensioni immagini standardizzate su tutti i 13 badge linguistici

### Rimosso

| Elemento | Motivo |
|---|---|
| `extends="GenericUnityGame"` nei file XML giochi | Causava ereditarietà errata di `Assembly-CSharp-firstpass.dll` — rimosso da Subnautica, Raft, EscapeThePacific, GH |
| Layout `WrapPanel` nella scheda Mods | Sostituito con layout Grid a 3 colonne (Filtro Giochi / Lista Mod / Informazioni) |

---

## Modifiche Principali per Fase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Tutti i 5 progetti migrati da .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Sistema a 3 temi, `theme.cfg`, correzione trascinamento finestra, supporto hyperlink.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Sistema di login rimosso, meccanismo di aggiornamento modernizzato.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Scheda Downloads, icone Segoe MDL2 Assets, supporto 13 lingue.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, patching header PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Schermo nero corretto, `ValueTuple` rimosso, C# 7.3 verificato in gioco.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 filtri giochi, scheda Mods a 3 colonne, costruttore leggero `Game`, XML registrato.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML corretto, percorso Steam, sicurezza percorso gioco, validazione avvio gioco in 5 passaggi, validazione ModLib in 3 passaggi, verifica header PE `FileValidator`, separazione compilazione `#if DEBUG`, `create_dummy_Debug_games.ps1`, correzione costruttore leggero `ModLibrary`, correzione GamePath in `SwitchDevGame`, creazione cartelle per 5 giochi, correzioni crash.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Scheda Themes aggiunta, 10 temi + funzione texture di sfondo, separazione cartella Themes/, correzione pulsante massimizza, correzione espansione percorso gioco, aggiornamento Versions.xml per 4 giochi, pulsanti reset percorso, auto-salvataggio Browse, MODAPI_VersionTool.

---

## Cronologia delle Versioni

### v2.0.9618 — 2026-04-25
Aggiunto MODAPI_VersionTool (strumento WPF autonomo per aggiornamento versione), visualizzazione versione StatusBar collegata ad App.Version

### v2.0.9617 — 2026-04-24
Aggiunti pulsanti reset percorso Steam/gioco nella scheda Settings, auto-salvataggio Browse, stato reset preservato tramite flag ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml creato/aggiornato per 4 giochi (Subnautica, Raft, EscapeThePacific, GH), regole di composizione checksum stabilite, procedura di aggiornamento gioco documentata

### v2.0.9615 — 2026-04-18
Correzione precisione altezza espansione scheda percorso gioco in Settings, prevenzione interferenza texture di sfondo in UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Pulsante massimizza con massimizzazione manuale basata su WorkArea, salvataggio e ripristino dimensione/posizione precedente

### v2.0.9613 — 2026-04-18
Scheda Themes aggiunta, struttura registro temi guidata dai dati, 10 temi supportati, funzione texture di sfondo (compressione, sicurezza, trasparenza a 2 livelli), overlay blocco ThemeSelector, 12 nuove chiavi di lingua

### v2.0.9612 — 2026-04-18
Separazione cartella Themes/, modularizzazione XAML temi

### v2.0.9611 — 2026-04-18
Correzione larghezza lista mod non applicata dopo cambio tema

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
