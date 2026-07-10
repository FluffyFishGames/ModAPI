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

# ModAPI(v1) v2.0.9620 - 20260621

**The Forest モッド管理ツール — アップグレード版**

> オリジナル: FluffyFish / Philipp Mohrenstecher (ドイツ・エンゲルスキルヒェン)
> アップグレード: zzangae (大韓民国)

---

## 概要

ModAPIは**5つの公式サポートゲーム**のモッドを管理するデスクトップアプリケーションです。このアップグレード版には、マルチゲーム対応、全面的に再設計されたSettingsタブ、Steamパス設定、永続的なUI設定、動的フォントサイズシステム、ゲーム起動時の検証機能、Debug/Releaseビルド分離、そしてインゲームテストで検証された数多くのクラッシュ修正が含まれています。

---

## サポートゲーム

| ゲーム | エンジン | バージョン | Steam ID | 実行ファイル |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025パッチ | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (ベータ) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 5 (Unity 4からアップグレード) |
| 最新バージョン | v1.12 (VR) |
| 最終更新 | 2019年9月11日 — VR対応パッチ；以降大型コンテンツ更新なし |
| 実行ファイル | `TheForest.exe` |
| データフォルダ | `TheForest_Data/Managed/` |
| Modsフォルダ | `mods/TheForest/` |
| プロジェクトフォルダ | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 完全サポート |

The ForestはUnity 4からUnity 5へアップグレードされ、ビジュアルと物理演算が大幅に向上しました。2019年9月のVRパッチが最後の大型アップデートであり、以降は安定した完成状態を維持しているため、モッド制作に理想的です。
</details>

<details>
<summary><b>Subnautica</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity (2022年にBelow Zeroと統合コードベース化) |
| 最新バージョン | 2025パッチ (v18810395) |
| 最終更新 | 2025年8月12日 — モバイル版リリースに伴うバグ修正およびパフォーマンス改善 |
| 実行ファイル | `Subnautica.exe` |
| データフォルダ | `Subnautica_Data/Managed/` |
| Modsフォルダ | `mods/Subnautica/` |
| プロジェクトフォルダ | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — サポート |

元々Unity 5をベースにリリースされたSubnauticaは、2022年末の「Living Large」アップデート(v2.0)でBelow Zeroとエンジンコードベースを統合し、最適化と安定性が向上しました。備考: 続編の*Subnautica 2*はUnreal Engine 5を使用します。

> **v2.0.9610でXMLを再作成**: `XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll`が`copyAssembly`に追加されました。
</details>

<details>
<summary><b>RAFT</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity |
| 最新バージョン | v1.1.02 (ベータ) / v1.09 (安定版) |
| 最終更新 | 2026年3月 — ベータブランチで音声チャットおよびマルチプレイヤーのバグ修正 |
| 実行ファイル | `Raft.exe` |
| データフォルダ | `Raft_Data/Managed/` |
| Modsフォルダ | `mods/Raft/` |
| プロジェクトフォルダ | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — サポート |
| Versions.xml | `1.1.01` (チェックサム含む) |

v1.0 *The Final Chapter*で公式ストーリーが完結した後も、ネットワークコードの改善と安定性のためのパッチが継続されています。2026年3月のベータブランチアップデートで音声チャットおよびマルチプレイヤーの問題が修正されました。
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 6 (2025年末にUnity 2021/2022から移行) |
| 最新バージョン | v0.67.0.0 |
| 最終更新 | 2025年6月26日 — 島の配置再設計とエンジン更新；2026年までホットフィックス継続中 |
| 実行ファイル | `EscapeThePacific.exe` |
| データフォルダ | `EscapeThePacific_Data/Managed/` |
| Modsフォルダ | `mods/EscapeThePacific/` |
| プロジェクトフォルダ | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — サポート |

2025年末に主要システムの再設計とUnity 6への移行を完了し、より動的な環境が実現されました。ゲームは現在アーリーアクセスとして開発が進行中です。

> **v2.0.9610でXMLを再作成**: `extends="GenericUnityGame"`を削除；`includeAssembly`を`Assembly-CSharp.dll`のみに設定 — `Assembly-CSharp-firstpass.dll`の継承エラーを防止。
</details>

<details>
<summary><b>Green Hell</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 2019 |
| 最新バージョン | v2.9.5 |
| 最終更新 | 2026年2月4日 — Steam Deck最適化およびテキスト可読性の改善 |
| 実行ファイル | `GH.exe` |
| データフォルダ | `GH_Data/Managed/` |
| Modsフォルダ | `mods/GH/` |
| プロジェクトフォルダ | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — サポート |
| Versions.xml | `2.9.5` (チェックサム含む) |

ゲームのライフサイクルを通じてUnity 2017 → 2018 → 2019と開発されました。2026年2月のホットフィックスはSteam Deck互換性とUI可読性に重点が置かれました。

> **v2.0.9610でXMLを再作成**: `AmplifyBloom.dll`、`AmplifyColor.dll`、`AmplifyMotion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`を追加；存在しない`DOTweenPro.dll`を削除。
</details>

---

<details>
<summary><b>アーキテクチャ</b></summary>

### ランタイム分離

| コンポーネント | 対象 | ランタイム | 理由 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | デスクトップアプリケーション、最新API完全対応 |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 共有ライブラリ |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **恒久固定** — PEヘッダーが`v2.0.50727`を示す必要あり |
| Mod DLL (ユーザー) | .NET Framework 4.8 | Game Mono 2.0 (パッチ済み) | 4.8でビルド、Apply時にPEヘッダーをパッチ |

### 開発者ツール

プロジェクト管理用の独立したWPFユーティリティです。エンドユーザーには配布されません。

| ツール | プロジェクト | 目的 |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | `AssemblyInfo.cs`および`App.xaml.cs`のバージョンを同時更新 |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | 言語ファイル管理 — 追加、編集、無効化、内蔵切り替え |

**VersionTool — バージョン管理**

ワンクリックでバージョン番号を更新できる独立WPFツールです。

- 現在のバージョンを自動表示 (`App.xaml.cs`から読み取り)
- 新しいバージョンを入力し**Apply Version**をクリックすると両方のファイルを同時更新
- 形式検証: `X.X.XXXX`形式のみ許可

| ファイル | パス | 変更内容 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`、`AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — 言語システム**

```
resources/langs/langs.json          ← 言語レジストリ (builtin / active フラグ)
resources/langs/Language.XX.xaml    ← 言語別翻訳キー
resources/langs/Language.XX.png     ← 国旗画像 (36×24、flagcdn.com/h24/ 提供)
```

内蔵切り替えの流れ (Updateボタン):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() 再作成 (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml 登録 (ModAPI\ModAPI.csproj)
  → 次回ビルド: 言語が完全に内蔵され、オフラインで使用可能
```

### Debug / Release ビルド分離

すべてのファイル検証およびアセンブリ処理は、`#if DEBUG` / `#else`によるビルド構成で分岐します。

| 箇所 | Debugビルド | Releaseビルド |
|---|---|---|
| `CheckSteam()` | `File.Exists()`のみ — ダミーファイルも通過 | `FileValidator.IsValidSteamExe()` — PEヘッダー + 最小1 MB |
| `CheckGamePath()` | `File.Exists()`のみ — ダミーファイルも通過 | `FileValidator.IsValidAssemblyDll()` — PEヘッダー + CLRメタデータ + 最小8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — Cecil解析を省略 | 完全なMono.Cecil解析 + IL修正 + `module.Write()` |
| `ModLib.Create()` — ファイル未検出 | 警告ログを出力してスキップ、継続 | エラーログを出力し、ポップアップとともに中断 |

**Debugテスト**では`create_dummy_Debug_games.ps1`を使用して、`bin\Debug\dummy_games\`、`bin\Debug\dummy_steam\`、`bin\Debug\gamefiles\original\`配下に0バイトのダミーファイルを生成します。これらのファイルは`File.Exists()`検査を通過し、実際のゲームをインストールせずに全UIワークフローのテストが可能です。

**Releaseビルド**では`FileValidator` (PEヘッダー + .NET CLRメタデータ検証)を適用し、0バイトファイル、テキストファイル、任意のバイナリを拒否します。有効なWindows実行ファイルと.NETアセンブリのみが通過します。

### FileValidator — PEヘッダー検証

`ModAPI_Shared\Utils\FileValidator.cs` — Releaseビルドでのみ適用されます。

| メソッド | 検査項目 | 最小サイズ |
|---|---|---|
| `IsValidSteamExe(path)` | MZ署名 + PE\0\0署名 | 1 MB |
| `IsValidGameExe(path)` | MZ署名 + PE\0\0署名 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLRメタデータヘッダー (データディレクトリ #14) | 8 KB |

```
検査されるPEヘッダーのレイアウト:
[0x00] 4D 5A          ← "MZ" DOS署名
[0x3C] XX XX XX XX   ← PEヘッダーオフセット (リトルエンディアン)
[offset] 50 45 00 00 ← "PE\0\0" 署名
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLRヘッダーの存在
```

### アセンブリ再マッピングパイプライン

```
[Modデベロッパーが.NET 4.8でビルド]
  → Mod DLL: PEヘッダー v4.0.30319、mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0 など
  → modModule.RuntimeVersion = "v2.0.50727"
      PEヘッダー: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → PEヘッダー承認 ✅  →  参照解決 ✅
```

### アセンブリリゾルバーフォールバック

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← バックアップフォルダ
2. {ActualGameInstallPath}/{AssemblyPath}        ← ゲームインストールフォルダ (フォールバック)
```

### C# 7.3 機能サポート

| 機能 | 状態 | 備考 |
|---|---|---|
| パターンマッチング (`is`, `switch`) | ✅ | インゲーム検証済み |
| 文字列補間 (`$""`) | ✅ | インゲーム検証済み |
| `out`変数インライン | ✅ | インゲーム検証済み |
| `async` / `await` | ✅ | AsyncBridge + System.Threadingポリフィル経由 |
| タプル (`ValueTuple`) | ❌ ハード制限 | Mono 2.0 `mscorlib` ABI — 回避策なし |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_ko.md)</b></summary>

v2.0.9613より、テーマ選択UIがSettingsタブから専用の**Themesタブ**へ移動されました。新しいテーマの追加は`App.xaml.cs`辞書に1行追加するだけで完了します。

| インデックス | ID | ファイル | パレット |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml`のみ | オリジナルModAPIテクスチャ背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明るいトーン + 青のアクセントカラー |
| 2 | `dark` | `FluentStyles.xaml` | 暗いトーン + 青のアクセントカラー (デフォルト) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 赤 + 黒 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗い宇宙 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明るい夕焼け |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗い海 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明るいノルディック |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明るいシトラス |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明るい花柄 |

テーマ変更時、アプリは自動的に再起動します。(`theme.cfg`に保存)

| テーマ | テーマ |
| :---: | :---: |
|**01. Classicテーマ**|**02. Lightテーマ**|
| ![01. Classic theme](https://github.com/user-attachments/assets/dc81132a-149c-4d0b-a7bb-a04a900e878b) | ![02. Light theme](https://github.com/user-attachments/assets/0d6925ec-f8b2-4f8a-a1d6-c082a5aa3378) |
|**03. Darkテーマ**|**04. Diabloテーマ**|
| ![03. Dark theme](https://github.com/user-attachments/assets/53abe172-ee66-4f3e-9c36-830b2d659b4d) | ![04. Diablo theme](https://github.com/user-attachments/assets/8c30f223-e564-45dc-8389-c51bfc60b3eb) |
|**05. Nebulaテーマ**|**06. Sunsetテーマ**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/4ff565dd-516b-4951-9d47-6027ac9e3e29) | ![06. Sunset theme](https://github.com/user-attachments/assets/192a6f16-b041-4422-8b64-4f8522f27c15) |
|**07. Oceanテーマ**|**08. Nordicテーマ**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/50a47588-bc62-4cfc-91a0-a44f87c45867) | ![08. Nordic theme](https://github.com/user-attachments/assets/81e98f6b-2897-4fd5-bee9-604c04dc26ff) |
|**09. Citrusテーマ**|**10. Bloomテーマ**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/64ccb11d-4ab0-41a2-8e00-4f7910558372) | ![10. Bloom theme](https://github.com/user-attachments/assets/265c9249-4d43-4f77-86d6-ccc4037071f7) |

### 背景テクスチャ

Themesタブの**背景テクスチャ**カードで画像を選択すると、アプリ全体の背景として適用されます。対応形式: `.png` / `.jpg` / `.jpeg`、最大50MB、4K解像度以下。画像はJPEG Q75で圧縮され、16バイトのマジックヘッダーとともに`resources\textures\ui_bg\bg.dat` (隠しファイル属性)として保存されます。SHA-256ハッシュで整合性を検証；改ざんが検出されると自動的にリセット + 警告ポップアップを表示。

背景が有効な場合、UIの透明度は2つのレイヤーで処理されます: レイヤー1 (MergedDictionariesオーバーレイ)は`{DynamicResource}`パネル用、レイヤー2 (WalkStyleBackgrounds)は`{StaticResource}`ベースのパネルに半透明を適用。

### フォントサイズシステム

| リソースキー | 基本値 | 説明 |
|---|---|---|
| `AppBaseFontSize` | 13 | 通常テキスト |
| `AppBaseHeaderFontSize` | 16 | ヘッダー、パネルタイトル |
| `AppBaseSmallFontSize` | 12 | 補助ラベル |
| `AppBaseTinyFontSize` | 10 | ヒントテキスト |
| `AppBaseLargeFontSize` | 20 | 大型表示テキスト |

### 永続UI設定 — `ui.cfg`

| キー | デフォルト | 説明 |
|-----|---------|-------------|
| `ModListWidth` | `150` | Modsタブのリスト幅 (px) |
| `ProjectListWidth` | `150` | Developmentタブのプロジェクトリスト幅 (px) |
| `AppFontSize` | `13` | グローバルUIフォントサイズ (px) |
| `AlwaysOnTop` | `false` | ウィンドウを常に最前面に表示 |
| `TexturePath` | *(なし)* | 背景テクスチャの元のファイル名 (表示用) |
| `TextureHash` | *(なし)* | 背景テクスチャのSHA-256ハッシュ |
| `TextureActive` | `false` | 背景テクスチャの有効化状態 |
| `GamePathReset_{GameId}` | *(なし)* | ゲームパスのリセットフラグ |
| `SteamPathReset` | *(なし)* | Steamパスのリセットフラグ |
</details>

<details>
<summary><b>プロジェクト構造</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # 永続UI設定
├── theme.cfg                            # 現在のテーマ
├── Windows/
│   ├── MainWindow.xaml / .cs            # メインUI — 6つのタブ、テーマ、設定、Steamパス、
│   │                                    #   0バイトダウンロード保護、スライダーデバウンス、サイレント設定読み取り
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # ゲームパスポップアップ (動的GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # 初回起動セットアップ + デフォルト値初期化
│       └── (その他14個のSubWindows)
├── Themes/
│   ├── Dictionary.xaml                  # Classicテーマ
│   ├── FluentStyles.xaml                # Darkテーマ
│   ├── FluentStylesLight.xaml           # Lightテーマ
│   ├── FluentStylesDiablo.xaml          # Diabloテーマ
│   ├── FluentStylesNebula.xaml          # Nebulaテーマ
│   ├── FluentStylesSunset.xaml          # Sunsetテーマ
│   ├── FluentStylesOcean.xaml           # Oceanテーマ
│   ├── FluentStylesNordic.xaml          # Nordicテーマ
│   ├── FluentStylesCitrus.xaml          # Citrusテーマ
│   └── FluentStylesBloom.xaml           # Bloomテーマ
├── Data/
│   ├── Mod.cs                           # Modファイルの読み込み、LF/CRLFヘッダー解析、診断ログ
│   ├── ModLib.cs                        # BaseModLib生成 + 再マッピング (#if DEBUG分離)
│   ├── Models/
│   │   └── ModProject.cs                # プロジェクトの作成/ビルド/適用 + nullガード
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   破損したModの再試行防止
│   │   ├── ModViewModel.cs              # フォルダパスからGameIdを抽出
│   │   ├── ModProjectsViewModel.cs      # DispatcherTimer用のDispose()
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersionsのデフォルトtrue
│   └── AssemblyVersionMap.cs            # Mono 2.0アセンブリバージョンマッピング (20個のアセンブリ)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 名前ベースのリゾルバー (キャッシュ付き)
│   └── MonoHelper.cs                    # Mono.Cecil IL ヘルパーユーティリティ
├── resources/
│   ├── langs/                           # 13言語ファイル + langs.json (v2.0.9620でLangTool.*キー追加)
│   └── textures/ui_bg/
│       └── bg.dat                       # 圧縮・セキュア処理された背景画像 (ランタイム生成)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # v2.0.9610で全面再作成
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # v2.0.9610で全面再作成
    │   ├── GH.xml                       # v2.0.9610で全面再作成
    │   ├── SonsOfTheForest.xml          # IL2CPP — 未サポート
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # silentパラメータ付きのGetPath/GetString/GetInt
├── Data/
│   ├── Game.cs                          # ApplyModsバックアップ自動生成、条件付きリゾルバー、
│   │                                    #   ゲームフォルダフォールバック、軽量コンストラクタ + ModLib初期化修正
│   └── ModLib.cs                        # #if DEBUG分離、IncludeAssemblies/CopyAssemblies用ゲームフォルダフォールバック
└── Utils/
    └── FileValidator.cs                 # PEヘッダー + CLRメタデータ検証 (Release専用、最小8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # 独立WPFバージョン更新ツール
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # バージョン入力、Applyボタン、現在バージョン表示
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # 独立WPF言語管理ツール
├── App.xaml / App.xaml.cs              # 言語読み込み/切り替え、langtool.cfg
├── MainWindow.xaml / .cs               # メインUI — 言語リスト、編集パネル、パスセレクター
├── AddLanguageDialog.xaml / .cs        # ISO 3166-1国選択ComboBox
├── ModApiDialog.xaml / .cs             # ModAPIスタイルのカスタムダイアログ (情報/警告/確認/質問)
├── Models/
│   ├── LanguageEntry.cs                # 言語エントリーモデル (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # langs.jsonルートモデル
│   └── IsoCountry.cs                   # ComboBox用ISO国モデル
└── Helpers/
    ├── LangsJsonHelper.cs              # langs.jsonの読み書き
    ├── FlagDownloader.cs               # flagcdn.com h24 国旗ダウンロード
    ├── XamlGenerator.cs                # Language.XX.xamlの生成/保存/解析
    ├── MissingKeyDetector.cs           # 英語基準の欠落キー検出
    ├── IsoCountryList.cs               # ISO 3166-1全196か国リスト (オフライン)
    └── BuiltinCodeWriter.cs            # CreateDefaultLangsJson()再作成 + ModAPI.csproj登録

bin\Debug\                               # Debugテスト専用
├── create_dummy_Debug_games.ps1         # ダミーゲーム/Steam構造の生成
├── dummy_games\{GameId}\               # ダミーゲームインストールパス
├── dummy_steam\Steam.exe               # ダミーSteam実行ファイル
└── gamefiles\original\{GameId}\        # ModLib用ダミーバックアップパス
```

---

</details>

<details>
<summary><b>インストールと設定</b></summary>

### ステップ1 — 前提条件

| 項目 | 必須 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (Windows 11にはプリインストール済み；Windows 10は[ダウンロード](https://dotnet.microsoft.com/download/dotnet-framework/net48)) |
| Steam | 必須 — Settingsタブで設定が必要 |
| サポートされているゲーム1本以上 | 必須 — Settingsタブで設定が必要 |

### ステップ2 — ModAPIのインストール

1. GitHubから最新リリースをダウンロード
2. 任意のフォルダに解凍 (例: `C:\ModAPI\`)
3. `ModAPI.exe`を実行
4. 初回起動時に**Welcome**画面が表示されます — 設定を行い**Continue**をクリック

### ステップ3 — Steamパスの設定 (Settingsタブ)

1. **Settings**タブへ移動
2. **Steam Installation Path**項目を探す
3. **Browse**をクリック → `Steam.exe`を選択
4. **Save**をクリック

### ステップ4 — ゲームパスの設定 (Settingsタブ)

1. ゲームカードのヘッダーをクリックして展開
2. **Browse**をクリック → ゲームのルートフォルダを選択 (`.exe`がある場所)
3. **Save**をクリック

| ゲーム | 実行ファイル | パスの例 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### ステップ5 — モッドのダウンロード (Downloadsタブ)

1. **Downloads**タブへ移動
2. ゲームフィルターからゲームを選択
3. モッドを閲覧または検索し、**Download**をクリック

> **オフライン**: `modapi.survivetheforest.net`から`.mod`ファイルを手動でダウンロードし、対応するフォルダに配置してください:

| ゲーム | フォルダ |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### ステップ6 — モッドの適用とゲーム起動 (Modsタブ)

1. **Mods**タブへ移動
2. **Game Filter**からゲームを選択 (列0)
3. **Mod List**で有効化するモッドにチェック (列1)
4. **Start Game**をクリック

ゲーム起動前に以下の検査が自動的に実行されます:

| # | 検査項目 | 失敗時のポップアップ |
|---|---|---|
| 1 | Steamパスの設定と有効性確認 | SteamNotFound |
| 2 | `mods/`フォルダのゲームがSettingsタブのゲームと一致 | GameModsMismatch |
| 3 | 最低1つのモッドが選択されている | NoModSelected |
| 4 | 複数ゲームのモッドが混在選択されていない | MixedGameMods |
| 5 | ゲームパスの設定と実行ファイルの存在確認 | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>タブ概要</b></summary>

### Welcomeタブ
初回起動セットアップ画面 (タブインデックス0)。AutoUpdate、Steam接続、VersionsDataテーブルの設定を行います。2回目以降の起動ではコミュニティリンクとリリースノートを提供します。

### Modsタブ
主要なモッド管理ワークフロー — 3列レイアウト:

| 列 | 内容 |
|---|---|
| 列0 | Game Filter — 5つのサポートゲーム用のラジオボタン |
| 列1 | Mod List — バージョンピッカーと有効化チェックボックス付きのインストール済みモッド |
| 列2 | Information — 選択したモッドの詳細情報、説明、バージョン履歴 |

### Downloadsタブ
`modapi.survivetheforest.net`からモッドを閲覧しダウンロードします。

- **Game Filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category Filter**: 12カテゴリー (バグ修正、バランス調整、チート、…)
- **Search**: モッド名、説明、作者で検索
- **Offline mode**: サポートされている5つのゲームすべてに対するフォルダ案内を表示

### Developmentタブ
モッド開発ワークフロー — Game Filterパネル (列0)はサポートされている5つのゲームすべてを含みます。

- ゲームごとのモッドプロジェクトの作成、ビルド、適用
- 言語リソース管理
- 3段階の検証を伴うModLib生成 (Steam → プロジェクト → ゲームパス)
- 軽量な`Game`コンストラクタによる安全なゲーム切り替え (`Verify()`呼び出しなし)

### Themesタブ
テーマ選択と背景テクスチャ管理。

- **テーマ選択**: 10種類のテーマ (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **背景テクスチャ**: アプリ全体の背景として画像を選択 (JPEG圧縮 + セキュア処理)
- 背景テクスチャが有効な場合、テーマ選択はロックされます

### Settingsタブ
集中管理型の設定 — 4行:

| 行 | 内容 |
|---|---|
| 0 | 言語 / フォントサイズ / 最大幅 / Mod List幅 / Project List幅 |
| 1 | VersionsData保持 / 自動更新 / Steam接続 / 常に最前面に表示 |
| 2 | Steam Installation Path (テキストボックス + Browse + Save + Reset) |
| 3 | Game Installation Paths — ゲームごとの展開可能なカード (テキストボックス + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (言語管理ツール)

ModAPIの言語ファイルを管理する独立したWPFツールです。`LangTool\MODAPI_LangTool.csproj`としてソリューションに追加されます。

**場所**: `LangTool\MODAPI_LangTool.csproj`

**主な機能**

| 機能 | 説明 |
|---|---|
| 言語リスト | `langs.json`内のすべての言語をステータスアイコン付きで表示 (🔒 内蔵 / 🚫 無効 / ✅ 有効) |
| 言語追加 | ISO 3166-1のComboBoxから国を選択 → `flagcdn.com/h24/{iso}.png`から国旗を自動ダウンロード → 英語テンプレートから`Language.XX.xaml`を自動生成 |
| 言語編集 | `isoCode` / `langCode`はロック；有効状態のときのみ`langName`および翻訳キーを編集可能 |
| 無効化 / 有効化 | `langs.json`の`active`フラグをトグル — ファイルは保持され、ModAPIのリストから非表示 |
| 更新 (内蔵切り替え) | `builtin: false` → `true`へ切り替え — 元に戻せない、2段階確認あり — ソースから`CreateDefaultLangsJson()`を自動再作成し、`ModAPI.csproj`に`Language.XX.xaml`を登録 |
| 欠落キー検出 | 英語基準と比較 — 欠落/空のキー数および翻訳進捗を表示 |
| 内蔵保護 | `builtin: true`の言語は読み取り専用 — 編集、無効化、更新不可 |
| 無効保護 | `active: false`の言語は再有効化するまで読み取り専用 |
| 言語UI | LangTool自体が13言語すべてのModAPI言語をサポート — 右上に国旗付きの言語セレクター |
| パス保存 | 選択したModAPIルートパスを`langtool.cfg`に保存 — 次回起動時に自動読み込み |
| カスタムダイアログ | すべてのポップアップにシステムのMessageBoxではなく、ModAPIスタイルのダークテーマ`ModApiDialog`を使用 |

**langs.jsonの構造**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**国旗画像のルール**

```
ISOコード (小文字) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                  resources/langs/
```

**Updateボタンの動作**

非内蔵の有効な言語でUpdateボタンをクリックすると:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — 現在`builtin: true`の言語全体で`CreateDefaultLangsJson()`を再作成
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />`を登録
4. 次回ビルド — 言語が完全に内蔵され、オフラインで使用可能

**追加された言語キー** (`Lang.LangTool.*`)

LangToolのUI文字列、ダイアログメッセージ、ステータステキストを含む53個の新規キーが13言語ファイル全体に追加されました。

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (バージョン更新ツール)

ワンクリックでバージョン番号を更新できる独立WPFツールです。

**場所**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**機能**
- 現在のバージョンを自動表示 (`App.xaml.cs`から読み取り)
- 新しいバージョンを入力し**Apply Version**をクリックすると両方のファイルを同時更新
- 形式検証: `X.X.XXXX`形式のみ許可

**変更されるファイル**

| ファイル | パス | 変更内容 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`、`AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**使い方**
1. `MODAPI_VersionTool.exe`を実行
2. 新しいバージョンを入力 (例: `2.0.9619`)
3. **Apply Version**をクリック
4. Visual StudioでModAPIソリューションをリビルド

**StatusBarのバージョン表示**

- `VersionLabel.Text`がハードコードされた説明子ではなく`App.Version`を参照するように変更
- VersionToolでバージョンを更新しリビルドすると、StatusBarに即座に反映されます

---

</details>

<details>
<summary><b>Log</b></summary>

### ロギングシステム — 2ファイル分離 (`ModAPI.log` / `ModAPI.detailed.log`)

開発者専用の診断ログは以前`#if DEBUG`に制限されていたため、ユーザーの問題解決に最も必要となるReleaseビルドで確認できないという問題がありました。これを2ファイルシステムに置き換えます:

| ファイル | 内容 |
|---|---|
| `ModAPI.log` | ユーザー向けの主要ログ — 従来と同じ形式で、以前より増加しない |
| `ModAPI.detailed.log` | Release/Debugに関係なく、すべてのログ呼び出しを常に記録 — ユーザー問い合わせ時の診断用 |

**`Debug.cs`** — `Log()`に`detailedOnly`パラメータが追加されました。`true`の場合、メッセージは`ModAPI.detailed.log`にのみ記録されます；既存のすべての`#if DEBUG`ブロックを完全に削除する代わりにこのフラグへ切り替えることで、Releaseでも常にdetailedファイルへ記録されます。結果として4段階の重大度体系が構成されます:

| 段階 | 意味 |
|---|---|
| Verbose (`detailedOnly: true`) | 反復的/機械的なトレース — タイプ別、ファイル別、メソッド別 |
| Notice | 人が読む流れ — 進行状況および成功メッセージ |
| Warning | 潜在的な問題、まだ失敗ではない |
| Error | 確実な失敗 |

**`ModAPI.log`を圧迫していたログノイズの発生箇所と`detailedOnly: true`への切り替え対象:**

| ファイル | `ModAPI.log`にあふれていた内容 |
|---|---|
| `ModsViewModel.cs` | 1秒ごとに繰り返される`FindMods()`のスキャン/スキップ/キューメッセージ |
| `Game.cs` | `UpdateVersions()`のTLS/URLトレース行、Cecilの型マッピング項目 |
| `ModLib.cs` | Cecilによる型/メソッド単位のアセンブリ処理 (`Validating`、`Processing`、`Changed ... accessibility`) — Green Hellのモッドビルド1回で数万行が出力され、`ModAPI.log`の容量の大半を占めていた主犯 |
| `Mod.cs` | モッド読み込みごとにモッドヘッダーXML全体をダンプ (`configuration.ToString()`) |

**チェックサム不一致ログ — 項目ごとから要約へ:** `Header.Verify()`は以前、互換性のない`InjectInto`/`AddMethod`/`AddField`/`AddClass`項目ごとに`Mismatched checksum at "..."`という行を1つずつ出力しており、1つの古いモッドから数十行出ることもありました。現在は`ModAPI.log`に単一のWarningレベルの要約のみが記録されます (例: `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`)。項目ごとの全リストは引き続き`ModAPI.detailed.log`で確認できます。

---

</details>

<details open>
<summary><b>v2.0.9620の変更点</b></summary>

## v2.0.9620の変更点

### MODAPI_LangToolの追加

ModAPIの言語ファイルを管理する独立WPFツールが追加されました (`LangTool\MODAPI_LangTool.csproj`) — 詳細は上記の**Lang Tool**セクションを参照してください。

---

### バグ修正

| # | ファイル | 問題 | 修正内容 |
|---|---|---|---|
| 1 | `App.xaml.cs` | 非英語のWindowsで.NET例外メッセージにフランス語が混入する | `App()`コンストラクタの先頭で`CultureInfo.InvariantCulture`を固定 |
| 2 | `Game.cs` | `UpdateVersions()`でSSL/TLSエラー — SSL/TLSセキュアチャネルを作成できない | `ServicePointManager.SecurityProtocol`を通じてTLS 1.2を明示的に設定 |
| 3 | `MainWindow.xaml.cs` | パスが設定されているにもかかわらずGreen Hellで`GamePathNotSet`ポップアップが表示される | `App.Game.GamePath`が空 → `Configuration`から保存済みパスを読み込み |
| 4 | `ModsViewModel.cs` | `mods\TheForest\`に手動で配置したモッドファイルがリストに表示されない | ファイル名パターン検証の診断ログを追加 |
| 5 | `MainWindow.xaml.cs` | `MixedGameMods`ポップアップが複数ゲームのモッド選択をブロックする | ブロックポップアップを削除 — `SelectGameDialog`に置き換え |

---

### 新機能

#### ゲーム起動 — ゲーム選択ポップアップ (`SelectGameDialog`)

異なるゲームのモッドが選択されている場合、または**All**フィルターが有効な場合、起動をブロックする代わりにゲーム選択ポップアップが表示されます。

**発動条件:**
- `All`フィルター選択 + Start Gameクリック
- 2つ以上の異なるゲームのモッドが同時に有効化されている

**動作:**
- パスが設定され、実行ファイルが存在するゲームのみ表示
- 選択したゲームのモッドのみが適用される — 他のゲームのモッドは完全に無視される
- ポップアップ終了後、選択したゲームにラジオボタンを同期 (`SyncModGameFilterRadioButton`)

**新規ファイル**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### ゲーム整合性検証 (Releaseビルド専用、`#if !DEBUG`)

ゲーム起動前に毎回3段階の整合性検査が実行されます:

| レイヤー | 方法 | 失敗時 |
|---|---|---|
| A — PEヘッダー | `FileValidator.IsValidGameExe()` | ブロック + `GameExeCorrupted`ポップアップ |
| B — アセンブリチェックサム | MD5 → `Versions.xml`比較 | ブロック + `GameAssemblyTampered`ポップアップ |
| C — デジタル署名 | `HasDigitalSignature()` | 警告 + ユーザー選択 (`GameIntegrityWarning`) |

**新規ファイル**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**`FileValidator.cs`に追加された新規メソッド**:
- `ComputeAssemblyChecksum(managedFolder)` — Assembly-CSharp.dllのMD5ハッシュ (firstpassが存在する場合は含む)
- `HasDigitalSignature(path)` — Authenticode署名の確認

---

### 診断ログの追加

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12項目、Release + Debug)

| # | 段階 | 種類 | 内容 |
|---|---|---|---|
| 1 | TLS設定 | Notice | 変更前後のプロトコル |
| 2 | ダウンロード開始 | Notice | サーバーリスト |
| 3 | URL試行 | Notice | 試行中の各URL |
| 4 | ダウンロード成功 | Notice | URL、レスポンス長、使用されたプロトコル |
| 5 | WebException | Error | URL、HTTPステータス、プロトコル、詳細内容 |
| 6 | その他の例外 | Error | URL、例外の種類、詳細内容 |
| 7 | ダウンロード完了 | Notice | 成功数 / 全サーバー数 |
| 8 | 解析成功 | Notice | 変更前後のファイル数およびバージョン数 |
| 9 | 解析失敗 | Error | 例外の種類および詳細内容 |
| 10 | 保存成功 | Notice | 保存パス、全体のバージョン数/ファイル数 |
| 11 | 保存失敗 | Error | パス、例外の種類、詳細内容 |
| 12 | レスポンスなし | Error | 試行したサーバー、プロトコル |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7項目、`#if DEBUG`のみ)

| # | 状況 | 種類 | 内容 |
|---|---|---|---|
| 1 | スキャン開始 | Notice | Modsフォルダパス、検出された総ファイル数 |
| 2 | 既に読み込み済み | Notice | ファイル名 |
| 3 | .modファイルではない | Notice | ファイル名 |
| 4 | パターンマッチング成功 | Notice | キューに追加されたファイル名 |
| 5 | パターンマッチング失敗 | Warning | ファイル名 + 理由 + 期待される形式 |
| 6 | スキャン完了 | Notice | キュー追加数 / 全ファイル数 |
| 7 | 例外 | Error | 例外の詳細内容 |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10項目、Release + Debug)

| # | 状況 | 種類 | 内容 |
|---|---|---|---|
| 1 | ポップアップ条件 | Notice | 現在のフィルター、選択されたゲームID、needGameSelect |
| 2 | 候補ゲーム | Notice | ポップアップ候補IDリスト |
| 3 | パス未設定 | Notice | ゲームをスキップ — パス未設定 |
| 4 | Configurationに存在しない | Notice | ゲームをスキップ — Configuration.Gamesに存在しない |
| 5 | インストール確認済み | Notice | ゲーム + 実行ファイルパス |
| 6 | 実行ファイルなし | Warning | ゲームをスキップ — 実行ファイルなし |
| 7 | インストール済みゲームなし | Error | 候補0件 → GamePathNotSet |
| 8 | 自動選択 | Notice | 単一候補を自動選択 |
| 9 | ユーザーキャンセル | Notice | SelectGameDialogがキャンセルされた |
| 10 | ゲーム選択 + モッド | Notice | 選択されたゲーム、収集されたモッド数/リスト |

---

### 開発者 / ユーザーログの分離 (`#if DEBUG`)

| ファイル | ログ | 理由 |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | 1秒ごとに繰り返される — 全ログの81% |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | 開発者専用の内部詳細情報 |

Releaseログとして維持: ダウンロード成功/失敗、解析/保存結果、パターンマッチング失敗、例外、整合性検査結果。

---

### バージョンテーブル更新 — アーキテクチャ

#### 設計意図

```
ゲームがSteamアップデートを受信
  → Assembly-CSharp.dllが変更される
  → ModAPIがVersions.xmlの既知チェックサムを確認
  → 見つからない場合 → サーバーから最新のVersions.xmlをダウンロード
  → ModAPIの再インストールなしで新バージョンを自動登録
```

#### 連携構造

```
Settingsタブ → KeepVersionsDataチェックボックス
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → UpdateVersions()呼び出し
      → VersionUpdateDomains[]からVersions.xmlをダウンロード
      → ローカルのconfigs\games\{GameId}\Versions.xmlを上書き
```

#### GitHub Raw URLの統合

`modapi.survivetheforest.net`のみに依存する代わりに、直接管理のためGitHub Raw URLを主要ソースとして使用します:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — 直接管理、優先度1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // レガシーサーバー — フォールバック、優先度2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| 項目 | 詳細内容 |
|---|---|
| デフォルト | GitHub Raw URL — プッシュ後即時反映 |
| フォールバック | レガシーサーバー — GitHubが使用できない場合 |
| パス | リポジトリ内の`ModAPI/configs/games/{GameId}/Versions.xml` |
| 変更ファイル | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Versions.xmlの更新

| ゲーム | ファイル | 変更内容 |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | チェックサム修正 (誤った大文字のSHA-256) — `2.9.5b114117`に正しいMD5を設定 |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID: 20229486) を追加 — 128文字のMD5チェックサム |

---

### 新規言語キー (13言語)

| キー | 英語の値 |
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
| `Lang.Savegames.*` (133キー) | 12言語に英語の値を追加 (DEは既に翻訳済み) |

---

### 変更ファイル

| ファイル | パス | 変更内容 |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | 起動時に`CultureInfo.InvariantCulture`を固定 |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog、整合性検査、MixedGameMods削除、ラジオ同期、10項目ログ |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | 新規 |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | 新規 |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | ファイル名診断ログ、#if DEBUG分離 |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2、UpdateVersions 12項目ログ、GitHub URL、#if DEBUG分離 |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`、`HasDigitalSignature()` |
| 13個の`Language.XX.xaml` | `ModAPI\resources\langs\` | 10個の新規キー + 133個のSavegamesキー (合計515個、全言語一致) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | チェックサム修正 |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12`を追加 |
| `LangTool\` (13ファイル) | ソリューションルート | 新規 |
| `ModAPI.sln` | ソリューションルート | LangTool登録 |

---

### 追加修正およびロギングシステムの全面刷新 (2026-06-21)

#### StartGame検証 — 全面再設計

検証順序を厳密な3段階に是正し、ゲーム選択ポップアップがパス設定の有無にかかわらず、有効化されたモッドのゲームをすべて反映するように修正しました。

| 段階 | 検査項目 | 失敗時のポップアップ |
|---|---|---|
| 1 | Steamインストールの確認 | SteamNotFound |
| 2 | 選択したゲームのパス設定 + 実行ファイルの存在確認 | GamePathNotSet |
| 3 | 選択したゲームに有効化されたモッドが1つ以上存在 | NoModSelected |

- **Allフィルター / 複数ゲームのモッド選択時** → ポップアップは有効化されたモッドがあるゲームを**パス未設定のゲームも含めて**すべて表示 — パスがないゲームを選択した際に静かにリストから外れたり無関係なエラーが出たりする代わりに、正確に`GamePathNotSet`が表示される
- **特定のゲームフィルター選択時** → 該当ゲームに対して同じ1→2→3の順序でパス/モッド検査を直接実行

#### 主要バグ修正

| # | ファイル | 問題 | 修正内容 |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()`が成功した**すべての**サーバー(GitHub + レガシー)のレスポンスをマージしてしまい、両方成功した場合にチェックサムが2倍(64文字→128文字)に壊れる — `GameAssemblyTampered`の誤検知をブロックしてしまう | 最初に成功したサーバーのレスポンスのみを解析し、1か所が成功したら他のサーバーへの試行を停止 |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click`がモッド自身のゲームではなく`App.Game`(現在有効なフィルター)を使用 — TheForestが有効な状態でGreen Hellのモッドを削除すると、無関係なManagedフォルダを探索してしまい削除が静かに失敗する | `mod.Game`(モッドが実際に属するゲームインスタンス)から配布済みDLLパスを検索するよう変更し、`GamePath`が空の場合は`Configuration`から補完 |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | 削除したモッドを再ダウンロードすると、有効化バッジがオンのまま復元される — 削除時に永続保存された`Selected`/`Version`キーやメモリ上のViewModelキャッシュがクリアされていなかった | `Configuration.cs`に`RemoveKey()` / `RemoveKeysWithPrefix()`を追加；`DeleteMod_Click`が削除時に`ModViewModel.Selected = false`を強制設定し、`Mods.{GameId}.{ModId}.*`キーをすべて削除 |
| 4 | `ModsViewModel.cs` | 特定のゲームフィルター("All"以外)が選択された状態でモッドを削除すると、Allに切り替えて戻るまでリストに残り続けているように見える | ファイル削除検出のポーリングループで`_Mods.RemoveAt()`直後の`FilteredMods`変更通知が漏れていた — モッドが実際に削除されるたびに通知が発生するよう修正 |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | 署名なし警告ポップアップの生成/表示中に例外が発生すると、ログ1行も残さずModAPIが静かに強制終了することがあった | ポップアップの生成/表示とメッセージフォーマットをtry-catchで囲み、失敗時は原因をログに記録した上でユーザーが安全に続行できるようにした (署名なしはブロック理由ではなく推奨事項のため) |

#### デジタル署名警告 — メッセージの明確化

`GameNoSignature`の文言に具体的なゲーム名が明示されるようになり、署名なしが改ざんの可能性ではなく**インディーゲームでよくあるケースであり、ゲームの進行に影響がない**ことを明確に案内するようになりました。13言語ファイルすべてで、ゲーム表示名(例: "The Forest"、"Green Hell")が入る`{0}`プレースホルダーを使用するよう更新しました。

#### ロギングシステム — 2ファイル分離

`#if DEBUG`で囲まれていた診断ログを`detailedOnly`フラグへ切り替え、`ModAPI.log`(ユーザー向け)と`ModAPI.detailed.log`(常に全件記録)に分離しました — 詳細は上記の**Log**セクションを参照してください。

#### 変更ファイル (追加分)

| ファイル | パス | 変更内容 |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | StartGame検証の再設計、DeleteMod_Clickのゲームインスタンス修正、GameIntegrityWarningのtry-catch、ゲーム表示名マッピング |
| `Game.cs` | `ModAPI_Shared\Data\` | UpdateVersionsの単一レスポンス修正 |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`、`RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 削除時の`FilteredMods`変更通知、`#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25か所の呼び出し) |
| `Mod.cs` | `ModAPI\Data\` | ヘッダーXMLダンプをdetailedOnlyへ移動、チェックサム不一致の要約化 |
| `Debug.cs` | `ModAPI_Shared\` | `detailedOnly`パラメータ、二重ファイル記録、4段階ロギングガイドコメント |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | `{0}`ゲーム名プレースホルダー、try-catchによる安全処理 |
| 13個の`Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text`をゲーム名プレースホルダー付きで再作成 |

---


</details>

<details>
<summary><b>v2.0.9619の変更点</b></summary>

### バグ修正

- **空のバックアップフォルダによるモッド適用の中断**: `gamefiles\original\`が空 → アセンブリ読み込み前にゲームインストールパスから自動的にバックアップを生成
- **ゲームDLLファイルロック (IOException)**: バックアップが存在する場合、アセンブリリゾルバーがゲームフォルダを条件付きで除外 — `DirectoryCopy`中にCecilがファイルロックを保持することを防止
- **破損したモッドの無限再試行ループ**: 破損したヘッダーの`.mod`ファイルが1秒ごとの再スキャンループを引き起こしていた — `LoadedFiles`に登録することで再スキャンを防止
- **LF改行のモッドファイルが拒否される**: ヘッダーパーサーの`EndsWith("</Mod>\r")`がUnixスタイルの`.mod`ファイルで失敗 — `TrimEnd`を使用してCRLFとLFの両方に対応
- **小型DLLの検証失敗**: `Assembly-UnityScript-firstpass.dll` (21 KB)が`FileValidator`で拒否される — 最小アセンブリサイズを64 KBから8 KBに引き下げ
- **不要なWARNINGログ**: 未設定のゲームパスおよび初回起動時の設定キーがノイズを生成 — `GetPath`/`GetString`/`GetInt`に`silent`パラメータを追加

### 改善事項

- **0バイトダウンロードの検出**: サーバーが空の`.mod`ファイルを返した際にポップアップ通知 + 一時ファイルの整理 (`Lang.Windows.DownloadEmpty`)
- **スライダー保存のデバウンス**: `ModListWidth` / `ProjectListWidth`をピクセル変更ごとではなく、ドラッグ終了後500msに一度だけ`ui.cfg`へ保存
- **条件付きゲームフォルダ生成**: `mods/`および`projects/`フォルダをパスが設定されているゲームのみに生成 — 5つすべてを無条件に生成しない
- **ヘッダー解析の診断ログ**: `.mod`ファイルの解析失敗時に行数と内容のプレビューを表示 (トラブルシューティング用)

### 新規言語キー (13言語)

| キー | 英語の値 |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### 変更ファイル

| ファイル | パス | 変更内容 |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | バックアップ自動生成、条件付きリゾルバー、ゲームフォルダフォールバック |
| `ModLib.cs` | `ModAPI_Shared\Data\` | IncludeAssemblies/CopyAssemblies用ゲームフォルダフォールバック |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | GetPath/GetString/GetIntに`silent`パラメータ |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | 0バイトダウンロード保護、スライダーデバウンス、サイレント設定読み取り、条件付きフォルダ生成 |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | 破損したモッドの再試行防止 |
| `Mod.cs` | `ModAPI\Data\` | LF/CRLFヘッダー解析、診断ログ |
| 13個の`Language.XX.xaml` | `resources\langs\` | `DownloadEmpty`ポップアップキー |

---

</details>

<details>
<summary><b>v2.0.9618の変更点</b></summary>


### MODAPI_VersionToolの追加

ワンクリックでバージョン番号を更新できる独立WPFツールが追加されました (`VersionTool\MODAPI_VersionTool.csproj`) — 詳細は上記の**Version Tool**セクションを参照してください。

- `VersionLabel.Text`がハードコードされた`Version.Descriptor`ではなく`App.Version`を参照するようになったため、リビルド後にStatusBarへ即座に反映されます。

---

</details>

<details>
<summary><b>v2.0.9617の変更点</b></summary>


### Settingsタブ — パスリセットボタンの追加

Steamインストールパスおよび各ゲームインストールパスの行に**Reset**ボタンが追加されました。

**Steamパス行**
```
[TextBox] [Browse] [Save] [Reset]
```

**ゲームパス行 (ゲームごと)**
```
[TextBox] [Browse] [Save] [Reset]
```

**リセット動作**
- 即座にパステキストボックスを初期化
- `ui.cfg`にリセットフラグを保存 (`GamePathReset_{GameId}=1`、`SteamPathReset=1`)
- 再起動後もテキストボックスは空のまま維持
- Configuration XMLが空文字列を保存しない問題を回避

**Browseの自動保存**
- 従来: Browse後に別途Saveボタンのクリックが必要
- 変更後: ファイル選択時に自動保存 — Modsタブへ切り替えた後も反映される

**新規言語キー**

| キー | 値 |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>v2.0.9616の変更点</b></summary>

### Versions.xml — 4ゲームの追加/更新

| ゲーム | ファイルパス | BuildID | 備考 |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 新規作成 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | チェックサム更新 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 新規作成 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | チェックサム更新 |

### チェックサム構成ルール

チェックサム形式は、ゲームごとの`Assembly-CSharp-firstpass.dll`の有無によって異なります。

| ゲーム | firstpass.dll | チェックサム形式 |
|---|---|---|
| GH | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`を連結 (64文字) |
| Subnautica | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`を連結 (64文字) |
| EscapeThePacific | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`を連結 (64文字) |
| Raft | ❌ なし | `Assembly-CSharp MD5`のみ (32文字) |

### ゲームアップデート時のVersions.xml更新手順

既存の項目を削除せずに新しい`<version>`項目を追加します。

**ステップ1 — 新しいBuildIDを探す**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| ゲーム | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**ステップ2 — 新しいチェックサムを抽出**
```powershell
# firstpass.dllがあるゲーム (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → 両方のHash値を順番に連結 (firstpassを先に)

# firstpass.dllがないゲーム (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**ステップ3 — Versions.xmlに項目を追加**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>v2.0.9615の変更点</b></summary>

### Settingsタブ ゲームパス展開の修正

- **カード展開の高さ**: ゲームパスカードを展開した際、入力フィールドの高さ分だけウィンドウ下部が正確に伸びるように修正
- **`UpdateWindowHeight()`の改善**: `SizeToContent.Height`の測定前に`UpdateLayout()`を呼び出す；背景テクスチャが有効な場合、4K画像の元のサイズが高さ計算に影響しないよう`TextureLayer1`を一時的に`Collapsed`に設定
- **内部Grid行の修正**: ゲームパスパネル内部Gridの最後の行を`Height="*"`から`Height="Auto"`に変更 — 不要な下部の余白を削除

---

</details>

<details>
<summary><b>v2.0.9614の変更点</b></summary>

### 最大化ボタンの動作修正

- **最大化**: `WindowState.Maximized`の代わりに`SystemParameters.WorkArea`を使用した手動最大化 — タスクバーと重ならず、現在の画面解像度に正確にフィット
- **復元**: 最大化前に`Left`、`Top`、`Width`、`Height`、`MaxWidth`を保存し、復元ボタンのクリック時に元に戻す
- **`MaxWidth`の処理**: 最大化時は`∞`に設定、通常化時は保存された値に復元

---

</details>

<details>
<summary><b>v2.0.9613の変更点</b></summary>

### 新規Themesタブ

タブの順序が以下のように変更されました:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

テーマ選択UIがSettingsタブから専用の**Themesタブ**へ移動されました。
アイコン: Segoe MDL2 Assets `&#xE790;` (パレット)

### テーマレジストリ (データ駆動型構造)

新しいテーマの追加は`App.xaml.cs`辞書に**1行**追加するだけで完了するようになりました。
すべてのswitch文が削除されました — 他の箇所のコード変更は不要です。

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

`ThemeSelector`のComboBox項目は`ThemeIds`のループから自動生成されます。
言語キー規則: `Lang.Options.Theme.{PascalCase}` (例: `Lang.Options.Theme.Nebula`)

### サポートされているテーマ

| インデックス | ID | ファイル | パレット |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml`のみ | オリジナルModAPIテクスチャ背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明るいトーン + 青のアクセントカラー |
| 2 | `dark` | `FluentStyles.xaml` | 暗いトーン + 青のアクセントカラー (デフォルト) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 赤 + 黒 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 暗い宇宙 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明るい夕焼け |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 暗い海 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明るいノルディック |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明るいシトラス |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明るい花柄 |

テーマ変更時、アプリは自動的に再起動します。(`theme.cfg`に保存)

### 背景テクスチャ機能

Themesタブの**背景テクスチャ**カードで画像を選択すると、アプリ全体の背景として適用されます。選択中のテーマに関係なく動作します。

**サポートされる入力形式**: `.png` / `.jpg` / `.jpeg`、最大50MB、4K解像度以下

**画像処理パイプライン**

```
ユーザー選択画像 (.png / .jpg / .jpeg、最大50MB、4K以下)
  ↓
JPEG Q75圧縮 (メモリバッファ)
  ↓
16バイトのマジックヘッダーを挿入
  "MODAPI" + "BG" + バージョン + パディング (FF 00 FE 00)
  ↓
resources\textures\ui_bg\bg.datとして保存 (隠しファイル属性)
  ↓
SHA-256ハッシュ → ui.cfgにTextureHashとして保存
```

**セキュリティレイヤー**

| レイヤー | 方法 | 効果 |
|---|---|---|
| マジックヘッダー | JPEG署名(FF D8 FF)の前に16バイトを付加 | 外部ビューアーでファイルを認識できない |
| 隠しファイル属性 | `FileAttributes.Hidden` | エクスプローラーからデフォルトで非表示 |
| SHA-256整合性 | 読み込み時にハッシュ検証 | 改ざん検出時に自動リセット + 警告ポップアップ |

**改ざん検出時の動作**
1. `bg.dat`を削除
2. `ui.cfg`のキー`TexturePath`、`TextureHash`、`TextureActive`をリセット
3. テキストボックスおよびトグルをリセット
4. `Lang.Windows.TextureTampered`ポップアップを表示

**ui.cfgのキー**

| キー | 値 | 説明 |
|---|---|---|
| `TexturePath` | ファイル名 (表示用) | テキストボックスに表示される元のファイル名 |
| `TextureHash` | SHA-256 16進数 | 整合性検証ハッシュ |
| `TextureActive` | `true` / `false` | 有効化状態 |

**透明度処理**

背景画像が有効化されると、UI背景は2つのレイヤーで処理されます。

- **レイヤー1 — MergedDictionariesオーバーレイ**: `{DynamicResource FluentBgBrush}`などを参照するパネルが自動的に透明になります。無効化時は単一の`Remove()`呼び出しで復元されます。

  対象キー: `FluentBgBrush`、`FluentBgSecondaryBrush`、`FluentBgTertiaryBrush`、`FluentSurfaceBrush`、`FluentCardBrush`、`FluentTabBarBrush`、`FluentBorderBrush`

- **レイヤー2 — ビジュアルツリー走査 (`WalkStyleBackgrounds`)**: Fluentテーマの`{StaticResource}`要素はレイヤー1の影響を受けないため、元の色を基に半透明ブラシを適用するためビジュアルツリーを直接走査します。

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=完全に透明、255=不透明 → 100 ≈ 39%不透明
  ```

  処理対象: `Panel` (Grid以外)、`Border`、`ListBox` / `ListView`

  除外対象: `Grid` (背景は維持、子要素は走査)、`TabPanel` (タブヘッダー保護)、`ButtonBase` / `ComboBox`、`Collapsed`要素

  復元: スタイルSetterソース → `ClearValue()`、XAMLローカル値ソース → 元のブラシを直接復元

**タブ切り替え**

WPFのTabControlはタブの内容を遅延読み込みするため、タブ変更時に`ContextIdle`優先度で`WalkStyleBackgrounds(this)`を再実行します。既に処理済みの要素は`ContainsKey`チェックによりスキップされます。

**ThemeSelectorのロック**

背景テクスチャが有効化されると、テーマセレクターの上に`ThemeSelectorOverlay`のBorderが表示され、操作をブロックします。

- XAML: `ThemeSelectorOverlay`のBorderがThemeSelectorの上に追加される (`IsHitTestVisible=True`)
- 有効時: `ThemeSelectorOverlay.Visibility = Visible`
- 無効時: `ThemeSelectorOverlay.Visibility = Collapsed`
- `_textureActive`フラグにより`ThemeSelector_SelectionChanged`も保護される

**UI状態の流れ**

```
画像選択 (Browse)
  → bg.dat生成 → トグルのロック解除 → 自動有効化 → TextureLayer1表示
  → SaveAndClearBrushes() → ThemeSelectorOverlay表示

トグル無効化
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay非表示
  → TextureLayer1非表示

Clearボタン
  → bg.dat削除 → トグルロック → TextureLayer1非表示 → ブラシ復元
  → GC.Collect() (4K画像メモリ解放)
```

**新規言語キー**

| キー | 説明 |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7個の新規テーマ名 |
| `Lang.Options.Labels.TextureBackground` | 背景テクスチャラベル |
| `Lang.Options.Labels.TextureEnable` | 有効化ラベル |
| `Lang.Options.Labels.TextureClear` | Clearボタン |
| `Lang.Windows.TextureTooLarge` | ファイルサイズ超過警告 |
| `Lang.Windows.TextureTampered` | 改ざん検出警告 |

**ファイル構造**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Themesタブ、ThemeSelectorOverlay、TextureLayer1
│   └── MainWindow.xaml.cs         # テーマ & テクスチャロジック
├── Themes\
│   ├── Dictionary.xaml            # Classicテーマ
│   ├── FluentStyles.xaml          # Darkテーマ
│   ├── FluentStylesLight.xaml     # Lightテーマ
│   ├── FluentStylesDiablo.xaml    # Diabloテーマ
│   ├── FluentStylesNebula.xaml    # Nebulaテーマ
│   ├── FluentStylesSunset.xaml    # Sunsetテーマ
│   ├── FluentStylesOcean.xaml     # Oceanテーマ
│   ├── FluentStylesNordic.xaml    # Nordicテーマ
│   ├── FluentStylesCitrus.xaml    # Citrusテーマ
│   └── FluentStylesBloom.xaml     # Bloomテーマ
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # 圧縮・セキュア処理された背景画像 (ランタイム生成)
```

**既知の設計上の制約**

| 項目 | 詳細内容 |
|---|---|
| ComboBoxの`IsEnabled=false` | `ElementNotEnabledException`によるクラッシュが発生 → `IsHitTestVisible`オーバーレイ方式を使用 |
| `MergedDictionaries`キーの直接置き換え | レイアウトパス中にクラッシュ → `Add`/`Remove`パターンのみ使用 |
| 隠しファイルの上書き | `Access Denied` → 書き込み前に`FileAttributes.Normal`の再設定が必要 |
| `{StaticResource}`背景 | レイヤー1の影響を受けない → WalkStyleBackgrounds (レイヤー2)が必要 |

---

</details>

<details>
<summary><b>v2.0.9612の変更点</b></summary>

### テーマモジュールの分離

- **新規`Themes/`フォルダ**: `Dictionary.xaml`、`FluentStyles.xaml`、`FluentStylesLight.xaml`、`FluentStylesClassic.xaml`を`ModAPI\Themes\`へ移動
- **`App.xaml.cs`**: `ApplyTheme()` — Classicテーマは`Dictionary.xaml`のみを使用；Light/Dark/その他のFluentテーマは対応するXAMLを読み込み
- **`ModAPI.csproj`**: テーマXAMLパスを`Themes\`サブディレクトリへ更新；`FluentStylesClassic.xaml`を登録

---

</details>

<details>
<summary><b>v2.0.9611の変更点</b></summary>

### バグ修正

- **テーマ切り替え後にMod List幅が適用されない**: Light/Darkテーマの切り替えと再起動後にMod List幅が適用されない問題を修正 — `InitModListWidth()`内に`ApplyModListWidth(width)`呼び出しを追加

---

</details>

<details>
<summary><b>v2.0.9610の変更点</b></summary>

### 追加事項

#### ゲームXML & Versions設定

| # | ファイル | 変更内容 |
|---|------|--------|
| 1 | `GH.xml` | 全面再作成 — 存在しない`DOTweenPro.dll`を削除；`AmplifyBloom/Color/Motion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`を追加 |
| 2 | `Subnautica.xml` | 全面再作成 — `extends="GenericUnityGame"`を削除；`XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll`を追加 |
| 3 | `EscapeThePacific.xml` | 全面再作成 — `extends="GenericUnityGame"`を削除；`includeAssembly` → `Assembly-CSharp.dll`のみ |
| 4 | `Raft/Versions.xml` | 作成 — チェックサム付きバージョン`1.1.01` |
| 5 | `GH/Versions.xml` | 作成 — チェックサム付きバージョン`2.9.5` |
| 6 | `Subnautica/Versions.xml` | 作成 — チェックサムなし (更新頻度が高すぎるため) |

#### 重大なバグ修正

| # | 種類 | 問題 | 修正内容 |
|---|------|-------|-----|
| 1 | ハング | `extends="GenericUnityGame"`により`Assembly-CSharp-firstpass.dll`が継承される → `CreateModLibrary`がハング | 非TheForest XMLから`extends`をすべて削除 |
| 2 | クラッシュ | Subnautica適用中に`ResolutionException: XGamingRuntime.XUserGamertagComponent` | `XGamingRuntime.dll`、`XblPCSandbox.dll`を`copyAssembly`に追加 |
| 3 | クラッシュ | バックアップ生成後に`copyAssembly`へ追加されたDLLでリゾルバーが失敗 | `Game.cs`: 実際のインストールフォルダをリゾルバーフォールバックに追加 |
| 4 | クラッシュ | `CreateModLibrary`と`ApplyMods`の間で`BaseModLib.dll`のファイルロック`IOException` | 再試行ループ: 最大10回×500ms読み取り + 最大30回×500ms存在待機 |
| 5 | クラッシュ | `NullReferenceException` — `typesMap`エントリのValueがnull (ゲーム未インストール) | `if (entry.Value == null) continue`を追加 |
| 6 | クラッシュ | `NullReferenceException` — 軽量`Game`コンストラクタに`ModLibrary = new ModLib(this)`が欠落 → `CreateModLibrary()`がクラッシュ | 軽量コンストラクタに`ModLibrary = new ModLib(this)`を追加 |
| 7 | クラッシュ | `SwitchDevGame()` — 軽量コンストラクタ後に`App.Game.GamePath`が空 → `CreateModLibrary`がクラッシュ | 軽量コンストラクタ後に`App.Game.GamePath = savedPath`を設定 |
| 8 | 誤ったゲーム | `EscapeThePacific`のモッドがTheForestとして分類される | `ModsViewModel`: フォルダパスから`GameId`を抽出 |
| 9 | 誤ったパス | `GetGameFolder()` → `""` → ドライブルートとして解釈される (例: `E:\`) | 全6箇所の呼び出し地点にnull/空値ガードを追加 |

#### Debug / Release ビルド分離

- **`FileValidator.cs`** — 新規ファイル`ModAPI_Shared\Utils\FileValidator.cs`；`ModAPI_Shared.csproj`に登録
  - `IsValidSteamExe()` — PEヘッダー (MZ + PE\0\0) + 最小1 MB
  - `IsValidGameExe()` — PEヘッダー + 最小512 KB
  - `IsValidAssemblyDll()` — PEヘッダー + .NET CLRメタデータヘッダー + 最小8 KB
- **`CheckSteam()`** — `#if DEBUG`: `File.Exists()`のみ / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: `File.Exists()`のみ / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: Cecilを省略した`File.Copy()` / `#else`: 完全なCecil解析 + IL修正
- **`ModLib.Create()` ファイル未検出** — `#if DEBUG`: 警告ログを出力してスキップ / `#else`: エラーログを出力して中断

#### Debugテスト

- **`create_dummy_Debug_games.ps1`** — `bin\Debug\`用PowerShellスクリプト；5つのゲームすべてに対して`dummy_games\`、`dummy_steam\`、`gamefiles\original\`配下に0バイトのダミーファイルを生成 — 実際のゲームをインストールせずに全UIワークフローのテストが可能

#### Settingsタブ

- **Steamパスカード** — Game Installation Pathsカードに統合；`InitSteamPath()`、`SteamBrowse_Click()`、`SteamSave_Click()`
- **ゲームパスパネル** — ゲームごとの展開可能なカードを持つ`BuildGamePathsPanel()`；テキストボックスは`HorizontalAlignment=Stretch`を使用
- **Expand All / Collapse All**ボタン
- **AlwaysOnTop**チェックボックス (`ui.cfg`に保存)
- **Mod/Project List幅**スライダー — 最小値`150`から開始；`ui.cfg`に保存
- **フォントサイズ**ComboBox — FHD 10~16、4K 10~22、8K 10~28
- **チェックボックス同期** — `SettingsCheckboxes.DataContext = SettingsVm`；AutoUpdate / UseSteam / UpdateVersionsが正しく同期されるように修正
- **`_uiInitialized`フラグ** — WPF起動中の`ui.cfg`への早期書き込みを防止

#### Modsタブ — ゲーム起動検証

Start Gameクリック時、モッドリストの状態に関係なく毎回5段階の検証が実行されます:

| 段階 | 検査 | ポップアップ |
|---|---|---|
| 1 | Settingsタブ Steamパスが有効 (`Steam.exe`が存在) | SteamNotFound |
| 2 | `mods/{GameId}/`フォルダのゲームがSettingsで構成されたゲームと一致 | GameModsMismatch |
| 3 | 最低1つのモッドが選択されている | NoModSelected |
| 4 | 複数ゲームのモッドが混在選択されていない | MixedGameMods |
| 5 | ゲームパスの設定 + 実行ファイルの存在確認 | GamePathNotSet / GameNotInstalled |

#### Developmentタブ — ModLib検証

Mod Library Regenerationクリック時に3段階の検証:

| 段階 | 検査 | ポップアップ |
|---|---|---|
| 1 | Settingsタブ Steamパスが有効 | SteamNotFound |
| 2 | 最低1つのプロジェクトが存在 | NoProjectWarning |
| 3 | `App.Game.GamePath`が設定されている | GamePathNotSet |

#### Downloadsタブ
- デバッグ文字列を`Lang.Downloads.Status.NoDownloads`に置き換え
- すべてのステータスメッセージに一貫した余白を適用
- サポートされている5つのゲーム用のオフライン手動テキストを更新；2つのTextBlockで改行

#### First Setup & ゲームパスシステム
- `FirstSetup.Check()` — `UseSteam`、`AutoUpdate`、`UpdateVersions`のデフォルト値を`true`
- `FirstSetupDone()` — 5つのゲームすべてに対して`mods/`および`projects/`フォルダを作成
- `SpecifyGamePath` — `GameNameLabel`にどのゲームかを表示；`NavigateToSettings()`がSettingsタブへ遷移

#### 新規/更新された言語キー

| キー | 英語の値 |
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

### 未実装の項目

| 機能 | 理由 |
|---|---|
| 自動アップデート (最新バージョンの維持) | サーバー側インフラが未構築 |
| アップデート検索 | サーバー側インフラが未構築 |

### 削除された項目

| 項目 | 理由 |
|---|---|
| 起動時の`SpecifyGamePath`ポップアップ | すべてのパスがSettingsタブで設定されるため |
| 起動時の`SpecifySteamPath`ポップアップ | SteamパスがSettingsタブで設定されるため |
| ログインシステム | 元のサーバーの運用終了 (v2.0.9400で削除) |
| `Portable.System.ValueTuple.dll` | Mono 2.0で動作しない (v2.0.9586で削除) |
| Steam検査の`UseSteam`条件 | ゲーム起動およびMod Library Regeneration時にSteamが常に最初に検証されるため |

---

</details>

<details>
<summary><b>v2.0.9600の変更点</b></summary>

### 追加事項

- **Downloadsタブ**: 5つのゲームフィルター (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcomeタブ**: 最も左の位置に追加 (インデックス0)
- **Modsタブ**: 3列レイアウト (WrapPanel → 垂直リスト)；自動幅調整；モッド名の折り返し
- **`ModsViewModel`**: ゲームごとのフィルタリング、モッドごとの正しい`Game`インスタンス用の`ResolveGame()`
- **`Game.cs`**: 軽量コンストラクタ`new Game(config, true)` — 識別専用、`Verify()`なし
- **ビルド**: 4つのゲームXMLファイルが`CopyToOutputDirectory=Always`として`ModAPI.csproj`に登録
- **ビルド**: 警告のクリーンアップ — CS0168、CS0618、CS0252
- **ゲームXML**: TheForest、Raft、GHのDLLリストを修正
- **言語の国旗**: 13言語すべてのバッジで画像サイズを標準化

### 削除された項目

| 項目 | 理由 |
|---|---|
| ゲームXMLファイルの`extends="GenericUnityGame"` | `Assembly-CSharp-firstpass.dll`が誤って継承される問題 — Subnautica、Raft、EscapeThePacific、GHから削除 |
| Modsタブの`WrapPanel`レイアウト | 3列Gridレイアウトに置き換え (Game Filter / Mod List / Information) |

---

</details>

---

## バージョン履歴

<details>
<summary><b>Phase 6-3 — テーマシステム拡張、設定改善、安定性 & ツール追加</b></summary>

### v2.0.9620 — 2026-06-21

**MODAPI_LangToolおよび主要な修正**
- MODAPI_LangToolを追加 (独立WPF言語管理ツール)
- SSL/TLS修正 (TLS 1.2)
- フランス語混入の修正 (`CultureInfo.InvariantCulture`)
- Green Hellの`GamePathNotSet`修正
- SelectGameDialog (Allフィルター + マルチゲームモッド起動)
- MixedGameModsのブロックを削除
- 3段階のゲーム整合性検証 (PEヘッダー / アセンブリチェックサム / デジタル署名)
- 開発者/ユーザーログの分離
- UpdateVersions 12項目 + FindMods 7項目 + StartGame 10項目のログ
- GitHub Raw URLを優先適用 (`VersionUpdateDomains`)
- GHの`Versions.xml`チェックサム修正
- TheForestの`Versions.xml`に`1.12`を追加
- 13言語ファイル515キーの完全一致

**追加修正 (2026-06-21)**
- StartGame検証順序の修正 (Steam → ゲームパス → モッド)
- ゲーム選択ポップアップがパス未設定のゲームも正確に表示
- UpdateVersionsの単一レスポンス処理でチェックサム重複問題を解決
- `DeleteMod`が現在有効なフィルターではなくモッド自身のゲームインスタンスを使用
- 削除したモッドの再ダウンロード時に有効化バッジが残存する問題を解決
- ゲームフィルターの状態にかかわらずモッド削除後即座にリストを更新
- `GameIntegrityWarning`ポップアップの強制終了を防止
- デジタル署名警告メッセージにゲーム名を明示し、インディーゲームに関する案内を改善
- 2ファイルロギングシステム(`ModAPI.log` / `ModAPI.detailed.log`)へ`#if DEBUG`ログを移行 — Releaseビルドでも全診断ログを確保しつつユーザー画面はクリーンに維持

### v2.0.9619 — 2026-05-25

- ゲームインストールパスからの自動バックアップ生成
- ファイルロック修正 (条件付きリゾルバー)
- 破損モッドの無限再試行を防止
- LF改行のモッドファイルに対応
- 0バイトダウンロード検出ポップアップ
- スライダー保存のデバウンス (500ms)
- 条件付きゲームフォルダ生成
- `FileValidator`の最小アセンブリサイズを64 KB → 8 KBに変更
- `GetPath`/`GetString`/`GetInt`の`silent`パラメータ
- ヘッダー解析の診断ログ
- `DownloadEmpty`言語キー (13言語)

### v2.0.9618 — 2026-04-25
MODAPI_VersionToolを追加 (独立WPFバージョン更新ツール)、StatusBarのバージョン表示をApp.Versionに連動

### v2.0.9617 — 2026-04-24
Settingsタブに Steam/ゲームパスのリセットボタンを追加、Browseの自動保存、ui.cfgフラグによるリセット状態の保持

### v2.0.9616 — 2026-04-18
4つのゲームのVersions.xmlを作成/更新 (Subnautica, Raft, EscapeThePacific, GH)、チェックサム構成ルールを確立、ゲームアップデート手順を文書化

### v2.0.9615 — 2026-04-18
Settingsタブのゲームパスカード展開高さの精度を修正、UpdateWindowHeightの背景テクスチャ干渉を防止

### v2.0.9614 — 2026-04-18
最大化ボタンのWorkAreaベース手動最大化、以前のサイズ/位置の保存と復元

### v2.0.9613 — 2026-04-18
Themesタブを追加、テーマレジストリのデータ駆動型構造、10種類のテーマ対応、背景テクスチャ機能 (圧縮、セキュリティ、2レイヤー透明度)、ThemeSelectorロックオーバーレイ、12個の新規言語キー

### v2.0.9612 — 2026-04-18
Themes/フォルダの分離、テーマXAMLのモジュール化

### v2.0.9611 — 2026-04-18
テーマ切り替え後にMod List幅が適用されない問題を修正

</details>

<details>
<summary><b>Phase 6-2 — 設定、パスの安全化、クラッシュ修正 & Debug/Release分岐</b></summary>

### v2.0.9610 — 2026-04-13

- マルチゲームXMLの修正 (GH, Subnautica, EscapeThePacific)
- `Versions.xml`を追加
- Settingsタブの再設計 (Steamパス、ゲームパスパネル、幅スライダー、フォントサイズ、チェックボックス同期)
- ゲームパスのnull安全処理 (6箇所)
- 起動時ポップアップをSettingsタブに置き換え
- Modsタブの5段階ゲーム起動検証 (Steamを常に最初に検証)
- Devタブの3段階ModLib検証
- `GameModsMismatch`ポップアップを追加
- 軽量コンストラクタの`ModLibrary` null修正
- `SwitchDevGame`の`GamePath`修正
- `FileValidator`のPEヘッダー検証 (Release)
- `#if DEBUG`ビルド分離 (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- 永続的な`ui.cfg`
- 5段階フォントシステム
- 多数のクラッシュ修正
- 言語キーの更新

</details>

<details>
<summary><b>Phase 6-1 — マルチゲーム & Mods再設計</b></summary>

### v2.0.9600 — 2026-04-09
> 5つのゲームフィルター、Modsタブの3列レイアウト、自動幅調整、軽量`Game`コンストラクタ、`ModsViewModel`のゲームフィルタリング、4つのXMLファイルの登録、ビルド警告のクリーンアップ、Welcomeタブ、言語国旗の標準化

</details>

<details>
<summary><b>Phase 5-6B — C# 7.3 & ポリフィル</b></summary>

### v2.0.9586 — 2026-03-31
> ブラックスクリーン修正、ポリフィル確定、ValueTupleの削除、C# 7.3検証

</details>

<details>
<summary><b>Phase 5-5 — アセンブリ解決</b></summary>

### v2.0.9561 — 2026-03-06
> C# 7.3サポート、PEヘッダーパッチング、ポリフィルパイプライン、アセンブリ解決の復元

</details>

<details>
<summary><b>Phase 5-1 — Downloadsタブ & 13言語</b></summary>

### v2.0.9552 — 2026-02-25
> Downloadsタブ、アイコンの近代化、テーマの統一、13言語対応

</details>

<details>
<summary><b>初期段階</b></summary>

### Phase 3 — UI再設計 & テーマシステム
v2.0.9500
> テーマシステム (Classic/Light/Dark)、Fluent Design UI、SubWindowシステム

### Phase 4 — コード整理
v2.0.9400
> コード整理、ログイン削除、レガシーの近代化

### Phase 2 — ビルド環境 & Fluent Design
v2.0.9300
> ビルド環境、UnityEngineスタブDLL、ModernWpf統合

### Phase 1 — .NET 4.8移行
v2.0.9200
> .NET Framework 4.8への移行

### v1.x
オリジナルFluffyFishリリース

</details>

---

## ビルド要件

| 要件 | バージョン | 備考 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPIプロジェクト用 |
| .NET Framework SDK | 3.5 | BaseModLibのみ |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `libs/polyfills/`の`System.Threading.dll` |

---

## ライセンス

GNU General Public License v3.0 — オリジナルのライセンスに準拠します。
