[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Ferramenta de Gestão de Mods do The Forest — Edição Atualizada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemanha)
> Atualização: zzangae (República da Coreia)

---

## Visão Geral

ModAPI é uma aplicação desktop para gerir mods do The Forest. Esta edição atualizada inclui migração para .NET Framework 4.8, interface Windows 11 Fluent Design, sistema de 3 temas, suporte multilingue melhorado e implementação completa do separador Downloads.

---

## Alterações Principais

### Fase 1 — Atualização para .NET Framework 4.8

- Migração de todos os projetos (5) de `.NET Framework 4.5` → `4.8`
- Atualização de `TargetFrameworkVersion`, `App.config`, `packages.config` em todos os projetos
- Versão de assembly unificada

### Fase 2 — Ambiente de Build e Fundação Fluent Design

- Introdução do pacote NuGet **ModernWpf 0.9.6**
- Criação do **FluentStyles.xaml** — camada de sobreposição Windows 11 Fluent Design
  - Paleta de cores Fluent, tipografia, botões, separadores, comboboxes, estilos de barras de rolagem
  - Templates Window, SubWindow, SplashScreen
- Compilação da **DLL stub UnityEngine**
  - Tipos em falta adicionados: `WWW`, `Event`, `TextEditor`, `Physics`, etc.
- Referências de dependências corrigidas e build bem-sucedido confirmado

### Fase 3 — Redesign da UI e Sistema de Temas

#### Redesign Fluent UI
- Reestruturação completa do **MainWindow.xaml**
  - Layout, cores e tipografia baseados em Fluent Design
  - Controlos de separadores, barra de estado e botões da barra de título redesenhados
- Correções de runtime: congelamento do SplashScreen, troca de separadores, estados de ícones, arrastar janela

#### Sistema de 3 Temas

| Tema | Ficheiro de Estilo | Descrição |
|------|-------------------|-----------|
| Clássico | Apenas Dictionary.xaml | Design original do ModAPI (fundo de textura) |
| Claro | FluentStylesLight.xaml | Tom luminoso + acento azul |
| Escuro | FluentStyles.xaml | Tom escuro + acento azul (predefinido) |

- **ComboBox de seleção de tema** adicionado no separador Definições
- Mudança de tema aciona **diálogo de confirmação** → **reinício automático**
- Definição de tema guardada/carregada via ficheiro `theme.cfg`

#### Arrastar Janela / SubWindows / Hiperligações
- Evento `MouseLeftButtonDown` no Root Grid para tratamento direto do arraste
- Diálogos ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Cores de ligação específicas por tema: Escuro/Clássico (`#FFD700`), Claro (`#0078D4`)

### Fase 4 — Limpeza de Código e Remoção de Legado

- Sistema de login removido (servidor fora de serviço)
- Mecanismo de atualização modernizado
- Código não utilizado limpo
- UI SubWindow corrigida (diálogos de caminho do jogo, etc.)

### Fase 5 — Expansão do Suporte Multilingue (13 Idiomas)

| Idioma | Ficheiro | Idioma | Ficheiro |
|--------|---------|--------|---------|
| Coreano | Language.KR.xaml | Italiano | Language.IT.xaml |
| Inglês | Language.EN.xaml | Japonês | Language.JA.xaml |
| Alemão | Language.DE.xaml | Português | Language.PT.xaml |
| Espanhol | Language.ES.xaml | Vietnamita | Language.VI.xaml |
| Francês | Language.FR.xaml | Chinês (Simplificado) | Language.ZH.xaml |
| Polaco | Language.PL.xaml | Chinês (Tradicional) | Language.ZH-TW.xaml |
| Russo | Language.RU.xaml | | |

### Fase 5-1 — Separador Downloads e Conclusão dos Temas

#### Separador Downloads
- Carregamento da lista de mods de 3 fontes (`mods.json`, `versions.xml`, parsing HTML)
- Funcionalidade de pesquisa (filtrar por nome/descrição/autor do mod)
- **Filtro de jogo** (Todos / The Forest / Servidor Dedicado / VR)
- **Filtro de categoria** (Todos / Correções de bugs / Balanceamento / Batotas, etc. — 12 categorias)
- UI de painel dividido para seleção de versão
- Download direto de ficheiros `.mod` → instalação na pasta do jogo
- Ordenação de colunas (clicar em nome/categoria/autor) e redimensionamento
- Eliminação de mods (limpeza de DLL + ficheiros intermediários)

#### Modernização de Ícones (Todos os Temas)
- Todos os ícones PNG de botões → ícones de fonte **Segoe MDL2 Assets**
- Aplicado em MainWindow.xaml + 14 ficheiros SubWindow
- Ícones de fonte herdam a cor de primeiro plano, garantindo visibilidade em todos os temas

| PNG Original | Ícone de Fonte | Utilização |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Adicionar / Iniciar Jogo |
| Icon_Delete | &#xE74D; | Eliminar |
| Icon_Refresh | &#xE72C; | Atualizar |
| Icon_Download | &#xE896; | Descarregar |
| Icon_Continue/Accept | &#xE8FB; | Confirmar/Continuar |
| Icon_Decline | &#xE711; | Cancelar/Fechar |
| Icon_Information | &#xE946; | Informação |
| Icon_Warning | &#xE7BA; | Aviso |
| Icon_Error | &#xEA39; | Erro |
| Icon_Browse | &#xED25; | Procurar |
| Icon_CreateMod | &#xE713; | Criar Mod |

#### Controlos Unificados em Todos os Temas

| Controlo | Clássico | Escuro | Claro |
|----------|----------|--------|-------|
| Caixa de verificação | Interruptor (Dourado) | Interruptor (AccentBrush) | Interruptor (AccentBrush) |
| Botão de opção | Círculo (Dourado) | Círculo (AccentBrush) | Círculo (AccentBrush) |
| ComboBox | Scale9 original | Fluent personalizado | Fluent personalizado |

#### Correções de Visibilidade dos Temas
- Claro: texto AccentButton forçado Branco, ajuste de Opacity dos ícones de separadores
- Escuro/Claro: abordagem `TextElement.Foreground` do ComboBoxItem para visibilidade do texto selecionado
- Clássico: recursos de fallback Fluent adicionados ao Dictionary.xaml

---

## Estrutura de Ficheiros

```
ModAPI/
├── App.xaml / App.xaml.cs          # Carregar/guardar/aplicar tema
├── Dictionary.xaml                  # Estilos originais + recursos interruptor/rádio/fallback
├── FluentStyles.xaml                # Tema escuro + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Tema claro + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # UI principal + separador downloads + seletor de tema
│   └── SubWindows/                  # 16 SubWindows (todos com ícones de fonte)
├── resources/
│   ├── langs/                       # 13 ficheiros de idioma
│   └── textures/Icons/flags/        # Ícones de bandeiras (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Requisitos de Build

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Licença

GNU General Public License v3.0 — segue a licença original.
