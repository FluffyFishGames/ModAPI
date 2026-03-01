[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Инструмент Управления Модами The Forest — Улучшенное Издание**

> Оригинал: FluffyFish / Philipp Mohrenstecher (Энгельскирхен, Германия)
> Улучшение: zzangae (Республика Корея)

---

## Обзор

ModAPI — это настольное приложение для управления модами игры The Forest. Это улучшенное издание включает миграцию на .NET Framework 4.8, интерфейс Windows 11 Fluent Design, систему из 3 тем, расширенную многоязычную поддержку и полную реализацию вкладки «Загрузки».

---

## Ключевые Изменения

### Фаза 1 — Обновление до .NET Framework 4.8

- Миграция всех проектов (5) с `.NET Framework 4.5` → `4.8`
- Обновление `TargetFrameworkVersion`, `App.config`, `packages.config` во всех проектах
- Унификация версии сборки

### Фаза 2 — Среда сборки и Основа Fluent Design

- Внедрение пакета NuGet **ModernWpf 0.9.6**
- Создание **FluentStyles.xaml** — слой переопределений Windows 11 Fluent Design
  - Цветовая палитра Fluent, типографика, кнопки, вкладки, выпадающие списки, стили полос прокрутки
  - Шаблоны Window, SubWindow, SplashScreen
- Компиляция **заглушки DLL UnityEngine**
  - Добавлены отсутствующие типы: `WWW`, `Event`, `TextEditor`, `Physics` и др.
- Исправлены ссылки зависимостей, подтверждена успешная сборка

### Фаза 3 — Редизайн UI и Система Тем

#### Редизайн Fluent UI
- Полная реструктуризация **MainWindow.xaml**
  - Макет, цвета и типографика на основе Fluent Design
  - Переработаны элементы управления вкладками, строка состояния, кнопки заголовка
- Исправления времени выполнения: зависание SplashScreen, переключение вкладок, состояния значков, перетаскивание окна

#### Система из 3 Тем

| Тема | Файл стиля | Описание |
|------|-----------|----------|
| Классическая | Только Dictionary.xaml | Оригинальный дизайн ModAPI (текстурный фон) |
| Светлая | FluentStylesLight.xaml | Светлый тон + синий акцент |
| Тёмная | FluentStyles.xaml | Тёмный тон + синий акцент (по умолчанию) |

- Добавлен **ComboBox выбора темы** во вкладке Настройки
- Смена темы запускает **диалог подтверждения** → **автоматический перезапуск**
- Настройка темы сохраняется/загружается через файл `theme.cfg`

#### Перетаскивание Окна / SubWindows / Гиперссылки
- Событие `MouseLeftButtonDown` корневого Grid для прямого перетаскивания
- Диалоги ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Цвета ссылок для каждой темы: Тёмная/Классическая (`#FFD700`), Светлая (`#0078D4`)

### Фаза 4 — Очистка Кода и Удаление Устаревших Компонентов

- Удалена система входа (сервер прекратил работу)
- Модернизирован механизм обновления
- Очищен неиспользуемый код
- Исправлен UI SubWindow (диалоги пути к игре и др.)

### Фаза 5 — Расширение Многоязычной Поддержки (13 Языков)

| Язык | Файл | Язык | Файл |
|------|------|------|------|
| Корейский | Language.KR.xaml | Итальянский | Language.IT.xaml |
| Английский | Language.EN.xaml | Японский | Language.JA.xaml |
| Немецкий | Language.DE.xaml | Португальский | Language.PT.xaml |
| Испанский | Language.ES.xaml | Вьетнамский | Language.VI.xaml |
| Французский | Language.FR.xaml | Китайский (Упрощённый) | Language.ZH.xaml |
| Польский | Language.PL.xaml | Китайский (Традиционный) | Language.ZH-TW.xaml |
| Русский | Language.RU.xaml | | |

### Фаза 5-1 — Вкладка Загрузки и Завершение Тем

#### Вкладка Загрузки
- Загрузка списка модов из 3 источников (`mods.json`, `versions.xml`, HTML-парсинг)
- Функция поиска (фильтрация по имени/описанию/автору мода)
- **Фильтр игры** (Все / The Forest / Выделенный Сервер / VR)
- **Фильтр категории** (Все / Исправления ошибок / Баланс / Читы и др. — 12 категорий)
- UI с разделённой панелью для выбора версии
- Прямая загрузка файлов `.mod` → установка в папку игры
- Сортировка столбцов (клик по имени/категории/автору) и изменение размера
- Удаление модов (очистка DLL + промежуточных файлов)

#### Модернизация Значков (Все Темы)
- Все PNG-значки кнопок → шрифтовые значки **Segoe MDL2 Assets**
- Применено в MainWindow.xaml + 14 файлах SubWindow
- Шрифтовые значки наследуют цвет переднего плана, обеспечивая видимость во всех темах

| Оригинальный PNG | Шрифтовой Значок | Использование |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Добавить / Запустить Игру |
| Icon_Delete | &#xE74D; | Удалить |
| Icon_Refresh | &#xE72C; | Обновить |
| Icon_Download | &#xE896; | Скачать |
| Icon_Continue/Accept | &#xE8FB; | Подтвердить/Продолжить |
| Icon_Decline | &#xE711; | Отменить/Закрыть |
| Icon_Information | &#xE946; | Информация |
| Icon_Warning | &#xE7BA; | Предупреждение |
| Icon_Error | &#xEA39; | Ошибка |
| Icon_Browse | &#xED25; | Обзор |
| Icon_CreateMod | &#xE713; | Создать Мод |

#### Унифицированные Элементы Управления во Всех Темах

| Элемент управления | Классическая | Тёмная | Светлая |
|--------------------|-------------|--------|---------|
| Флажок | Переключатель (Золотой) | Переключатель (AccentBrush) | Переключатель (AccentBrush) |
| Переключатель | Круг (Золотой) | Круг (AccentBrush) | Круг (AccentBrush) |
| ComboBox | Scale9 оригинал | Fluent пользовательский | Fluent пользовательский |

#### Исправления Видимости Тем
- Светлая: текст AccentButton принудительно Белый, настройка Opacity значков вкладок
- Тёмная/Светлая: подход `TextElement.Foreground` ComboBoxItem для видимости выбранного текста
- Классическая: резервные ресурсы Fluent добавлены в Dictionary.xaml

---

## Структура Файлов

```
ModAPI/
├── App.xaml / App.xaml.cs          # Загрузка/сохранение/применение темы
├── Dictionary.xaml                  # Оригинальные стили + ресурсы переключатель/радио/резервные
├── FluentStyles.xaml                # Тёмная тема + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Светлая тема + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # Основной UI + вкладка загрузок + выбор темы
│   └── SubWindows/                  # 16 SubWindows (все со шрифтовыми значками)
├── resources/
│   ├── langs/                       # 13 языковых файлов
│   └── textures/Icons/flags/        # Значки флагов (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # Заглушка DLL
```

---

## Требования к Сборке

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Лицензия

GNU General Public License v3.0 — следует оригинальной лицензии.
