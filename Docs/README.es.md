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

# ModAPI(v1) v2.0.9622 - 20260808

**Herramienta de Gestión de Mods para The Forest — Edición Mejorada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemania)
> Mejora: zzangae (República de Corea)

---

## Descripción General

ModAPI es una aplicación de escritorio para gestionar mods de **5 juegos oficialmente compatibles**. Esta edición mejorada incluye compatibilidad multijuego, una pestaña Settings completamente rediseñada, configuración de la ruta de Steam, ajustes de interfaz persistentes, un sistema dinámico de tamaño de fuente, validación al iniciar el juego, separación de compilaciones Debug/Release y numerosas correcciones de fallos verificadas mediante pruebas en el juego.

---

## Juegos Compatibles

| Juego | Motor | Versión | ID de Steam | Ejecutable |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Parche 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 5 (mejorado desde Unity 4) |
| Última versión | v1.12 (VR) |
| Última actualización | 11 de septiembre de 2019 — parche de compatibilidad con VR; sin más actualizaciones importantes de contenido |
| Ejecutable | `TheForest.exe` |
| Carpeta de datos | `TheForest_Data/Managed/` |
| Carpeta de mods | `mods/TheForest/` |
| Carpeta de proyectos | `projects/TheForest/` |
| ID de app de Steam | `242760` |
| IL2CPP | ❌ Mono — totalmente compatible |

The Forest fue actualizado de Unity 4 a Unity 5, mejorando notablemente los gráficos y la física. El parche de VR de septiembre de 2019 fue la última actualización importante. El juego se mantiene ahora en un estado estable y finalizado, ideal para el modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity (base de código integrada, unificada con Below Zero en 2022) |
| Última versión | Parche 2025 (v18810395) |
| Última actualización | 12 de agosto de 2025 — corrección de errores y mejoras de rendimiento junto con el lanzamiento móvil |
| Ejecutable | `Subnautica.exe` |
| Carpeta de datos | `Subnautica_Data/Managed/` |
| Carpeta de mods | `mods/Subnautica/` |
| Carpeta de proyectos | `projects/Subnautica/` |
| ID de app de Steam | `264710` |
| IL2CPP | ❌ Mono — compatible |

Originalmente construido sobre Unity 5, Subnautica recibió la actualización "Living Large" (v2.0) a finales de 2022, que fusionó la base de código del motor con Below Zero para mejorar la optimización y la estabilidad. Nota: la próxima *Subnautica 2* utiliza Unreal Engine 5.

> **XML reescrito en v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` añadidos a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity |
| Última versión | v1.1.02 (Beta) / v1.09 (Stable) |
| Última actualización | Marzo de 2026 — correcciones de errores de chat de voz y multijugador a través de la rama beta |
| Ejecutable | `Raft.exe` |
| Carpeta de datos | `Raft_Data/Managed/` |
| Carpeta de mods | `mods/Raft/` |
| Carpeta de proyectos | `projects/Raft/` |
| ID de app de Steam | `648800` |
| IL2CPP | ❌ Mono — compatible |
| Versions.xml | `1.1.01` (con suma de comprobación) |

Tras la conclusión oficial de la historia en v1.0: *The Final Chapter*, los parches han continuado para mejorar el código de red y la estabilidad. Una actualización de la rama beta en marzo de 2026 solucionó problemas de chat de voz y multijugador.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 6 (migrado desde Unity 2021/2022 a finales de 2025) |
| Última versión | v0.67.0.0 |
| Última actualización | 26 de junio de 2025 — rediseño de la distribución de islas y actualización del motor; hotfixes en curso hasta 2026 |
| Ejecutable | `EscapeThePacific.exe` |
| Carpeta de datos | `EscapeThePacific_Data/Managed/` |
| Carpeta de mods | `mods/EscapeThePacific/` |
| Carpeta de proyectos | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — compatible |

Completó una importante reconstrucción del sistema y la migración a Unity 6 a finales de 2025, lo que permite entornos más dinámicos. El juego permanece en desarrollo activo de Acceso Anticipado.

> **XML reescrito en v2.0.9610**: `extends="GenericUnityGame"` eliminado; `includeAssembly` configurado únicamente con `Assembly-CSharp.dll` — evita errores de herencia de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Elemento | Valor |
|---|---|
| Motor | Unity 2019 |
| Última versión | v2.9.5 |
| Última actualización | 4 de febrero de 2026 — optimización para Steam Deck y mejoras en la legibilidad del texto |
| Ejecutable | `GH.exe` |
| Carpeta de datos | `GH_Data/Managed/` |
| Carpeta de mods | `mods/GH/` |
| Carpeta de proyectos | `projects/GH/` |
| ID de app de Steam | `763790` |
| IL2CPP | ❌ Mono — compatible |
| Versions.xml | `2.9.5` (con suma de comprobación) |

Desarrollado a través de Unity 2017 → 2018 → 2019 a lo largo de su ciclo de vida. El hotfix de febrero de 2026 se centró en la compatibilidad con Steam Deck y la legibilidad de la interfaz.

> **XML reescrito en v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` añadidos; `DOTweenPro.dll` (inexistente) eliminado.
</details>

---

<details>
<summary><b>Arquitectura</b></summary>

### División del Entorno de Ejecución

| Componente | Objetivo | Entorno de ejecución | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplicación de escritorio, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteca compartida |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fijado de forma permanente** — el encabezado PE debe indicar `v2.0.50727` |
| DLLs de mods (usuario) | .NET Framework 4.8 | Game Mono 2.0 (parcheado) | Compilado con 4.8, encabezado PE parcheado al aplicar |

### Herramientas para Desarrolladores

Utilidades WPF independientes para la gestión de proyectos. No se distribuyen a los usuarios finales.

| Herramienta | Proyecto | Propósito |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Actualiza `AssemblyInfo.cs` y la versión de `App.xaml.cs` simultáneamente |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Gestiona archivos de idioma — añadir, editar, desactivar, integración nativa |

**VersionTool — Gestión de Versiones**

Una herramienta WPF independiente para actualizar el número de versión con un solo clic.

- Muestra automáticamente la versión actual (leída de `App.xaml.cs`)
- Introduzca una nueva versión y haga clic en **Apply Version** para actualizar ambos archivos simultáneamente
- Validación de formato: solo se acepta el formato `X.X.XXXX`

| Archivo | Ruta | Cambio |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Sistema de Idiomas**

```
resources/langs/langs.json          ← Registro de idiomas (indicadores builtin / active)
resources/langs/Language.XX.xaml    ← Claves de traducción por idioma
resources/langs/Language.XX.png     ← Imagen de bandera (36×24, de flagcdn.com/h24/)
```

Flujo de integración nativa (botón Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() reescrito (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml registrado (ModAPI\ModAPI.csproj)
  → Próxima compilación: idioma completamente integrado, disponible sin conexión
```

### División de Compilaciones Debug / Release

Toda la validación de archivos y el procesamiento de ensamblados se ramifican según la configuración de compilación mediante `#if DEBUG` / `#else`.

| Ubicación | Compilación Debug | Compilación Release |
|---|---|---|
| `CheckSteam()` | solo `File.Exists()` — los archivos ficticios pasan | `FileValidator.IsValidSteamExe()` — encabezado PE + mín. 1 MB |
| `CheckGamePath()` | solo `File.Exists()` — los archivos ficticios pasan | `FileValidator.IsValidAssemblyDll()` — encabezado PE + metadatos CLR + mín. 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — omite el análisis de Cecil | Análisis completo de Mono.Cecil + modificación de IL + `module.Write()` |
| `ModLib.Create()` — archivo no encontrado | Registra advertencia, omite y continúa | Registra error, aborta con ventana emergente |

**Las pruebas en Debug** usan `create_dummy_Debug_games.ps1` para generar archivos de marcador de posición de 0 bytes en `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` y `bin\Debug\gamefiles\original\`. Estos superan las comprobaciones de `File.Exists()` y permiten probar el flujo de trabajo completo de la interfaz sin una instalación real del juego.

**Las compilaciones Release** aplican `FileValidator` (verificación de encabezado PE + metadatos CLR de .NET) para rechazar archivos de 0 bytes, archivos de texto y binarios arbitrarios. Solo se aceptan ejecutables de Windows y ensamblados .NET válidos.

### FileValidator — Verificación de Encabezado PE

`ModAPI_Shared\Utils\FileValidator.cs` — se aplica únicamente en compilaciones Release.

| Método | Comprobaciones | Tamaño mínimo |
|---|---|---|
| `IsValidSteamExe(path)` | Firma MZ + firma PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Firma MZ + firma PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + encabezado de metadatos CLR (directorio de datos #14) | 8 KB |

```
Diseño del encabezado PE verificado:
[0x00] 4D 5A          ← firma DOS "MZ"
[0x3C] XX XX XX XX   ← desplazamiento del encabezado PE (little-endian)
[offset] 50 45 00 00 ← firma "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← presencia del encabezado CLR de .NET
```

### Pipeline de Remapeo de Ensamblados

```
[El desarrollador del mod compila con .NET 4.8]
  → Mod DLL: encabezado PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, etc.
  → modModule.RuntimeVersion = "v2.0.50727"
      encabezado PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → encabezado PE aceptado ✅  →  referencias resueltas ✅
```

### Resolución de Respaldo de Ensamblados

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← carpeta de respaldo
2. {ActualGameInstallPath}/{AssemblyPath}        ← carpeta de instalación del juego (respaldo)
```

### Compatibilidad con Funciones de C# 7.3

| Función | Estado | Notas |
|---|---|---|
| Coincidencia de patrones (`is`, `switch`) | ✅ | Verificado en el juego |
| Interpolación de cadenas (`$""`) | ✅ | Verificado en el juego |
| Variable `out` en línea | ✅ | Verificado en el juego |
| `async` / `await` | ✅ | Mediante AsyncBridge + polyfills de System.Threading |
| Tuplas (`ValueTuple`) | ❌ Límite estricto | ABI de `mscorlib` de Mono 2.0 — sin solución alternativa |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Desde la v2.0.9613, la interfaz de selección de temas se trasladó de la pestaña Settings a una pestaña **Themes** dedicada. Añadir un nuevo tema solo requiere una línea en el diccionario de `App.xaml.cs`.

| Índice | ID | Archivo | Paleta |
|---|---|---|---|
| 0 | `classic` | solo `Dictionary.xaml` | Fondo de textura original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono claro + acento azul |
| 2 | `dark` | `FluentStyles.xaml` | Tono oscuro + acento azul (predeterminado) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rojo + negro |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espacio oscuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Atardecer brillante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océano oscuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brillante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brillante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brillante |

El cambio de tema provoca un reinicio automático de la aplicación. (guardado en `theme.cfg`)

| Tema | Tema |
| :---: | :---: |
|**01. Tema Classic**|**02. Tema Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Tema Dark**|**04. Tema Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Tema Nebula**|**06. Tema Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Tema Ocean**|**08. Tema Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Tema Citrus**|**10. Tema Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### Textura de Fondo

Seleccione una imagen en la tarjeta **Background Texture** de la pestaña Themes para aplicarla como fondo en toda la aplicación. Formatos compatibles: `.png` / `.jpg` / `.jpeg`, hasta 50 MB, resolución 4K o inferior. La imagen se comprime como JPEG Q75 con un encabezado mágico de 16 bytes y se guarda como `resources\textures\ui_bg\bg.dat` (atributo Hidden). Hash SHA-256 para verificación de integridad; la manipulación provoca un restablecimiento automático + ventana emergente de advertencia.

Cuando el fondo está activo, la transparencia de la interfaz se procesa en dos capas: la Capa 1 (superposición de MergedDictionaries) para paneles `{DynamicResource}`, la Capa 2 (WalkStyleBackgrounds) para paneles basados en `{StaticResource}` con semitransparencia.

### Sistema de Tamaño de Fuente

| Clave de recurso | Base | Descripción |
|---|---|---|
| `AppBaseFontSize` | 13 | Texto normal |
| `AppBaseHeaderFontSize` | 16 | Encabezados, títulos de panel |
| `AppBaseSmallFontSize` | 12 | Etiquetas secundarias |
| `AppBaseTinyFontSize` | 10 | Texto de sugerencia |
| `AppBaseLargeFontSize` | 20 | Texto de visualización grande |

### Configuración Persistente de la Interfaz — `ui.cfg`

| Clave | Predeterminado | Descripción |
|-----|---------|-------------|
| `ModListWidth` | `150` | Ancho de la lista en la pestaña Mods (px) |
| `ProjectListWidth` | `150` | Ancho de la lista de proyectos en la pestaña Development (px) |
| `AppFontSize` | `13` | Tamaño de fuente global de la interfaz (px) |
| `AlwaysOnTop` | `false` | Ventana siempre visible |
| `TexturePath` | *(ninguno)* | Nombre de archivo original de la textura de fondo (solo visualización) |
| `TextureHash` | *(ninguno)* | Hash SHA-256 de la textura de fondo |
| `TextureActive` | `false` | Estado de activación de la textura de fondo |
| `GamePathReset_{GameId}` | *(ninguno)* | Indicador de restablecimiento de la ruta del juego |
| `SteamPathReset` | *(ninguno)* | Indicador de restablecimiento de la ruta de Steam |
</details>

<details>
<summary><b>Estructura del Proyecto</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Ajustes persistentes de la interfaz
├── theme.cfg                            # Tema actual
├── Windows/
│   ├── MainWindow.xaml / .cs            # Interfaz principal — 6 pestañas, Themes, Settings, ruta de Steam,
│   │                                    #   protección contra descargas de 0 bytes, debounce del deslizador, lecturas silenciosas de configuración
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Ventana emergente de ruta del juego (GameNameLabel dinámico)
│       ├── FirstSetup.xaml / .cs        # Configuración inicial + inicialización de valores predeterminados
│       └── (otras 14 SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Tema Classic
│   ├── FluentStyles.xaml                # Tema Dark
│   ├── FluentStylesLight.xaml           # Tema Light
│   ├── FluentStylesDiablo.xaml          # Tema Diablo
│   ├── FluentStylesNebula.xaml          # Tema Nebula
│   ├── FluentStylesSunset.xaml          # Tema Sunset
│   ├── FluentStylesOcean.xaml           # Tema Ocean
│   ├── FluentStylesNordic.xaml          # Tema Nordic
│   ├── FluentStylesCitrus.xaml          # Tema Citrus
│   └── FluentStylesBloom.xaml           # Tema Bloom
├── Data/
│   ├── Mod.cs                           # Carga de archivos de mods, análisis de encabezado LF/CRLF, registro de diagnóstico
│   ├── ModLib.cs                        # Generación de BaseModLib + remapeo (separación #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Creación/compilación/aplicación de proyectos + protecciones null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   prevención de reintentos de mods dañados
│   │   ├── ModViewModel.cs              # GameId a partir de la ruta de la carpeta
│   │   ├── ModProjectsViewModel.cs      # Dispose() para DispatcherTimer
│   │   └── SettingsViewModel.cs         # Valor predeterminado true para UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mapeo de versiones de ensamblados Mono 2.0 (20 ensamblados)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolutor basado en nombres con caché
│   └── MonoHelper.cs                    # Utilidades auxiliares de IL de Mono.Cecil
├── resources/
│   ├── langs/                           # 13 archivos de idioma + langs.json (claves LangTool.* añadidas en v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Imagen de fondo comprimida y protegida (generada en tiempo de ejecución)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Reescritura completa en v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Reescritura completa en v2.0.9610
    │   ├── GH.xml                       # Reescritura completa en v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — no compatible
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt con parámetro silent
├── Data/
│   ├── Game.cs                          # Creación automática de copia de seguridad de ApplyMods, resolutor condicional,
│   │                                    #   respaldo a carpeta del juego, corrección de inicialización de ModLib + constructor ligero
│   └── ModLib.cs                        # Separación #if DEBUG, respaldo a carpeta del juego para IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Validación de encabezado PE + metadatos CLR (solo Release, mín. 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Herramienta WPF independiente de actualización de versión
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Entrada de versión, botón Apply, visualización de versión actual
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Herramienta WPF independiente de gestión de idiomas
├── App.xaml / App.xaml.cs              # Carga/cambio de idioma, langtool.cfg
├── MainWindow.xaml / .cs               # Interfaz principal — lista de idiomas, panel de edición, selector de ruta
├── AddLanguageDialog.xaml / .cs        # ComboBox de selección de país ISO 3166-1
├── ModApiDialog.xaml / .cs             # Diálogo personalizado con estilo ModAPI (Info/Advertencia/Confirmar/Preguntar)
├── Models/
│   ├── LanguageEntry.cs                # Modelo de entrada de idioma (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Modelo raíz de langs.json
│   └── IsoCountry.cs                   # Modelo de país ISO para ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Lectura/escritura de langs.json
    ├── FlagDownloader.cs               # Descarga de banderas de flagcdn.com h24
    ├── XamlGenerator.cs                # Generación/guardado/análisis de Language.XX.xaml
    ├── MissingKeyDetector.cs           # Detección de claves faltantes usando el inglés como referencia
    ├── IsoCountryList.cs               # Lista completa de países ISO 3166-1 (196 países, sin conexión)
    └── BuiltinCodeWriter.cs            # Reescritura de CreateDefaultLangsJson() + registro en ModAPI.csproj

bin\Debug\                               # Solo para pruebas Debug
├── create_dummy_Debug_games.ps1         # Genera estructura ficticia de juego/Steam
├── dummy_games\{GameId}\               # Rutas ficticias de instalación de juegos
├── dummy_steam\Steam.exe               # Ejecutable ficticio de Steam
└── gamefiles\original\{GameId}\        # Rutas ficticias de respaldo para ModLib
```

---

</details>

<details>
<summary><b>Instalación y Configuración</b></summary>

### Paso 1 — Requisitos Previos

| Elemento | Requerido |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (preinstalado en Windows 11; [descargar](https://dotnet.microsoft.com/download/dotnet-framework/net48) para Windows 10) |
| Steam | Requerido — debe configurarse en la pestaña Settings |
| Al menos un juego compatible | Requerido — debe configurarse en la pestaña Settings |

### Paso 2 — Instalar ModAPI

1. Descargue la última versión desde GitHub
2. Extraiga a cualquier carpeta (p. ej., `C:\ModAPI\`)
3. Ejecute `ModAPI.exe`
4. En el primer inicio aparece la pantalla **Welcome** — configure las preferencias y haga clic en **Continue**

### Paso 3 — Configurar la Ruta de Steam (Pestaña Settings)

1. Vaya a la pestaña **Settings**
2. Busque **Steam Installation Path**
3. Haga clic en **Browse** → seleccione `Steam.exe`
4. Haga clic en **Save**

### Paso 4 — Configurar Rutas de Juegos (Pestaña Settings)

1. Haga clic en el encabezado de la tarjeta de un juego para expandirla
2. Haga clic en **Browse** → seleccione la carpeta raíz del juego (donde se encuentra el `.exe`)
3. Haga clic en **Save**

| Juego | Ejecutable | Ruta de ejemplo |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Paso 5 — Descargar Mods (Pestaña Downloads)

1. Vaya a la pestaña **Downloads**
2. Seleccione un juego en el filtro de juegos
3. Busque o explore un mod y haga clic en **Download**

> **Sin conexión**: Descargue los archivos `.mod` manualmente desde `modapi.survivetheforest.net` y colóquelos en la carpeta correspondiente:

| Juego | Carpeta |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Paso 6 — Aplicar Mods e Iniciar el Juego (Pestaña Mods)

1. Vaya a la pestaña **Mods**
2. Seleccione un juego en **Game Filter** (columna 0)
3. Marque los mods a activar en **Mod List** (columna 1)
4. Haga clic en **Start Game**

Antes del inicio se ejecutan automáticamente las siguientes comprobaciones:

| # | Comprobación | Ventana emergente en caso de fallo |
|---|---|---|
| 1 | Ruta de Steam configurada y válida | SteamNotFound |
| 2 | El juego de la carpeta `mods/` coincide con la ruta del juego en Settings | GameModsMismatch |
| 3 | Al menos un mod seleccionado | NoModSelected |
| 4 | Sin mods de juegos mezclados en la selección | MixedGameMods |
| 5 | Ruta del juego configurada y ejecutable existente | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Descripción General de las Pestañas</b></summary>

### Pestaña Welcome
Pantalla de configuración inicial (índice de pestaña 0). Configure AutoUpdate, la conexión con Steam y las preferencias de la tabla VersionsData. En inicios posteriores, esta pestaña ofrece enlaces de la comunidad y notas de la versión.

### Pestaña Mods
Flujo de trabajo principal de gestión de mods — diseño de 3 columnas:

| Columna | Contenido |
|---|---|
| Columna 0 | Game Filter — botones de opción para los 5 juegos compatibles |
| Columna 1 | Mod List — mods instalados con selector de versión y casilla de activación |
| Columna 2 | Information — detalles, descripción e historial de versiones del mod seleccionado |

### Pestaña Downloads
Explore y descargue mods desde `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 categorías (correcciones de errores, balance, trucos, …)
- **Search**: por nombre de mod, descripción o autor
- **Offline mode**: muestra instrucciones de carpetas para los 5 juegos compatibles

### Pestaña Development
Flujo de trabajo de desarrollo de mods — el panel de filtro de juegos (columna 0) cubre los 5 juegos compatibles.

- Crear, compilar y aplicar proyectos de mods por juego
- Gestión de recursos de idioma
- Generación de ModLib con validación de 3 pasos (Steam → proyecto → ruta del juego)
- Cambio seguro de juego mediante un constructor `Game` ligero (sin llamada a `Verify()`)

### Pestaña Themes
Selección de temas y gestión de la textura de fondo.

- **Selección de tema**: 10 temas (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Textura de fondo**: seleccione una imagen como fondo de toda la aplicación (compresión JPEG + procesamiento de seguridad)
- Cuando la textura de fondo está activa, la selección de tema queda bloqueada

### Pestaña Settings
Configuración centralizada — 4 filas:

| Fila | Contenido |
|---|---|
| 0 | Idioma / Tamaño de fuente / Ancho máximo / Ancho de Mod List / Ancho de Project List |
| 1 | Mantener VersionsData / Actualización automática / Conexión con Steam / Siempre visible |
| 2 | Steam Installation Path (cuadro de texto + Browse + Save + Reset) |
| 3 | Game Installation Paths — tarjeta expandible por juego (cuadro de texto + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Herramienta de Gestión de Idiomas)

Una herramienta WPF independiente para gestionar los archivos de idioma de ModAPI. Añadida a la solución como `LangTool\MODAPI_LangTool.csproj`.

**Ubicación**: `LangTool\MODAPI_LangTool.csproj`

**Funciones Principales**

| Función | Descripción |
|---|---|
| Lista de idiomas | Muestra todos los idiomas de `langs.json` con iconos de estado (🔒 integrado / 🚫 inactivo / ✅ activo) |
| Añadir idioma | Seleccione un país en el ComboBox ISO 3166-1 → la bandera se descarga automáticamente de `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` se genera automáticamente a partir de la plantilla en inglés |
| Editar idioma | `isoCode` / `langCode` bloqueados; `langName` y las claves de traducción son editables cuando está activo |
| Desactivar / Activar | Alterna el indicador `active` en `langs.json` — el archivo se conserva, oculto de la lista de ModAPI |
| Actualizar (integración nativa) | Convierte `builtin: false` → `true` — irreversible, confirmación en 2 pasos — reescribe automáticamente `CreateDefaultLangsJson()` en el código fuente y registra `Language.XX.xaml` en `ModAPI.csproj` |
| Detección de claves faltantes | Compara con la referencia en inglés — muestra el número de claves faltantes/vacías y el progreso de la traducción |
| Protección de integrados | Los idiomas con `builtin: true` son de solo lectura — no se permite editar, desactivar ni actualizar |
| Protección de inactivos | Los idiomas con `active: false` son de solo lectura hasta que se reactiven |
| Interfaz de idioma | El propio LangTool admite los 13 idiomas de ModAPI — selector de idioma con bandera en la esquina superior derecha |
| Memoria de ruta | La ruta raíz de ModAPI seleccionada se guarda en `langtool.cfg` — se carga automáticamente en el próximo inicio |
| Diálogos personalizados | Todas las ventanas emergentes usan el `ModApiDialog` de tema oscuro al estilo de ModAPI en lugar del MessageBox del sistema |

**Estructura de langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Convención de Imágenes de Bandera**

```
Código ISO (minúsculas) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                          resources/langs/
```

**Comportamiento del Botón Update**

Al hacer clic en el botón Update en un idioma activo no integrado:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` se reescribe con todos los idiomas actualmente `builtin: true`
3. `ModAPI\ModAPI.csproj` — se registra `<Resource Include="resources\langs\Language.XX.xaml" />`
4. Próxima compilación — idioma completamente integrado, disponible sin conexión

**Claves de Idioma Añadidas** (`Lang.LangTool.*`)

Se añadieron 53 claves nuevas a los 13 archivos de idioma que cubren todas las cadenas de la interfaz de LangTool, mensajes de diálogo y textos de estado.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Herramienta de Actualización de Versión)

Una herramienta WPF independiente para actualizar el número de versión con un solo clic.

**Ubicación**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Funciones**
- Muestra automáticamente la versión actual (leída de `App.xaml.cs`)
- Introduzca una nueva versión y haga clic en **Apply Version** para actualizar ambos archivos simultáneamente
- Validación de formato: solo se acepta el formato `X.X.XXXX`

**Archivos Modificados**

| Archivo | Ruta | Cambio |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Uso**
1. Ejecute `MODAPI_VersionTool.exe`
2. Introduzca la nueva versión (p. ej., `2.0.9619`)
3. Haga clic en **Apply Version**
4. Reconstruya la solución ModAPI en Visual Studio

**Visualización de Versión en StatusBar**

- `VersionLabel.Text` ahora hace referencia a `App.Version` en lugar de un descriptor codificado
- Al actualizar la versión con VersionTool y reconstruir, se refleja de inmediato en el StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Sistema de Registro — Separación en Dos Archivos (`ModAPI.log` / `ModAPI.detailed.log`)

Los registros de diagnóstico exclusivos para desarrolladores estaban antes limitados a `#if DEBUG`, lo que significaba que eran invisibles en las compilaciones Release justo cuando más se necesitaban para solucionar el problema de un usuario. Un sistema de dos archivos reemplaza esto:

| Archivo | Contenido |
|---|---|
| `ModAPI.log` | Registro principal orientado al usuario — sin cambios en apariencia, no más ruidoso que antes |
| `ModAPI.detailed.log` | Cada llamada de registro, siempre, tanto en Release como en Debug — para diagnosticar problemas reportados por usuarios |

**`Debug.cs`** — `Log()` tiene un parámetro `detailedOnly`. Cuando es `true`, el mensaje se escribe únicamente en `ModAPI.detailed.log`; todos los bloques `#if DEBUG` anteriores se convirtieron a este indicador en lugar de compilarse por completo, por lo que siempre se capturan en el archivo detallado incluso en Release. Esto resulta en un modelo de severidad de 4 niveles:

| Nivel | Significado |
|---|---|
| Verbose (`detailedOnly: true`) | Trazas repetitivas/mecánicas — por tipo, por archivo, por método |
| Notice | Flujo legible para humanos — mensajes de progreso y éxito |
| Warning | Problemas potenciales, aún no son fallos |
| Error | Fallos confirmados |

**Fuentes de ruido de registro identificadas y convertidas a `detailedOnly: true`:**

| Archivo | Qué inundaba `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Mensajes de escaneo/omisión/cola de `FindMods()` repetidos en cada sondeo de 1 segundo |
| `Game.cs` | Líneas de traza TLS/URL de `UpdateVersions()`, entradas de mapeo de tipos de Cecil |
| `ModLib.cs` | Procesamiento de ensamblados por tipo/método de Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — responsable de la gran mayoría del volumen de `ModAPI.log` (decenas de miles de líneas para la compilación de un único mod de Green Hell) |
| `Mod.cs` | Volcado completo del XML de encabezado del mod (`configuration.ToString()`) registrado íntegramente en cada carga de mod |

**Registro de discrepancias de suma de comprobación — resumido en lugar de por elemento:** `Header.Verify()` registraba antes una línea `Mismatched checksum at "..."` por cada entrada incompatible de `InjectInto`/`AddMethod`/`AddField`/`AddClass`, lo que podía significar docenas de líneas para un único mod desactualizado. Ahora registra un único resumen de nivel Warning en `ModAPI.log` (p. ej., `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), mientras que el desglose completo por elemento sigue disponible en `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Cambios en la v2.0.9622</b></summary>

## Cambios en la v2.0.9622

### Corrección de Error — Cálculo de Checksum Unificado

La verificación de integridad de `StartGame()` (Verificación B) recalculaba el checksum por su cuenta mediante `FileValidator.ComputeAssemblyChecksum()`, que solo calcula el hash de un par fijo de archivos (`Assembly-CSharp` + `Assembly-CSharp-firstpass`). Esto no encajaba estructuralmente con juegos como The Forest, que enlazan 4 archivos (firstpass + principal + UnityScript-firstpass + UnityScript) — la verificación reportaba una discrepancia de checksum falsa incluso cuando los archivos del juego no habían sido tocados.

- `Game.CheckSumGame` (ya calculado correctamente por `GenerateCheckSums()` en el momento de `Verify()`, siguiendo la lista real `VersionsData.CheckFiles` de cada juego — 2 archivos para Green Hell, 4 para The Forest, etc.) ahora se expone como `public` y se reutiliza directamente en `StartGame()` en lugar de recalcularse con un conjunto de archivos distinto y fijo.
- El cálculo del checksum ahora está unificado en una única fuente de verdad (`GenerateCheckSums()`), sin importar cuántos archivos necesite realmente cada juego.

### Archivos modificados

| Archivo | Ruta | Cambio |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | `CheckSumGame` cambiado de `protected` a `public` |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | La verificación de integridad de `StartGame()` reutiliza `targetGame.CheckSumGame` en lugar de recalcular mediante `FileValidator.ComputeAssemblyChecksum()` |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9621</b></summary>

## Cambios en la v2.0.9621

### Nuevas funciones

#### Detección automática en toda la biblioteca de Steam

`FindGamePath()` ahora, si un juego no se encuentra mediante sus `SearchPaths` predefinidos, busca también en **todas las bibliotecas de Steam registradas en el sistema** (analizadas una vez desde `libraryfolders.vdf`, almacenadas en caché durante la sesión). Esto se aplica a los 5 juegos compatibles, no solo al que está activo actualmente.

- Nuevo `Game.GetSteamLibraryFolders()` — analiza `libraryfolders.vdf`, en caché estática por sesión
- Controlado por la casilla **Conexión con Steam**: desactivada (valor predeterminado en instalación nueva) → se omite la detección automática para los 5 juegos, las rutas quedan vacías hasta configurarlas manualmente. Activada → los 5 juegos se buscan de forma consistente con el mismo método.

#### Detección automática de mods de otro juego

Un archivo `.mod` colocado en la carpeta de un juego equivocado (por ejemplo, un mod de Green Hell copiado en `mods\TheForest\`) ahora se detecta automáticamente en lugar de corromper silenciosamente una operación de aplicación.

- `Game.CheckModGameCompatibility()` (usado dentro de `ApplyMods()`) verifica que cada tipo `AddMethod`/`AddField`/`InjectInto` declarado por un mod exista realmente en los ensamblados reales del juego de destino antes de comenzar la inyección. Los mods no compatibles se excluyen automáticamente de esa aplicación; el resto se aplica con normalidad.
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` ejecutan la misma verificación al cargar el mod (ligera: lee los bytes del ensamblado en memoria, extrae los nombres de tipo y libera el archivo de inmediato). Los mods no compatibles muestran una **insignia de advertencia ⚠** con información sobre herramientas en la pestaña Mods, antes incluso de pulsar Aplicar.
- Si se excluyeron mods y/o finalmente no se aplicó nada, Iniciar Juego muestra un único popup combinado en lugar de varios apilados; el juego no se inicia si no queda ningún mod aplicado (`Game.LastAppliedModCount`).

#### Pestaña Configuración — Registro de desarrollador / Borrar registros al iniciar

Dos casillas nuevas, después de **Conexión con Steam** y antes de **Siempre visible**:

| Clave | Descripción |
|---|---|
| `Lang.Options.Labels.DevLog` | Activa `ModAPI.dev.log` (renombrado de `ModAPI.detailed.log`) — equivale a ejecutar con `--dev` |
| `Lang.Options.Labels.ClearLogsOnStart` | Borra la carpeta `logs\` en cada inicio |

`Debug.ClearLogs()` cierra los flujos de registro abiertos antes de borrar archivos, evitando errores de "archivo en uso".

#### Registro global de excepciones no controladas

`App.xaml.cs` ahora engancha `DispatcherUnhandledException` (hilo de interfaz) y `AppDomain.UnhandledException` (hilos en segundo plano). Las excepciones que antes hacían fallar la aplicación sin dejar rastro ahora se registran con tipo, mensaje y traza de pila completa antes de que el proceso finalice.

---

### Correcciones críticas de errores

| # | Archivo | Problema | Corrección |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` resolvía una ruta explícitamente restablecida (cadena vacía) como `RootPath` en lugar de `""`, porque `Path.GetFullPath(RootPath + separador + "")` se reduce a `RootPath` | Los valores almacenados vacíos ahora devuelven `""` directamente, antes de la unión de rutas |
| 2 | `MainWindow.xaml.cs` | El orden de validación de Iniciar Juego difería entre el filtro "Todos" y un filtro específico, mostrando a veces un popup de selección de mod o juego antes de un problema más fundamental (falta de ruta de Steam/juego) | Ambas rutas siguen ahora el mismo orden: Steam → ruta del juego → selección de mods → selección de juego |
| 3 | `MainWindow.xaml.cs` | La recopilación de mods para Iniciar Juego ignoraba el filtro de juego activo — los mods marcados de otro juego (invisible) seguían contándose, provocando el popup equivocado | La recopilación de mods ahora respeta el filtro actual; solo "Todos" agrega entre todos los juegos |
| 4 | `ModsViewModel.cs` | `Mod.Mods` se indexaba solo por `{ModId}-{Versión}`, por lo que nombres de archivo idénticos en dos carpetas de juego distintas colisionaban — el `Load()` del segundo nunca se llamaba | La clave ahora incluye el GameId: `{GameId}-{ModId}-{Versión}` |
| 5 | `ModsViewModel.cs` | Tras la corrección #4, `UpdateMods()` seguía agrupando las entradas de la lista solo por ModId, fusionando dos mods con el mismo nombre de juegos distintos en una sola entrada — fallaba con `ArgumentException: An item with the same key has already been added` cuando ambos declaraban la misma versión | La agrupación de la pantalla ahora también compara el GameId |
| 6 | `Game.cs` | La lista `<files>` del `Versions.xml` de Green Hell contiene los mismos dos archivos dos veces con distinta capitalización (`_Data`/`_data`); `CheckFiles` era un `HashSet<string>` sensible a mayúsculas, por lo que ambos se procesaban con hash, duplicando la suma de comprobación calculada y provocando falsos fallos de integridad | `CheckFiles` ahora usa `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | El paso de "eliminar archivos antiguos" de `ModLib.Create()` no tenía protección de reintento contra un `BaseModLib.dll` bloqueado, y `Game.CreateModLibrary()` no tenía manejo de excepciones — un bloqueo hacía fallar toda la aplicación en un hilo en segundo plano | Se añadió un bucle de reintento de 10×500 ms al paso de eliminación; `CreateModLibrary()` ahora envuelve la llamada en try/catch |
| 8 | `MainWindow.xaml.cs` | Si `ApplyMods()` terminaba sin aplicar realmente ningún mod (por ejemplo, todos excluidos), seguía señalando la finalización igual que un éxito real, por lo que el juego se iniciaba sin ninguna modificación | `Game.LastAppliedModCount` distingue "nada aplicado" de "N aplicados"; el inicio se omite en 0 |
| 9 | `MainWindow.xaml.cs` | La altura de la ventana no se recalculaba al cambiar el tamaño de fuente, al cargar al inicio un tamaño de fuente grande guardado, ni al cambiar a la pestaña Configuración (`Tabs_SelectionChanged` estaba vacío) — con fuentes grandes se recortaba la última tarjeta de ruta de juego | Se añadió el recálculo de altura en los tres puntos |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` no tenía límite superior — expandir las 5 tarjetas de ruta de juego a la vez podía hacer que la ventana ocupara toda la pantalla o más | Altura limitada ahora a `SystemParameters.WorkArea.Height` |
| 11 | `MainWindow.xaml.cs` | Las carpetas `mods\`/`projects\` se creaban incondicionalmente para los 5 juegos en cada inicio, sin importar si el juego estaba instalado | Las carpetas ahora solo se crean para juegos con una ruta verificada y un ejecutable existente |
| 12 | `Game.cs` | `UpdateVersions()` podía fallar al guardar `Versions.xml` si la carpeta de destino no existía todavía (oculto hasta ahora porque las 5 carpetas se distribuyen precomprometidas) | La carpeta se crea con `Directory.CreateDirectory()` justo antes de guardar |

---

### Pestaña Configuración — Valores predeterminados de primer inicio modificados

`AutoUpdate`, `UseSteam` (Conexión con Steam) y `UpdateVersionsTable` (Mantener VersionsData) ahora están **desactivados** de forma predeterminada en una instalación nueva (antes activados por defecto). Estas tres funciones aún están incompletas en el lado del servidor, así que ahora son opcionales (opt-in), igual que `DevLog`/`ClearLogsOnStart`.

### Interfaz

- Fila de casillas de la pestaña Configuración (`SettingsCheckboxes`): `StackPanel` → `WrapPanel`, para que las etiquetas pasen a una nueva línea en lugar de recortarse con fuentes grandes.

### Nuevas claves de idioma (13 idiomas)

| Clave | Valor en inglés |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### Archivos modificados

| Archivo | Ruta | Cambio |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Orden de validación de Iniciar Juego unificado, recopilación de mods según filtro, popup de resultado combinado, detección automática de 4 juegos vía biblioteca de Steam controlada por UseSteam, correcciones de altura de ventana (tamaño de fuente / cambio de pestaña / límite) |
| `MainWindow.xaml` | `ModAPI\Windows\` | Casillas DevLog/ClearLogsOnStart en la pestaña Configuración, `WrapPanel` |
| `Game.cs` | `ModAPI_Shared\Data\` | Búsqueda en biblioteca de Steam, `CheckFiles` insensible a mayúsculas, verificaciones de compatibilidad de mods (completa + ligera), `LastAppliedModCount`/`LastExcludedModsSummary`, manejo de excepciones en `CreateModLibrary()`, detección automática controlada por UseSteam |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Bucle de reintento al eliminar archivos antiguos |
| `Mod.cs` | `ModAPI_Shared\Data\` | Campo `GameMismatchReason` |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Corrección del error de ruta vacía en `GetPath()` |
| `Debug.cs` | `ModAPI_Shared\` | Cambio de nombre a `ModAPI.dev.log`, campo `DevMode`, `ClearLogs()` |
| `App.xaml.cs` | `ModAPI\` | Manejadores globales de excepciones, conexión de `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Claves de `Mod.Mods` por juego, agrupación de pantalla por juego, insignia de incompatibilidad, supresión de spam de registros |
| `ModViewModel.cs` | `ModAPI\Data\ViewModels\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\Data\ViewModels\` | `DevLog`/`ClearLogsOnStart`, valores predeterminados opcionales para 3 casillas existentes |
| `FirstSetup.xaml` | `ModAPI\Windows\SubWindows\` | Valores predeterminados de 3 casillas cambiados a desactivado |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\Windows\SubWindows\` | Nuevo |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 8 claves nuevas |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9620</b></summary>

## Cambios en la v2.0.9620

### MODAPI_LangTool Añadido

Se añadió una herramienta WPF independiente para gestionar los archivos de idioma de ModAPI (`LangTool\MODAPI_LangTool.csproj`) — vea la sección **Lang Tool** anterior para más detalles.

---

### Correcciones de Errores

| # | Archivo | Problema | Corrección |
|---|---|---|---|
| 1 | `App.xaml.cs` | El idioma francés se mezclaba en los mensajes de excepción de .NET en Windows no inglés | `CultureInfo.InvariantCulture` fijado al inicio del constructor `App()` |
| 2 | `Game.cs` | Error SSL/TLS en `UpdateVersions()` — no se pudo crear un canal seguro SSL/TLS | TLS 1.2 configurado explícitamente mediante `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Ventana emergente `GamePathNotSet` de Green Hell a pesar de que la ruta estaba configurada | `App.Game.GamePath` vacío → lee la ruta guardada desde `Configuration` |
| 4 | `ModsViewModel.cs` | Los archivos de mods no aparecían en la lista al colocarlos manualmente en `mods\TheForest\` | Se añadió un registro de diagnóstico de validación del patrón de nombre de archivo |
| 5 | `MainWindow.xaml.cs` | La ventana emergente `MixedGameMods` bloqueaba la selección de mods de varios juegos | Ventana emergente de bloqueo eliminada — reemplazada por `SelectGameDialog` |

---

### Nuevas Funciones

#### Inicio del Juego — Ventana Emergente de Selección de Juego (`SelectGameDialog`)

Cuando se seleccionan mods de diferentes juegos, o cuando el filtro **All** está activo, aparece una ventana emergente de selección de juego en lugar de bloquear el inicio.

**Condiciones de activación:**
- Filtro `All` seleccionado + clic en Start Game
- Mods de 2 o más juegos diferentes activados simultáneamente

**Comportamiento:**
- Muestra solo los juegos con rutas configuradas y ejecutable existente
- Solo se aplican los mods del juego seleccionado — los mods de otros juegos se ignoran por completo
- El botón de opción se sincroniza con el juego seleccionado tras cerrar la ventana emergente (`SyncModGameFilterRadioButton`)

**Archivos nuevos**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Verificación de Integridad del Juego (solo compilación Release, `#if !DEBUG`)

Se ejecuta una comprobación de integridad de tres capas antes de cada inicio del juego:

| Capa | Método | En caso de fallo |
|---|---|---|
| A — Encabezado PE | `FileValidator.IsValidGameExe()` | Bloqueado + ventana emergente `GameExeCorrupted` |
| B — Suma de comprobación del ensamblado | Comparación MD5 → `Versions.xml` | Bloqueado + ventana emergente `GameAssemblyTampered` |
| C — Firma digital | `HasDigitalSignature()` | Advertencia + elección del usuario (`GameIntegrityWarning`) |

**Archivos nuevos**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Nuevos métodos añadidos a `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 de Assembly-CSharp.dll (+ firstpass si existe)
- `HasDigitalSignature(path)` — comprobación de firma Authenticode

---

### Nuevos Registros de Diagnóstico

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 elementos, Release + Debug)

| # | Fase | Tipo | Contenido |
|---|---|---|---|
| 1 | Configuración de TLS | Notice | Protocolo antes/después |
| 2 | Inicio de descarga | Notice | Lista de servidores |
| 3 | Intento de URL | Notice | Cada URL que se intenta |
| 4 | Descarga exitosa | Notice | URL, longitud de la respuesta, protocolo usado |
| 5 | WebException | Error | URL, estado HTTP, protocolo, detalle |
| 6 | Otra excepción | Error | URL, tipo de excepción, detalle |
| 7 | Descarga completa | Notice | Recuento de éxitos / total de servidores |
| 8 | Análisis exitoso | Notice | Cantidad de archivos y versiones antes/después |
| 9 | Fallo de análisis | Error | Tipo de excepción y detalle |
| 10 | Guardado exitoso | Notice | Ruta de guardado, total de versiones/archivos |
| 11 | Fallo al guardar | Error | Ruta, tipo de excepción, detalle |
| 12 | Sin respuesta | Error | Servidores intentados, protocolo |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 elementos, solo `#if DEBUG`)

| # | Situación | Tipo | Contenido |
|---|---|---|---|
| 1 | Inicio de escaneo | Notice | Ruta de la carpeta de mods, total de archivos encontrados |
| 2 | Ya cargado | Notice | Nombre de archivo |
| 3 | No es archivo .mod | Notice | Nombre de archivo |
| 4 | Coincidencia de patrón exitosa | Notice | Nombre de archivo encolado |
| 5 | Fallo de coincidencia de patrón | Warning | Nombre de archivo + motivo + formato esperado |
| 6 | Escaneo completo | Notice | Cantidad en cola / total de archivos |
| 7 | Excepción | Error | Detalle de la excepción |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 elementos, Release + Debug)

| # | Situación | Tipo | Contenido |
|---|---|---|---|
| 1 | Condición de ventana emergente | Notice | Filtro actual, IDs de juegos seleccionados, needGameSelect |
| 2 | Juegos candidatos | Notice | Lista de IDs candidatos para la ventana emergente |
| 3 | Ruta no establecida | Notice | Juego omitido — ruta no configurada |
| 4 | No está en Configuration | Notice | Juego omitido — no está en Configuration.Games |
| 5 | Instalación confirmada | Notice | Juego + ruta del ejecutable |
| 6 | Ejecutable no encontrado | Warning | Juego omitido — falta el ejecutable |
| 7 | Sin juegos instalados | Error | 0 candidatos → GamePathNotSet |
| 8 | Selección automática | Notice | Candidato único seleccionado automáticamente |
| 9 | Cancelado por el usuario | Notice | SelectGameDialog cancelado |
| 10 | Juego seleccionado + mods | Notice | Juego seleccionado, recuento/lista de mods recopilados |

---

### Separación de Registros de Desarrollador / Usuario (`#if DEBUG`)

| Archivo | Registro | Motivo |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Se repite cada segundo — 81 % del volumen total de registro |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Detalle interno exclusivo para desarrolladores |

El registro de Release conserva: éxito/fallo de descarga, resultados de análisis/guardado, fallos de coincidencia de patrones, excepciones, resultados de verificación de integridad.

---

### Actualización de la Tabla de Versiones — Arquitectura

#### Intención de Diseño

```
El juego recibe una actualización de Steam
  → Assembly-CSharp.dll cambia
  → ModAPI comprueba Versions.xml en busca de una suma de comprobación conocida
  → Si no se encuentra → descarga el Versions.xml más reciente del servidor
  → La nueva versión se registra automáticamente sin reinstalar ModAPI
```

#### Estructura de Conexión

```
Pestaña Settings → casilla KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → se llama a UpdateVersions()
      → descarga Versions.xml desde VersionUpdateDomains[]
      → sobrescribe el configs\games\{GameId}\Versions.xml local
```

#### Integración de URL Raw de GitHub

En lugar de depender únicamente de `modapi.survivetheforest.net`, ahora se usa la URL Raw de GitHub como fuente principal para la gestión directa:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — gestionado directamente, prioridad 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Servidor heredado — respaldo, prioridad 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Elemento | Detalle |
|---|---|
| Principal | URL Raw de GitHub — se actualiza de inmediato con cada push |
| Respaldo | Servidor heredado — usado cuando GitHub no está disponible |
| Ruta | `ModAPI/configs/games/{GameId}/Versions.xml` en el repositorio |
| Archivo modificado | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Actualizaciones de Versions.xml

| Juego | Archivo | Cambio |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Suma de comprobación corregida (era un SHA-256 incorrecto en mayúsculas) — `2.9.5b114117` con MD5 correcto |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID: 20229486) añadido — suma de comprobación MD5 de 128 caracteres |

---

### Nuevas Claves de Idioma (13 idiomas)

| Clave | Valor en inglés |
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
| `Lang.Savegames.*` (133 claves) | Valores en inglés añadidos a 12 idiomas (DE ya traducido) |

---

### Archivos Modificados

| Archivo | Ruta | Cambio |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` fijado al inicio |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, comprobación de integridad, MixedGameMods eliminado, sincronización de botón de opción, 10 registros |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nuevo |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nuevo |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Registro de diagnóstico de nombre de archivo, separación #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 registros de UpdateVersions, URL de GitHub, separación #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 claves nuevas + 133 claves de Savegames (515 en total, todos los idiomas coincidentes) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Suma de comprobación corregida |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12` añadido |
| `LangTool\` (13 archivos) | Raíz de la solución | Nuevo |
| `ModAPI.sln` | Raíz de la solución | LangTool registrado |

---

### Correcciones Adicionales y Renovación del Sistema de Registro (2026-06-21)

#### Validación de StartGame — Rediseño Completo

Se corrigió el orden de validación a una secuencia estricta de 3 pasos, y la ventana emergente de selección de juego ahora refleja los mods activados independientemente de si la ruta del juego está configurada.

| Paso | Comprobación | Ventana emergente en caso de fallo |
|---|---|---|
| 1 | Steam instalado | SteamNotFound |
| 2 | Ruta del juego seleccionado configurada + ejecutable existente | GamePathNotSet |
| 3 | Al menos un mod activado para el juego seleccionado | NoModSelected |

- **Filtro All / mods de varios juegos seleccionados** → la ventana emergente siempre enumera todos los juegos con un mod activado, **incluidos aquellos sin ruta configurada** — seleccionar un juego no configurado ahora muestra correctamente `GamePathNotSet` en lugar de excluirlo silenciosamente o mostrar el error incorrecto
- **Filtro de un solo juego** → las comprobaciones de ruta y mods se ejecutan directamente contra ese juego, en el mismo orden 1→2→3

#### Correcciones Críticas de Errores

| # | Archivo | Problema | Corrección |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` combinaba las respuestas de **todos** los servidores exitosos (GitHub + heredado), duplicando las sumas de comprobación (64 → 128 caracteres) cuando ambos tenían éxito — causaba bloqueos falsos de `GameAssemblyTampered` | Solo se analiza la respuesta del primer servidor exitoso; los servidores restantes se omiten una vez que uno tiene éxito |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` usaba `App.Game` (filtro activo actual) en lugar del propio juego del mod — eliminar un mod de Green Hell mientras The Forest estaba activo buscaba en la carpeta `Managed` incorrecta y omitía la eliminación silenciosamente | Ahora resuelve la ruta de la DLL desplegada desde `mod.Game` (la instancia real del juego del mod), con un respaldo a la ruta de `Configuration` si `GamePath` está vacío |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Volver a descargar un mod previamente eliminado restauraba su insignia de activación como marcada — al eliminar un mod nunca se borraban sus claves persistentes `Selected`/`Version` ni la caché del ViewModel en memoria | Se añadieron `RemoveKey()` / `RemoveKeysWithPrefix()` a `Configuration.cs`; `DeleteMod_Click` ahora restablece forzosamente `ModViewModel.Selected = false` y elimina todas las claves `Mods.{GameId}.{ModId}.*` al eliminar |
| 4 | `ModsViewModel.cs` | Eliminar un mod mientras un filtro de juego específico (no "All") estaba seleccionado dejaba el mod visible en la lista hasta cambiar a "All" y volver | Faltaba la notificación de cambio de `FilteredMods` después de `_Mods.RemoveAt()` en el bucle de sondeo de eliminación de archivos; ahora se activa siempre que se elimina realmente un mod |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Una excepción no controlada al construir o mostrar la ventana emergente de advertencia de falta de firma podía provocar que ModAPI se cerrara silenciosamente sin registrar ningún error | La construcción/visualización de la ventana emergente y el formateo de mensajes se envolvieron en try-catch; en caso de fallo, se registra la advertencia y se permite al usuario continuar de forma segura (la falta de firma es informativa, no un bloqueo estricto) |

#### Advertencia de Firma Digital — Mensaje Aclarado

El texto de `GameNoSignature` ahora nombra el juego específico y aclara que la falta de una firma es esperable en títulos independientes y no afecta a la jugabilidad, en lugar de sugerir una posible manipulación. Actualizado en los 13 archivos de idioma con un marcador de posición `{0}` para el nombre visible del juego (p. ej., "The Forest", "Green Hell").

#### Sistema de Registro — Separación en Dos Archivos

Los registros de diagnóstico limitados por `#if DEBUG` se convirtieron a un indicador `detailedOnly` y se dividieron entre `ModAPI.log` (orientado al usuario) y `ModAPI.detailed.log` (siempre con detalle completo) — vea la sección **Log** anterior para el desglose completo.

#### Archivos Modificados (Adicionales)

| Archivo | Ruta | Cambio |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Rediseño de validación de StartGame, corrección de instancia de juego en DeleteMod_Click, try-catch en GameIntegrityWarning, mapeo de nombres visibles |
| `Game.cs` | `ModAPI_Shared\Data\` | Corrección de respuesta única en UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Notificación de cambio de `FilteredMods` al eliminar, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 puntos de llamada) |
| `Mod.cs` | `ModAPI\Data\` | Volcado de XML de encabezado movido a `detailedOnly`, resumen de discrepancias de suma de comprobación |
| `Debug.cs` | `ModAPI_Shared\` | Parámetro `detailedOnly`, escritor de doble archivo, comentario de guía de registro de 4 niveles |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Marcador de posición `{0}` para el nombre del juego, protección try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` reescrito con marcador de posición para el nombre del juego |

---


</details>

<details>
<summary><b>Cambios en la v2.0.9619</b></summary>

### Correcciones de Errores

- **Bloqueo al aplicar mods con carpeta de respaldo vacía**: `gamefiles\original\` vacía → creación automática de copia de seguridad desde la ruta de instalación del juego antes de leer el ensamblado
- **Bloqueo de archivo (IOException) en DLLs del juego**: el resolutor de ensamblados excluye condicionalmente la carpeta del juego cuando existe una copia de seguridad — evita que Cecil mantenga bloqueos de archivo durante `DirectoryCopy`
- **Bucle infinito de reintento para mods dañados**: los archivos `.mod` fallidos (encabezado dañado) causaban un bucle de reescaneo de 1 segundo — ahora se registran en `LoadedFiles` para evitar el reescaneo
- **Archivos de mod con terminación de línea LF rechazados**: el analizador de encabezado `EndsWith("</Mod>\r")` fallaba con archivos `.mod` de estilo Unix — ahora usa `TrimEnd` para manejar tanto CRLF como LF
- **Fallo de validación de DLL pequeña**: `Assembly-UnityScript-firstpass.dll` (21 KB) era rechazado por `FileValidator` — el tamaño mínimo de ensamblado se redujo de 64 KB a 8 KB
- **Registros WARNING innecesarios**: las rutas de juego no configuradas y las claves de configuración de la primera ejecución generaban ruido — se añadió el parámetro `silent` a `GetPath`/`GetString`/`GetInt`

### Mejoras

- **Detección de descargas de 0 bytes**: alerta emergente + limpieza de archivos temporales cuando el servidor devuelve un archivo `.mod` vacío (`Lang.Windows.DownloadEmpty`)
- **Debounce al guardar el deslizador**: `ModListWidth` / `ProjectListWidth` se guarda en `ui.cfg` solo una vez (500 ms tras finalizar el arrastre) en lugar de en cada cambio de píxel
- **Creación condicional de carpetas de juego**: las carpetas `mods/` y `projects/` se crean solo para los juegos con rutas configuradas — ya no incondicionalmente para los 5
- **Registro de diagnóstico de análisis de encabezado**: muestra el número de líneas y una vista previa del contenido al fallar el análisis de un archivo `.mod`, para facilitar la resolución de problemas

### Nuevas Claves de Idioma (13 idiomas)

| Clave | Valor en inglés |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Archivos Modificados

| Archivo | Ruta | Cambio |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Creación automática de copia de seguridad, resolutor condicional, respaldo a carpeta del juego |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Respaldo a carpeta del juego para IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Parámetro `silent` en GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Protección contra descargas de 0 bytes, debounce del deslizador, lecturas silenciosas de configuración, creación condicional de carpetas |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Prevención de reintentos de mods dañados |
| `Mod.cs` | `ModAPI\Data\` | Análisis de encabezado LF/CRLF, registro de diagnóstico |
| 13× `Language.XX.xaml` | `resources\langs\` | Claves de ventana emergente `DownloadEmpty` |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9618</b></summary>


### MODAPI_VersionTool Añadido

Se añadió una herramienta WPF independiente para actualizar el número de versión con un solo clic (`VersionTool\MODAPI_VersionTool.csproj`) — vea la sección **Version Tool** anterior para más detalles.

- `VersionLabel.Text` ahora hace referencia a `App.Version` en lugar del `Version.Descriptor` codificado, por lo que las actualizaciones se reflejan de inmediato en el StatusBar tras una reconstrucción.

---

</details>

<details>
<summary><b>Cambios en la v2.0.9617</b></summary>


### Pestaña Settings — Botones de Restablecimiento de Ruta Añadidos

Se añadió un botón **Reset** a la fila de ruta de instalación de Steam y a cada fila de ruta de instalación de juego.

**Fila de ruta de Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Fila de ruta de juego (por juego)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamiento de Reset**
- Borra el cuadro de texto de la ruta de inmediato
- Guarda un indicador de restablecimiento en `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- El cuadro de texto permanece vacío tras reiniciar
- Evita el problema de que Configuration XML no persista cadenas vacías

**Guardado automático de Browse**
- Antes: se requería un clic independiente en Save después de Browse
- Ahora: se guarda automáticamente al seleccionar el archivo — se refleja incluso tras cambiar a la pestaña Mods

**Nueva clave de idioma**

| Clave | Valor |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9616</b></summary>

### Versions.xml — 4 Juegos Añadidos / Actualizados

| Juego | Ruta del archivo | BuildID | Notas |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Creado nuevo |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Suma de comprobación actualizada |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Creado nuevo |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Suma de comprobación actualizada |

### Reglas de Composición de la Suma de Comprobación

El formato de la suma de comprobación difiere según si `Assembly-CSharp-firstpass.dll` existe para cada juego.

| Juego | firstpass.dll | Formato de suma de comprobación |
|---|---|---|
| GH | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Subnautica | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| EscapeThePacific | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Raft | ❌ No presente | solo `Assembly-CSharp MD5` (32 caracteres) |

### Procedimiento de Actualización de Versions.xml al Actualizar el Juego

Añada una nueva entrada `<version>` sin eliminar las entradas existentes.

**Paso 1 — Encontrar el nuevo BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Juego | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Paso 2 — Extraer la nueva suma de comprobación**
```powershell
# Juegos con firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenar ambos valores Hash en orden (firstpass primero)

# Juegos sin firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Paso 3 — Añadir entrada a Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Cambios en la v2.0.9615</b></summary>

### Corrección de la Expansión de Ruta de Juego en la Pestaña Settings

- **Altura de expansión de tarjeta**: la parte inferior de la ventana ahora crece exactamente según la altura del campo de entrada al expandir una tarjeta de ruta de juego
- **Mejora de `UpdateWindowHeight()`**: llama a `UpdateLayout()` antes de medir `SizeToContent.Height`; establece temporalmente `TextureLayer1` en `Collapsed` cuando la textura de fondo está activa, para evitar que el tamaño original de una imagen 4K afecte al cálculo de altura
- **Corrección de la fila interna del Grid**: se cambió la última fila del Grid interno del panel de rutas de juego de `Height="*"` a `Height="Auto"` — elimina el espacio en blanco innecesario en la parte inferior

---

</details>

<details>
<summary><b>Cambios en la v2.0.9614</b></summary>

### Corrección del Comportamiento del Botón de Maximizar

- **Maximizar**: usa `SystemParameters.WorkArea` para la maximización manual en lugar de `WindowState.Maximized` — se ajusta exactamente a la resolución de pantalla actual sin superponerse con la barra de tareas
- **Restaurar**: guarda `Left`, `Top`, `Width`, `Height` y `MaxWidth` antes de maximizar y los restaura al hacer clic en el botón de restaurar
- **Manejo de `MaxWidth`**: se establece en `∞` al maximizar, se restaura al valor guardado al normalizar

---

</details>

<details>
<summary><b>Cambios en la v2.0.9613</b></summary>

### Nueva Pestaña Themes

El orden de las pestañas ahora es:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

La interfaz de selección de temas se trasladó de la pestaña Settings a una pestaña **Themes** dedicada.
Icono: Segoe MDL2 Assets `&#xE790;` (paleta)

### Registro de Temas (Estructura Basada en Datos)

Añadir un nuevo tema ahora solo requiere **una línea** en el diccionario de `App.xaml.cs`.
Se eliminaron todas las sentencias switch — no se necesitan cambios de código en ningún otro lugar.

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

Los elementos del ComboBox de `ThemeSelector` se generan automáticamente a partir del bucle `ThemeIds`.
Convención de claves de idioma: `Lang.Options.Theme.{PascalCase}` (p. ej., `Lang.Options.Theme.Nebula`)

### Temas Compatibles

| Índice | ID | Archivo | Paleta |
|---|---|---|---|
| 0 | `classic` | solo `Dictionary.xaml` | Fondo de textura original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tono claro + acento azul |
| 2 | `dark` | `FluentStyles.xaml` | Tono oscuro + acento azul (predeterminado) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rojo + negro |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espacio oscuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Atardecer brillante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océano oscuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brillante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brillante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brillante |

El cambio de tema provoca un reinicio automático de la aplicación. (guardado en `theme.cfg`)

### Función de Textura de Fondo

Seleccione una imagen en la tarjeta **Background Texture** de la pestaña Themes para aplicarla como fondo de toda la aplicación. Funciona con cualquier tema seleccionado.

**Formatos de entrada compatibles**: `.png` / `.jpg` / `.jpeg`, hasta 50 MB, resolución 4K o inferior

**Pipeline de Procesamiento de Imagen**

```
Imagen seleccionada por el usuario (.png / .jpg / .jpeg, máx. 50 MB, 4K o inferior)
  ↓
Compresión JPEG Q75 (búfer de memoria)
  ↓
Encabezado mágico de 16 bytes insertado
  "MODAPI" + "BG" + versión + relleno (FF 00 FE 00)
  ↓
Guardado como resources\textures\ui_bg\bg.dat (atributo Hidden)
  ↓
Hash SHA-256 → almacenado en ui.cfg como TextureHash
```

**Capas de Seguridad**

| Capa | Método | Efecto |
|---|---|---|
| Encabezado mágico | 16 bytes antepuestos antes de la firma JPEG (FF D8 FF) | Los visores externos no pueden reconocer el archivo |
| Atributo Hidden | `FileAttributes.Hidden` | Oculto en el Explorador por defecto |
| Integridad SHA-256 | Hash verificado al cargar | La manipulación provoca un restablecimiento automático + ventana emergente de advertencia |

**Comportamiento de Detección de Manipulación**
1. `bg.dat` eliminado
2. Claves de `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` restablecidas
3. Cuadro de texto y conmutador restablecidos
4. Ventana emergente `Lang.Windows.TextureTampered` mostrada

**Claves de ui.cfg**

| Clave | Valor | Descripción |
|---|---|---|
| `TexturePath` | Nombre de archivo (solo visualización) | Nombre de archivo original mostrado en el cuadro de texto |
| `TextureHash` | Hexadecimal SHA-256 | Hash de verificación de integridad |
| `TextureActive` | `true` / `false` | Estado de activación |

**Procesamiento de Transparencia**

Cuando la imagen de fondo está activa, los fondos de la interfaz se procesan en dos capas.

- **Capa 1 — Superposición de MergedDictionaries**: los paneles que referencian `{DynamicResource FluentBgBrush}`, etc., se vuelven transparentes automáticamente. Se restauran con una única llamada a `Remove()` al desactivar.

  Claves objetivo: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Capa 2 — Recorrido del árbol visual (`WalkStyleBackgrounds`)**: los elementos `{StaticResource}` en los temas Fluent no se ven afectados por la Capa 1, por lo que el árbol visual se recorre directamente para aplicar pinceles semitransparentes basados en los colores originales.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=totalmente transparente, 255=opaco → 100 ≈ 39 % opaco
  ```

  Procesado: `Panel` (excepto Grid), `Border`, `ListBox` / `ListView`

  Excluido: `Grid` (fondo conservado, hijos recorridos), `TabPanel` (protección del encabezado de pestaña), `ButtonBase` / `ComboBox`, elementos `Collapsed`

  Restauración: origen del Setter de estilo → `ClearValue()`, origen de valor local XAML → restaura directamente el pincel original

**Cambio de Pestaña**

Dado que el TabControl de WPF carga el contenido de las pestañas de forma diferida, `WalkStyleBackgrounds(this)` se vuelve a ejecutar con prioridad `ContextIdle` al cambiar de pestaña. Los elementos ya procesados se omiten mediante una comprobación `ContainsKey`.

**Bloqueo de ThemeSelector**

Cuando la textura de fondo está activa, se muestra un borde `ThemeSelectorOverlay` sobre el selector de temas para bloquear la interacción.

- XAML: borde `ThemeSelectorOverlay` añadido sobre ThemeSelector (`IsHitTestVisible=True`)
- Activo: `ThemeSelectorOverlay.Visibility = Visible`
- Inactivo: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` también protegido por el indicador `_textureActive`

**Flujo de Estado de la Interfaz**

```
Imagen seleccionada (Browse)
  → bg.dat creado → conmutador desbloqueado → activación automática → TextureLayer1 mostrado
  → SaveAndClearBrushes() → ThemeSelectorOverlay mostrado

Conmutador desactivado
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay oculto
  → TextureLayer1 oculto

Botón Clear
  → bg.dat eliminado → conmutador bloqueado → TextureLayer1 oculto → pinceles restaurados
  → GC.Collect() (libera la memoria de la imagen 4K)
```

**Nuevas Claves de Idioma**

| Clave | Descripción |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nuevos nombres de tema |
| `Lang.Options.Labels.TextureBackground` | Etiqueta de textura de fondo |
| `Lang.Options.Labels.TextureEnable` | Etiqueta de activación |
| `Lang.Options.Labels.TextureClear` | Botón Clear |
| `Lang.Windows.TextureTooLarge` | Advertencia de tamaño de archivo excedido |
| `Lang.Windows.TextureTampered` | Advertencia de manipulación detectada |

**Estructura de Archivos**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Pestaña Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Lógica de tema y textura
├── Themes\
│   ├── Dictionary.xaml            # Tema Classic
│   ├── FluentStyles.xaml          # Tema Dark
│   ├── FluentStylesLight.xaml     # Tema Light
│   ├── FluentStylesDiablo.xaml    # Tema Diablo
│   ├── FluentStylesNebula.xaml    # Tema Nebula
│   ├── FluentStylesSunset.xaml    # Tema Sunset
│   ├── FluentStylesOcean.xaml     # Tema Ocean
│   ├── FluentStylesNordic.xaml    # Tema Nordic
│   ├── FluentStylesCitrus.xaml    # Tema Citrus
│   └── FluentStylesBloom.xaml     # Tema Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Imagen de fondo comprimida y protegida (generada en tiempo de ejecución)
```

**Limitaciones de Diseño Conocidas**

| Elemento | Detalles |
|---|---|
| `IsEnabled=false` en ComboBox | Causa un fallo `ElementNotEnabledException` → se usa el enfoque de superposición `IsHitTestVisible` |
| Reemplazo directo de claves de `MergedDictionaries` | Falla durante el paso de diseño → solo el patrón `Add`/`Remove` |
| Sobrescritura de archivo oculto | `Access Denied` → debe restablecerse `FileAttributes.Normal` antes de escribir |
| Fondos `{StaticResource}` | No afectados por la Capa 1 → requieren WalkStyleBackgrounds (Capa 2) |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9612</b></summary>

### Separación del Módulo de Temas

- **Nueva carpeta `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` y `FluentStylesClassic.xaml` movidos a `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — el tema Classic usa solo `Dictionary.xaml`; los temas Light/Dark/otros Fluent cargan el XAML correspondiente
- **`ModAPI.csproj`**: rutas de XAML de temas actualizadas al subdirectorio `Themes\`; `FluentStylesClassic.xaml` registrado

---

</details>

<details>
<summary><b>Cambios en la v2.0.9611</b></summary>

### Corrección de Error

- **Ancho de Mod List no aplicado tras cambio de tema**: se corrigió un problema en el que el ancho de la lista de mods no se aplicaba tras cambiar entre los temas Light/Dark y reiniciar — se añadió la llamada `ApplyModListWidth(width)` dentro de `InitModListWidth()`

---

</details>

<details>
<summary><b>Cambios en la v2.0.9610</b></summary>

### Añadido

#### XML de Juego y Configuración de Versions

| # | Archivo | Cambio |
|---|------|--------|
| 1 | `GH.xml` | Reescritura completa — se eliminó `DOTweenPro.dll` (inexistente); se añadieron `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Reescritura completa — se eliminó `extends="GenericUnityGame"`; se añadieron `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Reescritura completa — se eliminó `extends="GenericUnityGame"`; `includeAssembly` → solo `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Creado — versión `1.1.01` con suma de comprobación |
| 5 | `GH/Versions.xml` | Creado — versión `2.9.5` con suma de comprobación |
| 6 | `Subnautica/Versions.xml` | Creado — sin suma de comprobación (se actualiza con demasiada frecuencia) |

#### Correcciones Críticas de Errores

| # | Tipo | Problema | Corrección |
|---|------|-------|-----|
| 1 | Bloqueo | `extends="GenericUnityGame"` causaba la herencia de `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` se detenía | Se eliminó `extends` de todos los XML que no son de TheForest |
| 2 | Fallo | `ResolutionException: XGamingRuntime.XUserGamertagComponent` durante la aplicación en Subnautica | Se añadieron `XGamingRuntime.dll`, `XblPCSandbox.dll` a `copyAssembly` |
| 3 | Fallo | El resolutor fallaba con DLLs añadidas a `copyAssembly` después de crear la copia de seguridad | `Game.cs`: se añadió la carpeta de instalación real como respaldo del resolutor |
| 4 | Fallo | `IOException`: bloqueo de archivo de `BaseModLib.dll` entre `CreateModLibrary` y `ApplyMods` | Bucle de reintento: máx. 10 × 500 ms de lectura + máx. 30 × 500 ms de espera de existencia |
| 5 | Fallo | `NullReferenceException` — entry.Value de `typesMap` nulo (juego no instalado) | Se añadió `if (entry.Value == null) continue` |
| 6 | Fallo | `NullReferenceException` — al constructor ligero de `Game` le faltaba `ModLibrary = new ModLib(this)` → fallo en `CreateModLibrary()` | Se añadió `ModLibrary = new ModLib(this)` al constructor ligero |
| 7 | Fallo | `SwitchDevGame()` — `App.Game.GamePath` vacío tras el constructor ligero → fallo en `CreateModLibrary` | Se estableció `App.Game.GamePath = savedPath` tras el constructor ligero |
| 8 | Juego incorrecto | Los mods de `EscapeThePacific` se clasificaban como TheForest | `ModsViewModel`: `GameId` extraído de la ruta de la carpeta |
| 9 | Ruta incorrecta | `GetGameFolder()` → `""` → se resuelve a la raíz de la unidad (p. ej., `E:\`) | Protección nula/vacía en los 6 puntos de llamada |

#### División de Compilaciones Debug / Release

- **`FileValidator.cs`** — archivo nuevo `ModAPI_Shared\Utils\FileValidator.cs`; registrado en `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — encabezado PE (MZ + PE\0\0) + mínimo 1 MB
  - `IsValidGameExe()` — encabezado PE + mínimo 512 KB
  - `IsValidAssemblyDll()` — encabezado PE + encabezado de metadatos CLR de .NET + mínimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: solo `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` sin Cecil / `#else`: análisis Cecil completo + modificación de IL
- **`ModLib.Create()` archivo no encontrado** — `#if DEBUG`: registra advertencia, omite / `#else`: registra error, aborta

#### Pruebas Debug

- **`create_dummy_Debug_games.ps1`** — script de PowerShell para `bin\Debug\`; crea archivos de marcador de posición de 0 bytes para los 5 juegos en `dummy_games\`, `dummy_steam\` y `gamefiles\original\` — permite probar el flujo de trabajo completo de la interfaz sin una instalación real del juego

#### Pestaña Settings

- **Tarjeta de ruta de Steam** — integrada en la tarjeta Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panel de rutas de juego** — `BuildGamePathsPanel()` con tarjetas expandibles por juego; el cuadro de texto usa `HorizontalAlignment=Stretch`
- Botón **Expand All / Collapse All**
- Casilla **AlwaysOnTop** (guardada en `ui.cfg`)
- Deslizadores de **Mod/Project List Width** — comienzan en el mínimo `150`; guardados en `ui.cfg`
- ComboBox de **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronización de casillas** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions ahora se sincronizan correctamente
- **Indicador `_uiInitialized`** — evita escrituras prematuras en `ui.cfg` durante el inicio de WPF

#### Pestaña Mods — Validación de Inicio de Juego

Se ejecuta una validación de cinco pasos en cada clic de Start Game, independientemente del estado de la lista de mods:

| Paso | Comprobación | Ventana emergente |
|---|---|---|
| 1 | Ruta de Steam en la pestaña Settings válida (`Steam.exe` existe) | SteamNotFound |
| 2 | El juego de la carpeta `mods/{GameId}/` coincide con el juego configurado en Settings | GameModsMismatch |
| 3 | Al menos un mod seleccionado | NoModSelected |
| 4 | Sin mods de juegos mezclados en la selección | MixedGameMods |
| 5 | Ruta del juego configurada + ejecutable existente | GamePathNotSet / GameNotInstalled |

#### Pestaña Development — Validación de ModLib

Validación de tres pasos al hacer clic en Mod Library Regeneration:

| Paso | Comprobación | Ventana emergente |
|---|---|---|
| 1 | Ruta de Steam en la pestaña Settings válida | SteamNotFound |
| 2 | Al menos un proyecto existente | NoProjectWarning |
| 3 | `App.Game.GamePath` establecido | GamePathNotSet |

#### Pestaña Downloads
- Cadena de depuración reemplazada por `Lang.Downloads.Status.NoDownloads`
- Relleno consistente para todos los mensajes de estado
- Texto manual sin conexión actualizado para los 5 juegos compatibles; salto de línea mediante dos TextBlocks

#### First Setup y Sistema de Ruta de Juego
- `FirstSetup.Check()` — valor predeterminado `true` para `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crea carpetas `mods/` y `projects/` para los 5 juegos
- `SpecifyGamePath` — `GameNameLabel` muestra de qué juego se trata; `NavigateToSettings()` dirige a la pestaña Settings

#### Claves de Idioma Nuevas/Actualizadas

| Clave | Valor en inglés |
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

| Función | Motivo |
|---|---|
| Actualización automática (mantener la última versión) | Infraestructura del lado del servidor no disponible |
| Búsqueda de actualizaciones | Infraestructura del lado del servidor no disponible |

### Eliminado

| Elemento | Motivo |
|---|---|
| Ventana emergente `SpecifyGamePath` al iniciar | Todas las rutas se configuran en la pestaña Settings |
| Ventana emergente `SpecifySteamPath` al iniciar | La ruta de Steam se configura en la pestaña Settings |
| Sistema de inicio de sesión | El servidor original ya no está operativo (eliminado en v2.0.9400) |
| `Portable.System.ValueTuple.dll` | No funciona en Mono 2.0 (eliminado en v2.0.9586) |
| Condición `UseSteam` en la comprobación de Steam | Steam ahora siempre se valida primero en Start Game y en Mod Library Regeneration |

## Planificado para Futuras Versiones

| # | Función | Descripción |
|---|---|---|
| 1 | Actualización automática de ModAPI | Descargar y aplicar automáticamente nuevas versiones de ModAPI |
| 2 | Actualización de la tabla VersionsData de ModAPI | Actualizar automáticamente la tabla VersionsData del juego cuando se publiquen nuevos parches |

---

</details>

<details>
<summary><b>Cambios en la v2.0.9600</b></summary>

### Añadido

- **Pestaña Downloads**: 5 filtros de juego (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Pestaña Welcome**: añadida en la posición más a la izquierda (índice 0)
- **Pestaña Mods**: diseño de 3 columnas (WrapPanel → lista vertical); ajuste automático de ancho; ajuste de línea en nombres de mods
- **`ModsViewModel`**: filtrado específico por juego, `ResolveGame()` para la instancia `Game` correcta por mod
- **`Game.cs`**: constructor ligero `new Game(config, true)` — solo identificación, sin `Verify()`
- **Compilación**: 4 archivos XML de juego registrados en `ModAPI.csproj` con `CopyToOutputDirectory=Always`
- **Compilación**: advertencias limpiadas — CS0168, CS0618, CS0252
- **XML de juego**: listas de DLL de TheForest, Raft, GH corregidas
- **Banderas de idioma**: tamaños de imagen estandarizados en las 13 insignias de idioma

### Eliminado

| Elemento | Motivo |
|---|---|
| `extends="GenericUnityGame"` en archivos XML de juego | Causaba que `Assembly-CSharp-firstpass.dll` se heredara incorrectamente — eliminado de Subnautica, Raft, EscapeThePacific, GH |
| Diseño `WrapPanel` en la pestaña Mods | Reemplazado por un diseño Grid de 3 columnas (Game Filter / Mod List / Information) |

---

</details>

---

## Historial de Versiones

<details>
<summary><b>Fase 6-3 — Expansión del Sistema de Temas, Mejoras de Configuración, Estabilidad y Herramientas</b></summary>

### v2.0.9621 — 2026-07-28

- Detección automática en toda la biblioteca de Steam para los 5 juegos, controlada por la casilla Conexión con Steam
- Detección y exclusión automática de mods creados para otro juego (lista + al aplicar), con insignia ⚠ en la pestaña Mods
- Popup de resultado combinado para mods excluidos / ningún mod aplicado en lugar de popups apilados; el juego ya no se inicia con cero mods aplicados
- Registro global de excepciones no controladas (hilo de interfaz + hilos en segundo plano)
- `ModAPI.dev.log` reemplaza a `ModAPI.detailed.log`; nuevos interruptores en la pestaña Configuración para Registro de desarrollador y Borrar registros al iniciar
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` ahora están desactivados por defecto en una instalación nueva
- Corregido: error de ruta vacía en `Configuration.GetPath()`, orden de validación inconsistente en Iniciar Juego, recopilación de mods que ignoraba el filtro, colisiones de clave de `Mod.Mods` entre juegos y el consiguiente fallo de `UpdateMods()`, duplicación de suma de comprobación en Green Hell (`_Data`/`_data`), fallo por bloqueo de archivo de `BaseModLib.dll`, creación incondicional de `mods\`/`projects\`, fallo al guardar `Versions.xml` con carpeta inexistente, falta de recálculo de altura de ventana al cambiar tamaño de fuente / pestaña, altura de ventana sin límite al expandir todo

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool y correcciones principales**
- MODAPI_LangTool añadido (herramienta WPF independiente de gestión de idiomas)
- Corrección de SSL/TLS (TLS 1.2)
- Corrección de configuración regional francesa (`CultureInfo.InvariantCulture`)
- Corrección de `GamePathNotSet` en Green Hell
- SelectGameDialog (filtro All + inicio con mods de varios juegos)
- Bloqueo por MixedGameMods eliminado
- Comprobación de integridad del juego de 3 capas (encabezado PE / suma de comprobación del ensamblado / firma digital)
- Separación de registros de desarrollador y usuario
- 12 registros de UpdateVersions + 7 registros de FindMods + 10 registros de StartGame
- URL Raw de GitHub como `VersionUpdateDomains` principal
- Suma de comprobación de `Versions.xml` de GH corregida
- `1.12` añadido a `Versions.xml` de TheForest
- 515 claves en los 13 archivos de idioma

**Correcciones adicionales (2026-06-21)**
- Orden de validación de StartGame corregido (Steam → ruta del juego → mods)
- La ventana emergente de selección de juego ahora enumera correctamente los juegos con ruta no configurada
- Corrección de respuesta única en UpdateVersions (ya no hay sumas de comprobación duplicadas)
- `DeleteMod` ahora resuelve la propia instancia de juego del mod en lugar del filtro activo
- Los mods eliminados ya no dejan una insignia obsoleta "Selected" al volver a descargarse
- La lista de mods ahora se actualiza de inmediato al eliminar, bajo cualquier filtro de juego
- Ventana emergente `GameIntegrityWarning` reforzada contra fallos por excepciones no controladas
- El mensaje de advertencia de firma digital ahora nombra el juego y aclara que es esperable en títulos independientes
- El sistema de registro de dos archivos (`ModAPI.log` / `ModAPI.detailed.log`) reemplaza los registros limitados por `#if DEBUG`, de modo que las compilaciones Release puedan seguir capturando todo el detalle de diagnóstico sin saturar el registro orientado al usuario

### v2.0.9619 — 2026-05-25

- Creación automática de copia de seguridad desde la ruta de instalación del juego
- Corrección de bloqueo de archivo (resolutor condicional)
- Prevención de bucle infinito para mods dañados
- Compatibilidad con mods de terminación de línea LF
- Detección de descargas de 0 bytes con ventana emergente
- Debounce al guardar el deslizador (500 ms)
- Creación condicional de carpetas de juego
- Tamaño mínimo de ensamblado en `FileValidator` reducido de 64 KB a 8 KB
- Parámetro `silent` en `GetPath`/`GetString`/`GetInt`
- Registro de diagnóstico de análisis de encabezado
- Claves de idioma `DownloadEmpty` (13 idiomas)

### v2.0.9618 — 2026-04-25
Se añadió MODAPI_VersionTool (herramienta WPF independiente de actualización de versión), visualización de versión en StatusBar vinculada a App.Version

### v2.0.9617 — 2026-04-24
Se añadieron botones de restablecimiento de ruta de Steam/juego en la pestaña Settings, guardado automático de Browse, estado de restablecimiento preservado mediante el indicador ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml creado/actualizado para 4 juegos (Subnautica, Raft, EscapeThePacific, GH), reglas de composición de suma de comprobación establecidas, procedimiento de actualización de juego documentado

### v2.0.9615 — 2026-04-18
Corregida la precisión de la altura de expansión de la tarjeta de ruta de juego en la pestaña Settings, prevenida la interferencia de UpdateWindowHeight con la textura de fondo

### v2.0.9614 — 2026-04-18
Maximización manual del botón de maximizar basada en WorkArea, guardado y restauración de tamaño/posición anteriores

### v2.0.9613 — 2026-04-18
Pestaña Themes añadida, estructura de registro de temas basada en datos, compatibilidad con 10 temas, función de textura de fondo (compresión, seguridad, transparencia de 2 capas), superposición de bloqueo de ThemeSelector, 12 nuevas claves de idioma

### v2.0.9612 — 2026-04-18
Separación de la carpeta Themes/, modularización de XAML de temas

### v2.0.9611 — 2026-04-18
Corregido: ancho de Mod List no aplicado tras cambio de tema

</details>

<details>
<summary><b>Fase 6-2 — Configuración, Seguridad, Correcciones de Fallos y División Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- XML multijuego corregido (GH, Subnautica, EscapeThePacific)
- `Versions.xml` añadido
- Pestaña Settings rediseñada (ruta de Steam, panel de rutas de juego, deslizadores de ancho, tamaño de fuente, sincronización de casillas)
- Seguridad nula de ruta de juego (6 puntos)
- Ventanas emergentes de inicio reemplazadas por la pestaña Settings
- Validación de inicio de juego de 5 pasos en la pestaña Mods (Steam siempre primero)
- Validación de ModLib de 3 pasos en la pestaña Dev
- Ventana emergente `GameModsMismatch` añadida
- Corrección de `ModLibrary` nulo en el constructor ligero
- Corrección de `GamePath` en `SwitchDevGame`
- Verificación de encabezado PE de `FileValidator` (Release)
- División de compilación `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- `ui.cfg` persistente
- Sistema de fuente de 5 claves
- Múltiples correcciones de fallos
- Claves de idioma actualizadas

</details>

<details>
<summary><b>Fase 6-1 — Multijuego y Rediseño de Mods</b></summary>

### v2.0.9600 — 2026-04-09
> 5 filtros de juego, diseño de 3 columnas en la pestaña Mods, ancho automático, constructor `Game` ligero, filtrado de juegos en `ModsViewModel`, 4 archivos XML registrados, advertencias de compilación limpiadas, pestaña Welcome, banderas de idioma estandarizadas

</details>

<details>
<summary><b>Fase 5-6B — C# 7.3 y Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Pantalla negra corregida, polyfill finalizado, ValueTuple eliminado, C# 7.3 verificado

</details>

<details>
<summary><b>Fase 5-5 — Resolución de Ensamblados</b></summary>

### v2.0.9561 — 2026-03-06
> Compatibilidad con C# 7.3, parcheo de encabezado PE, pipeline de polyfill, resolución de ensamblados restaurada

</details>

<details>
<summary><b>Fase 5-1 — Pestaña Downloads y 13 Idiomas</b></summary>

### v2.0.9552 — 2026-02-25
> Pestaña Downloads, modernización de iconos, unificación de temas, compatibilidad con 13 idiomas

</details>

<details>
<summary><b>Fases Anteriores</b></summary>

### Fase 3 — Rediseño de la Interfaz y Sistema de Temas
v2.0.9500
> Sistema de temas (Classic/Light/Dark), interfaz Fluent Design, sistema SubWindow

### Fase 4 — Limpieza de Código
v2.0.9400
> Limpieza de código, eliminación del inicio de sesión, modernización de legado

### Fase 2 — Entorno de Compilación y Fluent Design
v2.0.9300
> Entorno de compilación, DLL stub de UnityEngine, integración de ModernWpf

### Fase 1 — Migración a .NET 4.8
v2.0.9200
> Migración a .NET Framework 4.8

### v1.x
Versión original de FluffyFish

</details>

---

## Requisitos de Compilación

| Requisito | Versión | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Proyectos de ModAPI |
| .NET Framework SDK | 3.5 | Solo BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` en `libs/polyfills/` |

---

## Licencia

GNU General Public License v3.0 — sigue la licencia original.
