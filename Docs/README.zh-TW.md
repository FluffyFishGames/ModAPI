[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md) [![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](README.ko.md) [![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](README.de.md) [![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](README.es.md) [![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.fr.md) [![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](README.pl.md) [![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](README.ru.md) [![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](README.it.md) [![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.jp.md) [![Português](https://img.shields.io/badge/Português-🇵🇹-green)](README.pt.md) [![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.vi.md) [![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.zh-CN.md) [![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.zh-TW.md)

# ModAPI(v1) v2.0.9621 - 20260728

**The Forest 模組管理工具 — 升級版**

> 原作: FluffyFish / Philipp Mohrenstecher (德國 恩格爾斯基興)
> 升級: zzangae (大韓民國)

---

## 概述

ModAPI 是一款用於管理 **5款官方支援遊戲** 模組的桌面應用程式。此升級版包含多遊戲支援、全面重新設計的 Settings 分頁、Steam 路徑設定、持久化 UI 設定、動態字型大小系統、遊戲啟動驗證、Debug/Release 建置分離，以及透過遊戲內測試驗證的大量當機修復。

---

## 支援的遊戲

| 遊戲 | 引擎 | 版本 | Steam ID | 執行檔 |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025修補 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (測試版) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 5 (由 Unity 4 升級) |
| 最新版本 | v1.12 (VR) |
| 最後更新 | 2019年9月11日 — VR支援修補；此後無重大內容更新 |
| 執行檔 | `TheForest.exe` |
| 資料夾 | `TheForest_Data/Managed/` |
| Mods資料夾 | `mods/TheForest/` |
| 專案資料夾 | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 完全支援 |

The Forest 從 Unity 4 升級到 Unity 5，畫面與物理效果都有顯著提升。2019年9月的 VR 修補是最後一次重大更新，此後一直維持穩定的完成狀態，非常適合製作模組。
</details>

<details>
<summary><b>Subnautica</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity (2022年與 Below Zero 整合為統一程式碼庫) |
| 最新版本 | 2025修補 (v18810395) |
| 最後更新 | 2025年8月12日 — 隨行動版發布進行的錯誤修復及效能改進 |
| 執行檔 | `Subnautica.exe` |
| 資料夾 | `Subnautica_Data/Managed/` |
| Mods資料夾 | `mods/Subnautica/` |
| 專案資料夾 | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — 支援 |

Subnautica 最初以 Unity 5 為基礎發布，在2022年底的「Living Large」更新(v2.0)中與 Below Zero 整合了引擎程式碼庫，最佳化與穩定性皆有所提升。備註：續作 *Subnautica 2* 將使用 Unreal Engine 5。

> **v2.0.9610 中重寫 XML**：`XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` 已加入 `copyAssembly`。
</details>

<details>
<summary><b>RAFT</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity |
| 最新版本 | v1.1.02 (測試版) / v1.09 (穩定版) |
| 最後更新 | 2026年3月 — 測試分支中的語音聊天及多人遊戲錯誤修復 |
| 執行檔 | `Raft.exe` |
| 資料夾 | `Raft_Data/Managed/` |
| Mods資料夾 | `mods/Raft/` |
| 專案資料夾 | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — 支援 |
| Versions.xml | `1.1.01` (含校驗和) |

自 v1.0 *The Final Chapter* 官方劇情完結以來，網路程式碼改進及穩定性方面的修補仍持續進行。2026年3月的測試分支更新修復了語音聊天及多人遊戲問題。
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 6 (2025年底從 Unity 2021/2022 遷移) |
| 最新版本 | v0.67.0.0 |
| 最後更新 | 2025年6月26日 — 島嶼分布重新設計及引擎更新；截至2026年熱修復仍在進行中 |
| 執行檔 | `EscapeThePacific.exe` |
| 資料夾 | `EscapeThePacific_Data/Managed/` |
| Mods資料夾 | `mods/EscapeThePacific/` |
| 專案資料夾 | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — 支援 |

2025年底完成了主要系統重新設計及 Unity 6 遷移，實現了更具動態性的環境。遊戲目前仍處於搶先體驗開發階段。

> **v2.0.9610 中重寫 XML**：移除 `extends="GenericUnityGame"`；將 `includeAssembly` 設定為僅 `Assembly-CSharp.dll` — 防止 `Assembly-CSharp-firstpass.dll` 繼承錯誤。
</details>

<details>
<summary><b>Green Hell</b></summary>

| 項目 | 值 |
|---|---|
| 引擎 | Unity 2019 |
| 最新版本 | v2.9.5 |
| 最後更新 | 2026年2月4日 — Steam Deck 最佳化及文字可讀性改進 |
| 執行檔 | `GH.exe` |
| 資料夾 | `GH_Data/Managed/` |
| Mods資料夾 | `mods/GH/` |
| 專案資料夾 | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — 支援 |
| Versions.xml | `2.9.5` (含校驗和) |

在遊戲生命週期中經歷了 Unity 2017 → 2018 → 2019 的開發。2026年2月的熱修復主要著重於 Steam Deck 相容性及 UI 可讀性。

> **v2.0.9610 中重寫 XML**：加入 `AmplifyBloom.dll`、`AmplifyColor.dll`、`AmplifyMotion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`；移除不存在的 `DOTweenPro.dll`。
</details>

---

<details>
<summary><b>架構</b></summary>

### 執行環境分離

| 元件 | 目標 | 執行環境 | 原因 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 桌面應用程式，完全支援最新 API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 共用函式庫 |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **永久固定** — PE 標頭必須顯示為 `v2.0.50727` |
| Mod DLL (使用者) | .NET Framework 4.8 | Game Mono 2.0 (已修補) | 使用 4.8 建置，於 Apply 時修補 PE 標頭 |

### 開發者工具

用於專案管理的獨立 WPF 公用程式。不會發布給終端使用者。

| 工具 | 專案 | 目的 |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | 同時更新 `AssemblyInfo.cs` 及 `App.xaml.cs` 的版本號 |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | 語言檔案管理 — 新增、編輯、停用、內建切換 |

**VersionTool — 版本管理**

只需點擊一次即可更新版本號的獨立 WPF 工具。

- 自動顯示目前版本 (從 `App.xaml.cs` 讀取)
- 輸入新版本後點擊 **Apply Version** 即可同時更新兩個檔案
- 格式驗證：僅接受 `X.X.XXXX` 格式

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`、`AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — 語言系統**

```
resources/langs/langs.json          ← 語言登錄檔 (builtin / active 旗標)
resources/langs/Language.XX.xaml    ← 各語言的翻譯鍵
resources/langs/Language.XX.png     ← 國旗圖片 (36×24，由 flagcdn.com/h24/ 提供)
```

內建切換流程 (Update 按鈕)：
```
builtin: false → true (langs.json)
  → 重寫 CreateDefaultLangsJson() (LangTool\MainWindow.xaml.cs)
  → 登錄 Language.XX.xaml (ModAPI\ModAPI.csproj)
  → 下次建置：語言完全內建，可離線使用
```

### Debug / Release 建置分離

所有檔案驗證及組件處理均透過 `#if DEBUG` / `#else` 依建置設定進行分支處理。

| 位置 | Debug 建置 | Release 建置 |
|---|---|---|
| `CheckSteam()` | 僅 `File.Exists()` — 虛擬檔案也能通過 | `FileValidator.IsValidSteamExe()` — PE 標頭 + 最小 1 MB |
| `CheckGamePath()` | 僅 `File.Exists()` — 虛擬檔案也能通過 | `FileValidator.IsValidAssemblyDll()` — PE 標頭 + CLR 中繼資料 + 最小 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — 略過 Cecil 解析 | 完整的 Mono.Cecil 解析 + IL 修改 + `module.Write()` |
| `ModLib.Create()` — 找不到檔案 | 記錄警告日誌，略過並繼續 | 記錄錯誤日誌，彈出提示後中止 |

**Debug 測試** 使用 `create_dummy_Debug_games.ps1` 在 `bin\Debug\dummy_games\`、`bin\Debug\dummy_steam\`、`bin\Debug\gamefiles\original\` 下產生 0 位元組的虛擬檔案。這些檔案可通過 `File.Exists()` 檢查，無需實際安裝遊戲即可測試完整的 UI 工作流程。

**Release 建置** 套用 `FileValidator` (PE 標頭 + .NET CLR 中繼資料驗證) 拒絕 0 位元組檔案、文字檔案及任意二進位檔案。僅有效的 Windows 執行檔與 .NET 組件才能通過。

### FileValidator — PE 標頭驗證

`ModAPI_Shared\Utils\FileValidator.cs` — 僅在 Release 建置中套用。

| 方法 | 檢查項目 | 最小大小 |
|---|---|---|
| `IsValidSteamExe(path)` | MZ 簽章 + PE\0\0 簽章 | 1 MB |
| `IsValidGameExe(path)` | MZ 簽章 + PE\0\0 簽章 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLR 中繼資料標頭 (資料目錄 #14) | 8 KB |

```
檢查的 PE 標頭配置：
[0x00] 4D 5A          ← "MZ" DOS 簽章
[0x3C] XX XX XX XX   ← PE 標頭位移量 (小端序)
[offset] 50 45 00 00 ← "PE\0\0" 簽章
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR 標頭存在
```

### 組件重新對應流程

```
[Mod 開發者以 .NET 4.8 建置]
  → Mod DLL: PE 標頭 v4.0.30319，mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0 等
  → modModule.RuntimeVersion = "v2.0.50727"
      PE 標頭：v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → PE 標頭驗證通過 ✅  →  參照解析成功 ✅
```

### 組件解析器回退

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← 備份資料夾
2. {ActualGameInstallPath}/{AssemblyPath}        ← 遊戲安裝資料夾 (回退)
```

### C# 7.3 功能支援

| 功能 | 狀態 | 備註 |
|---|---|---|
| 模式比對 (`is`, `switch`) | ✅ | 已透過遊戲內驗證 |
| 字串插值 (`$""`) | ✅ | 已透過遊戲內驗證 |
| `out` 變數內嵌 | ✅ | 已透過遊戲內驗證 |
| `async` / `await` | ✅ | 透過 AsyncBridge + System.Threading 填充函式庫實現 |
| 元組 (`ValueTuple`) | ❌ 硬性限制 | Mono 2.0 `mscorlib` ABI — 無解決方案 |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_ko.md)</b></summary>

自 v2.0.9613 起，主題選擇 UI 已從 Settings 分頁移至專屬的 **Themes 分頁**。新增主題只需在 `App.xaml.cs` 字典中新增一行即可。

| 索引 | ID | 檔案 | 配色 |
|---|---|---|---|
| 0 | `classic` | 僅 `Dictionary.xaml` | 原版 ModAPI 材質背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 淺色調 + 藍色強調色 |
| 2 | `dark` | `FluentStyles.xaml` | 深色調 + 藍色強調色 (預設) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 紅 + 黑 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 深邃宇宙 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮日落 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 深邃海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北歐風 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘色 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉色 |

切換主題時，應用程式會自動重新啟動。(儲存至 `theme.cfg`)

| 主題 | 主題 |
| :---: | :---: |
|**01. Classic 主題**|**02. Light 主題**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Dark 主題**|**04. Diablo 主題**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Nebula 主題**|**06. Sunset 主題**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Ocean 主題**|**08. Nordic 主題**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Citrus 主題**|**10. Bloom 主題**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### 背景材質

在 Themes 分頁的 **背景材質** 卡片中選擇圖片，即可套用為應用程式全域背景。支援格式：`.png` / `.jpg` / `.jpeg`，最大 50MB，4K 解析度以下。圖片會以 JPEG Q75 壓縮，並附帶 16 位元組的魔術標頭，儲存為 `resources\textures\ui_bg\bg.dat` (隱藏屬性)。透過 SHA-256 雜湊進行完整性驗證；偵測到篡改時會自動重設並彈出警告提示。

背景啟用後，UI 透明度會分兩層處理：第 1 層 (MergedDictionaries 疊加) 用於 `{DynamicResource}` 面板，第 2 層 (WalkStyleBackgrounds) 為基於 `{StaticResource}` 的面板套用半透明效果。

### 字型大小系統

| 資源鍵 | 基礎值 | 說明 |
|---|---|---|
| `AppBaseFontSize` | 13 | 一般文字 |
| `AppBaseHeaderFontSize` | 16 | 標題、面板標題 |
| `AppBaseSmallFontSize` | 12 | 輔助標籤 |
| `AppBaseTinyFontSize` | 10 | 提示文字 |
| `AppBaseLargeFontSize` | 20 | 大型顯示文字 |

### 持久化 UI 設定 — `ui.cfg`

| 鍵 | 預設值 | 說明 |
|-----|---------|-------------|
| `ModListWidth` | `150` | Mods 分頁清單寬度 (px) |
| `ProjectListWidth` | `150` | Development 分頁專案清單寬度 (px) |
| `AppFontSize` | `13` | 全域 UI 字型大小 (px) |
| `AlwaysOnTop` | `false` | 視窗永遠置頂 |
| `TexturePath` | *(無)* | 背景材質原始檔名 (僅顯示用) |
| `TextureHash` | *(無)* | 背景材質 SHA-256 雜湊 |
| `TextureActive` | `false` | 背景材質啟用狀態 |
| `GamePathReset_{GameId}` | *(無)* | 遊戲路徑重設旗標 |
| `SteamPathReset` | *(無)* | Steam 路徑重設旗標 |
</details>

<details>
<summary><b>專案結構</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # 持久化 UI 設定
├── theme.cfg                            # 目前主題
├── Windows/
│   ├── MainWindow.xaml / .cs            # 主 UI — 6個分頁、主題、設定、Steam路徑、
│   │                                    #   0位元組下載保護、滑桿防彈跳、靜默設定讀取
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # 遊戲路徑彈出視窗 (動態 GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # 首次執行設定 + 預設值初始化
│       └── (其他14個 SubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Classic 主題
│   ├── FluentStyles.xaml                # Dark 主題
│   ├── FluentStylesLight.xaml           # Light 主題
│   ├── FluentStylesDiablo.xaml          # Diablo 主題
│   ├── FluentStylesNebula.xaml          # Nebula 主題
│   ├── FluentStylesSunset.xaml          # Sunset 主題
│   ├── FluentStylesOcean.xaml           # Ocean 主題
│   ├── FluentStylesNordic.xaml          # Nordic 主題
│   ├── FluentStylesCitrus.xaml          # Citrus 主題
│   └── FluentStylesBloom.xaml           # Bloom 主題
├── Data/
│   ├── Mod.cs                           # Mod檔案載入、LF/CRLF標頭解析、診斷日誌
│   ├── ModLib.cs                        # BaseModLib產生 + 重新對應 (#if DEBUG分離)
│   ├── Models/
│   │   └── ModProject.cs                # 專案建立/建置/套用 + null保護
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   防止損壞的Mod重試
│   │   ├── ModViewModel.cs              # 從資料夾路徑擷取GameId
│   │   ├── ModProjectsViewModel.cs      # DispatcherTimer用的Dispose()
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersions預設值為true
│   └── AssemblyVersionMap.cs            # Mono 2.0組件版本對應 (20個組件)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 以名稱為基礎的解析器 (含快取)
│   └── MonoHelper.cs                    # Mono.Cecil IL輔助工具
├── resources/
│   ├── langs/                           # 13個語言檔案 + langs.json (v2.0.9620中新增LangTool.*鍵)
│   └── textures/ui_bg/
│       └── bg.dat                       # 壓縮及安全處理的背景圖片 (執行時期產生)
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
├── Configurations/
│   └── Configuration.cs                 # 含silent參數的GetPath/GetString/GetInt
├── Data/
│   ├── Game.cs                          # ApplyMods自動備份產生、條件式解析器、
│   │                                    #   遊戲資料夾回退、輕量建構函式 + ModLib初始化修復
│   └── ModLib.cs                        # #if DEBUG分離，IncludeAssemblies/CopyAssemblies用遊戲資料夾回退
└── Utils/
    └── FileValidator.cs                 # PE標頭 + CLR中繼資料驗證 (僅限Release，最小8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # 獨立WPF版本更新工具
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # 版本輸入、Apply按鈕、目前版本顯示
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # 獨立WPF語言管理工具
├── App.xaml / App.xaml.cs              # 語言載入/切換，langtool.cfg
├── MainWindow.xaml / .cs               # 主UI — 語言清單、編輯面板、路徑選擇器
├── AddLanguageDialog.xaml / .cs        # ISO 3166-1國家選擇ComboBox
├── ModApiDialog.xaml / .cs             # ModAPI風格的自訂對話方塊 (資訊/警告/確認/詢問)
├── Models/
│   ├── LanguageEntry.cs                # 語言項目模型 (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # langs.json根模型
│   └── IsoCountry.cs                   # ComboBox用ISO國家模型
└── Helpers/
    ├── LangsJsonHelper.cs              # langs.json的讀寫
    ├── FlagDownloader.cs               # flagcdn.com h24 國旗下載
    ├── XamlGenerator.cs                # Language.XX.xaml的產生/儲存/解析
    ├── MissingKeyDetector.cs           # 以英文為基準偵測缺漏鍵
    ├── IsoCountryList.cs               # ISO 3166-1全196個國家清單 (離線)
    └── BuiltinCodeWriter.cs            # 重寫CreateDefaultLangsJson() + 登錄ModAPI.csproj

bin\Debug\                               # 僅用於Debug測試
├── create_dummy_Debug_games.ps1         # 產生虛擬遊戲/Steam結構
├── dummy_games\{GameId}\               # 虛擬遊戲安裝路徑
├── dummy_steam\Steam.exe               # 虛擬Steam執行檔
└── gamefiles\original\{GameId}\        # ModLib用虛擬備份路徑
```

---

</details>

<details>
<summary><b>安裝與設定</b></summary>

### 步驟1 — 前置需求

| 項目 | 是否必要 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (Windows 11已預先安裝；Windows 10請[下載](https://dotnet.microsoft.com/download/dotnet-framework/net48)) |
| Steam | 必要 — 需於Settings分頁中設定 |
| 至少1款受支援的遊戲 | 必要 — 需於Settings分頁中設定 |

### 步驟2 — 安裝 ModAPI

1. 從 GitHub 下載最新版本
2. 解壓縮至任意資料夾 (例如：`C:\ModAPI\`)
3. 執行 `ModAPI.exe`
4. 首次啟動時會顯示 **Welcome** 畫面 — 完成設定後點擊 **Continue**

### 步驟3 — 設定 Steam 路徑 (Settings 分頁)

1. 前往 **Settings** 分頁
2. 找到 **Steam Installation Path** 項目
3. 點擊 **Browse** → 選擇 `Steam.exe`
4. 點擊 **Save**

### 步驟4 — 設定遊戲路徑 (Settings 分頁)

1. 點擊遊戲卡片標題以展開
2. 點擊 **Browse** → 選擇遊戲根資料夾 (`.exe` 所在位置)
3. 點擊 **Save**

| 遊戲 | 執行檔 | 路徑範例 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### 步驟5 — 下載模組 (Downloads 分頁)

1. 前往 **Downloads** 分頁
2. 於遊戲篩選中選擇遊戲
3. 瀏覽或搜尋模組後點擊 **Download**

> **離線模式**：從 `modapi.survivetheforest.net` 手動下載 `.mod` 檔案，並放置到對應資料夾中：

| 遊戲 | 資料夾 |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### 步驟6 — 套用模組並啟動遊戲 (Mods 分頁)

1. 前往 **Mods** 分頁
2. 於 **Game Filter** 中選擇遊戲 (第0欄)
3. 於 **Mod List** 中勾選要啟用的模組 (第1欄)
4. 點擊 **Start Game**

啟動遊戲前會自動執行以下檢查：

| # | 檢查項目 | 失敗時彈出視窗 |
|---|---|---|
| 1 | Steam 路徑已設定且有效 | SteamNotFound |
| 2 | `mods/` 資料夾中的遊戲與 Settings 分頁中的遊戲相符 | GameModsMismatch |
| 3 | 至少已選擇一個模組 | NoModSelected |
| 4 | 未混合選擇多個遊戲的模組 | MixedGameMods |
| 5 | 遊戲路徑已設定且執行檔存在 | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>分頁概覽</b></summary>

### Welcome 分頁
首次執行設定畫面 (分頁索引0)。設定 AutoUpdate、Steam 連線及 VersionsData 表格偏好設定。之後啟動時會提供社群連結及發行說明。

### Mods 分頁
主要的模組管理工作流程 — 3欄配置：

| 欄 | 內容 |
|---|---|
| 第0欄 | Game Filter — 5款受支援遊戲的單選按鈕 |
| 第1欄 | Mod List — 含版本選擇器及啟用核取方塊的已安裝模組 |
| 第2欄 | Information — 所選模組的詳細資訊、說明、版本歷史 |

### Downloads 分頁
從 `modapi.survivetheforest.net` 瀏覽並下載模組。

- **Game Filter**：TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category Filter**：12個分類 (錯誤修復、平衡調整、作弊、……)
- **Search**：依模組名稱、說明或作者搜尋
- **Offline mode**：顯示全部5款受支援遊戲的資料夾說明

### Development 分頁
模組開發工作流程 — Game Filter 面板 (第0欄) 涵蓋全部5款受支援遊戲。

- 依遊戲建立、建置及套用模組專案
- 語言資源管理
- 含3階段驗證的 ModLib 產生 (Steam → 專案 → 遊戲路徑)
- 透過輕量級 `Game` 建構函式安全切換遊戲 (不呼叫 `Verify()`)

### Themes 分頁
主題選擇及背景材質管理。

- **主題選擇**：10種主題 (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **背景材質**：選擇圖片作為應用程式全域背景 (JPEG壓縮 + 安全處理)
- 背景材質啟用時，主題選擇會被鎖定

### Settings 分頁
集中式設定 — 4列：

| 列 | 內容 |
|---|---|
| 0 | 語言 / 字型大小 / 最大寬度 / Mod List寬度 / Project List寬度 |
| 1 | 保留 VersionsData / 自動更新 / Steam 連線 / 永遠置頂 |
| 2 | Steam Installation Path (文字方塊 + Browse + Save + Reset) |
| 3 | Game Installation Paths — 依遊戲可展開的卡片 (文字方塊 + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (語言管理工具)

用於管理 ModAPI 語言檔案的獨立 WPF 工具，以 `LangTool\MODAPI_LangTool.csproj` 加入方案中。

**位置**：`LangTool\MODAPI_LangTool.csproj`

**核心功能**

| 功能 | 說明 |
|---|---|
| 語言清單 | 顯示 `langs.json` 中所有語言及狀態圖示 (🔒 內建 / 🚫 已停用 / ✅ 已啟用) |
| 新增語言 | 於 ISO 3166-1 ComboBox 中選擇國家 → 從 `flagcdn.com/h24/{iso}.png` 自動下載國旗 → 以英文範本自動產生 `Language.XX.xaml` |
| 編輯語言 | `isoCode` / `langCode` 鎖定；僅於啟用狀態下可編輯 `langName` 及翻譯鍵 |
| 停用 / 啟用 | 切換 `langs.json` 中的 `active` 旗標 — 保留檔案，但從 ModAPI 清單中隱藏 |
| 更新 (內建切換) | 將 `builtin: false` → `true` — 無法復原，需二次確認 — 從原始碼自動重寫 `CreateDefaultLangsJson()`，並於 `ModAPI.csproj` 中登錄 `Language.XX.xaml` |
| 缺漏鍵偵測 | 與英文基準比對 — 顯示缺漏/空白鍵數量及翻譯進度 |
| 內建保護 | `builtin: true` 的語言為唯讀 — 無法編輯、停用或更新 |
| 停用保護 | `active: false` 的語言在重新啟用前為唯讀 |
| 語言 UI | LangTool 本身支援全部13種 ModAPI 語言 — 右上角含國旗的語言選擇器 |
| 路徑儲存 | 將選定的 ModAPI 根路徑儲存至 `langtool.cfg` — 下次啟動時自動載入 |
| 自訂對話方塊 | 所有彈出視窗均使用 ModAPI 風格的深色主題 `ModApiDialog`，而非系統 MessageBox |

**langs.json 結構**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**國旗圖片規則**

```
ISO代碼 (小寫) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                  resources/langs/
```

**Update 按鈕的行為**

對非內建且已啟用的語言點擊 Update 按鈕時：

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — 以目前所有 `builtin: true` 的語言重寫 `CreateDefaultLangsJson()`
3. `ModAPI\ModAPI.csproj` — 登錄 `<Resource Include="resources\langs\Language.XX.xaml" />`
4. 下次建置 — 語言完全內建，可離線使用

**新增的語言鍵** (`Lang.LangTool.*`)

包含 LangTool UI 字串、對話方塊訊息、狀態文字的53個新鍵已加入全部13個語言檔案中。

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (版本更新工具)

只需點擊一次即可更新版本號的獨立 WPF 工具。

**位置**：`VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**功能**
- 自動顯示目前版本 (從 `App.xaml.cs` 讀取)
- 輸入新版本後點擊 **Apply Version** 即可同時更新兩個檔案
- 格式驗證：僅接受 `X.X.XXXX` 格式

**修改的檔案**

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`、`AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**使用方法**
1. 執行 `MODAPI_VersionTool.exe`
2. 輸入新版本 (例如：`2.0.9619`)
3. 點擊 **Apply Version**
4. 於 Visual Studio 中重新建置 ModAPI 方案

**StatusBar 版本顯示**

- `VersionLabel.Text` 現在參照 `App.Version`，而非硬編碼的說明符
- 使用 VersionTool 更新版本並重新建置後，StatusBar 會立即反映更新

---

</details>

<details>
<summary><b>Log</b></summary>

### 日誌系統 — 雙檔案分離 (`ModAPI.log` / `ModAPI.detailed.log`)

以往僅限於 `#if DEBUG` 的開發者專用診斷日誌，導致在最需要排查使用者問題的 Release 建置中無法檢視。現改為雙檔案系統：

| 檔案 | 內容 |
|---|---|
| `ModAPI.log` | 面向使用者的核心日誌 — 與以往格式相同，不會比以前更多 |
| `ModAPI.detailed.log` | 無論 Release/Debug，皆持續記錄所有日誌呼叫 — 用於使用者諮詢時的診斷 |

**`Debug.cs`** — `Log()` 新增了 `detailedOnly` 參數。當為 `true` 時，訊息僅記錄至 `ModAPI.detailed.log`；不再完全移除現有的所有 `#if DEBUG` 區塊，而是切換為此旗標，使 Release 版本也能持續記錄至 detailed 檔案。因此構成四級嚴重程度體系：

| 等級 | 意義 |
|---|---|
| Verbose (`detailedOnly: true`) | 重複性/機械式追蹤 — 依類型、檔案、方法分類 |
| Notice | 人類可讀的流程 — 進度及成功訊息 |
| Warning | 潛在問題，尚未失敗 |
| Error | 確定的失敗 |

**曾占用 `ModAPI.log` 的日誌雜訊來源及切換為 `detailedOnly: true` 的項目：**

| 檔案 | 曾溢出至 `ModAPI.log` 的內容 |
|---|---|
| `ModsViewModel.cs` | 每秒重複的 `FindMods()` 掃描/略過/佇列訊息 |
| `Game.cs` | `UpdateVersions()` 的 TLS/URL 追蹤行、Cecil 類型對應項目 |
| `ModLib.cs` | Cecil 依類型/方法進行的組件處理 (`Validating`、`Processing`、`Changed ... accessibility`) — 一次 Green Hell 模組建置即可產生數萬行，是占用 `ModAPI.log` 容量最多的主要來源 |
| `Mod.cs` | 每次載入模組時傾印整個模組標頭 XML (`configuration.ToString()`) |

**校驗和不符日誌 — 從逐項記錄改為摘要：** `Header.Verify()` 之前對每個不相容的 `InjectInto`/`AddMethod`/`AddField`/`AddClass` 項目都會輸出一行 `Mismatched checksum at "..."`，一個舊模組可能產生數十行。現在 `ModAPI.log` 中僅記錄單一 Warning 等級摘要 (例如：`Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`)。逐項完整清單仍可於 `ModAPI.detailed.log` 中檢視。

---

</details>

<details open>
<summary><b>v2.0.9621 的變更內容</b></summary>

## v2.0.9621 的變更內容

### 新功能

#### 全 Steam 庫自動檢測

現在，如果透過固定的 `SearchPaths` 找不到遊戲，`FindGamePath()` 還會搜尋**系統中已註冊的所有 Steam 庫**（從 `libraryfolders.vdf` 解析一次，會話期間快取）。此功能適用於全部 5 款支援的遊戲，而不僅僅是當前啟用的那一款。

- 新增 `Game.GetSteamLibraryFolders()` —— 解析 `libraryfolders.vdf`，按會話靜態快取
- 由 **Steam 連線** 核取方塊控制：關閉（全新安裝的預設值）→ 全部 5 款遊戲都跳過自動檢測，路徑保持為空直到手動設定。開啟 → 全部 5 款遊戲都透過同一方法一致地進行搜尋。

#### 自動檢測其他遊戲的模組

放錯遊戲資料夾的 `.mod` 檔案（例如把 Green Hell 的模組複製到了 `mods\TheForest\`）現在會被自動檢測出來，而不是悄悄破壞 Apply 操作。

- `Game.CheckModGameCompatibility()`（在 `ApplyMods()` 內部使用）會在注入開始前，驗證模組宣告的每個 `AddMethod`/`AddField`/`InjectInto` 型別是否真實存在於目標遊戲的實際程式集中。不匹配的模組會自動從該次 Apply 中排除；其餘模組照常應用。
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` 在模組載入時執行同樣的輕量級檢查（將程式集位元組讀入記憶體，提取型別名後立即釋放檔案控制代碼）。不匹配的模組會在 Mods 標籤頁中顯示 **⚠ 警告徽章** 及提示，甚至在點選 Apply 之前就能看到。
- 如果有模組被排除和/或最終沒有任何內容被應用，Start Game 會顯示一個合併後的彈窗，而不是多個堆疊的彈窗；如果沒有任何模組最終應用成功，遊戲將不會啟動（`Game.LastAppliedModCount`）。

#### 設定標籤頁 —— 開發者日誌 / 啟動時清除日誌

在 **Steam 連線** 之後、**始終置頂** 之前新增兩個核取方塊：

| 鍵 | 說明 |
|---|---|
| `Lang.Options.Labels.DevLog` | 啟用 `ModAPI.dev.log`（由 `ModAPI.detailed.log` 更名而來）—— 等同於使用 `--dev` 啟動 |
| `Lang.Options.Labels.ClearLogsOnStart` | 每次啟動時清空 `logs\` 資料夾 |

`Debug.ClearLogs()` 會在刪除檔案前先關閉已開啟的日誌流，避免"檔案正在使用"錯誤。

#### 全域性未處理異常日誌

`App.xaml.cs` 現在掛鉤了 `DispatcherUnhandledException`（UI 執行緒）和 `AppDomain.UnhandledException`（後臺執行緒）。以前會導致應用無聲崩潰、日誌中毫無痕跡的異常，現在會在程序退出前記錄下型別、訊息和完整的呼叫堆疊。

---

### 關鍵錯誤修復

| # | 檔案 | 問題 | 修復 |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` 會把明確重置為空字串的路徑解析為 `RootPath` 而不是 `""`，原因是 `Path.GetFullPath(RootPath + 分隔符 + "")` 會被歸約為 `RootPath` | 儲存值為空字串時，現在會在路徑拼接之前直接返回 `""` |
| 2 | `MainWindow.xaml.cs` | "全部"篩選和特定篩選下 Start Game 的驗證順序不一致，有時會在更根本的問題（缺少 Steam/遊戲路徑）之前先彈出模組選擇或遊戲選擇彈窗 | 兩條路徑現在遵循同樣的順序：Steam → 遊戲路徑 → 模組選擇 → 遊戲選擇 |
| 3 | `MainWindow.xaml.cs` | Start Game 收集模組時忽略了當前啟用的遊戲篩選 —— 其他（不可見）遊戲中被勾選的模組仍會被計入，導致彈出錯誤的視窗 | 模組收集現在會遵循當前篩選；只有"全部"才會跨所有遊戲彙總 |
| 4 | `ModsViewModel.cs` | `Mod.Mods` 僅以 `{ModId}-{版本}` 作為鍵，導致兩個不同遊戲資料夾下相同的檔名發生衝突 —— 第二個的 `Load()` 從未被呼叫 | 鍵現在包含 GameId：`{GameId}-{ModId}-{版本}` |
| 5 | `ModsViewModel.cs` | 修復第 4 項後，`UpdateMods()` 仍僅按 ModId 對列表條目分組，導致來自不同遊戲的同名模組被合併為一個條目 —— 當兩者宣告相同版本時，會因 `ArgumentException: An item with the same key has already been added` 而崩潰 | 顯示分組現在也會比較 GameId |
| 6 | `Game.cs` | Green Hell 的 `Versions.xml` 中 `<files>` 列表以不同大小寫（`_Data`/`_data`）重複列出了相同的兩個檔案；`CheckFiles` 是區分大小寫的 `HashSet<string>`，因此兩者都被雜湊，使計算出的校驗和翻倍，造成虛假的完整性錯誤 | `CheckFiles` 現在使用 `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | `ModLib.Create()` 的"移除舊檔案"步驟對被鎖定的 `BaseModLib.dll` 沒有重試保護，`Game.CreateModLibrary()` 也完全沒有異常處理 —— 檔案被鎖定時會導致整個應用在後臺執行緒中崩潰 | 在刪除步驟中新增了 10×500ms 的重試迴圈；`CreateModLibrary()` 現在用 try/catch 包裹呼叫 |
| 8 | `MainWindow.xaml.cs` | 當 `ApplyMods()` 結束時實際應用的模組數為零（例如全部被排除），仍會像真正成功一樣發出完成訊號，導致遊戲在未做任何修改的情況下啟動 | `Game.LastAppliedModCount` 用於區分"未應用任何內容"與"已應用 N 個"；為 0 時跳過啟動 |
| 9 | `MainWindow.xaml.cs` | 無論是更改字型大小、啟動時載入已儲存的大號字型，還是切換到設定標籤頁（`Tabs_SelectionChanged` 是空的），視窗高度都不會重新計算 —— 大字號下最下方的遊戲路徑卡片會被裁切 | 在這三處都新增了高度重新計算 |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` 沒有上限 —— 同時展開全部 5 張遊戲路徑卡片可能使視窗達到整個螢幕大小甚至更大 | 高度現在被限制在 `SystemParameters.WorkArea.Height` 以內 |
| 11 | `MainWindow.xaml.cs` | 無論遊戲是否已安裝，每次啟動都會無條件為全部 5 款遊戲建立 `mods\`/`projects\` 資料夾 | 現在僅為路徑已驗證且可執行檔案存在的遊戲建立資料夾 |
| 12 | `Game.cs` | 如果目標資料夾尚不存在，`UpdateVersions()` 可能無法儲存 `Versions.xml`（此前一直被掩蓋，因為全部 5 個資料夾都已預先提交隨分發包一起釋出） | 儲存前立即透過 `Directory.CreateDirectory()` 建立資料夾 |

---

### 設定標籤頁 —— 首次執行預設值變更

`AutoUpdate`、`UseSteam`（Steam 連線）和 `UpdateVersionsTable`（保持 VersionsData 最新）在全新安裝時現在預設**關閉**（此前預設開啟）。這三項功能的伺服器端實現仍不完整，因此現在改為選擇性開啟（opt-in）—— 與 `DevLog`/`ClearLogsOnStart` 保持一致。

### 介面

- 設定標籤頁核取方塊行（`SettingsCheckboxes`）：從 `StackPanel` 改為 `WrapPanel`，使標籤在字型過大時自動換行而不是被裁切。

### 新增語言鍵（13 種語言）

| 鍵 | 英文值 |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### 修改的檔案

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | 統一 Start Game 驗證順序、按篩選收集模組、合併結果彈窗、由 UseSteam 控制的 4 款遊戲 Steam 庫自動檢測、視窗高度修復（字型大小 / 標籤切換 / 上限） |
| `MainWindow.xaml` | `ModAPI\Windows\` | 設定標籤頁 DevLog/ClearLogsOnStart 核取方塊、`WrapPanel` |
| `Game.cs` | `ModAPI_Shared\Data\` | Steam 庫搜尋、不區分大小寫的 `CheckFiles`、模組相容性檢查（完整版 + 輕量版）、`LastAppliedModCount`/`LastExcludedModsSummary`、`CreateModLibrary()` 異常處理、由 UseSteam 控制的自動檢測 |
| `ModLib.cs` | `ModAPI_Shared\Data\` | 刪除舊檔案時的重試迴圈 |
| `Mod.cs` | `ModAPI_Shared\Data\` | `GameMismatchReason` 欄位 |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | 修復 `GetPath()` 的空路徑錯誤 |
| `Debug.cs` | `ModAPI_Shared\` | 更名為 `ModAPI.dev.log`、`DevMode` 欄位、`ClearLogs()` |
| `App.xaml.cs` | `ModAPI\` | 全域性異常處理器、接入 `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 按遊戲區分的 `Mod.Mods` 鍵、按遊戲分組顯示、不匹配徽章、日誌刷屏抑制 |
| `ModViewModel.cs` | `ModAPI\Data\ViewModels\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\Data\ViewModels\` | `DevLog`/`ClearLogsOnStart`，現有 3 個核取方塊改為選擇性開啟預設值 |
| `FirstSetup.xaml` | `ModAPI\Windows\SubWindows\` | 3 個核取方塊預設值改為關閉 |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\Windows\SubWindows\` | 新增 |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 新增 8 個鍵 |

---

</details>



<details>
<summary><b>v2.0.9620 的變更內容</b></summary>

## v2.0.9620 的變更內容

### 新增 MODAPI_LangTool

新增了用於管理 ModAPI 語言檔案的獨立 WPF 工具 (`LangTool\MODAPI_LangTool.csproj`) — 完整內容請參閱上方的 **Lang Tool** 章節。

---

### 錯誤修復

| # | 檔案 | 問題 | 修復內容 |
|---|---|---|---|
| 1 | `App.xaml.cs` | 於非英文 Windows 系統上，.NET 例外訊息中混入了法語 | 於 `App()` 建構函式開頭固定 `CultureInfo.InvariantCulture` |
| 2 | `Game.cs` | `UpdateVersions()` 中出現 SSL/TLS 錯誤 — 無法建立 SSL/TLS 安全通道 | 透過 `ServicePointManager.SecurityProtocol` 明確設定 TLS 1.2 |
| 3 | `MainWindow.xaml.cs` | 即使路徑已設定，Green Hell 仍顯示 `GamePathNotSet` 彈出視窗 | `App.Game.GamePath` 為空 → 從 `Configuration` 讀取已儲存的路徑 |
| 4 | `ModsViewModel.cs` | 手動放置於 `mods\TheForest\` 中的模組檔案未顯示於清單中 | 新增檔名格式驗證的診斷日誌 |
| 5 | `MainWindow.xaml.cs` | `MixedGameMods` 彈出視窗阻擋了多個遊戲的模組選擇 | 移除阻擋彈出視窗 — 改用 `SelectGameDialog` |

---

### 新功能

#### 遊戲啟動 — 遊戲選擇彈出視窗 (`SelectGameDialog`)

當選擇了不同遊戲的模組，或啟用了 **All** 篩選時，不再阻擋啟動，而是顯示遊戲選擇彈出視窗。

**觸發條件：**
- 選擇 `All` 篩選 + 點擊 Start Game
- 同時啟用了2個以上不同遊戲的模組

**行為：**
- 僅顯示路徑已設定且執行檔存在的遊戲
- 僅套用所選遊戲的模組 — 其他遊戲的模組將被完全忽略
- 彈出視窗關閉後，將單選按鈕同步至所選遊戲 (`SyncModGameFilterRadioButton`)

**新增檔案**：`ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### 遊戲完整性驗證 (僅限 Release 建置，`#if !DEBUG`)

每次遊戲啟動前都會執行3階段完整性檢查：

| 層級 | 方法 | 失敗時 |
|---|---|---|
| A — PE標頭 | `FileValidator.IsValidGameExe()` | 阻擋 + `GameExeCorrupted` 彈出視窗 |
| B — 組件校驗和 | MD5 → 與 `Versions.xml` 比對 | 阻擋 + `GameAssemblyTampered` 彈出視窗 |
| C — 數位簽章 | `HasDigitalSignature()` | 警告 + 使用者選擇 (`GameIntegrityWarning`) |

**新增檔案**：`ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**新增至 `FileValidator.cs` 的新方法**：
- `ComputeAssemblyChecksum(managedFolder)` — Assembly-CSharp.dll 的 MD5 雜湊 (若存在firstpass則包含)
- `HasDigitalSignature(path)` — 驗證 Authenticode 簽章

---

### 新增診斷日誌

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12項，Release + Debug)

| # | 階段 | 類型 | 內容 |
|---|---|---|---|
| 1 | TLS設定 | Notice | 變更前後的協定 |
| 2 | 下載開始 | Notice | 伺服器清單 |
| 3 | URL嘗試 | Notice | 正在嘗試的各個URL |
| 4 | 下載成功 | Notice | URL、回應長度、使用的協定 |
| 5 | WebException | Error | URL、HTTP狀態、協定、詳細內容 |
| 6 | 其他例外 | Error | URL、例外類型、詳細內容 |
| 7 | 下載完成 | Notice | 成功數 / 總伺服器數 |
| 8 | 解析成功 | Notice | 變更前後的檔案及版本數 |
| 9 | 解析失敗 | Error | 例外類型及詳細內容 |
| 10 | 儲存成功 | Notice | 儲存路徑、總版本/檔案數 |
| 11 | 儲存失敗 | Error | 路徑、例外類型、詳細內容 |
| 12 | 無回應 | Error | 嘗試的伺服器、協定 |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7項，僅限 `#if DEBUG`)

| # | 情況 | 類型 | 內容 |
|---|---|---|---|
| 1 | 掃描開始 | Notice | Mods資料夾路徑、偵測到的總檔案數 |
| 2 | 已載入 | Notice | 檔名 |
| 3 | 非.mod檔案 | Notice | 檔名 |
| 4 | 樣式比對成功 | Notice | 加入佇列的檔名 |
| 5 | 樣式比對失敗 | Warning | 檔名 + 原因 + 預期格式 |
| 6 | 掃描完成 | Notice | 佇列新增數 / 總檔案數 |
| 7 | 例外 | Error | 例外詳細內容 |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10項，Release + Debug)

| # | 情況 | 類型 | 內容 |
|---|---|---|---|
| 1 | 彈出視窗條件 | Notice | 目前篩選、所選遊戲ID、needGameSelect |
| 2 | 候選遊戲 | Notice | 彈出視窗候選ID清單 |
| 3 | 路徑未設定 | Notice | 略過遊戲 — 路徑未設定 |
| 4 | 不在Configuration中 | Notice | 略過遊戲 — 不在Configuration.Games中 |
| 5 | 已確認安裝 | Notice | 遊戲 + 執行檔路徑 |
| 6 | 無執行檔 | Warning | 略過遊戲 — 無執行檔 |
| 7 | 無已安裝遊戲 | Error | 候選數為0 → GamePathNotSet |
| 8 | 自動選擇 | Notice | 單一候選自動選擇 |
| 9 | 使用者取消 | Notice | SelectGameDialog已取消 |
| 10 | 遊戲選擇+模組 | Notice | 所選遊戲、收集的模組數/清單 |

---

### 開發者 / 使用者日誌分離 (`#if DEBUG`)

| 檔案 | 日誌 | 原因 |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | 每秒重複 — 佔全部日誌的81% |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | 開發者專用內部細節資訊 |

保留於 Release 日誌中：下載成功/失敗、解析/儲存結果、樣式比對失敗、例外、完整性檢查結果。

---

### 版本表更新 — 架構

#### 設計意圖

```
遊戲收到Steam更新
  → Assembly-CSharp.dll發生變化
  → ModAPI於Versions.xml中檢查已知的校驗和
  → 若未找到 → 從伺服器下載最新的Versions.xml
  → 無需重新安裝ModAPI即可自動登錄新版本
```

#### 連接結構

```
Settings分頁 → KeepVersionsData核取方塊
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → 呼叫UpdateVersions()
      → 從VersionUpdateDomains[]下載Versions.xml
      → 覆寫本機的configs\games\{GameId}\Versions.xml
```

#### GitHub Raw URL 整合

不再僅依賴 `modapi.survivetheforest.net`，為便於直接管理，改用 GitHub Raw URL 作為主要來源：

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — 直接管理，優先順序1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // 舊版伺服器 — 回退，優先順序2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| 項目 | 詳細內容 |
|---|---|
| 預設 | GitHub Raw URL — 推送後立即生效 |
| 回退 | 舊版伺服器 — 當GitHub無法使用時 |
| 路徑 | 儲存庫中的 `ModAPI/configs/games/{GameId}/Versions.xml` |
| 修改的檔案 | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Versions.xml 更新

| 遊戲 | 檔案 | 變更內容 |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | 校驗和修復 (錯誤的SHA-256大寫) — 為 `2.9.5b114117` 設定正確的MD5 |
| The Forest | `configs\games\TheForest\Versions.xml` | 新增 `1.12` (BuildID: 20229486) — 128字元MD5校驗和 |

---

### 新增語言鍵 (13種語言)

| 鍵 | 英文值 |
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
| `Lang.Savegames.*` (133個鍵) | 為12種語言新增英文值 (DE已翻譯) |

---

### 修改的檔案

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | 啟動時固定 `CultureInfo.InvariantCulture` |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog、完整性檢查、移除MixedGameMods、單選按鈕同步、10項日誌 |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | 新增 |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | 新增 |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 檔名診斷日誌、#if DEBUG分離 |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2、UpdateVersions 12項日誌、GitHub URL、#if DEBUG分離 |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`、`HasDigitalSignature()` |
| 13個 `Language.XX.xaml` | `ModAPI\resources\langs\` | 10個新鍵 + 133個Savegames鍵 (共515個，所有語言一致) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | 校驗和修復 |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | 新增 `1.12` |
| `LangTool\` (13個檔案) | 方案根目錄 | 新增 |
| `ModAPI.sln` | 方案根目錄 | 登錄LangTool |

---

### 附加修復及日誌系統全面改造 (2026-06-21)

#### StartGame 驗證 — 全面重新設計

將驗證順序修正為嚴格的3個步驟，並修復了遊戲選擇彈出視窗，使其無論路徑是否已設定，皆能反映所有已啟用模組所屬的遊戲。

| 步驟 | 檢查項目 | 失敗時彈出視窗 |
|---|---|---|
| 1 | 確認Steam已安裝 | SteamNotFound |
| 2 | 所選遊戲的路徑已設定 + 執行檔存在 | GamePathNotSet |
| 3 | 所選遊戲中至少存在1個已啟用的模組 | NoModSelected |

- **選擇All篩選 / 多遊戲模組選擇時** → 彈出視窗會顯示所有存在已啟用模組的遊戲，**包括路徑未設定的遊戲** — 選擇未設定路徑的遊戲時不會靜默從清單消失或出現無關錯誤，而是準確顯示 `GamePathNotSet`
- **選擇特定遊戲篩選時** → 對該遊戲直接以相同的1→2→3順序執行路徑/模組檢查

#### 主要錯誤修復

| # | 檔案 | 問題 | 修復內容 |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` 會合併所有成功回應的伺服器 (GitHub + 舊版)，當兩者皆成功時校驗和會加倍損壞(64字元→128字元) — 導致誤觸發 `GameAssemblyTampered` 阻擋 | 僅解析最先成功的伺服器回應，一旦有一處成功便不再嘗試其他伺服器 |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` 使用的是 `App.Game` (目前啟用的篩選) 而非模組自身所屬的遊戲 — 於TheForest處於啟用狀態下刪除Green Hell模組時，會搜尋錯誤的Managed資料夾，導致刪除靜默失敗 | 現在從 `mod.Game` (模組實際所屬的遊戲執行個體) 尋找已部署的DLL路徑，若 `GamePath` 為空則從 `Configuration` 補充 |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | 重新下載已刪除的模組時，啟用徽章會以開啟狀態還原 — 刪除時未清除持久儲存的 `Selected`/`Version` 鍵或記憶體中的ViewModel快取 | 於 `Configuration.cs` 中新增 `RemoveKey()` / `RemoveKeysWithPrefix()`；`DeleteMod_Click` 於刪除時強制設定 `ModViewModel.Selected = false` 並移除所有 `Mods.{GameId}.{ModId}.*` 鍵 |
| 4 | `ModsViewModel.cs` | 於選擇了特定遊戲篩選("All"以外)的狀態下刪除模組時，看起來會一直殘留於清單中，直到切換到All再切回來 | 檔案刪除偵測輪詢迴圈中，`_Mods.RemoveAt()` 之後缺少 `FilteredMods` 變更通知 — 現已修復為每次實際移除模組時都會觸發通知 |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | 產生/顯示無簽章警告彈出視窗時若發生例外，ModAPI可能會在沒有任何日誌記錄的情況下靜默強制結束 | 將彈出視窗的產生/顯示及訊息格式化用try-catch包裹，失敗時記錄原因並讓使用者可以安全繼續 (因為無簽章並非阻擋的理由，而只是建議事項) |

#### 數位簽章警告 — 訊息明確化

`GameNoSignature` 的文案現在會明確指出具體的遊戲名稱，並清楚說明無簽章並非篡改的可能性，而是**獨立遊戲中常見的情況，不會影響遊戲進程**。已於全部13個語言檔案中更新為包含遊戲顯示名稱 (例如 "The Forest"、"Green Hell") 的 `{0}` 佔位符。

#### 日誌系統 — 雙檔案分離

將原本被 `#if DEBUG` 包裹的診斷日誌切換為 `detailedOnly` 旗標，分離為 `ModAPI.log` (面向使用者) 與 `ModAPI.detailed.log` (持續完整記錄) — 完整內容請參閱上方的 **Log** 章節。

#### 修改的檔案 (附加部分)

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | StartGame驗證重新設計、DeleteMod_Click遊戲執行個體修復、GameIntegrityWarning的try-catch、遊戲顯示名稱對應 |
| `Game.cs` | `ModAPI_Shared\Data\` | UpdateVersions單一回應修復 |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`、`RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 刪除時的`FilteredMods`變更通知、`#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25處呼叫) |
| `Mod.cs` | `ModAPI\Data\` | 將標頭XML傾印移至detailedOnly，校驗和不符摘要化 |
| `Debug.cs` | `ModAPI_Shared\` | `detailedOnly`參數、雙檔案記錄、4級日誌指南註解 |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | `{0}`遊戲名稱佔位符、try-catch安全處理 |
| 13個 `Language.XX.xaml` | `ModAPI\resources\langs\` | 使用遊戲名稱佔位符重寫 `GameNoSignature.Text` |

---


</details>

<details>
<summary><b>v2.0.9619 的變更內容</b></summary>

### 錯誤修復

- **空備份資料夾導致模組套用中斷**：`gamefiles\original\` 為空 → 於讀取組件之前從遊戲安裝路徑自動產生備份
- **遊戲DLL檔案鎖定 (IOException)**：備份存在時，組件解析器會有條件地排除遊戲資料夾 — 防止 `DirectoryCopy` 期間Cecil持有檔案鎖定
- **損壞模組的無限重試迴圈**：標頭損壞的 `.mod` 檔案會引發每秒重新掃描迴圈 — 現已登錄至 `LoadedFiles` 以防止重複掃描
- **拒絕LF換行的模組檔案**：標頭剖析器的 `EndsWith("</Mod>\r")` 於Unix風格的 `.mod` 檔案上失敗 — 現使用 `TrimEnd` 同時處理CRLF與LF
- **小型DLL驗證失敗**：`Assembly-UnityScript-firstpass.dll` (21 KB) 被 `FileValidator` 拒絕 — 將最小組件大小從64 KB降低至8 KB
- **不必要的WARNING日誌**：未設定的遊戲路徑及首次執行設定鍵產生雜訊 — 為 `GetPath`/`GetString`/`GetInt` 新增了 `silent` 參數

### 改進事項

- **0位元組下載偵測**：當伺服器回傳空的 `.mod` 檔案時彈出通知 + 清理暫存檔案 (`Lang.Windows.DownloadEmpty`)
- **滑桿儲存防彈跳**：`ModListWidth` / `ProjectListWidth` 不再隨每次像素變化儲存，而是於拖曳結束後500ms才儲存一次至 `ui.cfg`
- **條件式遊戲資料夾產生**：`mods/` 及 `projects/` 資料夾僅於已設定路徑的遊戲中建立 — 不會無條件為全部5款遊戲建立
- **標頭解析診斷日誌**：`.mod` 檔案解析失敗時顯示行數及內容預覽 (便於排查問題)

### 新增語言鍵 (13種語言)

| 鍵 | 英文值 |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### 修改的檔案

| 檔案 | 路徑 | 變更內容 |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | 自動備份產生、條件式解析器、遊戲資料夾回退 |
| `ModLib.cs` | `ModAPI_Shared\Data\` | IncludeAssemblies/CopyAssemblies用遊戲資料夾回退 |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | GetPath/GetString/GetInt新增 `silent` 參數 |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | 0位元組下載保護、滑桿防彈跳、靜默設定讀取、條件式資料夾產生 |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 防止損壞模組重試 |
| `Mod.cs` | `ModAPI\Data\` | LF/CRLF標頭解析、診斷日誌 |
| 13個 `Language.XX.xaml` | `resources\langs\` | `DownloadEmpty` 彈出視窗鍵 |

---

</details>

<details>
<summary><b>v2.0.9618 的變更內容</b></summary>


### 新增 MODAPI_VersionTool

新增了只需點擊一次即可更新版本號的獨立 WPF 工具 (`VersionTool\MODAPI_VersionTool.csproj`) — 完整內容請參閱上方的 **Version Tool** 章節。

- `VersionLabel.Text` 現在參照 `App.Version`，而非硬編碼的 `Version.Descriptor`，因此重新建置後會立即反映至 StatusBar。

---

</details>

<details>
<summary><b>v2.0.9617 的變更內容</b></summary>


### Settings 分頁 — 新增路徑重設按鈕

Steam 安裝路徑及各遊戲安裝路徑列皆新增了 **Reset** 按鈕。

**Steam路徑列**
```
[TextBox] [Browse] [Save] [Reset]
```

**遊戲路徑列 (依遊戲)**
```
[TextBox] [Browse] [Save] [Reset]
```

**重設行為**
- 立即清空路徑文字方塊
- 將重設旗標儲存至 `ui.cfg` (`GamePathReset_{GameId}=1`、`SteamPathReset=1`)
- 重新啟動後文字方塊仍保持空白
- 繞過Configuration XML不儲存空字串的問題

**Browse自動儲存**
- 之前：Browse後需另外點擊Save按鈕
- 現在：選擇檔案後自動儲存 — 切換至Mods分頁後仍會保留

**新增語言鍵**

| 鍵 | 值 |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>v2.0.9616 的變更內容</b></summary>

### Versions.xml — 新增/更新4款遊戲

| 遊戲 | 檔案路徑 | BuildID | 備註 |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 新建 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | 校驗和更新 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 新建 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | 校驗和更新 |

### 校驗和構成規則

校驗和格式依各遊戲是否存在 `Assembly-CSharp-firstpass.dll` 而不同。

| 遊戲 | firstpass.dll | 校驗和格式 |
|---|---|---|
| GH | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 連接 (64字元) |
| Subnautica | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 連接 (64字元) |
| EscapeThePacific | ✅ 存在 | `firstpass MD5` + `Assembly-CSharp MD5` 連接 (64字元) |
| Raft | ❌ 不存在 | 僅 `Assembly-CSharp MD5` (32字元) |

### 遊戲更新時的 Versions.xml 更新流程

於不刪除現有項目的情況下新增新的 `<version>` 項目。

**步驟1 — 尋找新的BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| 遊戲 | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**步驟2 — 擷取新的校驗和**
```powershell
# 存在firstpass.dll的遊戲 (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → 依順序連接兩個Hash值 (firstpass在前)

# 不存在firstpass.dll的遊戲 (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**步驟3 — 於Versions.xml中新增項目**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>v2.0.9615 的變更內容</b></summary>

### 修復 Settings 分頁遊戲路徑展開問題

- **卡片展開高度**：展開遊戲路徑卡片時，視窗下方恰好依輸入欄位的高度精確增長
- **`UpdateWindowHeight()` 改進**：於測量 `SizeToContent.Height` 前呼叫 `UpdateLayout()`；背景材質啟用時，將 `TextureLayer1` 暫時設為 `Collapsed`，以防止4K圖片原始尺寸影響高度計算
- **內部Grid列修復**：將遊戲路徑面板內部Grid的最後一列從 `Height="*"` 改為 `Height="Auto"` — 移除不必要的底部空白

---

</details>

<details>
<summary><b>v2.0.9614 的變更內容</b></summary>

### 修復最大化按鈕行為

- **最大化**：使用 `SystemParameters.WorkArea` 進行手動最大化，而非 `WindowState.Maximized` — 精確符合目前螢幕解析度，不與工作列重疊
- **還原**：最大化前儲存 `Left`、`Top`、`Width`、`Height`、`MaxWidth`，點擊還原按鈕時恢復
- **`MaxWidth` 處理**：最大化時設為 `∞`，還原正常大小時恢復為儲存的值

---

</details>

<details>
<summary><b>v2.0.9613 的變更內容</b></summary>

### 新增 Themes 分頁

分頁順序已變更為：

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

主題選擇UI已從Settings分頁移至專屬的 **Themes 分頁**。
圖示：Segoe MDL2 Assets `&#xE790;` (調色盤)

### 主題登錄檔 (資料驅動結構)

現在新增主題只需於 `App.xaml.cs` 字典中新增 **一行** 即可完成。
所有 switch 陳述式皆已移除 — 無需修改其他位置的程式碼。

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

`ThemeSelector` 的ComboBox項目由 `ThemeIds` 迴圈自動產生。
語言鍵規則：`Lang.Options.Theme.{PascalCase}` (例如：`Lang.Options.Theme.Nebula`)

### 支援的主題

| 索引 | ID | 檔案 | 配色 |
|---|---|---|---|
| 0 | `classic` | 僅 `Dictionary.xaml` | 原版 ModAPI 材質背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 淺色調 + 藍色強調色 |
| 2 | `dark` | `FluentStyles.xaml` | 深色調 + 藍色強調色 (預設) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 紅 + 黑 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 深邃宇宙 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明亮日落 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 深邃海洋 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明亮北歐風 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明亮柑橘色 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明亮花卉色 |

切換主題時，應用程式會自動重新啟動。(儲存至 `theme.cfg`)

### 背景材質功能

於Themes分頁的 **背景材質** 卡片中選擇圖片，即可套用為應用程式全域背景。無論選擇哪種主題皆可使用。

**支援的輸入格式**：`.png` / `.jpg` / `.jpeg`，最大50MB，4K解析度以下

**圖片處理流程**

```
使用者選擇的圖片 (.png / .jpg / .jpeg，最大50MB，4K以下)
  ↓
JPEG Q75壓縮 (記憶體緩衝區)
  ↓
插入16位元組魔術標頭
  "MODAPI" + "BG" + 版本 + 填充 (FF 00 FE 00)
  ↓
儲存為resources\textures\ui_bg\bg.dat (隱藏屬性)
  ↓
SHA-256雜湊 → 儲存至ui.cfg作為TextureHash
```

**安全層**

| 層級 | 方法 | 效果 |
|---|---|---|
| 魔術標頭 | 於JPEG簽章(FF D8 FF)前新增16位元組 | 外部檢視器無法辨識檔案 |
| 隱藏屬性 | `FileAttributes.Hidden` | 檔案總管中預設隱藏 |
| SHA-256完整性 | 載入時驗證雜湊 | 偵測到篡改時自動重設 + 警告彈出視窗 |

**篡改偵測行為**
1. 刪除 `bg.dat`
2. 重設 `ui.cfg` 中的 `TexturePath`、`TextureHash`、`TextureActive` 鍵
3. 重設文字方塊及切換開關
4. 顯示 `Lang.Windows.TextureTampered` 彈出視窗

**ui.cfg 鍵**

| 鍵 | 值 | 說明 |
|---|---|---|
| `TexturePath` | 檔名 (僅顯示用) | 文字方塊中顯示的原始檔名 |
| `TextureHash` | SHA-256十六進位 | 完整性驗證雜湊 |
| `TextureActive` | `true` / `false` | 啟用狀態 |

**透明度處理**

背景圖片啟用後，UI背景會分兩層處理。

- **第1層 — MergedDictionaries疊加**：參照 `{DynamicResource FluentBgBrush}` 等的面板會自動變透明。停用時透過單次 `Remove()` 呼叫即可還原。

  目標鍵：`FluentBgBrush`、`FluentBgSecondaryBrush`、`FluentBgTertiaryBrush`、`FluentSurfaceBrush`、`FluentCardBrush`、`FluentTabBarBrush`、`FluentBorderBrush`

- **第2層 — 視覺樹狀結構走訪 (`WalkStyleBackgrounds`)**：Fluent主題中的 `{StaticResource}` 元素不受第1層影響，因此直接走訪視覺樹狀結構，依原始顏色套用半透明筆刷。

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=完全透明，255=不透明 → 100 ≈ 39%不透明
  ```

  處理對象：`Panel` (Grid除外)、`Border`、`ListBox` / `ListView`

  排除對象：`Grid` (保留背景，走訪子元素)、`TabPanel` (標籤標頭保護)、`ButtonBase` / `ComboBox`、`Collapsed`元素

  還原：樣式Setter來源 → `ClearValue()`，XAML本機值來源 → 直接還原原始筆刷

**分頁切換**

由於WPF的TabControl會延遲載入分頁內容，分頁切換時會以 `ContextIdle` 優先順序重新執行 `WalkStyleBackgrounds(this)`。已處理的元素會透過 `ContainsKey` 檢查而跳過。

**ThemeSelector鎖定**

背景材質啟用後，主題選擇器上方會顯示 `ThemeSelectorOverlay` 邊框，阻擋互動。

- XAML：`ThemeSelectorOverlay` 邊框新增於ThemeSelector上方 (`IsHitTestVisible=True`)
- 啟用時：`ThemeSelectorOverlay.Visibility = Visible`
- 停用時：`ThemeSelectorOverlay.Visibility = Collapsed`
- `_textureActive` 旗標同時保護 `ThemeSelector_SelectionChanged`

**UI狀態流程**

```
選擇圖片 (Browse)
  → 產生bg.dat → 解鎖切換開關 → 自動啟用 → 顯示TextureLayer1
  → SaveAndClearBrushes() → 顯示ThemeSelectorOverlay

停用切換開關
  → RestoreThemeState() → RestoreBrushes() → 隱藏ThemeSelectorOverlay
  → 隱藏TextureLayer1

點擊Clear按鈕
  → 刪除bg.dat → 鎖定切換開關 → 隱藏TextureLayer1 → 還原筆刷
  → GC.Collect() (釋放4K圖片記憶體)
```

**新增語言鍵**

| 鍵 | 說明 |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7個新增主題名稱 |
| `Lang.Options.Labels.TextureBackground` | 背景材質標籤 |
| `Lang.Options.Labels.TextureEnable` | 啟用標籤 |
| `Lang.Options.Labels.TextureClear` | Clear按鈕 |
| `Lang.Windows.TextureTooLarge` | 檔案大小超過限制警告 |
| `Lang.Windows.TextureTampered` | 篡改偵測警告 |

**檔案結構**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Themes分頁、ThemeSelectorOverlay、TextureLayer1
│   └── MainWindow.xaml.cs         # 主題 & 材質邏輯
├── Themes\
│   ├── Dictionary.xaml            # Classic主題
│   ├── FluentStyles.xaml          # Dark主題
│   ├── FluentStylesLight.xaml     # Light主題
│   ├── FluentStylesDiablo.xaml    # Diablo主題
│   ├── FluentStylesNebula.xaml    # Nebula主題
│   ├── FluentStylesSunset.xaml    # Sunset主題
│   ├── FluentStylesOcean.xaml     # Ocean主題
│   ├── FluentStylesNordic.xaml    # Nordic主題
│   ├── FluentStylesCitrus.xaml    # Citrus主題
│   └── FluentStylesBloom.xaml     # Bloom主題
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # 壓縮及安全處理的背景圖片 (執行時期產生)
```

**已知設計限制**

| 項目 | 詳細內容 |
|---|---|
| ComboBox的`IsEnabled=false` | 引發 `ElementNotEnabledException` 當機 → 改用 `IsHitTestVisible` 疊加方式 |
| 直接取代 `MergedDictionaries` 鍵 | 版面配置過程中當機 → 僅使用 `Add`/`Remove` 模式 |
| 覆寫隱藏檔案 | `Access Denied` → 寫入前需重設為 `FileAttributes.Normal` |
| `{StaticResource}` 背景 | 不受第1層影響 → 需要WalkStyleBackgrounds (第2層) |

---

</details>

<details>
<summary><b>v2.0.9612 的變更內容</b></summary>

### 主題模組分離

- **新增 `Themes/` 資料夾**：將 `Dictionary.xaml`、`FluentStyles.xaml`、`FluentStylesLight.xaml`、`FluentStylesClassic.xaml` 移至 `ModAPI\Themes\`
- **`App.xaml.cs`**：`ApplyTheme()` — Classic主題僅使用 `Dictionary.xaml`；Light/Dark/其他Fluent主題載入對應的XAML
- **`ModAPI.csproj`**：將主題XAML路徑更新為 `Themes\` 子目錄；登錄 `FluentStylesClassic.xaml`

---

</details>

<details>
<summary><b>v2.0.9611 的變更內容</b></summary>

### 錯誤修復

- **主題切換後Mod List寬度未套用**：修復了於Light/Dark主題切換及重新啟動後Mod List寬度未套用的問題 — 於 `InitModListWidth()` 中新增了 `ApplyModListWidth(width)` 呼叫

---

</details>

<details>
<summary><b>v2.0.9610 的變更內容</b></summary>

### 新增內容

#### 遊戲XML & Versions設定

| # | 檔案 | 變更內容 |
|---|------|--------|
| 1 | `GH.xml` | 全面重寫 — 移除不存在的 `DOTweenPro.dll`；新增 `AmplifyBloom/Color/Motion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | 全面重寫 — 移除 `extends="GenericUnityGame"`；新增 `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | 全面重寫 — 移除 `extends="GenericUnityGame"`；`includeAssembly` → 僅 `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | 建立 — 含校驗和的版本 `1.1.01` |
| 5 | `GH/Versions.xml` | 建立 — 含校驗和的版本 `2.9.5` |
| 6 | `Subnautica/Versions.xml` | 建立 — 無校驗和 (更新過於頻繁) |

#### 嚴重錯誤修復

| # | 類型 | 問題 | 修復內容 |
|---|------|-------|-----|
| 1 | 掛起 | `extends="GenericUnityGame"` 導致繼承 `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` 掛起 | 從所有非TheForest XML中移除 `extends` |
| 2 | 當機 | 套用Subnautica時出現 `ResolutionException: XGamingRuntime.XUserGamertagComponent` | 將 `XGamingRuntime.dll`、`XblPCSandbox.dll` 新增至 `copyAssembly` |
| 3 | 當機 | 備份產生後，`copyAssembly` 中新增的DLL導致解析器失敗 | `Game.cs`：將實際安裝資料夾新增為解析器回退路徑 |
| 4 | 當機 | `CreateModLibrary` 與 `ApplyMods` 之間出現 `BaseModLib.dll` 檔案鎖定 `IOException` | 重試迴圈：最多10次×500ms讀取 + 最多30次×500ms存在等待 |
| 5 | 當機 | `NullReferenceException` — `typesMap` 項目的Value為null (遊戲未安裝) | 新增 `if (entry.Value == null) continue` |
| 6 | 當機 | `NullReferenceException` — 輕量級 `Game` 建構函式中缺少 `ModLibrary = new ModLib(this)` → `CreateModLibrary()` 當機 | 於輕量級建構函式中新增 `ModLibrary = new ModLib(this)` |
| 7 | 當機 | `SwitchDevGame()` — 輕量級建構函式後 `App.Game.GamePath` 為空 → `CreateModLibrary` 當機 | 於輕量級建構函式後設定 `App.Game.GamePath = savedPath` |
| 8 | 錯誤的遊戲 | `EscapeThePacific` 的模組被歸類為TheForest | `ModsViewModel`：從資料夾路徑擷取 `GameId` |
| 9 | 錯誤的路徑 | `GetGameFolder()` → `""` → 被解析為磁碟機根目錄 (例如：`E:\`) | 於全部6處呼叫位置新增null/空值保護 |

#### Debug / Release 建置分離

- **`FileValidator.cs`** — 新增檔案 `ModAPI_Shared\Utils\FileValidator.cs`；登錄至 `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — PE標頭 (MZ + PE\0\0) + 最小1 MB
  - `IsValidGameExe()` — PE標頭 + 最小512 KB
  - `IsValidAssemblyDll()` — PE標頭 + .NET CLR中繼資料標頭 + 最小8 KB
- **`CheckSteam()`** — `#if DEBUG`：僅 `File.Exists()` / `#else`：`FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`：僅 `File.Exists()` / `#else`：`FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`：略過Cecil的 `File.Copy()` / `#else`：完整Cecil解析 + IL修改
- **`ModLib.Create()` 找不到檔案** — `#if DEBUG`：記錄警告日誌並略過 / `#else`：記錄錯誤日誌並中止

#### Debug測試

- **`create_dummy_Debug_games.ps1`** — 用於 `bin\Debug\` 的PowerShell指令碼；為全部5款遊戲於 `dummy_games\`、`dummy_steam\`、`gamefiles\original\` 下產生0位元組佔位檔案 — 無需實際安裝遊戲即可測試完整UI工作流程

#### Settings分頁

- **Steam路徑卡片** — 整合至Game Installation Paths卡片；`InitSteamPath()`、`SteamBrowse_Click()`、`SteamSave_Click()`
- **遊戲路徑面板** — 含各遊戲可展開卡片的 `BuildGamePathsPanel()`；文字方塊使用 `HorizontalAlignment=Stretch`
- **Expand All / Collapse All** 按鈕
- **AlwaysOnTop** 核取方塊 (儲存至 `ui.cfg`)
- **Mod/Project List寬度** 滑桿 — 從最小值 `150` 開始；儲存至 `ui.cfg`
- **字型大小** ComboBox — FHD 10~16，4K 10~22，8K 10~28
- **核取方塊同步** — `SettingsCheckboxes.DataContext = SettingsVm`；AutoUpdate / UseSteam / UpdateVersions現已正確同步
- **`_uiInitialized` 旗標** — 防止WPF啟動過程中過早寫入 `ui.cfg`

#### Mods分頁 — 遊戲啟動驗證

每次點擊Start Game時，無論模組清單狀態如何，都會執行5階段驗證：

| 階段 | 檢查 | 彈出視窗 |
|---|---|---|
| 1 | Settings分頁 Steam路徑有效 (`Steam.exe` 存在) | SteamNotFound |
| 2 | `mods/{GameId}/` 資料夾中的遊戲與Settings設定的遊戲一致 | GameModsMismatch |
| 3 | 至少選擇了1個模組 | NoModSelected |
| 4 | 未混合選擇多個遊戲的模組 | MixedGameMods |
| 5 | 遊戲路徑已設定 + 執行檔存在 | GamePathNotSet / GameNotInstalled |

#### Development分頁 — ModLib驗證

點擊Mod Library Regeneration時進行3階段驗證：

| 階段 | 檢查 | 彈出視窗 |
|---|---|---|
| 1 | Settings分頁 Steam路徑有效 | SteamNotFound |
| 2 | 至少存在1個專案 | NoProjectWarning |
| 3 | `App.Game.GamePath` 已設定 | GamePathNotSet |

#### Downloads分頁
- 除錯字串替換為 `Lang.Downloads.Status.NoDownloads`
- 所有狀態訊息套用一致的邊距
- 更新支援的5款遊戲的離線手動文字；透過兩個TextBlock換行

#### First Setup & 遊戲路徑系統
- `FirstSetup.Check()` — `UseSteam`、`AutoUpdate`、`UpdateVersions` 預設值為 `true`
- `FirstSetupDone()` — 為全部5款遊戲建立 `mods/` 及 `projects/` 資料夾
- `SpecifyGamePath` — `GameNameLabel` 顯示是哪款遊戲；`NavigateToSettings()` 跳轉至Settings分頁

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

### 未包含的功能

| 功能 | 原因 |
|---|---|
| 自動更新 (保持最新版本) | 伺服器端基礎架構尚未建置 |
| 更新搜尋 | 伺服器端基礎架構尚未建置 |

### 已移除的項目

| 項目 | 原因 |
|---|---|
| 啟動時的 `SpecifyGamePath` 彈出視窗 | 所有路徑皆於Settings分頁中設定 |
| 啟動時的 `SpecifySteamPath` 彈出視窗 | Steam路徑已於Settings分頁中設定 |
| 登入系統 | 原伺服器已停止運作 (v2.0.9400中移除) |
| `Portable.System.ValueTuple.dll` | 於Mono 2.0上無法運作 (v2.0.9586中移除) |
| Steam檢查中的 `UseSteam` 條件 | 遊戲啟動及Mod Library Regeneration時，Steam現在始終最先被驗證 |

---

</details>

<details>
<summary><b>v2.0.9600 的變更內容</b></summary>

### 新增內容

- **Downloads分頁**：5個遊戲篩選 (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome分頁**：新增至最左側位置 (索引0)
- **Mods分頁**：3欄配置 (WrapPanel → 垂直清單)；自動寬度調整；模組名稱換行
- **`ModsViewModel`**：依遊戲篩選，為每個模組配對正確 `Game` 執行個體的 `ResolveGame()`
- **`Game.cs`**：輕量級建構函式 `new Game(config, true)` — 僅用於識別，無 `Verify()`
- **建置**：4個遊戲XML檔案以 `CopyToOutputDirectory=Always` 登錄至 `ModAPI.csproj`
- **建置**：清理警告 — CS0168、CS0618、CS0252
- **遊戲XML**：修正TheForest、Raft、GH的DLL清單
- **語言國旗**：全部13種語言徽章的圖片尺寸標準化

### 已移除的項目

| 項目 | 原因 |
|---|---|
| 遊戲XML檔案中的 `extends="GenericUnityGame"` | 導致 `Assembly-CSharp-firstpass.dll` 被錯誤繼承的問題 — 已從Subnautica、Raft、EscapeThePacific、GH中移除 |
| Mods分頁的 `WrapPanel` 版面配置 | 替換為3欄Grid版面配置 (Game Filter / Mod List / Information) |

---

</details>

---

## 版本歷史

<details>
<summary><b>Phase 6-3 — 主題系統擴充、設定改進、穩定性 & 工具新增</b></summary>

### v2.0.9621 — 2026-07-28

- 全部 5 款遊戲的全 Steam 庫自動檢測，由 Steam 連線核取方塊控制
- 自動檢測並排除為其他遊戲構建的模組（列表階段 + Apply 階段），Mods 標籤頁顯示 ⚠ 徽章
- 將排除的模組 / 未應用任何模組的提示合併為一個彈窗，不再堆疊多個彈窗；應用的模組為零個時遊戲不再啟動
- 新增全域性未處理異常日誌記錄（UI 執行緒 + 後臺執行緒）
- 用 `ModAPI.dev.log` 取代 `ModAPI.detailed.log`；設定標籤頁新增開發者日誌、啟動時清除日誌開關
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` 全新安裝時預設改為關閉
- 修復：`Configuration.GetPath()` 空路徑錯誤、Start Game 驗證順序不一致、忽略篩選的模組收集、跨遊戲的 `Mod.Mods` 鍵衝突及由此導致的 `UpdateMods()` 崩潰、Green Hell 校驗和重複計算（`_Data`/`_data`）、`BaseModLib.dll` 檔案鎖定崩潰、無條件建立 `mods\`/`projects\`、資料夾不存在時 `Versions.xml` 儲存失敗、字型大小變更/標籤切換時視窗高度未重新計算、"全部展開"時視窗高度無限擴大

### v2.0.9620 — 2026-06-21

**新增MODAPI_LangTool及主要修復**
- 新增MODAPI_LangTool (獨立WPF語言管理工具)
- 修復SSL/TLS (TLS 1.2)
- 修復法語混入問題 (`CultureInfo.InvariantCulture`)
- 修復Green Hell的`GamePathNotSet`
- SelectGameDialog (All篩選 + 多遊戲模組啟動)
- 移除MixedGameMods阻擋機制
- 3階段遊戲完整性驗證 (PE標頭 / 組件校驗和 / 數位簽章)
- 開發者/使用者日誌分離
- UpdateVersions 12項 + FindMods 7項 + StartGame 10項日誌
- 優先套用GitHub Raw URL (`VersionUpdateDomains`)
- 修復GH的`Versions.xml`校驗和
- TheForest的`Versions.xml`新增`1.12`
- 13個語言檔案515個鍵完全一致

**附加修復 (2026-06-21)**
- 修復StartGame驗證順序 (Steam → 遊戲路徑 → 模組)
- 遊戲選擇彈出視窗準確顯示路徑未設定的遊戲
- 透過UpdateVersions單一回應處理解決校驗和重複問題
- `DeleteMod`使用模組自身的遊戲執行個體，而非目前啟用的篩選
- 解決重新下載已刪除模組時啟用徽章殘留的問題
- 無論遊戲篩選狀態如何，刪除模組後立即更新清單
- 防止`GameIntegrityWarning`彈出視窗強制結束
- 改進數位簽章警告訊息，明確遊戲名稱並說明獨立遊戲相關情況
- 將`#if DEBUG`日誌遷移至雙檔案日誌系統(`ModAPI.log` / `ModAPI.detailed.log`) — 於Release建置中也能取得完整診斷日誌，同時保持使用者介面簡潔

### v2.0.9619 — 2026-05-25

- 從遊戲安裝路徑自動產生備份
- 修復檔案鎖定 (條件式解析器)
- 防止損壞模組無限重試
- 相容LF換行的模組檔案
- 0位元組下載偵測彈出視窗
- 滑桿儲存防彈跳 (500ms)
- 條件式遊戲資料夾產生
- `FileValidator`最小組件大小從64 KB改為8 KB
- `GetPath`/`GetString`/`GetInt`的`silent`參數
- 標頭解析診斷日誌
- `DownloadEmpty`語言鍵 (13種語言)

### v2.0.9618 — 2026-04-25
新增MODAPI_VersionTool (獨立WPF版本更新工具)，StatusBar版本顯示與App.Version關聯

### v2.0.9617 — 2026-04-24
Settings分頁新增Steam/遊戲路徑重設按鈕，Browse自動儲存，透過ui.cfg旗標保留重設狀態

### v2.0.9616 — 2026-04-18
建立/更新4款遊戲的Versions.xml (Subnautica, Raft, EscapeThePacific, GH)，建立校驗和構成規則，記錄遊戲更新流程文件

### v2.0.9615 — 2026-04-18
修復Settings分頁遊戲路徑卡片展開高度精確度，防止UpdateWindowHeight受背景材質干擾

### v2.0.9614 — 2026-04-18
最大化按鈕基於WorkArea的手動最大化，儲存並還原先前的大小/位置

### v2.0.9613 — 2026-04-18
新增Themes分頁，主題登錄檔資料驅動結構，支援10種主題，背景材質功能 (壓縮、安全性、雙層透明度)，ThemeSelector鎖定疊加層，12個新增語言鍵

### v2.0.9612 — 2026-04-18
Themes/資料夾分離，主題XAML模組化

### v2.0.9611 — 2026-04-18
修復主題切換後Mod List寬度未套用的問題

</details>

<details>
<summary><b>Phase 6-2 — 設定、路徑安全化、當機修復 & Debug/Release分支</b></summary>

### v2.0.9610 — 2026-04-13

- 修正多遊戲XML (GH, Subnautica, EscapeThePacific)
- 新增 `Versions.xml`
- 重新設計Settings分頁 (Steam路徑、遊戲路徑面板、寬度滑桿、字型大小、核取方塊同步)
- 遊戲路徑null安全處理 (6處)
- 以Settings分頁取代啟動時彈出視窗
- Mods分頁5階段遊戲啟動驗證 (Steam始終最先驗證)
- Dev分頁3階段ModLib驗證
- 新增 `GameModsMismatch` 彈出視窗
- 修復輕量級建構函式的 `ModLibrary` null問題
- 修復 `SwitchDevGame` 的 `GamePath`
- `FileValidator` PE標頭驗證 (Release)
- `#if DEBUG` 建置分離 (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- 持久化 `ui.cfg`
- 5階字型系統
- 多項當機修復
- 語言鍵更新

</details>

<details>
<summary><b>Phase 6-1 — 多遊戲 & Mods重新設計</b></summary>

### v2.0.9600 — 2026-04-09
> 5個遊戲篩選、Mods分頁3欄配置、自動寬度調整、輕量級`Game`建構函式、`ModsViewModel`遊戲篩選、登錄4個XML檔案、清理建置警告、Welcome分頁、語言國旗標準化

</details>

<details>
<summary><b>Phase 5-6B — C# 7.3 & 填充函式庫</b></summary>

### v2.0.9586 — 2026-03-31
> 修復黑畫面問題，確定填充函式庫，移除ValueTuple，驗證C# 7.3

</details>

<details>
<summary><b>Phase 5-5 — 組件解析</b></summary>

### v2.0.9561 — 2026-03-06
> C# 7.3支援，PE標頭修補，填充函式庫流程，恢復組件解析

</details>

<details>
<summary><b>Phase 5-1 — Downloads分頁 & 13種語言</b></summary>

### v2.0.9552 — 2026-02-25
> Downloads分頁，圖示現代化，主題統一，支援13種語言

</details>

<details>
<summary><b>初期階段</b></summary>

### Phase 3 — UI重新設計 & 主題系統
v2.0.9500
> 主題系統 (Classic/Light/Dark)，Fluent Design UI，SubWindow系統

### Phase 4 — 程式碼整理
v2.0.9400
> 程式碼整理，移除登入功能，舊有程式碼現代化

### Phase 2 — 建置環境 & Fluent Design
v2.0.9300
> 建置環境，UnityEngine虛擬DLL，ModernWpf整合

### Phase 1 — .NET 4.8遷移
v2.0.9200
> .NET Framework 4.8遷移

### v1.x
原版FluffyFish發行版

</details>

---

## 建置需求

| 需求 | 版本 | 備註 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI專案使用 |
| .NET Framework SDK | 3.5 | 僅BaseModLib使用 |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `libs/polyfills/`中的`System.Threading.dll` |

---

## 授權條款

GNU General Public License v3.0 — 遵循原始授權條款。
