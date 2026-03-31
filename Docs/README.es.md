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

**Herramienta de Gestión de Mods de The Forest — Edición Mejorada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemania)
> Mejora: zzangae (República de Corea)

---

## Descripción General

ModAPI es una aplicación de escritorio para gestionar mods de The Forest. Esta edición mejorada incluye migración a .NET Framework 4.8, interfaz Windows 11 Fluent Design, sistema de 3 temas, soporte multilingüe mejorado, implementación completa de la pestaña de Descargas y soporte para desarrollo de mods en C# 7.3.

---

## Qué Cambió en v2.0.9586

| # | Categoría | Problema | Solución |
|---|---|---|---|
| 1 | **Crítico** | Pantalla negra en el menú principal tras aplicar mods | Resuelto — la pipeline de remapeo de ensamblados parchea correctamente los encabezados PE y las tablas de referencias |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` incluido pero no funcional | Eliminado completamente — `mscorlib` de Mono 2.0 genera IL con referencia directa a `ValueTuple`; ningún polyfill puede anularlo |
| 3 | **Polyfill** | Nombre de archivo incorrecto: `System.Threading.Tasks.dll` | Corregido a `System.Threading.dll` — nombre real del NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Bug de ruta de copia en `Game.cs`: archivos copiados a `Managed\polyfills\` | Corregido con `Path.GetFileName()` para copia plana en `Managed\` |
| 5 | **Build** | Target PostBuild sin auto-copia de polyfills | `BaseModLib.csproj` PostBuild ahora copia automáticamente `AsyncBridge.dll` y `System.Threading.dll` |
| 6 | **C# 7.3** | Soporte de tuplas (`ValueTuple`) intentado y fallido | Eliminado definitivamente — límite arquitectónico en Mono 2.0 |
| 7 | **C# 7.3** | Verificación en juego de características C# 7.3 | Confirmado: pattern matching, interpolación de cadenas, variable `out` inline |

### Matriz Final de Características C# 7.3

| Característica | Estado | Notas |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Confirmado | Probado en juego via `TEST_MOD.log` |
| Interpolación de cadenas (`$""`) | ✅ Confirmado | Probado en juego via `TEST_MOD.log` |
| Variable `out` inline | ✅ Confirmado | Probado en juego via `TEST_MOD.log` |
| Miembros con cuerpo de expresión (`=>`) | ✅ | Gestionado por compilador |
| Funciones locales | ✅ | Gestionado por compilador |
| `nameof` | ✅ | Gestionado por compilador |
| Operador null-condicional (`?.`, `??`) | ✅ | Gestionado por compilador |
| `async`/`await` | ✅ | Via polyfills AsyncBridge + System.Threading |
| Tuplas (`ValueTuple`) | ❌ Límite duro | ABI de `mscorlib` Mono 2.0 — sin solución |

### Configuración Final de Polyfill

| DLL | Paquete NuGet | Destino | Propósito |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` para .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Dependencia de AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Eliminado~~ | ~~Eliminado~~ | ~~No funcional en Mono 2.0~~ |

---

## Arquitectura de Runtime

| Componente | Objetivo | Runtime | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | App de escritorio |
| `BaseModLib.dll` | .NET Framework 3.5 | Juego Mono 2.0 | **Fijado permanentemente** |
| DLLs de Mod | .NET Framework 4.8 | Juego Mono 2.0 (parcheado) | Cabecera PE parcheada al aplicar |

```
Build v3.5  →  Cabecera PE: CLR Runtime v2.0.50727  ←  Mono 2.0 acepta  ✅
Build v4.8  →  Cabecera PE: CLR Runtime v4.0.30319  ←  Mono 2.0 rechaza ❌
```

---

## Historial de Versiones

| Versión | Fecha | Resumen |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Pantalla negra resuelta, pipeline polyfill finalizada, ValueTuple eliminado, bugs corregidos, C# 7.3 verificado |
| v2.0.9561 | 2026-03-06 | Soporte C# 7.3, parche PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Pestaña descargas, iconos, 13 idiomas |
| v2.0.9500 | — | Sistema de temas, Fluent Design UI |
| v2.0.9400 | — | Limpieza de código |
| v2.0.9300 | — | Entorno build, DLL stub UnityEngine |
| v2.0.9200 | — | Migración .NET Framework 4.8 |
| v1.x | — | Versión original FluffyFish |

---

## Requisitos de Compilación

| Requisito | Versión | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Para proyectos ModAPI |
| .NET Framework SDK | 3.5 | Solo para BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — en `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` en `libs/polyfills/` |

---

## Licencia

GNU General Public License v3.0 — sigue la licencia original.
