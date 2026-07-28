[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md) [![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md) [![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md) [![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md) [![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md) [![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md) [![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md) [![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md) [![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md) [![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md) [![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md) [![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md) [![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9621 - 20260728

**Ferramenta de Gestão de Mods para The Forest — Edição Aprimorada**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Alemanha)
> Aprimoramento: zzangae (República da Coreia)

---

## Visão Geral

ModAPI é uma aplicação de desktop para gerenciar mods de **5 jogos oficialmente suportados**. Esta edição aprimorada inclui suporte multijogo, uma aba Settings totalmente redesenhada, configuração do caminho do Steam, configurações de interface persistentes, um sistema dinâmico de tamanho de fonte, validação na inicialização do jogo, separação de builds Debug/Release e diversas correções de travamentos verificadas por meio de testes em jogo.

---

## Jogos Suportados

| Jogo | Motor | Versão | ID Steam | Executável |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Patch 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 5 (atualizado a partir do Unity 4) |
| Última versão | v1.12 (VR) |
| Última atualização | 11 de setembro de 2019 — patch de suporte a VR; sem novas atualizações importantes de conteúdo |
| Executável | `TheForest.exe` |
| Pasta de dados | `TheForest_Data/Managed/` |
| Pasta de mods | `mods/TheForest/` |
| Pasta de projetos | `projects/TheForest/` |
| ID do app Steam | `242760` |
| IL2CPP | ❌ Mono — totalmente suportado |

The Forest foi atualizado do Unity 4 para o Unity 5, melhorando significativamente os gráficos e a física. O patch de VR de setembro de 2019 foi a última grande atualização. O jogo permanece agora em um estado estável e finalizado — ideal para modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity (base de código integrada, unificada com Below Zero em 2022) |
| Última versão | Patch 2025 (v18810395) |
| Última atualização | 12 de agosto de 2025 — correções de bugs e melhorias de desempenho junto com o lançamento mobile |
| Executável | `Subnautica.exe` |
| Pasta de dados | `Subnautica_Data/Managed/` |
| Pasta de mods | `mods/Subnautica/` |
| Pasta de projetos | `projects/Subnautica/` |
| ID do app Steam | `264710` |
| IL2CPP | ❌ Mono — suportado |

Originalmente construído sobre o Unity 5, Subnautica recebeu a atualização "Living Large" (v2.0) no final de 2022, que uniu a base de código do motor com Below Zero para melhor otimização e estabilidade. Observação: o próximo *Subnautica 2* utiliza a Unreal Engine 5.

> **XML reescrito na v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` adicionados a `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity |
| Última versão | v1.1.02 (Beta) / v1.09 (Stable) |
| Última atualização | Março de 2026 — correções de bugs de chat de voz e multijogador via ramificação beta |
| Executável | `Raft.exe` |
| Pasta de dados | `Raft_Data/Managed/` |
| Pasta de mods | `mods/Raft/` |
| Pasta de projetos | `projects/Raft/` |
| ID do app Steam | `648800` |
| IL2CPP | ❌ Mono — suportado |
| Versions.xml | `1.1.01` (com checksum) |

Após a conclusão oficial da história na v1.0: *The Final Chapter*, os patches continuaram para melhorias no código de rede e estabilidade. Uma atualização da ramificação beta em março de 2026 resolveu problemas de chat de voz e multijogador.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 6 (migrado do Unity 2021/2022 no final de 2025) |
| Última versão | v0.67.0.0 |
| Última atualização | 26 de junho de 2025 — reformulação da distribuição de ilhas e atualização do motor; hotfixes em andamento até 2026 |
| Executável | `EscapeThePacific.exe` |
| Pasta de dados | `EscapeThePacific_Data/Managed/` |
| Pasta de mods | `mods/EscapeThePacific/` |
| Pasta de projetos | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — suportado |

Concluiu uma grande reconstrução do sistema e a migração para o Unity 6 no final de 2025, permitindo ambientes mais dinâmicos. O jogo permanece em desenvolvimento ativo em Acesso Antecipado.

> **XML reescrito na v2.0.9610**: `extends="GenericUnityGame"` removido; `includeAssembly` definido apenas para `Assembly-CSharp.dll` — evita erros de herança de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Item | Valor |
|---|---|
| Motor | Unity 2019 |
| Última versão | v2.9.5 |
| Última atualização | 4 de fevereiro de 2026 — otimização para Steam Deck e melhorias na legibilidade do texto |
| Executável | `GH.exe` |
| Pasta de dados | `GH_Data/Managed/` |
| Pasta de mods | `mods/GH/` |
| Pasta de projetos | `projects/GH/` |
| ID do app Steam | `763790` |
| IL2CPP | ❌ Mono — suportado |
| Versions.xml | `2.9.5` (com checksum) |

Desenvolvido através do Unity 2017 → 2018 → 2019 ao longo de seu ciclo de vida. O hotfix de fevereiro de 2026 focou na compatibilidade com Steam Deck e na legibilidade da interface.

> **XML reescrito na v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` adicionados; `DOTweenPro.dll` (inexistente) removido.
</details>

---

<details>
<summary><b>Arquitetura</b></summary>

### Separação de Runtime

| Componente | Alvo | Runtime | Motivo |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Aplicação de desktop, API moderna completa |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Biblioteca compartilhada |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fixado permanentemente** — o cabeçalho PE deve indicar `v2.0.50727` |
| DLLs de mods (usuário) | .NET Framework 4.8 | Game Mono 2.0 (corrigido) | Compilado com 4.8, cabeçalho PE corrigido no momento da aplicação |

### Ferramentas para Desenvolvedores

Utilitários WPF independentes para gerenciamento de projetos. Não distribuídos aos usuários finais.

| Ferramenta | Projeto | Objetivo |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Atualiza simultaneamente a versão de `AssemblyInfo.cs` e `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Gerencia arquivos de idioma — adicionar, editar, desativar, incorporação nativa |

**VersionTool — Gerenciamento de Versões**

Uma ferramenta WPF independente para atualizar o número de versão com um único clique.

- Exibe automaticamente a versão atual (lida de `App.xaml.cs`)
- Digite uma nova versão e clique em **Apply Version** para atualizar ambos os arquivos simultaneamente
- Validação de formato: apenas o formato `X.X.XXXX` é aceito

| Arquivo | Caminho | Alteração |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Sistema de Idiomas**

```
resources/langs/langs.json          ← Registro de idiomas (flags builtin / active)
resources/langs/Language.XX.xaml    ← Chaves de tradução por idioma
resources/langs/Language.XX.png     ← Imagem da bandeira (36×24, de flagcdn.com/h24/)
```

Fluxo de incorporação nativa (botão Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() reescrito (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml registrado (ModAPI\ModAPI.csproj)
  → Próxima compilação: idioma totalmente incorporado, disponível offline
```

### Separação de Builds Debug / Release

Toda a validação de arquivos e processamento de assemblies se ramifica de acordo com a configuração de build via `#if DEBUG` / `#else`.

| Local | Build Debug | Build Release |
|---|---|---|
| `CheckSteam()` | apenas `File.Exists()` — arquivos fictícios passam | `FileValidator.IsValidSteamExe()` — cabeçalho PE + mín. 1 MB |
| `CheckGamePath()` | apenas `File.Exists()` — arquivos fictícios passam | `FileValidator.IsValidAssemblyDll()` — cabeçalho PE + metadados CLR + mín. 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — pula a análise Cecil | Análise Mono.Cecil completa + modificação de IL + `module.Write()` |
| `ModLib.Create()` — arquivo não encontrado | Registra aviso, pula e continua | Registra erro, aborta com popup |

**Os testes Debug** usam `create_dummy_Debug_games.ps1` para gerar arquivos de espaço reservado de 0 bytes em `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` e `bin\Debug\gamefiles\original\`. Estes passam nas verificações `File.Exists()` e permitem testar todo o fluxo de trabalho da interface sem uma instalação real do jogo.

**As builds Release** aplicam `FileValidator` (verificação de cabeçalho PE + metadados CLR .NET) para rejeitar arquivos de 0 bytes, arquivos de texto e binários arbitrários. Apenas executáveis Windows válidos e assemblies .NET válidos passam.

### FileValidator — Verificação do Cabeçalho PE

`ModAPI_Shared\Utils\FileValidator.cs` — aplicado somente em builds Release.

| Método | Verificações | Tamanho mínimo |
|---|---|---|
| `IsValidSteamExe(path)` | Assinatura MZ + assinatura PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Assinatura MZ + assinatura PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + cabeçalho de metadados CLR (diretório de dados #14) | 8 KB |

```
Layout do cabeçalho PE verificado:
[0x00] 4D 5A          ← assinatura DOS "MZ"
[0x3C] XX XX XX XX   ← offset do cabeçalho PE (little-endian)
[offset] 50 45 00 00 ← assinatura "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← presença do cabeçalho CLR .NET
```

### Pipeline de Remapeamento de Assemblies

```
[Desenvolvedor do mod compila com .NET 4.8]
  → DLL do mod: cabeçalho PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, etc.
  → modModule.RuntimeVersion = "v2.0.50727"
      cabeçalho PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → cabeçalho PE aceito ✅  →  referências resolvidas ✅
```

### Fallback do Resolvedor de Assemblies

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← pasta de backup
2. {ActualGameInstallPath}/{AssemblyPath}        ← pasta de instalação do jogo (fallback)
```

### Suporte a Recursos do C# 7.3

| Recurso | Status | Notas |
|---|---|---|
| Correspondência de padrões (`is`, `switch`) | ✅ | Verificado no jogo |
| Interpolação de strings (`$""`) | ✅ | Verificado no jogo |
| Variável `out` embutida | ✅ | Verificado no jogo |
| `async` / `await` | ✅ | Via AsyncBridge + polyfills System.Threading |
| Tuplas (`ValueTuple`) | ❌ Limite rígido | ABI `mscorlib` do Mono 2.0 — sem solução alternativa |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

A partir da v2.0.9613, a interface de seleção de tema foi movida da aba Settings para uma aba **Themes** dedicada. Adicionar um novo tema requer apenas uma linha no dicionário `App.xaml.cs`.

| Índice | ID | Arquivo | Paleta |
|---|---|---|---|
| 0 | `classic` | apenas `Dictionary.xaml` | Plano de fundo com textura original do ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tom claro + destaque azul |
| 2 | `dark` | `FluentStyles.xaml` | Tom escuro + destaque azul (padrão) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Vermelho + preto |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espaço escuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Pôr do sol claro |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano escuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico claro |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico claro |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral claro |

A mudança de tema aciona uma reinicialização automática do aplicativo. (salvo em `theme.cfg`)

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

### Textura de Fundo

Selecione uma imagem no cartão **Background Texture** na aba Themes para aplicá-la como plano de fundo em toda a aplicação. Formatos suportados: `.png` / `.jpg` / `.jpeg`, até 50 MB, resolução 4K ou inferior. A imagem é compactada como JPEG Q75 com um cabeçalho mágico de 16 bytes e salva como `resources\textures\ui_bg\bg.dat` (atributo Hidden). Hash SHA-256 para verificação de integridade; adulteração aciona reset automático + popup de aviso.

Quando o plano de fundo está ativo, a transparência da interface é processada em duas camadas: Camada 1 (sobreposição MergedDictionaries) para painéis `{DynamicResource}`, Camada 2 (WalkStyleBackgrounds) para painéis baseados em `{StaticResource}` com semitransparência.

### Sistema de Tamanho de Fonte

| Chave de recurso | Base | Descrição |
|---|---|---|
| `AppBaseFontSize` | 13 | Texto normal |
| `AppBaseHeaderFontSize` | 16 | Cabeçalhos, títulos de painéis |
| `AppBaseSmallFontSize` | 12 | Rótulos secundários |
| `AppBaseTinyFontSize` | 10 | Texto de dica |
| `AppBaseLargeFontSize` | 20 | Texto de exibição grande |

### Configuração Persistente da Interface — `ui.cfg`

| Chave | Padrão | Descrição |
|-----|---------|-------------|
| `ModListWidth` | `150` | Largura da lista na aba Mods (px) |
| `ProjectListWidth` | `150` | Largura da lista de projetos na aba Development (px) |
| `AppFontSize` | `13` | Tamanho de fonte global da interface (px) |
| `AlwaysOnTop` | `false` | Janela sempre em primeiro plano |
| `TexturePath` | *(nenhum)* | Nome de arquivo original da textura de fundo (apenas exibição) |
| `TextureHash` | *(nenhum)* | Hash SHA-256 da textura de fundo |
| `TextureActive` | `false` | Estado de ativação da textura de fundo |
| `GamePathReset_{GameId}` | *(nenhum)* | Flag de reset do caminho do jogo |
| `SteamPathReset` | *(nenhum)* | Flag de reset do caminho do Steam |
</details>

<details>
<summary><b>Estrutura do Projeto</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Configurações persistentes da interface
├── theme.cfg                            # Tema atual
├── Windows/
│   ├── MainWindow.xaml / .cs            # Interface principal — 6 abas, Themes, Settings, caminho do Steam,
│   │                                    #   proteção contra downloads de 0 bytes, debounce do slider, leituras silenciosas de configuração
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup do caminho do jogo (GameNameLabel dinâmico)
│       ├── FirstSetup.xaml / .cs        # Configuração inicial + inicialização de padrões
│       └── (14 outras SubWindows)
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
│   ├── Mod.cs                           # Carregamento de arquivos de mod, análise de cabeçalho LF/CRLF, log de diagnóstico
│   ├── ModLib.cs                        # Geração de BaseModLib + remapeamento (separação #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Criação/compilação/aplicação de projeto + proteções null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   prevenção de novas tentativas para mods corrompidos
│   │   ├── ModViewModel.cs              # GameId a partir do caminho da pasta
│   │   ├── ModProjectsViewModel.cs      # Dispose() para DispatcherTimer
│   │   └── SettingsViewModel.cs         # Valor padrão true para UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mapeamento de versões de assembly Mono 2.0 (20 assemblies)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolvedor baseado em nome com cache
│   └── MonoHelper.cs                    # Utilitários auxiliares de IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 arquivos de idioma + langs.json (chaves LangTool.* adicionadas na v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Imagem de fundo compactada e protegida (gerada em tempo de execução)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Reescrita completa na v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Reescrita completa na v2.0.9610
    │   ├── GH.xml                       # Reescrita completa na v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — não suportado
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt com parâmetro silent
├── Data/
│   ├── Game.cs                          # Criação automática de backup para ApplyMods, resolvedor condicional,
│   │                                    #   fallback para pasta do jogo, correção do construtor leve + inicialização do ModLib
│   └── ModLib.cs                        # Separação #if DEBUG, fallback para pasta do jogo para IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Validação de cabeçalho PE + metadados CLR (somente Release, mín. 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Ferramenta WPF independente de atualização de versão
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Entrada de versão, botão Apply, exibição da versão atual
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Ferramenta WPF independente de gerenciamento de idiomas
├── App.xaml / App.xaml.cs              # Carregamento/troca de idioma, langtool.cfg
├── MainWindow.xaml / .cs               # Interface principal — lista de idiomas, painel de edição, seletor de caminho
├── AddLanguageDialog.xaml / .cs        # ComboBox de seleção de país ISO 3166-1
├── ModApiDialog.xaml / .cs             # Caixa de diálogo personalizada no estilo ModAPI (Info/Aviso/Confirmar/Perguntar)
├── Models/
│   ├── LanguageEntry.cs                # Modelo de entrada de idioma (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Modelo raiz de langs.json
│   └── IsoCountry.cs                   # Modelo de país ISO para ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Leitura/gravação de langs.json
    ├── FlagDownloader.cs               # Download de bandeira de flagcdn.com h24
    ├── XamlGenerator.cs                # Geração/salvamento/análise de Language.XX.xaml
    ├── MissingKeyDetector.cs           # Detecção de chaves ausentes com base na referência em inglês
    ├── IsoCountryList.cs               # Lista completa de países ISO 3166-1 (196 países, offline)
    └── BuiltinCodeWriter.cs            # Reescrita de CreateDefaultLangsJson() + registro em ModAPI.csproj

bin\Debug\                               # Somente para testes Debug
├── create_dummy_Debug_games.ps1         # Gera estrutura fictícia de jogo/Steam
├── dummy_games\{GameId}\               # Caminhos de instalação fictícios de jogos
├── dummy_steam\Steam.exe               # Executável fictício do Steam
└── gamefiles\original\{GameId}\        # Caminhos de backup fictícios para ModLib
```

---

</details>

<details>
<summary><b>Instalação e Configuração</b></summary>

### Passo 1 — Pré-requisitos

| Item | Necessário |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (pré-instalado no Windows 11; [baixar](https://dotnet.microsoft.com/download/dotnet-framework/net48) para Windows 10) |
| Steam | Necessário — deve ser configurado na aba Settings |
| Pelo menos um jogo suportado | Necessário — deve ser configurado na aba Settings |

### Passo 2 — Instalar o ModAPI

1. Baixe a versão mais recente do GitHub
2. Extraia para qualquer pasta (ex.: `C:\ModAPI\`)
3. Execute `ModAPI.exe`
4. Na primeira execução, a tela **Welcome** aparece — configure as preferências e clique em **Continue**

### Passo 3 — Configurar o Caminho do Steam (Aba Settings)

1. Vá para a aba **Settings**
2. Encontre **Steam Installation Path**
3. Clique em **Browse** → selecione `Steam.exe`
4. Clique em **Save**

### Passo 4 — Configurar os Caminhos dos Jogos (Aba Settings)

1. Clique no cabeçalho de um cartão de jogo para expandi-lo
2. Clique em **Browse** → selecione a pasta raiz do jogo (onde o `.exe` está localizado)
3. Clique em **Save**

| Jogo | Executável | Exemplo de caminho |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Passo 5 — Baixar Mods (Aba Downloads)

1. Vá para a aba **Downloads**
2. Selecione um jogo no filtro de jogos
3. Navegue ou pesquise um mod e clique em **Download**

> **Offline**: baixe os arquivos `.mod` manualmente de `modapi.survivetheforest.net` e coloque-os na pasta correspondente:

| Jogo | Pasta |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Passo 6 — Aplicar Mods e Iniciar o Jogo (Aba Mods)

1. Vá para a aba **Mods**
2. Selecione um jogo em **Game Filter** (coluna 0)
3. Marque os mods a serem ativados em **Mod List** (coluna 1)
4. Clique em **Start Game**

As seguintes verificações são executadas automaticamente antes do início:

| # | Verificação | Popup em caso de falha |
|---|---|---|
| 1 | Caminho do Steam configurado e válido | SteamNotFound |
| 2 | O jogo na pasta `mods/` corresponde ao caminho do jogo em Settings | GameModsMismatch |
| 3 | Pelo menos um mod selecionado | NoModSelected |
| 4 | Nenhuma mistura de mods de jogos diferentes na seleção | MixedGameMods |
| 5 | Caminho do jogo configurado e executável existente | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Visão Geral das Abas</b></summary>

### Aba Welcome
Tela de configuração inicial (índice de aba 0). Configure AutoUpdate, conexão com o Steam e preferências da tabela VersionsData. Nas inicializações subsequentes, esta aba fornece links da comunidade e notas de lançamento.

### Aba Mods
Fluxo de trabalho principal de gerenciamento de mods — layout de 3 colunas:

| Coluna | Conteúdo |
|---|---|
| Coluna 0 | Game Filter — botões de rádio para os 5 jogos suportados |
| Coluna 1 | Mod List — mods instalados com seletor de versão e caixa de seleção de ativação |
| Coluna 2 | Information — detalhes, descrição e histórico de versões do mod selecionado |

### Aba Downloads
Navegue e baixe mods de `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 categorias (correções de bugs, balanceamento, trapaças, …)
- **Search**: por nome do mod, descrição ou autor
- **Offline mode**: exibe instruções de pastas para todos os 5 jogos suportados

### Aba Development
Fluxo de trabalho de desenvolvimento de mods — o painel de filtro de jogo (coluna 0) abrange todos os 5 jogos suportados.

- Criação, compilação e aplicação de projetos de mods por jogo
- Gerenciamento de recursos de idioma
- Geração de ModLib com validação em 3 etapas (Steam → projeto → caminho do jogo)
- Troca segura de jogo por meio de um construtor `Game` leve (sem chamada a `Verify()`)

### Aba Themes
Seleção de tema e gerenciamento de textura de fundo.

- **Seleção de tema**: 10 temas (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Textura de fundo**: selecione uma imagem como plano de fundo de toda a aplicação (compressão JPEG + processamento de segurança)
- Quando a textura de fundo está ativa, a seleção de tema fica bloqueada

### Aba Settings
Configuração centralizada — 4 linhas:

| Linha | Conteúdo |
|---|---|
| 0 | Idioma / Tamanho da fonte / Largura máxima / Largura da Mod List / Largura da Project List |
| 1 | Manter VersionsData / Atualização automática / Conexão com Steam / Sempre em primeiro plano |
| 2 | Steam Installation Path (caixa de texto + Browse + Save + Reset) |
| 3 | Game Installation Paths — cartão expansível por jogo (caixa de texto + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Ferramenta de Gerenciamento de Idiomas)

Uma ferramenta WPF independente para gerenciar os arquivos de idioma do ModAPI. Adicionada à solução como `LangTool\MODAPI_LangTool.csproj`.

**Localização**: `LangTool\MODAPI_LangTool.csproj`

**Recursos Principais**

| Recurso | Descrição |
|---|---|
| Lista de idiomas | Exibe todos os idiomas de `langs.json` com ícones de status (🔒 incorporado / 🚫 inativo / ✅ ativo) |
| Adicionar idioma | Selecione um país no ComboBox ISO 3166-1 → a bandeira é baixada automaticamente de `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` é gerado automaticamente a partir do modelo em inglês |
| Editar idioma | `isoCode` / `langCode` bloqueados; `langName` e as chaves de tradução são editáveis quando ativo |
| Desativar / Ativar | Alterna a flag `active` em `langs.json` — o arquivo é preservado, oculto da lista do ModAPI |
| Atualização (incorporação nativa) | Converte `builtin: false` → `true` — irreversível, confirmação em 2 etapas — reescreve automaticamente `CreateDefaultLangsJson()` no código-fonte e registra `Language.XX.xaml` em `ModAPI.csproj` |
| Detecção de chaves ausentes | Compara com a referência em inglês — mostra a contagem de chaves ausentes/vazias e o progresso da tradução |
| Proteção de idiomas incorporados | Idiomas com `builtin: true` são somente leitura — não é possível editar, desativar ou atualizar |
| Proteção de idiomas inativos | Idiomas com `active: false` são somente leitura até a reativação |
| Interface de idioma | O próprio LangTool suporta todos os 13 idiomas do ModAPI — seletor de idioma com bandeira no canto superior direito |
| Memorização de caminho | O caminho raiz do ModAPI selecionado é salvo em `langtool.cfg` — carregado automaticamente na próxima inicialização |
| Caixas de diálogo personalizadas | Todos os popups usam o `ModApiDialog` de tema escuro no estilo ModAPI em vez da MessageBox do sistema |

**Estrutura de langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Convenção de Imagens de Bandeira**

```
Código ISO (minúsculas) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                          resources/langs/
```

**Comportamento do Botão Update**

Ao clicar no botão Update em um idioma ativo não incorporado:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` reescrito com todos os idiomas atualmente `builtin: true`
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` registrado
4. Próxima compilação — idioma totalmente incorporado, disponível offline

**Chaves de Idioma Adicionadas** (`Lang.LangTool.*`)

53 novas chaves adicionadas a todos os 13 arquivos de idioma, cobrindo todas as strings de interface do LangTool, mensagens de diálogo e textos de status.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Ferramenta de Atualização de Versão)

Uma ferramenta WPF independente para atualizar o número de versão com um único clique.

**Localização**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Recursos**
- Exibe automaticamente a versão atual (lida de `App.xaml.cs`)
- Digite uma nova versão e clique em **Apply Version** para atualizar ambos os arquivos simultaneamente
- Validação de formato: apenas o formato `X.X.XXXX` é aceito

**Arquivos Modificados**

| Arquivo | Caminho | Alteração |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Uso**
1. Execute `MODAPI_VersionTool.exe`
2. Digite a nova versão (ex.: `2.0.9619`)
3. Clique em **Apply Version**
4. Recompile a solução ModAPI no Visual Studio

**Exibição de Versão na StatusBar**

- `VersionLabel.Text` agora referencia `App.Version` em vez de um descritor codificado
- A atualização da versão com o VersionTool e uma recompilação são refletidas imediatamente na StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Sistema de Log — Separação em Dois Arquivos (`ModAPI.log` / `ModAPI.detailed.log`)

Os logs de diagnóstico exclusivos para desenvolvedores eram anteriormente limitados por `#if DEBUG`, o que os tornava invisíveis em builds Release exatamente quando eram mais necessários para solucionar um problema do usuário. Um sistema de dois arquivos substitui isso:

| Arquivo | Conteúdo |
|---|---|
| `ModAPI.log` | Log principal voltado ao usuário — aparência inalterada, não mais ruidoso do que antes |
| `ModAPI.detailed.log` | Toda chamada de log, sempre, tanto em Release quanto em Debug — para diagnosticar problemas relatados pelos usuários |

**`Debug.cs`** — `Log()` possui um parâmetro `detailedOnly`. Quando `true`, a mensagem é gravada somente em `ModAPI.detailed.log`; todos os blocos `#if DEBUG` anteriores foram convertidos para essa flag em vez de serem totalmente excluídos da compilação, de modo que sempre sejam capturados no arquivo detalhado, mesmo em Release. Isso resulta em um modelo de severidade de 4 níveis:

| Nível | Significado |
|---|---|
| Verbose (`detailedOnly: true`) | Rastreamentos repetitivos/mecânicos — por tipo, por arquivo, por método |
| Notice | Fluxo legível por humanos — mensagens de progresso e sucesso |
| Warning | Problemas potenciais, ainda não falhas |
| Error | Falhas confirmadas |

**Fontes de ruído de log identificadas e convertidas para `detailedOnly: true`:**

| Arquivo | O que estava inundando `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Mensagens de varredura/pulo/fila de `FindMods()` repetidas a cada polling de 1 segundo |
| `Game.cs` | Linhas de rastreamento TLS/URL de `UpdateVersions()`, entradas de mapeamento de tipo do Cecil |
| `ModLib.cs` | Processamento de assemblies por tipo/método pelo Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — responsável pela grande maioria do volume de `ModAPI.log` (dezenas de milhares de linhas para uma única compilação de mod do Green Hell) |
| `Mod.cs` | Dump completo do XML de cabeçalho do mod (`configuration.ToString()`) registrado integralmente a cada carregamento de mod |

**Log de discrepâncias de checksum — resumido em vez de por item:** `Header.Verify()` anteriormente registrava uma linha `Mismatched checksum at "..."` para cada entrada incompatível de `InjectInto`/`AddMethod`/`AddField`/`AddClass`, o que podia significar dezenas de linhas para um único mod desatualizado. Agora registra um único resumo de nível Warning em `ModAPI.log` (ex.: `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), enquanto a discriminação completa por item permanece disponível em `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Alterações na v2.0.9621</b></summary>

## Alterações na v2.0.9621

### Novas funcionalidades

#### Detecção automática em toda a biblioteca Steam

`FindGamePath()` agora, quando um jogo não é encontrado através dos `SearchPaths` fixos, também pesquisa em **todas as bibliotecas Steam registadas no sistema** (analisadas uma vez a partir de `libraryfolders.vdf`, colocadas em cache durante a sessão). Isto aplica-se aos 5 jogos suportados, não apenas ao atualmente ativo.

- Novo `Game.GetSteamLibraryFolders()` — analisa `libraryfolders.vdf`, cache estática por sessão
- Controlado pela caixa **Conexão Steam**: desativada (predefinição em instalação nova) → a deteção automática é ignorada para os 5 jogos, os caminhos ficam vazios até serem configurados manualmente. Ativada → os 5 jogos são pesquisados de forma consistente através do mesmo método.

#### Deteção automática de mods de outro jogo

Um ficheiro `.mod` colocado na pasta do jogo errado (por exemplo, um mod de Green Hell copiado para `mods\TheForest\`) é agora detetado automaticamente, em vez de corromper silenciosamente uma operação de Apply.

- `Game.CheckModGameCompatibility()` (usado dentro de `ApplyMods()`) verifica que cada tipo `AddMethod`/`AddField`/`InjectInto` declarado por um mod existe realmente nos assemblies reais do jogo de destino antes de começar a injeção. Mods incompatíveis são automaticamente excluídos dessa aplicação; o resto é aplicado normalmente.
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` executam a mesma verificação no momento em que o mod é carregado (leve — lê os bytes do assembly para memória, extrai os nomes dos tipos, liberta o ficheiro de imediato). Mods incompatíveis mostram um **selo de aviso ⚠** com dica na aba Mods, mesmo antes de clicar em Apply.
- Se mods foram excluídos e/ou nada foi finalmente aplicado, Iniciar Jogo mostra um único popup combinado em vez de vários empilhados; o jogo não é iniciado se não restar nenhum mod aplicado (`Game.LastAppliedModCount`).

#### Aba Configurações — Log de desenvolvedor / Limpar logs ao iniciar

Duas novas caixas, depois de **Conexão Steam** e antes de **Sempre no topo**:

| Chave | Descrição |
|---|---|
| `Lang.Options.Labels.DevLog` | Ativa `ModAPI.dev.log` (renomeado de `ModAPI.detailed.log`) — equivale a executar com `--dev` |
| `Lang.Options.Labels.ClearLogsOnStart` | Limpa a pasta `logs\` a cada início |

`Debug.ClearLogs()` fecha os fluxos de log abertos antes de apagar ficheiros, evitando erros de "ficheiro em uso".

#### Registo global de exceções não tratadas

`App.xaml.cs` agora liga-se a `DispatcherUnhandledException` (thread de UI) e `AppDomain.UnhandledException` (threads em segundo plano). Exceções que antes faziam a app falhar sem deixar rasto são agora registadas — tipo, mensagem e stack trace completo — antes do processo terminar.

---

### Correções críticas de bugs

| # | Ficheiro | Problema | Correção |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` resolvia um caminho explicitamente reiniciado (string vazia) para `RootPath` em vez de `""`, porque `Path.GetFullPath(RootPath + separador + "")` reduz-se a `RootPath` | Valores armazenados vazios agora retornam `""` diretamente, antes da junção do caminho |
| 2 | `MainWindow.xaml.cs` | A ordem de validação do Iniciar Jogo diferia entre o filtro "Todos" e um filtro específico, mostrando por vezes um popup de seleção de mod ou jogo antes de um problema mais fundamental (caminho de Steam/jogo em falta) | Ambos os caminhos seguem agora a mesma ordem: Steam → caminho do jogo → seleção de mods → seleção do jogo |
| 3 | `MainWindow.xaml.cs` | A recolha de mods para Iniciar Jogo ignorava o filtro de jogo ativo — mods marcados para outro jogo (invisível) eram na mesma contados, ativando o popup errado | A recolha de mods respeita agora o filtro atual; apenas "Todos" agrega entre todos os jogos |
| 4 | `ModsViewModel.cs` | `Mod.Mods` estava indexado apenas por `{ModId}-{Versão}`, portanto nomes de ficheiro idênticos em duas pastas de jogos diferentes colidiam — o `Load()` do segundo nunca era chamado | A chave agora inclui o GameId: `{GameId}-{ModId}-{Versão}` |
| 5 | `ModsViewModel.cs` | Após a correção #4, `UpdateMods()` continuava a agrupar entradas da lista apenas por ModId, fundindo dois mods com o mesmo nome de jogos diferentes numa única entrada — falha com `ArgumentException: An item with the same key has already been added` quando ambos declaravam a mesma versão | O agrupamento de exibição agora também compara o GameId |
| 6 | `Game.cs` | A lista `<files>` do `Versions.xml` de Green Hell contém os mesmos dois ficheiros duplicados com capitalização diferente (`_Data`/`_data`); `CheckFiles` era um `HashSet<string>` sensível a maiúsculas/minúsculas, portanto ambos eram processados em hash, duplicando o checksum calculado e causando falsas falhas de integridade | `CheckFiles` agora usa `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | O passo "remover ficheiros antigos" de `ModLib.Create()` não tinha proteção de nova tentativa contra um `BaseModLib.dll` bloqueado, e `Game.CreateModLibrary()` não tinha qualquer tratamento de exceções — um bloqueio fazia falhar toda a aplicação numa thread em segundo plano | Adicionado um ciclo de nova tentativa de 10×500ms ao passo de eliminação; `CreateModLibrary()` agora envolve a chamada em try/catch |
| 8 | `MainWindow.xaml.cs` | Quando `ApplyMods()` terminava sem realmente aplicar nenhum mod (por exemplo, todos excluídos), sinalizava mesmo assim a conclusão como um sucesso real, portanto o jogo era iniciado sem qualquer modificação | `Game.LastAppliedModCount` distingue "nada aplicado" de "N aplicados"; o início é ignorado em 0 |
| 9 | `MainWindow.xaml.cs` | A altura da janela não era recalculada ao mudar o tamanho da fonte, ao carregar no início um tamanho de fonte grande guardado, nem ao mudar para a aba Configurações (`Tabs_SelectionChanged` estava vazio) — com fontes grandes o último cartão de caminho de jogo era cortado | Recálculo de altura adicionado nos três pontos |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` não tinha limite superior — expandir os 5 cartões de caminho de jogo de uma vez podia fazer a janela ocupar o ecrã inteiro ou mais | Altura agora limitada a `SystemParameters.WorkArea.Height` |
| 11 | `MainWindow.xaml.cs` | As pastas `mods\`/`projects\` eram criadas incondicionalmente para os 5 jogos a cada início, independentemente de o jogo estar instalado | As pastas agora só são criadas para jogos com um caminho verificado e um executável existente |
| 12 | `Game.cs` | `UpdateVersions()` podia falhar ao guardar `Versions.xml` se a pasta de destino ainda não existisse (oculto até agora porque as 5 pastas são distribuídas pré-confirmadas) | A pasta é criada via `Directory.CreateDirectory()` imediatamente antes de guardar |

---

### Aba Configurações — Valores predefinidos na primeira execução alterados

`AutoUpdate`, `UseSteam` (Conexão Steam) e `UpdateVersionsTable` (Manter VersionsData) agora estão **desmarcados** por predefinição numa instalação nova (anteriormente marcados por predefinição). Estas três funcionalidades continuam incompletas do lado do servidor, portanto agora são opt-in — tal como `DevLog`/`ClearLogsOnStart`.

### Interface

- Linha de caixas da aba Configurações (`SettingsCheckboxes`): `StackPanel` → `WrapPanel`, para que as etiquetas passem para a linha seguinte em vez de serem cortadas com fontes grandes.

### Novas chaves de idioma (13 idiomas)

| Chave | Valor em inglês |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### Ficheiros modificados

| Ficheiro | Caminho | Alteração |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Ordem de validação do Iniciar Jogo unificada, recolha de mods sensível ao filtro, popup de resultado combinado, deteção automática de 4 jogos via biblioteca Steam controlada por UseSteam, correções de altura de janela (tamanho de fonte / mudança de aba / limite) |
| `MainWindow.xaml` | `ModAPI\Windows\` | Caixas DevLog/ClearLogsOnStart na aba Configurações, `WrapPanel` |
| `Game.cs` | `ModAPI_Shared\Data\` | Pesquisa em biblioteca Steam, `CheckFiles` insensível a maiúsculas/minúsculas, verificações de compatibilidade de mods (completa + leve), `LastAppliedModCount`/`LastExcludedModsSummary`, tratamento de exceções em `CreateModLibrary()`, deteção automática controlada por UseSteam |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Ciclo de nova tentativa ao eliminar ficheiros antigos |
| `Mod.cs` | `ModAPI_Shared\Data\` | Campo `GameMismatchReason` |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Correção do bug de caminho vazio em `GetPath()` |
| `Debug.cs` | `ModAPI_Shared\` | Renomeado para `ModAPI.dev.log`, campo `DevMode`, `ClearLogs()` |
| `App.xaml.cs` | `ModAPI\` | Manipuladores globais de exceções, ligação de `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Chaves `Mod.Mods` por jogo, agrupamento de exibição por jogo, selo de incompatibilidade, supressão de spam de logs |
| `ModViewModel.cs` | `ModAPI\Data\ViewModels\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\Data\ViewModels\` | `DevLog`/`ClearLogsOnStart`, valores predefinidos opt-in para 3 caixas existentes |
| `FirstSetup.xaml` | `ModAPI\Windows\SubWindows\` | Valores predefinidos de 3 caixas alterados para desmarcado |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\Windows\SubWindows\` | Novo |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 8 novas chaves |

---

</details>

<details>
<summary><b>Alterações na v2.0.9620</b></summary>

## Alterações na v2.0.9620

### MODAPI_LangTool Adicionado

Foi adicionada uma ferramenta WPF independente para gerenciar os arquivos de idioma do ModAPI (`LangTool\MODAPI_LangTool.csproj`) — veja a seção **Lang Tool** acima para todos os detalhes.

---

### Correções de Bugs

| # | Arquivo | Problema | Correção |
|---|---|---|---|
| 1 | `App.xaml.cs` | O francês se misturava às mensagens de exceção do .NET em Windows não inglês | `CultureInfo.InvariantCulture` fixado na inicialização do construtor `App()` |
| 2 | `Game.cs` | Erro SSL/TLS em `UpdateVersions()` — não foi possível criar um canal seguro SSL/TLS | TLS 1.2 definido explicitamente via `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Popup `GamePathNotSet` do Green Hell apesar do caminho estar configurado | `App.Game.GamePath` vazio → lê o caminho salvo de `Configuration` |
| 4 | `ModsViewModel.cs` | Arquivos de mod não apareciam na lista quando colocados manualmente em `mods\TheForest\` | Adicionado log de diagnóstico de validação de padrão de nome de arquivo |
| 5 | `MainWindow.xaml.cs` | Popup `MixedGameMods` bloqueava a seleção de mods multijogo | Popup bloqueante removido — substituído por `SelectGameDialog` |

---

### Novos Recursos

#### Início do Jogo — Popup de Seleção de Jogo (`SelectGameDialog`)

Quando mods de jogos diferentes são selecionados, ou quando o filtro **All** está ativo, um popup de seleção de jogo aparece em vez de bloquear o início.

**Condições de acionamento:**
- Filtro `All` selecionado + clique em Start Game
- Mods de 2 ou mais jogos diferentes ativados simultaneamente

**Comportamento:**
- Mostra apenas jogos com caminhos configurados e executável existente
- Apenas os mods do jogo selecionado são aplicados — mods de outros jogos são completamente ignorados
- O botão de rádio se sincroniza com o jogo selecionado após o fechamento do popup (`SyncModGameFilterRadioButton`)

**Novos arquivos**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Verificação de Integridade do Jogo (somente build Release, `#if !DEBUG`)

Uma verificação de integridade em três camadas é executada antes de cada início de jogo:

| Camada | Método | Em caso de falha |
|---|---|---|
| A — Cabeçalho PE | `FileValidator.IsValidGameExe()` | Bloqueado + popup `GameExeCorrupted` |
| B — Checksum do assembly | Comparação MD5 → `Versions.xml` | Bloqueado + popup `GameAssemblyTampered` |
| C — Assinatura digital | `HasDigitalSignature()` | Aviso + escolha do usuário (`GameIntegrityWarning`) |

**Novos arquivos**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Novos métodos adicionados a `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 de Assembly-CSharp.dll (+ firstpass se existir)
- `HasDigitalSignature(path)` — verificação de assinatura Authenticode

---

### Novos Logs de Diagnóstico

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 itens, Release + Debug)

| # | Fase | Tipo | Conteúdo |
|---|---|---|---|
| 1 | Configuração de TLS | Notice | Protocolo antes/depois |
| 2 | Início do download | Notice | Lista de servidores |
| 3 | Tentativa de URL | Notice | Cada URL tentada |
| 4 | Download bem-sucedido | Notice | URL, comprimento da resposta, protocolo usado |
| 5 | WebException | Error | URL, status HTTP, protocolo, detalhe |
| 6 | Outra exceção | Error | URL, tipo de exceção, detalhe |
| 7 | Download concluído | Notice | Contagem de sucessos / total de servidores |
| 8 | Análise bem-sucedida | Notice | Contagem de arquivos e versões antes/depois |
| 9 | Falha na análise | Error | Tipo de exceção e detalhe |
| 10 | Salvamento bem-sucedido | Notice | Caminho de salvamento, total de versões/arquivos |
| 11 | Falha ao salvar | Error | Caminho, tipo de exceção, detalhe |
| 12 | Nenhuma resposta | Error | Servidores tentados, protocolo |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 itens, apenas `#if DEBUG`)

| # | Situação | Tipo | Conteúdo |
|---|---|---|---|
| 1 | Início da varredura | Notice | Caminho da pasta de mods, total de arquivos encontrados |
| 2 | Já carregado | Notice | Nome do arquivo |
| 3 | Não é arquivo .mod | Notice | Nome do arquivo |
| 4 | Correspondência de padrão bem-sucedida | Notice | Nome do arquivo enfileirado |
| 5 | Falha na correspondência de padrão | Warning | Nome do arquivo + motivo + formato esperado |
| 6 | Varredura concluída | Notice | Contagem na fila / total de arquivos |
| 7 | Exceção | Error | Detalhe da exceção |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 itens, Release + Debug)

| # | Situação | Tipo | Conteúdo |
|---|---|---|---|
| 1 | Condição do popup | Notice | Filtro atual, IDs de jogos selecionados, needGameSelect |
| 2 | Jogos candidatos | Notice | Lista de IDs candidatos para o popup |
| 3 | Caminho não definido | Notice | Jogo ignorado — caminho não configurado |
| 4 | Ausente em Configuration | Notice | Jogo ignorado — ausente em Configuration.Games |
| 5 | Instalação confirmada | Notice | Jogo + caminho do executável |
| 6 | Exe não encontrado | Warning | Jogo ignorado — executável ausente |
| 7 | Nenhum jogo instalado | Error | 0 candidatos → GamePathNotSet |
| 8 | Selecionado automaticamente | Notice | Candidato único selecionado automaticamente |
| 9 | Cancelado pelo usuário | Notice | SelectGameDialog cancelado |
| 10 | Jogo selecionado + mods | Notice | Jogo selecionado, contagem/lista de mods coletados |

---

### Separação de Logs de Desenvolvedor / Usuário (`#if DEBUG`)

| Arquivo | Log | Motivo |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Repete a cada segundo — 81% do volume total de logs |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Detalhe interno exclusivo para desenvolvedores |

O log Release mantém: sucesso/falha de download, resultados de análise/salvamento, falhas de correspondência de padrão, exceções, resultados de verificação de integridade.

---

### Atualização da Tabela de Versões — Arquitetura

#### Intenção de Design

```
O jogo recebe uma atualização do Steam
  → Assembly-CSharp.dll muda
  → ModAPI verifica Versions.xml em busca de checksum conhecido
  → Se não encontrado → baixa o Versions.xml mais recente do servidor
  → A nova versão é registrada automaticamente sem reinstalar o ModAPI
```

#### Estrutura de Conexão

```
Aba Settings → caixa de seleção KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → chamada a UpdateVersions()
      → baixa Versions.xml de VersionUpdateDomains[]
      → sobrescreve o configs\games\{GameId}\Versions.xml local
```

#### Integração da URL Raw do GitHub

Em vez de depender exclusivamente de `modapi.survivetheforest.net`, a URL Raw do GitHub agora é usada como fonte primária para gerenciamento direto:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — gerenciado diretamente, prioridade 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Servidor legado — fallback, prioridade 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Item | Detalhe |
|---|---|
| Primário | URL Raw do GitHub — atualizado imediatamente com o push |
| Fallback | Servidor legado — usado quando o GitHub está indisponível |
| Caminho | `ModAPI/configs/games/{GameId}/Versions.xml` no repositório |
| Arquivo modificado | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Atualizações do Versions.xml

| Jogo | Arquivo | Alteração |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Checksum corrigido (era um SHA-256 incorreto em maiúsculas) — `2.9.5b114117` com MD5 correto |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID: 20229486) adicionado — checksum MD5 de 128 caracteres |

---

### Novas Chaves de Idioma (13 idiomas)

| Chave | Valor em inglês |
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
| `Lang.Savegames.*` (133 chaves) | Valores em inglês adicionados a 12 idiomas (DE já traduzido) |

---

### Arquivos Modificados

| Arquivo | Caminho | Alteração |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` fixado na inicialização |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, verificação de integridade, MixedGameMods removido, sincronização de rádio, 10 logs |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Novo |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Novo |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Log de diagnóstico de nome de arquivo, separação #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 logs de UpdateVersions, URL do GitHub, separação #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 novas chaves + 133 chaves Savegames (515 no total, todos os idiomas alinhados) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Checksum corrigido |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12` adicionado |
| `LangTool\` (13 arquivos) | Raiz da solução | Novo |
| `ModAPI.sln` | Raiz da solução | LangTool registrado |

---

### Correções Adicionais e Revisão do Sistema de Log (2026-06-21)

#### Validação do StartGame — Redesenho Completo

A ordem de validação foi corrigida para uma sequência estrita de 3 etapas, e o popup de seleção de jogo agora reflete os mods ativados independentemente de o caminho do jogo estar configurado.

| Etapa | Verificação | Popup em caso de falha |
|---|---|---|
| 1 | Steam instalado | SteamNotFound |
| 2 | Caminho do jogo selecionado configurado + executável existente | GamePathNotSet |
| 3 | Pelo menos um mod ativado para o jogo selecionado | NoModSelected |

- **Filtro All / mods de vários jogos selecionados** → o popup sempre lista todos os jogos com um mod ativado, **incluindo aqueles sem caminho configurado** — selecionar um jogo não configurado agora exibe corretamente `GamePathNotSet` em vez de excluí-lo silenciosamente ou mostrar o erro errado
- **Filtro de um único jogo** → as verificações de caminho e mod são executadas diretamente para esse jogo, na mesma ordem 1→2→3

#### Correções Críticas de Bugs

| # | Arquivo | Problema | Correção |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` mesclava as respostas de **todos** os servidores bem-sucedidos (GitHub + legado), duplicando os checksums (64 → 128 caracteres) quando ambos tinham êxito — causava bloqueios falsos de `GameAssemblyTampered` | Apenas a resposta do primeiro servidor bem-sucedido é analisada; os servidores restantes são pulados assim que um tem êxito |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` usava `App.Game` (filtro ativo atual) em vez do próprio jogo do mod — excluir um mod do Green Hell enquanto The Forest estava ativo pesquisava a pasta `Managed` errada e ignorava silenciosamente a exclusão | Agora resolve o caminho da DLL implantada a partir de `mod.Game` (a instância real de jogo do mod), com um fallback para `Configuration` se `GamePath` estiver vazio |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Rebaixar um mod previamente excluído restaurava seu selo de ativação como marcado — a exclusão de um mod nunca limpava suas chaves persistentes `Selected`/`Version` nem o cache do ViewModel em memória | Adicionados `RemoveKey()` / `RemoveKeysWithPrefix()` a `Configuration.cs`; `DeleteMod_Click` agora força `ModViewModel.Selected = false` e remove todas as chaves `Mods.{GameId}.{ModId}.*` na exclusão |
| 4 | `ModsViewModel.cs` | Excluir um mod enquanto um filtro de jogo específico (não "All") estava selecionado deixava o mod visível na lista até alternar para "All" e voltar | Faltava a notificação de alteração de `FilteredMods` após `_Mods.RemoveAt()` no loop de polling de exclusão de arquivo; agora é disparada sempre que um mod é realmente removido |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Uma exceção não tratada ao construir ou exibir o popup de aviso de assinatura ausente podia travar silenciosamente o ModAPI sem nenhum erro registrado | A construção/exibição do popup e a formatação de mensagens foram envolvidas em try-catch; em caso de falha, o aviso é registrado e o usuário pode continuar com segurança (a assinatura ausente é informativa, não um bloqueio rígido) |

#### Aviso de Assinatura Digital — Mensagem Esclarecida

O texto de `GameNoSignature` agora nomeia o jogo específico e esclarece que a ausência de assinatura é esperada para títulos independentes e não afeta a jogabilidade, em vez de sugerir uma possível adulteração. Atualizado em todos os 13 arquivos de idioma com um placeholder `{0}` para o nome de exibição do jogo (ex.: "The Forest", "Green Hell").

#### Sistema de Log — Separação em Dois Arquivos

Os logs de diagnóstico limitados por `#if DEBUG` foram convertidos em uma flag `detailedOnly` e divididos entre `ModAPI.log` (voltado ao usuário) e `ModAPI.detailed.log` (sempre com detalhe completo) — veja a seção **Log** acima para a discriminação completa.

#### Arquivos Modificados (Adicionais)

| Arquivo | Caminho | Alteração |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Redesenho da validação StartGame, correção da instância de jogo em DeleteMod_Click, try-catch para GameIntegrityWarning, mapeamento de nomes de exibição |
| `Game.cs` | `ModAPI_Shared\Data\` | Correção de resposta única em UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Notificação de alteração de `FilteredMods` na exclusão, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 pontos de chamada) |
| `Mod.cs` | `ModAPI\Data\` | Dump de XML de cabeçalho movido para `detailedOnly`, resumo de discrepâncias de checksum |
| `Debug.cs` | `ModAPI_Shared\` | Parâmetro `detailedOnly`, gravador de arquivo duplo, comentário guia de log de 4 níveis |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Placeholder `{0}` para nome do jogo, segurança try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` reescrito com placeholder de nome do jogo |

---


</details>

<details>
<summary><b>Alterações na v2.0.9619</b></summary>

### Correções de Bugs

- **Travamento na aplicação de mods com pasta de backup vazia**: `gamefiles\original\` vazia → criação automática de backup a partir do caminho de instalação do jogo antes da leitura do assembly
- **Bloqueio de arquivo (IOException) em DLLs do jogo**: o resolvedor de assembly exclui condicionalmente a pasta do jogo quando existe backup — impede que o Cecil mantenha bloqueios de arquivo durante `DirectoryCopy`
- **Loop de repetição infinito para mods corrompidos**: arquivos `.mod` com falha (cabeçalho corrompido) causavam um loop de nova varredura de 1 segundo — agora registrados em `LoadedFiles` para evitar nova varredura
- **Arquivos de mod com terminação de linha LF rejeitados**: o analisador de cabeçalho `EndsWith("</Mod>\r")` falhava para arquivos `.mod` no estilo Unix — agora usa `TrimEnd` para lidar com CRLF e LF
- **Falha de validação de DLLs pequenas**: `Assembly-UnityScript-firstpass.dll` (21 KB) era rejeitado por `FileValidator` — tamanho mínimo de assembly reduzido de 64 KB para 8 KB
- **Logs WARNING desnecessários**: caminhos de jogo não configurados e chaves de configuração na primeira execução geravam ruído — parâmetro `silent` adicionado a `GetPath`/`GetString`/`GetInt`

### Melhorias

- **Detecção de downloads de 0 bytes**: alerta em popup + limpeza de arquivos temporários quando o servidor retorna um arquivo `.mod` vazio (`Lang.Windows.DownloadEmpty`)
- **Debounce ao salvar o slider**: `ModListWidth` / `ProjectListWidth` salvo em `ui.cfg` apenas uma vez (500 ms após o término do arrasto) em vez de a cada mudança de pixel
- **Criação condicional de pastas de jogo**: as pastas `mods/` e `projects/` são criadas apenas para jogos com caminhos configurados — não incondicionalmente para todos os 5
- **Log de diagnóstico de análise de cabeçalho**: mostra a contagem de linhas e uma prévia do conteúdo em caso de falha na análise de arquivo `.mod`, para facilitar a solução de problemas

### Novas Chaves de Idioma (13 idiomas)

| Chave | Valor em inglês |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Arquivos Modificados

| Arquivo | Caminho | Alteração |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Criação automática de backup, resolvedor condicional, fallback para pasta do jogo |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Fallback para pasta do jogo para IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Parâmetro `silent` em GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Proteção contra downloads de 0 bytes, debounce do slider, leituras silenciosas de configuração, criação condicional de pastas |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Prevenção de novas tentativas para mods corrompidos |
| `Mod.cs` | `ModAPI\Data\` | Análise de cabeçalho LF/CRLF, log de diagnóstico |
| 13× `Language.XX.xaml` | `resources\langs\` | Chaves de popup `DownloadEmpty` |

---

</details>

<details>
<summary><b>Alterações na v2.0.9618</b></summary>


### MODAPI_VersionTool Adicionado

Foi adicionada uma ferramenta WPF independente para atualizar o número de versão com um único clique (`VersionTool\MODAPI_VersionTool.csproj`) — veja a seção **Version Tool** acima para todos os detalhes.

- `VersionLabel.Text` agora referencia `App.Version` em vez do `Version.Descriptor` codificado, portanto as atualizações são refletidas imediatamente na StatusBar após uma recompilação.

---

</details>

<details>
<summary><b>Alterações na v2.0.9617</b></summary>


### Aba Settings — Botões de Reset de Caminho Adicionados

Um botão **Reset** foi adicionado à linha do caminho de instalação do Steam e a cada linha de caminho de instalação de jogo.

**Linha do caminho do Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Linha do caminho do jogo (por jogo)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportamento do Reset**
- Limpa imediatamente a caixa de texto do caminho
- Salva uma flag de reset em `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- A caixa de texto permanece vazia após reiniciar
- Contorna o problema de o Configuration XML não persistir strings vazias

**Salvamento automático do Browse**
- Antes: era necessário um clique separado em Save após Browse
- Depois: salvamento automático na seleção do arquivo — refletido mesmo após a troca para a aba Mods

**Nova chave de idioma**

| Chave | Valor |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Alterações na v2.0.9616</b></summary>

### Versions.xml — 4 Jogos Adicionados / Atualizados

| Jogo | Caminho do arquivo | BuildID | Notas |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Recém-criado |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum atualizado |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Recém-criado |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum atualizado |

### Regras de Composição do Checksum

O formato do checksum difere dependendo se `Assembly-CSharp-firstpass.dll` existe para cada jogo.

| Jogo | firstpass.dll | Formato de checksum |
|---|---|---|
| GH | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Subnautica | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| EscapeThePacific | ✅ Presente | `firstpass MD5` + `Assembly-CSharp MD5` concatenados (64 caracteres) |
| Raft | ❌ Ausente | apenas `Assembly-CSharp MD5` (32 caracteres) |

### Procedimento de Atualização do Versions.xml em uma Atualização de Jogo

Adicione uma nova entrada `<version>` sem remover as entradas existentes.

**Passo 1 — Encontrar o novo BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Jogo | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Passo 2 — Extrair o novo checksum**
```powershell
# Jogos com firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenar ambos os valores Hash em ordem (firstpass primeiro)

# Jogos sem firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Passo 3 — Adicionar entrada ao Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Alterações na v2.0.9615</b></summary>

### Corrigida a Expansão do Caminho do Jogo na Aba Settings

- **Altura de expansão do cartão**: a parte inferior da janela agora cresce exatamente na altura do campo de entrada ao expandir um cartão de caminho de jogo
- **Melhoria em `UpdateWindowHeight()`**: chama `UpdateLayout()` antes da medição de `SizeToContent.Height`; define temporariamente `TextureLayer1` como `Collapsed` quando a textura de fundo está ativa, para evitar que o tamanho original de uma imagem 4K afete o cálculo de altura
- **Correção da linha interna do Grid**: a última linha do Grid interno do painel de caminhos de jogo foi alterada de `Height="*"` para `Height="Auto"` — remove espaço em branco desnecessário na parte inferior

---

</details>

<details>
<summary><b>Alterações na v2.0.9614</b></summary>

### Corrigido o Comportamento do Botão Maximizar

- **Maximizar**: usa `SystemParameters.WorkArea` para maximização manual em vez de `WindowState.Maximized` — ajusta-se exatamente à resolução de tela atual sem sobrepor a barra de tarefas
- **Restaurar**: salva `Left`, `Top`, `Width`, `Height` e `MaxWidth` antes de maximizar e os restaura ao clicar no botão de restaurar
- **Manuseio de `MaxWidth`**: definido como `∞` ao maximizar, restaurado ao valor salvo ao normalizar

---

</details>

<details>
<summary><b>Alterações na v2.0.9613</b></summary>

### Nova Aba Themes

A ordem das abas agora é:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

A interface de seleção de tema foi movida da aba Settings para uma aba **Themes** dedicada.
Ícone: Segoe MDL2 Assets `&#xE790;` (paleta)

### Registro de Temas (Estrutura Orientada por Dados)

Adicionar um novo tema agora requer apenas **uma linha** no dicionário `App.xaml.cs`.
Todas as instruções switch foram removidas — nenhuma alteração de código é necessária em outros lugares.

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

Os itens ComboBox do `ThemeSelector` são gerados automaticamente a partir do loop `ThemeIds`.
Convenção de chave de idioma: `Lang.Options.Theme.{PascalCase}` (ex.: `Lang.Options.Theme.Nebula`)

### Temas Suportados

| Índice | ID | Arquivo | Paleta |
|---|---|---|---|
| 0 | `classic` | apenas `Dictionary.xaml` | Plano de fundo com textura original do ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tom claro + destaque azul |
| 2 | `dark` | `FluentStyles.xaml` | Tom escuro + destaque azul (padrão) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Vermelho + preto |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espaço escuro |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Pôr do sol claro |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Oceano escuro |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nórdico claro |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cítrico claro |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral claro |

A mudança de tema aciona uma reinicialização automática do aplicativo. (salvo em `theme.cfg`)

### Recurso de Textura de Fundo

Selecione uma imagem no cartão **Background Texture** na aba Themes para aplicá-la como plano de fundo de toda a aplicação. Funciona com qualquer tema selecionado.

**Formatos de entrada suportados**: `.png` / `.jpg` / `.jpeg`, até 50 MB, resolução 4K ou inferior

**Pipeline de Processamento de Imagem**

```
Imagem selecionada pelo usuário (.png / .jpg / .jpeg, máx. 50 MB, 4K ou inferior)
  ↓
Compressão JPEG Q75 (buffer de memória)
  ↓
Cabeçalho mágico de 16 bytes inserido
  "MODAPI" + "BG" + versão + preenchimento (FF 00 FE 00)
  ↓
Salvo como resources\textures\ui_bg\bg.dat (atributo Hidden)
  ↓
Hash SHA-256 → armazenado em ui.cfg como TextureHash
```

**Camadas de Segurança**

| Camada | Método | Efeito |
|---|---|---|
| Cabeçalho mágico | 16 bytes prefixados antes da assinatura JPEG (FF D8 FF) | Visualizadores externos não conseguem reconhecer o arquivo |
| Atributo Hidden | `FileAttributes.Hidden` | Oculto do Explorer por padrão |
| Integridade SHA-256 | Hash verificado ao carregar | Adulteração aciona reset automático + popup de aviso |

**Comportamento de Detecção de Adulteração**
1. `bg.dat` excluído
2. Chaves `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` redefinidas
3. Caixa de texto e alternador redefinidos
4. Popup `Lang.Windows.TextureTampered` exibido

**Chaves ui.cfg**

| Chave | Valor | Descrição |
|---|---|---|
| `TexturePath` | Nome do arquivo (apenas exibição) | Nome de arquivo original exibido na caixa de texto |
| `TextureHash` | Hexadecimal SHA-256 | Hash de verificação de integridade |
| `TextureActive` | `true` / `false` | Estado de ativação |

**Processamento de Transparência**

Quando a imagem de fundo está ativa, os fundos da interface são processados em duas camadas.

- **Camada 1 — Sobreposição MergedDictionaries**: painéis que referenciam `{DynamicResource FluentBgBrush}` etc. são automaticamente tornados transparentes. Restaurados com uma única chamada a `Remove()` na desativação.

  Chaves-alvo: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Camada 2 — Percorrimento da árvore visual (`WalkStyleBackgrounds`)**: elementos `{StaticResource}` em temas Fluent não são afetados pela Camada 1, então a árvore visual é percorrida diretamente para aplicar pincéis semitransparentes com base nas cores originais.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=totalmente transparente, 255=opaco → 100 ≈ 39% opaco
  ```

  Processado: `Panel` (exceto Grid), `Border`, `ListBox` / `ListView`

  Excluído: `Grid` (fundo preservado, filhos percorridos), `TabPanel` (proteção do cabeçalho de aba), `ButtonBase` / `ComboBox`, elementos `Collapsed`

  Restauração: origem do Setter de estilo → `ClearValue()`, origem de valor local XAML → restaura diretamente o pincel original

**Troca de Aba**

Como o TabControl do WPF carrega o conteúdo das abas de forma preguiçosa, `WalkStyleBackgrounds(this)` é reexecutado com prioridade `ContextIdle` na troca de aba. Elementos já processados são pulados via verificação `ContainsKey`.

**Bloqueio do ThemeSelector**

Quando a textura de fundo está ativa, uma borda `ThemeSelectorOverlay` é exibida sobre o seletor de temas para bloquear a interação.

- XAML: borda `ThemeSelectorOverlay` adicionada acima do ThemeSelector (`IsHitTestVisible=True`)
- Ativo: `ThemeSelectorOverlay.Visibility = Visible`
- Inativo: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` também protegido pela flag `_textureActive`

**Fluxo de Estado da Interface**

```
Imagem selecionada (Browse)
  → bg.dat criado → alternador desbloqueado → ativação automática → TextureLayer1 exibido
  → SaveAndClearBrushes() → ThemeSelectorOverlay exibido

Alternador desativado
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay oculto
  → TextureLayer1 oculto

Botão Clear
  → bg.dat excluído → alternador bloqueado → TextureLayer1 oculto → pincéis restaurados
  → GC.Collect() (libera memória de imagem 4K)
```

**Novas Chaves de Idioma**

| Chave | Descrição |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 novos nomes de tema |
| `Lang.Options.Labels.TextureBackground` | Rótulo de textura de fundo |
| `Lang.Options.Labels.TextureEnable` | Rótulo de ativação |
| `Lang.Options.Labels.TextureClear` | Botão Clear |
| `Lang.Windows.TextureTooLarge` | Aviso de tamanho de arquivo excedido |
| `Lang.Windows.TextureTampered` | Aviso de adulteração detectada |

**Estrutura de Arquivos**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Aba Themes, ThemeSelectorOverlay, TextureLayer1
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
            └── bg.dat             # Imagem de fundo compactada e protegida (gerada em tempo de execução)
```

**Restrições de Design Conhecidas**

| Item | Detalhes |
|---|---|
| `IsEnabled=false` no ComboBox | Causa travamento `ElementNotEnabledException` → abordagem de sobreposição `IsHitTestVisible` usada |
| Substituição direta de chaves `MergedDictionaries` | Trava durante a passagem de layout → apenas o padrão `Add`/`Remove` |
| Sobrescrever arquivo oculto | `Access Denied` → deve redefinir `FileAttributes.Normal` antes de gravar |
| Fundos `{StaticResource}` | Não afetados pela Camada 1 → requer WalkStyleBackgrounds (Camada 2) |

---

</details>

<details>
<summary><b>Alterações na v2.0.9612</b></summary>

### Separação do Módulo de Temas

- **Nova pasta `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` e `FluentStylesClassic.xaml` movidos para `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — o tema Classic usa apenas `Dictionary.xaml`; os temas Light/Dark/outros Fluent carregam o XAML correspondente
- **`ModAPI.csproj`**: caminhos XAML de temas atualizados para o subdiretório `Themes\`; `FluentStylesClassic.xaml` registrado

---

</details>

<details>
<summary><b>Alterações na v2.0.9611</b></summary>

### Correção de Bug

- **Largura da Mod List não aplicada após troca de tema**: corrigido um problema em que a largura da lista de mods não era aplicada após uma troca entre os temas Light/Dark e uma reinicialização — adicionada a chamada `ApplyModListWidth(width)` dentro de `InitModListWidth()`

---

</details>

<details>
<summary><b>Alterações na v2.0.9610</b></summary>

### Adicionado

#### XML de Jogo e Configuração Versions

| # | Arquivo | Alteração |
|---|------|--------|
| 1 | `GH.xml` | Reescrita completa — removido `DOTweenPro.dll` inexistente; adicionados `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Reescrita completa — removido `extends="GenericUnityGame"`; adicionados `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Reescrita completa — removido `extends="GenericUnityGame"`; `includeAssembly` → apenas `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Criado — versão `1.1.01` com checksum |
| 5 | `GH/Versions.xml` | Criado — versão `2.9.5` com checksum |
| 6 | `Subnautica/Versions.xml` | Criado — sem checksum (atualiza com muita frequência) |

#### Correções Críticas de Bugs

| # | Tipo | Problema | Correção |
|---|------|-------|-----|
| 1 | Travamento | `extends="GenericUnityGame"` causava herança de `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` travava | Removido `extends` de todos os XML não-TheForest |
| 2 | Falha | `ResolutionException: XGamingRuntime.XUserGamertagComponent` durante aplicação no Subnautica | Adicionados `XGamingRuntime.dll`, `XblPCSandbox.dll` a `copyAssembly` |
| 3 | Falha | O resolvedor falhava em DLLs adicionadas a `copyAssembly` após a criação do backup | `Game.cs`: pasta de instalação real adicionada como fallback do resolvedor |
| 4 | Falha | `IOException`: bloqueio de arquivo de `BaseModLib.dll` entre `CreateModLibrary` e `ApplyMods` | Loop de repetição: máx. 10 × 500 ms de leitura + máx. 30 × 500 ms de espera de existência |
| 5 | Falha | `NullReferenceException` — entry.Value de `typesMap` nulo (jogo não instalado) | Adicionado `if (entry.Value == null) continue` |
| 6 | Falha | `NullReferenceException` — construtor leve `Game` sem `ModLibrary = new ModLib(this)` → falha de `CreateModLibrary()` | Adicionado `ModLibrary = new ModLib(this)` ao construtor leve |
| 7 | Falha | `SwitchDevGame()` — `App.Game.GamePath` vazio após construtor leve → falha de `CreateModLibrary` | Definido `App.Game.GamePath = savedPath` após o construtor leve |
| 8 | Jogo errado | Mods de `EscapeThePacific` classificados como TheForest | `ModsViewModel`: `GameId` extraído do caminho da pasta |
| 9 | Caminho errado | `GetGameFolder()` → `""` → resolvido para a raiz da unidade (ex.: `E:\`) | Proteção null/vazio em todos os 6 pontos de chamada |

#### Separação de Builds Debug / Release

- **`FileValidator.cs`** — novo arquivo `ModAPI_Shared\Utils\FileValidator.cs`; registrado em `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — cabeçalho PE (MZ + PE\0\0) + mínimo 1 MB
  - `IsValidGameExe()` — cabeçalho PE + mínimo 512 KB
  - `IsValidAssemblyDll()` — cabeçalho PE + cabeçalho de metadados CLR .NET + mínimo 64 KB
- **`CheckSteam()`** — `#if DEBUG`: apenas `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: apenas `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` sem Cecil / `#else`: análise Cecil completa + modificação de IL
- **`ModLib.Create()` arquivo não encontrado** — `#if DEBUG`: registra aviso, pula / `#else`: registra erro, aborta

#### Testes Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell para `bin\Debug\`; cria arquivos de espaço reservado de 0 bytes para todos os 5 jogos em `dummy_games\`, `dummy_steam\` e `gamefiles\original\` — permite testar todo o fluxo de trabalho da interface sem instalação real do jogo

#### Aba Settings

- **Cartão de caminho do Steam** — integrado ao cartão Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Painel de caminhos de jogo** — `BuildGamePathsPanel()` com cartões expansíveis por jogo; a caixa de texto usa `HorizontalAlignment=Stretch`
- Botão **Expand All / Collapse All**
- Caixa de seleção **AlwaysOnTop** (salva em `ui.cfg`)
- Sliders **Mod/Project List Width** — começam no mínimo `150`; salvos em `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Sincronização de caixas de seleção** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions agora sincronizam corretamente
- **Flag `_uiInitialized`** — impede gravações prematuras de `ui.cfg` durante a inicialização do WPF

#### Aba Mods — Validação de Início de Jogo

Uma validação de cinco etapas é executada a cada clique em Start Game, independentemente do estado da lista de mods:

| Etapa | Verificação | Popup |
|---|---|---|
| 1 | Caminho do Steam na aba Settings válido (`Steam.exe` existe) | SteamNotFound |
| 2 | O jogo na pasta `mods/{GameId}/` corresponde ao jogo configurado em Settings | GameModsMismatch |
| 3 | Pelo menos um mod selecionado | NoModSelected |
| 4 | Nenhuma mistura de mods de jogos diferentes na seleção | MixedGameMods |
| 5 | Caminho do jogo configurado + executável existente | GamePathNotSet / GameNotInstalled |

#### Aba Development — Validação de ModLib

Validação em três etapas ao clicar em Mod Library Regeneration:

| Etapa | Verificação | Popup |
|---|---|---|
| 1 | Caminho do Steam na aba Settings válido | SteamNotFound |
| 2 | Pelo menos um projeto existente | NoProjectWarning |
| 3 | `App.Game.GamePath` definido | GamePathNotSet |

#### Aba Downloads
- String de depuração substituída por `Lang.Downloads.Status.NoDownloads`
- Preenchimento consistente para todas as mensagens de status
- Texto manual offline atualizado para os 5 jogos suportados; quebra de linha via dois TextBlocks

#### First Setup e Sistema de Caminho de Jogo
- `FirstSetup.Check()` — valor padrão `true` para `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — cria as pastas `mods/` e `projects/` para todos os 5 jogos
- `SpecifyGamePath` — `GameNameLabel` mostra qual jogo é; `NavigateToSettings()` direciona para a aba Settings

#### Chaves de Idioma Novas/Atualizadas

| Chave | Valor em inglês |
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

| Recurso | Motivo |
|---|---|
| Atualização automática (manter a versão mais recente) | Infraestrutura do lado do servidor não disponível |
| Busca de atualizações | Infraestrutura do lado do servidor não disponível |

### Removido

| Item | Motivo |
|---|---|
| Popup `SpecifyGamePath` na inicialização | Todos os caminhos são configurados na aba Settings |
| Popup `SpecifySteamPath` na inicialização | O caminho do Steam é configurado na aba Settings |
| Sistema de login | O servidor original não está mais operacional (removido na v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Não funciona no Mono 2.0 (removido na v2.0.9586) |
| Condição `UseSteam` na verificação do Steam | O Steam agora é sempre validado primeiro em Start Game e Mod Library Regeneration |

## Planejado para Versões Futuras

| # | Recurso | Descrição |
|---|---|---|
| 1 | Atualização automática do ModAPI | Baixar e aplicar automaticamente novos lançamentos do ModAPI |
| 2 | Atualização da tabela VersionsData do ModAPI | Atualizar automaticamente a tabela VersionsData do jogo quando novos patches de jogo forem lançados |

---

</details>

<details>
<summary><b>Alterações na v2.0.9600</b></summary>

### Adicionado

- **Aba Downloads**: 5 filtros de jogo (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Aba Welcome**: adicionada na posição mais à esquerda (índice 0)
- **Aba Mods**: layout de 3 colunas (WrapPanel → lista vertical); ajuste automático de largura; quebra de nomes de mods
- **`ModsViewModel`**: filtragem específica por jogo, `ResolveGame()` para a instância `Game` correta por mod
- **`Game.cs`**: construtor leve `new Game(config, true)` — apenas identificação, sem `Verify()`
- **Compilação**: 4 arquivos XML de jogo registrados em `ModAPI.csproj` com `CopyToOutputDirectory=Always`
- **Compilação**: avisos limpos — CS0168, CS0618, CS0252
- **XML de jogo**: listas de DLL de TheForest, Raft, GH corrigidas
- **Bandeiras de idioma**: tamanhos de imagem padronizados em todos os 13 selos de idioma

### Removido

| Item | Motivo |
|---|---|
| `extends="GenericUnityGame"` em arquivos XML de jogo | Causava herança incorreta de `Assembly-CSharp-firstpass.dll` — removido de Subnautica, Raft, EscapeThePacific, GH |
| Layout `WrapPanel` na aba Mods | Substituído por layout Grid de 3 colunas (Game Filter / Mod List / Information) |

---

</details>

---

## Histórico de Versões

<details>
<summary><b>Fase 6-3 — Expansão do Sistema de Temas, Melhorias de Configurações, Estabilidade e Ferramentas</b></summary>

### v2.0.9621 — 2026-07-28

- Deteção automática em toda a biblioteca Steam para os 5 jogos, controlada pela caixa Conexão Steam
- Deteção e exclusão automática de mods criados para outro jogo (lista + no momento do Apply), com selo ⚠ na aba Mods
- Popup de resultado combinado para mods excluídos / nenhum mod aplicado em vez de popups empilhados; o jogo já não inicia com zero mods aplicados
- Registo global de exceções não tratadas (thread de UI + threads em segundo plano)
- `ModAPI.dev.log` substitui `ModAPI.detailed.log`; novos interruptores na aba Configurações para Log de desenvolvedor e Limpar logs ao iniciar
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` agora desmarcados por predefinição em instalação nova
- Corrigido: bug de caminho vazio em `Configuration.GetPath()`, ordem de validação inconsistente do Iniciar Jogo, recolha de mods que ignorava o filtro, colisões de chave `Mod.Mods` entre jogos e a consequente falha de `UpdateMods()`, duplicação do checksum de Green Hell (`_Data`/`_data`), falha por bloqueio de ficheiro `BaseModLib.dll`, criação incondicional de `mods\`/`projects\`, falha ao guardar `Versions.xml` com pasta em falta, falta de recálculo da altura da janela ao mudar tamanho de fonte / aba, altura de janela ilimitada ao "Expandir tudo"

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool e correções principais**
- MODAPI_LangTool adicionado (ferramenta WPF independente de gerenciamento de idiomas)
- Correção de SSL/TLS (TLS 1.2)
- Correção de configuração regional francesa (`CultureInfo.InvariantCulture`)
- Correção de `GamePathNotSet` do Green Hell
- SelectGameDialog (filtro All + início multijogo de mods)
- Bloqueio por MixedGameMods removido
- Verificação de integridade do jogo em 3 camadas (cabeçalho PE / checksum de assembly / assinatura digital)
- Separação de logs de desenvolvedor e usuário
- 12 logs de UpdateVersions + 7 logs de FindMods + 10 logs de StartGame
- URL Raw do GitHub como `VersionUpdateDomains` primária
- Checksum do `Versions.xml` do GH corrigido
- `1.12` adicionado ao `Versions.xml` do TheForest
- 515 chaves em todos os 13 arquivos de idioma

**Correções adicionais (2026-06-21)**
- Ordem de validação do StartGame corrigida (Steam → caminho do jogo → mods)
- O popup de seleção de jogo agora lista corretamente jogos com caminho não configurado
- Correção de resposta única em UpdateVersions (sem mais checksums duplicados)
- `DeleteMod` agora resolve a própria instância de jogo do mod em vez do filtro ativo
- Mods excluídos não deixam mais um selo "Selected" desatualizado ao rebaixar
- A lista de mods agora atualiza imediatamente na exclusão, sob qualquer filtro de jogo
- Popup `GameIntegrityWarning` reforçado contra travamentos por exceções não tratadas
- A mensagem de aviso de assinatura digital agora nomeia o jogo e esclarece que isso é esperado para títulos independentes
- O sistema de log de dois arquivos (`ModAPI.log` / `ModAPI.detailed.log`) substitui os logs limitados por `#if DEBUG`, para que as builds Release ainda possam capturar todo o detalhe diagnóstico sem sobrecarregar o log voltado ao usuário

### v2.0.9619 — 2026-05-25

- Criação automática de backup a partir do caminho de instalação do jogo
- Correção de bloqueio de arquivo (resolvedor condicional)
- Prevenção de loop infinito para mods corrompidos
- Compatibilidade com mods de terminação de linha LF
- Detecção de downloads de 0 bytes com popup
- Debounce ao salvar o slider (500 ms)
- Criação condicional de pastas de jogo
- Tamanho mínimo de assembly em `FileValidator` reduzido de 64 KB para 8 KB
- Parâmetro `silent` em `GetPath`/`GetString`/`GetInt`
- Log de diagnóstico de análise de cabeçalho
- Chaves de idioma `DownloadEmpty` (13 idiomas)

### v2.0.9618 — 2026-04-25
Adicionado MODAPI_VersionTool (ferramenta WPF independente de atualização de versão), exibição de versão na StatusBar vinculada a App.Version

### v2.0.9617 — 2026-04-24
Adicionados botões de reset de caminho Steam/jogo na aba Settings, salvamento automático de Browse, estado de reset preservado via flag ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml criado/atualizado para 4 jogos (Subnautica, Raft, EscapeThePacific, GH), regras de composição de checksum estabelecidas, procedimento de atualização de jogo documentado

### v2.0.9615 — 2026-04-18
Corrigida a precisão da altura de expansão do cartão de caminho de jogo na aba Settings, prevenida a interferência de UpdateWindowHeight pela textura de fundo

### v2.0.9614 — 2026-04-18
Maximização manual do botão Maximizar baseada em WorkArea, salvamento e restauração de tamanho/posição anteriores

### v2.0.9613 — 2026-04-18
Adicionada a aba Themes, estrutura de registro de temas orientada por dados, suporte a 10 temas, recurso de textura de fundo (compressão, segurança, transparência em 2 camadas), sobreposição de bloqueio do ThemeSelector, 12 novas chaves de idioma

### v2.0.9612 — 2026-04-18
Separação da pasta Themes/, modularização de XAML de temas

### v2.0.9611 — 2026-04-18
Corrigido: largura da Mod List não aplicada após troca de tema

</details>

<details>
<summary><b>Fase 6-2 — Configurações, Segurança, Correções de Travamentos e Separação Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- XML multijogo corrigido (GH, Subnautica, EscapeThePacific)
- `Versions.xml` adicionado
- Aba Settings redesenhada (caminho do Steam, painel de caminhos de jogo, sliders de largura, tamanho de fonte, sincronização de caixas de seleção)
- Segurança null do caminho de jogo (6 pontos)
- Popups de inicialização substituídos pela aba Settings
- Validação de início de jogo em 5 etapas na aba Mods (Steam sempre primeiro)
- Validação de ModLib em 3 etapas na aba Dev
- Popup `GameModsMismatch` adicionado
- Correção do null de `ModLibrary` no construtor leve
- Correção de `GamePath` em `SwitchDevGame`
- Verificação de cabeçalho PE de `FileValidator` (Release)
- Separação de build `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- `ui.cfg` persistente
- Sistema de fonte de 5 chaves
- Múltiplas correções de travamentos
- Chaves de idioma atualizadas

</details>

<details>
<summary><b>Fase 6-1 — Multijogo e Redesenho de Mods</b></summary>

### v2.0.9600 — 2026-04-09
> 5 filtros de jogo, layout de 3 colunas na aba Mods, largura automática, construtor `Game` leve, filtragem de jogo em `ModsViewModel`, 4 arquivos XML registrados, avisos de compilação limpos, aba Welcome, bandeiras de idioma padronizadas

</details>

<details>
<summary><b>Fase 5-6B — C# 7.3 e Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Tela preta corrigida, polyfill finalizado, ValueTuple removido, C# 7.3 verificado

</details>

<details>
<summary><b>Fase 5-5 — Resolução de Assemblies</b></summary>

### v2.0.9561 — 2026-03-06
> Suporte a C# 7.3, correção de cabeçalho PE, pipeline de polyfill, resolução de assemblies restaurada

</details>

<details>
<summary><b>Fase 5-1 — Aba Downloads e 13 Idiomas</b></summary>

### v2.0.9552 — 2026-02-25
> Aba Downloads, modernização de ícones, unificação de temas, suporte a 13 idiomas

</details>

<details>
<summary><b>Fases Anteriores</b></summary>

### Fase 3 — Redesenho da Interface e Sistema de Temas
v2.0.9500
> Sistema de temas (Classic/Light/Dark), interface Fluent Design, sistema SubWindow

### Fase 4 — Limpeza de Código
v2.0.9400
> Limpeza de código, remoção de login, modernização de legado

### Fase 2 — Ambiente de Compilação e Fluent Design
v2.0.9300
> Ambiente de compilação, DLL stub UnityEngine, integração ModernWpf

### Fase 1 — Migração para .NET 4.8
v2.0.9200
> Migração para .NET Framework 4.8

### v1.x
Versão original da FluffyFish

</details>

---

## Requisitos de Compilação

| Requisito | Versão | Notas |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projetos ModAPI |
| .NET Framework SDK | 3.5 | Somente BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` em `libs/polyfills/` |

---

## Licença

GNU General Public License v3.0 — segue a licença original.
