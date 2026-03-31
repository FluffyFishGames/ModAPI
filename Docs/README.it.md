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

**Strumento di Gestione Mod di The Forest — Edizione Aggiornata**

> Originale: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germania)
> Aggiornamento: zzangae (Repubblica di Corea)

---

## Panoramica

ModAPI è un'applicazione desktop per la gestione delle mod di The Forest. Questa edizione aggiornata include la migrazione a .NET Framework 4.8, l'interfaccia Windows 11 Fluent Design, un sistema a 3 temi, supporto multilingue migliorato, un'implementazione completa della scheda Download e supporto per lo sviluppo di mod in C# 7.3.

---

## Cosa è cambiato in v2.0.9586

| # | Categoria | Problema | Soluzione |
|---|---|---|---|
| 1 | **Critico** | Schermo nero nel menu principale dopo l'applicazione dei mod | Risolto — la pipeline di rimappatura degli assembly patcha correttamente gli header PE e le tabelle dei riferimenti |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` incluso ma non funzionale | Rimosso completamente — `mscorlib` di Mono 2.0 genera IL con riferimento diretto a `ValueTuple`; nessun polyfill può sovrascriverlo |
| 3 | **Polyfill** | Nome file errato: `System.Threading.Tasks.dll` | Corretto in `System.Threading.dll` — nome reale dal NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Bug percorso di copia in `Game.cs`: file copiati in `Managed\polyfills\` | Corretto con `Path.GetFileName()` per copia piatta in `Managed\` |
| 5 | **Build** | Target PostBuild senza auto-copia dei polyfill | `BaseModLib.csproj` PostBuild copia ora automaticamente `AsyncBridge.dll` e `System.Threading.dll` |
| 6 | **C# 7.3** | Supporto tuple (`ValueTuple`) tentato e fallito | Definitivamente rimosso — limite architetturale su Mono 2.0 |
| 7 | **C# 7.3** | Verifica in-game delle funzionalità C# 7.3 | Confermato: pattern matching, interpolazione di stringhe, variabile `out` inline |

### Matrice Finale delle Funzionalità C# 7.3

| Funzionalità | Stato | Note |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Confermato | Testato in-game via `TEST_MOD.log` |
| Interpolazione di stringhe (`$""`) | ✅ Confermato | Testato in-game via `TEST_MOD.log` |
| Variabile `out` inline | ✅ Confermato | Testato in-game via `TEST_MOD.log` |
| Membri con corpo di espressione (`=>`) | ✅ | Gestito dal compilatore |
| Funzioni locali | ✅ | Gestito dal compilatore |
| `nameof` | ✅ | Gestito dal compilatore |
| Operatore null-condizionale (`?.`, `??`) | ✅ | Gestito dal compilatore |
| `async`/`await` | ✅ | Via polyfill AsyncBridge + System.Threading |
| Tuple (`ValueTuple`) | ❌ Limite duro | ABI `mscorlib` Mono 2.0 — nessuna soluzione alternativa |

### Configurazione Finale dei Polyfill

| DLL | Pacchetto NuGet | Destinazione | Scopo |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` per .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Dipendenza AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Rimosso~~ | ~~Rimosso~~ | ~~Non funzionale su Mono 2.0~~ |

---

## Architettura di Runtime

| Componente | Obiettivo | Runtime | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | App desktop |
| `BaseModLib.dll` | .NET Framework 3.5 | Gioco Mono 2.0 | **Fissato definitivamente** |
| DLL di Mod | .NET Framework 4.8 | Gioco Mono 2.0 (patchato) | Intestazione PE patchata durante l'applicazione |

```
Build v3.5  →  Intestazione PE: CLR Runtime v2.0.50727  ←  Mono 2.0 accetta  ✅
Build v4.8  →  Intestazione PE: CLR Runtime v4.0.30319  ←  Mono 2.0 rifiuta  ❌
```

---

## Cronologia delle Versioni

| Versione | Data | Sommario |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Schermo nero risolto, pipeline polyfill finalizzata, ValueTuple rimosso, bug corretti, C# 7.3 verificato |
| v2.0.9561 | 2026-03-06 | Supporto C# 7.3, patch intestazione PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Scheda download, icone, 13 lingue |
| v2.0.9500 | — | Sistema di temi, Fluent Design UI |
| v2.0.9400 | — | Pulizia del codice |
| v2.0.9300 | — | Ambiente build, DLL stub UnityEngine |
| v2.0.9200 | — | Migrazione .NET Framework 4.8 |
| v1.x | — | Release originale FluffyFish |

---

## Requisiti di Build

| Requisito | Versione | Note |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Per progetti ModAPI |
| .NET Framework SDK | 3.5 | Solo per BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — in `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licenza

GNU General Public License v3.0 — segue la licenza originale.
