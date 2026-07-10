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

**Инструмент управления модами для The Forest — Расширенная версия**

> Оригинал: FluffyFish / Philipp Mohrenstecher (Энгельскирхен, Германия)
> Доработка: zzangae (Республика Корея)

---

## Обзор

ModAPI — это настольное приложение для управления модами для **5 официально поддерживаемых игр**. Данная расширенная версия включает поддержку нескольких игр, полностью переработанную вкладку Settings, настройку пути Steam, постоянные настройки интерфейса, динамическую систему размера шрифта, проверку при запуске игры, разделение сборок Debug/Release, а также многочисленные исправления сбоев, проверенные в ходе игровых тестов.

---

## Поддерживаемые Игры

| Игра | Движок | Версия | Steam ID | Исполняемый файл |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Патч 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Бета) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Пункт | Значение |
|---|---|
| Движок | Unity 5 (обновлено с Unity 4) |
| Последняя версия | v1.12 (VR) |
| Последнее обновление | 11 сентября 2019 г. — патч поддержки VR; дальнейших крупных обновлений контента не было |
| Исполняемый файл | `TheForest.exe` |
| Папка данных | `TheForest_Data/Managed/` |
| Папка модов | `mods/TheForest/` |
| Папка проектов | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — полностью поддерживается |

The Forest была обновлена с Unity 4 до Unity 5, что значительно улучшило графику и физику. Патч VR от сентября 2019 года стал последним крупным обновлением. Игра сейчас находится в стабильном, завершённом состоянии — идеальном для моддинга.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Пункт | Значение |
|---|---|
| Движок | Unity (объединённая кодовая база, унифицированная с Below Zero в 2022 году) |
| Последняя версия | Патч 2025 (v18810395) |
| Последнее обновление | 12 августа 2025 г. — исправления ошибок и улучшения производительности вместе с мобильным релизом |
| Исполняемый файл | `Subnautica.exe` |
| Папка данных | `Subnautica_Data/Managed/` |
| Папка модов | `mods/Subnautica/` |
| Папка проектов | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — поддерживается |

Изначально созданная на Unity 5, Subnautica получила обновление "Living Large" (v2.0) в конце 2022 года, которое объединило кодовую базу движка с Below Zero для улучшения оптимизации и стабильности. Примечание: предстоящая *Subnautica 2* использует Unreal Engine 5.

> **XML переписан в v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` добавлены в `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Пункт | Значение |
|---|---|
| Движок | Unity |
| Последняя версия | v1.1.02 (Бета) / v1.09 (Stable) |
| Последнее обновление | Март 2026 г. — исправления ошибок голосового чата и мультиплеера через бета-ветку |
| Исполняемый файл | `Raft.exe` |
| Папка данных | `Raft_Data/Managed/` |
| Папка модов | `mods/Raft/` |
| Папка проектов | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — поддерживается |
| Versions.xml | `1.1.01` (с контрольной суммой) |

После официального завершения сюжета в v1.0: *The Final Chapter*, патчи продолжали выпускаться для улучшения сетевого кода и стабильности. Обновление бета-ветки в марте 2026 года решило проблемы с голосовым чатом и мультиплеером.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Пункт | Значение |
|---|---|
| Движок | Unity 6 (миграция с Unity 2021/2022 в конце 2025 года) |
| Последняя версия | v0.67.0.0 |
| Последнее обновление | 26 июня 2025 г. — переработка распределения островов и обновление движка; хотфиксы продолжаются до 2026 года |
| Исполняемый файл | `EscapeThePacific.exe` |
| Папка данных | `EscapeThePacific_Data/Managed/` |
| Папка модов | `mods/EscapeThePacific/` |
| Папка проектов | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — поддерживается |

Завершила крупную перестройку системы и миграцию на Unity 6 в конце 2025 года, что позволило создать более динамичные среды. Игра остаётся в активной разработке в раннем доступе.

> **XML переписан в v2.0.9610**: удалён `extends="GenericUnityGame"`; `includeAssembly` установлен только на `Assembly-CSharp.dll` — предотвращает ошибки наследования `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Пункт | Значение |
|---|---|
| Движок | Unity 2019 |
| Последняя версия | v2.9.5 |
| Последнее обновление | 4 февраля 2026 г. — оптимизация под Steam Deck и улучшение читаемости текста |
| Исполняемый файл | `GH.exe` |
| Папка данных | `GH_Data/Managed/` |
| Папка модов | `mods/GH/` |
| Папка проектов | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — поддерживается |
| Versions.xml | `2.9.5` (с контрольной суммой) |

Разрабатывалась на протяжении своего жизненного цикла через Unity 2017 → 2018 → 2019. Хотфикс февраля 2026 года был сосредоточен на совместимости со Steam Deck и читаемости интерфейса.

> **XML переписан в v2.0.9610**: добавлены `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll`; удалён несуществующий `DOTweenPro.dll`.
</details>

---

<details>
<summary><b>Архитектура</b></summary>

### Разделение Среды Выполнения

| Компонент | Цель | Среда выполнения | Причина |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Настольное приложение, полный современный API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Общая библиотека |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Зафиксировано навсегда** — заголовок PE должен указывать `v2.0.50727` |
| DLL модов (пользователь) | .NET Framework 4.8 | Game Mono 2.0 (пропатчен) | Собрано с 4.8, заголовок PE патчится при применении |

### Инструменты для Разработчиков

Автономные утилиты WPF для управления проектами. Не распространяются среди конечных пользователей.

| Инструмент | Проект | Назначение |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Одновременно обновляет версию `AssemblyInfo.cs` и `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Управляет языковыми файлами — добавление, редактирование, деактивация, встраивание |

**VersionTool — Управление Версиями**

Автономный инструмент WPF для обновления номера версии одним щелчком.

- Автоматически отображает текущую версию (считывается из `App.xaml.cs`)
- Введите новую версию и нажмите **Apply Version**, чтобы обновить оба файла одновременно
- Проверка формата: принимается только формат `X.X.XXXX`

| Файл | Путь | Изменение |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Языковая Система**

```
resources/langs/langs.json          ← Реестр языков (флаги builtin / active)
resources/langs/Language.XX.xaml    ← Ключи перевода для каждого языка
resources/langs/Language.XX.png     ← Изображение флага (36×24, с flagcdn.com/h24/)
```

Процесс встраивания (кнопка Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() переписан (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml зарегистрирован (ModAPI\ModAPI.csproj)
  → Следующая сборка: язык полностью встроен, доступен офлайн
```

### Разделение Сборок Debug / Release

Вся проверка файлов и обработка сборок разветвляется в зависимости от конфигурации сборки через `#if DEBUG` / `#else`.

| Расположение | Сборка Debug | Сборка Release |
|---|---|---|
| `CheckSteam()` | только `File.Exists()` — фиктивные файлы проходят | `FileValidator.IsValidSteamExe()` — заголовок PE + мин. 1 МБ |
| `CheckGamePath()` | только `File.Exists()` — фиктивные файлы проходят | `FileValidator.IsValidAssemblyDll()` — заголовок PE + метаданные CLR + мин. 8 КБ |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — анализ Cecil пропускается | Полный анализ Mono.Cecil + модификация IL + `module.Write()` |
| `ModLib.Create()` — файл не найден | Записывает предупреждение, пропускает и продолжает | Записывает ошибку, прерывает с всплывающим окном |

**Debug-тесты** используют `create_dummy_Debug_games.ps1` для создания файлов-заглушек размером 0 байт в `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` и `bin\Debug\gamefiles\original\`. Они проходят проверки `File.Exists()` и позволяют тестировать весь рабочий процесс интерфейса без реальной установки игры.

**Release-сборки** применяют `FileValidator` (проверка заголовка PE + метаданных CLR .NET) для отклонения файлов размером 0 байт, текстовых файлов и произвольных бинарных файлов. Проходят только допустимые исполняемые файлы Windows и сборки .NET.

### FileValidator — Проверка Заголовка PE

`ModAPI_Shared\Utils\FileValidator.cs` — применяется только в Release-сборках.

| Метод | Проверки | Минимальный размер |
|---|---|---|
| `IsValidSteamExe(path)` | Сигнатура MZ + сигнатура PE\0\0 | 1 МБ |
| `IsValidGameExe(path)` | Сигнатура MZ + сигнатура PE\0\0 | 512 КБ |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + заголовок метаданных CLR (каталог данных #14) | 8 КБ |

```
Проверяемая структура заголовка PE:
[0x00] 4D 5A          ← сигнатура DOS "MZ"
[0x3C] XX XX XX XX   ← смещение заголовка PE (little-endian)
[offset] 50 45 00 00 ← сигнатура "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← наличие заголовка .NET CLR
```

### Конвейер Ремаппинга Сборок

```
[Разработчик мода собирает с .NET 4.8]
  → DLL мода: заголовок PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0 и т.д.
  → modModule.RuntimeVersion = "v2.0.50727"
      заголовок PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → заголовок PE принят ✅  →  ссылки разрешены ✅
```

### Резервное Разрешение Сборок

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← папка резервной копии
2. {ActualGameInstallPath}/{AssemblyPath}        ← папка установки игры (резерв)
```

### Поддержка Функций C# 7.3

| Функция | Статус | Примечания |
|---|---|---|
| Сопоставление с образцом (`is`, `switch`) | ✅ | Проверено в игре |
| Интерполяция строк (`$""`) | ✅ | Проверено в игре |
| Встроенная переменная `out` | ✅ | Проверено в игре |
| `async` / `await` | ✅ | Через AsyncBridge + полифиллы System.Threading |
| Кортежи (`ValueTuple`) | ❌ Жёсткое ограничение | ABI `mscorlib` Mono 2.0 — обходных путей нет |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Начиная с v2.0.9613, интерфейс выбора темы был перемещён из вкладки Settings в выделенную вкладку **Themes**. Добавление новой темы требует всего одной строки в словаре `App.xaml.cs`.

| Индекс | ID | Файл | Палитра |
|---|---|---|---|
| 0 | `classic` | только `Dictionary.xaml` | Оригинальный текстурный фон ModAPI |
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

| Тема | Тема |
| :---: | :---: |
|**01. Тема Classic**|**02. Тема Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/dc81132a-149c-4d0b-a7bb-a04a900e878b) | ![02. Light theme](https://github.com/user-attachments/assets/0d6925ec-f8b2-4f8a-a1d6-c082a5aa3378) |
|**03. Тема Dark**|**04. Тема Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/53abe172-ee66-4f3e-9c36-830b2d659b4d) | ![04. Diablo theme](https://github.com/user-attachments/assets/8c30f223-e564-45dc-8389-c51bfc60b3eb) |
|**05. Тема Nebula**|**06. Тема Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/4ff565dd-516b-4951-9d47-6027ac9e3e29) | ![06. Sunset theme](https://github.com/user-attachments/assets/192a6f16-b041-4422-8b64-4f8522f27c15) |
|**07. Тема Ocean**|**08. Тема Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/50a47588-bc62-4cfc-91a0-a44f87c45867) | ![08. Nordic theme](https://github.com/user-attachments/assets/81e98f6b-2897-4fd5-bee9-604c04dc26ff) |
|**09. Тема Citrus**|**10. Тема Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/64ccb11d-4ab0-41a2-8e00-4f7910558372) | ![10. Bloom theme](https://github.com/user-attachments/assets/265c9249-4d43-4f77-86d6-ccc4037071f7) |

### Текстура Фона

Выберите изображение в карточке **Background Texture** на вкладке Themes, чтобы применить его в качестве фона всего приложения. Поддерживаемые форматы: `.png` / `.jpg` / `.jpeg`, до 50 МБ, разрешение 4K или ниже. Изображение сжимается в формате JPEG Q75 с 16-байтовым магическим заголовком и сохраняется как `resources\textures\ui_bg\bg.dat` (атрибут Hidden). Хэш SHA-256 для проверки целостности; изменение вызывает автоматический сброс + всплывающее предупреждение.

Когда фон активен, прозрачность интерфейса обрабатывается в двух слоях: Слой 1 (наложение MergedDictionaries) для панелей `{DynamicResource}`, Слой 2 (WalkStyleBackgrounds) для панелей на основе `{StaticResource}` с полупрозрачностью.

### Система Размера Шрифта

| Ключ ресурса | База | Описание |
|---|---|---|
| `AppBaseFontSize` | 13 | Обычный текст |
| `AppBaseHeaderFontSize` | 16 | Заголовки, названия панелей |
| `AppBaseSmallFontSize` | 12 | Второстепенные метки |
| `AppBaseTinyFontSize` | 10 | Текст подсказок |
| `AppBaseLargeFontSize` | 20 | Крупный текст отображения |

### Постоянная Конфигурация Интерфейса — `ui.cfg`

| Ключ | По умолчанию | Описание |
|-----|---------|-------------|
| `ModListWidth` | `150` | Ширина списка на вкладке Mods (px) |
| `ProjectListWidth` | `150` | Ширина списка проектов на вкладке Development (px) |
| `AppFontSize` | `13` | Глобальный размер шрифта интерфейса (px) |
| `AlwaysOnTop` | `false` | Окно всегда поверх других |
| `TexturePath` | *(нет)* | Исходное имя файла текстуры фона (только отображение) |
| `TextureHash` | *(нет)* | Хэш SHA-256 текстуры фона |
| `TextureActive` | `false` | Состояние активации текстуры фона |
| `GamePathReset_{GameId}` | *(нет)* | Флаг сброса пути игры |
| `SteamPathReset` | *(нет)* | Флаг сброса пути Steam |
</details>

<details>
<summary><b>Структура Проекта</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Постоянные настройки интерфейса
├── theme.cfg                            # Текущая тема
├── Windows/
│   ├── MainWindow.xaml / .cs            # Главный интерфейс — 6 вкладок, Themes, Settings, путь Steam,
│   │                                    #   защита от загрузки 0 байт, debounce ползунка, тихое чтение конфигурации
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Всплывающее окно пути игры (динамический GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # Первоначальная настройка + инициализация значений по умолчанию
│       └── (ещё 14 SubWindows)
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
│   ├── Mod.cs                           # Загрузка файлов модов, разбор заголовков LF/CRLF, диагностический журнал
│   ├── ModLib.cs                        # Генерация BaseModLib + ремаппинг (разделение #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Создание/сборка/применение проекта + защита от null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   предотвращение повторных попыток для повреждённых модов
│   │   ├── ModViewModel.cs              # GameId из пути папки
│   │   ├── ModProjectsViewModel.cs      # Dispose() для DispatcherTimer
│   │   └── SettingsViewModel.cs         # Значение по умолчанию true для UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Сопоставление версий сборок Mono 2.0 (20 сборок)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Резолвер на основе имени с кэшированием
│   └── MonoHelper.cs                    # Вспомогательные утилиты Mono.Cecil IL
├── resources/
│   ├── langs/                           # 13 языковых файлов + langs.json (ключи LangTool.* добавлены в v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Сжатое и защищённое фоновое изображение (генерируется во время выполнения)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Полная переработка в v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Полная переработка в v2.0.9610
    │   ├── GH.xml                       # Полная переработка в v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — не поддерживается
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt с параметром silent
├── Data/
│   ├── Game.cs                          # Автоматическое создание резервной копии для ApplyMods, условный резолвер,
│   │                                    #   резервный переход к папке игры, исправление лёгкого конструктора + инициализации ModLib
│   └── ModLib.cs                        # Разделение #if DEBUG, резервный переход к папке игры для IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Проверка заголовка PE + метаданных CLR (только Release, мин. 8 КБ)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Автономный инструмент WPF для обновления версии
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Ввод версии, кнопка Apply, отображение текущей версии
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Автономный инструмент WPF для управления языками
├── App.xaml / App.xaml.cs              # Загрузка/переключение языка, langtool.cfg
├── MainWindow.xaml / .cs               # Главный интерфейс — список языков, панель редактирования, выбор пути
├── AddLanguageDialog.xaml / .cs        # ComboBox выбора страны ISO 3166-1
├── ModApiDialog.xaml / .cs             # Пользовательское диалоговое окно в стиле ModAPI (Инфо/Предупреждение/Подтверждение/Вопрос)
├── Models/
│   ├── LanguageEntry.cs                # Модель языковой записи (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Корневая модель langs.json
│   └── IsoCountry.cs                   # Модель страны ISO для ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Чтение/запись langs.json
    ├── FlagDownloader.cs               # Загрузка флага с flagcdn.com h24
    ├── XamlGenerator.cs                # Генерация/сохранение/разбор Language.XX.xaml
    ├── MissingKeyDetector.cs           # Обнаружение отсутствующих ключей относительно английского эталона
    ├── IsoCountryList.cs               # Полный список стран ISO 3166-1 (196 стран, офлайн)
    └── BuiltinCodeWriter.cs            # Переписывание CreateDefaultLangsJson() + регистрация в ModAPI.csproj

bin\Debug\                               # Только для Debug-тестов
├── create_dummy_Debug_games.ps1         # Генерирует фиктивную структуру игры/Steam
├── dummy_games\{GameId}\               # Фиктивные пути установки игр
├── dummy_steam\Steam.exe               # Фиктивный исполняемый файл Steam
└── gamefiles\original\{GameId}\        # Фиктивные пути резервных копий для ModLib
```

---

</details>

<details>
<summary><b>Установка и Настройка</b></summary>

### Шаг 1 — Предварительные Требования

| Пункт | Требуется |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (предустановлен в Windows 11; [скачать](https://dotnet.microsoft.com/download/dotnet-framework/net48) для Windows 10) |
| Steam | Требуется — необходимо настроить на вкладке Settings |
| Хотя бы одна поддерживаемая игра | Требуется — необходимо настроить на вкладке Settings |

### Шаг 2 — Установка ModAPI

1. Скачайте последнюю версию с GitHub
2. Распакуйте в любую папку (например, `C:\ModAPI\`)
3. Запустите `ModAPI.exe`
4. При первом запуске появится экран **Welcome** — настройте параметры и нажмите **Continue**

### Шаг 3 — Настройка Пути Steam (Вкладка Settings)

1. Перейдите на вкладку **Settings**
2. Найдите **Steam Installation Path**
3. Нажмите **Browse** → выберите `Steam.exe`
4. Нажмите **Save**

### Шаг 4 — Настройка Путей Игр (Вкладка Settings)

1. Нажмите на заголовок карточки игры, чтобы развернуть её
2. Нажмите **Browse** → выберите корневую папку игры (где находится `.exe`)
3. Нажмите **Save**

| Игра | Исполняемый файл | Пример пути |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Шаг 5 — Загрузка Модов (Вкладка Downloads)

1. Перейдите на вкладку **Downloads**
2. Выберите игру в фильтре игр
3. Найдите мод или просмотрите список и нажмите **Download**

> **Офлайн**: скачайте файлы `.mod` вручную с `modapi.survivetheforest.net` и поместите их в соответствующую папку:

| Игра | Папка |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Шаг 6 — Применение Модов и Запуск Игры (Вкладка Mods)

1. Перейдите на вкладку **Mods**
2. Выберите игру в **Game Filter** (столбец 0)
3. Отметьте моды для активации в **Mod List** (столбец 1)
4. Нажмите **Start Game**

Перед запуском автоматически выполняются следующие проверки:

| # | Проверка | Всплывающее окно при сбое |
|---|---|---|
| 1 | Путь Steam настроен и корректен | SteamNotFound |
| 2 | Игра в папке `mods/` соответствует пути игры в Settings | GameModsMismatch |
| 3 | Выбран хотя бы один мод | NoModSelected |
| 4 | В выборе нет смешанных модов разных игр | MixedGameMods |
| 5 | Путь игры настроен и исполняемый файл существует | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Обзор Вкладок</b></summary>

### Вкладка Welcome
Экран первоначальной настройки (индекс вкладки 0). Настройте AutoUpdate, подключение к Steam и предпочтения таблицы VersionsData. При последующих запусках эта вкладка предоставляет ссылки сообщества и заметки о выпуске.

### Вкладка Mods
Основной рабочий процесс управления модами — трёхколоночный макет:

| Колонка | Содержимое |
|---|---|
| Колонка 0 | Game Filter — переключатели для 5 поддерживаемых игр |
| Колонка 1 | Mod List — установленные моды с выбором версии и флажком активации |
| Колонка 2 | Information — сведения, описание и история версий выбранного мода |

### Вкладка Downloads
Просмотр и загрузка модов с `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 категорий (исправления ошибок, баланс, читы, …)
- **Search**: по названию мода, описанию или автору
- **Offline mode**: отображает инструкции по папкам для всех 5 поддерживаемых игр

### Вкладка Development
Рабочий процесс разработки модов — панель фильтра игр (колонка 0) охватывает все 5 поддерживаемых игр.

- Создание, сборка и применение проектов модов для каждой игры
- Управление языковыми ресурсами
- Генерация ModLib с трёхэтапной проверкой (Steam → проект → путь игры)
- Безопасное переключение игры через лёгкий конструктор `Game` (без вызова `Verify()`)

### Вкладка Themes
Выбор темы и управление текстурой фона.

- **Выбор темы**: 10 тем (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Текстура фона**: выберите изображение в качестве фона всего приложения (JPEG-сжатие + обработка безопасности)
- Когда текстура фона активна, выбор темы заблокирован

### Вкладка Settings
Централизованная конфигурация — 4 строки:

| Строка | Содержимое |
|---|---|
| 0 | Язык / Размер шрифта / Максимальная ширина / Ширина Mod List / Ширина Project List |
| 1 | Сохранять VersionsData / Автообновление / Подключение Steam / Всегда поверх других |
| 2 | Steam Installation Path (текстовое поле + Browse + Save + Reset) |
| 3 | Game Installation Paths — раскрывающаяся карточка для каждой игры (текстовое поле + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Инструмент Управления Языками)

Автономный инструмент WPF для управления языковыми файлами ModAPI. Добавлен в решение как `LangTool\MODAPI_LangTool.csproj`.

**Расположение**: `LangTool\MODAPI_LangTool.csproj`

**Основные Функции**

| Функция | Описание |
|---|---|
| Список языков | Отображает все языки из `langs.json` со значками статуса (🔒 встроенный / 🚫 неактивный / ✅ активный) |
| Добавление языка | Выберите страну в ComboBox ISO 3166-1 → флаг автоматически загружается с `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` автоматически генерируется из английского шаблона |
| Редактирование языка | `isoCode` / `langCode` заблокированы; `langName` и ключи перевода редактируются, когда язык активен |
| Деактивация / Активация | Переключает флаг `active` в `langs.json` — файл сохраняется, скрывается из списка ModAPI |
| Обновление (встраивание) | Преобразует `builtin: false` → `true` — необратимо, подтверждение в 2 шага — автоматически переписывает `CreateDefaultLangsJson()` в исходном коде и регистрирует `Language.XX.xaml` в `ModAPI.csproj` |
| Обнаружение отсутствующих ключей | Сравнивает с английским эталоном — показывает количество отсутствующих/пустых ключей и прогресс перевода |
| Защита встроенных | Языки с `builtin: true` доступны только для чтения — редактирование, деактивация или обновление невозможны |
| Защита неактивных | Языки с `active: false` доступны только для чтения до реактивации |
| Языковой интерфейс | Сам LangTool поддерживает все 13 языков ModAPI — переключатель языка с флагом в правом верхнем углу |
| Запоминание пути | Выбранный корневой путь ModAPI сохраняется в `langtool.cfg` — автоматически загружается при следующем запуске |
| Пользовательские диалоги | Все всплывающие окна используют тёмную тему `ModApiDialog` в стиле ModAPI вместо системного MessageBox |

**Структура langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Соглашение об Изображениях Флагов**

```
Код ISO (строчными буквами) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                              resources/langs/
```

**Поведение Кнопки Update**

При нажатии кнопки Update для активного, не встроенного языка:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` переписывается со всеми текущими языками `builtin: true`
3. `ModAPI\ModAPI.csproj` — регистрируется `<Resource Include="resources\langs\Language.XX.xaml" />`
4. Следующая сборка — язык полностью встроен, доступен офлайн

**Добавленные Языковые Ключи** (`Lang.LangTool.*`)

53 новых ключа добавлены во все 13 языковых файлов, охватывающих все строки интерфейса LangTool, сообщения диалогов и тексты состояния.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Инструмент Обновления Версии)

Автономный инструмент WPF для обновления номера версии одним щелчком.

**Расположение**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Функции**
- Автоматически отображает текущую версию (считывается из `App.xaml.cs`)
- Введите новую версию и нажмите **Apply Version**, чтобы обновить оба файла одновременно
- Проверка формата: принимается только формат `X.X.XXXX`

**Изменённые Файлы**

| Файл | Путь | Изменение |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Использование**
1. Запустите `MODAPI_VersionTool.exe`
2. Введите новую версию (например, `2.0.9619`)
3. Нажмите **Apply Version**
4. Пересоберите решение ModAPI в Visual Studio

**Отображение Версии в StatusBar**

- `VersionLabel.Text` теперь ссылается на `App.Version` вместо жёстко закодированного дескриптора
- Обновление версии с помощью VersionTool и пересборка немедленно отражаются в StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Система Журналирования — Разделение на Два Файла (`ModAPI.log` / `ModAPI.detailed.log`)

Диагностические журналы, предназначенные только для разработчиков, ранее ограничивались `#if DEBUG`, из-за чего они были невидимы в Release-сборках именно тогда, когда они были наиболее необходимы для устранения проблем пользователя. Двухфайловая система заменяет это:

| Файл | Содержимое |
|---|---|
| `ModAPI.log` | Основной журнал, ориентированный на пользователя — внешний вид не изменился, не более шумный, чем раньше |
| `ModAPI.detailed.log` | Каждый вызов журналирования, всегда, как в Release, так и в Debug — для диагностики проблем, сообщаемых пользователями |

**`Debug.cs`** — `Log()` имеет параметр `detailedOnly`. Когда он `true`, сообщение записывается только в `ModAPI.detailed.log`; все предыдущие блоки `#if DEBUG` были преобразованы в этот флаг вместо полного исключения из компиляции, поэтому они всегда фиксируются в подробном файле даже в Release. Это приводит к 4-уровневой модели серьёзности:

| Уровень | Значение |
|---|---|
| Verbose (`detailedOnly: true`) | Повторяющиеся/механические трассировки — по типу, по файлу, по методу |
| Notice | Понятный человеку поток — сообщения о ходе выполнения и успехе |
| Warning | Потенциальные проблемы, ещё не сбои |
| Error | Подтверждённые сбои |

**Источники шума в журналах, выявленные и преобразованные в `detailedOnly: true`:**

| Файл | Что заполняло `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Сообщения сканирования/пропуска/очереди `FindMods()`, повторяющиеся при каждом опросе раз в 1 секунду |
| `Game.cs` | Строки трассировки TLS/URL из `UpdateVersions()`, записи сопоставления типов Cecil |
| `ModLib.cs` | Обработка сборок по типу/методу с помощью Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — ответственная за подавляющую часть объёма `ModAPI.log` (десятки тысяч строк для одной сборки мода Green Hell) |
| `Mod.cs` | Полный дамп XML заголовка мода (`configuration.ToString()`), полностью регистрируемый при каждой загрузке мода |

**Журналирование расхождений контрольной суммы — сводка вместо построчной записи:** `Header.Verify()` ранее записывал одну строку `Mismatched checksum at "..."` для каждой несовместимой записи `InjectInto`/`AddMethod`/`AddField`/`AddClass`, что могло означать десятки строк для одного устаревшего мода. Теперь он записывает единую сводку уровня Warning в `ModAPI.log` (например, `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), в то время как полная построчная расшифровка остаётся доступной в `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Изменения в v2.0.9620</b></summary>

## Изменения в v2.0.9620

### Добавлен MODAPI_LangTool

Добавлен автономный инструмент WPF для управления языковыми файлами ModAPI (`LangTool\MODAPI_LangTool.csproj`) — полные сведения см. в разделе **Lang Tool** выше.

---

### Исправления Ошибок

| # | Файл | Проблема | Исправление |
|---|---|---|---|
| 1 | `App.xaml.cs` | Французский язык примешивался к сообщениям исключений .NET в неанглийской версии Windows | `CultureInfo.InvariantCulture` зафиксирован при запуске конструктора `App()` |
| 2 | `Game.cs` | Ошибка SSL/TLS в `UpdateVersions()` — не удавалось создать безопасный канал SSL/TLS | TLS 1.2 явно установлен через `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Всплывающее окно `GamePathNotSet` для Green Hell, несмотря на настроенный путь | `App.Game.GamePath` пуст → читает сохранённый путь из `Configuration` |
| 4 | `ModsViewModel.cs` | Файлы модов не отображались в списке при ручном размещении в `mods\TheForest\` | Добавлен диагностический журнал проверки шаблона имени файла |
| 5 | `MainWindow.xaml.cs` | Всплывающее окно `MixedGameMods` блокировало выбор модов нескольких игр | Блокирующее всплывающее окно удалено — заменено на `SelectGameDialog` |

---

### Новые Функции

#### Запуск Игры — Всплывающее Окно Выбора Игры (`SelectGameDialog`)

Когда выбраны моды разных игр или активен фильтр **All**, вместо блокировки запуска появляется всплывающее окно выбора игры.

**Условия срабатывания:**
- Выбран фильтр `All` + нажат Start Game
- Одновременно активированы моды из 2 или более разных игр

**Поведение:**
- Отображаются только игры с настроенными путями и существующим исполняемым файлом
- Применяются только моды выбранной игры — моды других игр полностью игнорируются
- Переключатель синхронизируется с выбранной игрой после закрытия всплывающего окна (`SyncModGameFilterRadioButton`)

**Новые файлы**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Проверка Целостности Игры (только Release-сборка, `#if !DEBUG`)

Перед каждым запуском игры выполняется трёхуровневая проверка целостности:

| Уровень | Метод | При сбое |
|---|---|---|
| A — Заголовок PE | `FileValidator.IsValidGameExe()` | Заблокировано + всплывающее окно `GameExeCorrupted` |
| B — Контрольная сумма сборки | Сравнение MD5 → `Versions.xml` | Заблокировано + всплывающее окно `GameAssemblyTampered` |
| C — Цифровая подпись | `HasDigitalSignature()` | Предупреждение + выбор пользователя (`GameIntegrityWarning`) |

**Новые файлы**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Новые методы, добавленные в `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — хэш MD5 файла Assembly-CSharp.dll (+ firstpass, если существует)
- `HasDigitalSignature(path)` — проверка подписи Authenticode

---

### Новые Диагностические Журналы

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 пунктов, Release + Debug)

| # | Этап | Тип | Содержимое |
|---|---|---|---|
| 1 | Настройка TLS | Notice | Протокол до/после |
| 2 | Начало загрузки | Notice | Список серверов |
| 3 | Попытка URL | Notice | Каждый испытываемый URL |
| 4 | Успешная загрузка | Notice | URL, длина ответа, использованный протокол |
| 5 | WebException | Error | URL, HTTP-статус, протокол, детали |
| 6 | Другое исключение | Error | URL, тип исключения, детали |
| 7 | Загрузка завершена | Notice | Количество успехов / общее число серверов |
| 8 | Успешный разбор | Notice | Количество файлов и версий до/после |
| 9 | Ошибка разбора | Error | Тип исключения и детали |
| 10 | Успешное сохранение | Notice | Путь сохранения, общее количество версий/файлов |
| 11 | Ошибка сохранения | Error | Путь, тип исключения, детали |
| 12 | Нет ответа | Error | Испытанные серверы, протокол |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 пунктов, только `#if DEBUG`)

| # | Ситуация | Тип | Содержимое |
|---|---|---|---|
| 1 | Начало сканирования | Notice | Путь папки модов, всего найдено файлов |
| 2 | Уже загружен | Notice | Имя файла |
| 3 | Не файл .mod | Notice | Имя файла |
| 4 | Успешное совпадение шаблона | Notice | Имя файла добавлено в очередь |
| 5 | Сбой совпадения шаблона | Warning | Имя файла + причина + ожидаемый формат |
| 6 | Сканирование завершено | Notice | Количество в очереди / всего файлов |
| 7 | Исключение | Error | Детали исключения |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 пунктов, Release + Debug)

| # | Ситуация | Тип | Содержимое |
|---|---|---|---|
| 1 | Условие всплывающего окна | Notice | Текущий фильтр, выбранные ID игр, needGameSelect |
| 2 | Игры-кандидаты | Notice | Список ID кандидатов для всплывающего окна |
| 3 | Путь не установлен | Notice | Игра пропущена — путь не настроен |
| 4 | Отсутствует в Configuration | Notice | Игра пропущена — отсутствует в Configuration.Games |
| 5 | Установка подтверждена | Notice | Игра + путь исполняемого файла |
| 6 | Exe не найден | Warning | Игра пропущена — отсутствует исполняемый файл |
| 7 | Нет установленных игр | Error | 0 кандидатов → GamePathNotSet |
| 8 | Автовыбор | Notice | Единственный кандидат выбран автоматически |
| 9 | Отменено пользователем | Notice | SelectGameDialog отменён |
| 10 | Игра выбрана + моды | Notice | Выбранная игра, количество/список собранных модов |

---

### Разделение Журналов Разработчика / Пользователя (`#if DEBUG`)

| Файл | Журнал | Причина |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Повторяется каждую секунду — 81% от общего объёма журнала |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Внутренние детали только для разработчиков |

В журнале Release сохраняются: успех/сбой загрузки, результаты разбора/сохранения, сбои совпадения шаблонов, исключения, результаты проверки целостности.

---

### Обновление Таблицы Версий — Архитектура

#### Замысел Проектирования

```
Игра получает обновление Steam
  → Assembly-CSharp.dll изменяется
  → ModAPI проверяет Versions.xml на известную контрольную сумму
  → Если не найдена → загружает последний Versions.xml с сервера
  → Новая версия автоматически регистрируется без переустановки ModAPI
```

#### Структура Соединения

```
Вкладка Settings → флажок KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → вызов UpdateVersions()
      → загружает Versions.xml из VersionUpdateDomains[]
      → перезаписывает локальный configs\games\{GameId}\Versions.xml
```

#### Интеграция URL Raw GitHub

Вместо того чтобы полагаться исключительно на `modapi.survivetheforest.net`, URL Raw GitHub теперь используется как основной источник для прямого управления:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — управляется напрямую, приоритет 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Устаревший сервер — резерв, приоритет 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Пункт | Детали |
|---|---|
| Основной | URL Raw GitHub — обновляется немедленно при push |
| Резервный | Устаревший сервер — используется, когда GitHub недоступен |
| Путь | `ModAPI/configs/games/{GameId}/Versions.xml` в репозитории |
| Изменённый файл | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Обновления Versions.xml

| Игра | Файл | Изменение |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Исправлена контрольная сумма (был неверный SHA-256 в верхнем регистре) — `2.9.5b114117` с правильным MD5 |
| The Forest | `configs\games\TheForest\Versions.xml` | Добавлено `1.12` (BuildID: 20229486) — 128-символьная контрольная сумма MD5 |

---

### Новые Языковые Ключи (13 языков)

| Ключ | Значение на английском |
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
| `Lang.Savegames.*` (133 ключа) | Английские значения добавлены к 12 языкам (DE уже переведён) |

---

### Изменённые Файлы

| Файл | Путь | Изменение |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` зафиксирован при запуске |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, проверка целостности, удалён MixedGameMods, синхронизация переключателя, 10 журналов |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Новый |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Новый |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Диагностический журнал имени файла, разделение #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 журналов UpdateVersions, URL GitHub, разделение #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 новых ключей + 133 ключа Savegames (515 всего, все языки согласованы) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Исправлена контрольная сумма |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | Добавлено `1.12` |
| `LangTool\` (13 файлов) | Корень решения | Новый |
| `ModAPI.sln` | Корень решения | LangTool зарегистрирован |

---

### Дополнительные Исправления и Переработка Системы Журналирования (2026-06-21)

#### Проверка StartGame — Полная Переработка

Порядок проверки исправлен на строгую 3-этапную последовательность, а всплывающее окно выбора игры теперь отражает активированные моды независимо от того, настроен ли путь игры.

| Этап | Проверка | Всплывающее окно при сбое |
|---|---|---|
| 1 | Steam установлен | SteamNotFound |
| 2 | Путь выбранной игры настроен + исполняемый файл существует | GamePathNotSet |
| 3 | Хотя бы один мод активирован для выбранной игры | NoModSelected |

- **Выбран фильтр All / моды нескольких игр** → всплывающее окно всегда перечисляет все игры с активированным модом, **включая те, у которых не настроен путь** — выбор ненастроенной игры теперь корректно показывает `GamePathNotSet` вместо молчаливого исключения или показа неверной ошибки
- **Фильтр одной игры** → проверки пути и модов выполняются напрямую для этой игры, в том же порядке 1→2→3

#### Критические Исправления Ошибок

| # | Файл | Проблема | Исправление |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` объединял ответы **всех** успешных серверов (GitHub + устаревший), удваивая контрольные суммы (64 → 128 символов) при успехе обоих — вызывало ложные блокировки `GameAssemblyTampered` | Разбирается только ответ первого успешного сервера; остальные серверы пропускаются, как только один из них успешен |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` использовал `App.Game` (текущий активный фильтр) вместо собственной игры мода — удаление мода Green Hell при активной The Forest искало неверную папку `Managed` и молча пропускало удаление | Теперь путь развёрнутой DLL разрешается из `mod.Game` (фактического экземпляра игры мода), с резервным переходом к `Configuration`, если `GamePath` пуст |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Повторная загрузка ранее удалённого мода восстанавливала его значок активации как отмеченный — удаление мода никогда не очищало его постоянные ключи `Selected`/`Version` или кэш ViewModel в памяти | Добавлены `RemoveKey()` / `RemoveKeysWithPrefix()` в `Configuration.cs`; `DeleteMod_Click` теперь принудительно устанавливает `ModViewModel.Selected = false` и удаляет все ключи `Mods.{GameId}.{ModId}.*` при удалении |
| 4 | `ModsViewModel.cs` | Удаление мода при выбранном конкретном фильтре игры (не "All") оставляло мод видимым в списке до переключения на "All" и обратно | Отсутствовало уведомление об изменении `FilteredMods` после `_Mods.RemoveAt()` в цикле опроса удаления файлов; теперь срабатывает каждый раз, когда мод действительно удаляется |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Необработанное исключение при построении или отображении всплывающего окна предупреждения об отсутствии подписи могло привести к тихому сбою ModAPI без записи какой-либо ошибки | Построение/отображение всплывающего окна и форматирование сообщений обёрнуты в try-catch; в случае сбоя предупреждение регистрируется, и пользователю безопасно разрешается продолжить (отсутствие подписи носит информационный характер, а не является жёсткой блокировкой) |

#### Предупреждение о Цифровой Подписи — Уточнённое Сообщение

Текст `GameNoSignature` теперь называет конкретную игру и поясняет, что отсутствие подписи ожидаемо для инди-игр и не влияет на игровой процесс, вместо намёка на возможное изменение файлов. Обновлено во всех 13 языковых файлах с заполнителем `{0}` для отображаемого названия игры (например, "The Forest", "Green Hell").

#### Система Журналирования — Разделение на Два Файла

Диагностические журналы, ограниченные `#if DEBUG`, были преобразованы во флаг `detailedOnly` и разделены между `ModAPI.log` (ориентированным на пользователя) и `ModAPI.detailed.log` (всегда с полными подробностями) — полную расшифровку см. в разделе **Log** выше.

#### Изменённые Файлы (Дополнительные)

| Файл | Путь | Изменение |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Переработка проверки StartGame, исправление экземпляра игры в DeleteMod_Click, try-catch для GameIntegrityWarning, сопоставление отображаемых имён |
| `Game.cs` | `ModAPI_Shared\Data\` | Исправление единичного ответа в UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Уведомление об изменении `FilteredMods` при удалении, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 точек вызова) |
| `Mod.cs` | `ModAPI\Data\` | Дамп XML заголовка перенесён в `detailedOnly`, сводка расхождений контрольной суммы |
| `Debug.cs` | `ModAPI_Shared\` | Параметр `detailedOnly`, запись в два файла, комментарий-руководство по 4-уровневому журналированию |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Заполнитель `{0}` для названия игры, защита try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` переписан с заполнителем названия игры |

---


</details>

<details>
<summary><b>Изменения в v2.0.9619</b></summary>

### Исправления Ошибок

- **Зависание применения модов при пустой папке резервной копии**: `gamefiles\original\` пуста → автоматическое создание резервной копии из пути установки игры перед чтением сборки
- **Блокировка файла (IOException) на DLL игры**: резолвер сборок условно исключает папку игры при наличии резервной копии — предотвращает удержание Cecil блокировок файлов во время `DirectoryCopy`
- **Бесконечный цикл повторных попыток для повреждённых модов**: неудачные файлы `.mod` (повреждённый заголовок) вызывали цикл повторного сканирования каждую секунду — теперь регистрируются в `LoadedFiles` для предотвращения повторного сканирования
- **Отклонение файлов модов с окончаниями строк LF**: анализатор заголовка `EndsWith("</Mod>\r")` давал сбой для файлов `.mod` в стиле Unix — теперь использует `TrimEnd` для обработки как CRLF, так и LF
- **Сбой проверки маленьких DLL**: `Assembly-UnityScript-firstpass.dll` (21 КБ) отклонялся `FileValidator` — минимальный размер сборки снижен с 64 КБ до 8 КБ
- **Ненужные журналы WARNING**: ненастроенные пути игр и ключи конфигурации при первом запуске создавали шум — параметр `silent` добавлен в `GetPath`/`GetString`/`GetInt`

### Улучшения

- **Обнаружение загрузок размером 0 байт**: всплывающее предупреждение + очистка временных файлов, когда сервер возвращает пустой файл `.mod` (`Lang.Windows.DownloadEmpty`)
- **Debounce сохранения ползунка**: `ModListWidth` / `ProjectListWidth` сохраняется в `ui.cfg` только один раз (через 500 мс после окончания перетаскивания) вместо при каждом изменении пикселя
- **Условное создание папок игр**: папки `mods/` и `projects/` создаются только для игр с настроенными путями — не безусловно для всех 5
- **Диагностический журнал разбора заголовка**: показывает количество строк и предпросмотр содержимого при сбое разбора файла `.mod` для облегчения устранения неполадок

### Новые Языковые Ключи (13 языков)

| Ключ | Значение на английском |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Изменённые Файлы

| Файл | Путь | Изменение |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Автоматическое создание резервной копии, условный резолвер, резервный переход к папке игры |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Резервный переход к папке игры для IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 КБ → 8 КБ |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Параметр `silent` в GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Защита от загрузки 0 байт, debounce ползунка, тихое чтение конфигурации, условное создание папок |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Предотвращение повторных попыток для повреждённых модов |
| `Mod.cs` | `ModAPI\Data\` | Разбор заголовков LF/CRLF, диагностический журнал |
| 13× `Language.XX.xaml` | `resources\langs\` | Ключи всплывающего окна `DownloadEmpty` |

---

</details>

<details>
<summary><b>Изменения в v2.0.9618</b></summary>


### Добавлен MODAPI_VersionTool

Добавлен автономный инструмент WPF для обновления номера версии одним щелчком (`VersionTool\MODAPI_VersionTool.csproj`) — полные сведения см. в разделе **Version Tool** выше.

- `VersionLabel.Text` теперь ссылается на `App.Version` вместо жёстко закодированного `Version.Descriptor`, поэтому обновления немедленно отражаются в StatusBar после пересборки.

---

</details>

<details>
<summary><b>Изменения в v2.0.9617</b></summary>


### Вкладка Settings — Добавлены Кнопки Сброса Пути

Кнопка **Reset** добавлена к строке пути установки Steam и к каждой строке пути установки игры.

**Строка пути Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Строка пути игры (для каждой игры)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Поведение Reset**
- Немедленно очищает текстовое поле пути
- Сохраняет флаг сброса в `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Текстовое поле остаётся пустым после перезапуска
- Обходит проблему, при которой Configuration XML не сохраняет пустые строки

**Автоматическое сохранение Browse**
- Раньше: после Browse требовалось отдельное нажатие Save
- Теперь: автоматическое сохранение при выборе файла — отражается даже после переключения на вкладку Mods

**Новый языковой ключ**

| Ключ | Значение |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Изменения в v2.0.9616</b></summary>

### Versions.xml — Добавлены/Обновлены 4 Игры

| Игра | Путь файла | BuildID | Примечания |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Создан заново |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Обновлена контрольная сумма |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Создан заново |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Обновлена контрольная сумма |

### Правила Составления Контрольной Суммы

Формат контрольной суммы различается в зависимости от того, существует ли `Assembly-CSharp-firstpass.dll` для каждой игры.

| Игра | firstpass.dll | Формат контрольной суммы |
|---|---|---|
| GH | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| Subnautica | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| EscapeThePacific | ✅ Присутствует | `firstpass MD5` + `Assembly-CSharp MD5` объединены (64 символа) |
| Raft | ❌ Отсутствует | только `Assembly-CSharp MD5` (32 символа) |

### Процедура Обновления Versions.xml при Обновлении Игры

Добавьте новую запись `<version>`, не удаляя существующие записи.

**Шаг 1 — Найти новый BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Игра | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Шаг 2 — Извлечь новую контрольную сумму**
```powershell
# Игры с firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Объединить оба значения Hash по порядку (сначала firstpass)

# Игры без firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Шаг 3 — Добавить запись в Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Изменения в v2.0.9615</b></summary>

### Исправлено Раскрытие Пути Игры на Вкладке Settings

- **Высота раскрытия карточки**: нижняя часть окна теперь увеличивается точно на высоту поля ввода при раскрытии карточки пути игры
- **Улучшение `UpdateWindowHeight()`**: вызывает `UpdateLayout()` перед измерением `SizeToContent.Height`; временно устанавливает `TextureLayer1` в `Collapsed`, когда текстура фона активна, чтобы предотвратить влияние исходного размера изображения 4K на расчёт высоты
- **Исправление внутренней строки Grid**: последняя строка внутренней сетки Grid панели путей игр изменена с `Height="*"` на `Height="Auto"` — устраняет ненужное пустое пространство внизу

---

</details>

<details>
<summary><b>Изменения в v2.0.9614</b></summary>

### Исправлено Поведение Кнопки Развернуть

- **Развернуть**: использует `SystemParameters.WorkArea` для ручного разворачивания вместо `WindowState.Maximized` — точно подстраивается под текущее разрешение экрана без перекрытия панели задач
- **Восстановить**: сохраняет `Left`, `Top`, `Width`, `Height` и `MaxWidth` перед разворачиванием и восстанавливает их при нажатии кнопки восстановления
- **Обработка `MaxWidth`**: устанавливается в `∞` при разворачивании, восстанавливается к сохранённому значению при нормализации

---

</details>

<details>
<summary><b>Изменения в v2.0.9613</b></summary>

### Новая Вкладка Themes

Порядок вкладок теперь следующий:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Интерфейс выбора темы был перемещён из вкладки Settings в выделенную вкладку **Themes**.
Значок: Segoe MDL2 Assets `&#xE790;` (палитра)

### Реестр Тем (Структура на Основе Данных)

Добавление новой темы теперь требует всего **одной строки** в словаре `App.xaml.cs`.
Все операторы switch были удалены — изменения кода в других местах не требуются.

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

Элементы ComboBox `ThemeSelector` автоматически генерируются из цикла `ThemeIds`.
Соглашение о языковых ключах: `Lang.Options.Theme.{PascalCase}` (например, `Lang.Options.Theme.Nebula`)

### Поддерживаемые Темы

| Индекс | ID | Файл | Палитра |
|---|---|---|---|
| 0 | `classic` | только `Dictionary.xaml` | Оригинальный текстурный фон ModAPI |
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

### Функция Текстуры Фона

Выберите изображение в карточке **Background Texture** на вкладке Themes, чтобы применить его в качестве фона всего приложения. Работает с любой выбранной темой.

**Поддерживаемые форматы ввода**: `.png` / `.jpg` / `.jpeg`, до 50 МБ, разрешение 4K или ниже

**Конвейер Обработки Изображения**

```
Изображение, выбранное пользователем (.png / .jpg / .jpeg, макс. 50 МБ, 4K или ниже)
  ↓
Сжатие JPEG Q75 (буфер памяти)
  ↓
Вставлен 16-байтовый магический заголовок
  "MODAPI" + "BG" + версия + заполнение (FF 00 FE 00)
  ↓
Сохранено как resources\textures\ui_bg\bg.dat (атрибут Hidden)
  ↓
Хэш SHA-256 → сохранён в ui.cfg как TextureHash
```

**Уровни Безопасности**

| Уровень | Метод | Эффект |
|---|---|---|
| Магический заголовок | 16 байт добавлены перед сигнатурой JPEG (FF D8 FF) | Внешние программы просмотра не могут распознать файл |
| Атрибут Hidden | `FileAttributes.Hidden` | Скрыт из Проводника по умолчанию |
| Целостность SHA-256 | Хэш проверяется при загрузке | Изменение вызывает автоматический сброс + всплывающее предупреждение |

**Поведение Обнаружения Изменений**
1. `bg.dat` удалён
2. Ключи `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` сброшены
3. Текстовое поле и переключатель сброшены
4. Показано всплывающее окно `Lang.Windows.TextureTampered`

**Ключи ui.cfg**

| Ключ | Значение | Описание |
|---|---|---|
| `TexturePath` | Имя файла (только отображение) | Исходное имя файла, отображаемое в текстовом поле |
| `TextureHash` | Шестнадцатеричный SHA-256 | Хэш проверки целостности |
| `TextureActive` | `true` / `false` | Состояние активации |

**Обработка Прозрачности**

Когда фоновое изображение активно, фоны интерфейса обрабатываются в двух слоях.

- **Слой 1 — Наложение MergedDictionaries**: панели, ссылающиеся на `{DynamicResource FluentBgBrush}` и т.д., автоматически становятся прозрачными. Восстанавливаются одним вызовом `Remove()` при деактивации.

  Целевые ключи: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Слой 2 — Обход визуального дерева (`WalkStyleBackgrounds`)**: элементы `{StaticResource}` в темах Fluent не затрагиваются Слоем 1, поэтому визуальное дерево обходится напрямую для применения полупрозрачных кистей на основе исходных цветов.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=полностью прозрачный, 255=непрозрачный → 100 ≈ 39% непрозрачности
  ```

  Обрабатывается: `Panel` (кроме Grid), `Border`, `ListBox` / `ListView`

  Исключено: `Grid` (фон сохраняется, дочерние элементы обходятся), `TabPanel` (защита заголовка вкладки), `ButtonBase` / `ComboBox`, элементы `Collapsed`

  Восстановление: источник Setter стиля → `ClearValue()`, источник локального значения XAML → напрямую восстанавливает исходную кисть

**Переключение Вкладок**

Поскольку TabControl WPF отложенно загружает содержимое вкладок, `WalkStyleBackgrounds(this)` повторно выполняется с приоритетом `ContextIdle` при смене вкладки. Уже обработанные элементы пропускаются с помощью проверки `ContainsKey`.

**Блокировка ThemeSelector**

Когда текстура фона активна, над селектором тем отображается рамка `ThemeSelectorOverlay`, блокирующая взаимодействие.

- XAML: рамка `ThemeSelectorOverlay` добавлена поверх ThemeSelector (`IsHitTestVisible=True`)
- Активна: `ThemeSelectorOverlay.Visibility = Visible`
- Неактивна: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` также защищён флагом `_textureActive`

**Поток Состояния Интерфейса**

```
Изображение выбрано (Browse)
  → bg.dat создан → переключатель разблокирован → автоактивация → TextureLayer1 отображён
  → SaveAndClearBrushes() → ThemeSelectorOverlay отображён

Переключатель деактивирован
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay скрыт
  → TextureLayer1 скрыт

Кнопка Clear
  → bg.dat удалён → переключатель заблокирован → TextureLayer1 скрыт → кисти восстановлены
  → GC.Collect() (освобождает память изображения 4K)
```

**Новые Языковые Ключи**

| Ключ | Описание |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 новых названий тем |
| `Lang.Options.Labels.TextureBackground` | Метка текстуры фона |
| `Lang.Options.Labels.TextureEnable` | Метка активации |
| `Lang.Options.Labels.TextureClear` | Кнопка Clear |
| `Lang.Windows.TextureTooLarge` | Предупреждение о превышении размера файла |
| `Lang.Windows.TextureTampered` | Предупреждение об обнаруженном изменении |

**Структура Файлов**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Вкладка Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Логика темы и текстуры
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
            └── bg.dat             # Сжатое и защищённое фоновое изображение (генерируется во время выполнения)
```

**Известные Проектные Ограничения**

| Пункт | Детали |
|---|---|
| `IsEnabled=false` на ComboBox | Вызывает сбой `ElementNotEnabledException` → используется подход наложения `IsHitTestVisible` |
| Прямая замена ключей `MergedDictionaries` | Сбой во время прохода компоновки → только шаблон `Add`/`Remove` |
| Перезапись скрытого файла | `Access Denied` → перед записью необходимо сбросить `FileAttributes.Normal` |
| Фоны `{StaticResource}` | Не затрагиваются Слоем 1 → требуется WalkStyleBackgrounds (Слой 2) |

---

</details>

<details>
<summary><b>Изменения в v2.0.9612</b></summary>

### Разделение Модуля Тем

- **Новая папка `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` и `FluentStylesClassic.xaml` перемещены в `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — тема Classic использует только `Dictionary.xaml`; темы Light/Dark/другие Fluent загружают соответствующий XAML
- **`ModAPI.csproj`**: обновлены пути XAML тем на подкаталог `Themes\`; зарегистрирован `FluentStylesClassic.xaml`

---

</details>

<details>
<summary><b>Изменения в v2.0.9611</b></summary>

### Исправление Ошибки

- **Ширина Mod List не применяется после смены темы**: исправлена проблема, при которой ширина списка модов не применялась после переключения между темами Light/Dark и перезапуска — добавлен вызов `ApplyModListWidth(width)` внутри `InitModListWidth()`

---

</details>

<details>
<summary><b>Изменения в v2.0.9610</b></summary>

### Добавлено

#### XML Игр и Конфигурация Versions

| # | Файл | Изменение |
|---|------|--------|
| 1 | `GH.xml` | Полная переработка — удалён несуществующий `DOTweenPro.dll`; добавлены `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Полная переработка — удалён `extends="GenericUnityGame"`; добавлены `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Полная переработка — удалён `extends="GenericUnityGame"`; `includeAssembly` → только `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Создан — версия `1.1.01` с контрольной суммой |
| 5 | `GH/Versions.xml` | Создан — версия `2.9.5` с контрольной суммой |
| 6 | `Subnautica/Versions.xml` | Создан — без контрольной суммы (обновляется слишком часто) |

#### Критические Исправления Ошибок

| # | Тип | Проблема | Исправление |
|---|------|-------|-----|
| 1 | Зависание | `extends="GenericUnityGame"` вызывал наследование `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` зависал | Удалён `extends` из всех XML, кроме TheForest |
| 2 | Сбой | `ResolutionException: XGamingRuntime.XUserGamertagComponent` во время применения на Subnautica | Добавлены `XGamingRuntime.dll`, `XblPCSandbox.dll` в `copyAssembly` |
| 3 | Сбой | Резолвер давал сбой на DLL, добавленных в `copyAssembly` после создания резервной копии | `Game.cs`: реальная папка установки добавлена как резервный вариант резолвера |
| 4 | Сбой | `IOException`: блокировка файла `BaseModLib.dll` между `CreateModLibrary` и `ApplyMods` | Цикл повторных попыток: макс. 10 × 500 мс чтения + макс. 30 × 500 мс ожидания существования |
| 5 | Сбой | `NullReferenceException` — entry.Value из `typesMap` пуст (игра не установлена) | Добавлено `if (entry.Value == null) continue` |
| 6 | Сбой | `NullReferenceException` — в лёгком конструкторе `Game` отсутствовал `ModLibrary = new ModLib(this)` → сбой `CreateModLibrary()` | Добавлен `ModLibrary = new ModLib(this)` в лёгкий конструктор |
| 7 | Сбой | `SwitchDevGame()` — `App.Game.GamePath` пуст после лёгкого конструктора → сбой `CreateModLibrary` | Установлен `App.Game.GamePath = savedPath` после лёгкого конструктора |
| 8 | Неверная игра | Моды `EscapeThePacific` классифицированы как TheForest | `ModsViewModel`: `GameId` извлекается из пути папки |
| 9 | Неверный путь | `GetGameFolder()` → `""` → преобразуется в корень диска (например, `E:\`) | Защита от null/пустого значения во всех 6 точках вызова |

#### Разделение Сборок Debug / Release

- **`FileValidator.cs`** — новый файл `ModAPI_Shared\Utils\FileValidator.cs`; зарегистрирован в `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — заголовок PE (MZ + PE\0\0) + минимум 1 МБ
  - `IsValidGameExe()` — заголовок PE + минимум 512 КБ
  - `IsValidAssemblyDll()` — заголовок PE + заголовок метаданных .NET CLR + минимум 64 КБ
- **`CheckSteam()`** — `#if DEBUG`: только `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: только `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` без Cecil / `#else`: полный анализ Cecil + модификация IL
- **`ModLib.Create()` файл не найден** — `#if DEBUG`: записывает предупреждение, пропускает / `#else`: записывает ошибку, прерывает

#### Debug-Тесты

- **`create_dummy_Debug_games.ps1`** — скрипт PowerShell для `bin\Debug\`; создаёт файлы-заглушки размером 0 байт для всех 5 игр в `dummy_games\`, `dummy_steam\` и `gamefiles\original\` — позволяет тестировать весь рабочий процесс интерфейса без реальной установки игры

#### Вкладка Settings

- **Карточка пути Steam** — интегрирована в карточку Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Панель путей игр** — `BuildGamePathsPanel()` с раскрывающимися карточками для каждой игры; текстовое поле использует `HorizontalAlignment=Stretch`
- Кнопка **Expand All / Collapse All**
- Флажок **AlwaysOnTop** (сохраняется в `ui.cfg`)
- Ползунки **Mod/Project List Width** — начинаются с минимума `150`; сохраняются в `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Синхронизация флажков** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions теперь корректно синхронизируются
- **Флаг `_uiInitialized`** — предотвращает преждевременные записи `ui.cfg` во время запуска WPF

#### Вкладка Mods — Проверка Запуска Игры

Пятиэтапная проверка выполняется при каждом нажатии Start Game, независимо от состояния списка модов:

| Этап | Проверка | Всплывающее окно |
|---|---|---|
| 1 | Путь Steam на вкладке Settings корректен (`Steam.exe` существует) | SteamNotFound |
| 2 | Игра в папке `mods/{GameId}/` соответствует игре, настроенной в Settings | GameModsMismatch |
| 3 | Выбран хотя бы один мод | NoModSelected |
| 4 | В выборе нет смешанных модов разных игр | MixedGameMods |
| 5 | Путь игры настроен + исполняемый файл существует | GamePathNotSet / GameNotInstalled |

#### Вкладка Development — Проверка ModLib

Трёхэтапная проверка при нажатии Mod Library Regeneration:

| Этап | Проверка | Всплывающее окно |
|---|---|---|
| 1 | Путь Steam на вкладке Settings корректен | SteamNotFound |
| 2 | Существует хотя бы один проект | NoProjectWarning |
| 3 | `App.Game.GamePath` установлен | GamePathNotSet |

#### Вкладка Downloads
- Строка отладки заменена на `Lang.Downloads.Status.NoDownloads`
- Единообразные отступы для всех сообщений о статусе
- Обновлён текст для офлайн-режима для всех 5 поддерживаемых игр; перенос строки через два TextBlock

#### First Setup и Система Пути Игры
- `FirstSetup.Check()` — значение по умолчанию `true` для `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — создаёт папки `mods/` и `projects/` для всех 5 игр
- `SpecifyGamePath` — `GameNameLabel` показывает, о какой игре идёт речь; `NavigateToSettings()` перенаправляет на вкладку Settings

#### Новые/Обновлённые Языковые Ключи

| Ключ | Значение на английском |
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

### Не Включено

| Функция | Причина |
|---|---|
| Автообновление (сохранение последней версии) | Серверная инфраструктура недоступна |
| Поиск обновлений | Серверная инфраструктура недоступна |

### Удалено

| Пункт | Причина |
|---|---|
| Всплывающее окно `SpecifyGamePath` при запуске | Все пути настраиваются на вкладке Settings |
| Всплывающее окно `SpecifySteamPath` при запуске | Путь Steam настраивается на вкладке Settings |
| Система входа | Исходный сервер больше не работает (удалено в v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Не работает на Mono 2.0 (удалено в v2.0.9586) |
| Условие `UseSteam` в проверке Steam | Steam теперь всегда проверяется первым при Start Game и Mod Library Regeneration |

## Запланировано на Будущие Версии

| # | Функция | Описание |
|---|---|---|
| 1 | Автообновление ModAPI | Автоматическая загрузка и применение новых версий ModAPI |
| 2 | Обновление таблицы VersionsData ModAPI | Автоматическое обновление таблицы VersionsData игры при выходе новых патчей игры |

---

</details>

<details>
<summary><b>Изменения в v2.0.9600</b></summary>

### Добавлено

- **Вкладка Downloads**: 5 фильтров игр (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Вкладка Welcome**: добавлена в крайне левой позиции (индекс 0)
- **Вкладка Mods**: трёхколоночный макет (WrapPanel → вертикальный список); автоматическая регулировка ширины; перенос названий модов
- **`ModsViewModel`**: фильтрация по конкретной игре, `ResolveGame()` для корректного экземпляра `Game` для каждого мода
- **`Game.cs`**: лёгкий конструктор `new Game(config, true)` — только идентификация, без `Verify()`
- **Сборка**: 4 XML-файла игр зарегистрированы в `ModAPI.csproj` с `CopyToOutputDirectory=Always`
- **Сборка**: очищены предупреждения — CS0168, CS0618, CS0252
- **XML игр**: исправлены списки DLL для TheForest, Raft, GH
- **Языковые флаги**: размеры изображений унифицированы на всех 13 языковых значках

### Удалено

| Пункт | Причина |
|---|---|
| `extends="GenericUnityGame"` в XML-файлах игр | Вызывал неверное наследование `Assembly-CSharp-firstpass.dll` — удалён из Subnautica, Raft, EscapeThePacific, GH |
| Макет `WrapPanel` на вкладке Mods | Заменён трёхколоночным макетом Grid (Game Filter / Mod List / Information) |

---

</details>

---

## История Версий

<details>
<summary><b>Фаза 6-3 — Расширение Системы Тем, Улучшения Настроек, Стабильность и Инструменты</b></summary>

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool и основные исправления**
- Добавлен MODAPI_LangTool (автономный инструмент WPF для управления языками)
- Исправление SSL/TLS (TLS 1.2)
- Исправление французской локали (`CultureInfo.InvariantCulture`)
- Исправление `GamePathNotSet` для Green Hell
- SelectGameDialog (фильтр All + запуск с модами нескольких игр)
- Удалена блокировка через MixedGameMods
- Трёхуровневая проверка целостности игры (заголовок PE / контрольная сумма сборки / цифровая подпись)
- Разделение журналов разработчика и пользователя
- 12 журналов UpdateVersions + 7 журналов FindMods + 10 журналов StartGame
- URL Raw GitHub в качестве основного `VersionUpdateDomains`
- Исправлена контрольная сумма `Versions.xml` для GH
- Добавлено `1.12` в `Versions.xml` TheForest
- 515 ключей во всех 13 языковых файлах

**Дополнительные исправления (2026-06-21)**
- Исправлен порядок проверки StartGame (Steam → путь игры → моды)
- Всплывающее окно выбора игры теперь корректно перечисляет игры с ненастроенным путём
- Исправление единичного ответа в UpdateVersions (больше нет дублирующихся контрольных сумм)
- `DeleteMod` теперь разрешает собственный экземпляр игры мода вместо активного фильтра
- Удалённые моды больше не оставляют устаревший значок "Selected" при повторной загрузке
- Список модов теперь немедленно обновляется при удалении, независимо от фильтра игры
- Всплывающее окно `GameIntegrityWarning` укреплено против сбоев из-за необработанных исключений
- Сообщение предупреждения о цифровой подписи теперь называет игру и поясняет, что это ожидаемо для инди-игр
- Система двухфайлового журналирования (`ModAPI.log` / `ModAPI.detailed.log`) заменяет журналы, ограниченные `#if DEBUG`, так что Release-сборки по-прежнему могут фиксировать полные диагностические подробности, не засоряя журнал, ориентированный на пользователя

### v2.0.9619 — 2026-05-25

- Автоматическое создание резервной копии из пути установки игры
- Исправлена блокировка файла (условный резолвер)
- Предотвращение бесконечного цикла для повреждённых модов
- Совместимость с модами с окончаниями строк LF
- Обнаружение загрузок размером 0 байт с всплывающим окном
- Debounce сохранения ползунка (500 мс)
- Условное создание папок игр
- Минимальный размер сборки в `FileValidator` снижен с 64 КБ до 8 КБ
- Параметр `silent` в `GetPath`/`GetString`/`GetInt`
- Диагностический журнал разбора заголовка
- Языковые ключи `DownloadEmpty` (13 языков)

### v2.0.9618 — 2026-04-25
Добавлен MODAPI_VersionTool (автономный инструмент WPF для обновления версии), отображение версии в StatusBar связано с App.Version

### v2.0.9617 — 2026-04-24
Добавлены кнопки сброса пути Steam/игры на вкладке Settings, автоматическое сохранение Browse, состояние сброса сохраняется через флаг ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml создан/обновлён для 4 игр (Subnautica, Raft, EscapeThePacific, GH), установлены правила составления контрольной суммы, документирована процедура обновления игры

### v2.0.9615 — 2026-04-18
Исправлена точность высоты раскрытия карточки пути игры на вкладке Settings, предотвращено вмешательство UpdateWindowHeight текстурой фона

### v2.0.9614 — 2026-04-18
Ручное разворачивание кнопки Развернуть на основе WorkArea, сохранение и восстановление предыдущего размера/позиции

### v2.0.9613 — 2026-04-18
Добавлена вкладка Themes, структура реестра тем на основе данных, поддержка 10 тем, функция текстуры фона (сжатие, безопасность, 2-слойная прозрачность), наложение блокировки ThemeSelector, 12 новых языковых ключей

### v2.0.9612 — 2026-04-18
Разделение папки Themes/, модуляризация XAML тем

### v2.0.9611 — 2026-04-18
Исправлено: ширина Mod List не применяется после смены темы

</details>

<details>
<summary><b>Фаза 6-2 — Настройки, Безопасность, Исправления Сбоев и Разделение Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- Исправлен XML для нескольких игр (GH, Subnautica, EscapeThePacific)
- Добавлен `Versions.xml`
- Переработана вкладка Settings (путь Steam, панель путей игр, ползунки ширины, размер шрифта, синхронизация флажков)
- Null-безопасность пути игры (6 мест)
- Стартовые всплывающие окна заменены вкладкой Settings
- Пятиэтапная проверка запуска игры на вкладке Mods (Steam всегда первый)
- Трёхэтапная проверка ModLib на вкладке Dev
- Добавлено всплывающее окно `GameModsMismatch`
- Исправлена null-ошибка `ModLibrary` в лёгком конструкторе
- Исправлен `GamePath` в `SwitchDevGame`
- Проверка заголовка PE `FileValidator` (Release)
- Разделение сборки `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- Постоянный `ui.cfg`
- 5-ключевая система шрифтов
- Множественные исправления сбоев
- Обновлены языковые ключи

</details>

<details>
<summary><b>Фаза 6-1 — Несколько Игр и Переработка Модов</b></summary>

### v2.0.9600 — 2026-04-09
> 5 фильтров игр, трёхколоночный макет вкладки Mods, автоматическая ширина, лёгкий конструктор `Game`, фильтрация игр в `ModsViewModel`, 4 зарегистрированных XML-файла, очищены предупреждения сборки, вкладка Welcome, унифицированы языковые флаги

</details>

<details>
<summary><b>Фаза 5-6B — C# 7.3 и Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Исправлен чёрный экран, финализирован polyfill, удалён ValueTuple, проверен C# 7.3

</details>

<details>
<summary><b>Фаза 5-5 — Разрешение Сборок</b></summary>

### v2.0.9561 — 2026-03-06
> Поддержка C# 7.3, патчинг заголовка PE, конвейер polyfill, восстановлено разрешение сборок

</details>

<details>
<summary><b>Фаза 5-1 — Вкладка Downloads и 13 Языков</b></summary>

### v2.0.9552 — 2026-02-25
> Вкладка Downloads, модернизация значков, унификация тем, поддержка 13 языков

</details>

<details>
<summary><b>Более Ранние Фазы</b></summary>

### Фаза 3 — Переработка Интерфейса и Система Тем
v2.0.9500
> Система тем (Classic/Light/Dark), интерфейс Fluent Design, система SubWindow

### Фаза 4 — Очистка Кода
v2.0.9400
> Очистка кода, удаление входа в систему, модернизация устаревшего кода

### Фаза 2 — Среда Сборки и Fluent Design
v2.0.9300
> Среда сборки, DLL-заглушка UnityEngine, интеграция ModernWpf

### Фаза 1 — Миграция на .NET 4.8
v2.0.9200
> Миграция на .NET Framework 4.8

### v1.x
Оригинальный релиз FluffyFish

</details>

---

## Требования к Сборке

| Требование | Версия | Примечания |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Проекты ModAPI |
| .NET Framework SDK | 3.5 | Только BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` в `libs/polyfills/` |

---

## Лицензия

GNU General Public License v3.0 — соответствует оригинальной лицензии.
