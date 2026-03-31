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

**The Forest Mod管理ツール — アップグレード版**

> オリジナル: FluffyFish / Philipp Mohrenstecher（エンゲルスキルヒェン、ドイツ）
> アップグレード: zzangae（大韓民国）

---

## 概要

ModAPIはThe ForestのMod管理用デスクトップアプリケーションです。このアップグレード版には、.NET Framework 4.8への移行、Windows 11 Fluent Design UI、3テーマシステム、多言語サポートの強化、ダウンロードタブの完全な実装、およびC# 7.3 Mod開発サポートが含まれています。

---

## v2.0.9586 での変更点

| # | カテゴリ | 問題 | 解決策 |
|---|---|---|---|
| 1 | **重大** | Mod適用後のゲームメインメニューでのブラックスクリーン | 解決済み — アセンブリリマッピングパイプラインがPEヘッダーと参照テーブルを正しくパッチ |
| 2 | **ポリフィル** | `Portable.System.ValueTuple.dll` 含まれていたが動作不可 | 完全削除 — Mono 2.0 の `mscorlib` が `ValueTuple` を直接参照するILを生成するため、ポリフィルで上書き不可 |
| 3 | **ポリフィル** | 誤ったファイル名: `System.Threading.Tasks.dll` | `System.Threading.dll` に修正 — `TaskParallelLibrary 1.0.2856` NuGet の実際のファイル名 |
| 4 | **ポリフィル** | `Game.cs` コピーパスのバグ: `Managed\polyfills\` にコピーされた | `Path.GetFileName()` で `Managed\` へのフラットコピーに修正 |
| 5 | **ビルド** | PostBuildターゲットにポリフィル自動コピーなし | `BaseModLib.csproj` PostBuildが `AsyncBridge.dll` と `System.Threading.dll` を自動コピー |
| 6 | **C# 7.3** | タプル(`ValueTuple`)サポートを試みたが失敗 | 完全削除 — Mono 2.0ではタプルはアーキテクチャ上の限界 |
| 7 | **C# 7.3** | 残りのC# 7.3機能のインゲーム検証 | 確認済み: パターンマッチング、文字列補間、`out`変数インライン |

### C# 7.3 最終機能マトリックス

| 機能 | 状態 | 備考 |
|---|---|---|
| パターンマッチング (`is`, `switch`) | ✅ 確認済み | `TEST_MOD.log` でインゲームテスト |
| 文字列補間 (`$""`) | ✅ 確認済み | `TEST_MOD.log` でインゲームテスト |
| `out`変数インライン | ✅ 確認済み | `TEST_MOD.log` でインゲームテスト |
| 式本体メンバー (`=>`) | ✅ | コンパイラー処理 |
| ローカル関数 | ✅ | コンパイラー処理 |
| `nameof` | ✅ | コンパイラー処理 |
| Null条件演算子 (`?.`, `??`) | ✅ | コンパイラー処理 |
| `async`/`await` | ✅ | AsyncBridge + System.Threadingポリフィル経由 |
| タプル (`ValueTuple`) | ❌ ハードリミット | Mono 2.0 mscorlib ABI — 回避不可 |

### 最終ポリフィル設定

| DLL | NuGetパッケージ | 宛先 | 目的 |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | .NET 3.5の`async`/`await` |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge依存関係 |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~削除済み~~ | ~~削除済み~~ | ~~Mono 2.0で動作不可~~ |

---

## ランタイムアーキテクチャ

| コンポーネント | ターゲット | ランタイム | 理由 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | デスクトップApp |
| `BaseModLib.dll` | .NET Framework 3.5 | ゲーム Mono 2.0 | **永久固定** |
| Mod DLL | .NET Framework 4.8 | ゲーム Mono 2.0（パッチ済み） | Apply時にPEヘッダーをパッチ |

```
v3.5ビルド  →  PEヘッダー: CLR Runtime v2.0.50727  ←  Mono 2.0 受け入れ  ✅
v4.8ビルド  →  PEヘッダー: CLR Runtime v4.0.30319  ←  Mono 2.0 拒否     ❌
```

---

## バージョン履歴

| バージョン | 日付 | 概要 |
|---|---|---|
| v2.0.9586 | 2026-03-31 | ブラックスクリーン修正確認、ポリフィルパイプライン完成、ValueTuple削除、バグ修正、C# 7.3インゲーム検証 |
| v2.0.9561 | 2026-03-06 | C# 7.3 Mod開発サポート、PEヘッダーパッチ、ポリフィルパイプライン |
| v2.0.9552 | 2026-02-25 | ダウンロードタブ、アイコン近代化、13言語 |
| v2.0.9500 | — | テーマシステム、Fluent Design UI |
| v2.0.9400 | — | コードクリーンアップ |
| v2.0.9300 | — | ビルド環境、UnityEngineスタブDLL |
| v2.0.9200 | — | .NET Framework 4.8移行 |
| v1.x | — | オリジナルFluffyFishリリース |

---

## ビルド要件

| 要件 | バージョン | 備考 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPIプロジェクト用 |
| .NET Framework SDK | 3.5 | BaseModLibのみ |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` に配置 |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` を `libs/polyfills/` に |

---

## ライセンス

GNU General Public License v3.0 — オリジナルライセンスに準拠。
