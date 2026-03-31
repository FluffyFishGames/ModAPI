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
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**The Forest Mod管理工具 — 升级版**

> 原作：FluffyFish / Philipp Mohrenstecher（恩格尔斯基兴，德国）
> 升级：zzangae（大韩民国）

---

## 概述

ModAPI是一款用于管理The Forest游戏Mod的桌面应用程序。此升级版包括.NET Framework 4.8迁移、Windows 11 Fluent Design界面、3主题系统、增强的多语言支持以及完整的下载选项卡实现。

---

## 主要变更

### 第1阶段 — .NET Framework 4.8 升级

- 将所有项目（5个）从`.NET Framework 4.5` → `4.8`迁移
- 更新所有项目的`TargetFrameworkVersion`、`App.config`、`packages.config`
- 统一程序集版本

### 第2阶段 — 构建环境与Fluent Design基础

- 引入**ModernWpf 0.9.6** NuGet包
- 创建**FluentStyles.xaml** — Windows 11 Fluent Design覆盖层
  - Fluent调色板、排版、按钮、选项卡、组合框、滚动条样式
  - Window、SubWindow、SplashScreen模板
- 编译**UnityEngine存根DLL**
  - 添加缺失的类型：`WWW`、`Event`、`TextEditor`、`Physics`等
- 修复依赖引用并确认成功构建

### 第3阶段 — UI重设计与主题系统

#### Fluent UI重设计
- 完全重构**MainWindow.xaml**
  - 基于Fluent Design的布局、颜色、排版
  - 重新设计选项卡控件、状态栏、标题按钮
- 运行时修复：SplashScreen冻结、选项卡切换、图标状态、窗口拖动

#### 3主题系统

| 主题 | 样式文件 | 描述 |
|------|---------|------|
| 经典 | 仅Dictionary.xaml | 原版ModAPI设计（纹理背景） |
| 亮色 | FluentStylesLight.xaml | 明亮色调 + 蓝色强调 |
| 暗色 | FluentStyles.xaml | 深色色调 + 蓝色强调（默认） |

- 在设置选项卡中添加**主题选择组合框**
- 主题更改触发**确认对话框** → **自动重启**
- 通过`theme.cfg`文件保存/加载主题设置

#### 窗口拖动 / 子窗口 / 超链接
- Root Grid `MouseLeftButtonDown`事件直接处理拖动
- ThemeConfirm、ThemeRestartNotice、NoProjectWarning、DeleteModConfirm对话框
- 主题特定链接颜色：暗色/经典（`#FFD700`），亮色（`#0078D4`）

### 第4阶段 — 代码清理与遗留功能移除

- 移除登录系统（服务器已停止运营）
- 现代化更新机制
- 清理未使用的代码
- 修复子窗口UI（游戏路径对话框等）

### 第5阶段 — 多语言支持扩展（13种语言）

| 语言 | 文件 | 语言 | 文件 |
|------|------|------|------|
| 韩语 | Language.KR.xaml | 意大利语 | Language.IT.xaml |
| 英语 | Language.EN.xaml | 日语 | Language.JA.xaml |
| 德语 | Language.DE.xaml | 葡萄牙语 | Language.PT.xaml |
| 西班牙语 | Language.ES.xaml | 越南语 | Language.VI.xaml |
| 法语 | Language.FR.xaml | 中文（简体） | Language.ZH.xaml |
| 波兰语 | Language.PL.xaml | 中文（繁体） | Language.ZH-TW.xaml |
| 俄语 | Language.RU.xaml | | |

### 第5-1阶段 — 下载选项卡与主题完善

#### 下载选项卡
- 从3个来源加载Mod列表（`mods.json`、`versions.xml`、HTML解析）
- 搜索功能（按Mod名称/描述/作者筛选）
- **游戏筛选**（全部 / The Forest / 专用服务器 / VR）
- **类别筛选**（全部 / Bug修复 / 平衡性 / 作弊等 — 12个类别）
- 版本选择分割面板UI
- 直接下载`.mod`文件 → 安装到游戏文件夹
- 列排序（点击名称/类别/作者）和调整大小
- Mod删除（DLL + 暂存文件清理）

#### 图标现代化（所有主题）
- 所有按钮PNG图标 → **Segoe MDL2 Assets**字体图标
- 应用于MainWindow.xaml + 14个子窗口文件
- 字体图标继承前景色，确保在所有主题中可见

| 原始PNG | 字体图标 | 用途 |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | 添加 / 启动游戏 |
| Icon_Delete | &#xE74D; | 删除 |
| Icon_Refresh | &#xE72C; | 刷新 |
| Icon_Download | &#xE896; | 下载 |
| Icon_Continue/Accept | &#xE8FB; | 确认/继续 |
| Icon_Decline | &#xE711; | 取消/关闭 |
| Icon_Information | &#xE946; | 信息 |
| Icon_Warning | &#xE7BA; | 警告 |
| Icon_Error | &#xEA39; | 错误 |
| Icon_Browse | &#xED25; | 浏览 |
| Icon_CreateMod | &#xE713; | 创建Mod |

#### 所有主题统一控件

| 控件 | 经典 | 暗色 | 亮色 |
|------|------|------|------|
| 复选框 | 开关（金色） | 开关（AccentBrush） | 开关（AccentBrush） |
| 单选按钮 | 圆形（金色） | 圆形（AccentBrush） | 圆形（AccentBrush） |
| 组合框 | Scale9原版 | Fluent自定义 | Fluent自定义 |

#### 主题可见性修复
- 亮色：AccentButton文本强制白色，选项卡图标不透明度调整
- 暗色/亮色：ComboBoxItem `TextElement.Foreground`方法确保选中文本可见性
- 经典：Dictionary.xaml中添加Fluent后备资源

---

## 文件结构

```
ModAPI/
├── App.xaml / App.xaml.cs          # 主题加载/保存/应用
├── Dictionary.xaml                  # 原始样式 + 开关/单选/后备资源
├── FluentStyles.xaml                # 暗色主题 + 组合框/复选框/单选按钮
├── FluentStylesLight.xaml           # 亮色主题 + 组合框/复选框/单选按钮
├── Windows/
│   ├── MainWindow.xaml / .cs        # 主UI + 下载选项卡 + 主题选择器
│   └── SubWindows/                  # 16个子窗口（全部使用字体图标）
├── resources/
│   ├── langs/                       # 13个语言文件
│   └── textures/Icons/flags/        # 国旗图标（16x11 PNG）
└── libs/
    └── UnityEngine.dll              # 存根DLL
```

---

## 构建要求

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## 许可证

GNU General Public License v3.0 — 遵循原始许可证。
