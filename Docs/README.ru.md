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

# ModAPI(v1) v2.0.9586 - 20260331

**Инструмент Управления Модами The Forest — Улучшенное Издание**

> Оригинал: FluffyFish / Philipp Mohrenstecher (Энгельскирхен, Германия)
> Улучшение: zzangae (Республика Корея)

---

## Обзор

ModAPI — настольное приложение для управления модами игры The Forest. Это улучшенное издание включает миграцию на .NET Framework 4.8, интерфейс Windows 11 Fluent Design, систему из 3 тем, расширенную многоязычную поддержку, полную реализацию вкладки «Загрузки» и поддержку разработки модов на C# 7.3.

---

## Что изменилось в v2.0.9586

| # | Категория | Проблема | Решение |
|---|---|---|---|
| 1 | **Критично** | Чёрный экран в главном меню после применения модов | Исправлено — pipeline ремаппинга сборок корректно патчит PE-заголовки и таблицы ссылок |
| 2 | **Полифилл** | `Portable.System.ValueTuple.dll` включён, но не работает | Полностью удалён — `mscorlib` Mono 2.0 генерирует IL с прямой ссылкой на `ValueTuple`; ни один полифилл не может это заменить |
| 3 | **Полифилл** | Неверное имя файла: `System.Threading.Tasks.dll` | Исправлено на `System.Threading.dll` — реальное имя из NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Полифилл** | Баг пути копирования в `Game.cs`: файлы копируются в `Managed\polyfills\` | Исправлено с помощью `Path.GetFileName()` для плоского копирования в `Managed\` |
| 5 | **Сборка** | Target PostBuild без автокопирования полифиллов | `BaseModLib.csproj` PostBuild теперь автоматически копирует `AsyncBridge.dll` и `System.Threading.dll` |
| 6 | **C# 7.3** | Попытка поддержки кортежей (`ValueTuple`) провалилась | Окончательно удалено — кортежи являются архитектурным ограничением на Mono 2.0 |
| 7 | **C# 7.3** | Проверка оставшихся функций C# 7.3 в игре | Подтверждено: сопоставление с образцом, интерполяция строк, переменная `out` inline |

### Итоговая Матрица Функций C# 7.3

| Функция | Статус | Примечания |
|---|---|---|
| Сопоставление с образцом (`is`, `switch`) | ✅ Подтверждено | Протестировано в игре via `TEST_MOD.log` |
| Интерполяция строк (`$""`) | ✅ Подтверждено | Протестировано в игре via `TEST_MOD.log` |
| Переменная `out` inline | ✅ Подтверждено | Протестировано в игре via `TEST_MOD.log` |
| Члены с телом выражения (`=>`) | ✅ | Обрабатывается компилятором |
| Локальные функции | ✅ | Обрабатывается компилятором |
| `nameof` | ✅ | Обрабатывается компилятором |
| Null-условный оператор (`?.`, `??`) | ✅ | Обрабатывается компилятором |
| `async`/`await` | ✅ | Через полифиллы AsyncBridge + System.Threading |
| Кортежи (`ValueTuple`) | ❌ Жёсткое ограничение | ABI mscorlib Mono 2.0 — нет обходного пути |

### Итоговая Конфигурация Полифиллов

| DLL | Пакет NuGet | Назначение | Цель |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` для .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Зависимость AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Удалено~~ | ~~Удалено~~ | ~~Не работает на Mono 2.0~~ |

---

## Архитектура Среды Выполнения

| Компонент | Цель | Среда | Причина |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Настольное приложение |
| `BaseModLib.dll` | .NET Framework 3.5 | Игра Mono 2.0 | **Зафиксировано навсегда** |
| DLL модов | .NET Framework 4.8 | Игра Mono 2.0 (патч) | PE-заголовок патчится при Apply |

```
Build v3.5  →  Заголовок PE: CLR Runtime v2.0.50727  ←  Mono 2.0 принимает  ✅
Build v4.8  →  Заголовок PE: CLR Runtime v4.0.30319  ←  Mono 2.0 отказывает ❌
```

---

## История Версий

| Версия | Дата | Сводка |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Чёрный экран исправлен, pipeline полифиллов завершён, ValueTuple удалён, баги исправлены, C# 7.3 проверен |
| v2.0.9561 | 2026-03-06 | Поддержка модов C# 7.3, патч PE-заголовка, pipeline полифиллов |
| v2.0.9552 | 2026-02-25 | Вкладка загрузок, значки, 13 языков |
| v2.0.9500 | — | Система тем, Fluent Design UI |
| v2.0.9400 | — | Очистка кода |
| v2.0.9300 | — | Среда сборки, заглушка DLL UnityEngine |
| v2.0.9200 | — | Миграция .NET Framework 4.8 |
| v1.x | — | Оригинальный релиз FluffyFish |

---

## Требования к Сборке

| Требование | Версия | Примечания |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Для проектов ModAPI |
| .NET Framework SDK | 3.5 | Только для BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — в `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` в `libs/polyfills/` |

---

## Лицензия

GNU General Public License v3.0 — следует оригинальной лицензии.
