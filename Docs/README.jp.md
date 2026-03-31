[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**The Forest Mod管理ツール — アップグレード版**

> オリジナル: FluffyFish / Philipp Mohrenstecher（エンゲルスキルヒェン、ドイツ）
> アップグレード: zzangae（大韓民国）

---

## 概要

ModAPIはThe ForestのMod管理用デスクトップアプリケーションです。このアップグレード版には、.NET Framework 4.8への移行、Windows 11 Fluent Design UI、3テーマシステム、多言語サポートの強化、およびダウンロードタブの完全な実装が含まれています。

---

## 主な変更点

### フェーズ 1 — .NET Framework 4.8 アップグレード

- すべてのプロジェクト（5つ）を`.NET Framework 4.5` → `4.8`に移行
- すべてのプロジェクトで`TargetFrameworkVersion`、`App.config`、`packages.config`を更新
- アセンブリバージョンの統一

### フェーズ 2 — ビルド環境とFluent Design基盤

- **ModernWpf 0.9.6** NuGetパッケージの導入
- **FluentStyles.xaml**の作成 — Windows 11 Fluent Designオーバーライドレイヤー
  - Fluentカラーパレット、タイポグラフィ、ボタン、タブ、コンボボックス、スクロールバースタイル
  - Window、SubWindow、SplashScreenテンプレート
- **UnityEngineスタブDLL**のコンパイル
  - 不足していた型を追加: `WWW`、`Event`、`TextEditor`、`Physics`など
- 依存関係参照を修正し、ビルド成功を確認

### フェーズ 3 — UIリデザインとテーマシステム

#### Fluent UIリデザイン
- **MainWindow.xaml**の完全な再構成
  - Fluent Designベースのレイアウト、カラー、タイポグラフィ
  - タブコントロール、ステータスバー、キャプションボタンの再設計
- ランタイム修正: SplashScreenフリーズ、タブ切り替え、アイコン状態、ウィンドウドラッグ

#### 3テーマシステム

| テーマ | スタイルファイル | 説明 |
|--------|----------------|------|
| クラシック | Dictionary.xamlのみ | オリジナルModAPIデザイン（テクスチャ背景） |
| ライト | FluentStylesLight.xaml | 明るいトーン + ブルーアクセント |
| ダーク | FluentStyles.xaml | 暗いトーン + ブルーアクセント（デフォルト） |

- 設定タブに**テーマ選択コンボボックス**を追加
- テーマ変更で**確認ダイアログ** → **自動再起動**がトリガー
- `theme.cfg`ファイルによるテーマ設定の保存/読み込み

#### ウィンドウドラッグ / サブウィンドウ / ハイパーリンク
- Root Grid `MouseLeftButtonDown`イベントによる直接ドラッグ処理
- ThemeConfirm、ThemeRestartNotice、NoProjectWarning、DeleteModConfirmダイアログ
- テーマ別リンクカラー: ダーク/クラシック (`#FFD700`)、ライト (`#0078D4`)

### フェーズ 4 — コードクリーンアップとレガシー除去

- ログインシステムの削除（サーバー運用終了）
- 更新メカニズムの近代化
- 未使用コードの整理
- SubWindow UIの修正（ゲームパスダイアログなど）

### フェーズ 5 — 多言語サポート拡張（13言語）

| 言語 | ファイル | 言語 | ファイル |
|------|---------|------|---------|
| 韓国語 | Language.KR.xaml | イタリア語 | Language.IT.xaml |
| 英語 | Language.EN.xaml | 日本語 | Language.JA.xaml |
| ドイツ語 | Language.DE.xaml | ポルトガル語 | Language.PT.xaml |
| スペイン語 | Language.ES.xaml | ベトナム語 | Language.VI.xaml |
| フランス語 | Language.FR.xaml | 中国語（簡体字） | Language.ZH.xaml |
| ポーランド語 | Language.PL.xaml | 中国語（繁体字） | Language.ZH-TW.xaml |
| ロシア語 | Language.RU.xaml | | |

### フェーズ 5-1 — ダウンロードタブとテーマ完成

#### ダウンロードタブ
- 3つのソースからModリストを読み込み（`mods.json`、`versions.xml`、HTMLパース）
- 検索機能（Mod名/説明/作者でフィルタリング）
- **ゲームフィルター**（すべて / The Forest / 専用サーバー / VR）
- **カテゴリフィルター**（すべて / バグ修正 / バランス調整 / チートなど — 12カテゴリ）
- バージョン選択スプリットパネルUI
- `.mod`ファイルの直接ダウンロード → ゲームフォルダへのインストール
- カラムソート（名前/カテゴリ/作者クリック）とリサイズ
- Mod削除（DLL + ステージングファイルのクリーンアップ）

#### アイコンの近代化（全テーマ）
- すべてのボタンPNGアイコン → **Segoe MDL2 Assets**フォントアイコン
- MainWindow.xaml + 14のSubWindowファイルに適用
- フォントアイコンがForegroundカラーを継承し、すべてのテーマで視認性を確保

| オリジナルPNG | フォントアイコン | 用途 |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | 追加 / ゲーム開始 |
| Icon_Delete | &#xE74D; | 削除 |
| Icon_Refresh | &#xE72C; | 更新 |
| Icon_Download | &#xE896; | ダウンロード |
| Icon_Continue/Accept | &#xE8FB; | 確認/続行 |
| Icon_Decline | &#xE711; | キャンセル/閉じる |
| Icon_Information | &#xE946; | 情報 |
| Icon_Warning | &#xE7BA; | 警告 |
| Icon_Error | &#xEA39; | エラー |
| Icon_Browse | &#xED25; | 参照 |
| Icon_CreateMod | &#xE713; | Mod作成 |

#### 全テーマ統一コントロール

| コントロール | クラシック | ダーク | ライト |
|-------------|----------|--------|--------|
| チェックボックス | トグル（ゴールド） | トグル（AccentBrush） | トグル（AccentBrush） |
| ラジオボタン | 円（ゴールド） | 円（AccentBrush） | 円（AccentBrush） |
| コンボボックス | Scale9オリジナル | Fluentカスタム | Fluentカスタム |

#### テーマ視認性修正
- ライト: AccentButtonテキストを強制ホワイト、タブアイコンのOpacity調整
- ダーク/ライト: ComboBoxItem `TextElement.Foreground`アプローチで選択テキストの視認性確保
- クラシック: Dictionary.xamlにFluentフォールバックリソースを追加

---

## ファイル構造

```
ModAPI/
├── App.xaml / App.xaml.cs          # テーマの読み込み/保存/適用
├── Dictionary.xaml                  # オリジナルスタイル + トグル/ラジオ/フォールバックリソース
├── FluentStyles.xaml                # ダークテーマ + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # ライトテーマ + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # メインUI + ダウンロードタブ + テーマセレクター
│   └── SubWindows/                  # 16個のSubWindow（すべてフォントアイコン付き）
├── resources/
│   ├── langs/                       # 13言語ファイル
│   └── textures/Icons/flags/        # 国旗アイコン（16x11 PNG）
└── libs/
    └── UnityEngine.dll              # スタブDLL
```

---

## ビルド要件

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## ライセンス

GNU General Public License v3.0 — オリジナルライセンスに準拠。
