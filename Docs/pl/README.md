[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Narzędzie do Zarządzania Modami The Forest — Edycja Ulepszona**

> Oryginał: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Niemcy)
> Ulepszenie: zzangae (Republika Korei)

---

## Przegląd

ModAPI to aplikacja desktopowa do zarządzania modami do The Forest. Ta ulepszona edycja zawiera migrację na .NET Framework 4.8, interfejs Windows 11 Fluent Design, system 3 motywów, rozszerzone wsparcie wielojęzyczne oraz pełną implementację karty Pobieranie.

---

## Kluczowe Zmiany

### Faza 1 — Aktualizacja .NET Framework 4.8

- Migracja wszystkich projektów (5) z `.NET Framework 4.5` → `4.8`
- Aktualizacja `TargetFrameworkVersion`, `App.config`, `packages.config` we wszystkich projektach
- Ujednolicona wersja assembly

### Faza 2 — Środowisko Build i Podstawy Fluent Design

- Wprowadzenie pakietu NuGet **ModernWpf 0.9.6**
- Utworzenie **FluentStyles.xaml** — warstwa nadpisań Windows 11 Fluent Design
  - Paleta kolorów Fluent, typografia, przyciski, karty, combobox, style pasków przewijania
  - Szablony Window, SubWindow, SplashScreen
- Kompilacja **DLL stub UnityEngine**
  - Dodano brakujące typy: `WWW`, `Event`, `TextEditor`, `Physics` itp.
- Poprawiono referencje zależności i potwierdzono pomyślny build

### Faza 3 — Przeprojektowanie UI i System Motywów

#### Przeprojektowanie Fluent UI
- Kompletna restrukturyzacja **MainWindow.xaml**
  - Układ, kolory i typografia oparte na Fluent Design
  - Przeprojektowane kontrolki kart, pasek stanu, przyciski paska tytułu
- Poprawki uruchomieniowe: zamrożenie SplashScreen, przełączanie kart, stany ikon, przeciąganie okna

#### System 3 Motywów

| Motyw | Plik Stylu | Opis |
|-------|-----------|------|
| Klasyczny | Tylko Dictionary.xaml | Oryginalny design ModAPI (tło teksturowe) |
| Jasny | FluentStylesLight.xaml | Jasny ton + niebieski akcent |
| Ciemny | FluentStyles.xaml | Ciemny ton + niebieski akcent (domyślny) |

- Dodano **ComboBox wyboru motywu** w karcie Ustawienia
- Zmiana motywu uruchamia **okno potwierdzenia** → **automatyczny restart**
- Ustawienie motywu zapisywane/wczytywane przez plik `theme.cfg`

#### Przeciąganie Okna / SubWindows / Hiperłącza
- Zdarzenie `MouseLeftButtonDown` na Root Grid do bezpośredniej obsługi przeciągania
- Okna dialogowe ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Kolory linków specyficzne dla motywu: Ciemny/Klasyczny (`#FFD700`), Jasny (`#0078D4`)

### Faza 4 — Czyszczenie Kodu i Usuwanie Starych Elementów

- Usunięto system logowania (serwer niedziałający)
- Zmodernizowano mechanizm aktualizacji
- Wyczyszczono nieużywany kod
- Poprawiono UI SubWindow (okna dialogowe ścieżki gry itp.)

### Faza 5 — Rozszerzenie Wsparcia Wielojęzycznego (13 Języków)

| Język | Plik | Język | Plik |
|-------|------|-------|------|
| Koreański | Language.KR.xaml | Włoski | Language.IT.xaml |
| Angielski | Language.EN.xaml | Japoński | Language.JA.xaml |
| Niemiecki | Language.DE.xaml | Portugalski | Language.PT.xaml |
| Hiszpański | Language.ES.xaml | Wietnamski | Language.VI.xaml |
| Francuski | Language.FR.xaml | Chiński (Uproszczony) | Language.ZH.xaml |
| Polski | Language.PL.xaml | Chiński (Tradycyjny) | Language.ZH-TW.xaml |
| Rosyjski | Language.RU.xaml | | |

### Faza 5-1 — Karta Pobierania i Uzupełnienie Motywów

#### Karta Pobierania
- Ładowanie listy modów z 3 źródeł (`mods.json`, `versions.xml`, parsowanie HTML)
- Funkcja wyszukiwania (filtrowanie po nazwie/opisie/autorze moda)
- **Filtr gry** (Wszystkie / The Forest / Serwer Dedykowany / VR)
- **Filtr kategorii** (Wszystkie / Poprawki błędów / Balansowanie / Cheaty itp. — 12 kategorii)
- UI panelu podzielonego do wyboru wersji
- Bezpośrednie pobieranie plików `.mod` → instalacja w folderze gry
- Sortowanie kolumn (kliknięcie na nazwę/kategorię/autora) i zmiana rozmiaru
- Usuwanie modów (czyszczenie DLL + plików tymczasowych)

#### Modernizacja Ikon (Wszystkie Motywy)
- Wszystkie ikony PNG przycisków → ikony czcionki **Segoe MDL2 Assets**
- Zastosowane w MainWindow.xaml + 14 plikach SubWindow
- Ikony czcionki dziedziczą kolor pierwszego planu, zapewniając widoczność we wszystkich motywach

| Oryginalne PNG | Ikona Czcionki | Użycie |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Dodaj / Uruchom Grę |
| Icon_Delete | &#xE74D; | Usuń |
| Icon_Refresh | &#xE72C; | Odśwież |
| Icon_Download | &#xE896; | Pobierz |
| Icon_Continue/Accept | &#xE8FB; | Potwierdź/Kontynuuj |
| Icon_Decline | &#xE711; | Anuluj/Zamknij |
| Icon_Information | &#xE946; | Informacja |
| Icon_Warning | &#xE7BA; | Ostrzeżenie |
| Icon_Error | &#xEA39; | Błąd |
| Icon_Browse | &#xED25; | Przeglądaj |
| Icon_CreateMod | &#xE713; | Utwórz Mod |

#### Ujednolicone Kontrolki we Wszystkich Motywach

| Kontrolka | Klasyczny | Ciemny | Jasny |
|-----------|-----------|--------|-------|
| Pole wyboru | Przełącznik (Złoty) | Przełącznik (AccentBrush) | Przełącznik (AccentBrush) |
| Przycisk opcji | Koło (Złoty) | Koło (AccentBrush) | Koło (AccentBrush) |
| ComboBox | Scale9 oryginał | Fluent niestandardowy | Fluent niestandardowy |

#### Poprawki Widoczności Motywów
- Jasny: tekst AccentButton wymuszony na Biały, dostosowanie Opacity ikon kart
- Ciemny/Jasny: podejście `TextElement.Foreground` ComboBoxItem dla widoczności zaznaczonego tekstu
- Klasyczny: zasoby zapasowe Fluent dodane do Dictionary.xaml

---

## Struktura Plików

```
ModAPI/
├── App.xaml / App.xaml.cs          # Ładowanie/zapisywanie/stosowanie motywu
├── Dictionary.xaml                  # Oryginalne style + zasoby przełącznik/radio/zapasowe
├── FluentStyles.xaml                # Ciemny motyw + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Jasny motyw + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # Główne UI + karta pobierania + wybór motywu
│   └── SubWindows/                  # 16 SubWindows (wszystkie z ikonami czcionki)
├── resources/
│   ├── langs/                       # 13 plików językowych
│   └── textures/Icons/flags/        # Ikony flag (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Wymagania Build

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Licencja

GNU General Public License v3.0 — zgodnie z oryginalną licencją.
