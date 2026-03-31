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

**The Forest Mod-Verwaltungstool — Upgrade-Edition**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Deutschland)
> Upgrade: zzangae (Republik Korea)

---

## Überblick

ModAPI ist eine Desktop-Anwendung zur Verwaltung von Mods für The Forest. Diese Upgrade-Edition umfasst die Migration auf .NET Framework 4.8, Windows 11 Fluent Design UI, ein 3-Themen-System, erweiterte Mehrsprachigkeitsunterstützung, eine vollständige Implementierung des Download-Tabs und C# 7.3 Mod-Entwicklungsunterstützung.

---

## Was hat sich in v2.0.9586 geändert

| # | Kategorie | Problem | Lösung |
|---|---|---|---|
| 1 | **Kritisch** | Schwarzer Bildschirm im Hauptmenü nach Mod-Anwendung | Behoben — Assembly-Remapping-Pipeline patcht PE-Header und Referenztabellen korrekt |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` enthalten, aber nicht funktionsfähig | Vollständig entfernt — Mono 2.0 `mscorlib` generiert IL mit direkter `ValueTuple`-Referenz; kein Polyfill kann dies überschreiben |
| 3 | **Polyfill** | Falscher Dateiname: `System.Threading.Tasks.dll` | Korrigiert zu `System.Threading.dll` — tatsächlicher Dateiname aus `TaskParallelLibrary 1.0.2856` NuGet |
| 4 | **Polyfill** | `Game.cs` Kopierpfad-Bug: Dateien in `Managed\polyfills\` kopiert | Behoben mit `Path.GetFileName()` für flaches Kopieren in `Managed\` |
| 5 | **Build** | PostBuild-Target fehlt Polyfill-Autokopie | `BaseModLib.csproj` PostBuild kopiert nun automatisch `AsyncBridge.dll` und `System.Threading.dll` |
| 6 | **C# 7.3** | Tupel-Unterstützung versucht und gescheitert | Definitiv entfernt — Tupel sind auf Mono 2.0 ein architektonisches Limit |
| 7 | **C# 7.3** | In-Game-Verifizierung der C# 7.3 Features | Bestätigt: Pattern Matching, String-Interpolation, `out`-Variable inline |

### C# 7.3 Finale Feature-Matrix

| Feature | Status | Hinweise |
|---|---|---|
| Pattern Matching (`is`, `switch`) | ✅ Bestätigt | In-Game via `TEST_MOD.log` getestet |
| String-Interpolation (`$""`) | ✅ Bestätigt | In-Game via `TEST_MOD.log` getestet |
| `out`-Variable inline | ✅ Bestätigt | In-Game via `TEST_MOD.log` getestet |
| Ausdruckskörper-Member (`=>`) | ✅ | Compiler-verarbeitet |
| Lokale Funktionen | ✅ | Compiler-verarbeitet |
| `nameof` | ✅ | Compiler-verarbeitet |
| Null-Bedingungsoperator (`?.`, `??`) | ✅ | Compiler-verarbeitet |
| `async`/`await` | ✅ | Via AsyncBridge + System.Threading Polyfills |
| Tupel (`ValueTuple`) | ❌ Hartes Limit | Mono 2.0 `mscorlib` ABI — keine Umgehung |

### Finale Polyfill-Konfiguration

| DLL | NuGet-Paket | Ziel | Zweck |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` für .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge-Abhängigkeit |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Entfernt~~ | ~~Entfernt~~ | ~~Auf Mono 2.0 nicht funktionsfähig~~ |

---

## Laufzeit-Architektur

| Komponente | Ziel | Laufzeit | Grund |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Desktop-App |
| `BaseModLib.dll` | .NET Framework 3.5 | Spiel Mono 2.0 | **Dauerhaft fixiert** |
| Mod-DLLs | .NET Framework 4.8 | Spiel Mono 2.0 (gepatcht) | PE-Header beim Apply gepatcht |

```
v3.5 Build  →  PE-Header: CLR Runtime v2.0.50727  ←  Mono 2.0 akzeptiert  ✅
v4.8 Build  →  PE-Header: CLR Runtime v4.0.30319  ←  Mono 2.0 verweigert  ❌
```

---

## Versionsverlauf

| Version | Datum | Zusammenfassung |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Schwarzer Bildschirm behoben, Polyfill-Pipeline finalisiert, ValueTuple entfernt, Bugs behoben, C# 7.3 verifiziert |
| v2.0.9561 | 2026-03-06 | C# 7.3 Mod-Unterstützung, PE-Header-Patching, Polyfill-Pipeline |
| v2.0.9552 | 2026-02-25 | Download-Tab, Symbol-Modernisierung, 13 Sprachen |
| v2.0.9500 | — | Themen-System, Fluent Design UI |
| v2.0.9400 | — | Code-Bereinigung, Login-Entfernung |
| v2.0.9300 | — | Build-Umgebung, UnityEngine Stub-DLL |
| v2.0.9200 | — | .NET Framework 4.8 Migration |
| v1.x | — | Originales FluffyFish-Release |

---

## Build-Anforderungen

| Anforderung | Version | Hinweise |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Für ModAPI-Projekte |
| .NET Framework SDK | 3.5 | Nur für BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — in `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Lizenz

GNU General Public License v3.0 — folgt der Originallizenz.
