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

**The Forest Mod管理ツール — アップグレード版**

> 原作: FluffyFish / Philipp Mohrenstecher (ドイツ・エンゲルスキルヘン)
> アップグレード: zzangae (大韓民国)

---

## 概要

ModAPIは**公式サポート5ゲーム**のModを管理するデスクトップアプリケーションです。このアップグレード版はマルチゲームサポート、完全に再設計されたSettingsタブ、Steamパス設定、永続的なUI設定、動的フォントサイズシステム、ゲーム起動時バリデーション、Debug/Releaseビルド分離、および実ゲームテストで確認された多数のクラッシュ修正を含みます。

---

## 対応ゲーム

| ゲーム | エンジン | バージョン | Steam ID | 実行ファイル |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (ベータ) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 5（Unity 4からアップグレード） |
| 最新バージョン | v1.12 (VR) |
| 最終更新 | 2019年9月11日 — VRサポートパッチ；以降の主要コンテンツ更新なし |
| 実行ファイル | `TheForest.exe` |
| データフォルダ | `TheForest_Data/Managed/` |
| Modsフォルダ | `mods/TheForest/` |
| プロジェクトフォルダ | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 完全サポート |

Unity 4からUnity 5にアップグレードされ、ビジュアルと物理効果が大幅に改善されました。2019年9月のVRパッチが最後の主要アップデートでした。ゲームは安定した最終状態を維持しており、MOD制作に最適な環境です。
</details>

<details>
<summary><b>Subnautica</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity（2022年にBelow Zeroと統合されたコードベース） |
| 最新バージョン | 2025 Patch (v18810395) |
| 最終更新 | 2025年8月12日 — モバイルリリースに伴うバグ修正とパフォーマンス改善 |
| 実行ファイル | `Subnautica.exe` |
| データフォルダ | `Subnautica_Data/Managed/` |
| Modsフォルダ | `mods/Subnautica/` |
| プロジェクトフォルダ | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — サポート |

元々Unity 5で構築されたSubnauticaは、2022年末に'Living Large'アップデート（v2.0）を受け、Below Zeroとエンジンコードベースを統合して最適化と安定性を強化しました。注：次回作*Subnautica 2*はUnreal Engine 5を使用します。

> **v2.0.9610でXML再作成**：`XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll`を`copyAssembly`に追加。
</details>

<details>
<summary><b>RAFT</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity |
| 最新バージョン | v1.1.02（ベータ）/ v1.09（安定版） |
| 最終更新 | 2026年3月 — ベータブランチでのボイスチャットとマルチプレイヤーバグ修正 |
| 実行ファイル | `Raft.exe` |
| データフォルダ | `Raft_Data/Managed/` |
| Modsフォルダ | `mods/Raft/` |
| プロジェクトフォルダ | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — サポート |
| Versions.xml | `1.1.01`（チェックサム付き） |

v1.0: *The Final Chapter*での公式ストーリー完結後も、ネットワークコードの改善と安定性のためのパッチが継続されています。
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 6（2025年末にUnity 2021/2022から移行） |
| 最新バージョン | v0.67.0.0 |
| 最終更新 | 2025年6月26日 — 島分布の再構築とエンジン更新；2026年にかけてホットフィックス継続 |
| 実行ファイル | `EscapeThePacific.exe` |
| データフォルダ | `EscapeThePacific_Data/Managed/` |
| Modsフォルダ | `mods/EscapeThePacific/` |
| プロジェクトフォルダ | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — サポート |

2025年末に大規模なシステム再構築とUnity 6移行を完了し、よりダイナミックな環境を実現しました。アーリーアクセス開発が継続中です。

> **v2.0.9610でXML再作成**：`extends="GenericUnityGame"`を削除；`includeAssembly`を`Assembly-CSharp.dll`のみに設定 — `Assembly-CSharp-firstpass.dll`の継承エラーを防止。
</details>

<details>
<summary><b>Green Hell</b></summary>

| 項目 | 値 |
|---|---|
| エンジン | Unity 2019 |
| 最新バージョン | v2.9.5 |
| 最終更新 | 2026年2月4日 — Steam Deck最適化とテキスト可読性の改善 |
| 実行ファイル | `GH.exe` |
| データフォルダ | `GH_Data/Managed/` |
| Modsフォルダ | `mods/GH/` |
| プロジェクトフォルダ | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — サポート |
| Versions.xml | `2.9.5`（チェックサム付き） |

開発を通じてUnity 2017 → 2018 → 2019と段階的にエンジンをアップグレードしました。2026年2月のホットフィックスはSteam Deck互換性とUIテキストの可読性向上に焦点を当てました。

> **v2.0.9610でXML再作成**：`AmplifyBloom.dll`、`AmplifyColor.dll`、`AmplifyMotion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`を追加；存在しない`DOTweenPro.dll`を削除。
</details>

---

## アーキテクチャ

### ランタイム分離

| コンポーネント | ターゲット | ランタイム | 理由 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | デスクトップアプリケーション、完全な最新API |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 共有ライブラリ |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **永久固定** — PEヘッダーは`v2.0.50727`を含む必要あり |
| Mod DLL（ユーザー） | .NET Framework 4.8 | Game Mono 2.0（パッチ済） | 4.8でビルド、適用時にPEヘッダーをパッチ |

### Debug / Release ビルド分離

すべてのファイル検証とアセンブリ処理は`#if DEBUG` / `#else`によるビルド構成で分岐します。

| 場所 | Debugビルド | Releaseビルド |
|---|---|---|
| `CheckSteam()` | `File.Exists()`のみ — ダミーファイルが通過 | `FileValidator.IsValidSteamExe()` — PEヘッダー + 最小1 MB |
| `CheckGamePath()` | `File.Exists()`のみ — ダミーファイルが通過 | `FileValidator.IsValidAssemblyDll()` — PEヘッダー + CLRメタデータ + 最小64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — Cecil解析をスキップ | 完全なMono.Cecil解析 + IL変更 + `module.Write()` |
| `ModLib.Create()` — ファイル未検出 | 警告を記録、スキップして続行 | エラーを記録、ポップアップで中止 |

**Debugテスト**は`create_dummy_Debug_games.ps1`を使用して`bin\Debug\dummy_games\`、`bin\Debug\dummy_steam\`、`bin\Debug\gamefiles\original\`配下に0バイトのプレースホルダーファイルを生成します。これらは`File.Exists()`チェックを通過し、実際のゲームインストールなしでUIワークフロー全体のテストを可能にします。

**Releaseビルド**は`FileValidator`（PEヘッダー + .NET CLRメタデータ検証）を適用して、0バイトファイル、テキストファイル、任意のバイナリを拒否します。有効なWindows実行ファイルと.NETアセンブリのみが通過します。

### FileValidator — PEヘッダー検証

`ModAPI_Shared\Utils\FileValidator.cs` — Releaseビルドのみで適用。

| メソッド | チェック内容 | 最小サイズ |
|---|---|---|
| `IsValidSteamExe(path)` | MZシグネチャ + PE\0\0シグネチャ | 1 MB |
| `IsValidGameExe(path)` | MZシグネチャ + PE\0\0シグネチャ | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + CLRメタデータヘッダー（データディレクトリ #14） | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### アセンブリリマッピングパイプライン

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

### アセンブリリゾルバーフォールバック

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### C# 7.3 機能サポート

| 機能 | 状態 | 備考 |
|---|---|---|
| パターンマッチング (`is`, `switch`) | ✅ | ゲーム内で検証済み |
| 文字列補間 (`$""`) | ✅ | ゲーム内で検証済み |
| インライン`out`変数 | ✅ | ゲーム内で検証済み |
| `async` / `await` | ✅ | AsyncBridge + System.Threadingポリフィル経由 |
| タプル (`ValueTuple`) | ❌ 絶対的制限 | Mono 2.0 `mscorlib` ABI — 回避策なし |

### テーマシステム

v2.0.9613より、テーマ選択UIはSettingsタブから専用の**Themesタブ**に移動しました。新しいテーマの追加には`App.xaml.cs`のディクショナリに1行追加するだけです。

| インデックス | ID | ファイル | パレット |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` のみ | オリジナルModAPIテクスチャ背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明るいトーン + 青アクセント |
| 2 | `dark` | `FluentStyles.xaml` | 暗いトーン + 青アクセント（デフォルト） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 赤 + 黒 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | ダークスペース |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明るいサンセット |
| 6 | `ocean` | `FluentStylesOcean.xaml` | ダークオーシャン |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明るいノルディック |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明るいシトラス |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明るいフローラル |

テーマ変更時にアプリが自動再起動します。（`theme.cfg`に保存）

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

### 背景テクスチャ

Themesタブの**Background Texture**カードで画像を選択すると、アプリ全体の背景として適用されます。対応入力形式：`.png` / `.jpg` / `.jpeg`、最大50MB、4K以下の解像度。画像はJPEG Q75で圧縮され、16バイトのマジックヘッダー付きで`resources\textures\ui_bg\bg.dat`にHidden属性で保存されます。SHA-256ハッシュで整合性を検証し、改ざん検出時は自動リセット+警告ポップアップが表示されます。

背景がアクティブな場合、UIの透明化は2層で処理されます：Layer 1（MergedDictionaries オーバーレイ）は`{DynamicResource}`パネルを、Layer 2（WalkStyleBackgrounds）は`{StaticResource}`ベースのパネルを半透明化します。

### フォントサイズシステム

| リソースキー | ベース | 説明 |
|---|---|---|
| `AppBaseFontSize` | 13 | 通常テキスト |
| `AppBaseHeaderFontSize` | 16 | ヘッダー、パネルタイトル |
| `AppBaseSmallFontSize` | 12 | サブラベル |
| `AppBaseTinyFontSize` | 10 | ヒントテキスト |
| `AppBaseLargeFontSize` | 20 | 大型表示テキスト |

### 永続UIコンフィグ — `ui.cfg`

| キー | デフォルト | 説明 |
|-----|---------|-------------|
| `ModListWidth` | `150` | Modsタブリスト幅 (px) |
| `ProjectListWidth` | `150` | 開発タブプロジェクトリスト幅 (px) |
| `AppFontSize` | `13` | グローバルUIフォントサイズ (px) |
| `AlwaysOnTop` | `false` | ウィンドウ常に最前面 |
| `TexturePath` | *(なし)* | 背景テクスチャ元ファイル名（表示用） |
| `TextureHash` | *(なし)* | 背景テクスチャSHA-256ハッシュ |
| `TextureActive` | `false` | 背景テクスチャ有効化状態 |
| `GamePathReset_{GameId}` | *(なし)* | ゲームパスリセットフラグ |
| `SteamPathReset` | *(なし)* | Steamパスリセットフラグ |

### ファイル構造

```
ModAPI/
├── App.xaml / App.xaml.cs              # テーマ登録、テーマID、テーマ適用
├── ui.cfg                               # 永続UIセッティング
├── theme.cfg                            # 現在のテーマ
├── Windows/
│   ├── MainWindow.xaml / .cs            # メインUI — 6タブ、テーマ、設定、Steamパス
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # ゲームパスポップアップ（動的GameNameLabel）
│       ├── FirstSetup.xaml / .cs        # 初回セットアップ + デフォルト初期化
│       └── （他14個のSubWindow）
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
│   ├── Game.cs                          # アセンブリパッチ、nullガード、解析器代替
│   ├── ModLib.cs                        # BaseModLib生成 + 再マッピング（#if DEBUG分岐）
│   ├── Models/
│   │   └── ModProject.cs                # プロジェクト作成/ビルド/適用 + nullガード
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # フィルタ済みMod、選択Mod、選択ゲームフィルター
│   │   ├── ModViewModel.cs              # フォルダパスからGameId取得
│   │   ├── ModProjectsViewModel.cs      # DispatcherTimer用Dispose()
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersionsのデフォルトtrue
│   └── AssemblyVersionMap.cs            # Mono 2.0アセンブリバージョンマッピング（20アセンブリ）
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 名前ベースの解析器（キャッシュ付き）
│   └── MonoHelper.cs                    # Mono.Cecil ILヘルパーユーティリティ
├── resources/
│   ├── langs/                           # 13言語ファイル
│   └── textures/ui_bg/
│       └── bg.dat                       # 圧縮・保護済み背景画像（実行時生成）
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # v2.0.9610で全面書き換え
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # v2.0.9610で全面書き換え
    │   ├── GH.xml                       # v2.0.9610で全面書き換え
    │   ├── SonsOfTheForest.xml          # IL2CPP — 非サポート
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # 軽量コンストラクター + ModLibrary初期化修正
│   └── ModLib.cs                        # Cecil解析の#if DEBUG分岐
└── Utils/
    └── FileValidator.cs                 # PEヘッダー + CLRメタデータ検証（Releaseのみ）

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # スタンドアロンWPFバージョン更新ツール

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # ダミーゲーム/Steam構造を生成
├── dummy_games\{GameId}\               # ダミーゲームインストールパス
├── dummy_steam\Steam.exe               # ダミーSteam実行ファイル
└── gamefiles\original\{GameId}\        # ModLib用ダミーバックアップパス
```

---

## インストールとセットアップ

### ステップ1 — 前提条件

| 項目 | 必須 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ （Windows 11にプリインストール済み；Windows 10は[ダウンロード](https://dotnet.microsoft.com/download/dotnet-framework/net48)） |
| Steam | 必須 — Settingsタブで設定が必要 |
| サポート対象ゲーム1つ以上 | 必須 — Settingsタブで設定が必要 |

### ステップ2 — ModAPIをインストール

1. GitHubから最新リリースをダウンロード
2. 任意のフォルダに展開（例：`C:\ModAPI\`）
3. `ModAPI.exe`を実行
4. 初回起動時に**Welcome**画面が表示 — 設定を行い**Continue**をクリック

### ステップ3 — Steamパスを設定（Settingsタブ）

1. **Settings**タブに移動
2. **Steam Installation Path**を見つける
3. **Browse**をクリック → `Steam.exe`を選択
4. **Save**をクリック

### ステップ4 — ゲームパスを設定（Settingsタブ）

1. ゲームカードのヘッダーをクリックして展開
2. **Browse**をクリック → ゲームのルートフォルダ（`.exe`がある場所）を選択
3. **Save**をクリック

| ゲーム | 実行ファイル | パスの例 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### ステップ5 — Modをダウンロード（Downloadsタブ）

1. **Downloads**タブに移動
2. ゲームフィルターからゲームを選択
3. Modを検索して**Download**をクリック

> **オフライン**：`modapi.survivetheforest.net`から`.mod`ファイルを手動でダウンロードし、対応するフォルダに配置：

| ゲーム | フォルダ |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### ステップ6 — Modを適用してゲームを開始（Modsタブ）

1. **Mods**タブに移動
2. **ゲームフィルター**（列0）からゲームを選択
3. **Modリスト**（列1）で有効化するModにチェック
4. **Start Game**をクリック

起動前に以下のチェックが自動実行されます：

| # | チェック内容 | エラーポップアップ |
|---|---|---|
| 1 | Steamパスが設定済みかつ有効 | SteamNotFound |
| 2 | `mods/`フォルダのゲームがSettingsのゲームパスと一致 | GameModsMismatch |
| 3 | 少なくとも1つのModが選択済み | NoModSelected |
| 4 | 選択に混合ゲームModなし | MixedGameMods |
| 5 | ゲームパスが設定済みかつ実行ファイルが存在 | GamePathNotSet / GameNotInstalled |

---

## タブ概要

### Welcomeタブ
初回設定画面（タブインデックス0）。AutoUpdate、Steam接続、VersionsDataテーブルの設定を行います。以降の起動時はコミュニティリンクとリリースノートを提供します。

### Modsタブ
主要なMod管理ワークフロー — 3列レイアウト：

| 列 | 内容 |
|---|---|
| 列0 | ゲームフィルター — 5つのサポートゲーム用ラジオボタン |
| 列1 | Modリスト — バージョン選択と有効化チェックボックス付きのインストール済みMod |
| 列2 | 情報 — 選択したModの詳細、説明、バージョン履歴 |

### Downloadsタブ
`modapi.survivetheforest.net`からModを閲覧・ダウンロード。

- **ゲームフィルター**：TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **カテゴリフィルター**：12カテゴリ（Bugfixes、Balancing、Cheats、…）
- **検索**：Mod名、説明、または作者で検索
- **オフラインモード**：5つのサポートゲームすべてのフォルダ手順を表示

### Developmentタブ
Mod開発ワークフロー — ゲームフィルターパネル（列0）は5つのサポートゲームすべてを網羅。

- ゲームごとにModプロジェクトを作成、ビルド、適用
- 言語リソース管理
- 3ステップ検証によるModLib生成（Steam → プロジェクト → ゲームパス）
- 軽量`Game`コンストラクターによる安全なゲーム切替（`Verify()`呼び出しなし）

### Themesタブ
テーマ選択と背景テクスチャ管理画面。

- **テーマ選択**: 10種テーマ (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **背景テクスチャ**: 画像を選択してアプリ全体の背景として適用（JPEG圧縮 + セキュリティ処理）
- 背景テクスチャが有効な場合、テーマ選択がロックされます

### Settingsタブ
統合設定画面 — 4行構成：

| 行 | 内容 |
|---|---|
| 0 | 言語 / フォントサイズ / テーマ / 最大幅 / Modリスト幅 / プロジェクトリスト幅 |
| 1 | VersionsData保持 / 自動更新 / Steam接続 / 常に最前面 |
| 2 | Steamインストールパス（TextBox + 参照 + 保存 + リセット） |
| 3 | ゲームインストールパス — ゲームごとの展開可能カード（TextBox + 参照 + 保存 + リセット） |

---

## v2.0.9618の変更点

### バージョン更新ツール (MODAPI_VersionTool)

ワンクリックでバージョン番号を更新できるスタンドアロンWPFツールです。

**場所**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**機能**
- 現在のバージョンを自動表示（`App.xaml.cs`から読み取り）
- 新しいバージョンを入力し**Apply Version**をクリックすると両方のファイルを同時に更新
- フォーマット検証：`X.X.XXXX`形式のみ受付

**変更対象ファイル**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**使用手順**
1. Run `MODAPI_VersionTool.exe`
2. 新しいバージョンを入力（例：`2.0.9619`）
3. Click **Apply Version**
4. Visual StudioでModAPIソリューションを再ビルド

### StatusBarバージョン表示修正

- `VersionLabel.Text`がハードコードされた`Version.Descriptor`の代わりに`App.Version`を参照するように変更
- VersionToolでバージョンを更新して再ビルドすると、StatusBarに即座に反映されるように

---

## v2.0.9617の変更点

### Settingsタブ — パスリセットボタン追加

Steamインストールパスと各ゲームインストールパスの行に**リセット**ボタンが追加されました。

**Steamパス行**
```
[TextBox] [Browse] [Save] [Reset]
```

**ゲームパス行（ゲームごと）**
```
[TextBox] [Browse] [Save] [Reset]
```

**リセット動作**
- パスTextBoxを即座にクリア
- リセットフラグを`ui.cfg`に保存（`GamePathReset_{GameId}=1`、`SteamPathReset=1`）
- 再起動後もTextBoxは空のまま維持
- Configuration XMLが空文字列を保存しない制限を回避

**Browse自動保存**
- 以前：Browse後にSaveボタンを別途クリックする必要があった
- 以後：ファイル選択時に自動保存 — Modsタブに切り替えた後も反映

**新規言語キー**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## v2.0.9616の変更点

### Versions.xml — 4ゲーム追加/更新

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 新規作成 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | チェックサム更新 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 新規作成 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | チェックサム更新 |

### チェックサム構成ルール

チェックサムの形式はゲームごとに`Assembly-CSharp-firstpass.dll`が存在するかどうかによって異なります。

| ゲーム | firstpass.dll | チェックサム形式 |
|---|---|---|
| GH | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`連結（64文字） |
| Subnautica | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`連結（64文字） |
| EscapeThePacific | ✅ あり | `firstpass MD5` + `Assembly-CSharp MD5`連結（64文字） |
| Raft | ❌ なし | `Assembly-CSharp MD5`のみ（32文字） |

### ゲーム更新時のVersions.xml更新手順

既存のエントリを削除せずに新しい`<version>`エントリを追加します。

**ステップ1 — 新しいBuildIDを確認**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**ステップ2 — 新しいチェックサムを抽出**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**ステップ3 — Versions.xmlにエントリを追加**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## v2.0.9615の変更点

### Settingsタブ ゲームパス展開修正

- **カード展開時の高さ**：ゲームパスカードを展開する際、ウィンドウ下端が入力フィールドの高さ分だけ正確に伸びるように修正
- **`UpdateWindowHeight()`改善**：`SizeToContent.Height`測定前に`UpdateLayout()`を呼び出し；背景テクスチャがアクティブな場合`TextureLayer1`を一時的に`Collapsed`に設定して4K画像の元サイズが高さ計算に影響しないように
- **内部Grid Row修正**：ゲームパスパネルの内部Gridの最後のRowを`Height="*"`から`Height="Auto"`に変更 — 不要な下部空白を除去

---

## v2.0.9614の変更点

### 最大化ボタン動作修正

- **最大化**：`WindowState.Maximized`の代わりに`SystemParameters.WorkArea`を使用して手動最大化 — タスクバーと重ならず現在の画面解像度に正確にフィット
- **復元**：最大化前に`Left`、`Top`、`Width`、`Height`、`MaxWidth`を保存し、復元ボタンクリック時に復元
- **`MaxWidth`処理**：最大化時に`∞`に設定、通常化時に保存値を復元

---

## v2.0.9613の変更点

### 新規Themesタブ

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

テーマ選択UIがSettingsタブから専用の**Themesタブ**に移動されました。
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### テーマレジストリ（データ駆動構造）

新しいテーマの追加は`App.xaml.cs`ディクショナリの**1行**のみで可能になりました。
すべてのswitch文が削除され、他の箇所でのコード変更は不要です。

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
言語キー規則：`Lang.Options.Theme.{PascalCase}`（例：`Lang.Options.Theme.Nebula`）

### サポートテーマ

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml`のみ | オリジナルModAPIテクスチャ背景 |
| 1 | `light` | `FluentStylesLight.xaml` | 明るいトーン + 青アクセント |
| 2 | `dark` | `FluentStyles.xaml` | 暗いトーン + 青アクセント（デフォルト） |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 赤 + 黒 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | ダークスペース |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 明るいサンセット |
| 6 | `ocean` | `FluentStylesOcean.xaml` | ダークオーシャン |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 明るいノルディック |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 明るいシトラス |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 明るいフローラル |

テーマ変更時にアプリが自動再起動します。（`theme.cfg`に保存）

### 背景テクスチャ機能

Themesタブの**Background Texture**カードで画像を選択すると、アプリ全体の背景として適用されます。どのテーマが選択されていても動作します。

**対応入力形式**：`.png` / `.jpg` / `.jpeg`、最大50MB、4K以下の解像度

**画像処理パイプライン**

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

**セキュリティ層**

| 層 | 方法 | 効果 |
|---|---|---|
| マジックヘッダー | JPEGシグネチャ(FF D8 FF)の前に16バイト挿入 | 外部ビューアがファイルを認識不可 |
| Hidden属性 | `FileAttributes.Hidden` | エクスプローラのデフォルト設定で非表示 |
| SHA-256整合性 | ロード時にハッシュ検証 | 改ざん検出時に自動リセット + 警告ポップアップ |

**改ざん検出時の動作**
1. `bg.dat` deleted
2. `ui.cfg`のキー`TexturePath`、`TextureHash`、`TextureActive`をリセット
3. TextBoxとトグルをリセット
4. `Lang.Windows.TextureTampered`ポップアップを表示

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**透明化処理**

背景画像がアクティブな場合、UIの背景は2層で処理されます。

- **Layer 1 — MergedDictionariesオーバーレイ**：`{DynamicResource FluentBgBrush}`等を参照するパネルが自動的に透明化されます。非アクティブ化時は`Remove()`一回で復元されます。

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — ビジュアルツリー走査（`WalkStyleBackgrounds`）**：FluentテーマのStaticResource要素はLayer 1の影響を受けないため、ビジュアルツリーを直接走査して元の色に基づく半透明ブラシを適用します。

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  処理対象：`Panel`（Grid除く）、`Border`、`ListBox` / `ListView`

  処理除外：`Grid`（背景保持、子要素は走査継続）、`TabPanel`（タブヘッダー保護）、`ButtonBase` / `ComboBox`、`Collapsed`要素

  復元方式：Style Setter出処 → `ClearValue()`、XAMLローカル値出処 → 元のブラシを直接復元

**タブ切り替え**

WPF TabControlはタブコンテンツを遅延読み込みするため、タブ切替時に`ContextIdle`優先度で`WalkStyleBackgrounds(this)`を再実行します。処理済みの要素は`ContainsKey`チェックでスキップされます。

**ThemeSelectorロック**

背景テクスチャがアクティブな場合、テーマセレクター上に`ThemeSelectorOverlay` Borderが表示され、操作がブロックされます。

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged`も`_textureActive`フラグで二重ガード

**UI状態フロー**

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

**新規言語キー**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**ファイル構造**

```
ModAPI\
├── App.xaml.cs                    # テーマ登録、テーマID、テーマ適用
├── Windows\
│   ├── MainWindow.xaml            # Themesタブ、テーマ選択オーバーレイ、テクスチャレイヤー1
│   └── MainWindow.xaml.cs         # テーマ・テクスチャロジック
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
            └── bg.dat             # 圧縮・保護済み背景画像（実行時生成）
```

**既知の設計制約**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| `MergedDictionaries`キーの直接置換 | レイアウトパス中にクラッシュ → `Add`/`Remove`パターンのみ使用 |
| Hiddenファイルの上書き | `Access Denied` → 書き込み前に`FileAttributes.Normal`に初期化必須 |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## v2.0.9612の変更点

### テーマモジュール分離

- **新規`Themes/`フォルダ**：`Dictionary.xaml`、`FluentStyles.xaml`、`FluentStylesLight.xaml`、`FluentStylesClassic.xaml`を`ModAPI\Themes\`に移動
- **`App.xaml.cs`**：`ApplyTheme()` — Classicテーマは`Dictionary.xaml`のみ使用；Light/Dark/その他Fluentテーマは対応するXAMLをロード
- **`ModAPI.csproj`**：テーマXAMLパスを`Themes\`サブディレクトリに更新；`FluentStylesClassic.xaml`を登録

---

## v2.0.9611の変更点

### バグ修正

- **テーマ切替後のModリスト幅が未適用**：Light/Darkテーマ間の切替と再起動後にModリスト幅が適用されない問題を修正 — `InitModListWidth()`内に`ApplyModListWidth(width)`呼び出しを追加

---

---

## v2.0.9610の変更点

### 追加

#### ゲームXMLとバージョン設定

| # | ファイル | 変更内容 |
|---|------|--------|
| 1 | `GH.xml` | 全面書き換え — 存在しない `DOTweenPro.dll`；`AmplifyBloom/Color/Motion.dll`、`com.rlabrecque.steamworks.net.dll`、`Unity.ProBuilder.dll`、`Unity.Postprocessing.Runtime.dll`を追加 |
| 2 | `Subnautica.xml` | 全面書き換え — 削除 `extends="GenericUnityGame"`；`XGamingRuntime.dll`、`XblPCSandbox.dll`、`FMODUnity.dll`、`Newtonsoft.Json.dll`、`Unity.InputSystem.dll`、`Unity.Collections.dll`、`Unity.Burst.dll`を追加 |
| 3 | `EscapeThePacific.xml` | 全面書き換え — 削除 `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | 作成 — バージョン `1.1.01` チェックサム付き |
| 5 | `GH/Versions.xml` | 作成 — バージョン `2.9.5` チェックサム付き |
| 6 | `Subnautica/Versions.xml` | 作成 — チェックサムなし（更新が頻繁すぎるため） |

#### 重大なバグ修正

| # | タイプ | 問題 | 修正 |
|---|------|-------|-----|
| 1 | ハング | `extends="GenericUnityGame"` `Assembly-CSharp-firstpass.dll`の継承を引き起こし → `CreateModLibrary`が停止 | 非TheForest XMLからすべての`extends`を削除 |
| 2 | クラッシュ | `ResolutionException: XGamingRuntime.XUserGamertagComponent` Subnautica適用中 | `XGamingRuntime.dll`、`XblPCSandbox.dll`を`copyAssembly`に追加 |
| 3 | クラッシュ | リゾルバーが失敗 バックアップ作成後に`copyAssembly`に追加されたDLLで | `Game.cs`：実際のインストールフォルダをリゾルバーフォールバックとして追加 |
| 4 | クラッシュ | `IOException`: `BaseModLib.dll` `CreateModLibrary`と`ApplyMods`間のファイルロック | リトライループ：最大10×500ms読取 + 最大30×500ms存在確認 |
| 5 | クラッシュ | `NullReferenceException` — `typesMap` entry.Valueがnull（ゲーム未インストール） | `if (entry.Value == null) continue`を追加 |
| 6 | クラッシュ | `NullReferenceException` — 軽量 `Game` コンストラクターに`ModLibrary = new ModLib(this)`がない → `CreateModLibrary()`クラッシュ | 軽量コンストラクターに`ModLibrary = new ModLib(this)`を追加 |
| 7 | クラッシュ | `SwitchDevGame()` — `App.Game.GamePath` 軽量コンストラクター後に空 → `CreateModLibrary`クラッシュ | 軽量コンストラクター後に`App.Game.GamePath = savedPath`を設定 |
| 8 | 誤ったゲーム | `EscapeThePacific` のModがTheForestとして分類される | `ModsViewModel`：フォルダパスから`GameId`を抽出 |
| 9 | 誤ったパス | `GetGameFolder()` → `""` → ドライブルートに解決される（例：`E:\`） | 全6呼び出し箇所にNull/空ガードを追加 |

#### Debug / Release ビルド分離

- **`FileValidator.cs`** — 新規ファイル `ModAPI_Shared\Utils\FileValidator.cs`；`ModAPI_Shared.csproj`に登録
  - `IsValidSteamExe()` — PEヘッダー（MZ + PE\0\0）+ 最小1 MB
  - `IsValidGameExe()` — PEヘッダー + 最小512 KB
  - `IsValidAssemblyDll()` — PEヘッダー + .NET CLRメタデータヘッダー + 最小64 KB
- **`CheckSteam()`** — `#if DEBUG`：`File.Exists()`のみ / `#else`：`FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`：`File.Exists()`のみ / `#else`：`FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`：`File.Copy()` Cecilスキップ / `#else`：完全なCecil解析 + IL変更
- **`ModLib.Create()` ファイル未検出** — `#if DEBUG`：警告記録、スキップ / `#else`：エラー記録、中止

#### Debugテスト

- **`create_dummy_Debug_games.ps1`** — `bin\Debug\`用PowerShellスクリプト；`dummy_games\`、`dummy_steam\`、`gamefiles\original\`配下に全5ゲームの0バイトプレースホルダーファイルを作成 — 実際のゲームインストールなしでUIワークフロー全体のテストが可能

#### Settingsタブ

- **Steamパスカード** — ゲームインストールパスカードに統合； `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **ゲームパスパネル** — `BuildGamePathsPanel()`によるゲームごとの展開可能カード；TextBoxは`HorizontalAlignment=Stretch`を使用
- **すべて展開 / すべて折りたたむ**ボタン
- **常に最前面**チェックボックス（`ui.cfg`に保存）
- **Mod/プロジェクトリスト幅**スライダー — 最小`150`から開始；`ui.cfg`に保存
- **フォントサイズ** ComboBox — FHD 10–16、4K 10–22、8K 10–28
- **チェックボックス同期** — `SettingsCheckboxes.DataContext = SettingsVm`；AutoUpdate / UseSteam / UpdateVersionsが正しく同期するように
- **`_uiInitialized`フラグ** — WPF起動中の早期`ui.cfg`書き込みを防止

#### Modsタブ — ゲーム開始検証

ゲーム開始クリックごとにModリストの状態に関係なく5ステップ検証が実行されます：

| ステップ | チェック内容 | ポップアップ |
|---|---|---|
| 1 | SettingsタブのSteamパスが有効（`Steam.exe`が存在） | SteamNotFound |
| 2 | `mods/{GameId}/`フォルダのゲームがSettingsの設定ゲームと一致 | GameModsMismatch |
| 3 | 少なくとも1つのModが選択済み | NoModSelected |
| 4 | 選択に混合ゲームModなし | MixedGameMods |
| 5 | ゲームパス設定済み + 実行ファイルが存在 | GamePathNotSet / GameNotInstalled |

#### Developmentタブ — ModLib検証

Modライブラリ再生成クリック時の3ステップ検証：

| ステップ | チェック内容 | ポップアップ |
|---|---|---|
| 1 | SettingsタブのSteamパスが有効 | SteamNotFound |
| 2 | 少なくとも1つのプロジェクトが存在 | NoProjectWarning |
| 3 | `App.Game.GamePath`が設定済み | GamePathNotSet |

#### Downloadsタブ
- デバッグ文字列を次に置換： `Lang.Downloads.Status.NoDownloads`
- すべてのステータスメッセージに一貫したパディング
- オフラインマニュアルテキストを5つのサポートゲーム用に更新；2つのTextBlockによる改行

#### 初回設定とゲームパスシステム
- `FirstSetup.Check()` — `UseSteam`、`AutoUpdate`、`UpdateVersions`のデフォルト値`true`
- `FirstSetupDone()` — 全5ゲームの`mods/`と`projects/`フォルダを作成
- `SpecifyGamePath` — `GameNameLabel`がどのゲームかを表示；`NavigateToSettings()`がSettingsタブへ遷移

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

### 未収録

| 機能 | 理由 |
|---|---|
| 自動更新（最新バージョン維持） | サーバー側インフラ未整備 |
| 更新検索 | サーバー側インフラ未整備 |

### 削除

| 項目 | 理由 |
|---|---|
| 起動時の`SpecifyGamePath`ポップアップ | すべてのパスはSettingsタブで設定 |
| 起動時の`SpecifySteamPath`ポップアップ | SteamパスはSettingsタブで設定 |
| ログインシステム | 元のサーバーが運用終了（v2.0.9400で削除） |
| `Portable.System.ValueTuple.dll` | Mono 2.0では非機能（v2.0.9586で削除） |
| Steam確認の`UseSteam`条件 | ゲーム開始とModライブラリ再生成時にSteamが常に最初に検証されるように変更 |

---

## 将来のリリース予定

| # | 機能 | 説明 |
|---|---|---|
| 1 | ModAPI自動アップデート | 新しいModAPIリリースを自動的にダウンロードして適用 |
| 2 | ModAPI VersionsDataテーブル更新 | 新しいゲームパッチがリリースされたとき、VersionsDataテーブルを自動更新 |

---

## v2.0.9600の変更点

### 追加

- **Downloadsタブ**：5つのゲームフィルター (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcomeタブ**：最左位置に追加（インデックス0）
- **Modsタブ**：3列レイアウト（WrapPanel → 縦リスト）；自動幅調整；Mod名の折り返し
- **`ModsViewModel`**：ゲーム固有フィルタリング、Modごとの正しい`Game`インスタンス用`ResolveGame()`
- **`Game.cs`**：軽量コンストラクター`new Game(config, true)` — 識別のみ、`Verify()`なし
- **ビルド**：4つのゲームXMLファイルを`ModAPI.csproj`に`CopyToOutputDirectory=Always`で登録
- **ビルド**：警告をクリーン — CS0168、CS0618、CS0252
- **ゲームXML**：TheForest、Raft、GHのDLLリストを修正
- **言語フラグ**：13言語バッジすべてで画像サイズを統一

### 削除

| 項目 | 理由 |
|---|---|
| ゲームXMLファイルの`extends="GenericUnityGame"` | `Assembly-CSharp-firstpass.dll`が誤って継承される原因 — Subnautica、Raft、EscapeThePacific、GHから削除 |
| Modsタブの`WrapPanel`レイアウト | 3列Gridレイアウトに置換（ゲームフィルター / Modリスト / 情報） |

---

## フェーズ別主な変更点

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
全5プロジェクトを.NET 4.5 → 4.8に移行。

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6、`FluentStyles.xaml`、UnityEngineスタブDLL。

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
3テーマシステム、`theme.cfg`、ウィンドウドラッグ修正、ハイパーリンクサポート。

### Phase 4 *(v2.0.9400)* — Code Cleanup
ログインシステム削除、更新メカニズム近代化。

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Downloadsタブ、Segoe MDL2 Assetsアイコン、13言語サポート。

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`、`CustomAssemblyResolver.cs`、PEヘッダーパッチング。

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
ブラックスクリーン修正、`ValueTuple`削除、C# 7.3ゲーム内検証済み。

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5ゲームフィルター、3列Modsタブ、軽量`Game`コンストラクター、XML登録。

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML修正、Steamパス、ゲームパス安全性、ゲーム開始5ステップ検証、ModLib 3ステップ検証、`FileValidator` PEヘッダー検証、`#if DEBUG`ビルド分離、`create_dummy_Debug_games.ps1`、軽量コンストラクター`ModLibrary`修正、`SwitchDevGame` GamePath修正、5ゲームフォルダ作成、クラッシュ修正。

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Themesタブ追加、10テーマ + 背景テクスチャ機能、Themes/フォルダ分離、最大化ボタン修正、ゲームパス展開修正、Versions.xml 4ゲーム更新、パスリセットボタン、Browse自動保存、MODAPI_VersionTool。

---

## バージョン履歴

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool追加（スタンドアロンWPFバージョン更新ツール）、StatusBarバージョン表示をApp.Versionに連動

### v2.0.9617 — 2026-04-24
Settingsタブにスチーム/ゲームパスリセットボタン追加、Browse自動保存、リセット状態ui.cfgフラグで保存

### v2.0.9616 — 2026-04-18
Versions.xml 4ゲーム新規/更新（Subnautica、Raft、EscapeThePacific、GH）、チェックサム構成ルール確立、ゲーム更新手順文書化

### v2.0.9615 — 2026-04-18
Settingsタブ ゲームパスカード展開高さ精度修正、UpdateWindowHeight背景テクスチャ干渉防止

### v2.0.9614 — 2026-04-18
最大化ボタンWorkArea基準手動最大化、前のサイズ/位置の保存と復元

### v2.0.9613 — 2026-04-18
Themesタブ新設、テーマレジストリデータ駆動構造、10テーマサポート、背景テクスチャ機能（圧縮・セキュリティ・2層透明化）、ThemeSelectorロックオーバーレイ、言語キー12個追加

### v2.0.9612 — 2026-04-18
Themes/フォルダ分離、テーマXAMLモジュール化

### v2.0.9611 — 2026-04-18
テーマ切替後Modリスト幅未適用バグ修正

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5ゲームフィルター、Modsタブ3列レイアウト、自動幅、軽量`Game`コンストラクター、`ModsViewModel`ゲームフィルタリング、4 XMLファイル登録、ビルド警告クリーン、Welcomeタブ、言語フラグ統一

### v2.0.9586 — 2026-03-31
ブラックスクリーン修正、ポリフィル最終化、ValueTuple削除、C# 7.3検証済み

### v2.0.9561 — 2026-03-06
C# 7.3サポート、PEヘッダーパッチング、ポリフィルパイプライン、アセンブリ解決復元

### v2.0.9552 — 2026-02-25
Downloadsタブ、アイコン近代化、テーマ統一、13言語サポート

### v2.0.9500
テーマシステム（Classic/Light/Dark）、Fluent Design UI、SubWindowシステム

### v2.0.9400
コードクリーンアップ、ログイン削除、レガシー近代化

### v2.0.9300
ビルド環境、UnityEngineスタブDLL、ModernWpf統合

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## ビルド要件

| 要件 | バージョン | 備考 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPIプロジェクト |
| .NET Framework SDK | 3.5 | BaseModLibのみ |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## ライセンス

GNU General Public License v3.0 — 元のライセンスに従います。
