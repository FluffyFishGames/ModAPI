[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**The Forest Mod管理工具 — 升級版**

> 原作：FluffyFish / Philipp Mohrenstecher（恩格爾斯基興，德國）
> 升級：zzangae（大韓民國）

---

## 概述

ModAPI是一款用於管理The Forest遊戲Mod的桌面應用程式。此升級版包括.NET Framework 4.8遷移、Windows 11 Fluent Design介面、3主題系統、增強的多語言支援以及完整的下載分頁實作。

---

## 主要變更

### 第1階段 — .NET Framework 4.8 升級

- 將所有專案（5個）從`.NET Framework 4.5` → `4.8`遷移
- 更新所有專案的`TargetFrameworkVersion`、`App.config`、`packages.config`
- 統一組件版本

### 第2階段 — 建置環境與Fluent Design基礎

- 引入**ModernWpf 0.9.6** NuGet套件
- 建立**FluentStyles.xaml** — Windows 11 Fluent Design覆蓋層
  - Fluent調色盤、字型排版、按鈕、分頁、下拉選單、捲軸樣式
  - Window、SubWindow、SplashScreen範本
- 編譯**UnityEngine存根DLL**
  - 新增遺失的型別：`WWW`、`Event`、`TextEditor`、`Physics`等
- 修正相依性參考並確認建置成功

### 第3階段 — UI重新設計與主題系統

#### Fluent UI重新設計
- 完全重構**MainWindow.xaml**
  - 基於Fluent Design的版面配置、色彩、字型排版
  - 重新設計分頁控制項、狀態列、標題按鈕
- 執行時期修正：SplashScreen凍結、分頁切換、圖示狀態、視窗拖曳

#### 3主題系統

| 主題 | 樣式檔案 | 描述 |
|------|---------|------|
| 經典 | 僅Dictionary.xaml | 原版ModAPI設計（材質背景） |
| 亮色 | FluentStylesLight.xaml | 明亮色調 + 藍色強調 |
| 暗色 | FluentStyles.xaml | 深色色調 + 藍色強調（預設） |

- 在設定分頁中新增**主題選擇下拉選單**
- 主題變更觸發**確認對話框** → **自動重新啟動**
- 透過`theme.cfg`檔案儲存/載入主題設定

#### 視窗拖曳 / 子視窗 / 超連結
- Root Grid `MouseLeftButtonDown`事件直接處理拖曳
- ThemeConfirm、ThemeRestartNotice、NoProjectWarning、DeleteModConfirm對話框
- 主題特定連結色彩：暗色/經典（`#FFD700`），亮色（`#0078D4`）

### 第4階段 — 程式碼清理與舊功能移除

- 移除登入系統（伺服器已停止營運）
- 現代化更新機制
- 清理未使用的程式碼
- 修正子視窗UI（遊戲路徑對話框等）

### 第5階段 — 多語言支援擴展（13種語言）

| 語言 | 檔案 | 語言 | 檔案 |
|------|------|------|------|
| 韓語 | Language.KR.xaml | 義大利語 | Language.IT.xaml |
| 英語 | Language.EN.xaml | 日語 | Language.JA.xaml |
| 德語 | Language.DE.xaml | 葡萄牙語 | Language.PT.xaml |
| 西班牙語 | Language.ES.xaml | 越南語 | Language.VI.xaml |
| 法語 | Language.FR.xaml | 中文（簡體） | Language.ZH.xaml |
| 波蘭語 | Language.PL.xaml | 中文（繁體） | Language.ZH-TW.xaml |
| 俄語 | Language.RU.xaml | | |

### 第5-1階段 — 下載分頁與主題完善

#### 下載分頁
- 從3個來源載入Mod清單（`mods.json`、`versions.xml`、HTML解析）
- 搜尋功能（依Mod名稱/描述/作者篩選）
- **遊戲篩選**（全部 / The Forest / 專用伺服器 / VR）
- **類別篩選**（全部 / Bug修復 / 平衡性 / 作弊等 — 12個類別）
- 版本選擇分割面板UI
- 直接下載`.mod`檔案 → 安裝至遊戲資料夾
- 欄位排序（點擊名稱/類別/作者）及調整大小
- Mod刪除（DLL + 暫存檔案清理）

#### 圖示現代化（所有主題）
- 所有按鈕PNG圖示 → **Segoe MDL2 Assets**字型圖示
- 套用於MainWindow.xaml + 14個子視窗檔案
- 字型圖示繼承前景色，確保在所有主題中可見

| 原始PNG | 字型圖示 | 用途 |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | 新增 / 啟動遊戲 |
| Icon_Delete | &#xE74D; | 刪除 |
| Icon_Refresh | &#xE72C; | 重新整理 |
| Icon_Download | &#xE896; | 下載 |
| Icon_Continue/Accept | &#xE8FB; | 確認/繼續 |
| Icon_Decline | &#xE711; | 取消/關閉 |
| Icon_Information | &#xE946; | 資訊 |
| Icon_Warning | &#xE7BA; | 警告 |
| Icon_Error | &#xEA39; | 錯誤 |
| Icon_Browse | &#xED25; | 瀏覽 |
| Icon_CreateMod | &#xE713; | 建立Mod |

#### 所有主題統一控制項

| 控制項 | 經典 | 暗色 | 亮色 |
|--------|------|------|------|
| 核取方塊 | 切換（金色） | 切換（AccentBrush） | 切換（AccentBrush） |
| 選項按鈕 | 圓形（金色） | 圓形（AccentBrush） | 圓形（AccentBrush） |
| 下拉選單 | Scale9原版 | Fluent自訂 | Fluent自訂 |

#### 主題可見性修正
- 亮色：AccentButton文字強制白色，分頁圖示不透明度調整
- 暗色/亮色：ComboBoxItem `TextElement.Foreground`方法確保選取文字可見性
- 經典：Dictionary.xaml中新增Fluent備援資源

---

## 檔案結構

```
ModAPI/
├── App.xaml / App.xaml.cs          # 主題載入/儲存/套用
├── Dictionary.xaml                  # 原始樣式 + 切換/選項/備援資源
├── FluentStyles.xaml                # 暗色主題 + 下拉選單/核取方塊/選項按鈕
├── FluentStylesLight.xaml           # 亮色主題 + 下拉選單/核取方塊/選項按鈕
├── Windows/
│   ├── MainWindow.xaml / .cs        # 主UI + 下載分頁 + 主題選擇器
│   └── SubWindows/                  # 16個子視窗（全部使用字型圖示）
├── resources/
│   ├── langs/                       # 13個語言檔案
│   └── textures/Icons/flags/        # 國旗圖示（16x11 PNG）
└── libs/
    └── UnityEngine.dll              # 存根DLL
```

---

## 建置需求

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## 授權條款

GNU General Public License v3.0 — 遵循原始授權條款。
