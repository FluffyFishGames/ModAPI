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

**The Forest Mod管理工具 — 升级版**

> 原作：FluffyFish / Philipp Mohrenstecher（恩格尔斯基兴，德国）
> 升级：zzangae（大韩民国）

---

## 概述

ModAPI是一款用于管理The Forest游戏Mod的桌面应用程序。此升级版包括.NET Framework 4.8迁移、Windows 11 Fluent Design界面、3主题系统、增强的多语言支持、完整的下载选项卡实现以及C# 7.3 Mod开发支持。

---

## v2.0.9586 的变更内容

| # | 类别 | 问题 | 解决方案 |
|---|---|---|---|
| 1 | **严重** | 应用Mod后游戏主菜单出现黑屏 | 已修复 — 程序集重映射管道正确修补PE头和引用表 |
| 2 | **多填** | `Portable.System.ValueTuple.dll` 包含但无法正常工作 | 完全移除 — Mono 2.0的`mscorlib`生成直接引用`ValueTuple`的IL；任何多填均无法覆盖 |
| 3 | **多填** | 文件名错误：`System.Threading.Tasks.dll` | 更正为`System.Threading.dll` — `TaskParallelLibrary 1.0.2856` NuGet的实际文件名 |
| 4 | **多填** | `Game.cs`复制路径错误：文件被复制到`Managed\polyfills\` | 使用`Path.GetFileName()`修复为平铺复制到`Managed\` |
| 5 | **构建** | PostBuild目标缺少多填自动复制 | `BaseModLib.csproj` PostBuild现在自动复制`AsyncBridge.dll`和`System.Threading.dll` |
| 6 | **C# 7.3** | 尝试支持元组(`ValueTuple`)失败 | 从所有配置中完全移除 — 元组在Mono 2.0上是架构硬限制 |
| 7 | **C# 7.3** | 游戏内验证剩余C# 7.3功能 | 已确认：模式匹配、字符串插值、`out`变量内联 |

### C# 7.3最终功能矩阵

| 功能 | 状态 | 备注 |
|---|---|---|
| 模式匹配（`is`、`switch`） | ✅ 已确认 | 通过`TEST_MOD.log`游戏内测试 |
| 字符串插值（`$""`） | ✅ 已确认 | 通过`TEST_MOD.log`游戏内测试 |
| `out`变量内联 | ✅ 已确认 | 通过`TEST_MOD.log`游戏内测试 |
| 表达式体成员（`=>`） | ✅ | 编译器处理 |
| 本地函数 | ✅ | 编译器处理 |
| `nameof` | ✅ | 编译器处理 |
| Null条件运算符（`?.`、`??`） | ✅ | 编译器处理 |
| `async`/`await` | ✅ | 通过AsyncBridge + System.Threading多填 |
| 元组（`ValueTuple`） | ❌ 硬限制 | Mono 2.0 mscorlib ABI — 无法绕过 |

### 最终多填配置

| DLL | NuGet包 | 目标 | 用途 |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | .NET 3.5的`async`/`await` |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge依赖 |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~已移除~~ | ~~已移除~~ | ~~在Mono 2.0上不可用~~ |

---

## 运行时架构

| 组件 | 目标 | 运行时 | 原因 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 桌面应用 |
| `BaseModLib.dll` | .NET Framework 3.5 | 游戏 Mono 2.0 | **永久固定** |
| Mod DLL | .NET Framework 4.8 | 游戏 Mono 2.0（已修补） | Apply时修补PE头 |

```
v3.5构建  →  PE头：CLR Runtime v2.0.50727  ←  Mono 2.0 接受  ✅
v4.8构建  →  PE头：CLR Runtime v4.0.30319  ←  Mono 2.0 拒绝  ❌
```

---

## 版本历史

| 版本 | 日期 | 摘要 |
|---|---|---|
| v2.0.9586 | 2026-03-31 | 黑屏修复确认，多填管道完成，ValueTuple移除，错误修复，C# 7.3游戏内验证 |
| v2.0.9561 | 2026-03-06 | C# 7.3 Mod开发支持，PE头修补，多填管道 |
| v2.0.9552 | 2026-02-25 | 下载选项卡，图标现代化，13语言 |
| v2.0.9500 | — | 主题系统，Fluent Design UI |
| v2.0.9400 | — | 代码清理 |
| v2.0.9300 | — | 构建环境，UnityEngine存根DLL |
| v2.0.9200 | — | .NET Framework 4.8迁移 |
| v1.x | — | FluffyFish原始版本 |

---

## 构建要求

| 要求 | 版本 | 备注 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | 用于ModAPI项目 |
| .NET Framework SDK | 3.5 | 仅用于BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — 放置于`libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll`置于`libs/polyfills/` |

---

## 许可证

GNU General Public License v3.0 — 遵循原始许可证。
