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

**The Forest Mod管理工具 — 升級版**

> 原作: FluffyFish / Philipp Mohrenstecher (德國恩格爾斯基興)
> 升級: zzangae (大韓民國)

---

## 概述

ModAPI是一款用於管理**5款官方支援遊戲**Mod的桌面應用程式。本升級版包含多遊戲支援、全面重新設計的Settings標籤頁、Steam路徑配置、持久化UI設定、動態字體大小系統、遊戲啟動驗證、Debug/Release構建分離以及通過遊戲內測試驗證的大量崩潰修復。

---

## 支援的遊戲

| 遊戲 | 引擎 | 版本 | Steam ID | 可執行檔 |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02（測試版） | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 5（從 Unity 4 升級） |
| 最新版本 | v1.12 (VR) |
| 最後更新 | 2019年9月11日 — VR 支援補丁；此後無主要內容更新 |
| 可執行檔 | `TheForest.exe` |
| 資料夾 | `TheForest_Data/Managed/` |
| Mod 資料夾 | `mods/TheForest/` |
| 專案資料夾 | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 完全支援 |

The Forest 從 Unity 4 升級到 Unity 5，顯著改善了視覺效果和物理效果。2019年9月的 VR 補丁是最後一次主要更新。遊戲目前維持穩定的最終狀態——非常適合模組製作。
</details>

<details>
<summary><b>Subnautica</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity（2022年與 Below Zero 統一的整合程式碼庫） |
| 最新版本 | 2025 Patch (v18810395) |
| 最後更新 | 2025年8月12日 — 隨行動版發布同步的錯誤修復和效能改進 |
| 可執行檔 | `Subnautica.exe` |
| 資料夾 | `Subnautica_Data/Managed/` |
| Mod 資料夾 | `mods/Subnautica/` |
| 專案資料夾 | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — 支援 |

最初基於 Unity 5 建構，Subnautica 在2022年末收到了 'Living Large' 更新（v2.0），將引擎程式碼庫與 Below Zero 合併以提高最佳化和穩定性。注：即將推出的 *Subnautica 2* 使用 Unreal Engine 5。

> **v2.0.9610 XML 重寫**：將 `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` 新增到 `copyAssembly`。
</details>

<details>
<summary><b>RAFT</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity |
| 最新版本 | v1.1.02（測試版）/ v1.09（穩定版） |
| 最後更新 | 2026年3月 — 透過測試分支修復語音聊天和多人遊戲錯誤 |
| 可執行檔 | `Raft.exe` |
| 資料夾 | `Raft_Data/Managed/` |
| Mod 資料夾 | `mods/Raft/` |
| 專案資料夾 | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — 支援 |
| Versions.xml | `1.1.01`（含校驗和） |

在 v1.0：*The Final Chapter* 官方故事完結後，補丁持續進行網路程式碼改進和穩定性提升。
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 6（2025年末從 Unity 2021/2022 遷移） |
| 最新版本 | v0.67.0.0 |
| 最後更新 | 2025年6月26日 — 島嶼分布重做和引擎更新；2026年持續熱修復 |
| 可執行檔 | `EscapeThePacific.exe` |
| 資料夾 | `EscapeThePacific_Data/Managed/` |
| Mod 資料夾 | `mods/EscapeThePacific/` |
| 專案資料夾 | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — 支援 |

2025年末完成了大規模系統重建和 Unity 6 遷移，實現了更加動態的環境。遊戲仍在積極的搶先體驗開發中。

> **v2.0.9610 XML 重寫**：移除 `extends="GenericUnityGame"`；將 `includeAssembly` 設定為僅 `Assembly-CSharp.dll` — 防止 `Assembly-CSharp-firstpass.dll` 繼承錯誤。
</details>

<details>
<summary><b>Green Hell</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 2019 |
| 最新版本 | v2.9.5 |
| 最後更新 | 2026年2月4日 — Steam Deck 最佳化和文字可讀性改進 |
| 可執行檔 | `GH.exe` |
| 資料夾 | `GH_Data/Managed/` |
| Mod 資料夾 | `mods/GH/` |
| 專案資料夾 | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — 支援 |
| Versions.xml | `2.9.5`（含校驗和） |

開發過程中逐步將引擎從 Unity 2017 → 2018 → 2019 升級。2026年2月的熱修復專注於 Steam Deck 相容性和 UI 文字可讀性。

> **v2.0.9610 XML 重寫**：新增 `AmplifyBloom.dll`、`AmplifyColor.dll`、`AmplifyMotion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`；移除不存在的 `DOTweenPro.dll`。
</details>

---

## 架構

### 執行階段分離

| 元件 | 目標 | 執行階段 | 原因 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 桌面應用程式，完整現代API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 共用程式庫 |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **永久固定** — PE標頭必須包含 `v2.0.50727` |
| Mod DLL（使用者） | .NET Framework 4.8 | Game Mono 2.0（已修補） | 使用4.8建置，套用時修補PE標頭 |

### Debug / Release 建置分離

所有檔案驗證和組件處理根據建置組態透過 `#if DEBUG` / `#else` 分支。

| 位置 | Debug 建置 | Release 建置 |
|---|---|---|
| `CheckSteam()` | 僅 `File.Exists()` — 虛擬檔案通過 | `FileValidator.IsValidSteamExe()` — PE標頭 + 最小 1 MB |
| `CheckGamePath()` | 僅 `File.Exists()` — 虛擬檔案通過 | `FileValidator.IsValidAssemblyDll()` — PE標頭 + CLR中繼資料 + 最小 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — 跳過Cecil解析 | 完整Mono.Cecil解析 + IL修改 + `module.Write()` |
| `ModLib.Create()` — 找不到檔案 | 記錄警告，跳過並繼續 | 記錄錯誤，彈窗中止 |

**Debug測試**使用 `create_dummy_Debug_games.ps1` 在 `bin\Debug\dummy_games\`、`bin\Debug\dummy_steam\` 和 `bin\Debug\gamefiles\original\` 下產生0位元組佔位檔案。這些檔案通過 `File.Exists()` 檢查，允許在無真實遊戲安裝的情況下進行完整UI工作流程測試。

**Release建置**套用 `FileValidator`（PE標頭 + .NET CLR中繼資料驗證）來拒絕0位元組檔案、文字檔和任意二進位檔案。只有有效的Windows可執行檔和.NET組件才能通過。

### FileValidator — PE標頭驗證

`ModAPI_Shared\Utils\FileValidator.cs` — 僅在Release建置中套用。

| 方法 | 檢查內容 | 最小大小 |
|---|---|---|
| `IsValidSteamExe(path)` | MZ簽章 + PE\0\0簽章 | 1 MB |
| `IsValidGameExe(path)` | MZ簽章 + PE\0\0簽章 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR中繼資料標頭（資料目錄 #14） | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### 組件重新對應管線

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

### 組件解析器備援

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### C# 7.3 功能支援

| 功能 | 狀態 | 備註 |
|---|---|---|
| 模式比對 (`is`, `switch`) | ✅ | 已在遊戲中驗證 |
| 字串插值 (`$""`) | ✅ | 已在遊戲中驗證 |
| 內嵌 `out` 變數 | ✅ | 已在遊戲中驗證 |
| `async` / `await` | ✅ | 透過 AsyncBridge + System.Threading polyfill |
| 元組 (`ValueTuple`) | ❌ 絕對限制 | Mono 2.0 `mscorlib` ABI — 無解決方案 |

### 主題系統

從 v2.0.9613 起，主題選擇介面已從 Settings 標籤頁移至專用的 **Themes 標籤頁**。新增主題只需在 `App.xaml.cs` 字典中新增一行。

| 索引 | ID | 檔案 | 調色盤 |
|---|---|---|---|
| 0 | `classic` | 僅 `Dictionary.xaml` | 原版 ModAPI 紋理背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明亮色調 + 藍色強調 |
| 2 | `dark` | `FluentStyles.xaml` | 深色色調 + 藍色強調（預設） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 紅色 + 黑色 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗色太空 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮夕陽 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗色海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北歐 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉 |

更改主題會觸發應用自動重啟。（儲存到 `theme.cfg`）

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

### 背景紋理

在 Themes 標籤頁的 **Background Texture** 卡片中選擇圖像，將其應用為整個應用的背景。支援格式：`.png` / `.jpg` / `.jpeg`，最大 50MB，4K 及以下解析度。圖像以 JPEG Q75 壓縮，附加 16 位元組魔法標頭，儲存為 `resources\textures\ui_bg\bg.dat`（Hidden 屬性）。SHA-256 雜湊用於完整性驗證；偵測到竄改時自動重設 + 警告彈窗。

當背景啟用時，UI 透明化分兩層處理：Layer 1（MergedDictionaries 覆蓋層）用於 `{DynamicResource}` 面板，Layer 2（WalkStyleBackgrounds）用於基於 `{StaticResource}` 的面板半透明化。

### 字型大小系統

| 資源鍵 | 基礎值 | 描述 |
|---|---|---|
| `AppBaseFontSize` | 13 | 一般文字 |
| `AppBaseHeaderFontSize` | 16 | 標題、面板標題 |
| `AppBaseSmallFontSize` | 12 | 次要標籤 |
| `AppBaseTinyFontSize` | 10 | 提示文字 |
| `AppBaseLargeFontSize` | 20 | 大型顯示文字 |

### 持久化UI設定 — `ui.cfg`

| 鍵 | 預設值 | 描述 |
|-----|---------|-------------|
| `ModListWidth` | `150` | Mod清單寬度 (px) |
| `ProjectListWidth` | `150` | 專案清單寬度 (px) |
| `AppFontSize` | `13` | 全域UI字型大小 (px) |
| `AlwaysOnTop` | `false` | 視窗置頂 |
| `TexturePath` | *(無)* | 背景材質原始檔名（僅顯示） |
| `TextureHash` | *(無)* | 背景材質 SHA-256 雜湊 |
| `TextureActive` | `false` | 背景材質啟用狀態 |
| `GamePathReset_{GameId}` | *(無)* | 遊戲路徑重設旗標 |
| `SteamPathReset` | *(無)* | Steam路徑重設旗標 |

### 檔案結構

```
ModAPI/
├── App.xaml / App.xaml.cs              # 佈景主題註冊表、佈景主題ID、佈景主題套用
├── ui.cfg                               # 持久化UI設定
├── theme.cfg                            # 目前佈景主題
├── Windows/
│   ├── MainWindow.xaml / .cs            # 主UI — 6個分頁、佈景主題、設定、Steam路徑
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # 遊戲路徑彈窗（動態GameNameLabel）
│       ├── FirstSetup.xaml / .cs        # 首次執行設定 + 預設初始化
│       └── （其他14個子視窗）
├── Themes/
│   ├── Dictionary.xaml                  # Classic佈景主題
│   ├── FluentStyles.xaml                # Dark佈景主題
│   ├── FluentStylesLight.xaml           # Light佈景主題
│   ├── FluentStylesDiablo.xaml          # Diablo佈景主題
│   ├── FluentStylesNebula.xaml          # Nebula佈景主題
│   ├── FluentStylesSunset.xaml          # Sunset佈景主題
│   ├── FluentStylesOcean.xaml           # Ocean佈景主題
│   ├── FluentStylesNordic.xaml          # Nordic佈景主題
│   ├── FluentStylesCitrus.xaml          # Citrus佈景主題
│   └── FluentStylesBloom.xaml           # Bloom佈景主題
├── Data/
│   ├── Game.cs                          # 組件修補、null保護、解析器備援
│   ├── ModLib.cs                        # BaseModLib產生 + 重新對應（#if DEBUG分支）
│   ├── Models/
│   │   └── ModProject.cs                # 專案建立/建置/套用 + null保護
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # 已篩選Mod、已選Mod、已選遊戲篩選器
│   │   ├── ModViewModel.cs              # 從資料夾路徑取得GameId
│   │   ├── ModProjectsViewModel.cs      # DispatcherTimer的Dispose()
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersions預設為true
│   └── AssemblyVersionMap.cs            # Mono 2.0組件版本對應（20個組件）
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 基於名稱的解析器（附快取）
│   └── MonoHelper.cs                    # Mono.Cecil IL輔助工具
├── resources/
│   ├── langs/                           # 13個語言檔案
│   └── textures/ui_bg/
│       └── bg.dat                       # 壓縮且安全處理的背景圖片（執行時產生）
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # v2.0.9610全面重寫
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # v2.0.9610全面重寫
    │   ├── GH.xml                       # v2.0.9610全面重寫
    │   ├── SonsOfTheForest.xml          # IL2CPP — 不支援
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # 輕量級建構子 + ModLibrary初始化修復
│   └── ModLib.cs                        # Cecil解析的#if DEBUG分支
└── Utils/
    └── FileValidator.cs                 # PE標頭 + CLR中繼資料驗證（僅Release）

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # 獨立WPF版本更新工具

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # 產生虛擬遊戲/Steam結構
├── dummy_games\{GameId}\               # 虛擬遊戲安裝路徑
├── dummy_steam\Steam.exe               # 虛擬Steam可執行檔
└── gamefiles\original\{GameId}\        # ModLib用虛擬備份路徑
```

---

## 安裝與配置

### 步驟 1 — 先決條件

| 項目 | 必要 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ （Windows 11 已預裝；Windows 10 請[下載](https://dotnet.microsoft.com/download/dotnet-framework/net48)） |
| Steam | 必要 — 必須在 Settings 分頁中設定 |
| 至少一個受支援的遊戲 | 必要 — 必須在 Settings 分頁中設定 |

### 步驟 2 — 安裝 ModAPI

1. 從 GitHub 下載最新版本
2. 解壓縮到任意資料夾（例如 `C:\ModAPI\`）
3. 執行 `ModAPI.exe`
4. 首次啟動時顯示 **Welcome** 畫面 — 設定偏好並點擊 **Continue**

### 步驟 3 — 設定 Steam 路徑（Settings 分頁）

1. 前往 **Settings** 分頁
2. 找到 **Steam Installation Path**
3. 點擊 **Browse** → 選擇 `Steam.exe`
4. 點擊 **Save**

### 步驟 4 — 設定遊戲路徑（Settings 分頁）

1. 點擊遊戲卡片標題以展開
2. 點擊 **Browse** → 選擇遊戲根資料夾（`.exe` 所在位置）
3. 點擊 **Save**

| 遊戲 | 可執行檔 | 路徑範例 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### 步驟 5 — 下載 Mod（Downloads 分頁）

1. 前往 **Downloads** 分頁
2. 從遊戲篩選器中選擇遊戲
3. 搜尋 Mod 並點擊 **Download**

> **離線**：從 `modapi.survivetheforest.net` 手動下載 `.mod` 檔案並放入對應資料夾：

| 遊戲 | 資料夾 |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### 步驟 6 — 套用 Mod 並啟動遊戲（Mods 分頁）

1. 前往 **Mods** 分頁
2. 從 **遊戲篩選器**（欄 0）選擇遊戲
3. 在 **Mod 清單**（欄 1）中勾選要啟用的 Mod
4. 點擊 **Start Game**

以下檢查在啟動前自動執行：

| # | 檢查內容 | 錯誤彈窗 |
|---|---|---|
| 1 | Steam 路徑已設定且有效 | SteamNotFound |
| 2 | `mods/` 資料夾中的遊戲與 Settings 中的遊戲路徑相符 | GameModsMismatch |
| 3 | 至少選擇了一個 Mod | NoModSelected |
| 4 | 選擇中無混合遊戲 Mod | MixedGameMods |
| 5 | 遊戲路徑已設定且可執行檔存在 | GamePathNotSet / GameNotInstalled |

---

## 標籤頁概述

### Welcome 分頁
首次執行設定畫面（分頁索引 0）。設定 AutoUpdate、Steam 連線和 VersionsData 表偏好。在後續啟動中，此分頁提供社群連結和版本說明。

### Mods 分頁
主要 Mod 管理工作流程 — 3欄配置：

| 欄 | 內容 |
|---|---|
| 欄 0 | 遊戲篩選器 — 5個受支援遊戲的選項按鈕 |
| 欄 1 | Mod 清單 — 已安裝的 Mod，附版本選擇器和啟用核取方塊 |
| 欄 2 | 資訊 — 所選 Mod 詳情、描述、版本歷程 |

### Downloads 分頁
從 `modapi.survivetheforest.net` 瀏覽和下載 Mod。

- **遊戲篩選器**：TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **類別篩選器**：12個類別（Bugfixes、Balancing、Cheats、…）
- **搜尋**：按 Mod 名稱、描述或作者
- **離線模式**：顯示所有 5 個受支援遊戲的資料夾說明

### Development 分頁
Mod 開發工作流程 — 遊戲篩選器面板（欄 0）涵蓋所有 5 個受支援的遊戲。

- 按遊戲建立、建置和套用 Mod 專案
- 語言資源管理
- 附 3 步驟驗證的 ModLib 產生（Steam → 專案 → 遊戲路徑）
- 透過輕量級 `Game` 建構子安全切換遊戲（不呼叫 `Verify()`）

### Themes 標籤頁
主題選擇和背景紋理管理介面。

- **主題選擇**：10 種主題（Classic、Light、Dark、Diablo、Nebula、Sunset、Ocean、Nordic、Citrus、Bloom）
- **背景紋理**：選擇圖像作為整個應用的背景（JPEG 壓縮 + 安全處理）
- 當背景紋理啟用時，主題選擇被鎖定

### Settings 分頁
集中設定 — 4列：

| 列 | 內容 |
|---|---|
| 0 | 語言 / 字型大小 / 佈景主題 / 最大寬度 / Mod清單寬度 / 專案清單寬度 |
| 1 | 保留 VersionsData / 自動更新 / Steam 連線 / 視窗置頂 |
| 2 | Steam 安裝路徑（TextBox + 瀏覽 + 儲存 + 重設） |
| 3 | 遊戲安裝路徑 — 每個遊戲的可展開卡片（TextBox + 瀏覽 + 儲存 + 重設） |

---

## v2.0.9618 變更內容

### 版本更新工具 (MODAPI_VersionTool)

一個獨立的 WPF 工具，可一鍵更新版本號。

**位置**： `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**功能**
- 自動顯示目前版本（從 `App.xaml.cs` 讀取）
- 輸入新版本並點擊 **Apply Version** 同時更新兩個檔案
- 格式驗證：僅接受 `X.X.XXXX` 格式

**修改的檔案**

| 檔案 | 路徑 | 變更 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**使用方法**
1. 執行 `MODAPI_VersionTool.exe`
2. 輸入新版本（例如 `2.0.9619`）
3. 點擊 **Apply Version**
4. 在Visual Studio中重新建置ModAPI方案

### StatusBar 版本顯示修復

- `VersionLabel.Text` 現在參照 `App.Version` 而非硬式編碼的 `Version.Descriptor`
- 使用VersionTool更新版本並重新建置後立即反映在StatusBar中

---

## v2.0.9617 變更內容

### Settings 標籤頁 — 新增路徑重設按鈕

已新增 **重設** 按鈕 to the Steam installation path and each game installation path row.

**Steam 路徑行**
```
[TextBox] [Browse] [Save] [Reset]
```

**遊戲路徑行（每個遊戲）**
```
[TextBox] [Browse] [Save] [Reset]
```

**重設行為**
- 立即清除路徑TextBox
- 將重設旗標儲存到 `ui.cfg`（`GamePathReset_{GameId}=1`、`SteamPathReset=1`）
- 重新啟動後TextBox保持為空
- 解決Configuration XML不儲存空字串的限制

**Browse 自動儲存**
- 之前：Browse後需要單獨點擊Save按鈕
- 之後：選擇檔案時自動儲存 — 即使切換到Mods分頁後也會反映

**新語言鍵**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | 重設 |

---

## v2.0.9616 變更內容

### Versions.xml — 4 個遊戲新增/更新

| 遊戲 | 檔案路徑 | BuildID | 備註 |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 新建 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | 校驗和已更新 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 新建 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | 校驗和已更新 |

### 校驗和組成規則

校驗和格式取決於每個遊戲是否存在 `Assembly-CSharp-firstpass.dll`。

| 遊戲 | firstpass.dll | 校驗和格式 |
|---|---|---|
| GH | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 串接（64字元） |
| Subnautica | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 串接（64字元） |
| EscapeThePacific | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 串接（64字元） |
| Raft | ❌ 不存在 | 僅 `Assembly-CSharp MD5`（32字元） |

### Versions.xml 更新程序

新增 `<version>` 條目，不移除現有條目。

**步驟 1 — 尋找新的BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**步驟 2 — 擷取新的校驗和**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**步驟 3 — 向Versions.xml新增條目**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## v2.0.9615 變更內容

### Settings 標籤頁遊戲路徑展開修復

- **卡片展開高度**：展開遊戲路徑卡片時，視窗底部現在精確增長輸入欄位的高度
- **`UpdateWindowHeight()` 改進**：在 `SizeToContent.Height` 測量前呼叫 `UpdateLayout()`；當背景材質啟用時暫時將 `TextureLayer1` 設為 `Collapsed`，防止4K圖片原始大小影響高度計算
- **內部Grid Row修復**：將遊戲路徑面板內部Grid的最後一個Row從 `Height="*"` 改為 `Height="Auto"` — 移除不必要的底部空白

---

## v2.0.9614 變更內容

### 最大化按鈕行為修復

- **最大化**：使用 `SystemParameters.WorkArea` 手動最大化，而非 `WindowState.Maximized` — 精確適應目前螢幕解析度，不覆蓋工作列
- **還原**：最大化前儲存 `Left`、`Top`、`Width`、`Height` 和 `MaxWidth`，點擊還原按鈕時恢復
- **`MaxWidth` 處理**：最大化時設為 `∞`，還原時恢復儲存的值

---

## v2.0.9613 變更內容

### 新增 Themes 標籤頁

分頁順序現在為：

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

佈景主題選擇UI已從Settings分頁移至專用的 **Themes分頁**。
圖示：Segoe MDL2 Assets `&#xE790;`（調色盤）

### 主題註冊表（資料驅動結構）

新增佈景主題現在只需在 `App.xaml.cs` 字典中新增**一行**。
所有switch陳述式已移除 — 其他地方無需程式碼變更。

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
語言鍵慣例：`Lang.Options.Theme.{PascalCase}`（例如 `Lang.Options.Theme.Nebula`）

### 支援的主題

| 索引 | ID | 檔案 | 色調 |
|---|---|---|---|
| 0 | `classic` | 僅 `Dictionary.xaml` | 原版ModAPI材質背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明亮色調 + 藍色強調 |
| 2 | `dark` | `FluentStyles.xaml` | 深色色調 + 藍色強調（預設） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 紅色 + 黑色 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗色太空 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮日落 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗色海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北歐 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉 |

變更佈景主題會觸發應用程式自動重新啟動。（儲存到 `theme.cfg`）

### 背景紋理功能

在Themes分頁的 **Background Texture** 卡片中選擇圖片，將其套用為整個應用程式的背景。適用於任何選定的佈景主題。

**支援的輸入格式**： `.png` / `.jpg` / `.jpeg`, 最大50MB，4K及以下解析度

**圖像處理管線**

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

**安全層**

| 層 | 方法 | 效果 |
|---|---|---|
| 魔法標頭 | JPEG簽章(FF D8 FF)前插入16位元組 | 外部檢視器無法辨識檔案 |
| Hidden屬性 | `FileAttributes.Hidden` | 預設在檔案總管中隱藏 |
| SHA-256完整性 | 載入時驗證雜湊 | 竄改觸發自動重設 + 警告彈窗 |

**竄改偵測行為**
1. `bg.dat` deleted
2. `ui.cfg` 鍵 `TexturePath`、`TextureHash`、`TextureActive` 重設
3. TextBox和切換按鈕重設
4. 顯示 `Lang.Windows.TextureTampered` 彈窗

**ui.cfg keys**

| 鍵 | 值 | 描述 |
|---|---|---|
| `TexturePath` | 檔名（僅顯示） | TextBox中顯示的原始檔名 |
| `TextureHash` | SHA-256 hex | 完整性驗證雜湊 |
| `TextureActive` | `true` / `false` | 啟用狀態 |

**透明化處理**

當背景圖片啟用時，UI背景分兩層處理。

- **Layer 1 — MergedDictionaries覆蓋層**：參照 `{DynamicResource FluentBgBrush}` 等的面板自動變為透明。停用時透過一次 `Remove()` 呼叫還原。

  目標鍵：`FluentBgBrush`、`FluentBgSecondaryBrush`、`FluentBgTertiaryBrush`、`FluentSurfaceBrush`、`FluentCardBrush`、`FluentTabBarBrush`、`FluentBorderBrush`

- **Layer 2 — 視覺樹走訪（`WalkStyleBackgrounds`）**：Fluent佈景主題中的 `{StaticResource}` 元素不受Layer 1影響，因此直接走訪視覺樹以基於原始色彩套用半透明筆刷。

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  處理對象：`Panel`（Grid除外）、`Border`、`ListBox` / `ListView`

  排除對象：`Grid`（保留背景，繼續走訪子元素）、`TabPanel`（分頁標頭保護）、`ButtonBase` / `ComboBox`、`Collapsed` 元素

  還原方式：Style Setter來源 → `ClearValue()`，XAML本機值來源 → 直接還原原始筆刷

**標籤切換**

WPF TabControl延遲載入分頁內容，因此在分頁切換時以 `ContextIdle` 優先順序重新執行 `WalkStyleBackgrounds(this)`。已處理的元素透過 `ContainsKey` 檢查跳過。

**ThemeSelector 鎖定**

當背景材質啟用時，`ThemeSelectorOverlay` Border顯示在佈景主題選擇器上方以阻擋互動。

- XAML：在ThemeSelector上方新增 `ThemeSelectorOverlay` Border（`IsHitTestVisible=True`）
- 啟用時：`ThemeSelectorOverlay.Visibility = Visible`
- 停用時：`ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` 也由 `_textureActive` 旗標雙重保護

**UI 狀態流程**

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

**新語言鍵**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7個新佈景主題名稱 |
| `Lang.Options.Labels.TextureBackground` | 背景材質標籤 |
| `Lang.Options.Labels.TextureEnable` | 啟用標籤 |
| `Lang.Options.Labels.TextureClear` | 清除按鈕 |
| `Lang.Windows.TextureTooLarge` | 檔案大小超限警告 |
| `Lang.Windows.TextureTampered` | 偵測到竄改警告 |

**檔案結構**

```
ModAPI\
├── App.xaml.cs                    # 佈景主題註冊表、佈景主題ID、佈景主題套用
├── Windows\
│   ├── MainWindow.xaml            # Themes分頁、佈景主題選擇覆蓋層、材質圖層1
│   └── MainWindow.xaml.cs         # 佈景主題與材質邏輯
├── Themes\
│   ├── Dictionary.xaml            # Classic佈景主題
│   ├── FluentStyles.xaml          # Dark佈景主題
│   ├── FluentStylesLight.xaml     # Light佈景主題
│   ├── FluentStylesDiablo.xaml    # Diablo佈景主題
│   ├── FluentStylesNebula.xaml    # Nebula佈景主題
│   ├── FluentStylesSunset.xaml    # Sunset佈景主題
│   ├── FluentStylesOcean.xaml     # Ocean佈景主題
│   ├── FluentStylesNordic.xaml    # Nordic佈景主題
│   ├── FluentStylesCitrus.xaml    # Citrus佈景主題
│   └── FluentStylesBloom.xaml     # Bloom佈景主題
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # 壓縮且安全處理的背景圖片（執行時產生）
```

**已知設計限制**

| Item | Details |
|---|---|
| ComboBox的`IsEnabled=false` | 導致 `ElementNotEnabledException` 當機 → 使用 `IsHitTestVisible` 覆蓋層方式 |
| 直接替換 `MergedDictionaries` 鍵 | 配置過程中當機 → 僅使用 `Add`/`Remove` 模式 |
| 覆寫Hidden檔案 | `Access Denied` → 寫入前必須重設 `FileAttributes.Normal` |
| `{StaticResource}` 背景 | 不受Layer 1影響 → 需要WalkStyleBackgrounds（Layer 2） |

---

## v2.0.9612 變更內容

### 主題模組分離

- **新建 `Themes/` 資料夾**：將 `Dictionary.xaml`、`FluentStyles.xaml`、`FluentStylesLight.xaml` 和 `FluentStylesClassic.xaml` 移至 `ModAPI\Themes\`
- **`App.xaml.cs`**：`ApplyTheme()` — Classic佈景主題僅使用 `Dictionary.xaml`；Light/Dark/其他Fluent佈景主題載入對應XAML
- **`ModAPI.csproj`**：佈景主題XAML路徑更新到 `Themes\` 子目錄；已註冊 `FluentStylesClassic.xaml`

---

## v2.0.9611 變更內容

### 缺陷修復

- **佈景主題切換後Mod清單寬度未套用**：修復了Light/Dark佈景主題切換並重新啟動後Mod清單寬度未套用的問題 — 在 `InitModListWidth()` 中新增了 `ApplyModListWidth(width)` 呼叫

---

---

## v2.0.9610 變更內容

### 新增

#### 遊戲XML與版本設定

| # | 檔案 | 變更 |
|---|------|--------|
| 1 | `GH.xml` | 全面重寫 — 移除不存在的 `DOTweenPro.dll`；新增了 `AmplifyBloom/Color/Motion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | 全面重寫 — 移除 `extends="GenericUnityGame"`；新增了 `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | 全面重寫 — 移除 `extends="GenericUnityGame"`；`includeAssembly` → 僅 `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | 已建立 — 版本 `1.1.01` 含校驗和 |
| 5 | `GH/Versions.xml` | 已建立 — 版本 `2.9.5` 含校驗和 |
| 6 | `Subnautica/Versions.xml` | 已建立 — 無校驗和（更新過於頻繁） |

#### 關鍵缺陷修復

| # | 類型 | 問題 | 修復 |
|---|------|-------|-----|
| 1 | 卡死 | `extends="GenericUnityGame"` 導致 `Assembly-CSharp-firstpass.dll` 繼承 → `CreateModLibrary` 停滯 | 從所有非TheForest XML中移除 `extends` |
| 2 | 當機 | `ResolutionException: XGamingRuntime.XUserGamertagComponent` Subnautica套用期間 | 將 `XGamingRuntime.dll`、`XblPCSandbox.dll` 新增到 `copyAssembly` |
| 3 | 當機 | 解析器失敗 在備份建立後新增到 `copyAssembly` 的DLL上 | `Game.cs`：將實際安裝資料夾新增為解析器備援 |
| 4 | 當機 | `IOException`: `BaseModLib.dll` `CreateModLibrary` 和 `ApplyMods` 之間的檔案鎖定 | 重試迴圈：最多10×500ms讀取 + 最多30×500ms存在等待 |
| 5 | 當機 | `NullReferenceException` — `typesMap` entry.Value為null（遊戲未安裝） | 新增了 `if (entry.Value == null) continue` |
| 6 | 當機 | `NullReferenceException` — 輕量級 `Game` 建構子缺少 `ModLibrary = new ModLib(this)` → `CreateModLibrary()` 當機 | 在輕量級建構子中新增 `ModLibrary = new ModLib(this)` |
| 7 | 當機 | `SwitchDevGame()` — `App.Game.GamePath` 輕量級建構子後為空 → `CreateModLibrary` 當機 | 在輕量級建構子後設定 `App.Game.GamePath = savedPath` |
| 8 | 錯誤遊戲 | `EscapeThePacific` Mod被分類為TheForest | `ModsViewModel`：從資料夾路徑擷取 `GameId` |
| 9 | 錯誤路徑 | `GetGameFolder()` → `""` → 解析到磁碟機根目錄（如 `E:\`） | 在所有6個呼叫點新增null/空保護 |

#### Debug / Release 建置分離

- **`FileValidator.cs`** — 新檔案 `ModAPI_Shared\Utils\FileValidator.cs`；已註冊在 `ModAPI_Shared.csproj` 中
  - `IsValidSteamExe()` — PE標頭（MZ + PE\0\0）+ 最小 1 MB
  - `IsValidGameExe()` — PE標頭 + 最小 512 KB
  - `IsValidAssemblyDll()` — PE標頭 + .NET CLR中繼資料標頭 + 最小 64 KB
- **`CheckSteam()`** — `#if DEBUG`：僅 `File.Exists()` / `#else`：`FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`：僅 `File.Exists()` / `#else`：`FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`：`File.Copy()` 跳過Cecil / `#else`：完整Cecil解析 + IL修改
- **`ModLib.Create()` 找不到檔案** — `#if DEBUG`：記錄警告，跳過 / `#else`：記錄錯誤，中止

#### Debug 測試

- **`create_dummy_Debug_games.ps1`** — `bin\Debug\` 的PowerShell指令碼；在 `dummy_games\`、`dummy_steam\` 和 `gamefiles\original\` 下為所有5個遊戲建立0位元組佔位檔案 — 無需真實遊戲安裝即可進行完整UI工作流程測試

#### Settings 分頁

- **Steam路徑卡片** — 整合到遊戲安裝路徑卡片中； `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **遊戲路徑面板** — `BuildGamePathsPanel()` 附每個遊戲的可展開卡片；TextBox使用 `HorizontalAlignment=Stretch`
- **全部展開 / 全部摺疊**按鈕
- **視窗置頂**核取方塊（儲存到 `ui.cfg`）
- **Mod/專案清單寬度**滑桿 — 從最小值 `150` 開始；儲存到 `ui.cfg`
- **字型大小** ComboBox — FHD 10–16、4K 10–22、8K 10–28
- **核取方塊同步** — `SettingsCheckboxes.DataContext = SettingsVm`；AutoUpdate / UseSteam / UpdateVersions 現在正確同步
- **`_uiInitialized` 旗標** — 防止WPF啟動期間過早寫入 `ui.cfg`

#### Mods 分頁 — 遊戲啟動驗證

每次點擊Start Game時執行五步驟驗證，與Mod清單狀態無關：

| 步驟 | 檢查內容 | 彈窗 |
|---|---|---|
| 1 | Settings分頁Steam路徑有效（`Steam.exe`存在） | SteamNotFound |
| 2 | `mods/{GameId}/` 資料夾遊戲與Settings設定的遊戲相符 | GameModsMismatch |
| 3 | 至少選擇了一個Mod | NoModSelected |
| 4 | 選擇中無混合遊戲Mod | MixedGameMods |
| 5 | 遊戲路徑已設定 + 可執行檔存在 | GamePathNotSet / GameNotInstalled |

#### Development 分頁 — ModLib 驗證

點擊Mod程式庫重新產生時的三步驟驗證：

| 步驟 | 檢查內容 | 彈窗 |
|---|---|---|
| 1 | Settings分頁Steam路徑有效 | SteamNotFound |
| 2 | 至少存在一個專案 | NoProjectWarning |
| 3 | `App.Game.GamePath` 已設定 | GamePathNotSet |

#### Downloads 分頁
- 除錯字串替換為 `Lang.Downloads.Status.NoDownloads`
- 所有狀態訊息使用一致的內距
- 離線手冊文字已更新支援5個遊戲；透過兩個TextBlock換行

#### 首次設定與遊戲路徑系統
- `FirstSetup.Check()` — `UseSteam`、`AutoUpdate`、`UpdateVersions` 預設值為 `true`
- `FirstSetupDone()` — 為所有5個遊戲建立 `mods/` 和 `projects/` 資料夾
- `SpecifyGamePath` — `GameNameLabel` 顯示哪個遊戲；`NavigateToSettings()` 導航到Settings分頁

#### 新增/更新的語言鍵

| 鍵 | 英文值 |
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
| 自動更新（保持最新版本） | 伺服器端基礎設施不可用 |
| 更新搜尋 | 伺服器端基礎設施不可用 |

### 已移除

| 項目 | 原因 |
|---|---|
| 啟動時 `SpecifyGamePath` 彈窗 | 所有路徑在Settings分頁中設定 |
| 啟動時 `SpecifySteamPath` 彈窗 | Steam路徑在Settings分頁中設定 |
| 登入系統 | 原始伺服器已停止營運（在v2.0.9400中移除） |
| `Portable.System.ValueTuple.dll` | 在Mono 2.0上無法運作（在v2.0.9586中移除） |
| Steam檢查的 `UseSteam` 條件 | Steam現在在啟動遊戲和Mod程式庫重新產生時始終優先驗證 |

---

## 未來版本計劃

| # | 功能 | 描述 |
|---|---|---|
| 1 | ModAPI自動更新 | 自動下載並套用新版本的ModAPI |
| 2 | ModAPI VersionsData表更新 | 遊戲新補丁發布時自動更新VersionsData表 |

---

## v2.0.9600 變更內容

### 新增

- **Downloads分頁**：5個遊戲篩選器 (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome分頁**：新增在最左側位置（索引0）
- **Mods分頁**：3欄配置（WrapPanel → 垂直清單）；自動寬度調整；Mod名稱換行
- **`ModsViewModel`**：按遊戲篩選，`ResolveGame()` 為每個Mod取得正確的 `Game` 實例
- **`Game.cs`**：輕量級建構子 `new Game(config, true)` — 僅識別，不呼叫 `Verify()`
- **建置**：4個遊戲XML檔案在 `ModAPI.csproj` 中註冊，使用 `CopyToOutputDirectory=Always`
- **建置**：清除警告 — CS0168、CS0618、CS0252
- **遊戲XML**：TheForest、Raft、GH DLL清單已修正
- **語言旗標**：13個語言徽章的圖片大小已標準化

### 已移除

| 項目 | 原因 |
|---|---|
| 遊戲XML檔案中的 `extends="GenericUnityGame"` | 導致 `Assembly-CSharp-firstpass.dll` 被錯誤繼承 — 從Subnautica、Raft、EscapeThePacific、GH中移除 |
| Mods分頁中的 `WrapPanel` 配置 | 替換為3欄Grid配置（遊戲篩選器 / Mod清單 / 資訊） |

---

## 各階段主要變更

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
全部5個專案從 .NET 4.5 → 4.8 遷移。

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6、`FluentStyles.xaml`、UnityEngine 存根DLL。

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
3佈景主題系統、`theme.cfg`、視窗拖曳修復、超連結支援。

### Phase 4 *(v2.0.9400)* — Code Cleanup
登入系統移除，更新機制現代化。

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Downloads分頁、Segoe MDL2 Assets圖示、13語言支援。

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`、`CustomAssemblyResolver.cs`、PE標頭修補。

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
黑畫面修復、`ValueTuple` 移除、C# 7.3遊戲內驗證。

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5個遊戲篩選器、3欄Mods分頁、輕量級 `Game` 建構子、XML已註冊。

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML已修正、Steam路徑、遊戲路徑安全、啟動遊戲5步驟驗證、ModLib 3步驟驗證、`FileValidator` PE標頭驗證、`#if DEBUG` 建置分離、`create_dummy_Debug_games.ps1`、輕量級建構子 `ModLibrary` 修復、`SwitchDevGame` GamePath修復、5個遊戲資料夾建立、當機修復。

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Themes分頁新增、10個佈景主題 + 背景材質功能、Themes/資料夾分離、最大化按鈕修復、遊戲路徑展開修復、Versions.xml 4個遊戲更新、路徑重設按鈕、Browse自動儲存、MODAPI_VersionTool。

---

## 版本歷史

### v2.0.9618 — 2026-04-25
新增 MODAPI_VersionTool（獨立 WPF 版本更新工具），StatusBar 版本顯示關聯 App.Version

### v2.0.9617 — 2026-04-24
Settings 標籤頁新增 Steam/遊戲路徑重設按鈕，Browse 自動儲存，重設狀態通過 ui.cfg 標誌保存

### v2.0.9616 — 2026-04-18
Versions.xml 為 4 個遊戲新建/更新（Subnautica、Raft、EscapeThePacific、GH），建立校驗和組成規則，記錄遊戲更新程序

### v2.0.9615 — 2026-04-18
修復 Settings 標籤頁遊戲路徑卡片展開高度精度，防止 UpdateWindowHeight 背景紋理干擾

### v2.0.9614 — 2026-04-18
最大化按鈕基於 WorkArea 手動最大化，儲存和恢復之前的大小/位置

### v2.0.9613 — 2026-04-18
新增 Themes 標籤頁，主題註冊表資料驅動結構，支援 10 種主題，背景紋理功能（壓縮、安全、2 層透明化），ThemeSelector 鎖定覆蓋層，12 個新語言鍵

### v2.0.9612 — 2026-04-18
Themes/ 資料夾分離，主題 XAML 模組化

### v2.0.9611 — 2026-04-18
修復主題切換後 Mod 列表寬度未套用的問題

### v2.0.9610 — 2026-04-13
多遊戲XML修正（GH、Subnautica、EscapeThePacific），Versions.xml已新增，Settings分頁重新設計（Steam路徑、遊戲路徑面板、寬度滑桿、字型大小、核取方塊同步），遊戲路徑null安全（6處），啟動彈窗替換為Settings分頁，Mods分頁5步驟啟動遊戲驗證（Steam始終優先），Dev分頁3步驟ModLib驗證，GameModsMismatch彈窗已新增，輕量級建構子ModLibrary null修復，SwitchDevGame GamePath修復，FileValidator PE標頭驗證（Release），#if DEBUG建置分離（CheckSteam / CheckGamePath / ModLib.Create），create_dummy_Debug_games.ps1，持久化ui.cfg，5鍵字型系統，多處當機修復，語言鍵已更新

### v2.0.9600 — 2026-04-09
5個遊戲篩選器、Mods分頁3欄配置、自動寬度、輕量級 `Game` 建構子、`ModsViewModel` 遊戲篩選、4個XML檔案已註冊、建置警告已清除、Welcome分頁、語言旗標已標準化

### v2.0.9586 — 2026-03-31
黑畫面修復、polyfill最終化、ValueTuple移除、C# 7.3已驗證

### v2.0.9561 — 2026-03-06
C# 7.3支援、PE標頭修補、polyfill管線、組件解析恢復

### v2.0.9552 — 2026-02-25
Downloads分頁、圖示現代化、佈景主題統一、13語言支援

### v2.0.9500
佈景主題系統（Classic/Light/Dark）、Fluent Design UI、SubWindow系統

### v2.0.9400
程式碼清理、登入移除、舊程式碼現代化

### v2.0.9300
建置環境、UnityEngine存根DLL、ModernWpf整合

### v2.0.9200
.NET Framework 4.8 遷移

### v1.x
原版 FluffyFish 發布

---

## 構建要求

| 需求 | 版本 | 備註 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI專案 |
| .NET Framework SDK | 3.5 | 僅BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## 許可證

GNU General Public License v3.0 — 遵循原始許可證。
