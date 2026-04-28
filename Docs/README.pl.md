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

**Narzędzie do Zarządzania Modami The Forest — Wersja Ulepszona**

> Oryginał: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Niemcy)
> Ulepszenie: zzangae (Republika Korei)

---

## Przegląd

ModAPI to aplikacja desktopowa do zarządzania modami **5 oficjalnie obsługiwanych gier**. Ta ulepszona edycja zawiera wsparcie dla wielu gier, całkowicie przeprojektowaną zakładkę Ustawienia, konfigurację ścieżki Steam, trwałe ustawienia UI, dynamiczny system rozmiaru czcionki, walidację uruchamiania gry, separację buildów Debug/Release oraz liczne poprawki błędów zweryfikowane podczas testów w grze.

---

## Obsługiwane Gry

| Gra | Silnik | Wersja | Steam ID | Plik Wykonywalny |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 5 (zaktualizowany z Unity 4) |
| Najnowsza Wersja | v1.12 (VR) |
| Ostatnia Aktualizacja | 11 września 2019 — patch wsparcia VR; brak dalszych większych aktualizacji treści |
| Plik Wykonywalny | `TheForest.exe` |
| Folder Danych | `TheForest_Data/Managed/` |
| Folder Modów | `mods/TheForest/` |
| Folder Projektów | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — w pełni obsługiwany |

The Forest został zaktualizowany z Unity 4 do Unity 5, znacząco poprawiając grafikę i fizykę. Patch VR z września 2019 był ostatnią większą aktualizacją. Gra pozostaje w stabilnym, sfinalizowanym stanie — idealnym do moddingu.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity (zintegrowana baza kodu, zunifikowana z Below Zero w 2022) |
| Najnowsza Wersja | 2025 Patch (v18810395) |
| Ostatnia Aktualizacja | 12 sierpnia 2025 — poprawki błędów i ulepszenia wydajności wraz z wydaniem mobilnym |
| Plik Wykonywalny | `Subnautica.exe` |
| Folder Danych | `Subnautica_Data/Managed/` |
| Folder Modów | `mods/Subnautica/` |
| Folder Projektów | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — obsługiwany |

Pierwotnie zbudowany na Unity 5, Subnautica otrzymała aktualizację 'Living Large' (v2.0) pod koniec 2022, która połączyła bazę kodu silnika z Below Zero dla lepszej optymalizacji i stabilności. Uwaga: nadchodzące *Subnautica 2* używa Unreal Engine 5.

> **XML przepisany w v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` dodane do `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity |
| Najnowsza Wersja | v1.1.02 (Beta) / v1.09 (Stabilna) |
| Ostatnia Aktualizacja | Marzec 2026 — poprawki czatu głosowego i trybu wieloosobowego przez gałąź beta |
| Plik Wykonywalny | `Raft.exe` |
| Folder Danych | `Raft_Data/Managed/` |
| Folder Modów | `mods/Raft/` |
| Folder Projektów | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — obsługiwany |
| Versions.xml | `1.1.01` (z sumą kontrolną) |

Po oficjalnym zakończeniu fabuły w v1.0: *The Final Chapter*, kontynuowane są patche poprawiające kod sieciowy i stabilność.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 6 (migracja z Unity 2021/2022 pod koniec 2025) |
| Najnowsza Wersja | v0.67.0.0 |
| Ostatnia Aktualizacja | 26 czerwca 2025 — przebudowa dystrybucji wysp i aktualizacja silnika; bieżące poprawki do 2026 |
| Plik Wykonywalny | `EscapeThePacific.exe` |
| Folder Danych | `EscapeThePacific_Data/Managed/` |
| Folder Modów | `mods/EscapeThePacific/` |
| Folder Projektów | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — obsługiwany |

Zakończono gruntowną przebudowę systemu i migrację do Unity 6 pod koniec 2025, umożliwiając bardziej dynamiczne środowiska. Gra pozostaje w aktywnym rozwoju Early Access.

> **XML przepisany w v2.0.9610**: `extends="GenericUnityGame"` usunięto; `includeAssembly` ustawiono tylko na `Assembly-CSharp.dll` — zapobiega błędom dziedziczenia `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 2019 |
| Najnowsza Wersja | v2.9.5 |
| Ostatnia Aktualizacja | 4 lutego 2026 — optymalizacja Steam Deck i poprawa czytelności tekstu |
| Plik Wykonywalny | `GH.exe` |
| Folder Danych | `GH_Data/Managed/` |
| Folder Modów | `mods/GH/` |
| Folder Projektów | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — obsługiwany |
| Versions.xml | `2.9.5` (z sumą kontrolną) |

Rozwijany z postępowymi aktualizacjami silnika Unity 2017 → 2018 → 2019. Poprawka z lutego 2026 skupiła się na kompatybilności ze Steam Deck i czytelności tekstu UI.

> **XML przepisany w v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` dodane; nieistniejący `DOTweenPro.dll` usunięty.
</details>

---

## Architektura

### Podział Środowiska Uruchomieniowego

| Komponent | Cel | Środowisko | Powód |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplikacja desktopowa, pełne nowoczesne API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteka współdzielona |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Trwale ustalony** — nagłówek PE musi zawierać `v2.0.50727` |
| DLL modów (użytkownik) | .NET Framework 4.8 | Game Mono 2.0 (zpatchowany) | Zbudowany z 4.8, nagłówek PE patchowany przy aplikacji |

### Podział Kompilacji Debug / Release

Wszystkie walidacje plików i przetwarzanie assemblów rozgałęziają się na podstawie konfiguracji kompilacji przez `#if DEBUG` / `#else`.

| Lokalizacja | Kompilacja Debug | Kompilacja Release |
|---|---|---|
| `CheckSteam()` | Tylko `File.Exists()` — pliki fikcyjne przechodzą | `FileValidator.IsValidSteamExe()` — nagłówek PE + min 1 MB |
| `CheckGamePath()` | Tylko `File.Exists()` — pliki fikcyjne przechodzą | `FileValidator.IsValidAssemblyDll()` — nagłówek PE + metadane CLR + min 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — pominięcie analizy Cecil | Pełna analiza Mono.Cecil + modyfikacja IL + `module.Write()` |
| `ModLib.Create()` — plik nie znaleziony | Zaloguj ostrzeżenie, pomiń i kontynuuj | Zaloguj błąd, przerwij z popup |

**Testy Debug** używają `create_dummy_Debug_games.ps1` do generowania plików 0-bajtowych pod `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` i `bin\Debug\gamefiles\original\`. Te przechodzą kontrole `File.Exists()` i umożliwiają pełne testy przepływu pracy UI bez rzeczywistej instalacji gry.

**Kompilacje Release** stosują `FileValidator` (weryfikacja nagłówka PE + metadanych CLR .NET) aby odrzucić pliki 0-bajtowe, pliki tekstowe i dowolne binaria. Przechodzą tylko prawidłowe pliki wykonywalne Windows i assemblaje .NET.

### FileValidator — Weryfikacja Nagłówka PE

`ModAPI_Shared\Utils\FileValidator.cs` — stosowany tylko w kompilacjach Release.

| Metoda | Sprawdzenia | Min. Rozmiar |
|---|---|---|
| `IsValidSteamExe(path)` | Sygnatura MZ + sygnatura PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Sygnatura MZ + sygnatura PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + nagłówek metadanych CLR (katalog danych #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline Remapowania Assemblów

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

### Fallback Resolvera Assemblów

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Obsługa Funkcji C# 7.3

| Funkcja | Status | Uwagi |
|---|---|---|
| Dopasowywanie wzorców (`is`, `switch`) | ✅ | Zweryfikowane w grze |
| Interpolacja ciągów (`$""`) | ✅ | Zweryfikowane w grze |
| Zmienna `out` inline | ✅ | Zweryfikowane w grze |
| `async` / `await` | ✅ | Przez AsyncBridge + polyfille System.Threading |
| Krotki (`ValueTuple`) | ❌ Bezwzględny limit | ABI `mscorlib` Mono 2.0 — brak obejścia |

### Theme System

Od wersji v2.0.9613 interfejs wyboru motywów został przeniesiony z karty Settings do dedykowanej **karty Themes**. Dodanie nowego motywu wymaga tylko jednej linii w słowniku `App.xaml.cs`.

| Indeks | ID | Plik | Paleta |
|---|---|---|---|
| 0 | `classic` | Tylko `Dictionary.xaml` | Oryginalne tło tekstury ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Jasny ton + niebieski akcent |
| 2 | `dark` | `FluentStyles.xaml` | Ciemny ton + niebieski akcent (domyślny) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Czerwony + czarny |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Ciemny kosmos |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Jasny zachód słońca |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Ciemny ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Jasny nordycki |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Jasny cytrusowy |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Jasny kwiatowy |

Zmiany motywu powodują automatyczny restart aplikacji. (zapisywane w `theme.cfg`)

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

### Tekstura Tła

Wybierz obraz w karcie **Background Texture** na karcie Themes, aby zastosować go jako tło całej aplikacji. Obsługiwane formaty: `.png` / `.jpg` / `.jpeg`, maks. 50MB, rozdzielczość 4K lub niższa. Obraz jest kompresowany jako JPEG Q75 z 16-bajtowym nagłówkiem magicznym i zapisywany jako `resources\textures\ui_bg\bg.dat` (atrybut Hidden). Hash SHA-256 do weryfikacji integralności; przy wykryciu manipulacji automatyczny reset + popup ostrzeżenia.

Gdy tło jest aktywne, przezroczystość UI jest przetwarzana w dwóch warstwach: Layer 1 (nakładka MergedDictionaries) dla paneli `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) dla paneli opartych na `{StaticResource}` z półprzezroczystością.

### System Rozmiaru Czcionki

| Klucz Zasobu | Baza | Opis |
|---|---|---|
| `AppBaseFontSize` | 13 | Zwykły tekst |
| `AppBaseHeaderFontSize` | 16 | Nagłówki, tytuły paneli |
| `AppBaseSmallFontSize` | 12 | Etykiety drugorzędne |
| `AppBaseTinyFontSize` | 10 | Tekst podpowiedzi |
| `AppBaseLargeFontSize` | 20 | Duży tekst wyświetlany |

### Trwała Konfiguracja UI — `ui.cfg`

| Klucz | Domyślna | Opis |
|-----|---------|-------------|
| `ModListWidth` | `150` | Szerokość listy modów (px) |
| `ProjectListWidth` | `150` | Szerokość listy projektów (px) |
| `AppFontSize` | `13` | Globalny rozmiar czcionki UI (px) |
| `AlwaysOnTop` | `false` | Okno zawsze na wierzchu |
| `TexturePath` | *(brak)* | Oryginalna nazwa pliku tekstury tła (tylko wyświetlanie) |
| `TextureHash` | *(brak)* | Hash SHA-256 tekstury tła |
| `TextureActive` | `false` | Stan aktywacji tekstury tła |
| `GamePathReset_{GameId}` | *(brak)* | Flaga resetowania ścieżki gry |
| `SteamPathReset` | *(brak)* | Flaga resetowania ścieżki Steam |

### Struktura Plików

```
ModAPI/
├── App.xaml / App.xaml.cs              # Rejestr motywów, ID motywów, zastosowanie motywu
├── ui.cfg                               # Trwałe ustawienia UI
├── theme.cfg                            # Bieżący motyw
├── Windows/
│   ├── MainWindow.xaml / .cs            # Główny UI — 6 kart, Motywy, Ustawienia, ścieżka Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup ścieżki gry (dynamiczny GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # Konfiguracja początkowa + domyślna inicjalizacja
│       └── (14 innych podokien)
├── Themes/
│   ├── Dictionary.xaml                  # Motyw Classic
│   ├── FluentStyles.xaml                # Motyw Dark
│   ├── FluentStylesLight.xaml           # Motyw Light
│   ├── FluentStylesDiablo.xaml          # Motyw Diablo
│   ├── FluentStylesNebula.xaml          # Motyw Nebula
│   ├── FluentStylesSunset.xaml          # Motyw Sunset
│   ├── FluentStylesOcean.xaml           # Motyw Ocean
│   ├── FluentStylesNordic.xaml          # Motyw Nordic
│   ├── FluentStylesCitrus.xaml          # Motyw Citrus
│   └── FluentStylesBloom.xaml           # Motyw Bloom
├── Data/
│   ├── Game.cs                          # Patchowanie assemblów, zabezpieczenia null, rezerwowy resolver
│   ├── ModLib.cs                        # Generowanie BaseModLib + remapowanie (#if DEBUG rozgałęzienie)
│   ├── Models/
│   │   └── ModProject.cs                # Tworzenie/budowanie/stosowanie projektu + zabezpieczenia null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Filtrowane mody, wybrany mod, wybrany filtr gry
│   │   ├── ModViewModel.cs              # GameId ze ścieżki folderu
│   │   ├── ModProjectsViewModel.cs      # Dispose() dla DispatcherTimer
│   │   └── SettingsViewModel.cs         # Domyślnie true dla UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mapowanie wersji assemblów Mono 2.0 (20 assemblów)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolver oparty na nazwie z pamięcią podręczną
│   └── MonoHelper.cs                    # Narzędzia pomocnicze IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 plików językowych
│   └── textures/ui_bg/
│       └── bg.dat                       # Skompresowany i zabezpieczony obraz tła (generowany w czasie wykonywania)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Pełne przepisanie v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Pełne przepisanie v2.0.9610
    │   ├── GH.xml                       # Pełne przepisanie v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — nieobsługiwany
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Lekki konstruktor + poprawka inicjalizacji ModLibrary
│   └── ModLib.cs                        # Rozgałęzienie #if DEBUG dla analizy Cecil
└── Utils/
    └── FileValidator.cs                 # Walidacja nagłówka PE + metadanych CLR (tylko Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Samodzielne narzędzie aktualizacji wersji WPF

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generuje fikcyjną strukturę gry/Steam
├── dummy_games\{GameId}\               # Fikcyjne ścieżki instalacji gier
├── dummy_steam\Steam.exe               # Fikcyjny plik wykonywalny Steam
└── gamefiles\original\{GameId}\        # Fikcyjne ścieżki kopii zapasowych dla ModLib
```

---

## Instalacja i Konfiguracja

### Krok 1 — Wymagania wstępne

| Element | Wymagany |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstalowany w Windows 11; [pobierz](https://dotnet.microsoft.com/download/dotnet-framework/net48) dla Windows 10) |
| Steam | Wymagany — musi być skonfigurowany w karcie Settings |
| Co najmniej jedna obsługiwana gra | Wymagany — musi być skonfigurowany w karcie Settings |

### Krok 2 — Zainstaluj ModAPI

1. Pobierz najnowszą wersję z GitHub
2. Rozpakuj do dowolnego folderu (np. `C:\ModAPI\`)
3. Uruchom `ModAPI.exe`
4. Przy pierwszym uruchomieniu pojawia się ekran **Welcome** — skonfiguruj preferencje i kliknij **Continue**

### Krok 3 — Skonfiguruj ścieżkę Steam (karta Settings)

1. Przejdź do karty **Settings**
2. Znajdź **Steam Installation Path**
3. Kliknij **Browse** → wybierz `Steam.exe`
4. Kliknij **Save**

### Krok 4 — Skonfiguruj ścieżki gier (karta Settings)

1. Kliknij nagłówek karty gry, aby ją rozwinąć
2. Kliknij **Browse** → wybierz folder główny gry (gdzie znajduje się `.exe`)
3. Kliknij **Save**

| Gra | Plik wykonywalny | Przykładowa ścieżka |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Krok 5 — Pobierz mody (karta Downloads)

1. Przejdź do karty **Downloads**
2. Wybierz grę z filtru gier
3. Wyszukaj mod i kliknij **Download**

> **Offline**: Pobierz pliki `.mod` ręcznie z `modapi.survivetheforest.net` i umieść w odpowiednim folderze:

| Gra | Folder |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Krok 6 — Zastosuj mody i uruchom grę (karta Mods)

1. Przejdź do karty **Mods**
2. Wybierz grę z **Filtru Gier** (Kolumna 0)
3. Zaznacz mody do aktywacji w **Liście Modów** (Kolumna 1)
4. Kliknij **Start Game**

Następujące sprawdzenia uruchamiają się automatycznie przed startem:

| # | Sprawdzenie | Popup błędu |
|---|---|---|
| 1 | Ścieżka Steam skonfigurowana i prawidłowa | SteamNotFound |
| 2 | Gra w folderze `mods/` odpowiada ścieżce gry w Settings | GameModsMismatch |
| 3 | Co najmniej jeden mod wybrany | NoModSelected |
| 4 | Brak mieszanych modów gier w wyborze | MixedGameMods |
| 5 | Ścieżka gry skonfigurowana i plik wykonywalny istnieje | GamePathNotSet / GameNotInstalled |

---

## Przegląd Zakładek

### Karta Welcome
Ekran konfiguracji początkowej (indeks karty 0). Konfiguracja AutoUpdate, połączenia Steam i preferencji tabeli VersionsData. Przy kolejnych uruchomieniach ta karta zawiera linki społeczności i informacje o wydaniach.

### Karta Mods
Główny przepływ pracy zarządzania modami — układ 3-kolumnowy:

| Kolumna | Zawartość |
|---|---|
| Kolumna 0 | Filtr Gier — przyciski radiowe dla 5 obsługiwanych gier |
| Kolumna 1 | Lista Modów — zainstalowane mody z wyborem wersji i polem aktywacji |
| Kolumna 2 | Informacje — szczegóły wybranego moda, opis, historia wersji |

### Karta Downloads
Przeglądanie i pobieranie modów z `modapi.survivetheforest.net`.

- **Filtr gier**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Filtr kategorii**: 12 kategorii (Bugfixes, Balancing, Cheats, …)
- **Wyszukiwanie**: po nazwie moda, opisie lub autorze
- **Tryb offline**: wyświetla instrukcje folderów dla wszystkich 5 obsługiwanych gier

### Karta Development
Przepływ pracy rozwoju modów — panel filtru gier (Kolumna 0) obejmuje wszystkie 5 obsługiwanych gier.

- Tworzenie, budowanie i stosowanie projektów modów dla każdej gry
- Zarządzanie zasobami językowymi
- Generowanie ModLib z walidacją 3-krokową (Steam → projekt → ścieżka gry)
- Bezpieczne przełączanie gier przez lekki konstruktor `Game` (bez wywołania `Verify()`)

### Karta Themes
Wybór motywów i zarządzanie teksturą tła.

- **Wybór motywu**: 10 motywów (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Tekstura tła**: Wybierz obraz jako tło całej aplikacji (kompresja JPEG + przetwarzanie bezpieczeństwa)
- Gdy tekstura tła jest aktywna, wybór motywu jest zablokowany

### Karta Settings
Scentralizowana konfiguracja — 4 wiersze:

| Wiersz | Zawartość |
|---|---|
| 0 | Język / Rozmiar czcionki / Motyw / Maks. szerokość / Szerokość listy modów / Szerokość listy projektów |
| 1 | Zachowaj VersionsData / Auto aktualizacja / Połączenie Steam / Zawsze na wierzchu |
| 2 | Ścieżka instalacji Steam (TextBox + Przeglądaj + Zapisz + Resetuj) |
| 3 | Ścieżki instalacji gier — rozwijalna karta na grę (TextBox + Przeglądaj + Zapisz + Resetuj) |

---

## Zmiany w v2.0.9618

### Narzędzie Aktualizacji Wersji (MODAPI_VersionTool)

Samodzielne narzędzie WPF do aktualizacji numeru wersji jednym kliknięciem.

**Lokalizacja**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Funkcje**
- Automatycznie wyświetla bieżącą wersję (odczytaną z `App.xaml.cs`)
- Wprowadź nową wersję i kliknij **Apply Version**, aby zaktualizować oba pliki jednocześnie
- Walidacja formatu: akceptowany tylko format `X.X.XXXX`

**Zmodyfikowane Pliki**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Użycie**
1. Run `MODAPI_VersionTool.exe`
2. Wprowadź nową wersję (np. `2.0.9619`)
3. Click **Apply Version**
4. Przebuduj rozwiązanie ModAPI w Visual Studio

### Poprawka Wyświetlania Wersji w StatusBar

- `VersionLabel.Text` teraz odwołuje się do `App.Version` zamiast zakodowanego na stałe `Version.Descriptor`
- Aktualizacja wersji za pomocą VersionTool i przebudowa teraz odzwierciedla się natychmiast w StatusBar

---

## Zmiany w v2.0.9617

### Karta Settings — Dodano Przyciski Resetowania Ścieżki

Przycisk **Reset** został dodany do ścieżki instalacji Steam i każdego wiersza ścieżki instalacji gry.

**Wiersz ścieżki Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Wiersz ścieżki gry (na grę)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Zachowanie resetowania**
- Natychmiast czyści TextBox ścieżki
- Zapisuje flagę resetowania w `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox pozostaje pusty po restarcie
- Omija ograniczenie Configuration XML, które nie zapisuje pustych ciągów

**Auto-zapis Browse**
- Wcześniej: wymagane było oddzielne kliknięcie przycisku Save po Browse
- Teraz: automatycznie zapisywane przy wyborze pliku — odzwierciedlane nawet po przejściu do karty Mods

**Nowy klucz językowy**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## Zmiany w v2.0.9616

### Versions.xml — 4 Gry Dodane / Zaktualizowane

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Nowo utworzony |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Suma kontrolna zaktualizowana |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Nowo utworzony |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Suma kontrolna zaktualizowana |

### Reguły Składu Sumy Kontrolnej

Format sumy kontrolnej różni się w zależności od tego, czy `Assembly-CSharp-firstpass.dll` istnieje dla danej gry.

| Gra | firstpass.dll | Format sumy kontrolnej |
|---|---|---|
| GH | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| Subnautica | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| EscapeThePacific | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| Raft | ❌ Nieobecny | Tylko `Assembly-CSharp MD5` (32 znaki) |

### Procedura Aktualizacji Versions.xml

Dodaj nowy wpis `<version>` bez usuwania istniejących wpisów.

**Krok 1 — Znajdź nowy BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Krok 2 — Wyodrębnij nową sumę kontrolną**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Krok 3 — Dodaj wpis do Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## Zmiany w v2.0.9615

### Poprawka Rozwijania Ścieżki Gry w Karcie Settings

- **Wysokość rozwinięcia karty**: Dolna krawędź okna teraz rośnie dokładnie o wysokość pola wejściowego przy rozwijaniu karty ścieżki gry
- **`UpdateWindowHeight()` ulepszone**: Wywołuje `UpdateLayout()` przed pomiarem `SizeToContent.Height`; tymczasowo ustawia `TextureLayer1` na `Collapsed` gdy tekstura tła jest aktywna, aby rozmiar oryginalny obrazu 4K nie wpływał na obliczanie wysokości
- **Poprawka wewnętrznego wiersza Grid**: Zmieniono ostatni wiersz wewnętrznego Grid panelu ścieżek gier z `Height="*"` na `Height="Auto"` — usuwa niepotrzebną dolną białą przestrzeń

---

## Zmiany w v2.0.9614

### Poprawka Zachowania Przycisku Maksymalizacji

- **Maksymalizacja**: Używa `SystemParameters.WorkArea` do ręcznej maksymalizacji zamiast `WindowState.Maximized` — dokładnie dopasowuje się do bieżącej rozdzielczości ekranu bez nakładania się na pasek zadań
- **Przywracanie**: Zapisuje `Left`, `Top`, `Width`, `Height` i `MaxWidth` przed maksymalizacją i przywraca je po kliknięciu przycisku przywracania
- **Obsługa `MaxWidth`**: Ustawiane na `∞` przy maksymalizacji, przywracane do zapisanej wartości przy normalizacji

---

## Zmiany w v2.0.9613

### Nowa Karta Themes

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Interfejs wyboru motywów został przeniesiony z karty Settings do dedykowanej **karty Themes**.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Rejestr Motywów (Struktura Sterowana Danymi)

Dodanie nowego motywu wymaga teraz tylko **jednej linii** w słowniku `App.xaml.cs`.
Wszystkie instrukcje switch zostały usunięte — nie są potrzebne zmiany kodu w innym miejscu.

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
Konwencja kluczy językowych: `Lang.Options.Theme.{PascalCase}` (np. `Lang.Options.Theme.Nebula`)

### Obsługiwane Motywy

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | Tylko `Dictionary.xaml` | Oryginalne tło tekstury ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Jasny ton + niebieski akcent |
| 2 | `dark` | `FluentStyles.xaml` | Ciemny ton + niebieski akcent (domyślny) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Czerwony + czarny |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Ciemny kosmos |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Jasny zachód słońca |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Ciemny ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Jasny nordycki |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Jasny cytrusowy |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Jasny kwiatowy |

Zmiany motywu powodują automatyczny restart aplikacji. (zapisywane w `theme.cfg`)

### Funkcja Tekstury Tła

Wybierz obraz w karcie **Background Texture** na karcie Themes, aby zastosować go jako tło całej aplikacji. Działa z dowolnym wybranym motywem.

**Obsługiwane formaty wejściowe**: `.png` / `.jpg` / `.jpeg`, do 50MB, rozdzielczość 4K lub niższa

**Pipeline przetwarzania obrazu**

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

**Warstwy bezpieczeństwa**

| Warstwa | Metoda | Efekt |
|---|---|---|
| Nagłówek magiczny | 16 bajtów wstawionych przed sygnaturą JPEG (FF D8 FF) | Zewnętrzne przeglądarki nie mogą rozpoznać pliku |
| Atrybut Hidden | `FileAttributes.Hidden` | Ukryty w Eksploratorze domyślnie |
| Integralność SHA-256 | Hash weryfikowany przy ładowaniu | Manipulacja powoduje automatyczny reset + popup ostrzeżenia |

**Zachowanie przy wykryciu manipulacji**
1. `bg.dat` deleted
2. Klucze `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` zresetowane
3. TextBox i przełącznik zresetowane
4. Popup `Lang.Windows.TextureTampered` wyświetlony

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**Przetwarzanie przezroczystości**

Gdy obraz tła jest aktywny, tła UI są przetwarzane w dwóch warstwach.

- **Warstwa 1 — nakładka MergedDictionaries**: Panele odwołujące się do `{DynamicResource FluentBgBrush}` itp. są automatycznie przezroczyste. Przywracane jednym wywołaniem `Remove()` przy dezaktywacji.

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Warstwa 2 — przechodzenie drzewa wizualnego (`WalkStyleBackgrounds`)**: Elementy `{StaticResource}` w motywach Fluent nie są objęte Warstwą 1, więc drzewo wizualne jest bezpośrednio przechodzone w celu zastosowania półprzezroczystych pędzli opartych na oryginalnych kolorach.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  Przetwarzane: `Panel` (poza Grid), `Border`, `ListBox` / `ListView`

  Wykluczone: `Grid` (tło zachowane, dzieci przechodzone), `TabPanel` (ochrona nagłówka karty), `ButtonBase` / `ComboBox`, elementy `Collapsed`

  Przywracanie: źródło Style Setter → `ClearValue()`, źródło wartości lokalnej XAML → przywrócenie oryginalnego pędzla bezpośrednio

**Przełączanie kart**

WPF TabControl leniwie ładuje zawartość kart, więc `WalkStyleBackgrounds(this)` jest ponownie uruchamiany z priorytetem `ContextIdle` przy zmianie karty. Już przetworzone elementy są pomijane przez sprawdzenie `ContainsKey`.

**Blokada ThemeSelector**

Gdy tekstura tła jest aktywna, Border `ThemeSelectorOverlay` jest wyświetlany nad selektorem motywów, aby zablokować interakcję.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` również chroniony flagą `_textureActive`

**Przepływ stanu UI**

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

**Nowe klucze językowe**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**Struktura plików**

```
ModAPI\
├── App.xaml.cs                    # Rejestr motywów, ID motywów, zastosowanie motywu
├── Windows\
│   ├── MainWindow.xaml            # Karta Themes, nakładka wyboru motywu, warstwa tekstury 1
│   └── MainWindow.xaml.cs         # Logika motywów i tekstur
├── Themes\
│   ├── Dictionary.xaml            # Motyw Classic
│   ├── FluentStyles.xaml          # Motyw Dark
│   ├── FluentStylesLight.xaml     # Motyw Light
│   ├── FluentStylesDiablo.xaml    # Motyw Diablo
│   ├── FluentStylesNebula.xaml    # Motyw Nebula
│   ├── FluentStylesSunset.xaml    # Motyw Sunset
│   ├── FluentStylesOcean.xaml     # Motyw Ocean
│   ├── FluentStylesNordic.xaml    # Motyw Nordic
│   ├── FluentStylesCitrus.xaml    # Motyw Citrus
│   └── FluentStylesBloom.xaml     # Motyw Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Skompresowany i zabezpieczony obraz tła (generowany w czasie wykonywania)
```

**Znane ograniczenia projektowe**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Bezpośrednia zamiana kluczy `MergedDictionaries` | Awaria podczas przejścia układu → tylko wzorzec `Add`/`Remove` |
| Nadpisywanie pliku Hidden | `Access Denied` → konieczne zresetowanie `FileAttributes.Normal` przed zapisem |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## Zmiany w v2.0.9612

### Separacja Modułu Motywów

- **Nowy folder `Themes/`**: Przeniesiono `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` i `FluentStylesClassic.xaml` do `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — motyw Classic używa tylko `Dictionary.xaml`; Light/Dark/inne motywy Fluent ładują odpowiedni XAML
- **`ModAPI.csproj`**: Zaktualizowano ścieżki XAML motywów do podkatalogu `Themes\`; zarejestrowano `FluentStylesClassic.xaml`

---

## Zmiany w v2.0.9611

### Poprawka Błędu

- **Szerokość listy modów nie stosowana po zmianie motywu**: Naprawiono problem, w którym szerokość listy modów nie była stosowana po przełączeniu między motywami Light/Dark i restarcie — dodano wywołanie `ApplyModListWidth(width)` wewnątrz `InitModListWidth()`

---

---

## Zmiany w v2.0.9610

### Dodano

#### Konfiguracja XML Gier i Wersji

| # | Plik | Zmiana |
|---|------|--------|
| 1 | `GH.xml` | Pełne przepisanie — usunięto nieistniejący `DOTweenPro.dll`; dodano `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Pełne przepisanie — usunięto `extends="GenericUnityGame"`; dodano `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Pełne przepisanie — usunięto `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Utworzono — wersja `1.1.01` z sumą kontrolną |
| 5 | `GH/Versions.xml` | Utworzono — wersja `2.9.5` z sumą kontrolną |
| 6 | `Subnautica/Versions.xml` | Utworzono — bez sumy kontrolnej (zbyt częste aktualizacje) |

#### Krytyczne Poprawki Błędów

| # | Typ | Problem | Poprawka |
|---|------|-------|-----|
| 1 | Zawieszenie | `extends="GenericUnityGame"` powodował dziedziczenie `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` zawieszał się | Usunięto `extends` ze wszystkich XML poza TheForest |
| 2 | Awaria | `ResolutionException: XGamingRuntime.XUserGamertagComponent` podczas aplikowania Subnautica | Dodano `XGamingRuntime.dll`, `XblPCSandbox.dll` do `copyAssembly` |
| 3 | Awaria | Resolver zawiódł na DLL-ach dodanych do `copyAssembly` po utworzeniu kopii zapasowej | `Game.cs`: dodano folder instalacji jako fallback resolvera |
| 4 | Awaria | `IOException`: `BaseModLib.dll` blokada pliku między `CreateModLibrary` i `ApplyMods` | Pętla ponowień: maks. 10 × 500ms odczyt + maks. 30 × 500ms oczekiwanie |
| 5 | Awaria | `NullReferenceException` — `typesMap` entry.Value null (gra nie zainstalowana) | Dodano `if (entry.Value == null) continue` |
| 6 | Awaria | `NullReferenceException` — lekki `Game` konstruktor bez `ModLibrary = new ModLib(this)` → awaria `CreateModLibrary()` | Dodano `ModLibrary = new ModLib(this)` do lekkiego konstruktora |
| 7 | Awaria | `SwitchDevGame()` — `App.Game.GamePath` pusty po lekkim konstruktorze → awaria `CreateModLibrary` | Ustawiono `App.Game.GamePath = savedPath` po lekkim konstruktorze |
| 8 | Błędna Gra | `EscapeThePacific` mody klasyfikowane jako TheForest | `ModsViewModel`: `GameId` wyodrębnione ze ścieżki folderu |
| 9 | Błędna Ścieżka | `GetGameFolder()` → `""` → rozwiązuje do katalogu głównego dysku (np. `E:\`) | Zabezpieczenie null/puste we wszystkich 6 miejscach wywołania |

#### Podział Kompilacji Debug / Release

- **`FileValidator.cs`** — nowy plik `ModAPI_Shared\Utils\FileValidator.cs`; zarejestrowany w `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — nagłówek PE (MZ + PE\0\0) + minimum 1 MB
  - `IsValidGameExe()` — nagłówek PE + minimum 512 KB
  - `IsValidAssemblyDll()` — nagłówek PE + nagłówek metadanych CLR .NET + minimum 64 KB
- **`CheckSteam()`** — `#if DEBUG`: tylko `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: tylko `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` pominięcie Cecil / `#else`: pełna analiza Cecil + modyfikacja IL
- **`ModLib.Create()` plik nie znaleziony** — `#if DEBUG`: log ostrzeżenie, pomiń / `#else`: log błąd, przerwij

#### Testy Debug

- **`create_dummy_Debug_games.ps1`** — skrypt PowerShell dla `bin\Debug\`; tworzy pliki 0-bajtowe dla wszystkich 5 gier pod `dummy_games\`, `dummy_steam\` i `gamefiles\original\` — umożliwia pełne testy przepływu pracy UI bez rzeczywistej instalacji gry

#### Karta Settings

- **Karta ścieżki Steam** — zintegrowana w karcie Ścieżek Instalacji Gier; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panel ścieżek gier** — `BuildGamePathsPanel()` z rozwijalnymi kartami na grę; TextBox używa `HorizontalAlignment=Stretch`
- Przycisk **Rozwiń Wszystko / Zwiń Wszystko**
- Pole wyboru **Zawsze na wierzchu** (zapisywane w `ui.cfg`)
- Suwaki **Szerokość Listy Modów/Projektów** — start od minimum `150`; zapisywane w `ui.cfg`
- ComboBox **Rozmiar Czcionki** — FHD 10–16, 4K 10–22, 8K 10–28
- **Synchronizacja pól wyboru** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions teraz synchronizują się poprawnie
- **Flaga `_uiInitialized`** — zapobiega przedwczesnemu zapisowi `ui.cfg` podczas startu WPF

#### Karta Mods — Walidacja Uruchomienia Gry

Walidacja pięciokrokowa uruchamiana przy każdym kliknięciu Start Game, niezależnie od stanu listy modów:

| Krok | Sprawdzenie | Popup |
|---|---|---|
| 1 | Ścieżka Steam w karcie Settings prawidłowa (`Steam.exe` istnieje) | SteamNotFound |
| 2 | Gra w folderze `mods/{GameId}/` odpowiada grze skonfigurowanej w Settings | GameModsMismatch |
| 3 | Co najmniej jeden mod wybrany | NoModSelected |
| 4 | Brak mieszanych modów gier w wyborze | MixedGameMods |
| 5 | Ścieżka gry skonfigurowana + plik wykonywalny istnieje | GamePathNotSet / GameNotInstalled |

#### Karta Development — Walidacja ModLib

Walidacja trzykrokowa przy kliknięciu Regeneracji Biblioteki Modów:

| Krok | Sprawdzenie | Popup |
|---|---|---|
| 1 | Ścieżka Steam w karcie Settings prawidłowa | SteamNotFound |
| 2 | Co najmniej jeden projekt istnieje | NoProjectWarning |
| 3 | `App.Game.GamePath` ustawiony | GamePathNotSet |

#### Karta Downloads
- Ciąg debugowania zastąpiony przez `Lang.Downloads.Status.NoDownloads`
- Spójne wypełnienie dla wszystkich komunikatów statusu
- Tekst instrukcji offline zaktualizowany dla 5 obsługiwanych gier; łamanie linii przez dwa TextBlocki

#### Konfiguracja Początkowa i System Ścieżek Gier
- `FirstSetup.Check()` — domyślna wartość `true` dla `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — tworzy foldery `mods/` i `projects/` dla wszystkich 5 gier
- `SpecifyGamePath` — `GameNameLabel` pokazuje którą grę; `NavigateToSettings()` kieruje do karty Settings

#### Nowe / Zaktualizowane Klucze Językowe

| Klucz | Wartość angielska |
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

### Nie uwzględniono

| Funkcja | Powód |
|---|---|
| Auto-aktualizacja (utrzymanie najnowszej wersji) | Infrastruktura po stronie serwera niedostępna |
| Wyszukiwanie aktualizacji | Infrastruktura po stronie serwera niedostępna |

### Usunięto

| Element | Powód |
|---|---|
| Popup `SpecifyGamePath` przy starcie | Wszystkie ścieżki skonfigurowane w karcie Settings |
| Popup `SpecifySteamPath` przy starcie | Ścieżka Steam skonfigurowana w karcie Settings |
| System logowania | Oryginalny serwer nie działa (usunięto w v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Niefunkcjonalny na Mono 2.0 (usunięto w v2.0.9586) |
| Warunek `UseSteam` na sprawdzenie Steam | Steam jest teraz zawsze walidowany jako pierwszy przy Start Game i Regeneracji Biblioteki Modów |

---

## Planowane w Przyszłych Wersjach

| # | Funkcja | Opis |
|---|---|---|
| 1 | Automatyczna aktualizacja ModAPI | Automatyczne pobieranie i stosowanie nowych wersji ModAPI |
| 2 | Aktualizacja tabeli VersionsData ModAPI | Automatyczna aktualizacja tabeli VersionsData przy nowych patchach gry |

---

## Zmiany w v2.0.9600

### Dodano

- **Karta Downloads**: 5 filtrów gier (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Karta Welcome**: dodana na pozycji najbardziej na lewo (indeks 0)
- **Karta Mods**: układ 3-kolumnowy (WrapPanel → lista pionowa); automatyczna regulacja szerokości; zawijanie nazwy moda
- **`ModsViewModel`**: filtrowanie specyficzne dla gry, `ResolveGame()` dla prawidłowej instancji `Game` na mod
- **`Game.cs`**: lekki konstruktor `new Game(config, true)` — tylko identyfikacja, bez `Verify()`
- **Build**: 4 pliki XML gier zarejestrowane w `ModAPI.csproj` z `CopyToOutputDirectory=Always`
- **Build**: ostrzeżenia wyczyszczone — CS0168, CS0618, CS0252
- **XML Gier**: listy DLL TheForest, Raft, GH poprawione
- **Flagi językowe**: rozmiary obrazów ustandaryzowane na wszystkich 13 odznakach językowych

### Usunięto

| Element | Powód |
|---|---|
| `extends="GenericUnityGame"` w plikach XML gier | Powodował nieprawidłowe dziedziczenie `Assembly-CSharp-firstpass.dll` — usunięto z Subnautica, Raft, EscapeThePacific, GH |
| Układ `WrapPanel` w karcie Mods | Zastąpiony układem Grid 3-kolumnowym (Filtr Gier / Lista Modów / Informacje) |

---

## Główne Zmiany według Fazy

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Wszystkie 5 projektów migrowanych z .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
System 3 motywów, `theme.cfg`, poprawka przeciągania okna, obsługa hiperłączy.

### Phase 4 *(v2.0.9400)* — Code Cleanup
System logowania usunięty, mechanizm aktualizacji zmodernizowany.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Karta Downloads, ikony Segoe MDL2 Assets, obsługa 13 języków.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, patchowanie nagłówka PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Czarny ekran naprawiony, `ValueTuple` usunięty, C# 7.3 zweryfikowany w grze.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 filtrów gier, karta Mods 3-kolumnowa, lekki konstruktor `Game`, XML zarejestrowany.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML poprawiony, ścieżka Steam, bezpieczeństwo ścieżki gry, walidacja Start Game 5-krokowa, walidacja ModLib 3-krokowa, weryfikacja nagłówka PE `FileValidator`, podział kompilacji `#if DEBUG`, `create_dummy_Debug_games.ps1`, poprawka lekkiego konstruktora `ModLibrary`, poprawka GamePath w `SwitchDevGame`, tworzenie folderów dla 5 gier, poprawki awarii.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Dodano kartę Themes, 10 motywów + funkcja tekstury tła, separacja folderu Themes/, poprawka przycisku maksymalizacji, poprawka rozwijania ścieżki gry, aktualizacja Versions.xml dla 4 gier, przyciski resetowania ścieżki, auto-zapis Browse, MODAPI_VersionTool.

---

## Historia Wersji

### v2.0.9618 — 2026-04-25
Dodano MODAPI_VersionTool (samodzielne narzędzie WPF do aktualizacji wersji), wyświetlanie wersji StatusBar połączone z App.Version

### v2.0.9617 — 2026-04-24
Dodano przyciski resetowania ścieżki Steam/gry w karcie Settings, auto-zapis Browse, stan resetowania zachowany przez flagę ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml utworzone/zaktualizowane dla 4 gier (Subnautica, Raft, EscapeThePacific, GH), ustalone reguły składu sumy kontrolnej, udokumentowana procedura aktualizacji gry

### v2.0.9615 — 2026-04-18
Poprawka dokładności wysokości rozwijania karty ścieżki gry w Settings, zapobieganie zakłóceniom tekstury tła w UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Przycisk maksymalizacji z ręczną maksymalizacją opartą na WorkArea, zapisywanie i przywracanie poprzedniego rozmiaru/pozycji

### v2.0.9613 — 2026-04-18
Dodano kartę Themes, struktura rejestru motywów sterowana danymi, obsługa 10 motywów, funkcja tekstury tła (kompresja, bezpieczeństwo, przezroczystość 2-warstwowa), nakładka blokady ThemeSelector, 12 nowych kluczy językowych

### v2.0.9612 — 2026-04-18
Separacja folderu Themes/, modularyzacja XAML motywów

### v2.0.9611 — 2026-04-18
Poprawka szerokości listy modów nie stosowanej po zmianie motywu

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 filtrów gier, układ 3-kolumnowy karty Mods, automatyczna szerokość, lekki konstruktor `Game`, filtrowanie gier `ModsViewModel`, 4 pliki XML zarejestrowane, ostrzeżenia kompilacji wyczyszczone, karta Welcome, flagi językowe ustandaryzowane

### v2.0.9586 — 2026-03-31
Czarny ekran naprawiony, polyfill sfinalizowany, ValueTuple usunięty, C# 7.3 zweryfikowany

### v2.0.9561 — 2026-03-06
Obsługa C# 7.3, patchowanie nagłówka PE, pipeline polyfill, przywrócono rozwiązywanie assemblów

### v2.0.9552 — 2026-02-25
Karta Downloads, modernizacja ikon, unifikacja motywów, obsługa 13 języków

### v2.0.9500
System motywów (Classic/Light/Dark), Fluent Design UI, system SubWindow

### v2.0.9400
Oczyszczenie kodu, usunięcie logowania, modernizacja starszych elementów

### v2.0.9300
Środowisko kompilacji, DLL stub UnityEngine, integracja ModernWpf

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Wymagania Kompilacji

| Wymaganie | Wersja | Uwagi |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projekty ModAPI |
| .NET Framework SDK | 3.5 | Tylko BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licencja

GNU General Public License v3.0 — zgodna z oryginalną licencją.
