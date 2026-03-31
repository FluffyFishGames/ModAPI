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

# ModAPI(v1) v2.0.9586 - 20260331

**The Forest Mod管理工具 — 升級版**

> 原作：FluffyFish / Philipp Mohrenstecher（恩格爾斯基興，德國）
> 升級：zzangae（大韓民國）

---

## 概述

ModAPI是一款用於管理The Forest遊戲Mod的桌面應用程式。此升級版包括.NET Framework 4.8遷移、Windows 11 Fluent Design介面、3主題系統、增強的多語言支援、完整的下載分頁實作以及C# 7.3 Mod開發支援。

---

## v2.0.9586 的變更內容

| # | 類別 | 問題 | 解決方案 |
|---|---|---|---|
| 1 | **嚴重** | 套用Mod後遊戲主選單出現黑色畫面 | 已修復 — 組件重新對映管線正確修補PE標頭和參考表 |
| 2 | **多填** | `Portable.System.ValueTuple.dll` 包含但無法正常運作 | 完全移除 — Mono 2.0的`mscorlib`產生直接參考`ValueTuple`的IL；任何多填均無法覆蓋 |
| 3 | **多填** | 檔案名稱錯誤：`System.Threading.Tasks.dll` | 更正為`System.Threading.dll` — `TaskParallelLibrary 1.0.2856` NuGet的實際檔案名稱 |
| 4 | **多填** | `Game.cs`複製路徑錯誤：檔案被複製到`Managed\polyfills\` | 使用`Path.GetFileName()`修復為平坦複製到`Managed\` |
| 5 | **建置** | PostBuild目標缺少多填自動複製 | `BaseModLib.csproj` PostBuild現在自動複製`AsyncBridge.dll`和`System.Threading.dll` |
| 6 | **C# 7.3** | 嘗試支援元組(`ValueTuple`)失敗 | 從所有設定中完全移除 — 元組在Mono 2.0上是架構硬限制 |
| 7 | **C# 7.3** | 遊戲內驗證剩餘C# 7.3功能 | 已確認：模式比對、字串插值、`out`變數內嵌 |

### C# 7.3最終功能矩陣

| 功能 | 狀態 | 備註 |
|---|---|---|
| 模式比對（`is`、`switch`） | ✅ 已確認 | 透過`TEST_MOD.log`遊戲內測試 |
| 字串插值（`$""`） | ✅ 已確認 | 透過`TEST_MOD.log`遊戲內測試 |
| `out`變數內嵌 | ✅ 已確認 | 透過`TEST_MOD.log`遊戲內測試 |
| 運算式主體成員（`=>`） | ✅ | 編譯器處理 |
| 區域函式 | ✅ | 編譯器處理 |
| `nameof` | ✅ | 編譯器處理 |
| Null條件運算子（`?.`、`??`） | ✅ | 編譯器處理 |
| `async`/`await` | ✅ | 透過AsyncBridge + System.Threading多填 |
| 元組（`ValueTuple`） | ❌ 硬限制 | Mono 2.0 mscorlib ABI — 無法繞過 |

### 最終多填設定

| DLL | NuGet套件 | 目標 | 用途 |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | .NET 3.5的`async`/`await` |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge相依性 |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~已移除~~ | ~~已移除~~ | ~~在Mono 2.0上不可用~~ |

---

## 執行時架構

| 元件 | 目標 | 執行時 | 原因 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 桌面應用程式 |
| `BaseModLib.dll` | .NET Framework 3.5 | 遊戲 Mono 2.0 | **永久固定** |
| Mod DLL | .NET Framework 4.8 | 遊戲 Mono 2.0（已修補） | Apply時修補PE標頭 |

```
v3.5建置  →  PE標頭：CLR Runtime v2.0.50727  ←  Mono 2.0 接受  ✅
v4.8建置  →  PE標頭：CLR Runtime v4.0.30319  ←  Mono 2.0 拒絕  ❌
```

---

## 版本歷程

| 版本 | 日期 | 摘要 |
|---|---|---|
| v2.0.9586 | 2026-03-31 | 黑色畫面修復確認，多填管線完成，ValueTuple移除，錯誤修復，C# 7.3遊戲內驗證 |
| v2.0.9561 | 2026-03-06 | C# 7.3 Mod開發支援，PE標頭修補，多填管線 |
| v2.0.9552 | 2026-02-25 | 下載分頁，圖示現代化，13語言 |
| v2.0.9500 | — | 主題系統，Fluent Design UI |
| v2.0.9400 | — | 程式碼清理 |
| v2.0.9300 | — | 建置環境，UnityEngine存根DLL |
| v2.0.9200 | — | .NET Framework 4.8遷移 |
| v1.x | — | FluffyFish原始版本 |

---

## 建置需求

| 需求 | 版本 | 備註 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | 用於ModAPI專案 |
| .NET Framework SDK | 3.5 | 僅用於BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — 放置於`libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll`置於`libs/polyfills/` |

---

## 授權條款

GNU General Public License v3.0 — 遵循原始授權條款。
