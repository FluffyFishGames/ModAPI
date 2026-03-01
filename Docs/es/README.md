[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Herramienta de Gestión de Mods de The Forest — Edición Mejorada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemania)
> Mejora: zzangae (República de Corea)

---

## Descripción General

ModAPI es una aplicación de escritorio para gestionar mods de The Forest. Esta edición mejorada incluye migración a .NET Framework 4.8, interfaz de usuario Windows 11 Fluent Design, sistema de 3 temas, soporte multilingüe mejorado e implementación completa de la pestaña de Descargas.

---

## Cambios Principales

### Fase 1 — Actualización a .NET Framework 4.8

- Migración de todos los proyectos (5) de `.NET Framework 4.5` → `4.8`
- Actualización de `TargetFrameworkVersion`, `App.config`, `packages.config` en todos los proyectos
- Versión de ensamblado unificada

### Fase 2 — Entorno de Compilación y Base de Fluent Design

- Introducción del paquete NuGet **ModernWpf 0.9.6**
- Creación de **FluentStyles.xaml** — capa de sobreescritura de Windows 11 Fluent Design
  - Paleta de colores Fluent, tipografía, botones, pestañas, comboboxes, estilos de barra de desplazamiento
  - Plantillas de Window, SubWindow, SplashScreen
- Compilación de **DLL stub de UnityEngine**
  - Tipos faltantes añadidos: `WWW`, `Event`, `TextEditor`, `Physics`, etc.
- Referencias de dependencias corregidas y compilación exitosa confirmada

### Fase 3 — Rediseño de UI y Sistema de Temas

#### Rediseño de Fluent UI
- Reestructuración completa de **MainWindow.xaml**
  - Diseño, colores y tipografía basados en Fluent Design
  - Controles de pestañas, barra de estado y botones de título rediseñados
- Correcciones en tiempo de ejecución: congelamiento de SplashScreen, cambio de pestañas, estados de iconos, arrastre de ventana

#### Sistema de 3 Temas

| Tema | Archivo de Estilo | Descripción |
|------|------------------|-------------|
| Clásico | Solo Dictionary.xaml | Diseño original de ModAPI (fondo de textura) |
| Claro | FluentStylesLight.xaml | Tono brillante + acento azul |
| Oscuro | FluentStyles.xaml | Tono oscuro + acento azul (predeterminado) |

- **ComboBox de selección de tema** añadido en la pestaña Configuración
- El cambio de tema activa **diálogo de confirmación** → **reinicio automático**
- Configuración de tema guardada/cargada mediante archivo `theme.cfg`

#### Arrastre de Ventana / SubWindows / Hipervínculos
- Evento `MouseLeftButtonDown` en Root Grid para manejo directo del arrastre
- Diálogos ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Colores de enlace específicos por tema: Oscuro/Clásico (`#FFD700`), Claro (`#0078D4`)

### Fase 4 — Limpieza de Código y Eliminación de Legado

- Sistema de inicio de sesión eliminado (servidor fuera de servicio)
- Mecanismo de actualización modernizado
- Código no utilizado limpiado
- UI de SubWindow corregida (diálogos de ruta del juego, etc.)

### Fase 5 — Expansión de Soporte Multilingüe (13 Idiomas)

| Idioma | Archivo | Idioma | Archivo |
|--------|---------|--------|---------|
| Coreano | Language.KR.xaml | Italiano | Language.IT.xaml |
| Inglés | Language.EN.xaml | Japonés | Language.JA.xaml |
| Alemán | Language.DE.xaml | Portugués | Language.PT.xaml |
| Español | Language.ES.xaml | Vietnamita | Language.VI.xaml |
| Francés | Language.FR.xaml | Chino (Simplificado) | Language.ZH.xaml |
| Polaco | Language.PL.xaml | Chino (Tradicional) | Language.ZH-TW.xaml |
| Ruso | Language.RU.xaml | | |

### Fase 5-1 — Pestaña de Descargas y Finalización de Temas

#### Pestaña de Descargas
- Carga de lista de mods desde 3 fuentes (`mods.json`, `versions.xml`, análisis HTML)
- Funcionalidad de búsqueda (filtrar por nombre/descripción/autor del mod)
- **Filtro de juego** (Todos / The Forest / Servidor Dedicado / VR)
- **Filtro de categoría** (Todos / Correcciones / Balanceo / Trucos, etc. — 12 categorías)
- UI de panel dividido para selección de versión
- Descarga directa de archivos `.mod` → instalación en carpeta del juego
- Ordenación de columnas (clic en nombre/categoría/autor) y redimensionamiento
- Eliminación de mods (limpieza de DLL + archivos de preparación)

#### Modernización de Iconos (Todos los Temas)
- Todos los iconos PNG de botones → iconos de fuente **Segoe MDL2 Assets**
- Aplicado en MainWindow.xaml + 14 archivos SubWindow
- Los iconos de fuente heredan el color de primer plano, asegurando visibilidad en todos los temas

| PNG Original | Icono de Fuente | Uso |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Añadir / Iniciar Juego |
| Icon_Delete | &#xE74D; | Eliminar |
| Icon_Refresh | &#xE72C; | Actualizar |
| Icon_Download | &#xE896; | Descargar |
| Icon_Continue/Accept | &#xE8FB; | Confirmar/Continuar |
| Icon_Decline | &#xE711; | Cancelar/Cerrar |
| Icon_Information | &#xE946; | Información |
| Icon_Warning | &#xE7BA; | Advertencia |
| Icon_Error | &#xEA39; | Error |
| Icon_Browse | &#xED25; | Explorar |
| Icon_CreateMod | &#xE713; | Crear Mod |

#### Controles Unificados en Todos los Temas

| Control | Clásico | Oscuro | Claro |
|---------|---------|--------|-------|
| Casilla de verificación | Interruptor (Dorado) | Interruptor (AccentBrush) | Interruptor (AccentBrush) |
| Botón de radio | Círculo (Dorado) | Círculo (AccentBrush) | Círculo (AccentBrush) |
| ComboBox | Scale9 original | Fluent personalizado | Fluent personalizado |

#### Correcciones de Visibilidad de Temas
- Claro: texto de AccentButton forzado a Blanco, ajuste de Opacidad de icono de pestaña
- Oscuro/Claro: enfoque `TextElement.Foreground` de ComboBoxItem para visibilidad del texto seleccionado
- Clásico: recursos de respaldo Fluent añadidos a Dictionary.xaml

---

## Estructura de Archivos

```
ModAPI/
├── App.xaml / App.xaml.cs          # Cargar/guardar/aplicar tema
├── Dictionary.xaml                  # Estilos originales + recursos de interruptor/radio/respaldo
├── FluentStyles.xaml                # Tema oscuro + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Tema claro + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # UI principal + pestaña de descargas + selector de tema
│   └── SubWindows/                  # 16 SubWindows (todos con iconos de fuente)
├── resources/
│   ├── langs/                       # 13 archivos de idioma
│   └── textures/Icons/flags/        # Iconos de banderas (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Requisitos de Compilación

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Licencia

GNU General Public License v3.0 — sigue la licencia original.
