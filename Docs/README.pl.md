[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md) [![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md) [![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md) [![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md) [![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md) [![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md) [![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md) [![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md) [![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md) [![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md) [![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md) [![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md) [![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9621 - 20260728

**Narzędzie do Zarządzania Modami dla The Forest — Wersja Rozszerzona**

> Oryginał: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Niemcy)
> Rozszerzenie: zzangae (Republika Korei)

---

## Przegląd

ModAPI to aplikacja desktopowa do zarządzania modami dla **5 oficjalnie wspieranych gier**. Ta rozszerzona wersja zawiera obsługę wielu gier, całkowicie przeprojektowaną zakładkę Settings, konfigurację ścieżki Steam, trwałe ustawienia interfejsu, dynamiczny system rozmiaru czcionki, walidację przy uruchamianiu gry, podział na buildy Debug/Release oraz liczne poprawki błędów zweryfikowane w testach w grze.

---

## Wspierane Gry

| Gra | Silnik | Wersja | ID Steam | Plik wykonywalny |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Patch 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 5 (zaktualizowany z Unity 4) |
| Najnowsza wersja | v1.12 (VR) |
| Ostatnia aktualizacja | 11 września 2019 — patch obsługi VR; brak dalszych większych aktualizacji zawartości |
| Plik wykonywalny | `TheForest.exe` |
| Folder danych | `TheForest_Data/Managed/` |
| Folder modów | `mods/TheForest/` |
| Folder projektów | `projects/TheForest/` |
| ID aplikacji Steam | `242760` |
| IL2CPP | ❌ Mono — w pełni obsługiwane |

The Forest zostało zaktualizowane z Unity 4 do Unity 5, co znacznie poprawiło grafikę i fizykę. Patch VR z września 2019 roku był ostatnią większą aktualizacją. Gra pozostaje obecnie w stabilnym, finalnym stanie — idealnym do moddingu.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity (zintegrowana baza kodu, ujednolicona z Below Zero w 2022 roku) |
| Najnowsza wersja | Patch 2025 (v18810395) |
| Ostatnia aktualizacja | 12 sierpnia 2025 — poprawki błędów i usprawnienia wydajności wraz z wydaniem mobilnym |
| Plik wykonywalny | `Subnautica.exe` |
| Folder danych | `Subnautica_Data/Managed/` |
| Folder modów | `mods/Subnautica/` |
| Folder projektów | `projects/Subnautica/` |
| ID aplikacji Steam | `264710` |
| IL2CPP | ❌ Mono — obsługiwane |

Pierwotnie zbudowana na Unity 5, Subnautica otrzymała aktualizację „Living Large” (v2.0) pod koniec 2022 roku, która połączyła bazę kodu silnika z Below Zero w celu lepszej optymalizacji i stabilności. Uwaga: nadchodząca *Subnautica 2* wykorzystuje Unreal Engine 5.

> **XML przepisany w v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` dodane do `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity |
| Najnowsza wersja | v1.1.02 (Beta) / v1.09 (Stable) |
| Ostatnia aktualizacja | Marzec 2026 — poprawki błędów czatu głosowego i trybu wieloosobowego przez gałąź beta |
| Plik wykonywalny | `Raft.exe` |
| Folder danych | `Raft_Data/Managed/` |
| Folder modów | `mods/Raft/` |
| Folder projektów | `projects/Raft/` |
| ID aplikacji Steam | `648800` |
| IL2CPP | ❌ Mono — obsługiwane |
| Versions.xml | `1.1.01` (z sumą kontrolną) |

Po oficjalnym zakończeniu fabuły w wersji v1.0: *The Final Chapter*, patche były kontynuowane w celu poprawy kodu sieciowego i stabilności. Aktualizacja gałęzi beta w marcu 2026 roku rozwiązała problemy z czatem głosowym i trybem wieloosobowym.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 6 (migracja z Unity 2021/2022 pod koniec 2025 roku) |
| Najnowsza wersja | v0.67.0.0 |
| Ostatnia aktualizacja | 26 czerwca 2025 — przeprojektowanie rozmieszczenia wysp i aktualizacja silnika; hotfixy trwają do 2026 roku |
| Plik wykonywalny | `EscapeThePacific.exe` |
| Folder danych | `EscapeThePacific_Data/Managed/` |
| Folder modów | `mods/EscapeThePacific/` |
| Folder projektów | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — obsługiwane |

Ukończono poważną przebudowę systemu i migrację do Unity 6 pod koniec 2025 roku, umożliwiając bardziej dynamiczne środowiska. Gra pozostaje w aktywnym rozwoju we wczesnym dostępie.

> **XML przepisany w v2.0.9610**: usunięto `extends="GenericUnityGame"`; `includeAssembly` ustawiono wyłącznie na `Assembly-CSharp.dll` — zapobiega błędom dziedziczenia `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Element | Wartość |
|---|---|
| Silnik | Unity 2019 |
| Najnowsza wersja | v2.9.5 |
| Ostatnia aktualizacja | 4 lutego 2026 — optymalizacja pod Steam Deck i poprawa czytelności tekstu |
| Plik wykonywalny | `GH.exe` |
| Folder danych | `GH_Data/Managed/` |
| Folder modów | `mods/GH/` |
| Folder projektów | `projects/GH/` |
| ID aplikacji Steam | `763790` |
| IL2CPP | ❌ Mono — obsługiwane |
| Versions.xml | `2.9.5` (z sumą kontrolną) |

Rozwijana przez Unity 2017 → 2018 → 2019 w trakcie swojego cyklu życia. Hotfix z lutego 2026 roku skupił się na kompatybilności ze Steam Deck i czytelności interfejsu.

> **XML przepisany w v2.0.9610**: dodano `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll`; usunięto nieistniejący `DOTweenPro.dll`.
</details>

---

<details>
<summary><b>Architektura</b></summary>

### Podział Środowiska Uruchomieniowego

| Komponent | Cel | Środowisko uruchomieniowe | Powód |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplikacja desktopowa, pełne nowoczesne API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteka współdzielona |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Trwale ustalone** — nagłówek PE musi wskazywać `v2.0.50727` |
| DLL modów (użytkownik) | .NET Framework 4.8 | Game Mono 2.0 (załatany) | Zbudowane z 4.8, nagłówek PE łatany podczas Apply |

### Narzędzia dla Deweloperów

Samodzielne narzędzia WPF do zarządzania projektami. Nie są dystrybuowane do użytkowników końcowych.

| Narzędzie | Projekt | Cel |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Aktualizuje jednocześnie wersję `AssemblyInfo.cs` i `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Zarządza plikami językowymi — dodawanie, edycja, dezaktywacja, wbudowywanie |

**VersionTool — Zarządzanie Wersjami**

Samodzielne narzędzie WPF do aktualizacji numeru wersji jednym kliknięciem.

- Automatycznie wyświetla aktualną wersję (odczytaną z `App.xaml.cs`)
- Wprowadź nową wersję i kliknij **Apply Version**, aby zaktualizować oba pliki jednocześnie
- Walidacja formatu: akceptowany jest tylko format `X.X.XXXX`

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — System Językowy**

```
resources/langs/langs.json          ← Rejestr języków (flagi builtin / active)
resources/langs/Language.XX.xaml    ← Klucze tłumaczeń dla każdego języka
resources/langs/Language.XX.png     ← Obraz flagi (36×24, z flagcdn.com/h24/)
```

Przepływ wbudowywania (przycisk Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() przepisane (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml zarejestrowany (ModAPI\ModAPI.csproj)
  → Następna kompilacja: język w pełni wbudowany, dostępny offline
```

### Podział na Buildy Debug / Release

Cała walidacja plików i przetwarzanie assemblies rozgałęzia się w zależności od konfiguracji buildu za pomocą `#if DEBUG` / `#else`.

| Lokalizacja | Build Debug | Build Release |
|---|---|---|
| `CheckSteam()` | tylko `File.Exists()` — pliki testowe przechodzą | `FileValidator.IsValidSteamExe()` — nagłówek PE + min. 1 MB |
| `CheckGamePath()` | tylko `File.Exists()` — pliki testowe przechodzą | `FileValidator.IsValidAssemblyDll()` — nagłówek PE + metadane CLR + min. 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — pomija parsowanie Cecil | Pełne parsowanie Mono.Cecil + modyfikacja IL + `module.Write()` |
| `ModLib.Create()` — plik nie znaleziony | Zapisuje ostrzeżenie, pomija i kontynuuje | Zapisuje błąd, przerywa z komunikatem |

**Testy Debug** wykorzystują `create_dummy_Debug_games.ps1` do generowania plików zastępczych o rozmiarze 0 bajtów w `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` i `bin\Debug\gamefiles\original\`. Przechodzą one kontrole `File.Exists()` i umożliwiają testowanie całego przepływu pracy interfejsu bez rzeczywistej instalacji gry.

**Buildy Release** stosują `FileValidator` (weryfikacja nagłówka PE + metadanych CLR .NET), aby odrzucić pliki o rozmiarze 0 bajtów, pliki tekstowe i dowolne pliki binarne. Przechodzą tylko prawidłowe pliki wykonywalne Windows i assemblies .NET.

### FileValidator — Weryfikacja Nagłówka PE

`ModAPI_Shared\Utils\FileValidator.cs` — stosowany tylko w buildach Release.

| Metoda | Sprawdzenia | Minimalny rozmiar |
|---|---|---|
| `IsValidSteamExe(path)` | Sygnatura MZ + sygnatura PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Sygnatura MZ + sygnatura PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + nagłówek metadanych CLR (katalog danych #14) | 8 KB |

```
Sprawdzany układ nagłówka PE:
[0x00] 4D 5A          ← sygnatura DOS "MZ"
[0x3C] XX XX XX XX   ← offset nagłówka PE (little-endian)
[offset] 50 45 00 00 ← sygnatura "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← obecność nagłówka CLR .NET
```

### Potok Remapowania Assemblies

```
[Deweloper moda kompiluje z .NET 4.8]
  → DLL moda: nagłówek PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0 itd.
  → modModule.RuntimeVersion = "v2.0.50727"
      nagłówek PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → nagłówek PE zaakceptowany ✅  →  referencje rozwiązane ✅
```

### Fallback Resolvera Assemblies

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← folder kopii zapasowej
2. {ActualGameInstallPath}/{AssemblyPath}        ← folder instalacji gry (fallback)
```

### Obsługa Funkcji C# 7.3

| Funkcja | Status | Uwagi |
|---|---|---|
| Dopasowywanie wzorców (`is`, `switch`) | ✅ | Zweryfikowane w grze |
| Interpolacja ciągów (`$""`) | ✅ | Zweryfikowane w grze |
| Zmienna `out` w linii | ✅ | Zweryfikowane w grze |
| `async` / `await` | ✅ | Przez AsyncBridge + polyfille System.Threading |
| Krotki (`ValueTuple`) | ❌ Twarde ograniczenie | ABI `mscorlib` Mono 2.0 — brak obejścia |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Od wersji v2.0.9613 interfejs wyboru motywu został przeniesiony z zakładki Settings do dedykowanej zakładki **Themes**. Dodanie nowego motywu wymaga tylko jednej linii w słowniku `App.xaml.cs`.

| Indeks | ID | Plik | Paleta |
|---|---|---|---|
| 0 | `classic` | tylko `Dictionary.xaml` | Oryginalne tło teksturowe ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Jasny ton + niebieski akcent |
| 2 | `dark` | `FluentStyles.xaml` | Ciemny ton + niebieski akcent (domyślny) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Czerwony + czarny |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Ciemna przestrzeń |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Jasny zachód słońca |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Ciemny ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Jasny nordycki |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Jasne cytrusy |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Jasny kwiatowy |

Zmiana motywu powoduje automatyczny restart aplikacji. (zapisywane w `theme.cfg`)

| Motyw | Motyw |
| :---: | :---: |
|**01. Motyw Classic**|**02. Motyw Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Motyw Dark**|**04. Motyw Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Motyw Nebula**|**06. Motyw Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Motyw Ocean**|**08. Motyw Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Motyw Citrus**|**10. Motyw Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### Tekstura Tła

Wybierz obraz na karcie **Background Texture** w zakładce Themes, aby zastosować go jako tło całej aplikacji. Obsługiwane formaty: `.png` / `.jpg` / `.jpeg`, do 50 MB, rozdzielczość 4K lub niższa. Obraz jest kompresowany jako JPEG Q75 z 16-bajtowym nagłówkiem magicznym i zapisywany jako `resources\textures\ui_bg\bg.dat` (atrybut Hidden). Hash SHA-256 do weryfikacji integralności; manipulacja wyzwala automatyczny reset + wyskakujące ostrzeżenie.

Gdy tło jest aktywne, przezroczystość interfejsu jest przetwarzana w dwóch warstwach: Warstwa 1 (nakładka MergedDictionaries) dla paneli `{DynamicResource}`, Warstwa 2 (WalkStyleBackgrounds) dla paneli opartych na `{StaticResource}` z półprzezroczystością.

### System Rozmiaru Czcionki

| Klucz zasobu | Baza | Opis |
|---|---|---|
| `AppBaseFontSize` | 13 | Normalny tekst |
| `AppBaseHeaderFontSize` | 16 | Nagłówki, tytuły paneli |
| `AppBaseSmallFontSize` | 12 | Etykiety drugorzędne |
| `AppBaseTinyFontSize` | 10 | Tekst podpowiedzi |
| `AppBaseLargeFontSize` | 20 | Duży tekst wyświetlania |

### Trwała Konfiguracja Interfejsu — `ui.cfg`

| Klucz | Domyślnie | Opis |
|-----|---------|-------------|
| `ModListWidth` | `150` | Szerokość listy w zakładce Mods (px) |
| `ProjectListWidth` | `150` | Szerokość listy projektów w zakładce Development (px) |
| `AppFontSize` | `13` | Globalny rozmiar czcionki interfejsu (px) |
| `AlwaysOnTop` | `false` | Okno zawsze na wierzchu |
| `TexturePath` | *(brak)* | Oryginalna nazwa pliku tekstury tła (tylko do wyświetlania) |
| `TextureHash` | *(brak)* | Hash SHA-256 tekstury tła |
| `TextureActive` | `false` | Stan aktywacji tekstury tła |
| `GamePathReset_{GameId}` | *(brak)* | Flaga resetu ścieżki gry |
| `SteamPathReset` | *(brak)* | Flaga resetu ścieżki Steam |
</details>

<details>
<summary><b>Struktura Projektu</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Trwałe ustawienia interfejsu
├── theme.cfg                            # Aktualny motyw
├── Windows/
│   ├── MainWindow.xaml / .cs            # Główny interfejs — 6 zakładek, Themes, Settings, ścieżka Steam,
│   │                                    #   ochrona przed pobraniem 0 bajtów, debounce suwaka, ciche odczyty konfiguracji
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup ścieżki gry (dynamiczny GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # Pierwsza konfiguracja + inicjalizacja domyślnych wartości
│       └── (14 innych SubWindows)
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
│   ├── Mod.cs                           # Ładowanie plików modów, parsowanie nagłówków LF/CRLF, log diagnostyczny
│   ├── ModLib.cs                        # Generowanie BaseModLib + remapowanie (podział #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Tworzenie/kompilacja/aplikowanie projektu + zabezpieczenia null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   zapobieganie ponownym próbom dla uszkodzonych modów
│   │   ├── ModViewModel.cs              # GameId ze ścieżki folderu
│   │   ├── ModProjectsViewModel.cs      # Dispose() dla DispatcherTimer
│   │   └── SettingsViewModel.cs         # Domyślna wartość true dla UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mapowanie wersji assemblies Mono 2.0 (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolver oparty na nazwie z cachowaniem
│   └── MonoHelper.cs                    # Narzędzia pomocnicze IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 plików językowych + langs.json (klucze LangTool.* dodane w v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Skompresowany i zabezpieczony obraz tła (generowany w czasie działania)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Pełne przepisanie w v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Pełne przepisanie w v2.0.9610
    │   ├── GH.xml                       # Pełne przepisanie w v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — nieobsługiwane
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt z parametrem silent
├── Data/
│   ├── Game.cs                          # Automatyczne tworzenie kopii zapasowej dla ApplyMods, warunkowy resolver,
│   │                                    #   fallback do folderu gry, poprawka lekkiego konstruktora + inicjalizacji ModLib
│   └── ModLib.cs                        # Podział #if DEBUG, fallback do folderu gry dla IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Walidacja nagłówka PE + metadanych CLR (tylko Release, min. 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Samodzielne narzędzie WPF do aktualizacji wersji
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Wprowadzanie wersji, przycisk Apply, wyświetlanie aktualnej wersji
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Samodzielne narzędzie WPF do zarządzania językami
├── App.xaml / App.xaml.cs              # Ładowanie/zmiana języka, langtool.cfg
├── MainWindow.xaml / .cs               # Główny interfejs — lista języków, panel edycji, selektor ścieżki
├── AddLanguageDialog.xaml / .cs        # ComboBox wyboru kraju ISO 3166-1
├── ModApiDialog.xaml / .cs             # Niestandardowe okno dialogowe w stylu ModAPI (Info/Ostrzeżenie/Potwierdzenie/Pytanie)
├── Models/
│   ├── LanguageEntry.cs                # Model wpisu językowego (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Model główny langs.json
│   └── IsoCountry.cs                   # Model kraju ISO dla ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Odczyt/zapis langs.json
    ├── FlagDownloader.cs               # Pobieranie flagi z flagcdn.com h24
    ├── XamlGenerator.cs                # Generowanie/zapis/parsowanie Language.XX.xaml
    ├── MissingKeyDetector.cs           # Wykrywanie brakujących kluczy względem referencji angielskiej
    ├── IsoCountryList.cs               # Pełna lista krajów ISO 3166-1 (196 krajów, offline)
    └── BuiltinCodeWriter.cs            # Przepisanie CreateDefaultLangsJson() + rejestracja w ModAPI.csproj

bin\Debug\                               # Tylko do testów Debug
├── create_dummy_Debug_games.ps1         # Generuje testową strukturę gry/Steam
├── dummy_games\{GameId}\               # Testowe ścieżki instalacji gier
├── dummy_steam\Steam.exe               # Testowy plik wykonywalny Steam
└── gamefiles\original\{GameId}\        # Testowe ścieżki kopii zapasowych dla ModLib
```

---

</details>

<details>
<summary><b>Instalacja i Konfiguracja</b></summary>

### Krok 1 — Wymagania Wstępne

| Element | Wymagane |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstalowany w Windows 11; [pobierz](https://dotnet.microsoft.com/download/dotnet-framework/net48) dla Windows 10) |
| Steam | Wymagane — musi być skonfigurowane w zakładce Settings |
| Co najmniej jedna wspierana gra | Wymagane — musi być skonfigurowana w zakładce Settings |

### Krok 2 — Instalacja ModAPI

1. Pobierz najnowszą wersję z GitHub
2. Rozpakuj do dowolnego folderu (np. `C:\ModAPI\`)
3. Uruchom `ModAPI.exe`
4. Przy pierwszym uruchomieniu pojawi się ekran **Welcome** — skonfiguruj preferencje i kliknij **Continue**

### Krok 3 — Konfiguracja Ścieżki Steam (Zakładka Settings)

1. Przejdź do zakładki **Settings**
2. Znajdź **Steam Installation Path**
3. Kliknij **Browse** → wybierz `Steam.exe`
4. Kliknij **Save**

### Krok 4 — Konfiguracja Ścieżek Gier (Zakładka Settings)

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

### Krok 5 — Pobieranie Modów (Zakładka Downloads)

1. Przejdź do zakładki **Downloads**
2. Wybierz grę z filtra gier
3. Przeglądaj lub wyszukaj moda i kliknij **Download**

> **Offline**: pobierz pliki `.mod` ręcznie z `modapi.survivetheforest.net` i umieść je w odpowiednim folderze:

| Gra | Folder |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Krok 6 — Aplikowanie Modów i Uruchamianie Gry (Zakładka Mods)

1. Przejdź do zakładki **Mods**
2. Wybierz grę w **Game Filter** (kolumna 0)
3. Zaznacz mody do aktywacji w **Mod List** (kolumna 1)
4. Kliknij **Start Game**

Przed uruchomieniem automatycznie wykonywane są następujące kontrole:

| # | Kontrola | Popup w przypadku niepowodzenia |
|---|---|---|
| 1 | Ścieżka Steam skonfigurowana i prawidłowa | SteamNotFound |
| 2 | Gra w folderze `mods/` odpowiada ścieżce gry w Settings | GameModsMismatch |
| 3 | Wybrano co najmniej jednego moda | NoModSelected |
| 4 | Brak mieszanych modów różnych gier w wyborze | MixedGameMods |
| 5 | Ścieżka gry skonfigurowana i plik wykonywalny istnieje | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Przegląd Zakładek</b></summary>

### Zakładka Welcome
Ekran pierwszej konfiguracji (indeks zakładki 0). Skonfiguruj AutoUpdate, połączenie Steam i preferencje tabeli VersionsData. Przy kolejnych uruchomieniach ta zakładka udostępnia linki społecznościowe i informacje o wydaniu.

### Zakładka Mods
Główny przepływ pracy zarządzania modami — układ 3-kolumnowy:

| Kolumna | Zawartość |
|---|---|
| Kolumna 0 | Game Filter — przyciski radiowe dla 5 wspieranych gier |
| Kolumna 1 | Mod List — zainstalowane mody z wyborem wersji i checkboksem aktywacji |
| Kolumna 2 | Information — szczegóły, opis i historia wersji wybranego moda |

### Zakładka Downloads
Przeglądaj i pobieraj mody z `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 kategorii (poprawki błędów, balans, cheaty, …)
- **Search**: po nazwie moda, opisie lub autorze
- **Offline mode**: wyświetla instrukcje folderów dla wszystkich 5 wspieranych gier

### Zakładka Development
Przepływ pracy rozwoju modów — panel filtra gier (kolumna 0) obejmuje wszystkie 5 wspieranych gier.

- Tworzenie, kompilacja i aplikowanie projektów modów dla każdej gry
- Zarządzanie zasobami językowymi
- Generowanie ModLib z 3-etapową walidacją (Steam → projekt → ścieżka gry)
- Bezpieczna zmiana gry za pomocą lekkiego konstruktora `Game` (bez wywołania `Verify()`)

### Zakładka Themes
Wybór motywu i zarządzanie teksturą tła.

- **Wybór motywu**: 10 motywów (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Tekstura tła**: wybierz obraz jako tło całej aplikacji (kompresja JPEG + przetwarzanie bezpieczeństwa)
- Gdy tekstura tła jest aktywna, wybór motywu jest zablokowany

### Zakładka Settings
Scentralizowana konfiguracja — 4 wiersze:

| Wiersz | Zawartość |
|---|---|
| 0 | Język / Rozmiar czcionki / Maksymalna szerokość / Szerokość Mod List / Szerokość Project List |
| 1 | Zachowaj VersionsData / Automatyczna aktualizacja / Połączenie Steam / Zawsze na wierzchu |
| 2 | Steam Installation Path (pole tekstowe + Browse + Save + Reset) |
| 3 | Game Installation Paths — rozwijalna karta dla każdej gry (pole tekstowe + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Narzędzie Zarządzania Językami)

Samodzielne narzędzie WPF do zarządzania plikami językowymi ModAPI. Dodane do rozwiązania jako `LangTool\MODAPI_LangTool.csproj`.

**Lokalizacja**: `LangTool\MODAPI_LangTool.csproj`

**Główne Funkcje**

| Funkcja | Opis |
|---|---|
| Lista języków | Wyświetla wszystkie języki z `langs.json` z ikonami statusu (🔒 wbudowany / 🚫 nieaktywny / ✅ aktywny) |
| Dodawanie języka | Wybierz kraj z ComboBox ISO 3166-1 → flaga jest automatycznie pobierana z `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` jest automatycznie generowany z angielskiego szablonu |
| Edycja języka | `isoCode` / `langCode` zablokowane; `langName` i klucze tłumaczeń są edytowalne, gdy aktywny |
| Dezaktywacja / Aktywacja | Przełącza flagę `active` w `langs.json` — plik jest zachowany, ukryty z listy ModAPI |
| Aktualizacja (wbudowywanie) | Konwertuje `builtin: false` → `true` — nieodwracalne, potwierdzenie w 2 krokach — automatycznie przepisuje `CreateDefaultLangsJson()` w kodzie źródłowym i rejestruje `Language.XX.xaml` w `ModAPI.csproj` |
| Wykrywanie brakujących kluczy | Porównuje z referencją angielską — pokazuje liczbę brakujących/pustych kluczy i postęp tłumaczenia |
| Ochrona wbudowanych | Języki z `builtin: true` są tylko do odczytu — brak możliwości edycji, dezaktywacji lub aktualizacji |
| Ochrona nieaktywnych | Języki z `active: false` są tylko do odczytu do momentu reaktywacji |
| Interfejs językowy | Sam LangTool obsługuje wszystkie 13 języków ModAPI — selektor języka z flagą w prawym górnym rogu |
| Zapamiętywanie ścieżki | Wybrana ścieżka główna ModAPI jest zapisywana w `langtool.cfg` — automatycznie ładowana przy następnym uruchomieniu |
| Niestandardowe okna dialogowe | Wszystkie popupy używają ciemnego motywu `ModApiDialog` w stylu ModAPI zamiast systemowego MessageBox |

**Struktura langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Konwencja Obrazów Flag**

```
Kod ISO (małe litery) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                        resources/langs/
```

**Zachowanie Przycisku Update**

Po kliknięciu przycisku Update dla aktywnego, niewbudowanego języka:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` przepisany ze wszystkimi aktualnie `builtin: true` językami
3. `ModAPI\ModAPI.csproj` — zarejestrowano `<Resource Include="resources\langs\Language.XX.xaml" />`
4. Następna kompilacja — język w pełni wbudowany, dostępny offline

**Dodane Klucze Językowe** (`Lang.LangTool.*`)

53 nowe klucze dodane do wszystkich 13 plików językowych obejmujące wszystkie ciągi interfejsu LangTool, komunikaty dialogowe i teksty statusu.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Narzędzie Aktualizacji Wersji)

Samodzielne narzędzie WPF do aktualizacji numeru wersji jednym kliknięciem.

**Lokalizacja**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Funkcje**
- Automatycznie wyświetla aktualną wersję (odczytaną z `App.xaml.cs`)
- Wprowadź nową wersję i kliknij **Apply Version**, aby zaktualizować oba pliki jednocześnie
- Walidacja formatu: akceptowany jest tylko format `X.X.XXXX`

**Zmodyfikowane Pliki**

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Użycie**
1. Uruchom `MODAPI_VersionTool.exe`
2. Wprowadź nową wersję (np. `2.0.9619`)
3. Kliknij **Apply Version**
4. Przebuduj rozwiązanie ModAPI w Visual Studio

**Wyświetlanie Wersji w StatusBar**

- `VersionLabel.Text` odwołuje się teraz do `App.Version` zamiast do zakodowanego na stałe deskryptora
- Aktualizacja wersji za pomocą VersionTool i przebudowa są natychmiast odzwierciedlane w StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### System Logowania — Rozdzielenie na Dwa Pliki (`ModAPI.log` / `ModAPI.detailed.log`)

Logi diagnostyczne przeznaczone wyłącznie dla deweloperów były wcześniej ograniczone przez `#if DEBUG`, przez co były niewidoczne w buildach Release dokładnie wtedy, gdy były najbardziej potrzebne do rozwiązywania problemów użytkownika. Zastępuje to system dwóch plików:

| Plik | Zawartość |
|---|---|
| `ModAPI.log` | Główny log dla użytkownika — niezmieniony wygląd, nie bardziej hałaśliwy niż wcześniej |
| `ModAPI.detailed.log` | Każde wywołanie logowania, zawsze, zarówno w Release jak i Debug — do diagnozowania problemów zgłaszanych przez użytkowników |

**`Debug.cs`** — `Log()` posiada parametr `detailedOnly`. Gdy jest `true`, komunikat jest zapisywany tylko w `ModAPI.detailed.log`; wszystkie wcześniejsze bloki `#if DEBUG` zostały przekonwertowane na tę flagę zamiast być całkowicie wykluczone z kompilacji, dzięki czemu są zawsze przechwytywane w szczegółowym pliku nawet w Release. Skutkuje to modelem ważności o 4 poziomach:

| Poziom | Znaczenie |
|---|---|
| Verbose (`detailedOnly: true`) | Powtarzalne/mechaniczne ślady — według typu, pliku, metody |
| Notice | Przepływ czytelny dla człowieka — komunikaty postępu i sukcesu |
| Warning | Potencjalne problemy, jeszcze nie awarie |
| Error | Potwierdzone awarie |

**Zidentyfikowane źródła szumu w logach, przekonwertowane na `detailedOnly: true`:**

| Plik | Co zalewało `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Komunikaty skanowania/pomijania/kolejkowania z `FindMods()` powtarzane przy każdym pollingu co 1 sekundę |
| `Game.cs` | Linie śledzenia TLS/URL z `UpdateVersions()`, wpisy mapowania typów Cecil |
| `ModLib.cs` | Przetwarzanie assemblies według typu/metody przez Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — odpowiedzialne za zdecydowaną większość objętości `ModAPI.log` (dziesiątki tysięcy linii dla pojedynczej kompilacji moda Green Hell) |
| `Mod.cs` | Pełny zrzut XML nagłówka moda (`configuration.ToString()`) rejestrowany w całości przy każdym ładowaniu moda |

**Logowanie niezgodności sumy kontrolnej — podsumowane zamiast pojedynczo:** `Header.Verify()` wcześniej rejestrowało jedną linię `Mismatched checksum at "..."` na każdy niezgodny wpis `InjectInto`/`AddMethod`/`AddField`/`AddClass`, co mogło oznaczać dziesiątki linii dla pojedynczego przestarzałego moda. Teraz rejestruje pojedyncze podsumowanie na poziomie Warning w `ModAPI.log` (np. `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), podczas gdy pełny podział na poszczególne pozycje pozostaje dostępny w `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Zmiany w v2.0.9621</b></summary>

## Zmiany w v2.0.9621

### Nowe funkcje

#### Wykrywanie automatyczne w całej bibliotece Steam

`FindGamePath()` teraz, gdy gra nie zostanie znaleziona przez zaszyte `SearchPaths`, przeszukuje również **wszystkie biblioteki Steam zarejestrowane w systemie** (parsowane raz z `libraryfolders.vdf`, buforowane na czas sesji). Dotyczy to wszystkich 5 obsługiwanych gier, nie tylko aktualnie aktywnej.

- Nowa `Game.GetSteamLibraryFolders()` — parsuje `libraryfolders.vdf`, statyczny bufor per sesja
- Sterowane checkboxem **Połączenie ze Steam**: wyłączone (domyślne przy nowej instalacji) → automatyczne wykrywanie jest pomijane dla wszystkich 5 gier, ścieżki pozostają puste do ręcznego ustawienia. Włączone → wszystkie 5 gier jest przeszukiwanych konsekwentnie tą samą metodą.

#### Automatyczne wykrywanie modów dla niewłaściwej gry

Plik `.mod` umieszczony w folderze niewłaściwej gry (np. mod do Green Hell skopiowany do `mods\TheForest\`) jest teraz wykrywany automatycznie, zamiast po cichu psuć operację Apply.

- `Game.CheckModGameCompatibility()` (używana wewnątrz `ApplyMods()`) sprawdza przed rozpoczęciem wstrzykiwania, czy każdy typ `AddMethod`/`AddField`/`InjectInto` zadeklarowany przez mod rzeczywiście istnieje w prawdziwych assembly gry docelowej. Niepasujące mody są automatycznie wykluczane z tego Apply; reszta jest stosowana normalnie.
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` wykonują tę samą kontrolę w momencie wczytywania moda (lekka wersja — wczytuje bajty assembly do pamięci, wyodrębnia nazwy typów, natychmiast zwalnia plik). Niepasujące mody pokazują **odznakę ostrzeżenia ⚠** z podpowiedzią w zakładce Mods, jeszcze zanim naciśnięty zostanie Apply.
- Jeśli mody zostały wykluczone i/lub ostatecznie nic nie zostało zastosowane, Start Game pokazuje jeden połączony popup zamiast kilku ułożonych jeden na drugim; gra nie uruchamia się, jeśli nie pozostał żaden zastosowany mod (`Game.LastAppliedModCount`).

#### Zakładka Ustawienia — Dziennik dewelopera / Czyść dzienniki przy starcie

Dwie nowe checkboxy, po **Połączenie ze Steam** i przed **Zawsze na wierzchu**:

| Klucz | Opis |
|---|---|
| `Lang.Options.Labels.DevLog` | Włącza `ModAPI.dev.log` (przemianowany z `ModAPI.detailed.log`) — odpowiada uruchomieniu z `--dev` |
| `Lang.Options.Labels.ClearLogsOnStart` | Czyści folder `logs\` przy każdym starcie |

`Debug.ClearLogs()` zamyka otwarte strumienie dzienników przed usunięciem plików, unikając błędów "plik w użyciu".

#### Globalne rejestrowanie nieobsłużonych wyjątków

`App.xaml.cs` teraz przechwytuje `DispatcherUnhandledException` (wątek UI) i `AppDomain.UnhandledException` (wątki w tle). Wyjątki, które wcześniej powodowały awarię aplikacji bez żadnego śladu, są teraz rejestrowane — typ, komunikat i pełny ślad stosu — przed zakończeniem procesu.

---

### Krytyczne poprawki błędów

| # | Plik | Problem | Poprawka |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` rozwiązywał jawnie zresetowaną (pustą) ścieżkę do `RootPath` zamiast `""`, ponieważ `Path.GetFullPath(RootPath + separator + "")` redukuje się do `RootPath` | Puste zapisane wartości teraz zwracają bezpośrednio `""`, przed połączeniem ścieżek |
| 2 | `MainWindow.xaml.cs` | Kolejność walidacji Start Game różniła się między filtrem "Wszystkie" a konkretnym filtrem, czasem pokazując popup wyboru moda lub gry przed bardziej fundamentalnym problemem (brak ścieżki Steam/gry) | Obie ścieżki mają teraz tę samą kolejność: Steam → ścieżka gry → wybór modów → wybór gry |
| 3 | `MainWindow.xaml.cs` | Zbieranie modów dla Start Game ignorowało aktywny filtr gry — zaznaczone mody dla innej (niewidocznej) gry były nadal liczone, wywołując zły popup | Zbieranie modów teraz uwzględnia bieżący filtr; tylko "Wszystkie" agreguje wszystkie gry |
| 4 | `ModsViewModel.cs` | `Mod.Mods` był indeksowany tylko przez `{ModId}-{Wersja}`, więc identyczne nazwy plików w dwóch różnych folderach gier kolidowały — `Load()` drugiego nigdy nie było wywoływane | Klucz zawiera teraz GameId: `{GameId}-{ModId}-{Wersja}` |
| 5 | `ModsViewModel.cs` | Po poprawce #4 `UpdateMods()` nadal grupowała wpisy listy tylko po ModId, łącząc dwa mody o tej samej nazwie z różnych gier w jeden wpis — awaria z `ArgumentException: An item with the same key has already been added`, gdy oba deklarowały tę samą wersję | Grupowanie wyświetlania teraz porównuje też GameId |
| 6 | `Game.cs` | Lista `<files>` w `Versions.xml` Green Hell zawiera te same dwa pliki podwójnie z różną wielkością liter (`_Data`/`_data`); `CheckFiles` był `HashSet<string>` rozróżniającym wielkość liter, więc oba były haszowane, podwajając obliczoną sumę kontrolną i powodując fałszywe błędy integralności | `CheckFiles` używa teraz `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | Krok "usuń stare pliki" w `ModLib.Create()` nie miał ochrony przed zablokowanym `BaseModLib.dll` w postaci ponawiania prób, a `Game.CreateModLibrary()` nie miała żadnej obsługi wyjątków — blokada powodowała awarię całej aplikacji w wątku w tle | Dodano pętlę ponawiania 10×500ms do kroku usuwania; `CreateModLibrary()` teraz obudowuje wywołanie w try/catch |
| 8 | `MainWindow.xaml.cs` | Gdy `ApplyMods()` kończyła się bez faktycznego zastosowania żadnego moda (np. wszystkie wykluczone), i tak sygnalizowała zakończenie jak prawdziwy sukces, więc gra uruchamiała się bez żadnej modyfikacji | `Game.LastAppliedModCount` rozróżnia "nic nie zastosowano" od "zastosowano N"; uruchomienie jest pomijane przy 0 |
| 9 | `MainWindow.xaml.cs` | Wysokość okna nie była przeliczana ani przy zmianie rozmiaru czcionki, ani przy wczytaniu przy starcie zapisanego dużego rozmiaru czcionki, ani przy przełączeniu na zakładkę Ustawienia (`Tabs_SelectionChanged` była pusta) — przy dużych rozmiarach czcionki ostatnia karta ścieżki gry była przycinana | Dodano przeliczanie wysokości we wszystkich trzech miejscach |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` nie miała górnego limitu — rozwinięcie wszystkich 5 kart ścieżek gier naraz mogło powiększyć okno do rozmiaru całego ekranu lub większego | Wysokość ograniczona teraz do `SystemParameters.WorkArea.Height` |
| 11 | `MainWindow.xaml.cs` | Foldery `mods\`/`projects\` były tworzone bezwarunkowo dla wszystkich 5 gier przy każdym starcie, niezależnie od tego, czy gra była zainstalowana | Foldery są teraz tworzone tylko dla gier ze zweryfikowaną ścieżką i istniejącym plikiem wykonywalnym |
| 12 | `Game.cs` | `UpdateVersions()` mogła nie zapisać `Versions.xml`, jeśli folder docelowy jeszcze nie istniał (dotychczas maskowane, ponieważ wszystkie 5 folderów jest dostarczanych wcześniej zatwierdzonych) | Folder jest tworzony przez `Directory.CreateDirectory()` tuż przed zapisem |

---

### Zakładka Ustawienia — Zmienione wartości domyślne przy pierwszym uruchomieniu

`AutoUpdate`, `UseSteam` (Połączenie ze Steam) i `UpdateVersionsTable` (Utrzymuj tabelę VersionsData) domyślnie są teraz **odznaczone** przy nowej instalacji (wcześniej domyślnie zaznaczone). Te trzy funkcje wciąż są niekompletne po stronie serwera, więc teraz są opt-in — tak jak `DevLog`/`ClearLogsOnStart`.

### UI

- Wiersz checkboxów zakładki Ustawienia (`SettingsCheckboxes`): `StackPanel` → `WrapPanel`, dzięki czemu etykiety zawijają się do nowej linii zamiast być przycinane przy dużych rozmiarach czcionki.

### Nowe klucze językowe (13 języków)

| Klucz | Wartość angielska |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### Zmodyfikowane pliki

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Ujednolicona kolejność walidacji Start Game, zbieranie modów uwzględniające filtr, połączony popup wyników, automatyczne wykrywanie 4 gier przez bibliotekę Steam sterowane UseSteam, poprawki wysokości okna (rozmiar czcionki / zmiana zakładki / limit) |
| `MainWindow.xaml` | `ModAPI\Windows\` | Checkboxy DevLog/ClearLogsOnStart w zakładce Ustawienia, `WrapPanel` |
| `Game.cs` | `ModAPI_Shared\Data\` | Wyszukiwanie w bibliotece Steam, `CheckFiles` niewrażliwy na wielkość liter, kontrole zgodności modów (pełna + lekka), `LastAppliedModCount`/`LastExcludedModsSummary`, obsługa wyjątków w `CreateModLibrary()`, automatyczne wykrywanie sterowane UseSteam |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Pętla ponawiania przy usuwaniu starych plików |
| `Mod.cs` | `ModAPI_Shared\Data\` | Pole `GameMismatchReason` |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Poprawka błędu pustej ścieżki w `GetPath()` |
| `Debug.cs` | `ModAPI_Shared\` | Zmiana nazwy na `ModAPI.dev.log`, pole `DevMode`, `ClearLogs()` |
| `App.xaml.cs` | `ModAPI\` | Globalne uchwyty wyjątków, powiązanie `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Klucze `Mod.Mods` per gra, grupowanie wyświetlania per gra, odznaka niezgodności, tłumienie spamu w dziennikach |
| `ModViewModel.cs` | `ModAPI\Data\ViewModels\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\Data\ViewModels\` | `DevLog`/`ClearLogsOnStart`, domyślne wartości opt-in dla 3 istniejących checkboxów |
| `FirstSetup.xaml` | `ModAPI\Windows\SubWindows\` | Domyślne wartości 3 checkboxów zmienione na odznaczone |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\Windows\SubWindows\` | Nowy |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 8 nowych kluczy |

---

</details>

<details>
<summary><b>Zmiany w v2.0.9620</b></summary>

## Zmiany w v2.0.9620

### Dodano MODAPI_LangTool

Dodano samodzielne narzędzie WPF do zarządzania plikami językowymi ModAPI (`LangTool\MODAPI_LangTool.csproj`) — pełne szczegóły w sekcji **Lang Tool** powyżej.

---

### Poprawki Błędów

| # | Plik | Problem | Poprawka |
|---|---|---|---|
| 1 | `App.xaml.cs` | Francuski mieszał się z komunikatami wyjątków .NET na nieanglojęzycznym Windowsie | `CultureInfo.InvariantCulture` ustalony przy starcie konstruktora `App()` |
| 2 | `Game.cs` | Błąd SSL/TLS przy `UpdateVersions()` — nie można było utworzyć bezpiecznego kanału SSL/TLS | TLS 1.2 ustawiony jawnie przez `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Popup `GamePathNotSet` dla Green Hell mimo skonfigurowanej ścieżki | `App.Game.GamePath` puste → odczytuje zapisaną ścieżkę z `Configuration` |
| 4 | `ModsViewModel.cs` | Pliki modów nie pojawiały się na liście po ręcznym umieszczeniu w `mods\TheForest\` | Dodano log diagnostyczny walidacji wzorca nazwy pliku |
| 5 | `MainWindow.xaml.cs` | Popup `MixedGameMods` blokował wybór modów z wielu gier | Usunięto blokujący popup — zastąpiono `SelectGameDialog` |

---

### Nowe Funkcje

#### Uruchamianie Gry — Popup Wyboru Gry (`SelectGameDialog`)

Gdy wybrane są mody z różnych gier lub gdy aktywny jest filtr **All**, zamiast blokowania uruchomienia pojawia się popup wyboru gry.

**Warunki wyzwalające:**
- Wybrano filtr `All` + kliknięto Start Game
- Jednocześnie aktywowano mody z 2 lub więcej różnych gier

**Zachowanie:**
- Wyświetla tylko gry ze skonfigurowanymi ścieżkami i istniejącym plikiem wykonywalnym
- Aplikowane są tylko mody wybranej gry — mody innych gier są całkowicie ignorowane
- Przycisk radiowy synchronizuje się z wybraną grą po zamknięciu popupu (`SyncModGameFilterRadioButton`)

**Nowe pliki**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Weryfikacja Integralności Gry (tylko build Release, `#if !DEBUG`)

Przed każdym uruchomieniem gry przeprowadzana jest trzywarstwowa kontrola integralności:

| Warstwa | Metoda | W przypadku niepowodzenia |
|---|---|---|
| A — Nagłówek PE | `FileValidator.IsValidGameExe()` | Zablokowane + popup `GameExeCorrupted` |
| B — Suma kontrolna assembly | Porównanie MD5 → `Versions.xml` | Zablokowane + popup `GameAssemblyTampered` |
| C — Podpis cyfrowy | `HasDigitalSignature()` | Ostrzeżenie + wybór użytkownika (`GameIntegrityWarning`) |

**Nowe pliki**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Nowe metody dodane do `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 pliku Assembly-CSharp.dll (+ firstpass jeśli istnieje)
- `HasDigitalSignature(path)` — sprawdzenie podpisu Authenticode

---

### Nowe Logi Diagnostyczne

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 pozycji, Release + Debug)

| # | Faza | Typ | Zawartość |
|---|---|---|---|
| 1 | Ustawienie TLS | Notice | Protokół przed/po |
| 2 | Rozpoczęcie pobierania | Notice | Lista serwerów |
| 3 | Próba URL | Notice | Każdy testowany URL |
| 4 | Udane pobieranie | Notice | URL, długość odpowiedzi, użyty protokół |
| 5 | WebException | Error | URL, status HTTP, protokół, szczegóły |
| 6 | Inny wyjątek | Error | URL, typ wyjątku, szczegóły |
| 7 | Pobieranie zakończone | Notice | Liczba sukcesów / łączna liczba serwerów |
| 8 | Udane parsowanie | Notice | Liczba plików i wersji przed/po |
| 9 | Nieudane parsowanie | Error | Typ wyjątku i szczegóły |
| 10 | Udany zapis | Notice | Ścieżka zapisu, łączna liczba wersji/plików |
| 11 | Nieudany zapis | Error | Ścieżka, typ wyjątku, szczegóły |
| 12 | Brak odpowiedzi | Error | Testowane serwery, protokół |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 pozycji, tylko `#if DEBUG`)

| # | Sytuacja | Typ | Zawartość |
|---|---|---|---|
| 1 | Rozpoczęcie skanowania | Notice | Ścieżka folderu modów, łączna liczba znalezionych plików |
| 2 | Już załadowany | Notice | Nazwa pliku |
| 3 | Nie plik .mod | Notice | Nazwa pliku |
| 4 | Udane dopasowanie wzorca | Notice | Nazwa pliku dodana do kolejki |
| 5 | Nieudane dopasowanie wzorca | Warning | Nazwa pliku + powód + oczekiwany format |
| 6 | Skanowanie zakończone | Notice | Liczba w kolejce / łączna liczba plików |
| 7 | Wyjątek | Error | Szczegóły wyjątku |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 pozycji, Release + Debug)

| # | Sytuacja | Typ | Zawartość |
|---|---|---|---|
| 1 | Warunek popupu | Notice | Aktualny filtr, wybrane ID gier, needGameSelect |
| 2 | Kandydujące gry | Notice | Lista ID kandydatów do popupu |
| 3 | Ścieżka nieustawiona | Notice | Gra pominięta — ścieżka nieskonfigurowana |
| 4 | Brak w Configuration | Notice | Gra pominięta — brak w Configuration.Games |
| 5 | Instalacja potwierdzona | Notice | Gra + ścieżka pliku wykonywalnego |
| 6 | Exe nie znaleziono | Warning | Gra pominięta — brak pliku wykonywalnego |
| 7 | Brak zainstalowanych gier | Error | 0 kandydatów → GamePathNotSet |
| 8 | Automatyczny wybór | Notice | Automatycznie wybrano jedynego kandydata |
| 9 | Anulowane przez użytkownika | Notice | Anulowano SelectGameDialog |
| 10 | Wybrano grę + mody | Notice | Wybrana gra, liczba/lista zebranych modów |

---

### Rozdzielenie Logów Deweloperskich / Użytkownika (`#if DEBUG`)

| Plik | Log | Powód |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Powtarza się co sekundę — 81% całkowitej objętości logów |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Szczegóły wewnętrzne przeznaczone wyłącznie dla deweloperów |

Log Release zachowuje: sukces/niepowodzenie pobierania, wyniki parsowania/zapisu, nieudane dopasowania wzorców, wyjątki, wyniki kontroli integralności.

---

### Aktualizacja Tabeli Wersji — Architektura

#### Zamysł Projektowy

```
Gra otrzymuje aktualizację Steam
  → Assembly-CSharp.dll się zmienia
  → ModAPI sprawdza Versions.xml pod kątem znanej sumy kontrolnej
  → Jeśli nie znaleziono → pobiera najnowszy Versions.xml z serwera
  → Nowa wersja jest automatycznie rejestrowana bez ponownej instalacji ModAPI
```

#### Struktura Połączenia

```
Zakładka Settings → checkbox KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → wywołanie UpdateVersions()
      → pobiera Versions.xml z VersionUpdateDomains[]
      → nadpisuje lokalny configs\games\{GameId}\Versions.xml
```

#### Integracja URL Raw GitHub

Zamiast polegać wyłącznie na `modapi.survivetheforest.net`, URL Raw GitHub jest teraz używany jako podstawowe źródło do bezpośredniego zarządzania:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — zarządzany bezpośrednio, priorytet 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Serwer legacy — fallback, priorytet 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Element | Szczegóły |
|---|---|
| Podstawowy | URL Raw GitHub — natychmiast aktualizowany po push |
| Fallback | Serwer legacy — używany, gdy GitHub jest niedostępny |
| Ścieżka | `ModAPI/configs/games/{GameId}/Versions.xml` w repozytorium |
| Zmodyfikowany plik | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Aktualizacje Versions.xml

| Gra | Plik | Zmiana |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Poprawiona suma kontrolna (był błędny SHA-256 wielkimi literami) — `2.9.5b114117` z poprawnym MD5 |
| The Forest | `configs\games\TheForest\Versions.xml` | Dodano `1.12` (BuildID: 20229486) — 128-znakowa suma kontrolna MD5 |

---

### Nowe Klucze Językowe (13 języków)

| Klucz | Wartość angielska |
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
| `Lang.Savegames.*` (133 klucze) | Wartości angielskie dodane do 12 języków (DE już przetłumaczone) |

---

### Zmodyfikowane Pliki

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` ustalony przy starcie |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, kontrola integralności, usunięto MixedGameMods, synchronizacja radio, 10 logów |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nowy |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nowy |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Log diagnostyczny nazwy pliku, podział #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 logów UpdateVersions, URL GitHub, podział #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 nowych kluczy + 133 klucze Savegames (515 łącznie, wszystkie języki dopasowane) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Poprawiona suma kontrolna |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | Dodano `1.12` |
| `LangTool\` (13 plików) | Korzeń rozwiązania | Nowy |
| `ModAPI.sln` | Korzeń rozwiązania | Zarejestrowano LangTool |

---

### Dodatkowe Poprawki i Przebudowa Systemu Logowania (2026-06-21)

#### Walidacja StartGame — Pełne Przeprojektowanie

Kolejność walidacji poprawiono na ścisłą 3-etapową sekwencję, a popup wyboru gry teraz odzwierciedla aktywowane mody niezależnie od tego, czy ścieżka gry jest skonfigurowana.

| Krok | Kontrola | Popup w przypadku niepowodzenia |
|---|---|---|
| 1 | Steam zainstalowany | SteamNotFound |
| 2 | Ścieżka wybranej gry skonfigurowana + plik wykonywalny istnieje | GamePathNotSet |
| 3 | Co najmniej jeden mod aktywowany dla wybranej gry | NoModSelected |

- **Wybrano filtr All / mody wielu gier** → popup zawsze wyświetla wszystkie gry z aktywowanym modem, **w tym te bez skonfigurowanej ścieżki** — wybór nieskonfigurowanej gry teraz poprawnie pokazuje `GamePathNotSet` zamiast po cichu ją wykluczać lub pokazywać niewłaściwy błąd
- **Filtr pojedynczej gry** → kontrole ścieżki i modów są wykonywane bezpośrednio dla tej gry, w tej samej kolejności 1→2→3

#### Krytyczne Poprawki Błędów

| # | Plik | Problem | Poprawka |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` łączył odpowiedzi z **wszystkich** udanych serwerów (GitHub + legacy), podwajając sumy kontrolne (64 → 128 znaków), gdy oba się powiodły — powodowało fałszywe blokady `GameAssemblyTampered` | Parsowana jest tylko odpowiedź pierwszego udanego serwera; pozostałe serwery są pomijane, gdy jeden się powiedzie |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` używał `App.Game` (aktualnie aktywny filtr) zamiast własnej gry moda — usunięcie moda Green Hell podczas aktywności The Forest przeszukiwało niewłaściwy folder `Managed` i po cichu pomijało usunięcie | Teraz rozwiązuje ścieżkę wdrożonej DLL z `mod.Game` (rzeczywistej instancji gry moda), z fallbackiem do `Configuration`, jeśli `GamePath` jest puste |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Ponowne pobranie wcześniej usuniętego moda przywracało jego odznakę aktywacji jako zaznaczoną — usunięcie moda nigdy nie czyściło jego trwałych kluczy `Selected`/`Version` ani pamięci podręcznej ViewModel | Dodano `RemoveKey()` / `RemoveKeysWithPrefix()` do `Configuration.cs`; `DeleteMod_Click` wymusza teraz `ModViewModel.Selected = false` i usuwa wszystkie klucze `Mods.{GameId}.{ModId}.*` przy usunięciu |
| 4 | `ModsViewModel.cs` | Usunięcie moda przy wybranym konkretnym filtrze gry (nie „All”) pozostawiało moda widocznego na liście aż do przełączenia na „All” i z powrotem | Brakowało powiadomienia o zmianie `FilteredMods` po `_Mods.RemoveAt()` w pętli pollingu usuwania plików; teraz uruchamia się za każdym razem, gdy mod jest faktycznie usuwany |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Nieobsłużony wyjątek podczas tworzenia lub wyświetlania popupu ostrzeżenia o braku podpisu mógł po cichu spowodować awarię ModAPI bez zarejestrowanego błędu | Tworzenie/wyświetlanie popupu i formatowanie komunikatów zostały opakowane w try-catch; w przypadku niepowodzenia ostrzeżenie jest rejestrowane, a użytkownik może bezpiecznie kontynuować (brak podpisu jest informacyjny, nie jest twardą blokadą) |

#### Ostrzeżenie o Podpisie Cyfrowym — Wyjaśniony Komunikat

Tekst `GameNoSignature` teraz podaje nazwę konkretnej gry i wyjaśnia, że brak podpisu jest oczekiwany dla tytułów niezależnych i nie wpływa na rozgrywkę, zamiast sugerować możliwą manipulację. Zaktualizowano we wszystkich 13 plikach językowych z placeholderem `{0}` dla wyświetlanej nazwy gry (np. „The Forest”, „Green Hell”).

#### System Logowania — Rozdzielenie na Dwa Pliki

Logi diagnostyczne ograniczone przez `#if DEBUG` zostały przekonwertowane na flagę `detailedOnly` i podzielone między `ModAPI.log` (dla użytkownika) i `ModAPI.detailed.log` (zawsze pełne szczegóły) — pełny podział w sekcji **Log** powyżej.

#### Zmodyfikowane Pliki (Dodatkowe)

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Przeprojektowanie walidacji StartGame, poprawka instancji gry w DeleteMod_Click, try-catch dla GameIntegrityWarning, mapowanie wyświetlanych nazw |
| `Game.cs` | `ModAPI_Shared\Data\` | Poprawka pojedynczej odpowiedzi w UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Powiadomienie o zmianie `FilteredMods` przy usunięciu, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 punktów wywołania) |
| `Mod.cs` | `ModAPI\Data\` | Zrzut XML nagłówka przeniesiony do `detailedOnly`, podsumowanie niezgodności sum kontrolnych |
| `Debug.cs` | `ModAPI_Shared\` | Parametr `detailedOnly`, zapis do dwóch plików, komentarz przewodnika logowania na 4 poziomach |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Placeholder `{0}` dla nazwy gry, zabezpieczenie try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` przepisany z placeholderem nazwy gry |

---


</details>

<details>
<summary><b>Zmiany w v2.0.9619</b></summary>

### Poprawki Błędów

- **Blokada aplikowania modów przy pustym folderze kopii zapasowej**: pusty `gamefiles\original\` → automatyczne tworzenie kopii zapasowej ze ścieżki instalacji gry przed odczytem assembly
- **Blokada pliku (IOException) na DLL gry**: resolver assemblies warunkowo wyklucza folder gry, gdy istnieje kopia zapasowa — zapobiega utrzymywaniu blokad plików przez Cecil podczas `DirectoryCopy`
- **Nieskończona pętla ponownych prób dla uszkodzonych modów**: nieudane pliki `.mod` (uszkodzony nagłówek) powodowały pętlę ponownego skanowania co 1 sekundę — teraz rejestrowane w `LoadedFiles`, aby zapobiec ponownemu skanowaniu
- **Odrzucane pliki modów z zakończeniami linii LF**: parser nagłówka `EndsWith("</Mod>\r")` zawodził dla plików `.mod` w stylu Unix — teraz używa `TrimEnd`, aby obsłużyć zarówno CRLF, jak i LF
- **Niepowodzenie walidacji małych DLL**: `Assembly-UnityScript-firstpass.dll` (21 KB) był odrzucany przez `FileValidator` — minimalny rozmiar assembly obniżono z 64 KB do 8 KB
- **Niepotrzebne logi WARNING**: nieskonfigurowane ścieżki gier i klucze konfiguracji przy pierwszym uruchomieniu generowały szum — dodano parametr `silent` do `GetPath`/`GetString`/`GetInt`

### Ulepszenia

- **Wykrywanie pobrań 0 bajtów**: alert popup + czyszczenie plików tymczasowych, gdy serwer zwraca pusty plik `.mod` (`Lang.Windows.DownloadEmpty`)
- **Debounce zapisu suwaka**: `ModListWidth` / `ProjectListWidth` zapisywane w `ui.cfg` tylko raz (500 ms po zakończeniu przeciągania) zamiast przy każdej zmianie piksela
- **Warunkowe tworzenie folderów gier**: foldery `mods/` i `projects/` są tworzone tylko dla gier ze skonfigurowanymi ścieżkami — nie bezwarunkowo dla wszystkich 5
- **Log diagnostyczny parsowania nagłówka**: pokazuje liczbę linii i podgląd zawartości przy niepowodzeniu parsowania pliku `.mod`, ułatwiając rozwiązywanie problemów

### Nowe Klucze Językowe (13 języków)

| Klucz | Wartość angielska |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Zmodyfikowane Pliki

| Plik | Ścieżka | Zmiana |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Automatyczne tworzenie kopii zapasowej, warunkowy resolver, fallback do folderu gry |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Fallback do folderu gry dla IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Parametr `silent` w GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Ochrona przed pobraniem 0 bajtów, debounce suwaka, ciche odczyty konfiguracji, warunkowe tworzenie folderów |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Zapobieganie ponownym próbom dla uszkodzonych modów |
| `Mod.cs` | `ModAPI\Data\` | Parsowanie nagłówków LF/CRLF, log diagnostyczny |
| 13× `Language.XX.xaml` | `resources\langs\` | Klucze popupu `DownloadEmpty` |

---

</details>

<details>
<summary><b>Zmiany w v2.0.9618</b></summary>


### Dodano MODAPI_VersionTool

Dodano samodzielne narzędzie WPF do aktualizacji numeru wersji jednym kliknięciem (`VersionTool\MODAPI_VersionTool.csproj`) — pełne szczegóły w sekcji **Version Tool** powyżej.

- `VersionLabel.Text` odwołuje się teraz do `App.Version` zamiast do zakodowanego na stałe `Version.Descriptor`, więc aktualizacje są natychmiast odzwierciedlane w StatusBar po przebudowie.

---

</details>

<details>
<summary><b>Zmiany w v2.0.9617</b></summary>


### Zakładka Settings — Dodano Przyciski Resetowania Ścieżki

Dodano przycisk **Reset** do wiersza ścieżki instalacji Steam oraz każdego wiersza ścieżki instalacji gry.

**Wiersz ścieżki Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Wiersz ścieżki gry (dla każdej gry)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Zachowanie Reset**
- Natychmiast czyści pole tekstowe ścieżki
- Zapisuje flagę resetu w `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Pole tekstowe pozostaje puste po ponownym uruchomieniu
- Omija problem, w którym Configuration XML nie zachowuje pustych ciągów

**Automatyczny zapis Browse**
- Wcześniej: wymagane było oddzielne kliknięcie Save po Browse
- Teraz: automatyczny zapis przy wyborze pliku — odzwierciedlane nawet po przełączeniu na zakładkę Mods

**Nowy klucz językowy**

| Klucz | Wartość |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Zmiany w v2.0.9616</b></summary>

### Versions.xml — 4 Gry Dodane / Zaktualizowane

| Gra | Ścieżka pliku | BuildID | Uwagi |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Nowo utworzony |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Zaktualizowana suma kontrolna |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Nowo utworzony |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Zaktualizowana suma kontrolna |

### Zasady Kompozycji Sumy Kontrolnej

Format sumy kontrolnej różni się w zależności od tego, czy `Assembly-CSharp-firstpass.dll` istnieje dla danej gry.

| Gra | firstpass.dll | Format sumy kontrolnej |
|---|---|---|
| GH | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| Subnautica | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| EscapeThePacific | ✅ Obecny | `firstpass MD5` + `Assembly-CSharp MD5` połączone (64 znaki) |
| Raft | ❌ Nieobecny | tylko `Assembly-CSharp MD5` (32 znaki) |

### Procedura Aktualizacji Versions.xml przy Aktualizacji Gry

Dodaj nowy wpis `<version>` bez usuwania istniejących wpisów.

**Krok 1 — Znajdź nowy BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Gra | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Krok 2 — Wyodrębnij nową sumę kontrolną**
```powershell
# Gry z firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Połącz obie wartości Hash w kolejności (firstpass jako pierwszy)

# Gry bez firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Krok 3 — Dodaj wpis do Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Zmiany w v2.0.9615</b></summary>

### Poprawiono Rozwijanie Ścieżki Gry w Zakładce Settings

- **Wysokość rozwinięcia karty**: dolna część okna teraz rośnie dokładnie o wysokość pola wprowadzania podczas rozwijania karty ścieżki gry
- **Ulepszenie `UpdateWindowHeight()`**: wywołuje `UpdateLayout()` przed pomiarem `SizeToContent.Height`; tymczasowo ustawia `TextureLayer1` na `Collapsed`, gdy tekstura tła jest aktywna, aby zapobiec wpływowi oryginalnego rozmiaru obrazu 4K na obliczanie wysokości
- **Poprawka wewnętrznego wiersza Grid**: ostatni wiersz wewnętrznego Grid panelu ścieżek gier zmieniono z `Height="*"` na `Height="Auto"` — usuwa niepotrzebną pustą przestrzeń na dole

---

</details>

<details>
<summary><b>Zmiany w v2.0.9614</b></summary>

### Poprawiono Zachowanie Przycisku Maksymalizacji

- **Maksymalizacja**: używa `SystemParameters.WorkArea` do ręcznej maksymalizacji zamiast `WindowState.Maximized` — dopasowuje się dokładnie do aktualnej rozdzielczości ekranu bez nakładania się na pasek zadań
- **Przywracanie**: zapisuje `Left`, `Top`, `Width`, `Height` i `MaxWidth` przed maksymalizacją i przywraca je po kliknięciu przycisku przywracania
- **Obsługa `MaxWidth`**: ustawiona na `∞` przy maksymalizacji, przywracana do zapisanej wartości przy normalizacji

---

</details>

<details>
<summary><b>Zmiany w v2.0.9613</b></summary>

### Nowa Zakładka Themes

Kolejność zakładek jest teraz:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Interfejs wyboru motywu został przeniesiony z zakładki Settings do dedykowanej zakładki **Themes**.
Ikona: Segoe MDL2 Assets `&#xE790;` (paleta)

### Rejestr Motywów (Struktura Oparta na Danych)

Dodanie nowego motywu wymaga teraz tylko **jednej linii** w słowniku `App.xaml.cs`.
Wszystkie instrukcje switch zostały usunięte — nie są wymagane żadne zmiany kodu w innym miejscu.

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

Elementy ComboBox `ThemeSelector` są automatycznie generowane z pętli `ThemeIds`.
Konwencja kluczy językowych: `Lang.Options.Theme.{PascalCase}` (np. `Lang.Options.Theme.Nebula`)

### Wspierane Motywy

| Indeks | ID | Plik | Paleta |
|---|---|---|---|
| 0 | `classic` | tylko `Dictionary.xaml` | Oryginalne tło teksturowe ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Jasny ton + niebieski akcent |
| 2 | `dark` | `FluentStyles.xaml` | Ciemny ton + niebieski akcent (domyślny) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Czerwony + czarny |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Ciemna przestrzeń |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Jasny zachód słońca |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Ciemny ocean |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Jasny nordycki |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Jasne cytrusy |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Jasny kwiatowy |

Zmiana motywu powoduje automatyczny restart aplikacji. (zapisywane w `theme.cfg`)

### Funkcja Tekstury Tła

Wybierz obraz na karcie **Background Texture** w zakładce Themes, aby zastosować go jako tło całej aplikacji. Działa z dowolnym wybranym motywem.

**Wspierane formaty wejściowe**: `.png` / `.jpg` / `.jpeg`, do 50 MB, rozdzielczość 4K lub niższa

**Potok Przetwarzania Obrazu**

```
Obraz wybrany przez użytkownika (.png / .jpg / .jpeg, maks. 50 MB, 4K lub niższa)
  ↓
Kompresja JPEG Q75 (bufor pamięci)
  ↓
Wstawiono 16-bajtowy nagłówek magiczny
  "MODAPI" + "BG" + wersja + wypełnienie (FF 00 FE 00)
  ↓
Zapisano jako resources\textures\ui_bg\bg.dat (atrybut Hidden)
  ↓
Hash SHA-256 → zapisany w ui.cfg jako TextureHash
```

**Warstwy Bezpieczeństwa**

| Warstwa | Metoda | Efekt |
|---|---|---|
| Nagłówek magiczny | 16 bajtów dodanych przed sygnaturą JPEG (FF D8 FF) | Zewnętrzne przeglądarki nie rozpoznają pliku |
| Atrybut Hidden | `FileAttributes.Hidden` | Domyślnie ukryty w Eksploratorze |
| Integralność SHA-256 | Hash weryfikowany przy ładowaniu | Manipulacja wyzwala automatyczny reset + wyskakujące ostrzeżenie |

**Zachowanie Wykrywania Manipulacji**
1. Usunięto `bg.dat`
2. Zresetowano klucze `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive`
3. Zresetowano pole tekstowe i przełącznik
4. Wyświetlono popup `Lang.Windows.TextureTampered`

**Klucze ui.cfg**

| Klucz | Wartość | Opis |
|---|---|---|
| `TexturePath` | Nazwa pliku (tylko do wyświetlania) | Oryginalna nazwa pliku wyświetlana w polu tekstowym |
| `TextureHash` | Szesnastkowy SHA-256 | Hash weryfikacji integralności |
| `TextureActive` | `true` / `false` | Stan aktywacji |

**Przetwarzanie Przezroczystości**

Gdy obraz tła jest aktywny, tła interfejsu są przetwarzane w dwóch warstwach.

- **Warstwa 1 — Nakładka MergedDictionaries**: panele odwołujące się do `{DynamicResource FluentBgBrush}` itp. są automatycznie robione przezroczyste. Przywracane pojedynczym wywołaniem `Remove()` przy dezaktywacji.

  Klucze docelowe: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Warstwa 2 — Przejście drzewa wizualnego (`WalkStyleBackgrounds`)**: elementy `{StaticResource}` w motywach Fluent nie są dotknięte przez Warstwę 1, więc drzewo wizualne jest bezpośrednio przechodzone w celu zastosowania półprzezroczystych pędzli opartych na oryginalnych kolorach.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=całkowicie przezroczysty, 255=nieprzezroczysty → 100 ≈ 39% nieprzezroczysty
  ```

  Przetworzone: `Panel` (oprócz Grid), `Border`, `ListBox` / `ListView`

  Wykluczone: `Grid` (tło zachowane, elementy podrzędne przechodzone), `TabPanel` (ochrona nagłówka zakładki), `ButtonBase` / `ComboBox`, elementy `Collapsed`

  Przywracanie: źródło Setter stylu → `ClearValue()`, źródło wartości lokalnej XAML → bezpośrednio przywraca oryginalny pędzel

**Przełączanie Zakładek**

Ponieważ TabControl WPF leniwie ładuje zawartość zakładek, `WalkStyleBackgrounds(this)` jest ponownie wykonywane z priorytetem `ContextIdle` przy zmianie zakładki. Już przetworzone elementy są pomijane za pomocą sprawdzenia `ContainsKey`.

**Blokada ThemeSelector**

Gdy tekstura tła jest aktywna, nad selektorem motywów wyświetlana jest ramka `ThemeSelectorOverlay`, blokująca interakcję.

- XAML: ramka `ThemeSelectorOverlay` dodana nad ThemeSelector (`IsHitTestVisible=True`)
- Aktywna: `ThemeSelectorOverlay.Visibility = Visible`
- Nieaktywna: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` jest również chroniona flagą `_textureActive`

**Przepływ Stanu Interfejsu**

```
Wybrano obraz (Browse)
  → utworzono bg.dat → odblokowano przełącznik → automatyczna aktywacja → wyświetlono TextureLayer1
  → SaveAndClearBrushes() → wyświetlono ThemeSelectorOverlay

Dezaktywowano przełącznik
  → RestoreThemeState() → RestoreBrushes() → ukryto ThemeSelectorOverlay
  → ukryto TextureLayer1

Przycisk Clear
  → usunięto bg.dat → zablokowano przełącznik → ukryto TextureLayer1 → przywrócono pędzle
  → GC.Collect() (zwalnia pamięć obrazu 4K)
```

**Nowe Klucze Językowe**

| Klucz | Opis |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nowych nazw motywów |
| `Lang.Options.Labels.TextureBackground` | Etykieta tekstury tła |
| `Lang.Options.Labels.TextureEnable` | Etykieta aktywacji |
| `Lang.Options.Labels.TextureClear` | Przycisk Clear |
| `Lang.Windows.TextureTooLarge` | Ostrzeżenie o przekroczeniu rozmiaru pliku |
| `Lang.Windows.TextureTampered` | Ostrzeżenie o wykrytej manipulacji |

**Struktura Plików**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Zakładka Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Logika motywu i tekstury
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
            └── bg.dat             # Skompresowany i zabezpieczony obraz tła (generowany w czasie działania)
```

**Znane Ograniczenia Projektowe**

| Element | Szczegóły |
|---|---|
| `IsEnabled=false` na ComboBox | Powoduje awarię `ElementNotEnabledException` → zastosowano podejście nakładki `IsHitTestVisible` |
| Bezpośrednia zamiana kluczy `MergedDictionaries` | Awaria podczas przebiegu layoutu → tylko wzorzec `Add`/`Remove` |
| Nadpisywanie pliku ukrytego | `Access Denied` → wymaga zresetowania `FileAttributes.Normal` przed zapisem |
| Tła `{StaticResource}` | Nie dotknięte przez Warstwę 1 → wymagają WalkStyleBackgrounds (Warstwa 2) |

---

</details>

<details>
<summary><b>Zmiany w v2.0.9612</b></summary>

### Separacja Modułu Motywów

- **Nowy folder `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` i `FluentStylesClassic.xaml` przeniesione do `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — motyw Classic używa tylko `Dictionary.xaml`; motywy Light/Dark/inne Fluent ładują odpowiedni XAML
- **`ModAPI.csproj`**: zaktualizowano ścieżki XAML motywów do podkatalogu `Themes\`; zarejestrowano `FluentStylesClassic.xaml`

---

</details>

<details>
<summary><b>Zmiany w v2.0.9611</b></summary>

### Poprawka Błędu

- **Szerokość Mod List nie stosowana po zmianie motywu**: naprawiono problem, w którym szerokość listy modów nie była stosowana po przełączeniu między motywami Light/Dark i ponownym uruchomieniu — dodano wywołanie `ApplyModListWidth(width)` wewnątrz `InitModListWidth()`

---

</details>

<details>
<summary><b>Zmiany w v2.0.9610</b></summary>

### Dodano

#### XML Gier i Konfiguracja Versions

| # | Plik | Zmiana |
|---|------|--------|
| 1 | `GH.xml` | Pełne przepisanie — usunięto nieistniejący `DOTweenPro.dll`; dodano `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Pełne przepisanie — usunięto `extends="GenericUnityGame"`; dodano `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Pełne przepisanie — usunięto `extends="GenericUnityGame"`; `includeAssembly` → tylko `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Utworzono — wersja `1.1.01` z sumą kontrolną |
| 5 | `GH/Versions.xml` | Utworzono — wersja `2.9.5` z sumą kontrolną |
| 6 | `Subnautica/Versions.xml` | Utworzono — bez sumy kontrolnej (zbyt częste aktualizacje) |

#### Krytyczne Poprawki Błędów

| # | Typ | Problem | Poprawka |
|---|------|-------|-----|
| 1 | Zawieszenie | `extends="GenericUnityGame"` powodowało dziedziczenie `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` zawieszało się | Usunięto `extends` ze wszystkich XML poza TheForest |
| 2 | Awaria | `ResolutionException: XGamingRuntime.XUserGamertagComponent` podczas aplikowania na Subnautica | Dodano `XGamingRuntime.dll`, `XblPCSandbox.dll` do `copyAssembly` |
| 3 | Awaria | Resolver zawodził na DLL dodanych do `copyAssembly` po utworzeniu kopii zapasowej | `Game.cs`: dodano rzeczywisty folder instalacji jako fallback resolvera |
| 4 | Awaria | `IOException`: blokada pliku `BaseModLib.dll` między `CreateModLibrary` a `ApplyMods` | Pętla ponownych prób: maks. 10 × 500 ms odczytu + maks. 30 × 500 ms oczekiwania na istnienie |
| 5 | Awaria | `NullReferenceException` — entry.Value z `typesMap` puste (gra niezainstalowana) | Dodano `if (entry.Value == null) continue` |
| 6 | Awaria | `NullReferenceException` — lekki konstruktor `Game` brakował `ModLibrary = new ModLib(this)` → awaria `CreateModLibrary()` | Dodano `ModLibrary = new ModLib(this)` do lekkiego konstruktora |
| 7 | Awaria | `SwitchDevGame()` — `App.Game.GamePath` puste po lekkim konstruktorze → awaria `CreateModLibrary` | Ustawiono `App.Game.GamePath = savedPath` po lekkim konstruktorze |
| 8 | Zła gra | Mody `EscapeThePacific` klasyfikowane jako TheForest | `ModsViewModel`: `GameId` wyodrębniany ze ścieżki folderu |
| 9 | Zła ścieżka | `GetGameFolder()` → `""` → rozwiązywane do katalogu głównego dysku (np. `E:\`) | Zabezpieczenie null/puste we wszystkich 6 punktach wywołania |

#### Podział na Buildy Debug / Release

- **`FileValidator.cs`** — nowy plik `ModAPI_Shared\Utils\FileValidator.cs`; zarejestrowany w `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — nagłówek PE (MZ + PE\0\0) + minimum 1 MB
  - `IsValidGameExe()` — nagłówek PE + minimum 512 KB
  - `IsValidAssemblyDll()` — nagłówek PE + nagłówek metadanych CLR .NET + minimum 64 KB
- **`CheckSteam()`** — `#if DEBUG`: tylko `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: tylko `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` bez Cecil / `#else`: pełne parsowanie Cecil + modyfikacja IL
- **`ModLib.Create()` plik nie znaleziony** — `#if DEBUG`: zapisuje ostrzeżenie, pomija / `#else`: zapisuje błąd, przerywa

#### Testy Debug

- **`create_dummy_Debug_games.ps1`** — skrypt PowerShell dla `bin\Debug\`; tworzy pliki zastępcze o rozmiarze 0 bajtów dla wszystkich 5 gier w `dummy_games\`, `dummy_steam\` i `gamefiles\original\` — umożliwia testowanie całego przepływu pracy interfejsu bez rzeczywistej instalacji gry

#### Zakładka Settings

- **Karta ścieżki Steam** — zintegrowana z kartą Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panel ścieżek gier** — `BuildGamePathsPanel()` z rozwijalnymi kartami dla każdej gry; pole tekstowe używa `HorizontalAlignment=Stretch`
- Przycisk **Expand All / Collapse All**
- Checkbox **AlwaysOnTop** (zapisywany w `ui.cfg`)
- Suwaki **Mod/Project List Width** — zaczynają od minimum `150`; zapisywane w `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Synchronizacja checkboksów** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions teraz poprawnie się synchronizują
- **Flaga `_uiInitialized`** — zapobiega przedwczesnym zapisom `ui.cfg` podczas startu WPF

#### Zakładka Mods — Walidacja Uruchamiania Gry

Pięcioetapowa walidacja jest wykonywana przy każdym kliknięciu Start Game, niezależnie od stanu listy modów:

| Krok | Kontrola | Popup |
|---|---|---|
| 1 | Ścieżka Steam w zakładce Settings prawidłowa (`Steam.exe` istnieje) | SteamNotFound |
| 2 | Gra w folderze `mods/{GameId}/` odpowiada grze skonfigurowanej w Settings | GameModsMismatch |
| 3 | Wybrano co najmniej jednego moda | NoModSelected |
| 4 | Brak mieszanych modów różnych gier w wyborze | MixedGameMods |
| 5 | Ścieżka gry skonfigurowana + plik wykonywalny istnieje | GamePathNotSet / GameNotInstalled |

#### Zakładka Development — Walidacja ModLib

Trzyetapowa walidacja przy kliknięciu Mod Library Regeneration:

| Krok | Kontrola | Popup |
|---|---|---|
| 1 | Ścieżka Steam w zakładce Settings prawidłowa | SteamNotFound |
| 2 | Istnieje co najmniej jeden projekt | NoProjectWarning |
| 3 | `App.Game.GamePath` ustawione | GamePathNotSet |

#### Zakładka Downloads
- Zastąpiono ciąg debugowania kluczem `Lang.Downloads.Status.NoDownloads`
- Spójne wypełnienie dla wszystkich komunikatów statusu
- Zaktualizowano tekst offline dla wszystkich 5 wspieranych gier; podział wiersza za pomocą dwóch TextBlocks

#### First Setup i System Ścieżki Gry
- `FirstSetup.Check()` — domyślna wartość `true` dla `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — tworzy foldery `mods/` i `projects/` dla wszystkich 5 gier
- `SpecifyGamePath` — `GameNameLabel` pokazuje, o którą grę chodzi; `NavigateToSettings()` przekierowuje do zakładki Settings

#### Nowe/Zaktualizowane Klucze Językowe

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

### Nie Uwzględniono

| Funkcja | Powód |
|---|---|
| Automatyczna aktualizacja (zachowanie najnowszej wersji) | Infrastruktura po stronie serwera niedostępna |
| Wyszukiwanie aktualizacji | Infrastruktura po stronie serwera niedostępna |

### Usunięto

| Element | Powód |
|---|---|
| Popup `SpecifyGamePath` przy starcie | Wszystkie ścieżki są konfigurowane w zakładce Settings |
| Popup `SpecifySteamPath` przy starcie | Ścieżka Steam jest konfigurowana w zakładce Settings |
| System logowania | Oryginalny serwer nie jest już operacyjny (usunięto w v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Nie działa na Mono 2.0 (usunięto w v2.0.9586) |
| Warunek `UseSteam` w kontroli Steam | Steam jest teraz zawsze weryfikowany jako pierwszy przy Start Game i Mod Library Regeneration |

## Zaplanowane na Przyszłe Wydania

| # | Funkcja | Opis |
|---|---|---|
| 1 | Automatyczna aktualizacja ModAPI | Automatyczne pobieranie i stosowanie nowych wydań ModAPI |
| 2 | Aktualizacja tabeli VersionsData ModAPI | Automatyczna aktualizacja tabeli VersionsData gry po wydaniu nowych patchy gry |

---

</details>

<details>
<summary><b>Zmiany w v2.0.9600</b></summary>

### Dodano

- **Zakładka Downloads**: 5 filtrów gier (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Zakładka Welcome**: dodana w skrajnie lewej pozycji (indeks 0)
- **Zakładka Mods**: układ 3-kolumnowy (WrapPanel → lista pionowa); automatyczne dostosowanie szerokości; zawijanie nazw modów
- **`ModsViewModel`**: filtrowanie specyficzne dla gry, `ResolveGame()` dla poprawnej instancji `Game` dla każdego moda
- **`Game.cs`**: lekki konstruktor `new Game(config, true)` — tylko identyfikacja, bez `Verify()`
- **Kompilacja**: 4 pliki XML gier zarejestrowane w `ModAPI.csproj` z `CopyToOutputDirectory=Always`
- **Kompilacja**: wyczyszczono ostrzeżenia — CS0168, CS0618, CS0252
- **XML gier**: poprawiono listy DLL dla TheForest, Raft, GH
- **Flagi językowe**: ujednolicone rozmiary obrazów we wszystkich 13 odznakach językowych

### Usunięto

| Element | Powód |
|---|---|
| `extends="GenericUnityGame"` w plikach XML gier | Powodowało nieprawidłowe dziedziczenie `Assembly-CSharp-firstpass.dll` — usunięto z Subnautica, Raft, EscapeThePacific, GH |
| Układ `WrapPanel` w zakładce Mods | Zastąpiony układem Grid 3-kolumnowym (Game Filter / Mod List / Information) |

---

</details>

---

## Historia Wersji

<details>
<summary><b>Faza 6-3 — Rozszerzenie Systemu Motywów, Ulepszenia Ustawień, Stabilność i Narzędzia</b></summary>

### v2.0.9621 — 2026-07-28

- Wykrywanie automatyczne w całej bibliotece Steam dla wszystkich 5 gier, sterowane checkboxem Połączenie ze Steam
- Automatyczne wykrywanie i wykluczanie modów zbudowanych dla innej gry (lista + w momencie Apply), z odznaką ⚠ w zakładce Mods
- Połączony popup wyników dla wykluczonych modów / braku zastosowanych modów zamiast ułożonych jeden na drugim; gra nie uruchamia się już przy zero zastosowanych modów
- Globalne rejestrowanie nieobsłużonych wyjątków (wątek UI + wątki w tle)
- `ModAPI.dev.log` zastępuje `ModAPI.detailed.log`; nowe przełączniki w zakładce Ustawienia dla Dziennika dewelopera i Czyszczenia dzienników przy starcie
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` domyślnie odznaczone przy nowej instalacji
- Poprawiono: błąd pustej ścieżki w `Configuration.GetPath()`, niespójną kolejność walidacji Start Game, zbieranie modów ignorujące filtr, kolizje kluczy `Mod.Mods` między grami i wynikającą z nich awarię `UpdateMods()`, podwojenie sumy kontrolnej Green Hell (`_Data`/`_data`), awarię przez blokadę pliku `BaseModLib.dll`, bezwarunkowe tworzenie `mods\`/`projects\`, błąd zapisu `Versions.xml` przy brakującym folderze, brak przeliczania wysokości okna przy zmianie rozmiaru czcionki / zakładki, nieograniczoną wysokość okna przy "Rozwiń wszystko"

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool i główne poprawki**
- Dodano MODAPI_LangTool (samodzielne narzędzie WPF do zarządzania językami)
- Poprawka SSL/TLS (TLS 1.2)
- Poprawka ustawień regionalnych francuskich (`CultureInfo.InvariantCulture`)
- Poprawka `GamePathNotSet` dla Green Hell
- SelectGameDialog (filtr All + uruchamianie modów wielu gier)
- Usunięto blokadę przez MixedGameMods
- 3-warstwowa kontrola integralności gry (nagłówek PE / suma kontrolna assembly / podpis cyfrowy)
- Rozdzielenie logów deweloperskich i użytkownika
- 12 logów UpdateVersions + 7 logów FindMods + 10 logów StartGame
- URL Raw GitHub jako główny `VersionUpdateDomains`
- Poprawiono sumę kontrolną `Versions.xml` GH
- Dodano `1.12` do `Versions.xml` TheForest
- 515 kluczy we wszystkich 13 plikach językowych

**Dodatkowe poprawki (2026-06-21)**
- Poprawiono kolejność walidacji StartGame (Steam → ścieżka gry → mody)
- Popup wyboru gry teraz poprawnie wyświetla gry z nieskonfigurowaną ścieżką
- Poprawka pojedynczej odpowiedzi w UpdateVersions (brak zduplikowanych sum kontrolnych)
- `DeleteMod` teraz rozwiązuje własną instancję gry moda zamiast aktywnego filtra
- Usunięte mody nie pozostawiają już nieaktualnej odznaki „Selected” przy ponownym pobraniu
- Lista modów teraz natychmiast się odświeża po usunięciu, niezależnie od filtra gry
- Wzmocniono popup `GameIntegrityWarning` przeciwko awariom spowodowanym nieobsłużonymi wyjątkami
- Komunikat ostrzeżenia o podpisie cyfrowym teraz podaje nazwę gry i wyjaśnia, że jest to oczekiwane dla tytułów niezależnych
- System logowania z dwoma plikami (`ModAPI.log` / `ModAPI.detailed.log`) zastępuje logi ograniczone przez `#if DEBUG`, dzięki czemu buildy Release nadal mogą przechwytywać pełne szczegóły diagnostyczne bez zaśmiecania logu dla użytkownika

### v2.0.9619 — 2026-05-25

- Automatyczne tworzenie kopii zapasowej ze ścieżki instalacji gry
- Poprawiono blokadę pliku (warunkowy resolver)
- Zapobieganie nieskończonej pętli dla uszkodzonych modów
- Kompatybilność z modami o zakończeniach linii LF
- Wykrywanie pobrań 0 bajtów z popupem
- Debounce zapisu suwaka (500 ms)
- Warunkowe tworzenie folderów gier
- Zmniejszono minimalny rozmiar assembly w `FileValidator` z 64 KB do 8 KB
- Parametr `silent` w `GetPath`/`GetString`/`GetInt`
- Log diagnostyczny parsowania nagłówka
- Klucze językowe `DownloadEmpty` (13 języków)

### v2.0.9618 — 2026-04-25
Dodano MODAPI_VersionTool (samodzielne narzędzie WPF do aktualizacji wersji), wyświetlanie wersji w StatusBar powiązane z App.Version

### v2.0.9617 — 2026-04-24
Dodano przyciski resetowania ścieżki Steam/gry w zakładce Settings, automatyczny zapis Browse, stan resetu zachowany za pomocą flagi ui.cfg

### v2.0.9616 — 2026-04-18
Utworzono/zaktualizowano Versions.xml dla 4 gier (Subnautica, Raft, EscapeThePacific, GH), ustalono zasady kompozycji sumy kontrolnej, udokumentowano procedurę aktualizacji gry

### v2.0.9615 — 2026-04-18
Poprawiono dokładność wysokości rozwinięcia karty ścieżki gry w zakładce Settings, zapobieżono zakłóceniom UpdateWindowHeight przez teksturę tła

### v2.0.9614 — 2026-04-18
Ręczna maksymalizacja przycisku Maksymalizuj oparta na WorkArea, zapisywanie i przywracanie poprzedniego rozmiaru/pozycji

### v2.0.9613 — 2026-04-18
Dodano zakładkę Themes, struktura rejestru motywów oparta na danych, wsparcie dla 10 motywów, funkcja tekstury tła (kompresja, bezpieczeństwo, 2-warstwowa przezroczystość), nakładka blokady ThemeSelector, 12 nowych kluczy językowych

### v2.0.9612 — 2026-04-18
Separacja folderu Themes/, modularyzacja XAML motywów

### v2.0.9611 — 2026-04-18
Poprawiono: szerokość Mod List nie stosowana po zmianie motywu

</details>

<details>
<summary><b>Faza 6-2 — Ustawienia, Bezpieczeństwo, Poprawki Awarii i Podział Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- Poprawiono XML wielu gier (GH, Subnautica, EscapeThePacific)
- Dodano `Versions.xml`
- Przeprojektowano zakładkę Settings (ścieżka Steam, panel ścieżek gier, suwaki szerokości, rozmiar czcionki, synchronizacja checkboksów)
- Bezpieczeństwo null ścieżki gry (6 miejsc)
- Zastąpiono popupy startowe zakładką Settings
- 5-etapowa walidacja uruchamiania gry w zakładce Mods (Steam zawsze pierwszy)
- 3-etapowa walidacja ModLib w zakładce Dev
- Dodano popup `GameModsMismatch`
- Poprawiono null `ModLibrary` w lekkim konstruktorze
- Poprawiono `GamePath` w `SwitchDevGame`
- Weryfikacja nagłówka PE przez `FileValidator` (Release)
- Podział buildu `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- Trwałe `ui.cfg`
- 5-kluczowy system czcionek
- Wiele poprawek awarii
- Zaktualizowano klucze językowe

</details>

<details>
<summary><b>Faza 6-1 — Wiele Gier i Przeprojektowanie Modów</b></summary>

### v2.0.9600 — 2026-04-09
> 5 filtrów gier, układ 3-kolumnowy zakładki Mods, automatyczna szerokość, lekki konstruktor `Game`, filtrowanie gier w `ModsViewModel`, 4 zarejestrowane pliki XML, wyczyszczone ostrzeżenia kompilacji, zakładka Welcome, ujednolicone flagi językowe

</details>

<details>
<summary><b>Faza 5-6B — C# 7.3 i Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Poprawiono czarny ekran, sfinalizowano polyfill, usunięto ValueTuple, zweryfikowano C# 7.3

</details>

<details>
<summary><b>Faza 5-5 — Rozwiązywanie Assemblies</b></summary>

### v2.0.9561 — 2026-03-06
> Wsparcie C# 7.3, łatanie nagłówka PE, potok polyfill, przywrócono rozwiązywanie assemblies

</details>

<details>
<summary><b>Faza 5-1 — Zakładka Downloads i 13 Języków</b></summary>

### v2.0.9552 — 2026-02-25
> Zakładka Downloads, modernizacja ikon, ujednolicenie motywów, wsparcie dla 13 języków

</details>

<details>
<summary><b>Wcześniejsze Fazy</b></summary>

### Faza 3 — Przeprojektowanie Interfejsu i System Motywów
v2.0.9500
> System motywów (Classic/Light/Dark), interfejs Fluent Design, system SubWindow

### Faza 4 — Czyszczenie Kodu
v2.0.9400
> Czyszczenie kodu, usunięcie logowania, modernizacja starego kodu

### Faza 2 — Środowisko Kompilacji i Fluent Design
v2.0.9300
> Środowisko kompilacji, zaślepka DLL UnityEngine, integracja ModernWpf

### Faza 1 — Migracja do .NET 4.8
v2.0.9200
> Migracja do .NET Framework 4.8

### v1.x
Oryginalne wydanie FluffyFish

</details>

---

## Wymagania Kompilacji

| Wymaganie | Wersja | Uwagi |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projekty ModAPI |
| .NET Framework SDK | 3.5 | Tylko BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` w `libs/polyfills/` |

---

## Licencja

GNU General Public License v3.0 — zgodnie z oryginalną licencją.
