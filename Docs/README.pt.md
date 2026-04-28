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

**Ferramenta de Gerenciamento de Mods do The Forest — Edição Atualizada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemanha)
> Atualização: zzangae (República da Coreia)

---

## Visão Geral

ModAPI é um aplicativo de desktop para gerenciar mods de **5 jogos oficialmente suportados**. Esta edição atualizada inclui suporte a múltiplos jogos, uma aba de Configurações completamente redesenhada, configuração do caminho do Steam, configurações de UI persistentes, sistema dinâmico de tamanho de fonte, validação de início de jogo, separação de builds Debug/Release e numerosas correções de falhas verificadas em testes no jogo.

---

## Jogos Suportados

| Jogo | Motor | Versão | Steam ID | Executável |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 5 (atualizado do Unity 4) |
| Última Versão | v1.12 (VR) |
| Última Atualização | 11 de setembro de 2019 — patch de suporte VR; sem atualizações de conteúdo importantes desde então |
| Executável | `TheForest.exe` |
| Pasta de Dados | `TheForest_Data/Managed/` |
| Pasta de Mods | `mods/TheForest/` |
| Pasta de Projetos | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — totalmente suportado |

The Forest foi atualizado do Unity 4 para o Unity 5, melhorando significativamente os visuais e a física. O patch VR de setembro de 2019 foi a última atualização importante. O jogo permanece em um estado estável e finalizado — ideal para modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity (base de código integrada, unificada com Below Zero em 2022) |
| Última Versão | 2025 Patch (v18810395) |
| Última Atualização | 12 de agosto de 2025 — correções de bugs e melhorias de desempenho junto com lançamento mobile |
| Executável | `Subnautica.exe` |
| Pasta de Dados | `Subnautica_Data/Managed/` |
| Pasta de Mods | `mods/Subnautica/` |
| Pasta de Projetos | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — suportado |

Originalmente construído no Unity 5, Subnautica recebeu a atualização 'Living Large' (v2.0) no final de 2022, fundindo a base de código do motor com Below Zero para otimização e estabilidade melhoradas. Nota: o próximo *Subnautica 2* usa Unreal Engine 5.

> **XML reescrito na v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` adicionados a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity |
| Última Versão | v1.1.02 (Beta) / v1.09 (Estável) |
| Última Atualização | Março 2026 — correções de chat de voz e multijogador via branch beta |
| Executável | `Raft.exe` |
| Pasta de Dados | `Raft_Data/Managed/` |
| Pasta de Mods | `mods/Raft/` |
| Pasta de Projetos | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — suportado |
| Versions.xml | `1.1.01` (com checksum) |

Após a conclusão oficial da história na v1.0: *The Final Chapter*, os patches continuaram para melhorias do código de rede e estabilidade.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 6 (migrado do Unity 2021/2022 no final de 2025) |
| Última Versão | v0.67.0.0 |
| Última Atualização | 26 de junho de 2025 — reelaboração da distribuição de ilhas e atualização do motor; hotfixes em andamento até 2026 |
| Executável | `EscapeThePacific.exe` |
| Pasta de Dados | `EscapeThePacific_Data/Managed/` |
| Pasta de Mods | `mods/EscapeThePacific/` |
| Pasta de Projetos | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — suportado |

Completou uma reconstrução importante do sistema e migração para Unity 6 no final de 2025, permitindo ambientes mais dinâmicos. O jogo permanece em desenvolvimento ativo de Acesso Antecipado.

> **XML reescrito na v2.0.9610**: `extends="GenericUnityGame"` removido; `includeAssembly` definido apenas como `Assembly-CSharp.dll` — previne erros de herança de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 2019 |
| Última Versão | v2.9.5 |
| Última Atualização | 4 de fevereiro de 2026 — otimização para Steam Deck e melhorias de legibilidade do texto |
| Executável | `GH.exe` |
| Pasta de Dados | `GH_Data/Managed/` |
| Pasta de Mods | `mods/GH/` |
| Pasta de Projetos | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — suportado |
| Versions.xml | `2.9.5` (com checksum) |

Desenvolvido com atualizações progressivas do motor Unity 2017 → 2018 → 2019. O hotfix de fevereiro de 2026 focou na compatibilidade com Steam Deck e legibilidade do texto da UI.

> **XML reescrito na v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` adicionados; `DOTweenPro.dll` inexistente removido.
</details>

---

## Arquitetura

### Separação do Tempo de Execução

| Componente | Alvo | Tempo de Execução | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplicação desktop, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteca compartilhada |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Permanentemente fixado** — cabeçalho PE deve conter `v2.0.50727` |
| DLLs de Mod (usuário) | .NET Framework 4.8 | Game Mono 2.0 (corrigido) | Compilado com 4.8, cabeçalho PE corrigido na aplicação |

### Separação de Compilação Debug / Release

Todas as validações de arquivos e processamento de assemblies ramificam-se com base na configuração de compilação via `#if DEBUG` / `#else`.

| Localização | Compilação Debug | Compilação Release |
|---|---|---|
| `CheckSteam()` | Apenas `File.Exists()` — arquivos fictícios passam | `FileValidator.IsValidSteamExe()` — cabeçalho PE + mín. 1 MB |
| `CheckGamePath()` | Apenas `File.Exists()` — arquivos fictícios passam | `FileValidator.IsValidAssemblyDll()` — cabeçalho PE + metadados CLR + mín. 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — análise Cecil ignorada | Análise completa Mono.Cecil + modificação IL + `module.Write()` |
| `ModLib.Create()` — arquivo não encontrado | Registrar aviso, ignorar e continuar | Registrar erro, abortar com popup |

**Testes Debug** usam `create_dummy_Debug_games.ps1` para gerar arquivos de 0 bytes sob `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` e `bin\Debug\gamefiles\original\`. Estes passam nas verificações `File.Exists()` e permitem testes completos do fluxo de trabalho da UI sem instalação real do jogo.

**Compilações Release** aplicam `FileValidator` (verificação de cabeçalho PE + metadados CLR .NET) para rejeitar arquivos de 0 bytes, arquivos de texto e binários arbitrários. Apenas executáveis Windows válidos e assemblies .NET passam.

### FileValidator — Verificação de Cabeçalho PE

`ModAPI_Shared\Utils\FileValidator.cs` — aplicado apenas em compilações Release.

| Método | Verificações | Tamanho Mín. |
|---|---|---|
| `IsValidSteamExe(path)` | Assinatura MZ + assinatura PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Assinatura MZ + assinatura PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + cabeçalho de metadados CLR (diretório de dados #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline de Remapeamento de Assemblies

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

### Fallback do Resolvedor de Assemblies

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Suporte a Funcionalidades C# 7.3

| Funcionalidade | Estado | Notas |
|---|---|---|
| Correspondência de padrões (`is`, `switch`) | ✅ | Verificado no jogo |
| Interpolação de strings (`$""`) | ✅ | Verificado no jogo |
| Variável `out` inline | ✅ | Verificado no jogo |
| `async` / `await` | ✅ | Via AsyncBridge + polyfills System.Threading |
| Tuplas (`ValueTuple`) | ❌ Limite absoluto | ABI `mscorlib` Mono 2.0 — sem solução |

### Theme System

A partir da v2.0.9613, a interface de seleção de temas foi movida da aba Settings para uma **aba Themes** dedicada. Para adicionar um novo tema, basta uma linha no dicionário de `App.xaml.cs`.

| Índice | ID | Arquivo | Paleta |
|---|---|---|---|
| 0 | `classic` | Apenas `Dictionary.xaml` | Fundo de textura original do ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tom claro + destaque azul |
| 2 | `dark` | `FluentStyles.xaml` | Tom escuro + destaque azul (padrão) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Vermelho + preto |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espaço escuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Pôr do sol brilhante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano escuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brilhante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brilhante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brilhante |

As alterações de tema acionam um reinício automático do aplicativo. (salvo em `theme.cfg`)

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

### Textura de Fundo

Selecione uma imagem no cartão **Background Texture** da aba Themes para aplicá-la como fundo de todo o aplicativo. Formatos suportados: `.png` / `.jpg` / `.jpeg`, máx. 50MB, resolução 4K ou inferior. A imagem é comprimida como JPEG Q75 com um cabeçalho mágico de 16 bytes e salva como `resources\textures\ui_bg\bg.dat` (atributo Hidden). Hash SHA-256 para verificação de integridade; ao detectar adulteração, reinicialização automática + popup de aviso.

Quando o fundo está ativo, a transparência da UI é processada em duas camadas: Layer 1 (overlay MergedDictionaries) para painéis `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) para painéis baseados em `{StaticResource}` com semi-transparência.

### Sistema de Tamanho de Fonte

| Chave do Recurso | Base | Descrição |
|---|---|---|
| `AppBaseFontSize` | 13 | Texto normal |
| `AppBaseHeaderFontSize` | 16 | Cabeçalhos, títulos de painel |
| `AppBaseSmallFontSize` | 12 | Rótulos secundários |
| `AppBaseTinyFontSize` | 10 | Texto de dica |
| `AppBaseLargeFontSize` | 20 | Texto de exibição grande |

### Configuração Persistente da UI — `ui.cfg`

| Chave | Padrão | Descrição |
|-----|---------|-------------|
| `ModListWidth` | `150` | Largura da lista de mods (px) |
| `ProjectListWidth` | `150` | Largura da lista de projetos (px) |
| `AppFontSize` | `13` | Tamanho de fonte global da UI (px) |
| `AlwaysOnTop` | `false` | Janela sempre no topo |
| `TexturePath` | *(nenhum)* | Nome do arquivo original da textura de fundo (apenas exibição) |
| `TextureHash` | *(nenhum)* | Hash SHA-256 da textura de fundo |
| `TextureActive` | `false` | Estado de ativação da textura de fundo |
| `GamePathReset_{GameId}` | *(nenhum)* | Flag de redefinição do caminho do jogo |
| `SteamPathReset` | *(nenhum)* | Flag de redefinição do caminho Steam |

### Estrutura de Arquivos

```
ModAPI/
├── App.xaml / App.xaml.cs              # Registro de temas, IDs de temas, aplicação de tema
├── ui.cfg                               # Configurações persistentes da UI
├── theme.cfg                            # Tema atual
├── Windows/
│   ├── MainWindow.xaml / .cs            # UI principal — 6 abas, Temas, Configurações, caminho Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup de caminho do jogo (GameNameLabel dinâmico)
│       ├── FirstSetup.xaml / .cs        # Configuração inicial + inicialização padrão
│       └── (14 outras subjanelas)
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
│   ├── Game.cs                          # Correção de assemblies, guardas null, fallback do resolvedor
│   ├── ModLib.cs                        # Geração BaseModLib + remapeamento (#if DEBUG separação)
│   ├── Models/
│   │   └── ModProject.cs                # Criação/compilação/aplicação de projeto + guardas null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Mods filtrados, mod selecionado, filtro de jogo selecionado
│   │   ├── ModViewModel.cs              # GameId do caminho da pasta
│   │   ├── ModProjectsViewModel.cs      # Dispose() para DispatcherTimer
│   │   └── SettingsViewModel.cs         # Padrão true para UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mapeamento de versões de assemblies Mono 2.0 (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolvedor baseado em nome com cache
│   └── MonoHelper.cs                    # Utilitários auxiliares IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 arquivos de idioma
│   └── textures/ui_bg/
│       └── bg.dat                       # Imagem de fundo comprimida e protegida (gerada em tempo de execução)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Reescrita completa v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Reescrita completa v2.0.9610
    │   ├── GH.xml                       # Reescrita completa v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — não suportado
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Construtor leve + correção de inicialização ModLibrary
│   └── ModLib.cs                        # Separação #if DEBUG para análise Cecil
└── Utils/
    └── FileValidator.cs                 # Validação de cabeçalho PE + metadados CLR (apenas Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Ferramenta autônoma de atualização de versão WPF

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Gera estrutura fictícia de jogo/Steam
├── dummy_games\{GameId}\               # Caminhos fictícios de instalação de jogos
├── dummy_steam\Steam.exe               # Executável Steam fictício
└── gamefiles\original\{GameId}\        # Caminhos fictícios de backup para ModLib
```

---

## Instalação e Configuração

### Passo 1 — Pré-requisitos

| Item | Necessário |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (pré-instalado no Windows 11; [baixar](https://dotnet.microsoft.com/download/dotnet-framework/net48) para Windows 10) |
| Steam | Necessário — deve ser configurado na aba Settings |
| Pelo menos um jogo suportado | Necessário — deve ser configurado na aba Settings |

### Passo 2 — Instalar ModAPI

1. Baixar a versão mais recente do GitHub
2. Extrair em qualquer pasta (ex. `C:\ModAPI\`)
3. Executar `ModAPI.exe`
4. No primeiro início, a tela **Welcome** aparece — configurar preferências e clicar em **Continue**

### Passo 3 — Configurar caminho do Steam (aba Settings)

1. Ir para a aba **Settings**
2. Encontrar **Steam Installation Path**
3. Clicar em **Browse** → selecionar `Steam.exe`
4. Clicar em **Save**

### Passo 4 — Configurar caminhos dos jogos (aba Settings)

1. Clicar no cabeçalho do cartão do jogo para expandir
2. Clicar em **Browse** → selecionar a pasta raiz do jogo (onde o `.exe` está localizado)
3. Clicar em **Save**

| Jogo | Executável | Caminho de Exemplo |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Passo 5 — Baixar Mods (aba Downloads)

1. Ir para a aba **Downloads**
2. Selecionar um jogo no filtro de jogos
3. Pesquisar um mod e clicar em **Download**

> **Offline**: Baixar arquivos `.mod` manualmente de `modapi.survivetheforest.net` e colocá-los na pasta correspondente:

| Jogo | Pasta |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Passo 6 — Aplicar Mods e Iniciar Jogo (aba Mods)

1. Ir para a aba **Mods**
2. Selecionar um jogo no **Filtro de Jogos** (Coluna 0)
3. Ativar mods na **Lista de Mods** (Coluna 1)
4. Clicar em **Start Game**

As seguintes verificações são executadas automaticamente antes do início:

| # | Verificação | Popup de Erro |
|---|---|---|
| 1 | Caminho Steam configurado e válido | SteamNotFound |
| 2 | Jogo na pasta `mods/` corresponde ao caminho em Settings | GameModsMismatch |
| 3 | Pelo menos um mod selecionado | NoModSelected |
| 4 | Sem mods de jogos mistos na seleção | MixedGameMods |
| 5 | Caminho do jogo configurado e executável existe | GamePathNotSet / GameNotInstalled |

---

## Visão Geral das Abas

### Aba Welcome
Tela de configuração inicial (índice da aba 0). Configurar AutoUpdate, conexão Steam e preferências da tabela VersionsData. Em inícios subsequentes, esta aba fornece links da comunidade e notas de lançamento.

### Aba Mods
Fluxo de trabalho principal de gerenciamento de mods — layout de 3 colunas:

| Coluna | Conteúdo |
|---|---|
| Coluna 0 | Filtro de Jogos — botões de rádio para 5 jogos suportados |
| Coluna 1 | Lista de Mods — mods instalados com seletor de versão e caixa de ativação |
| Coluna 2 | Informação — detalhes do mod selecionado, descrição, histórico de versões |

### Aba Downloads
Navegar e baixar mods de `modapi.survivetheforest.net`.

- **Filtro de jogos**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Filtro de categorias**: 12 categorias (Bugfixes, Balancing, Cheats, …)
- **Pesquisa**: por nome do mod, descrição ou autor
- **Modo offline**: exibe instruções de pastas para todos os 5 jogos suportados

### Aba Development
Fluxo de trabalho de desenvolvimento de mods — painel de filtro de jogos (Coluna 0) cobre todos os 5 jogos suportados.

- Criar, compilar e aplicar projetos de mods por jogo
- Gerenciamento de recursos linguísticos
- Geração de ModLib com validação de 3 etapas (Steam → projeto → caminho do jogo)
- Troca segura de jogo via construtor leve `Game` (sem chamada `Verify()`)

### Aba Themes
Seleção de temas e gerenciamento de textura de fundo.

- **Seleção de tema**: 10 temas (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Textura de fundo**: Selecionar uma imagem como fundo de todo o aplicativo (compressão JPEG + processamento de segurança)
- Quando a textura de fundo está ativa, a seleção de tema é bloqueada

### Aba Settings
Configuração centralizada — 4 linhas:

| Linha | Conteúdo |
|---|---|
| 0 | Idioma / Tamanho de fonte / Tema / Largura máxima / Largura da lista de mods / Largura da lista de projetos |
| 1 | Manter VersionsData / Atualização automática / Conexão Steam / Sempre no topo |
| 2 | Caminho de instalação Steam (TextBox + Navegar + Salvar + Redefinir) |
| 3 | Caminhos de instalação dos jogos — cartão expansível por jogo (TextBox + Navegar + Salvar + Redefinir) |

---

## Alterações na v2.0.9618

### Ferramenta de Atualização de Versão (MODAPI_VersionTool)

Uma ferramenta WPF independente para atualizar o número de versão com um único clique.

**Localização**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Funcionalidades**
- Exibe automaticamente a versão atual (lida de `App.xaml.cs`)
- Insira uma nova versão e clique em **Apply Version** para atualizar ambos os arquivos simultaneamente
- Validação de formato: apenas formato `X.X.XXXX` aceito

**Arquivos Modificados**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Utilização**
1. Run `MODAPI_VersionTool.exe`
2. Insira nova versão (ex. `2.0.9619`)
3. Click **Apply Version**
4. Recompilar a solução ModAPI no Visual Studio

### Correção da Exibição de Versão na StatusBar

- `VersionLabel.Text` agora referencia `App.Version` em vez do `Version.Descriptor` codificado
- Atualizar a versão com VersionTool e recompilar agora reflete imediatamente na StatusBar

---

## Alterações na v2.0.9617

### Aba Settings — Botões de Redefinição de Caminho Adicionados

Um botão **Reset** foi adicionado ao caminho de instalação do Steam e a cada linha de caminho de instalação de jogo.

**Linha de caminho Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Linha de caminho de jogo (por jogo)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamento do reset**
- Limpa o TextBox do caminho imediatamente
- Salva flag de redefinição em `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox permanece vazio após reinício
- Contorna a limitação do Configuration XML que não persiste strings vazias

**Auto-salvamento Browse**
- Antes: necessário clique separado no botão Save após Browse
- Depois: salvo automaticamente na seleção do arquivo — refletido mesmo após mudar para a aba Mods

**Nova chave de idioma**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## Alterações na v2.0.9616

### Versions.xml — 4 Jogos Adicionados / Atualizados

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Recém-criado |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum atualizado |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Recém-criado |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum atualizado |

### Regras de Composição do Checksum

O formato do checksum difere dependendo se `Assembly-CSharp-firstpass.dll` existe para cada jogo.

| Jogo | firstpass.dll | Formato do Checksum |
|---|---|---|
| GH | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Subnautica | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| EscapeThePacific | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Raft | ❌ Ausente | Apenas `Assembly-CSharp MD5` (32 caracteres) |

### Procedimento de Atualização do Versions.xml

Adicionar uma nova entrada `<version>` sem remover as existentes.

**Passo 1 — Encontrar novo BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Passo 2 — Extrair novo checksum**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Passo 3 — Adicionar entrada ao Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## Alterações na v2.0.9615

### Correção da Expansão de Caminho de Jogo na Aba Settings

- **Altura de expansão do cartão**: A parte inferior da janela agora cresce exatamente pela altura do campo de entrada ao expandir um cartão de caminho de jogo
- **`UpdateWindowHeight()` melhorado**: Chama `UpdateLayout()` antes da medição `SizeToContent.Height`; define temporariamente `TextureLayer1` como `Collapsed` quando a textura de fundo está ativa para evitar que o tamanho original da imagem 4K afete o cálculo de altura
- **Correção de Row interno do Grid**: Alterada a última Row do Grid interno do painel de caminhos de jogos de `Height="*"` para `Height="Auto"` — remove espaço em branco inferior desnecessário

---

## Alterações na v2.0.9614

### Correção do Comportamento do Botão Maximizar

- **Maximizar**: Usa `SystemParameters.WorkArea` para maximização manual em vez de `WindowState.Maximized` — ajusta-se exatamente à resolução de tela atual sem sobrepor a barra de tarefas
- **Restaurar**: Salva `Left`, `Top`, `Width`, `Height` e `MaxWidth` antes de maximizar e restaura ao clicar no botão de restauração
- **Tratamento de `MaxWidth`**: Definido como `∞` ao maximizar, restaurado para valor salvo ao normalizar

---

## Alterações na v2.0.9613

### Nova Aba Themes

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

A interface de seleção de temas foi movida da aba Settings para uma **aba Themes** dedicada.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Registro de Temas (Estrutura Orientada por Dados)

Adicionar um novo tema agora requer apenas **uma linha** no dicionário de `App.xaml.cs`.
Todas as instruções switch foram removidas — nenhuma alteração de código necessária em outro lugar.

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

`ThemeSelector` ComboBox items are auto-generated from the `ThemeIds` loop.
Convenção de chave de idioma: `Lang.Options.Theme.{PascalCase}` (ex. `Lang.Options.Theme.Nebula`)

### Temas Suportados

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | Apenas `Dictionary.xaml` | Fundo de textura original do ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tom claro + destaque azul |
| 2 | `dark` | `FluentStyles.xaml` | Tom escuro + destaque azul (padrão) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Vermelho + preto |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espaço escuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Pôr do sol brilhante |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano escuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico brilhante |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico brilhante |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral brilhante |

Alterações de tema acionam um reinício automático do aplicativo. (salvo em `theme.cfg`)

### Recurso de Textura de Fundo

Selecione uma imagem no cartão **Background Texture** da aba Themes para aplicá-la como fundo de todo o aplicativo. Funciona com qualquer tema selecionado.

**Formatos de entrada suportados**: `.png` / `.jpg` / `.jpeg`, até 50MB, resolução 4K ou inferior

**Pipeline de processamento de imagem**

```
User-selected image (.png / .jpg / .jpeg, max 50MB, 4K or below)
  ↓
JPEG Q75 compression (memory buffer)
  ↓
16-byte magic header inserted
  "MODAPI" + "BG" + version + padding (FF 00 FE 00)
  ↓
Saved as resources\textures\ui_bg\bg.dat (Hidden attribute)
  ↓
SHA-256 hash → stored in ui.cfg as TextureHash
```

**Camadas de segurança**

| Camada | Método | Efeito |
|---|---|---|
| Cabeçalho mágico | 16 bytes inseridos antes da assinatura JPEG (FF D8 FF) | Visualizadores externos não podem reconhecer o arquivo |
| Atributo Hidden | `FileAttributes.Hidden` | Oculto do Explorer por padrão |
| Integridade SHA-256 | Hash verificado ao carregar | Adulteração aciona redefinição automática + popup de aviso |

**Comportamento de detecção de adulteração**
1. `bg.dat` deleted
2. Chaves `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` redefinidas
3. TextBox e toggle redefinidos
4. Popup `Lang.Windows.TextureTampered` exibido

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**Processamento de transparência**

Quando a imagem de fundo está ativa, os fundos da UI são processados em duas camadas.

- **Camada 1 — overlay MergedDictionaries**: Painéis referenciando `{DynamicResource FluentBgBrush}` etc. são automaticamente tornados transparentes. Restaurados com uma única chamada `Remove()` na desativação.

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Camada 2 — Percurso da árvore visual (`WalkStyleBackgrounds`)**: Elementos `{StaticResource}` em temas Fluent não são afetados pela Camada 1, então a árvore visual é percorrida diretamente para aplicar pincéis semitransparentes baseados nas cores originais.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  Processados: `Panel` (exceto Grid), `Border`, `ListBox` / `ListView`

  Excluídos: `Grid` (fundo preservado, filhos percorridos), `TabPanel` (proteção do cabeçalho da aba), `ButtonBase` / `ComboBox`, elementos `Collapsed`

  Restauração: fonte Style Setter → `ClearValue()`, fonte de valor local XAML → restaurar pincel original diretamente

**Troca de aba**

WPF TabControl carrega conteúdo de abas de forma preguiçosa, então `WalkStyleBackgrounds(this)` é re-executado com prioridade `ContextIdle` na troca de aba. Elementos já processados são ignorados via verificação `ContainsKey`.

**Bloqueio ThemeSelector**

Quando a textura de fundo está ativa, um Border `ThemeSelectorOverlay` é mostrado sobre o seletor de temas para bloquear interação.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` também protegido pela flag `_textureActive`

**Fluxo de estado da UI**

```
Image selected (Browse)
  → bg.dat created → toggle unlocked → auto-activate → TextureLayer1 shown
  → SaveAndClearBrushes() → ThemeSelectorOverlay shown

Toggle deactivated
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay hidden
  → TextureLayer1 hidden

Clear button
  → bg.dat deleted → toggle locked → TextureLayer1 hidden → brushes restored
  → GC.Collect() (releases 4K image memory)
```

**Novas chaves de idioma**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**Estrutura de arquivos**

```
ModAPI\
├── App.xaml.cs                    # Registro de temas, IDs de temas, aplicação de tema
├── Windows\
│   ├── MainWindow.xaml            # Aba Themes, overlay de seleção de tema, camada de textura 1
│   └── MainWindow.xaml.cs         # Lógica de tema e textura
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
            └── bg.dat             # Imagem de fundo comprimida e protegida (gerada em tempo de execução)
```

**Restrições de design conhecidas**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Substituição direta de chaves `MergedDictionaries` | Falha durante passagem de layout → apenas padrão `Add`/`Remove` |
| Sobrescrita de arquivo Hidden | `Access Denied` → deve redefinir `FileAttributes.Normal` antes de escrever |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## Alterações na v2.0.9612

### Separação do Módulo de Temas

- **Nova pasta `Themes/`**: Movidos `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` e `FluentStylesClassic.xaml` para `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — tema Classic usa apenas `Dictionary.xaml`; Light/Dark/outros temas Fluent carregam o XAML correspondente
- **`ModAPI.csproj`**: Caminhos XAML de temas atualizados para subdiretório `Themes\`; registrado `FluentStylesClassic.xaml`

---

## Alterações na v2.0.9611

### Correção de Bug

- **Largura da lista de mods não aplicada após troca de tema**: Corrigido problema onde a largura da lista de Mods não era aplicada após trocar entre temas Light/Dark e reiniciar — adicionada chamada `ApplyModListWidth(width)` dentro de `InitModListWidth()`

---

---

## Alterações na v2.0.9610

### Adicionado

#### Configuração de XML de Jogos e Versões

| # | Arquivo | Alteração |
|---|------|--------|
| 1 | `GH.xml` | Reescrita completa — removido inexistente `DOTweenPro.dll`; adicionados `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Reescrita completa — removido `extends="GenericUnityGame"`; adicionados `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Reescrita completa — removido `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Criado — versão `1.1.01` com checksum |
| 5 | `GH/Versions.xml` | Criado — versão `2.9.5` com checksum |
| 6 | `Subnautica/Versions.xml` | Criado — sem checksum (atualizações muito frequentes) |

#### Correções de Bugs Críticos

| # | Tipo | Problema | Correção |
|---|------|-------|-----|
| 1 | Travamento | `extends="GenericUnityGame"` causou herança `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` travado | Removido `extends` de todos os XML não-TheForest |
| 2 | Falha | `ResolutionException: XGamingRuntime.XUserGamertagComponent` durante aplicação do Subnautica | Adicionados `XGamingRuntime.dll`, `XblPCSandbox.dll` ao `copyAssembly` |
| 3 | Falha | Resolvedor falhou em DLLs adicionadas ao `copyAssembly` após backup criado | `Game.cs`: pasta de instalação real adicionada como fallback do resolvedor |
| 4 | Falha | `IOException`: `BaseModLib.dll` bloqueio de arquivo entre `CreateModLibrary` e `ApplyMods` | Loop de repetição: máx. 10 × 500ms leitura + máx. 30 × 500ms espera de existência |
| 5 | Falha | `NullReferenceException` — `typesMap` entry.Value nulo (jogo não instalado) | Adicionado `if (entry.Value == null) continue` |
| 6 | Falha | `NullReferenceException` — construtor leve `Game` construtor sem `ModLibrary = new ModLib(this)` → falha `CreateModLibrary()` | Adicionado `ModLibrary = new ModLib(this)` ao construtor leve |
| 7 | Falha | `SwitchDevGame()` — `App.Game.GamePath` vazio após construtor leve → falha `CreateModLibrary` | Definido `App.Game.GamePath = savedPath` após construtor leve |
| 8 | Jogo Errado | `EscapeThePacific` mods classificados como TheForest | `ModsViewModel`: `GameId` extraído do caminho da pasta |
| 9 | Caminho Errado | `GetGameFolder()` → `""` → resolve para raiz do drive (ex. `E:\`) | Guarda null/vazio em todos os 6 pontos de chamada |

#### Separação de Compilação Debug / Release

- **`FileValidator.cs`** — novo arquivo `ModAPI_Shared\Utils\FileValidator.cs`; registrado em `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — cabeçalho PE (MZ + PE\0\0) + mínimo 1 MB
  - `IsValidGameExe()` — cabeçalho PE + mínimo 512 KB
  - `IsValidAssemblyDll()` — cabeçalho PE + cabeçalho de metadados CLR .NET + mínimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: apenas `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: apenas `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` Cecil ignorado / `#else`: análise Cecil completa + modificação IL
- **`ModLib.Create()` arquivo não encontrado** — `#if DEBUG`: registrar aviso, ignorar / `#else`: registrar erro, abortar

#### Testes Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell para `bin\Debug\`; cria arquivos de 0 bytes para todos os 5 jogos sob `dummy_games\`, `dummy_steam\` e `gamefiles\original\` — permite testes completos do fluxo de trabalho da UI sem instalação real do jogo

#### Aba Settings

- **Cartão de caminho Steam** — integrado no cartão de Caminhos de Instalação dos Jogos; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Painel de caminhos de jogos** — `BuildGamePathsPanel()` com cartões expansíveis por jogo; TextBox usa `HorizontalAlignment=Stretch`
- Botão **Expandir Tudo / Recolher Tudo**
- Caixa de seleção **Sempre no Topo** (salva em `ui.cfg`)
- Controles de **Largura da Lista de Mods/Projetos** — início no mínimo `150`; salvo em `ui.cfg`
- ComboBox **Tamanho de Fonte** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronização de caixas** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions agora sincronizam corretamente
- **Flag `_uiInitialized`** — previne escritas prematuras de `ui.cfg` durante inicialização WPF

#### Aba Mods — Validação de Início de Jogo

Validação de cinco etapas executada a cada clique em Start Game, independentemente do estado da lista de mods:

| Etapa | Verificação | Popup |
|---|---|---|
| 1 | Caminho Steam na aba Settings válido (`Steam.exe` existe) | SteamNotFound |
| 2 | Jogo na pasta `mods/{GameId}/` corresponde ao jogo configurado em Settings | GameModsMismatch |
| 3 | Pelo menos um mod selecionado | NoModSelected |
| 4 | Sem mods de jogos mistos na seleção | MixedGameMods |
| 5 | Caminho do jogo configurado + executável existe | GamePathNotSet / GameNotInstalled |

#### Aba Development — Validação ModLib

Validação de três etapas ao clicar em Regeneração de Biblioteca de Mods:

| Etapa | Verificação | Popup |
|---|---|---|
| 1 | Caminho Steam na aba Settings válido | SteamNotFound |
| 2 | Pelo menos um projeto existe | NoProjectWarning |
| 3 | `App.Game.GamePath` definido | GamePathNotSet |

#### Aba Downloads
- String de depuração substituída por `Lang.Downloads.Status.NoDownloads`
- Preenchimento consistente para todas as mensagens de status
- Texto manual offline atualizado para 5 jogos suportados; quebra de linha via dois TextBlocks

#### Configuração Inicial e Sistema de Caminhos de Jogos
- `FirstSetup.Check()` — valor padrão `true` para `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — cria pastas `mods/` e `projects/` para todos os 5 jogos
- `SpecifyGamePath` — `GameNameLabel` mostra qual jogo; `NavigateToSettings()` redireciona para a aba Settings

#### Chaves de Idioma Novas / Atualizadas

| Chave | Valor em Inglês |
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

### Não Incluído

| Funcionalidade | Motivo |
|---|---|
| Atualização automática (manter última versão) | Infraestrutura do servidor não disponível |
| Pesquisa de atualizações | Infraestrutura do servidor não disponível |

### Removido

| Item | Motivo |
|---|---|
| Popup `SpecifyGamePath` na inicialização | Todos os caminhos configurados na aba Settings |
| Popup `SpecifySteamPath` na inicialização | Caminho Steam configurado na aba Settings |
| Sistema de login | Servidor original não mais operacional (removido na v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Não funcional no Mono 2.0 (removido na v2.0.9586) |
| Condição `UseSteam` na verificação Steam | Steam agora é sempre validado primeiro no Start Game e Regeneração de Biblioteca de Mods |

---

## Planejado para Versões Futuras

| # | Funcionalidade | Descrição |
|---|---|---|
| 1 | Atualização automática do ModAPI | Baixar e aplicar automaticamente novas versões do ModAPI |
| 2 | Atualização da tabela VersionsData do ModAPI | Atualizar automaticamente a tabela VersionsData quando novos patches do jogo forem lançados |

---

## Alterações na v2.0.9600

### Adicionado

- **Aba Downloads**: 5 filtros de jogos (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Aba Welcome**: adicionada na posição mais à esquerda (índice 0)
- **Aba Mods**: layout de 3 colunas (WrapPanel → lista vertical); ajuste automático de largura; quebra de nome do mod
- **`ModsViewModel`**: filtragem específica por jogo, `ResolveGame()` para instância `Game` correta por mod
- **`Game.cs`**: construtor leve `new Game(config, true)` — apenas identificação, sem `Verify()`
- **Build**: 4 arquivos XML de jogos registrados em `ModAPI.csproj` com `CopyToOutputDirectory=Always`
- **Build**: avisos limpos — CS0168, CS0618, CS0252
- **XML de Jogos**: listas de DLL de TheForest, Raft, GH corrigidas
- **Flags de idioma**: tamanhos de imagem padronizados em todos os 13 badges de idioma

### Removido

| Item | Motivo |
|---|---|
| `extends="GenericUnityGame"` em arquivos XML de jogos | Causava herança incorreta de `Assembly-CSharp-firstpass.dll` — removido de Subnautica, Raft, EscapeThePacific, GH |
| Layout `WrapPanel` na aba Mods | Substituído por layout Grid de 3 colunas (Filtro de Jogos / Lista de Mods / Informação) |

---

## Principais Alterações por Fase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Todos os 5 projetos migrados de .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Sistema de 3 temas, `theme.cfg`, correção de arrasto de janela, suporte a hiperlinks.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Sistema de login removido, mecanismo de atualização modernizado.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Aba Downloads, ícones Segoe MDL2 Assets, suporte a 13 idiomas.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, correção de cabeçalho PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Tela preta corrigida, `ValueTuple` removido, C# 7.3 verificado no jogo.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 filtros de jogos, aba Mods de 3 colunas, construtor leve `Game`, XML registrado.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML corrigido, caminho Steam, segurança do caminho do jogo, validação de 5 etapas do Start Game, validação de 3 etapas do ModLib, verificação de cabeçalho PE `FileValidator`, separação de compilação `#if DEBUG`, `create_dummy_Debug_games.ps1`, correção do construtor leve `ModLibrary`, correção de GamePath em `SwitchDevGame`, criação de pastas para 5 jogos, correções de falhas.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Aba Themes adicionada, 10 temas + recurso de textura de fundo, separação da pasta Themes/, correção do botão maximizar, correção de expansão do caminho do jogo, atualização Versions.xml para 4 jogos, botões de redefinição de caminho, auto-salvamento Browse, MODAPI_VersionTool.

---

## Histórico de Versões

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool adicionado (ferramenta WPF independente de atualização de versão), exibição de versão na StatusBar vinculada a App.Version

### v2.0.9617 — 2026-04-24
Botões de redefinição de caminho Steam/jogo adicionados na aba Settings, auto-salvamento Browse, estado de redefinição preservado via flag ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml criado/atualizado para 4 jogos (Subnautica, Raft, EscapeThePacific, GH), regras de composição de checksum estabelecidas, procedimento de atualização de jogo documentado

### v2.0.9615 — 2026-04-18
Correção de precisão de altura de expansão de cartão de caminho de jogo na aba Settings, prevenção de interferência de textura de fundo em UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Botão maximizar com maximização manual baseada em WorkArea, salvamento e restauração de tamanho/posição anterior

### v2.0.9613 — 2026-04-18
Aba Themes adicionada, estrutura de registro de temas orientada por dados, 10 temas suportados, recurso de textura de fundo (compressão, segurança, transparência de 2 camadas), overlay de bloqueio ThemeSelector, 12 novas chaves de idioma

### v2.0.9612 — 2026-04-18
Separação da pasta Themes/, modularização XAML de temas

### v2.0.9611 — 2026-04-18
Correção de largura de lista de mods não aplicada após troca de tema

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 filtros de jogos, layout de 3 colunas da aba Mods, largura automática, construtor leve `Game`, filtragem de jogos `ModsViewModel`, 4 arquivos XML registrados, avisos de compilação limpos, aba Welcome, flags de idioma padronizadas

### v2.0.9586 — 2026-03-31
Tela preta corrigida, polyfill finalizado, ValueTuple removido, C# 7.3 verificado

### v2.0.9561 — 2026-03-06
Suporte C# 7.3, correção de cabeçalho PE, pipeline de polyfill, resolução de assembly restaurada

### v2.0.9552 — 2026-02-25
Aba Downloads, modernização de ícones, unificação de temas, suporte a 13 idiomas

### v2.0.9500
Sistema de temas (Classic/Light/Dark), Fluent Design UI, sistema SubWindow

### v2.0.9400
Limpeza de código, remoção de login, modernização legada

### v2.0.9300
Ambiente de compilação, DLL stub UnityEngine, integração ModernWpf

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Requisitos de Compilação

| Requisito | Versão | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projetos ModAPI |
| .NET Framework SDK | 3.5 | Apenas BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licença

GNU General Public License v3.0 — segue a licença original.
