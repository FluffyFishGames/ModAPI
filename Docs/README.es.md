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

**Herramienta de Gestión de Mods de The Forest — Edición Mejorada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemania)
> Mejora: zzangae (República de Corea)

---

## Descripción General

ModAPI es una aplicación de escritorio para gestionar mods de **5 juegos oficialmente compatibles**. Esta edición mejorada incluye soporte multijuego, una pestaña de Configuración completamente rediseñada, configuración de ruta de Steam, ajustes de UI persistentes, sistema de tamaño de fuente dinámico, validación de inicio de juego, separación de builds Debug/Release y numerosas correcciones de fallos verificadas en juego.

---

## Juegos Soportados

| Juego | Motor | Versión | Steam ID | Ejecutable |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 5 (actualizado desde Unity 4) |
| Última Versión | v1.12 (VR) |
| Última Actualización | 11 de septiembre de 2019 — parche de soporte VR; sin más actualizaciones de contenido importantes |
| Ejecutable | `TheForest.exe` |
| Carpeta de Datos | `TheForest_Data/Managed/` |
| Carpeta de Mods | `mods/TheForest/` |
| Carpeta de Proyectos | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — totalmente soportado |

The Forest fue actualizado de Unity 4 a Unity 5, mejorando significativamente los gráficos y la física. El parche VR de septiembre de 2019 fue la última actualización importante. El juego permanece en un estado estable y finalizado — ideal para modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity (código base integrado, unificado con Below Zero en 2022) |
| Última Versión | 2025 Patch (v18810395) |
| Última Actualización | 12 de agosto de 2025 — correcciones de errores y mejoras de rendimiento junto con lanzamiento móvil |
| Ejecutable | `Subnautica.exe` |
| Carpeta de Datos | `Subnautica_Data/Managed/` |
| Carpeta de Mods | `mods/Subnautica/` |
| Carpeta de Proyectos | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — soportado |

Originalmente construido sobre Unity 5, Subnautica recibió la actualización 'Living Large' (v2.0) a finales de 2022 que fusionó el código base del motor con Below Zero para mejorar la optimización y estabilidad. Nota: el próximo *Subnautica 2* usa Unreal Engine 5.

> **XML reescrito en v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` añadidos a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity |
| Última Versión | v1.1.02 (Beta) / v1.09 (Estable) |
| Última Actualización | Marzo 2026 — correcciones de chat de voz y multijugador vía rama beta |
| Ejecutable | `Raft.exe` |
| Carpeta de Datos | `Raft_Data/Managed/` |
| Carpeta de Mods | `mods/Raft/` |
| Carpeta de Proyectos | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — soportado |
| Versions.xml | `1.1.01` (con checksum) |

Tras la conclusión oficial de la historia en v1.0: *The Final Chapter*, los parches han continuado para mejoras del código de red y estabilidad.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 6 (migrado desde Unity 2021/2022 a finales de 2025) |
| Última Versión | v0.67.0.0 |
| Última Actualización | 26 de junio de 2025 — reelaboración de distribución de islas y actualización del motor; hotfixes en curso hasta 2026 |
| Ejecutable | `EscapeThePacific.exe` |
| Carpeta de Datos | `EscapeThePacific_Data/Managed/` |
| Carpeta de Mods | `mods/EscapeThePacific/` |
| Carpeta de Proyectos | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — soportado |

Completó una reconstrucción importante del sistema y migración a Unity 6 a finales de 2025, permitiendo entornos más dinámicos. El juego continúa en desarrollo de Acceso Anticipado.

> **XML reescrito en v2.0.9610**: `extends="GenericUnityGame"` eliminado; `includeAssembly` configurado solo como `Assembly-CSharp.dll` — previene errores de herencia de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 2019 |
| Última Versión | v2.9.5 |
| Última Actualización | 4 de febrero de 2026 — optimización para Steam Deck y mejoras de legibilidad de texto |
| Ejecutable | `GH.exe` |
| Carpeta de Datos | `GH_Data/Managed/` |
| Carpeta de Mods | `mods/GH/` |
| Carpeta de Proyectos | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — soportado |
| Versions.xml | `2.9.5` (con checksum) |

Desarrollado con actualizaciones progresivas del motor Unity 2017 → 2018 → 2019. El hotfix de febrero de 2026 se centró en la compatibilidad con Steam Deck y la legibilidad del texto de la UI.

> **XML reescrito en v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` añadidos; `DOTweenPro.dll` inexistente eliminado.
</details>

---

## Arquitectura

### División de Tiempo de Ejecución

| Componente | Objetivo | Tiempo de Ejecución | Razón |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplicación de escritorio, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteca compartida |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Permanentemente fijado** — el encabezado PE debe contener `v2.0.50727` |
| Mod DLLs (usuario) | .NET Framework 4.8 | Game Mono 2.0 (parcheado) | Compilado con 4.8, encabezado PE parcheado al aplicar |

### División de Compilación Debug / Release

Todas las validaciones de archivos y el procesamiento de ensamblados se ramifican según la configuración de compilación mediante `#if DEBUG` / `#else`.

| Ubicación | Compilación Debug | Compilación Release |
|---|---|---|
| `CheckSteam()` | Solo `File.Exists()` — archivos ficticios pasan | `FileValidator.IsValidSteamExe()` — encabezado PE + mín. 1 MB |
| `CheckGamePath()` | Solo `File.Exists()` — archivos ficticios pasan | `FileValidator.IsValidAssemblyDll()` — encabezado PE + metadatos CLR + mín. 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — omite análisis Cecil | Análisis completo Mono.Cecil + modificación IL + `module.Write()` |
| `ModLib.Create()` — archivo no encontrado | Registrar advertencia, omitir y continuar | Registrar error, abortar con popup |

**Las pruebas Debug** usan `create_dummy_Debug_games.ps1` para generar archivos de 0 bytes bajo `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` y `bin\Debug\gamefiles\original\`. Estos pasan las verificaciones `File.Exists()` y permiten pruebas completas del flujo de trabajo de la UI sin una instalación real del juego.

**Las compilaciones Release** aplican `FileValidator` (verificación de encabezado PE + metadatos CLR de .NET) para rechazar archivos de 0 bytes, archivos de texto y binarios arbitrarios. Solo pasan ejecutables Windows válidos y ensamblados .NET.

### FileValidator — Verificación de Encabezado PE

`ModAPI_Shared\Utils\FileValidator.cs` — aplicado solo en compilaciones Release.

| Método | Verificaciones | Tamaño Mín. |
|---|---|---|
| `IsValidSteamExe(path)` | Firma MZ + firma PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Firma MZ + firma PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + encabezado de metadatos CLR (directorio de datos #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline de Remapeo de Ensamblados

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

### Respaldo del Resolver de Ensamblados

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Soporte de Características C# 7.3

| Característica | Estado | Notas |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ | Verificado en el juego |
| Interpolación de cadenas (`$""`) | ✅ | Verificado en el juego |
| Variable `out` en línea | ✅ | Verificado en el juego |
| `async` / `await` | ✅ | Mediante AsyncBridge + polyfills System.Threading |
| Tuplas (`ValueTuple`) | ❌ Límite absoluto | ABI de `mscorlib` Mono 2.0 — sin solución alternativa |

### Theme System

A partir de v2.0.9613, la UI de selección de temas se trasladó del tab Settings a un **tab Themes** dedicado. Para agregar un nuevo tema solo se necesita una línea en el diccionario de `App.xaml.cs`.

| Índice | ID | Archivo | Paleta |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` solo | Fondo de textura original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono claro + acento azul |
| 2 | `dark` | `FluentStyles.xaml` | Tono oscuro + acento azul (predeterminado) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rojo + negro |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espacio oscuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Atardecer brillante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océano oscuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brillante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brillante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brillante |

Los cambios de tema activan un reinicio automático de la aplicación. (guardado en `theme.cfg`)

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

### Textura de Fondo

Seleccione una imagen en la tarjeta **Background Texture** del tab Themes para aplicarla como fondo de toda la aplicación. Formatos compatibles: `.png` / `.jpg` / `.jpeg`, máx 50MB, resolución 4K o inferior. La imagen se comprime como JPEG Q75 con un encabezado mágico de 16 bytes y se guarda como `resources\textures\ui_bg\bg.dat` (atributo Hidden). Hash SHA-256 para verificación de integridad; al detectar manipulación se reinicia automáticamente + popup de advertencia.

Cuando el fondo está activo, la transparencia de la UI se procesa en dos capas: Layer 1 (overlay MergedDictionaries) para paneles `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) para paneles basados en `{StaticResource}` con semitransparencia.

### Sistema de Tamaño de Fuente

| Clave de Recurso | Base | Descripción |
|---|---|---|
| `AppBaseFontSize` | 13 | Texto normal |
| `AppBaseHeaderFontSize` | 16 | Encabezados, títulos de panel |
| `AppBaseSmallFontSize` | 12 | Etiquetas secundarias |
| `AppBaseTinyFontSize` | 10 | Texto de sugerencia |
| `AppBaseLargeFontSize` | 20 | Texto de visualización grande |

### Configuración Persistente de UI — `ui.cfg`

| Clave | Predeterminado | Descripción |
|-----|---------|-------------|
| `ModListWidth` | `150` | Ancho de lista de mods (px) |
| `ProjectListWidth` | `150` | Ancho de lista de proyectos (px) |
| `AppFontSize` | `13` | Tamaño de fuente global de UI (px) |
| `AlwaysOnTop` | `false` | Ventana siempre visible |
| `TexturePath` | *(ninguno)* | Nombre de archivo original de textura de fondo (solo visualización) |
| `TextureHash` | *(ninguno)* | Hash SHA-256 de textura de fondo |
| `TextureActive` | `false` | Estado de activación de textura de fondo |
| `GamePathReset_{GameId}` | *(ninguno)* | Indicador de reinicio de ruta de juego |
| `SteamPathReset` | *(ninguno)* | Indicador de reinicio de ruta de Steam |

### Estructura de Archivos

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Persistent UI settings
├── theme.cfg                            # Current theme
├── Windows/
│   ├── MainWindow.xaml / .cs            # Main UI — 6 tabs, Themes, Settings, Steam path
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Game path popup (dynamic GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # First-run setup + default initialization
│       └── (14 other SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Classic theme
│   ├── FluentStyles.xaml                # Dark theme
│   ├── FluentStylesLight.xaml           # Light theme
│   ├── FluentStylesDiablo.xaml          # Diablo theme
│   ├── FluentStylesNebula.xaml          # Nebula theme
│   ├── FluentStylesSunset.xaml          # Sunset theme
│   ├── FluentStylesOcean.xaml           # Ocean theme
│   ├── FluentStylesNordic.xaml          # Nordic theme
│   ├── FluentStylesCitrus.xaml          # Citrus theme
│   └── FluentStylesBloom.xaml           # Bloom theme
├── Data/
│   ├── Game.cs                          # Assembly patching, null guards, resolver fallback
│   ├── ModLib.cs                        # BaseModLib generation + remapping (#if DEBUG split)
│   ├── Models/
│   │   └── ModProject.cs                # Project create/build/apply + null guards
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter
│   │   ├── ModViewModel.cs              # GameId from folder path
│   │   ├── ModProjectsViewModel.cs      # Dispose() for DispatcherTimer
│   │   └── SettingsViewModel.cs         # Default true for UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mono 2.0 assembly version mapping (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Name-based resolver with caching
│   └── MonoHelper.cs                    # Mono.Cecil IL helper utilities
├── resources/
│   ├── langs/                           # 13 language files
│   └── textures/ui_bg/
│       └── bg.dat                       # Compressed & secured background image (runtime-generated)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Full rewrite v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Full rewrite v2.0.9610
    │   ├── GH.xml                       # Full rewrite v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — not supported
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Lightweight constructor + ModLibrary init fix
│   └── ModLib.cs                        # #if DEBUG split for Cecil parsing
└── Utils/
    └── FileValidator.cs                 # PE header + CLR metadata validation (Release only)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Standalone WPF version update tool

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Generates dummy game/steam structure
├── dummy_games\{GameId}\               # Dummy game install paths
├── dummy_steam\Steam.exe               # Dummy Steam executable
└── gamefiles\original\{GameId}\        # Dummy backup paths for ModLib
```

---

## Instalación y Configuración

### Paso 1 — Requisitos previos

| Elemento | Requerido |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstalado en Windows 11; [descargar](https://dotnet.microsoft.com/download/dotnet-framework/net48) para Windows 10) |
| Steam | Requerido — debe configurarse en la pestaña Settings |
| Al menos un juego soportado | Requerido — debe configurarse en la pestaña Settings |

### Paso 2 — Instalar ModAPI

1. Descargar la última versión de GitHub
2. Extraer en cualquier carpeta (ej. `C:\ModAPI\`)
3. Ejecutar `ModAPI.exe`
4. En el primer inicio aparece la pantalla **Welcome** — configurar preferencias y hacer clic en **Continue**

### Paso 3 — Configurar ruta de Steam (pestaña Settings)

1. Ir a la pestaña **Settings**
2. Buscar **Steam Installation Path**
3. Hacer clic en **Browse** → seleccionar `Steam.exe`
4. Hacer clic en **Save**

### Paso 4 — Configurar rutas de juegos (pestaña Settings)

1. Hacer clic en el encabezado de la tarjeta del juego para expandirla
2. Hacer clic en **Browse** → seleccionar la carpeta raíz del juego (donde se encuentra el `.exe`)
3. Hacer clic en **Save**

| Juego | Ejecutable | Ruta de ejemplo |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Paso 5 — Descargar Mods (pestaña Downloads)

1. Ir a la pestaña **Downloads**
2. Seleccionar un juego del filtro de juegos
3. Buscar un mod y hacer clic en **Download**

> **Sin conexión**: Descargar archivos `.mod` manualmente desde `modapi.survivetheforest.net` y colocarlos en la carpeta correspondiente:

| Juego | Carpeta |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Paso 6 — Aplicar Mods e Iniciar Juego (pestaña Mods)

1. Ir a la pestaña **Mods**
2. Seleccionar un juego del **Filtro de Juegos** (Columna 0)
3. Activar mods en la **Lista de Mods** (Columna 1)
4. Hacer clic en **Start Game**

Las siguientes verificaciones se ejecutan automáticamente antes del inicio:

| # | Verificación | Popup de Error |
|---|---|---|
| 1 | Ruta de Steam configurada y válida | SteamNotFound |
| 2 | Juego en carpeta `mods/` coincide con ruta en Settings | GameModsMismatch |
| 3 | Al menos un mod seleccionado | NoModSelected |
| 4 | Sin mods de juegos mixtos en la selección | MixedGameMods |
| 5 | Ruta del juego configurada y ejecutable existe | GamePathNotSet / GameNotInstalled |

---

## Descripción de Pestañas

### Pestaña Welcome
Pantalla de configuración inicial (índice de pestaña 0). Configurar AutoUpdate, conexión Steam y preferencias de tabla VersionsData. En inicios posteriores esta pestaña proporciona enlaces de comunidad y notas de versión.

### Pestaña Mods
Flujo de trabajo principal de gestión de mods — diseño de 3 columnas:

| Columna | Contenido |
|---|---|
| Columna 0 | Filtro de Juegos — botones de radio para 5 juegos soportados |
| Columna 1 | Lista de Mods — mods instalados con selector de versión y casilla de activación |
| Columna 2 | Información — detalles del mod seleccionado, descripción, historial de versiones |

### Pestaña Downloads
Explorar y descargar mods desde `modapi.survivetheforest.net`.

- **Filtro de juegos**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Filtro de categorías**: 12 categorías (Bugfixes, Balancing, Cheats, …)
- **Búsqueda**: por nombre de mod, descripción o autor
- **Modo sin conexión**: muestra instrucciones de carpetas para los 5 juegos soportados

### Pestaña Development
Flujo de trabajo de desarrollo de mods — panel de filtro de juegos (Columna 0) cubre los 5 juegos soportados.

- Crear, compilar y aplicar proyectos de mods por juego
- Gestión de recursos de idioma
- Generación de ModLib con validación de 3 pasos (Steam → proyecto → ruta del juego)
- Cambio seguro de juego mediante constructor ligero `Game` (sin llamada a `Verify()`)

### Pestaña Themes
Selección de temas y gestión de texturas de fondo.

- **Selección de tema**: 10 temas (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Textura de fondo**: Seleccionar una imagen como fondo de toda la aplicación (compresión JPEG + procesamiento de seguridad)
- Cuando la textura de fondo está activa, la selección de tema se bloquea

### Pestaña Settings
Configuración centralizada — 4 filas:

| Fila | Contenido |
|---|---|
| 0 | Idioma / Tamaño de fuente / Tema / Ancho máximo / Ancho de lista de mods / Ancho de lista de proyectos |
| 1 | Mantener VersionsData / Auto actualización / Conexión Steam / Siempre visible |
| 2 | Ruta de instalación de Steam (TextBox + Explorar + Guardar + Reiniciar) |
| 3 | Rutas de instalación de juegos — tarjeta expandible por juego (TextBox + Explorar + Guardar + Reiniciar) |

---

## Cambios en v2.0.9618

### Herramienta de Actualización de Versión (MODAPI_VersionTool)

Una herramienta WPF independiente para actualizar el número de versión con un solo clic.

**Ubicación**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Características**
- Muestra automáticamente la versión actual (leída desde `App.xaml.cs`)
- Ingrese una nueva versión y haga clic en **Apply Version** para actualizar ambos archivos simultáneamente
- Validación de formato: solo se acepta el formato `X.X.XXXX`

**Archivos Modificados**

| Archivo | Ruta | Cambio |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Uso**
1. Ejecutar `MODAPI_VersionTool.exe`
2. Ingresar nueva versión (ej. `2.0.9619`)
3. Hacer clic en **Apply Version**
4. Recompilar la solución ModAPI en Visual Studio

### Corrección de Visualización de Versión en StatusBar

- `VersionLabel.Text` ahora referencia `App.Version` en lugar del `Version.Descriptor` codificado
- Actualizar la versión con VersionTool y recompilar ahora se refleja inmediatamente en la StatusBar

---

## Cambios en v2.0.9617

### Pestaña Settings — Botones de Reinicio de Ruta Añadidos

Se ha añadido un botón **Reset** a la ruta de instalación de Steam y a cada fila de ruta de instalación de juego.

**Fila de ruta de Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Fila de ruta de juego (por juego)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamiento del reinicio**
- Limpia el TextBox de ruta inmediatamente
- Guarda un flag de reinicio en `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- El TextBox permanece vacío después del reinicio
- Soluciona la limitación de Configuration XML que no persiste cadenas vacías

**Auto-guardado de Browse**
- Antes: requería hacer clic en el botón Save por separado después de Browse
- Después: guardado automático al seleccionar archivo — se refleja incluso después de cambiar al tab Mods

**Nueva clave de idioma**

| Clave | Valor |
|---|---|
| `Lang.Options.Labels.PathReset` | Reiniciar |

---

## Cambios en v2.0.9616

### Versions.xml — 4 Juegos Añadidos / Actualizados

| Juego | Ruta del Archivo | BuildID | Notas |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Recién creado |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum actualizado |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Recién creado |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum actualizado |

### Reglas de Composición del Checksum

El formato del checksum difiere dependiendo de si `Assembly-CSharp-firstpass.dll` existe para cada juego.

| Juego | firstpass.dll | Formato del Checksum |
|---|---|---|
| GH | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Subnautica | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| EscapeThePacific | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Raft | ❌ No presente | Solo `Assembly-CSharp MD5` (32 caracteres) |

### Procedimiento de Actualización de Versions.xml

Añadir una nueva entrada `<version>` sin eliminar las existentes.

**Step 1 — Encontrar nuevo BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Juego | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Step 2 — Extraer nuevo checksum**
```powershell
# Juegos con firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenar ambos valores Hash en orden (firstpass primero)

# Juegos sin firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Step 3 — Añadir entrada a Versions.xml**
```xml
<version id="{nuevo BuildID}">
    <checksum>{nuevo checksum}</checksum>
</version>
```

---

## Cambios en v2.0.9615

### Corrección de Expansión de Ruta de Juego en Settings

- **Altura de expansión de tarjeta**: El borde inferior de la ventana ahora crece exactamente la altura del campo de entrada al expandir una tarjeta de ruta de juego
- **`UpdateWindowHeight()` mejorado**: Llama a `UpdateLayout()` antes de la medición `SizeToContent.Height`; establece temporalmente `TextureLayer1` en `Collapsed` cuando la textura de fondo está activa para evitar que el tamaño original de imagen 4K afecte el cálculo de altura
- **Corrección de Grid Row interno**: Cambió la última Row del panel de rutas de juego de `Height="*"` a `Height="Auto"` — elimina espacio inferior innecesario

---

## Cambios en v2.0.9614

### Corrección del Comportamiento del Botón Maximizar

- **Maximizar**: Usa `SystemParameters.WorkArea` para maximización manual en lugar de `WindowState.Maximized` — se ajusta exactamente a la resolución de pantalla actual sin superponer la barra de tareas
- **Restaurar**: Guarda `Left`, `Top`, `Width`, `Height` y `MaxWidth` antes de maximizar y los restaura al hacer clic en el botón de restaurar
- **Manejo de `MaxWidth`**: Establecido a `∞` al maximizar, valor guardado restaurado al normalizar

---

## Cambios en v2.0.9613

### Nueva Pestaña Themes

El orden de pestañas es ahora:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

La UI de selección de temas se ha movido del tab Settings a un **tab Themes** dedicado.
Icono: Segoe MDL2 Assets `&#xE790;` (paleta)

### Registro de Temas (Estructura Basada en Datos)

Añadir un nuevo tema ahora requiere solo **una línea** en el diccionario de `App.xaml.cs`.
Todas las sentencias switch han sido eliminadas — no se necesitan cambios de código en otro lugar.

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

Los elementos del ComboBox `ThemeSelector` se generan automáticamente desde el bucle `ThemeIds`.
Convención de claves de idioma: `Lang.Options.Theme.{PascalCase}` (ej. `Lang.Options.Theme.Nebula`)

### Temas Soportados

| Índice | ID | Archivo | Paleta |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` solo | Fondo de textura original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono claro + acento azul |
| 2 | `dark` | `FluentStyles.xaml` | Tono oscuro + acento azul (predeterminado) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rojo + negro |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espacio oscuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Atardecer brillante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océano oscuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brillante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brillante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brillante |

Los cambios de tema activan un reinicio automático de la aplicación. (guardado en `theme.cfg`)

### Función de Textura de Fondo

Seleccione una imagen en la tarjeta **Background Texture** del tab Themes para aplicarla como fondo de toda la aplicación. Funciona con cualquier tema seleccionado.

**Formatos de entrada compatibles**: `.png` / `.jpg` / `.jpeg`, hasta 50MB, resolución 4K o inferior

**Pipeline de procesamiento de imagen**

```
Imagen seleccionada por el usuario (.png / .jpg / .jpeg, máx 50MB, 4K o inferior)
  ↓
Compresión JPEG Q75 (buffer de memoria)
  ↓
Encabezado mágico de 16 bytes insertado
  "MODAPI" + "BG" + versión + relleno (FF 00 FE 00)
  ↓
Guardado como resources\textures\ui_bg\bg.dat (atributo Hidden)
  ↓
Hash SHA-256 → almacenado en ui.cfg como TextureHash
```

**Capas de seguridad**

| Capa | Método | Efecto |
|---|---|---|
| Encabezado mágico | 16 bytes insertados antes de la firma JPEG (FF D8 FF) | Los visores externos no pueden reconocer el archivo |
| Atributo Hidden | `FileAttributes.Hidden` | Oculto del Explorador por defecto |
| Integridad SHA-256 | Hash verificado al cargar | La manipulación activa reinicio automático + popup de advertencia |

**Comportamiento de detección de manipulación**
1. `bg.dat` eliminado
2. Claves de `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` reiniciadas
3. TextBox y toggle reiniciados
4. Popup `Lang.Windows.TextureTampered` mostrado

**Claves de ui.cfg**

| Clave | Valor | Descripción |
|---|---|---|
| `TexturePath` | Nombre de archivo (solo visualización) | Nombre original mostrado en TextBox |
| `TextureHash` | SHA-256 hex | Hash de verificación de integridad |
| `TextureActive` | `true` / `false` | Estado de activación |

**Procesamiento de transparencia**

Cuando la imagen de fondo está activa, los fondos de la UI se procesan en dos capas.

- **Layer 1 — Overlay MergedDictionaries**: Los paneles que referencian `{DynamicResource FluentBgBrush}` etc. se hacen automáticamente transparentes. Se restauran con una sola llamada `Remove()` al desactivar.

  Claves objetivo: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — Recorrido del árbol visual (`WalkStyleBackgrounds`)**: Los elementos `{StaticResource}` en temas Fluent no se ven afectados por Layer 1, por lo que el árbol visual se recorre directamente para aplicar pinceles semitransparentes basados en colores originales.

  Procesados: `Panel` (excepto Grid), `Border`, `ListBox` / `ListView`

  Excluidos: `Grid` (fondo preservado, hijos recorridos), `TabPanel` (protección de encabezado de pestaña), `ButtonBase` / `ComboBox`, elementos `Collapsed`

  Restauración: fuente Style Setter → `ClearValue()`, fuente valor local XAML → restaurar pincel original directamente

**Cambio de pestaña**: WPF TabControl carga contenido de pestañas de forma diferida, por lo que `WalkStyleBackgrounds(this)` se re-ejecuta con prioridad `ContextIdle` al cambiar de pestaña.

**Bloqueo de ThemeSelector**: Cuando la textura de fondo está activa, un Border `ThemeSelectorOverlay` se muestra sobre el selector de temas para bloquear la interacción.

**Nuevas claves de idioma**

| Clave | Descripción |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nuevos nombres de temas |
| `Lang.Options.Labels.TextureBackground` | Etiqueta de textura de fondo |
| `Lang.Options.Labels.TextureEnable` | Etiqueta de activar |
| `Lang.Options.Labels.TextureClear` | Botón de limpiar |
| `Lang.Windows.TextureTooLarge` | Advertencia de tamaño de archivo excedido |
| `Lang.Windows.TextureTampered` | Advertencia de manipulación detectada |

**Restricciones de diseño conocidas**

| Elemento | Detalles |
|---|---|
| `IsEnabled=false` en ComboBox | Causa crash `ElementNotEnabledException` → enfoque de overlay `IsHitTestVisible` usado |
| Reemplazo directo de claves `MergedDictionaries` | Crash durante el pase de diseño → solo patrón `Add`/`Remove` |
| Sobrescritura de archivo Hidden | `Access Denied` → debe reiniciar `FileAttributes.Normal` antes de escribir |
| Fondos `{StaticResource}` | No afectados por Layer 1 → requiere WalkStyleBackgrounds (Layer 2) |

---

## Cambios en v2.0.9612

### Separación de Módulo de Temas

- **Nueva carpeta `Themes/`**: Movidos `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` y `FluentStylesClassic.xaml` a `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — Classic theme usa solo `Dictionary.xaml`; Light/Dark/otros temas Fluent cargan XAML correspondiente
- **`ModAPI.csproj`**: Rutas XAML de temas actualizadas al subdirectorio `Themes\`; registrado `FluentStylesClassic.xaml`

---

## Cambios en v2.0.9611

### Corrección de Errores

- **Ancho de lista de mods no aplicado después de cambio de tema**: Corregido problema donde el ancho de la lista de Mods no se aplicaba después de cambiar entre temas Light/Dark y reiniciar — añadida llamada `ApplyModListWidth(width)` dentro de `InitModListWidth()`

---

## Cambios en v2.0.9610

### Añadido

#### Configuración de XML de Juegos y Versiones

| # | Archivo | Cambio |
|---|------|--------|
| 1 | `GH.xml` | Reescritura completa — eliminado inexistente `DOTweenPro.dll`; added `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Reescritura completa — eliminado `extends="GenericUnityGame"`; added `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Reescritura completa — eliminado `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Creado — versión `1.1.01` with checksum |
| 5 | `GH/Versions.xml` | Creado — versión `2.9.5` with checksum |
| 6 | `Subnautica/Versions.xml` | Creado — sin checksum (actualizaciones demasiado frecuentes) |

#### Correcciones de Errores Críticos

| # | Tipo | Problema | Solución |
|---|------|-------|-----|
| 1 | Colgado | `extends="GenericUnityGame"` caused `Assembly-CSharp-firstpass.dll` inheritance → `CreateModLibrary` stalled | Removed `extends` from all non-TheForest XML |
| 2 | Caída | `ResolutionException: XGamingRuntime.XUserGamertagComponent` during Subnautica apply | Added `XGamingRuntime.dll`, `XblPCSandbox.dll` to `copyAssembly` |
| 3 | Caída | Resolver falló on DLLs added to `copyAssembly` after backup created | `Game.cs`: actual install folder added as resolver fallback |
| 4 | Caída | `IOException`: `BaseModLib.dll` file-lock between `CreateModLibrary` and `ApplyMods` | Retry loop: max 10 × 500ms read + max 30 × 500ms existence wait |
| 5 | Caída | `NullReferenceException` — `typesMap` entry.Value null (game not installed) | Added `if (entry.Value == null) continue` |
| 6 | Caída | `NullReferenceException` — constructor ligero `Game` constructor missing `ModLibrary = new ModLib(this)` → `CreateModLibrary()` crash | Added `ModLibrary = new ModLib(this)` to lightweight constructor |
| 7 | Caída | `SwitchDevGame()` — `App.Game.GamePath` empty after lightweight constructor → `CreateModLibrary` crash | Set `App.Game.GamePath = savedPath` after lightweight constructor |
| 8 | Juego Incorrecto | `EscapeThePacific` mods classified as TheForest | `ModsViewModel`: `GameId` extracted from folder path |
| 9 | Ruta Incorrecta | `GetGameFolder()` → `""` → resolves to drive root (e.g. `E:\`) | Null/empty guard at all 6 call sites |

#### División de Compilación Debug / Release

- **`FileValidator.cs`** — nuevo archivo `ModAPI_Shared\Utils\FileValidator.cs`; registrado en `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — encabezado PE (MZ + PE\0\0) + mínimo 1 MB
  - `IsValidGameExe()` — encabezado PE + mínimo 512 KB
  - `IsValidAssemblyDll()` — encabezado PE + encabezado de metadatos CLR .NET + mínimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` omite Cecil / `#else`: análisis Cecil completo + modificación IL
- **`ModLib.Create()` archivo no encontrado** — `#if DEBUG`: registrar advertencia, omitir / `#else`: registrar error, abortar

#### Pruebas Debug

- **`create_dummy_Debug_games.ps1`** — Script PowerShell para `bin\Debug\`; crea archivos de 0 bytes para los 5 juegos bajo `dummy_games\`, `dummy_steam\` y `gamefiles\original\` — permite pruebas completas del flujo de trabajo de UI sin instalación real del juego

#### Pestaña Settings

- **Tarjeta de ruta de Steam** — integrada en la tarjeta de Rutas de Instalación de Juegos; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panel de rutas de juegos** — `BuildGamePathsPanel()` con tarjetas expandibles por juego; TextBox usa `HorizontalAlignment=Stretch`
- Botón **Expandir Todo / Contraer Todo**
- Casilla **SiempreVisible** (guardada en `ui.cfg`)
- Controles deslizantes de **Ancho de Lista de Mods/Proyectos** — inicio en mínimo `150`; guardado en `ui.cfg`
- ComboBox de **Tamaño de Fuente** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronización de casillas** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions ahora se sincronizan correctamente
- **Indicador `_uiInitialized`** — previene escrituras prematuras de `ui.cfg` durante el inicio de WPF

#### Pestaña Mods — Validación de Inicio de Juego

Se ejecuta una validación de cinco pasos en cada clic de Inicio de Juego, independientemente del estado de la lista de mods:

| Paso | Verificación | Popup |
|---|---|---|
| 1 | Ruta de Steam en pestaña Settings válida (`Steam.exe` existe) | SteamNotFound |
| 2 | Juego en carpeta `mods/{GameId}/` coincide con juego configurado en Settings | GameModsMismatch |
| 3 | Al menos un mod seleccionado | NoModSelected |
| 4 | Sin mods de juegos mixtos en la selección | MixedGameMods |
| 5 | Ruta del juego configurada + ejecutable existe | GamePathNotSet / GameNotInstalled |

#### Pestaña Development — Validación de ModLib

Validación de tres pasos al hacer clic en Regeneración de Biblioteca de Mods:

| Paso | Verificación | Popup |
|---|---|---|
| 1 | Ruta de Steam en pestaña Settings válida | SteamNotFound |
| 2 | Al menos un proyecto existe | NoProjectWarning |
| 3 | `App.Game.GamePath` configurado | GamePathNotSet |

#### Pestaña Downloads
- Cadena de depuración reemplazada por `Lang.Downloads.Status.NoDownloads`
- Relleno consistente para todos los mensajes de estado
- Texto manual sin conexión actualizado para 5 juegos soportados; salto de línea mediante dos TextBlocks

#### Configuración Inicial y Sistema de Rutas de Juegos
- `FirstSetup.Check()` — valor predeterminado `true` para `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crea carpetas `mods/` y `projects/` para los 5 juegos
- `SpecifyGamePath` — `GameNameLabel` muestra qué juego; `NavigateToSettings()` redirige a la pestaña Settings

#### Claves de Idioma Nuevas / Actualizadas

| Clave | Valor en Inglés |
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

### No Incluido

| Característica | Razón |
|---|---|
| Auto-actualización (mantener última versión) | Infraestructura del servidor no disponible |
| Búsqueda de actualizaciones | Infraestructura del servidor no disponible |

### Eliminado

| Elemento | Razón |
|---|---|
| Popup `SpecifyGamePath` al inicio | Todas las rutas configuradas en la pestaña Settings |
| Popup `SpecifySteamPath` al inicio | Ruta de Steam configurada en la pestaña Settings |
| Sistema de inicio de sesión | Servidor original ya no operativo (eliminado en v2.0.9400) |
| `Portable.System.ValueTuple.dll` | No funcional en Mono 2.0 (eliminado en v2.0.9586) |
| Condición `UseSteam` en verificación de Steam | Steam ahora siempre se valida primero al Iniciar Juego y Regeneración de Biblioteca de Mods |

---

## Planificado para Versiones Futuras

| # | Característica | Descripción |
|---|---|---|
| 1 | Actualización automática de ModAPI | Descargar y aplicar automáticamente nuevas versiones de ModAPI |
| 2 | Actualización de Tabla VersionsData | Actualizar automáticamente la tabla VersionsData cuando se publiquen nuevos parches del juego |

---

## Cambios en v2.0.9600

### Añadido

- **Pestaña Downloads**: 5 filtros de juegos (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Pestaña Welcome**: añadida en la posición más a la izquierda (índice 0)
- **Pestaña Mods**: diseño de 3 columnas (WrapPanel → lista vertical); ajuste automático de ancho; ajuste de nombre de mod
- **`ModsViewModel`**: filtrado específico por juego, `ResolveGame()` para instancia `Game` correcta por mod
- **`Game.cs`**: constructor ligero `new Game(config, true)` — solo identificación, sin `Verify()`
- **Build**: 4 archivos XML de juegos registrados en `ModAPI.csproj` con `CopyToOutputDirectory=Always`
- **Build**: advertencias limpiadas — CS0168, CS0618, CS0252
- **XML de Juegos**: listas de DLL de TheForest, Raft, GH corregidas
- **Banderas de idioma**: tamaños de imagen estandarizados en las 13 insignias de idioma

### Eliminado

| Elemento | Razón |
|---|---|
| `extends="GenericUnityGame"` en archivos XML de juegos | Causaba herencia incorrecta de `Assembly-CSharp-firstpass.dll` — eliminado de Subnautica, Raft, EscapeThePacific, GH |
| Diseño `WrapPanel` en pestaña Mods | Reemplazado con diseño Grid de 3 columnas (Filtro de Juegos / Lista de Mods / Información) |

---

## Cambios Principales por Fase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Los 5 proyectos migrados de .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub de UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Sistema de 3 temas, `theme.cfg`, corrección de arrastre de ventana, soporte de hipervínculos.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Sistema de inicio de sesión eliminado, mecanismo de actualización modernizado.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Pestaña Downloads, iconos Segoe MDL2 Assets, soporte de 13 idiomas.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, parcheo de encabezado PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Pantalla negra corregida, `ValueTuple` eliminado, C# 7.3 verificado en el juego.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 filtros de juegos, pestaña Mods de 3 columnas, constructor ligero `Game`, XML registrado.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML corregido, ruta de Steam, seguridad de ruta de juego, validación de 5 pasos para Inicio de Juego, validación de 3 pasos para ModLib, verificación de encabezado PE `FileValidator`, división de compilación `#if DEBUG`, `create_dummy_Debug_games.ps1`, corrección de constructor ligero `ModLibrary`, corrección de GamePath en `SwitchDevGame`, creación de carpetas para 5 juegos, correcciones de caídas.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Pestaña Themes añadida, 10 temas + función de textura de fondo, separación de carpeta Themes/, corrección de botón maximizar, corrección de expansión de ruta de juego, actualización de Versions.xml para 4 juegos, botones de reinicio de ruta, auto-guardado Browse, MODAPI_VersionTool.

---

## Historial de Versiones

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool añadido (herramienta WPF independiente de actualización de versión), visualización de versión en StatusBar vinculada a App.Version

### v2.0.9617 — 2026-04-24
Botones de reinicio de ruta Steam/juego añadidos en pestaña Settings, auto-guardado Browse, estado de reinicio preservado vía flag ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml creado/actualizado para 4 juegos (Subnautica, Raft, EscapeThePacific, GH), reglas de composición de checksum establecidas, procedimiento de actualización de juego documentado

### v2.0.9615 — 2026-04-18
Corrección de precisión de altura de expansión de tarjeta de ruta de juego en Settings, prevención de interferencia de textura de fondo en UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Botón maximizar con maximización manual basada en WorkArea, guardado y restauración de tamaño/posición anterior

### v2.0.9613 — 2026-04-18
Pestaña Themes añadida, estructura de registro de temas basada en datos, 10 temas soportados, función de textura de fondo (compresión, seguridad, transparencia de 2 capas), overlay de bloqueo ThemeSelector, 12 nuevas claves de idioma

### v2.0.9612 — 2026-04-18
Separación de carpeta Themes/, modularización XAML de temas

### v2.0.9611 — 2026-04-18
Corrección de ancho de lista de mods no aplicado después de cambio de tema

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 game filters, Mods tab 3-column layout, auto width, lightweight `Game` constructor, `ModsViewModel` game filtering, 4 XML files registered, build warnings cleaned, Welcome tab, language flags standardized

### v2.0.9586 — 2026-03-31
Black screen fixed, polyfill finalized, ValueTuple removed, C# 7.3 verified

### v2.0.9561 — 2026-03-06
C# 7.3 support, PE header patching, polyfill pipeline, assembly resolution restored

### v2.0.9552 — 2026-02-25
Downloads tab, icon modernization, theme unification, 13-language support

### v2.0.9500
Theme system (Classic/Light/Dark), Fluent Design UI, SubWindow system

### v2.0.9400
Code cleanup, login removal, legacy modernization

### v2.0.9300
Build environment, UnityEngine stub DLL, ModernWpf integration

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Requisitos de Compilación

| Requisito | Versión | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Proyectos ModAPI |
| .NET Framework SDK | 3.5 | Solo BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licencia

GNU General Public License v3.0 — sigue la licencia original.
