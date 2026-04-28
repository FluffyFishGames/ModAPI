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

**The Forest Mod管理工具 — 升级版**

> 原作: FluffyFish / Philipp Mohrenstecher (德国恩格尔斯基兴)
> 升级: zzangae (大韩民国)

---

## 概述

ModAPI是一款用于管理**5款官方支持游戏**Mod的桌面应用程序。本升级版包含多游戏支持、全面重新设计的Settings标签页、Steam路径配置、持久化UI设置、动态字体大小系统、游戏启动验证、Debug/Release构建分离以及通过游戏内测试验证的大量崩溃修复。

---

## 支持的游戏

| 游戏 | 引擎 | 版本 | Steam ID | 可执行文件 |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02（测试版） | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| 项目 | 值 |
|---|---|
| 引擎 | Unity 5（从 Unity 4 升级） |
| 最新版本 | v1.12 (VR) |
| 最后更新 | 2019年9月11日 — VR 支持补丁；此后无主要内容更新 |
| 可执行文件 | `TheForest.exe` |
| 数据文件夹 | `TheForest_Data/Managed/` |
| Mod 文件夹 | `mods/TheForest/` |
| 项目文件夹 | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 完全支持 |

The Forest 从 Unity 4 升级到 Unity 5，显著改善了视觉效果和物理效果。2019年9月的 VR 补丁是最后一次主要更新。游戏目前保持稳定的最终状态——非常适合模组制作。
</details>

<details>
<summary><b>Subnautica</b></summary>

| 项目 | 值 |
|---|---|
| 引擎 | Unity（2022年与 Below Zero 统一的集成代码库） |
| 最新版本 | 2025 Patch (v18810395) |
| 最后更新 | 2025年8月12日 — 随移动版发布同步的错误修复和性能改进 |
| 可执行文件 | `Subnautica.exe` |
| 数据文件夹 | `Subnautica_Data/Managed/` |
| Mod 文件夹 | `mods/Subnautica/` |
| 项目文件夹 | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — 支持 |

最初基于 Unity 5 构建，Subnautica 在2022年末收到了 'Living Large' 更新（v2.0），将引擎代码库与 Below Zero 合并以提高优化和稳定性。注：即将推出的 *Subnautica 2* 使用 Unreal Engine 5。

> **v2.0.9610 XML 重写**：将 `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` 添加到 `copyAssembly`。
</details>

<details>
<summary><b>RAFT</b></summary>

| 项目 | 值 |
|---|---|
| 引擎 | Unity |
| 最新版本 | v1.1.02（测试版）/ v1.09（稳定版） |
| 最后更新 | 2026年3月 — 通过测试分支修复语音聊天和多人游戏错误 |
| 可执行文件 | `Raft.exe` |
| 数据文件夹 | `Raft_Data/Managed/` |
| Mod 文件夹 | `mods/Raft/` |
| 项目文件夹 | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — 支持 |
| Versions.xml | `1.1.01`（含校验和） |

在 v1.0：*The Final Chapter* 官方故事完结后，补丁持续进行网络代码改进和稳定性提升。
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| 项目 | 值 |
|---|---|
| 引擎 | Unity 6（2025年末从 Unity 2021/2022 迁移） |
| 最新版本 | v0.67.0.0 |
| 最后更新 | 2025年6月26日 — 岛屿分布重做和引擎更新；2026年持续热修复 |
| 可执行文件 | `EscapeThePacific.exe` |
| 数据文件夹 | `EscapeThePacific_Data/Managed/` |
| Mod 文件夹 | `mods/EscapeThePacific/` |
| 项目文件夹 | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — 支持 |

2025年末完成了大规模系统重建和 Unity 6 迁移，实现了更加动态的环境。游戏仍在积极的抢先体验开发中。

> **v2.0.9610 XML 重写**：移除 `extends="GenericUnityGame"`；将 `includeAssembly` 设置为仅 `Assembly-CSharp.dll` — 防止 `Assembly-CSharp-firstpass.dll` 继承错误。
</details>

<details>
<summary><b>Green Hell</b></summary>

| 项目 | 值 |
|---|---|
| 引擎 | Unity 2019 |
| 最新版本 | v2.9.5 |
| 最后更新 | 2026年2月4日 — Steam Deck 优化和文本可读性改进 |
| 可执行文件 | `GH.exe` |
| 数据文件夹 | `GH_Data/Managed/` |
| Mod 文件夹 | `mods/GH/` |
| 项目文件夹 | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — 支持 |
| Versions.xml | `2.9.5`（含校验和） |

开发过程中逐步将引擎从 Unity 2017 → 2018 → 2019 升级。2026年2月的热修复专注于 Steam Deck 兼容性和 UI 文本可读性。

> **v2.0.9610 XML 重写**：添加 `AmplifyBloom.dll`、`AmplifyColor.dll`、`AmplifyMotion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`；移除不存在的 `DOTweenPro.dll`。
</details>

---

## 架构

### 运行时分离

| 组件 | 目标 | 运行时 | 原因 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 桌面应用程序，完整现代API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 共享库 |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **永久固定** — PE头必须包含 `v2.0.50727` |
| Mod DLL（用户） | .NET Framework 4.8 | Game Mono 2.0（已修补） | 使用4.8构建，应用时修补PE头 |

### Debug / Release 构建分离

所有文件验证和程序集处理根据构建配置通过 `#if DEBUG` / `#else` 分支。

| 位置 | Debug 构建 | Release 构建 |
|---|---|---|
| `CheckSteam()` | 仅 `File.Exists()` — 虚拟文件通过 | `FileValidator.IsValidSteamExe()` — PE头 + 最小 1 MB |
| `CheckGamePath()` | 仅 `File.Exists()` — 虚拟文件通过 | `FileValidator.IsValidAssemblyDll()` — PE头 + CLR元数据 + 最小 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — 跳过Cecil解析 | 完整Mono.Cecil解析 + IL修改 + `module.Write()` |
| `ModLib.Create()` — 未找到文件 | 记录警告，跳过并继续 | 记录错误，弹窗中止 |

**Debug测试**使用 `create_dummy_Debug_games.ps1` 在 `bin\Debug\dummy_games\`、`bin\Debug\dummy_steam\` 和 `bin\Debug\gamefiles\original\` 下生成0字节占位文件。这些文件通过 `File.Exists()` 检查，允许在无真实游戏安装的情况下进行完整UI工作流测试。

**Release构建**应用 `FileValidator`（PE头 + .NET CLR元数据验证）来拒绝0字节文件、文本文件和任意二进制文件。只有有效的Windows可执行文件和.NET程序集才能通过。

### FileValidator — PE头验证

`ModAPI_Shared\Utils\FileValidator.cs` — 仅在Release构建中应用。

| 方法 | 检查内容 | 最小大小 |
|---|---|---|
| `IsValidSteamExe(path)` | MZ签名 + PE\0\0签名 | 1 MB |
| `IsValidGameExe(path)` | MZ签名 + PE\0\0签名 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR元数据头（数据目录 #14） | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### 程序集重映射管线

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

### 程序集解析器回退

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### C# 7.3 功能支持

| 功能 | 状态 | 备注 |
|---|---|---|
| 模式匹配 (`is`, `switch`) | ✅ | 已在游戏中验证 |
| 字符串插值 (`$""`) | ✅ | 已在游戏中验证 |
| 内联 `out` 变量 | ✅ | 已在游戏中验证 |
| `async` / `await` | ✅ | 通过 AsyncBridge + System.Threading polyfill |
| 元组 (`ValueTuple`) | ❌ 绝对限制 | Mono 2.0 `mscorlib` ABI — 无解决方案 |

### 主题系统

从 v2.0.9613 起，主题选择界面已从 Settings 标签页移至专用的 **Themes 标签页**。添加新主题只需在 `App.xaml.cs` 字典中添加一行。

| 索引 | ID | 文件 | 调色板 |
|---|---|---|---|
| 0 | `classic` | 仅 `Dictionary.xaml` | 原版 ModAPI 纹理背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明亮色调 + 蓝色强调 |
| 2 | `dark` | `FluentStyles.xaml` | 深色色调 + 蓝色强调（默认） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 红色 + 黑色 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗色太空 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮日落 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗色海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北欧 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉 |

更改主题会触发应用自动重启。（保存到 `theme.cfg`）

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

### 背景纹理

在 Themes 标签页的 **Background Texture** 卡片中选择图像，将其应用为整个应用的背景。支持格式：`.png` / `.jpg` / `.jpeg`，最大 50MB，4K 及以下分辨率。图像以 JPEG Q75 压缩，附加 16 字节魔法头部，保存为 `resources\textures\ui_bg\bg.dat`（Hidden 属性）。SHA-256 哈希用于完整性验证；检测到篡改时自动重置 + 警告弹窗。

当背景激活时，UI 透明化分两层处理：Layer 1（MergedDictionaries 覆盖层）用于 `{DynamicResource}` 面板，Layer 2（WalkStyleBackgrounds）用于基于 `{StaticResource}` 的面板半透明化。

### 字体大小系统

| 资源键 | 基础值 | 描述 |
|---|---|---|
| `AppBaseFontSize` | 13 | 普通文本 |
| `AppBaseHeaderFontSize` | 16 | 标题、面板标题 |
| `AppBaseSmallFontSize` | 12 | 次级标签 |
| `AppBaseTinyFontSize` | 10 | 提示文本 |
| `AppBaseLargeFontSize` | 20 | 大型显示文本 |

### 持久化UI配置 — `ui.cfg`

| 键 | 默认值 | 描述 |
|-----|---------|-------------|
| `ModListWidth` | `150` | Mod列表宽度 (px) |
| `ProjectListWidth` | `150` | 项目列表宽度 (px) |
| `AppFontSize` | `13` | 全局UI字体大小 (px) |
| `AlwaysOnTop` | `false` | 窗口置顶 |
| `TexturePath` | *(无)* | 背景纹理原始文件名（仅显示） |
| `TextureHash` | *(无)* | 背景纹理 SHA-256 哈希 |
| `TextureActive` | `false` | 背景纹理激活状态 |
| `GamePathReset_{GameId}` | *(无)* | 游戏路径重置标志 |
| `SteamPathReset` | *(无)* | Steam路径重置标志 |

### 文件结构

```
ModAPI/
├── App.xaml / App.xaml.cs              # 主题注册表、主题ID、主题应用
├── ui.cfg                               # 持久化UI设置
├── theme.cfg                            # 当前主题
├── Windows/
│   ├── MainWindow.xaml / .cs            # 主UI — 6个标签页、主题、设置、Steam路径
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # 游戏路径弹窗（动态GameNameLabel）
│       ├── FirstSetup.xaml / .cs        # 首次运行设置 + 默认初始化
│       └── （其他14个子窗口）
├── Themes/
│   ├── Dictionary.xaml                  # Classic主题
│   ├── FluentStyles.xaml                # Dark主题
│   ├── FluentStylesLight.xaml           # Light主题
│   ├── FluentStylesDiablo.xaml          # Diablo主题
│   ├── FluentStylesNebula.xaml          # Nebula主题
│   ├── FluentStylesSunset.xaml          # Sunset主题
│   ├── FluentStylesOcean.xaml           # Ocean主题
│   ├── FluentStylesNordic.xaml          # Nordic主题
│   ├── FluentStylesCitrus.xaml          # Citrus主题
│   └── FluentStylesBloom.xaml           # Bloom主题
├── Data/
│   ├── Game.cs                          # 程序集修补、null保护、解析器回退
│   ├── ModLib.cs                        # BaseModLib生成 + 重映射（#if DEBUG分支）
│   ├── Models/
│   │   └── ModProject.cs                # 项目创建/构建/应用 + null保护
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # 已过滤Mod、已选Mod、已选游戏筛选器
│   │   ├── ModViewModel.cs              # 从文件夹路径获取GameId
│   │   ├── ModProjectsViewModel.cs      # DispatcherTimer的Dispose()
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersions默认为true
│   └── AssemblyVersionMap.cs            # Mono 2.0程序集版本映射（20个程序集）
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 基于名称的解析器（带缓存）
│   └── MonoHelper.cs                    # Mono.Cecil IL辅助工具
├── resources/
│   ├── langs/                           # 13个语言文件
│   └── textures/ui_bg/
│       └── bg.dat                       # 压缩且安全处理的背景图片（运行时生成）
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # v2.0.9610全面重写
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # v2.0.9610全面重写
    │   ├── GH.xml                       # v2.0.9610全面重写
    │   ├── SonsOfTheForest.xml          # IL2CPP — 不支持
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # 轻量级构造函数 + ModLibrary初始化修复
│   └── ModLib.cs                        # Cecil解析的#if DEBUG分支
└── Utils/
    └── FileValidator.cs                 # PE头 + CLR元数据验证（仅Release）

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # 独立WPF版本更新工具

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # 生成虚拟游戏/Steam结构
├── dummy_games\{GameId}\               # 虚拟游戏安装路径
├── dummy_steam\Steam.exe               # 虚拟Steam可执行文件
└── gamefiles\original\{GameId}\        # ModLib用虚拟备份路径
```

---

## 安装与配置

### 步骤 1 — 前提条件

| 项目 | 必需 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ （Windows 11 已预装；Windows 10 请[下载](https://dotnet.microsoft.com/download/dotnet-framework/net48)） |
| Steam | 必需 — 必须在 Settings 标签页中配置 |
| 至少一个受支持的游戏 | 必需 — 必须在 Settings 标签页中配置 |

### 步骤 2 — 安装 ModAPI

1. 从 GitHub 下载最新版本
2. 解压到任意文件夹（例如 `C:\ModAPI\`）
3. 运行 `ModAPI.exe`
4. 首次启动时显示 **Welcome** 屏幕 — 配置偏好设置并点击 **Continue**

### 步骤 3 — 配置 Steam 路径（Settings 标签页）

1. 转到 **Settings** 标签页
2. 找到 **Steam Installation Path**
3. 点击 **Browse** → 选择 `Steam.exe`
4. 点击 **Save**

### 步骤 4 — 配置游戏路径（Settings 标签页）

1. 点击游戏卡片标题展开
2. 点击 **Browse** → 选择游戏根文件夹（`.exe` 所在位置）
3. 点击 **Save**

| 游戏 | 可执行文件 | 路径示例 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### 步骤 5 — 下载 Mod（Downloads 标签页）

1. 转到 **Downloads** 标签页
2. 从游戏筛选器中选择游戏
3. 搜索 Mod 并点击 **Download**

> **离线**：从 `modapi.survivetheforest.net` 手动下载 `.mod` 文件并放入对应文件夹：

| 游戏 | 文件夹 |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### 步骤 6 — 应用 Mod 并启动游戏（Mods 标签页）

1. 转到 **Mods** 标签页
2. 从 **游戏筛选器**（列 0）选择游戏
3. 在 **Mod 列表**（列 1）中勾选要激活的 Mod
4. 点击 **Start Game**

以下检查在启动前自动执行：

| # | 检查内容 | 错误弹窗 |
|---|---|---|
| 1 | Steam 路径已配置且有效 | SteamNotFound |
| 2 | `mods/` 文件夹中的游戏与 Settings 中的游戏路径匹配 | GameModsMismatch |
| 3 | 至少选择了一个 Mod | NoModSelected |
| 4 | 选择中无混合游戏 Mod | MixedGameMods |
| 5 | 游戏路径已配置且可执行文件存在 | GamePathNotSet / GameNotInstalled |

---

## 标签页概述

### Welcome 标签页
首次运行设置屏幕（标签页索引 0）。配置 AutoUpdate、Steam 连接和 VersionsData 表偏好。在后续启动中，此标签页提供社区链接和发行说明。

### Mods 标签页
主要 Mod 管理工作流 — 3列布局：

| 列 | 内容 |
|---|---|
| 列 0 | 游戏筛选器 — 5个受支持游戏的单选按钮 |
| 列 1 | Mod 列表 — 已安装的 Mod，带版本选择器和激活复选框 |
| 列 2 | 信息 — 所选 Mod 详情、描述、版本历史 |

### Downloads 标签页
从 `modapi.survivetheforest.net` 浏览和下载 Mod。

- **游戏筛选器**：TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **类别筛选器**：12个类别（Bugfixes、Balancing、Cheats、…）
- **搜索**：按 Mod 名称、描述或作者
- **离线模式**：显示所有 5 个受支持游戏的文件夹说明

### Development 标签页
Mod 开发工作流 — 游戏筛选器面板（列 0）覆盖所有 5 个受支持的游戏。

- 按游戏创建、构建和应用 Mod 项目
- 语言资源管理
- 带 3 步验证的 ModLib 生成（Steam → 项目 → 游戏路径）
- 通过轻量级 `Game` 构造函数安全切换游戏（不调用 `Verify()`）

### Themes 标签页
主题选择和背景纹理管理界面。

- **主题选择**：10 种主题（Classic、Light、Dark、Diablo、Nebula、Sunset、Ocean、Nordic、Citrus、Bloom）
- **背景纹理**：选择图像作为整个应用的背景（JPEG 压缩 + 安全处理）
- 当背景纹理激活时，主题选择被锁定

### Settings 标签页
集中配置 — 4行：

| 行 | 内容 |
|---|---|
| 0 | 语言 / 字体大小 / 主题 / 最大宽度 / Mod列表宽度 / 项目列表宽度 |
| 1 | 保留 VersionsData / 自动更新 / Steam 连接 / 窗口置顶 |
| 2 | Steam 安装路径（TextBox + 浏览 + 保存 + 重置） |
| 3 | 游戏安装路径 — 每个游戏的可展开卡片（TextBox + 浏览 + 保存 + 重置） |

---

## v2.0.9618 变更内容

### 版本更新工具 (MODAPI_VersionTool)

一个独立的 WPF 工具，可一键更新版本号。

**位置**： `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**功能**
- 自动显示当前版本（从 `App.xaml.cs` 读取）
- 输入新版本并点击 **Apply Version** 同时更新两个文件
- 格式验证：仅接受 `X.X.XXXX` 格式

**修改的文件**

| 文件 | 路径 | 变更 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**使用方法**
1. 运行 `MODAPI_VersionTool.exe`
2. 输入新版本（例如 `2.0.9619`）
3. 点击 **Apply Version**
4. 在Visual Studio中重新生成ModAPI解决方案

### StatusBar 版本显示修复

- `VersionLabel.Text` 现在引用 `App.Version` 而不是硬编码的 `Version.Descriptor`
- 使用VersionTool更新版本并重新生成后立即反映在StatusBar中

---

## v2.0.9617 变更内容

### Settings 标签页 — 添加路径重置按钮

已在Steam安装路径和每个游戏安装路径行添加 **重置** 按钮。

**Steam 路径行**
```
[TextBox] [Browse] [Save] [Reset]
```

**游戏路径行（每个游戏）**
```
[TextBox] [Browse] [Save] [Reset]
```

**重置行为**
- 立即清除路径TextBox
- 将重置标志保存到 `ui.cfg`（`GamePathReset_{GameId}=1`、`SteamPathReset=1`）
- 重启后TextBox保持为空
- 解决Configuration XML不保存空字符串的限制

**Browse 自动保存**
- 之前：Browse后需要单独点击Save按钮
- 之后：选择文件时自动保存 — 即使切换到Mods标签页后也会反映

**新语言键**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | 重置 |

---

## v2.0.9616 变更内容

### Versions.xml — 4 个游戏添加/更新

| 游戏 | 文件路径 | BuildID | 备注 |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 新建 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | 校验和已更新 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 新建 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | 校验和已更新 |

### 校验和组成规则

校验和格式取决于每个游戏是否存在 `Assembly-CSharp-firstpass.dll`。

| 游戏 | firstpass.dll | 校验和格式 |
|---|---|---|
| GH | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 连接（64字符） |
| Subnautica | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 连接（64字符） |
| EscapeThePacific | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 连接（64字符） |
| Raft | ❌ 不存在 | 仅 `Assembly-CSharp MD5`（32字符） |

### Versions.xml 更新程序

添加新的 `<version>` 条目，不删除现有条目。

**步骤 1 — 查找新的BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**步骤 2 — 提取新的校验和**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**步骤 3 — 向Versions.xml添加条目**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## v2.0.9615 变更内容

### Settings 标签页游戏路径展开修复

- **卡片展开高度**：展开游戏路径卡片时，窗口底部现在精确增长输入字段的高度
- **`UpdateWindowHeight()` 改进**：在 `SizeToContent.Height` 测量前调用 `UpdateLayout()`；当背景纹理激活时临时将 `TextureLayer1` 设为 `Collapsed`，防止4K图像原始大小影响高度计算
- **内部Grid Row修复**：将游戏路径面板内部Grid的最后一个Row从 `Height="*"` 改为 `Height="Auto"` — 移除不必要的底部空白

---

## v2.0.9614 变更内容

### 最大化按钮行为修复

- **最大化**：使用 `SystemParameters.WorkArea` 手动最大化，而非 `WindowState.Maximized` — 精确适应当前屏幕分辨率，不覆盖任务栏
- **还原**：最大化前保存 `Left`、`Top`、`Width`、`Height` 和 `MaxWidth`，点击还原按钮时恢复
- **`MaxWidth` 处理**：最大化时设为 `∞`，还原时恢复保存的值

---

## v2.0.9613 变更内容

### 新增 Themes 标签页

标签页顺序现在为：

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

主题选择UI已从Settings标签页移至专用的 **Themes标签页**。
图标：Segoe MDL2 Assets `&#xE790;`（调色板）

### 主题注册表（数据驱动结构）

添加新主题现在只需在 `App.xaml.cs` 字典中添加**一行**。
所有switch语句已移除 — 其他地方无需代码更改。

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
语言键约定：`Lang.Options.Theme.{PascalCase}`（例如 `Lang.Options.Theme.Nebula`）

### 支持的主题

| 索引 | ID | 文件 | 色调 |
|---|---|---|---|
| 0 | `classic` | 仅 `Dictionary.xaml` | 原版ModAPI纹理背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明亮色调 + 蓝色强调 |
| 2 | `dark` | `FluentStyles.xaml` | 深色色调 + 蓝色强调（默认） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 红色 + 黑色 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗色太空 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮日落 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗色海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北欧 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉 |

更改主题会触发应用自动重启。（保存到 `theme.cfg`）

### 背景纹理功能

在Themes标签页的 **Background Texture** 卡片中选择图像，将其应用为整个应用的背景。适用于任何选定的主题。

**支持的输入格式**： `.png` / `.jpg` / `.jpeg`, 最大50MB，4K及以下分辨率

**图像处理管线**

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

**安全层**

| 层 | 方法 | 效果 |
|---|---|---|
| 魔法头部 | JPEG签名(FF D8 FF)前插入16字节 | 外部查看器无法识别文件 |
| Hidden属性 | `FileAttributes.Hidden` | 默认在资源管理器中隐藏 |
| SHA-256完整性 | 加载时验证哈希 | 篡改触发自动重置 + 警告弹窗 |

**篡改检测行为**
1. `bg.dat` deleted
2. `ui.cfg` 键 `TexturePath`、`TextureHash`、`TextureActive` 重置
3. TextBox和切换按钮重置
4. 显示 `Lang.Windows.TextureTampered` 弹窗

**ui.cfg keys**

| 键 | 值 | 描述 |
|---|---|---|
| `TexturePath` | 文件名（仅显示） | TextBox中显示的原始文件名 |
| `TextureHash` | SHA-256 hex | 完整性验证哈希 |
| `TextureActive` | `true` / `false` | 激活状态 |

**透明化处理**

当背景图像激活时，UI背景分两层处理。

- **Layer 1 — MergedDictionaries覆盖层**：引用 `{DynamicResource FluentBgBrush}` 等的面板自动变为透明。停用时通过一次 `Remove()` 调用恢复。

  目标键：`FluentBgBrush`、`FluentBgSecondaryBrush`、`FluentBgTertiaryBrush`、`FluentSurfaceBrush`、`FluentCardBrush`、`FluentTabBarBrush`、`FluentBorderBrush`

- **Layer 2 — 可视树遍历（`WalkStyleBackgrounds`）**：Fluent主题中的 `{StaticResource}` 元素不受Layer 1影响，因此直接遍历可视树以基于原始颜色应用半透明画刷。

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  处理对象：`Panel`（Grid除外）、`Border`、`ListBox` / `ListView`

  排除对象：`Grid`（保留背景，继续遍历子元素）、`TabPanel`（标签头保护）、`ButtonBase` / `ComboBox`、`Collapsed` 元素

  恢复方式：Style Setter来源 → `ClearValue()`，XAML本地值来源 → 直接恢复原始画刷

**标签切换**

WPF TabControl延迟加载标签内容，因此在标签切换时以 `ContextIdle` 优先级重新运行 `WalkStyleBackgrounds(this)`。已处理的元素通过 `ContainsKey` 检查跳过。

**ThemeSelector 锁定**

当背景纹理激活时，`ThemeSelectorOverlay` Border显示在主题选择器上方以阻止交互。

- XAML：在ThemeSelector上方添加 `ThemeSelectorOverlay` Border（`IsHitTestVisible=True`）
- 激活时：`ThemeSelectorOverlay.Visibility = Visible`
- 停用时：`ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` 也由 `_textureActive` 标志双重保护

**UI 状态流程**

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

**新语言键**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7个新主题名称 |
| `Lang.Options.Labels.TextureBackground` | 背景纹理标签 |
| `Lang.Options.Labels.TextureEnable` | 启用标签 |
| `Lang.Options.Labels.TextureClear` | 清除按钮 |
| `Lang.Windows.TextureTooLarge` | 文件大小超限警告 |
| `Lang.Windows.TextureTampered` | 检测到篡改警告 |

**文件结构**

```
ModAPI\
├── App.xaml.cs                    # 主题注册表、主题ID、主题应用
├── Windows\
│   ├── MainWindow.xaml            # Themes标签页、主题选择覆盖层、纹理图层1
│   └── MainWindow.xaml.cs         # 主题与纹理逻辑
├── Themes\
│   ├── Dictionary.xaml            # Classic主题
│   ├── FluentStyles.xaml          # Dark主题
│   ├── FluentStylesLight.xaml     # Light主题
│   ├── FluentStylesDiablo.xaml    # Diablo主题
│   ├── FluentStylesNebula.xaml    # Nebula主题
│   ├── FluentStylesSunset.xaml    # Sunset主题
│   ├── FluentStylesOcean.xaml     # Ocean主题
│   ├── FluentStylesNordic.xaml    # Nordic主题
│   ├── FluentStylesCitrus.xaml    # Citrus主题
│   └── FluentStylesBloom.xaml     # Bloom主题
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # 压缩且安全处理的背景图片（运行时生成）
```

**已知设计限制**

| Item | Details |
|---|---|
| ComboBox的`IsEnabled=false` | 导致 `ElementNotEnabledException` 崩溃 → 使用 `IsHitTestVisible` 覆盖层方式 |
| 直接替换 `MergedDictionaries` 键 | 布局过程中崩溃 → 仅使用 `Add`/`Remove` 模式 |
| 覆盖Hidden文件 | `Access Denied` → 写入前必须重置 `FileAttributes.Normal` |
| `{StaticResource}` 背景 | 不受Layer 1影响 → 需要WalkStyleBackgrounds（Layer 2） |

---

## v2.0.9612 变更内容

### 主题模块分离

- **新建 `Themes/` 文件夹**：将 `Dictionary.xaml`、`FluentStyles.xaml`、`FluentStylesLight.xaml` 和 `FluentStylesClassic.xaml` 移至 `ModAPI\Themes\`
- **`App.xaml.cs`**：`ApplyTheme()` — Classic主题仅使用 `Dictionary.xaml`；Light/Dark/其他Fluent主题加载对应XAML
- **`ModAPI.csproj`**：主题XAML路径更新到 `Themes\` 子目录；已注册 `FluentStylesClassic.xaml`

---

## v2.0.9611 变更内容

### 缺陷修复

- **主题切换后Mod列表宽度未应用**：修复了Light/Dark主题切换并重启后Mod列表宽度未应用的问题 — 在 `InitModListWidth()` 中添加了 `ApplyModListWidth(width)` 调用

---

---

## v2.0.9610 变更内容

### 新增

#### 游戏XML与版本配置

| # | 文件 | 变更 |
|---|------|--------|
| 1 | `GH.xml` | 全面重写 — 移除不存在的 `DOTweenPro.dll`；添加了 `AmplifyBloom/Color/Motion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | 全面重写 — 移除 `extends="GenericUnityGame"`；添加了 `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | 全面重写 — 移除 `extends="GenericUnityGame"`；`includeAssembly` → 仅 `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | 已创建 — 版本 `1.1.01` 含校验和 |
| 5 | `GH/Versions.xml` | 已创建 — 版本 `2.9.5` 含校验和 |
| 6 | `Subnautica/Versions.xml` | 已创建 — 无校验和（更新过于频繁） |

#### 关键缺陷修复

| # | 类型 | 问题 | 修复 |
|---|------|-------|-----|
| 1 | 卡死 | `extends="GenericUnityGame"` 导致 `Assembly-CSharp-firstpass.dll` 继承 → `CreateModLibrary` 停滞 | 从所有非TheForest XML中移除 `extends` |
| 2 | 崩溃 | `ResolutionException: XGamingRuntime.XUserGamertagComponent` Subnautica应用期间 | 将 `XGamingRuntime.dll`、`XblPCSandbox.dll` 添加到 `copyAssembly` |
| 3 | 崩溃 | 解析器失败 在备份创建后添加到 `copyAssembly` 的DLL上 | `Game.cs`：将实际安装文件夹添加为解析器回退 |
| 4 | 崩溃 | `IOException`: `BaseModLib.dll` `CreateModLibrary` 和 `ApplyMods` 之间的文件锁 | 重试循环：最多10×500ms读取 + 最多30×500ms存在等待 |
| 5 | 崩溃 | `NullReferenceException` — `typesMap` entry.Value为null（游戏未安装） | 添加了 `if (entry.Value == null) continue` |
| 6 | 崩溃 | `NullReferenceException` — 轻量级 `Game` 构造函数缺少 `ModLibrary = new ModLib(this)` → `CreateModLibrary()` 崩溃 | 在轻量级构造函数中添加 `ModLibrary = new ModLib(this)` |
| 7 | 崩溃 | `SwitchDevGame()` — `App.Game.GamePath` 轻量级构造函数后为空 → `CreateModLibrary` 崩溃 | 在轻量级构造函数后设置 `App.Game.GamePath = savedPath` |
| 8 | 错误游戏 | `EscapeThePacific` Mod被分类为TheForest | `ModsViewModel`：从文件夹路径提取 `GameId` |
| 9 | 错误路径 | `GetGameFolder()` → `""` → 解析到驱动器根目录（如 `E:\`） | 在所有6个调用点添加null/空保护 |

#### Debug / Release 构建分离

- **`FileValidator.cs`** — 新文件 `ModAPI_Shared\Utils\FileValidator.cs`；已注册在 `ModAPI_Shared.csproj` 中
  - `IsValidSteamExe()` — PE头（MZ + PE\0\0）+ 最小 1 MB
  - `IsValidGameExe()` — PE头 + 最小 512 KB
  - `IsValidAssemblyDll()` — PE头 + .NET CLR元数据头 + 最小 64 KB
- **`CheckSteam()`** — `#if DEBUG`：仅 `File.Exists()` / `#else`：`FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`：仅 `File.Exists()` / `#else`：`FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`：`File.Copy()` 跳过Cecil / `#else`：完整Cecil解析 + IL修改
- **`ModLib.Create()` 未找到文件** — `#if DEBUG`：记录警告，跳过 / `#else`：记录错误，中止

#### Debug 测试

- **`create_dummy_Debug_games.ps1`** — `bin\Debug\` 的PowerShell脚本；在 `dummy_games\`、`dummy_steam\` 和 `gamefiles\original\` 下为所有5个游戏创建0字节占位文件 — 无需真实游戏安装即可进行完整UI工作流测试

#### Settings 标签页

- **Steam路径卡片** — 集成到游戏安装路径卡片中； `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **游戏路径面板** — `BuildGamePathsPanel()` 带每个游戏的可展开卡片；TextBox使用 `HorizontalAlignment=Stretch`
- **全部展开 / 全部折叠**按钮
- **窗口置顶**复选框（保存到 `ui.cfg`）
- **Mod/项目列表宽度**滑块 — 从最小值 `150` 开始；保存到 `ui.cfg`
- **字体大小** ComboBox — FHD 10–16、4K 10–22、8K 10–28
- **复选框同步** — `SettingsCheckboxes.DataContext = SettingsVm`；AutoUpdate / UseSteam / UpdateVersions 现在正确同步
- **`_uiInitialized` 标志** — 防止WPF启动期间过早写入 `ui.cfg`

#### Mods 标签页 — 游戏启动验证

每次点击Start Game时执行五步验证，与Mod列表状态无关：

| 步骤 | 检查内容 | 弹窗 |
|---|---|---|
| 1 | Settings标签页Steam路径有效（`Steam.exe`存在） | SteamNotFound |
| 2 | `mods/{GameId}/` 文件夹游戏与Settings配置的游戏匹配 | GameModsMismatch |
| 3 | 至少选择了一个Mod | NoModSelected |
| 4 | 选择中无混合游戏Mod | MixedGameMods |
| 5 | 游戏路径已配置 + 可执行文件存在 | GamePathNotSet / GameNotInstalled |

#### Development 标签页 — ModLib 验证

点击Mod库再生成时的三步验证：

| 步骤 | 检查内容 | 弹窗 |
|---|---|---|
| 1 | Settings标签页Steam路径有效 | SteamNotFound |
| 2 | 至少存在一个项目 | NoProjectWarning |
| 3 | `App.Game.GamePath` 已设置 | GamePathNotSet |

#### Downloads 标签页
- 调试字符串替换为 `Lang.Downloads.Status.NoDownloads`
- 所有状态消息使用一致的内边距
- 离线手册文本已更新支持5个游戏；通过两个TextBlock换行

#### 首次设置与游戏路径系统
- `FirstSetup.Check()` — `UseSteam`、`AutoUpdate`、`UpdateVersions` 默认值为 `true`
- `FirstSetupDone()` — 为所有5个游戏创建 `mods/` 和 `projects/` 文件夹
- `SpecifyGamePath` — `GameNameLabel` 显示哪个游戏；`NavigateToSettings()` 导航到Settings标签页

#### 新增/更新的语言键

| 键 | 英文值 |
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

### 未包含

| 功能 | 原因 |
|---|---|
| 自动更新（保持最新版本） | 服务器端基础设施不可用 |
| 更新搜索 | 服务器端基础设施不可用 |

### 已移除

| 项目 | 原因 |
|---|---|
| 启动时 `SpecifyGamePath` 弹窗 | 所有路径在Settings标签页中配置 |
| 启动时 `SpecifySteamPath` 弹窗 | Steam路径在Settings标签页中配置 |
| 登录系统 | 原始服务器已停止运营（在v2.0.9400中移除） |
| `Portable.System.ValueTuple.dll` | 在Mono 2.0上无法运行（在v2.0.9586中移除） |
| Steam检查的 `UseSteam` 条件 | Steam现在在启动游戏和Mod库再生成时始终首先验证 |

---

## 未来版本计划

| # | 功能 | 描述 |
|---|---|---|
| 1 | ModAPI自动更新 | 自动下载并应用新版本的ModAPI |
| 2 | ModAPI VersionsData表更新 | 游戏新补丁发布时自动更新VersionsData表 |

---

## v2.0.9600 变更内容

### 新增

- **Downloads标签页**：5个游戏筛选器 (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome标签页**：添加在最左侧位置（索引0）
- **Mods标签页**：3列布局（WrapPanel → 垂直列表）；自动宽度调整；Mod名称换行
- **`ModsViewModel`**：按游戏筛选，`ResolveGame()` 为每个Mod获取正确的 `Game` 实例
- **`Game.cs`**：轻量级构造函数 `new Game(config, true)` — 仅识别，不调用 `Verify()`
- **构建**：4个游戏XML文件在 `ModAPI.csproj` 中注册，使用 `CopyToOutputDirectory=Always`
- **构建**：清除警告 — CS0168、CS0618、CS0252
- **游戏XML**：TheForest、Raft、GH DLL列表已修正
- **语言标志**：13个语言徽章的图像大小已标准化

### 已移除

| 项目 | 原因 |
|---|---|
| 游戏XML文件中的 `extends="GenericUnityGame"` | 导致 `Assembly-CSharp-firstpass.dll` 被错误继承 — 从Subnautica、Raft、EscapeThePacific、GH中移除 |
| Mods标签页中的 `WrapPanel` 布局 | 替换为3列Grid布局（游戏筛选器 / Mod列表 / 信息） |

---

## 各阶段主要变更

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
全部5个项目从 .NET 4.5 → 4.8 迁移。

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6、`FluentStyles.xaml`、UnityEngine 存根DLL。

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
3主题系统、`theme.cfg`、窗口拖动修复、超链接支持。

### Phase 4 *(v2.0.9400)* — Code Cleanup
登录系统移除，更新机制现代化。

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Downloads标签页、Segoe MDL2 Assets图标、13语言支持。

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`、`CustomAssemblyResolver.cs`、PE头修补。

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
黑屏修复、`ValueTuple` 移除、C# 7.3游戏内验证。

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5个游戏筛选器、3列Mods标签页、轻量级 `Game` 构造函数、XML已注册。

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML已修正、Steam路径、游戏路径安全、启动游戏5步验证、ModLib 3步验证、`FileValidator` PE头验证、`#if DEBUG` 构建分离、`create_dummy_Debug_games.ps1`、轻量级构造函数 `ModLibrary` 修复、`SwitchDevGame` GamePath修复、5个游戏文件夹创建、崩溃修复。

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Themes标签页新增、10个主题 + 背景纹理功能、Themes/文件夹分离、最大化按钮修复、游戏路径展开修复、Versions.xml 4个游戏更新、路径重置按钮、Browse自动保存、MODAPI_VersionTool。

---

## 版本历史

### v2.0.9618 — 2026-04-25
新增 MODAPI_VersionTool（独立 WPF 版本更新工具），StatusBar 版本显示关联 App.Version

### v2.0.9617 — 2026-04-24
Settings 标签页添加 Steam/游戏路径重置按钮，Browse 自动保存，重置状态通过 ui.cfg 标志保存

### v2.0.9616 — 2026-04-18
Versions.xml 为 4 个游戏新建/更新（Subnautica、Raft、EscapeThePacific、GH），建立校验和组成规则，记录游戏更新程序

### v2.0.9615 — 2026-04-18
修复 Settings 标签页游戏路径卡片展开高度精度，防止 UpdateWindowHeight 背景纹理干扰

### v2.0.9614 — 2026-04-18
最大化按钮基于 WorkArea 手动最大化，保存和恢复之前的大小/位置

### v2.0.9613 — 2026-04-18
新增 Themes 标签页，主题注册表数据驱动结构，支持 10 种主题，背景纹理功能（压缩、安全、2 层透明化），ThemeSelector 锁定覆盖层，12 个新语言键

### v2.0.9612 — 2026-04-18
Themes/ 文件夹分离，主题 XAML 模块化

### v2.0.9611 — 2026-04-18
修复主题切换后 Mod 列表宽度未应用的问题

### v2.0.9610 — 2026-04-13
多游戏XML修正（GH、Subnautica、EscapeThePacific），Versions.xml已添加，Settings标签页重新设计（Steam路径、游戏路径面板、宽度滑块、字体大小、复选框同步），游戏路径null安全（6处），启动弹窗替换为Settings标签页，Mods标签页5步启动游戏验证（Steam始终优先），Dev标签页3步ModLib验证，GameModsMismatch弹窗已添加，轻量级构造函数ModLibrary null修复，SwitchDevGame GamePath修复，FileValidator PE头验证（Release），#if DEBUG构建分离（CheckSteam / CheckGamePath / ModLib.Create），create_dummy_Debug_games.ps1，持久化ui.cfg，5键字体系统，多处崩溃修复，语言键已更新

### v2.0.9600 — 2026-04-09
5个游戏筛选器、Mods标签页3列布局、自动宽度、轻量级 `Game` 构造函数、`ModsViewModel` 游戏筛选、4个XML文件已注册、构建警告已清除、Welcome标签页、语言标志已标准化

### v2.0.9586 — 2026-03-31
黑屏修复、polyfill最终化、ValueTuple移除、C# 7.3已验证

### v2.0.9561 — 2026-03-06
C# 7.3支持、PE头修补、polyfill管线、程序集解析恢复

### v2.0.9552 — 2026-02-25
Downloads标签页、图标现代化、主题统一、13语言支持

### v2.0.9500
主题系统（Classic/Light/Dark）、Fluent Design UI、SubWindow系统

### v2.0.9400
代码清理、登录移除、旧代码现代化

### v2.0.9300
构建环境、UnityEngine存根DLL、ModernWpf集成

### v2.0.9200
.NET Framework 4.8 迁移

### v1.x
原版 FluffyFish 发布

---

## 构建要求

| 要求 | 版本 | 备注 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI项目 |
| .NET Framework SDK | 3.5 | 仅BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## 许可证

GNU General Public License v3.0 — 遵循原始许可证。
