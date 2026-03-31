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

**Narzędzie do Zarządzania Modami The Forest — Edycja Ulepszona**

> Oryginał: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Niemcy)
> Ulepszenie: zzangae (Republika Korei)

---

## Przegląd

ModAPI to aplikacja desktopowa do zarządzania modami do The Forest. Ta ulepszona edycja zawiera migrację na .NET Framework 4.8, interfejs Windows 11 Fluent Design, system 3 motywów, rozszerzone wsparcie wielojęzyczne, pełną implementację karty Pobieranie oraz wsparcie dla tworzenia modów w C# 7.3.

---

## Co zmieniło się w v2.0.9586

| # | Kategoria | Problem | Rozwiązanie |
|---|---|---|---|
| 1 | **Krytyczne** | Czarny ekran w menu głównym po zastosowaniu modów | Naprawione — pipeline przemapowania assembly poprawnie łata nagłówki PE i tabele referencji |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` dołączony, ale niedziałający | Całkowicie usunięty — `mscorlib` Mono 2.0 generuje IL z bezpośrednią referencją do `ValueTuple`; żaden polyfill nie może tego zastąpić |
| 3 | **Polyfill** | Błędna nazwa pliku: `System.Threading.Tasks.dll` | Poprawiono na `System.Threading.dll` — rzeczywista nazwa pliku z NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Bug ścieżki kopiowania w `Game.cs`: pliki kopiowane do `Managed\polyfills\` | Naprawione przez `Path.GetFileName()` dla płaskiego kopiowania do `Managed\` |
| 5 | **Build** | Target PostBuild bez auto-kopiowania polyfilli | `BaseModLib.csproj` PostBuild teraz automatycznie kopiuje `AsyncBridge.dll` i `System.Threading.dll` |
| 6 | **C# 7.3** | Próba wsparcia krotki (`ValueTuple`) zakończona niepowodzeniem | Definitywnie usunięte — krotki to architektoniczne ograniczenie na Mono 2.0 |
| 7 | **C# 7.3** | Weryfikacja w grze pozostałych funkcji C# 7.3 | Potwierdzone: dopasowywanie wzorców, interpolacja ciągów, zmienna `out` inline |

### Finalna Macierz Funkcji C# 7.3

| Funkcja | Status | Uwagi |
|---|---|---|
| Dopasowywanie wzorców (`is`, `switch`) | ✅ Potwierdzone | Przetestowane w grze via `TEST_MOD.log` |
| Interpolacja ciągów (`$""`) | ✅ Potwierdzone | Przetestowane w grze via `TEST_MOD.log` |
| Zmienna `out` inline | ✅ Potwierdzone | Przetestowane w grze via `TEST_MOD.log` |
| Składowe z ciałem wyrażenia (`=>`) | ✅ | Obsługiwane przez kompilator |
| Funkcje lokalne | ✅ | Obsługiwane przez kompilator |
| `nameof` | ✅ | Obsługiwane przez kompilator |
| Operator warunkowy null (`?.`, `??`) | ✅ | Obsługiwane przez kompilator |
| `async`/`await` | ✅ | Przez polyfille AsyncBridge + System.Threading |
| Krotki (`ValueTuple`) | ❌ Twarde ograniczenie | ABI mscorlib Mono 2.0 — bez obejścia |

### Finalna Konfiguracja Polyfilli

| DLL | Pakiet NuGet | Cel | Przeznaczenie |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` dla .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Zależność AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Usunięto~~ | ~~Usunięto~~ | ~~Niedziałające na Mono 2.0~~ |

---

## Architektura Środowiska Wykonawczego

| Komponent | Cel | Środowisko | Powód |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplikacja desktopowa |
| `BaseModLib.dll` | .NET Framework 3.5 | Gra Mono 2.0 | **Na stałe zablokowane** |
| DLL modów | .NET Framework 4.8 | Gra Mono 2.0 (z łatką) | Nagłówek PE łatany przy Apply |

```
Build v3.5  →  Nagłówek PE: CLR Runtime v2.0.50727  ←  Mono 2.0 akceptuje  ✅
Build v4.8  →  Nagłówek PE: CLR Runtime v4.0.30319  ←  Mono 2.0 odmawia    ❌
```

---

## Historia Wersji

| Wersja | Data | Podsumowanie |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Czarny ekran naprawiony, pipeline polyfill sfinalizowany, ValueTuple usunięty, bugi naprawione, C# 7.3 zweryfikowany |
| v2.0.9561 | 2026-03-06 | Wsparcie modów C# 7.3, łatanie nagłówka PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Karta pobierania, ikony, 13 języków |
| v2.0.9500 | — | System motywów, Fluent Design UI |
| v2.0.9400 | — | Czyszczenie kodu |
| v2.0.9300 | — | Środowisko build, DLL stub UnityEngine |
| v2.0.9200 | — | Migracja .NET Framework 4.8 |
| v1.x | — | Oryginalne wydanie FluffyFish |

---

## Wymagania Build

| Wymaganie | Wersja | Uwagi |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Dla projektów ModAPI |
| .NET Framework SDK | 3.5 | Tylko dla BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — w `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` w `libs/polyfills/` |

---

## Licencja

GNU General Public License v3.0 — zgodnie z oryginalną licencją.
