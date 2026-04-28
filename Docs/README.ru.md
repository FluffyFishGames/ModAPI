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

**Инструмент управления модами The Forest — Обновлённая версия**

> Оригинал: FluffyFish / Philipp Mohrenstecher (Энгельскирхен, Германия)
> Обновление: zzangae (Республика Корея)

---

## Обзор

ModAPI — это настольное приложение для управления модами **5 официально поддерживаемых игр**. Эта обновлённая редакция включает поддержку нескольких игр, полностью переработанную вкладку «Настройки», настройку пути Steam, постоянные настройки интерфейса, динамическую систему размера шрифта, проверку запуска игры, разделение сборок Debug/Release и многочисленные исправления сбоев.

---

## Поддерживаемые Игры

| Игра | Движок | Версия | Steam ID | Исполняемый файл |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Бета) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Элемент | Значение |
|---|---|
| Движок | Unity 5 (обновлён с Unity 4) |
| Последняя версия | v1.12 (VR) |
| Последнее обновление | 11 сентября 2019 — патч поддержки VR; без дальнейших крупных обновлений контента |
| Исполняемый файл | `TheForest.exe` |
| Папка данных | `TheForest_Data/Managed/` |
| Папка модов | `mods/TheForest/` |
| Папка проектов | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — полностью поддерживается |

The Forest был обновлён с Unity 4 до Unity 5, что значительно улучшило графику и физику. VR-патч сентября 2019 стал последним крупным обновлением. Игра находится в стабильном, финализированном состоянии — идеальном для моддинга.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Элемент | Значение |
|---|---|
| Движок | Unity (интегрированная кодовая база, объединённая с Below Zero в 2022) |
| Последняя версия | 2025 Patch (v18810395) |
| Последнее обновление | 12 августа 2025 — исправления ошибок и улучшения производительности вместе с мобильным релизом |
| Исполняемый файл | `Subnautica.exe` |
| Папка данных | `Subnautica_Data/Managed/` |
| Папка модов | `mods/Subnautica/` |
| Папка проектов | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — поддерживается |

Изначально построенная на Unity 5, Subnautica получила обновление 'Living Large' (v2.0) в конце 2022, объединившее кодовую базу движка с Below Zero для улучшения оптимизации и стабильности. Примечание: предстоящая *Subnautica 2* использует Unreal Engine 5.

> **XML переписан в v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` добавлены в `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Элемент | Значение |
|---|---|
| Движок | Unity |
| Последняя версия | v1.1.02 (Бета) / v1.09 (Стабильная) |
| Последнее обновление | Март 2026 — исправления голосового чата и мультиплеера через бета-ветку |
| Исполняемый файл | `Raft.exe` |
| Папка данных | `Raft_Data/Managed/` |
| Папка модов | `mods/Raft/` |
| Папка проектов | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — поддерживается |
| Versions.xml | `1.1.01` (с контрольной суммой) |

После официального завершения истории в v1.0: *The Final Chapter* продолжают выходить патчи для улучшения сетевого кода и стабильности.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Элемент | Значение |
|---|---|
| Движок | Unity 6 (миграция с Unity 2021/2022 в конце 2025) |
| Последняя версия | v0.67.0.0 |
| Последнее обновление | 26 июня 2025 — переработка распределения островов и обновление движка; хотфиксы продолжаются в 2026 |
| Исполняемый файл | `EscapeThePacific.exe` |
| Папка данных | `EscapeThePacific_Data/Managed/` |
| Папка модов | `mods/EscapeThePacific/` |
| Папка проектов | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — поддерживается |

Завершена масштабная перестройка системы и миграция на Unity 6 в конце 2025, обеспечивающая более динамичные среды. Игра продолжает активную разработку в Раннем Доступе.

> **XML переписан в v2.0.9610**: `extends="GenericUnityGame"` удалён; `includeAssembly` установлен только для `Assembly-CSharp.dll` — предотвращает ошибки наследования `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Элемент | Значение |
|---|---|
| Движок | Unity 2019 |
| Последняя версия | v2.9.5 |
| Последнее обновление | 4 февраля 2026 — оптимизация для Steam Deck и улучшение читаемости текста |
| Исполняемый файл | `GH.exe` |
| Папка данных | `GH_Data/Managed/` |
| Папка модов | `mods/GH/` |
| Папка проектов | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — поддерживается |
| Versions.xml | `2.9.5` (с контрольной суммой) |

Разработана с поэтапным обновлением движка Unity 2017 → 2018 → 2019. Хотфикс февраля 2026 сосредоточился на совместимости со Steam Deck и читаемости текста UI.

> **XML переписан в v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` добавлены; несуществующий `DOTweenPro.dll` удалён.
</details>

---

## Архитектура

### Разделение Среды Выполнения

| Компонент | Цель | Среда выполнения | Причина |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Настольное приложение, полный современный API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Общая библиотека |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Постоянно зафиксирован** — PE-заголовок должен содержать `v2.0.50727` |
| DLL модов (пользователь) | .NET Framework 4.8 | Game Mono 2.0 (пропатчен) | Собран с 4.8, PE-заголовок патчится при применении |

### Разделение Сборки Debug / Release

Вся валидация файлов и обработка сборок разветвляется на основе конфигурации сборки через `#if DEBUG` / `#else`.

| Расположение | Сборка Debug | Сборка Release |
|---|---|---|
| `CheckSteam()` | Только `File.Exists()` — фиктивные файлы проходят | `FileValidator.IsValidSteamExe()` — PE-заголовок + мин. 1 МБ |
| `CheckGamePath()` | Только `File.Exists()` — фиктивные файлы проходят | `FileValidator.IsValidAssemblyDll()` — PE-заголовок + метаданные CLR + мин. 64 КБ |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — анализ Cecil пропущен | Полный анализ Mono.Cecil + модификация IL + `module.Write()` |
| `ModLib.Create()` — файл не найден | Записать предупреждение, пропустить и продолжить | Записать ошибку, прервать с popup |

**Тестирование Debug** использует `create_dummy_Debug_games.ps1` для генерации файлов-заглушек размером 0 байт в `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` и `bin\Debug\gamefiles\original\`. Они проходят проверки `File.Exists()` и позволяют полное тестирование рабочего процесса UI без реальной установки игры.

**Сборки Release** применяют `FileValidator` (верификация PE-заголовка + метаданных CLR .NET) для отклонения файлов размером 0 байт, текстовых файлов и произвольных бинарных файлов. Проходят только валидные исполняемые файлы Windows и сборки .NET.

### FileValidator — Верификация PE-заголовка

`ModAPI_Shared\Utils\FileValidator.cs` — применяется только в сборках Release.

| Метод | Проверки | Мин. размер |
|---|---|---|
| `IsValidSteamExe(path)` | Подпись MZ + подпись PE\0\0 | 1 МБ |
| `IsValidGameExe(path)` | Подпись MZ + подпись PE\0\0 | 512 КБ |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + заголовок метаданных CLR (каталог данных #14) | 64 КБ |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Конвейер Перемаппинга Сборок

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

### Резервный Вариант Резолвера Сборок

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Поддержка Функций C# 7.3

| Функция | Статус | Примечания |
|---|---|---|
| Сопоставление с образцом (`is`, `switch`) | ✅ | Проверено в игре |
| Интерполяция строк (`$""`) | ✅ | Проверено в игре |
| Inline-переменная `out` | ✅ | Проверено в игре |
| `async` / `await` | ✅ | Через AsyncBridge + полифилы System.Threading |
| Кортежи (`ValueTuple`) | ❌ Абсолютное ограничение | ABI `mscorlib` Mono 2.0 — обходных путей нет |

### Система тем

Начиная с v2.0.9613, интерфейс выбора тем перенесён из вкладки Settings в отдельную **вкладку Themes**. Для добавления новой темы достаточно одной строки в словаре `App.xaml.cs`.

| Индекс | ID | Файл | Палитра |
|---|---|---|---|
| 0 | `classic` | Только `Dictionary.xaml` | Оригинальный текстурный фон ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Светлый тон + синий акцент |
| 2 | `dark` | `FluentStyles.xaml` | Тёмный тон + синий акцент (по умолчанию) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Красный + чёрный |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Тёмный космос |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Яркий закат |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Тёмный океан |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Яркий нордический |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Яркий цитрусовый |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Яркий цветочный |

Смена темы вызывает автоматический перезапуск приложения. (сохраняется в `theme.cfg`)

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

### Фоновая текстура

Выберите изображение в карточке **Background Texture** на вкладке Themes для применения его в качестве фона всего приложения. Поддерживаемые форматы: `.png` / `.jpg` / `.jpeg`, макс. 50МБ, разрешение 4K или ниже. Изображение сжимается как JPEG Q75 с 16-байтовым магическим заголовком и сохраняется как `resources\textures\ui_bg\bg.dat` (атрибут Hidden). Хеш SHA-256 для проверки целостности; при обнаружении подделки — автоматический сброс + предупреждение.

При активном фоне прозрачность UI обрабатывается в два слоя: Layer 1 (наложение MergedDictionaries) для панелей `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) для панелей на основе `{StaticResource}` с полупрозрачностью.

### Система Размера Шрифта

| Ключ ресурса | База | Описание |
|---|---|---|
| `AppBaseFontSize` | 13 | Обычный текст |
| `AppBaseHeaderFontSize` | 16 | Заголовки, названия панелей |
| `AppBaseSmallFontSize` | 12 | Вторичные метки |
| `AppBaseTinyFontSize` | 10 | Текст подсказки |
| `AppBaseLargeFontSize` | 20 | Крупный текст |

### Постоянная Конфигурация UI — `ui.cfg`

| Ключ | По умолчанию | Описание |
|-----|---------|-------------|
| `ModListWidth` | `150` | Ширина списка модов (пикс.) |
| `ProjectListWidth` | `150` | Ширина списка проектов (пикс.) |
| `AppFontSize` | `13` | Глобальный размер шрифта UI (пикс.) |
| `AlwaysOnTop` | `false` | Окно всегда поверх |
| `TexturePath` | *(нет)* | Имя файла фоновой текстуры (только отображение) |
| `TextureHash` | *(нет)* | Хеш SHA-256 фоновой текстуры |
| `TextureActive` | `false` | Состояние активации фоновой текстуры |
| `GamePathReset_{GameId}` | *(нет)* | Флаг сброса пути игры |
| `SteamPathReset` | *(нет)* | Флаг сброса пути Steam |

### Структура Файлов

```
ModAPI/
├── App.xaml / App.xaml.cs              # Реестр тем, ID тем, применение темы
├── ui.cfg                               # Постоянные настройки UI
├── theme.cfg                            # Текущая тема
├── Windows/
│   ├── MainWindow.xaml / .cs            # Главный UI — 6 вкладок, Темы, Настройки, путь Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup пути игры (динамический GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # Первоначальная настройка + инициализация по умолчанию
│       └── (14 других подокон)
├── Themes/
│   ├── Dictionary.xaml                  # Тема Classic
│   ├── FluentStyles.xaml                # Тема Dark
│   ├── FluentStylesLight.xaml           # Тема Light
│   ├── FluentStylesDiablo.xaml          # Тема Diablo
│   ├── FluentStylesNebula.xaml          # Тема Nebula
│   ├── FluentStylesSunset.xaml          # Тема Sunset
│   ├── FluentStylesOcean.xaml           # Тема Ocean
│   ├── FluentStylesNordic.xaml          # Тема Nordic
│   ├── FluentStylesCitrus.xaml          # Тема Citrus
│   └── FluentStylesBloom.xaml           # Тема Bloom
├── Data/
│   ├── Game.cs                          # Патчинг сборок, null-защита, резервный резолвер
│   ├── ModLib.cs                        # Генерация BaseModLib + перемаппинг (#if DEBUG разделение)
│   ├── Models/
│   │   └── ModProject.cs                # Создание/сборка/применение проекта + null-защита
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Отфильтрованные моды, выбранный мод, выбранный фильтр игры
│   │   ├── ModViewModel.cs              # GameId из пути папки
│   │   ├── ModProjectsViewModel.cs      # Dispose() для DispatcherTimer
│   │   └── SettingsViewModel.cs         # По умолчанию true для UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Маппинг версий сборок Mono 2.0 (20 сборок)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Резолвер по имени с кэшированием
│   └── MonoHelper.cs                    # Вспомогательные утилиты IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 языковых файлов
│   └── textures/ui_bg/
│       └── bg.dat                       # Сжатое и защищённое фоновое изображение (создаётся при запуске)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Полная перезапись v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Полная перезапись v2.0.9610
    │   ├── GH.xml                       # Полная перезапись v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — не поддерживается
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Лёгкий конструктор + исправление инициализации ModLibrary
│   └── ModLib.cs                        # Разделение #if DEBUG для анализа Cecil
└── Utils/
    └── FileValidator.cs                 # Верификация PE-заголовка + метаданных CLR (только Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Автономный инструмент обновления версии WPF

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Генерирует фиктивную структуру игры/Steam
├── dummy_games\{GameId}\               # Фиктивные пути установки игр
├── dummy_steam\Steam.exe               # Фиктивный исполняемый файл Steam
└── gamefiles\original\{GameId}\        # Фиктивные пути резервных копий для ModLib
```

---

## Установка и настройка

### Шаг 1 — Предварительные требования

| Элемент | Требуется |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (предустановлен в Windows 11; [скачать](https://dotnet.microsoft.com/download/dotnet-framework/net48) для Windows 10) |
| Steam | Требуется — необходимо настроить во вкладке Settings |
| Хотя бы одна поддерживаемая игра | Требуется — необходимо настроить во вкладке Settings |

### Шаг 2 — Установить ModAPI

1. Скачать последний релиз с GitHub
2. Распаковать в любую папку (напр. `C:\ModAPI\`)
3. Запустить `ModAPI.exe`
4. При первом запуске появляется экран **Welcome** — настроить параметры и нажать **Continue**

### Шаг 3 — Настроить путь Steam (вкладка Settings)

1. Перейти на вкладку **Settings**
2. Найти **Steam Installation Path**
3. Нажать **Browse** → выбрать `Steam.exe`
4. Нажать **Save**

### Шаг 4 — Настроить пути игр (вкладка Settings)

1. Нажать на заголовок карточки игры для раскрытия
2. Нажать **Browse** → выбрать корневую папку игры (где находится `.exe`)
3. Нажать **Save**

| Игра | Исполняемый файл | Пример пути |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Шаг 5 — Скачать моды (вкладка Downloads)

1. Перейти на вкладку **Downloads**
2. Выбрать игру в фильтре игр
3. Найти мод и нажать **Download**

> **Офлайн**: Скачать файлы `.mod` вручную с `modapi.survivetheforest.net` и поместить в соответствующую папку:

| Игра | Папка |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Шаг 6 — Применить моды и запустить игру (вкладка Mods)

1. Перейти на вкладку **Mods**
2. Выбрать игру в **Фильтре Игр** (Столбец 0)
3. Отметить моды для активации в **Списке Модов** (Столбец 1)
4. Нажать **Start Game**

Следующие проверки выполняются автоматически перед запуском:

| # | Проверка | Popup ошибки |
|---|---|---|
| 1 | Путь Steam настроен и валиден | SteamNotFound |
| 2 | Игра в папке `mods/` соответствует пути игры в Settings | GameModsMismatch |
| 3 | Выбран хотя бы один мод | NoModSelected |
| 4 | Нет смешанных модов игр в выборе | MixedGameMods |
| 5 | Путь игры настроен и исполняемый файл существует | GamePathNotSet / GameNotInstalled |

---

## Обзор вкладок

### Вкладка Welcome
Экран начальной настройки (индекс вкладки 0). Настройка AutoUpdate, подключения Steam и предпочтений таблицы VersionsData. При последующих запусках эта вкладка предоставляет ссылки сообщества и заметки о выпусках.

### Вкладка Mods
Основной рабочий процесс управления модами — макет в 3 столбца:

| Столбец | Содержание |
|---|---|
| Столбец 0 | Фильтр Игр — радиокнопки для 5 поддерживаемых игр |
| Столбец 1 | Список Модов — установленные моды с выбором версии и флажком активации |
| Столбец 2 | Информация — детали выбранного мода, описание, история версий |

### Вкладка Downloads
Просмотр и скачивание модов с `modapi.survivetheforest.net`.

- **Фильтр игр**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Фильтр категорий**: 12 категорий (Bugfixes, Balancing, Cheats, …)
- **Поиск**: по имени мода, описанию или автору
- **Офлайн-режим**: отображает инструкции по папкам для всех 5 поддерживаемых игр

### Вкладка Development
Рабочий процесс разработки модов — панель фильтра игр (Столбец 0) охватывает все 5 поддерживаемых игр.

- Создание, сборка и применение проектов модов для каждой игры
- Управление языковыми ресурсами
- Генерация ModLib с 3-шаговой валидацией (Steam → проект → путь игры)
- Безопасное переключение игр через лёгкий конструктор `Game` (без вызова `Verify()`)

### Вкладка Themes
Выбор тем и управление фоновой текстурой.

- **Выбор темы**: 10 тем (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Фоновая текстура**: Выбрать изображение в качестве фона всего приложения (JPEG-сжатие + обработка безопасности)
- При активной фоновой текстуре выбор темы блокируется

### Вкладка Settings
Централизованная конфигурация — 4 строки:

| Строка | Содержание |
|---|---|
| 0 | Язык / Размер шрифта / Тема / Макс. ширина / Ширина списка модов / Ширина списка проектов |
| 1 | Сохранять VersionsData / Авто-обновление / Подключение Steam / Всегда поверх |
| 2 | Путь установки Steam (TextBox + Обзор + Сохранить + Сбросить) |
| 3 | Пути установки игр — раскрывающаяся карточка для каждой игры (TextBox + Обзор + Сохранить + Сбросить) |

---

## Изменения в v2.0.9618

### Инструмент Обновления Версии (MODAPI_VersionTool)

Автономный WPF-инструмент для обновления номера версии одним кликом.

**Расположение**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Функции**
- Автоматически отображает текущую версию (считанную из `App.xaml.cs`)
- Введите новую версию и нажмите **Apply Version** для одновременного обновления обоих файлов
- Валидация формата: принимается только формат `X.X.XXXX`

**Изменённые файлы**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Использование**
1. Run `MODAPI_VersionTool.exe`
2. Введите новую версию (напр. `2.0.9619`)
3. Click **Apply Version**
4. Пересоберите решение ModAPI в Visual Studio

### Исправление отображения версии в StatusBar

- `VersionLabel.Text` теперь ссылается на `App.Version` вместо жёстко заданного `Version.Descriptor`
- Обновление версии через VersionTool и пересборка теперь немедленно отражаются в StatusBar

---

## Изменения в v2.0.9617

### Вкладка Settings — Добавлены кнопки сброса пути

Кнопка **Reset** была добавлена to the Steam installation path and each game installation path row.

**Строка пути Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Строка пути игры (для каждой игры)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Поведение сброса**
- Немедленно очищает TextBox пути
- Сохраняет флаг сброса в `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox остаётся пустым после перезапуска
- Обходит ограничение Configuration XML, не сохраняющего пустые строки

**Авто-сохранение Browse**
- Раньше: требовался отдельный клик кнопки Save после Browse
- Теперь: автоматически сохраняется при выборе файла — отражается даже после переключения на вкладку Mods

**Новый языковой ключ**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## Изменения в v2.0.9616

### Versions.xml — 4 игры добавлены / обновлены

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Вновь создан |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Контрольная сумма обновлена |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Вновь создан |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Контрольная сумма обновлена |

### Правила составления контрольной суммы

Формат контрольной суммы различается в зависимости от того, существует ли `Assembly-CSharp-firstpass.dll` для каждой игры.

| Игра | firstpass.dll | Формат контрольной суммы |
|---|---|---|
| GH | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| Subnautica | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| EscapeThePacific | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| Raft | ❌ Отсутствует | Только `Assembly-CSharp MD5` (32 символа) |

### Процедура обновления Versions.xml

Добавить новую запись `<version>` без удаления существующих записей.

**Шаг 1 — Найти новый BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Шаг 2 — Извлечь новую контрольную сумму**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Шаг 3 — Добавить запись в Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## Изменения в v2.0.9615

### Исправление раскрытия пути игры во вкладке Settings

- **Высота раскрытия карточки**: Нижняя часть окна теперь увеличивается ровно на высоту поля ввода при раскрытии карточки пути игры
- **`UpdateWindowHeight()` улучшен**: Вызывает `UpdateLayout()` перед измерением `SizeToContent.Height`; временно устанавливает `TextureLayer1` в `Collapsed` при активной фоновой текстуре, чтобы исходный размер 4K-изображения не влиял на расчёт высоты
- **Исправление внутренней строки Grid**: Последняя строка внутреннего Grid панели путей игр изменена с `Height="*"` на `Height="Auto"` — удаляет ненужное пустое пространство снизу

---

## Изменения в v2.0.9614

### Исправление поведения кнопки максимизации

- **Максимизация**: Использует `SystemParameters.WorkArea` для ручной максимизации вместо `WindowState.Maximized` — точно подходит под текущее разрешение экрана без перекрытия панели задач
- **Восстановление**: Сохраняет `Left`, `Top`, `Width`, `Height` и `MaxWidth` перед максимизацией и восстанавливает их при нажатии кнопки восстановления
- **Обработка `MaxWidth`**: Устанавливается в `∞` при максимизации, восстанавливается до сохранённого значения при нормализации

---

## Изменения в v2.0.9613

### Новая вкладка Themes

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Интерфейс выбора тем перенесён из вкладки Settings в специальную **вкладку Themes**.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Реестр тем (структура на основе данных)

Добавление новой темы теперь требует только **одной строки** в словаре `App.xaml.cs`.
Все операторы switch удалены — изменения кода в других местах не требуются.

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
Конвенция языковых ключей: `Lang.Options.Theme.{PascalCase}` (напр. `Lang.Options.Theme.Nebula`)

### Поддерживаемые темы

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | Только `Dictionary.xaml` | Оригинальный текстурный фон ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Светлый тон + синий акцент |
| 2 | `dark` | `FluentStyles.xaml` | Тёмный тон + синий акцент (по умолчанию) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Красный + чёрный |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Тёмный космос |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Яркий закат |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Тёмный океан |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Яркий нордический |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Яркий цитрусовый |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Яркий цветочный |

Смена темы вызывает автоматический перезапуск приложения. (сохраняется в `theme.cfg`)

### Функция фоновой текстуры

Выберите изображение в карточке **Background Texture** на вкладке Themes для применения в качестве фона всего приложения. Работает с любой выбранной темой.

**Поддерживаемые форматы ввода**: `.png` / `.jpg` / `.jpeg`, до 50МБ, разрешение 4K или ниже

**Конвейер обработки изображений**

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

**Слои безопасности**

| Слой | Метод | Эффект |
|---|---|---|
| Магический заголовок | 16 байт вставлены перед JPEG-подписью (FF D8 FF) | Внешние просмотрщики не могут распознать файл |
| Атрибут Hidden | `FileAttributes.Hidden` | Скрыт в Проводнике по умолчанию |
| Целостность SHA-256 | Хеш проверяется при загрузке | Подделка вызывает автоматический сброс + popup предупреждения |

**Поведение при обнаружении подделки**
1. `bg.dat` deleted
2. Ключи `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` сброшены
3. TextBox и переключатель сброшены
4. Отображается popup `Lang.Windows.TextureTampered`

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**Обработка прозрачности**

Когда фоновое изображение активно, фоны UI обрабатываются в два слоя.

- **Слой 1 — наложение MergedDictionaries**: Панели, ссылающиеся на `{DynamicResource FluentBgBrush}` и т.д., автоматически становятся прозрачными. Восстанавливаются одним вызовом `Remove()` при деактивации.

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Слой 2 — Обход визуального дерева (`WalkStyleBackgrounds`)**: Элементы `{StaticResource}` в темах Fluent не затрагиваются Слоем 1, поэтому визуальное дерево обходится напрямую для применения полупрозрачных кистей на основе исходных цветов.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  Обрабатываются: `Panel` (кроме Grid), `Border`, `ListBox` / `ListView`

  Исключены: `Grid` (фон сохранён, дочерние элементы обходятся), `TabPanel` (защита заголовка вкладки), `ButtonBase` / `ComboBox`, элементы `Collapsed`

  Восстановление: источник Style Setter → `ClearValue()`, источник локального значения XAML → восстановление оригинальной кисти напрямую

**Переключение вкладок**

WPF TabControl лениво загружает содержимое вкладок, поэтому `WalkStyleBackgrounds(this)` повторно выполняется с приоритетом `ContextIdle` при смене вкладки. Уже обработанные элементы пропускаются через проверку `ContainsKey`.

**Блокировка ThemeSelector**

Когда фоновая текстура активна, Border `ThemeSelectorOverlay` отображается поверх селектора тем для блокировки взаимодействия.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` также защищён флагом `_textureActive`

**Поток состояний UI**

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

**Новые языковые ключи**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**Структура файлов**

```
ModAPI\
├── App.xaml.cs                    # Реестр тем, ID тем, применение темы
├── Windows\
│   ├── MainWindow.xaml            # Вкладка Themes, оверлей выбора темы, слой текстуры 1
│   └── MainWindow.xaml.cs         # Логика тем и текстур
├── Themes\
│   ├── Dictionary.xaml            # Тема Classic
│   ├── FluentStyles.xaml          # Тема Dark
│   ├── FluentStylesLight.xaml     # Тема Light
│   ├── FluentStylesDiablo.xaml    # Тема Diablo
│   ├── FluentStylesNebula.xaml    # Тема Nebula
│   ├── FluentStylesSunset.xaml    # Тема Sunset
│   ├── FluentStylesOcean.xaml     # Тема Ocean
│   ├── FluentStylesNordic.xaml    # Тема Nordic
│   ├── FluentStylesCitrus.xaml    # Тема Citrus
│   └── FluentStylesBloom.xaml     # Тема Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Сжатое и защищённое фоновое изображение (создаётся при запуске)
```

**Известные ограничения проектирования**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Прямая замена ключей `MergedDictionaries` | Сбой во время прохода макета → только паттерн `Add`/`Remove` |
| Перезапись скрытого файла | `Access Denied` → необходимо сбросить `FileAttributes.Normal` перед записью |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## Изменения в v2.0.9612

### Разделение модуля тем

- **Новая папка `Themes/`**: Перемещены `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` и `FluentStylesClassic.xaml` в `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — тема Classic использует только `Dictionary.xaml`; Light/Dark/другие темы Fluent загружают соответствующий XAML
- **`ModAPI.csproj`**: Пути XAML тем обновлены на подкаталог `Themes\`; зарегистрирован `FluentStylesClassic.xaml`

---

## Изменения в v2.0.9611

### Исправление ошибки

- **Ширина списка модов не применялась после смены темы**: Исправлена проблема, при которой ширина списка модов не применялась после переключения между темами Light/Dark и перезапуска — добавлен вызов `ApplyModListWidth(width)` внутри `InitModListWidth()`

---

---

## Изменения в v2.0.9610

### Добавлено

#### Конфигурация XML Игр и Версий

| # | Файл | Изменение |
|---|------|--------|
| 1 | `GH.xml` | Полная перезапись — удалён несуществующий `DOTweenPro.dll`; добавлены `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Полная перезапись — удалён `extends="GenericUnityGame"`; добавлены `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Полная перезапись — удалён `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Создан — версия `1.1.01` с контрольной суммой |
| 5 | `GH/Versions.xml` | Создан — версия `2.9.5` с контрольной суммой |
| 6 | `Subnautica/Versions.xml` | Создан — без контрольной суммы (обновления слишком частые) |

#### Критические Исправления Ошибок

| # | Тип | Проблема | Исправление |
|---|------|-------|-----|
| 1 | Зависание | `extends="GenericUnityGame"` вызвал наследование `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` зависал | Удалён `extends` из всех XML кроме TheForest |
| 2 | Сбой | `ResolutionException: XGamingRuntime.XUserGamertagComponent` при применении Subnautica | Добавлены `XGamingRuntime.dll`, `XblPCSandbox.dll` в `copyAssembly` |
| 3 | Сбой | Резолвер не смог на DLL добавленных в `copyAssembly` после создания бэкапа | `Game.cs`: фактическая папка установки добавлена как резервный вариант резолвера |
| 4 | Сбой | `IOException`: `BaseModLib.dll` блокировка файла между `CreateModLibrary` и `ApplyMods` | Цикл повторов: макс. 10 × 500мс чтение + макс. 30 × 500мс ожидание существования |
| 5 | Сбой | `NullReferenceException` — `typesMap` entry.Value null (игра не установлена) | Добавлено `if (entry.Value == null) continue` |
| 6 | Сбой | `NullReferenceException` — лёгкий `Game` конструктор без `ModLibrary = new ModLib(this)` → сбой `CreateModLibrary()` | Добавлено `ModLibrary = new ModLib(this)` в лёгкий конструктор |
| 7 | Сбой | `SwitchDevGame()` — `App.Game.GamePath` пуст после лёгкого конструктора → сбой `CreateModLibrary` | Установлено `App.Game.GamePath = savedPath` после лёгкого конструктора |
| 8 | Неверная Игра | `EscapeThePacific` моды классифицированы как TheForest | `ModsViewModel`: `GameId` извлечён из пути папки |
| 9 | Неверный Путь | `GetGameFolder()` → `""` → разрешается в корень диска (напр. `E:\`) | Защита null/пусто во всех 6 местах вызова |

#### Разделение Сборки Debug / Release

- **`FileValidator.cs`** — новый файл `ModAPI_Shared\Utils\FileValidator.cs`; зарегистрирован в `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — PE-заголовок (MZ + PE\0\0) + минимум 1 МБ
  - `IsValidGameExe()` — PE-заголовок + минимум 512 КБ
  - `IsValidAssemblyDll()` — PE-заголовок + заголовок метаданных CLR .NET + минимум 64 КБ
- **`CheckSteam()`** — `#if DEBUG`: только `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: только `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` Cecil пропущен / `#else`: полный анализ Cecil + модификация IL
- **`ModLib.Create()` файл не найден** — `#if DEBUG`: записать предупреждение, пропустить / `#else`: записать ошибку, прервать

#### Тестирование Debug

- **`create_dummy_Debug_games.ps1`** — скрипт PowerShell для `bin\Debug\`; создаёт файлы-заглушки размером 0 байт для всех 5 игр в `dummy_games\`, `dummy_steam\` и `gamefiles\original\` — позволяет полное тестирование рабочего процесса UI без реальной установки игры

#### Вкладка Settings

- **Карточка пути Steam** — интегрирована в карточку Путей Установки Игр; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Панель путей игр** — `BuildGamePathsPanel()` с раскрывающимися карточками для каждой игры; TextBox использует `HorizontalAlignment=Stretch`
- Кнопка **Развернуть Все / Свернуть Все**
- Флажок **Всегда Поверх** (сохраняется в `ui.cfg`)
- Ползунки **Ширина Списка Модов/Проектов** — начало от минимума `150`; сохраняется в `ui.cfg`
- ComboBox **Размер Шрифта** — FHD 10–16, 4K 10–22, 8K 10–28
- **Синхронизация флажков** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions теперь синхронизируются правильно
- **Флаг `_uiInitialized`** — предотвращает преждевременную запись `ui.cfg` при запуске WPF

#### Вкладка Mods — Валидация Запуска Игры

Пятишаговая валидация выполняется при каждом нажатии Start Game, независимо от состояния списка модов:

| Шаг | Проверка | Popup |
|---|---|---|
| 1 | Путь Steam во вкладке Settings валиден (`Steam.exe` существует) | SteamNotFound |
| 2 | Игра в папке `mods/{GameId}/` соответствует настроенной игре в Settings | GameModsMismatch |
| 3 | Выбран хотя бы один мод | NoModSelected |
| 4 | Нет смешанных модов игр в выборе | MixedGameMods |
| 5 | Путь игры настроен + исполняемый файл существует | GamePathNotSet / GameNotInstalled |

#### Вкладка Development — Валидация ModLib

Трёхшаговая валидация при нажатии Регенерации Библиотеки Модов:

| Шаг | Проверка | Popup |
|---|---|---|
| 1 | Путь Steam во вкладке Settings валиден | SteamNotFound |
| 2 | Существует хотя бы один проект | NoProjectWarning |
| 3 | `App.Game.GamePath` установлен | GamePathNotSet |

#### Вкладка Downloads
- Строка отладки заменена на `Lang.Downloads.Status.NoDownloads`
- Единообразные отступы для всех сообщений статуса
- Текст офлайн-инструкции обновлён для 5 поддерживаемых игр; перенос строки через два TextBlock

#### Начальная Настройка и Система Путей Игр
- `FirstSetup.Check()` — значение по умолчанию `true` для `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — создаёт папки `mods/` и `projects/` для всех 5 игр
- `SpecifyGamePath` — `GameNameLabel` показывает какую игру; `NavigateToSettings()` перенаправляет на вкладку Settings

#### Новые / Обновлённые Языковые Ключи

| Ключ | Значение (англ.) |
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

### Не включено

| Функция | Причина |
|---|---|
| Авто-обновление (поддержание последней версии) | Серверная инфраструктура недоступна |
| Поиск обновлений | Серверная инфраструктура недоступна |

### Удалено

| Элемент | Причина |
|---|---|
| Popup `SpecifyGamePath` при запуске | Все пути настроены во вкладке Settings |
| Popup `SpecifySteamPath` при запуске | Путь Steam настроен во вкладке Settings |
| Система входа | Оригинальный сервер больше не работает (удалено в v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Нефункционален на Mono 2.0 (удалено в v2.0.9586) |
| Условие `UseSteam` при проверке Steam | Steam теперь всегда валидируется первым при Запуске Игры и Регенерации Библиотеки Модов |

---

## Планируется в будущих версиях

| # | Функция | Описание |
|---|---|---|
| 1 | Автообновление ModAPI | Автоматически загружать и применять новые версии ModAPI |
| 2 | Обновление таблицы VersionsData ModAPI | Автоматически обновлять таблицу VersionsData при выходе новых патчей игры |

---

## Изменения в v2.0.9600

### Добавлено

- **Вкладка Downloads**: 5 фильтров игр (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Вкладка Welcome**: добавлена в крайнюю левую позицию (индекс 0)
- **Вкладка Mods**: макет в 3 столбца (WrapPanel → вертикальный список); автоматическая подстройка ширины; перенос имени мода
- **`ModsViewModel`**: фильтрация по играм, `ResolveGame()` для правильного экземпляра `Game` на мод
- **`Game.cs`**: лёгкий конструктор `new Game(config, true)` — только идентификация, без `Verify()`
- **Сборка**: 4 файла XML игр зарегистрированы в `ModAPI.csproj` с `CopyToOutputDirectory=Always`
- **Сборка**: предупреждения очищены — CS0168, CS0618, CS0252
- **XML Игр**: списки DLL TheForest, Raft, GH исправлены
- **Языковые флаги**: размеры изображений стандартизированы для всех 13 языковых значков

### Удалено

| Элемент | Причина |
|---|---|
| `extends="GenericUnityGame"` в файлах XML игр | Вызывал некорректное наследование `Assembly-CSharp-firstpass.dll` — удалён из Subnautica, Raft, EscapeThePacific, GH |
| Макет `WrapPanel` во вкладке Mods | Заменён на 3-столбцовый макет Grid (Фильтр Игр / Список Модов / Информация) |

---

## Ключевые изменения по фазам

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Все 5 проектов мигрированы с .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, заглушка DLL UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Система 3 тем, `theme.cfg`, исправление перетаскивания окна, поддержка гиперссылок.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Система входа удалена, механизм обновления модернизирован.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Вкладка Downloads, иконки Segoe MDL2 Assets, поддержка 13 языков.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, патчинг PE-заголовка.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Чёрный экран исправлен, `ValueTuple` удалён, C# 7.3 проверен в игре.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 фильтров игр, 3-столбцовая вкладка Mods, лёгкий конструктор `Game`, XML зарегистрирован.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML исправлен, путь Steam, безопасность пути игры, 5-шаговая валидация Запуска Игры, 3-шаговая валидация ModLib, верификация PE-заголовка `FileValidator`, разделение сборки `#if DEBUG`, `create_dummy_Debug_games.ps1`, исправление лёгкого конструктора `ModLibrary`, исправление GamePath в `SwitchDevGame`, создание папок для 5 игр, исправления сбоев.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Вкладка Themes добавлена, 10 тем + функция фоновой текстуры, разделение папки Themes/, исправление кнопки максимизации, исправление раскрытия пути игры, обновление Versions.xml для 4 игр, кнопки сброса пути, авто-сохранение Browse, MODAPI_VersionTool.

---

## История версий

### v2.0.9618 — 2026-04-25
Добавлен MODAPI_VersionTool (автономный WPF-инструмент обновления версии), отображение версии в StatusBar связано с App.Version

### v2.0.9617 — 2026-04-24
Добавлены кнопки сброса пути Steam/игры во вкладке Settings, авто-сохранение Browse, состояние сброса сохраняется через флаг ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml создан/обновлён для 4 игр (Subnautica, Raft, EscapeThePacific, GH), установлены правила составления контрольных сумм, документирована процедура обновления игры

### v2.0.9615 — 2026-04-18
Исправлена точность высоты раскрытия карточки пути игры в Settings, предотвращение влияния фоновой текстуры на UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Кнопка максимизации с ручной максимизацией на основе WorkArea, сохранение и восстановление предыдущего размера/позиции

### v2.0.9613 — 2026-04-18
Добавлена вкладка Themes, структура реестра тем на основе данных, поддержка 10 тем, функция фоновой текстуры (сжатие, безопасность, 2-слойная прозрачность), оверлей блокировки ThemeSelector, 12 новых языковых ключей

### v2.0.9612 — 2026-04-18
Разделение папки Themes/, модуляризация XAML тем

### v2.0.9611 — 2026-04-18
Исправлена ширина списка модов не применяемая после смены темы

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 фильтров игр, 3-столбцовый макет вкладки Mods, автоматическая ширина, лёгкий конструктор `Game`, фильтрация игр `ModsViewModel`, 4 файла XML зарегистрированы, предупреждения сборки очищены, вкладка Welcome, языковые флаги стандартизированы

### v2.0.9586 — 2026-03-31
Чёрный экран исправлен, полифил финализирован, ValueTuple удалён, C# 7.3 проверен

### v2.0.9561 — 2026-03-06
Поддержка C# 7.3, патчинг PE-заголовка, конвейер полифилов, разрешение сборок восстановлено

### v2.0.9552 — 2026-02-25
Вкладка Downloads, модернизация иконок, унификация тем, поддержка 13 языков

### v2.0.9500
Система тем (Classic/Light/Dark), Fluent Design UI, система SubWindow

### v2.0.9400
Очистка кода, удаление входа, модернизация устаревшего кода

### v2.0.9300
Среда сборки, заглушка DLL UnityEngine, интеграция ModernWpf

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Требования к сборке

| Требование | Версия | Примечания |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Проекты ModAPI |
| .NET Framework SDK | 3.5 | Только BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Лицензия

GNU General Public License v3.0 — следует оригинальной лицензии.
