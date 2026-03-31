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

**Outil de Gestion de Mods The Forest — Édition Améliorée**

> Original : FluffyFish / Philipp Mohrenstecher (Engelskirchen, Allemagne)
> Amélioration : zzangae (République de Corée)

---

## Aperçu

ModAPI est une application de bureau pour gérer les mods de The Forest. Cette édition améliorée comprend la migration vers .NET Framework 4.8, l'interface Windows 11 Fluent Design, un système à 3 thèmes, un support multilingue étendu, une implémentation complète de l'onglet Téléchargements et le support du développement de mods en C# 7.3.

---

## Ce qui a changé dans v2.0.9586

| # | Catégorie | Problème | Solution |
|---|---|---|---|
| 1 | **Critique** | Écran noir dans le menu principal après application des mods | Résolu — la pipeline de remappage d'assemblages patche correctement les en-têtes PE et les tables de références |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` inclus mais non fonctionnel | Supprimé entièrement — `mscorlib` de Mono 2.0 génère de l'IL référençant directement `ValueTuple` ; aucun polyfill ne peut le remplacer |
| 3 | **Polyfill** | Nom de fichier incorrect : `System.Threading.Tasks.dll` | Corrigé en `System.Threading.dll` — nom réel du NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Bug de chemin de copie dans `Game.cs` : fichiers copiés dans `Managed\polyfills\` | Corrigé avec `Path.GetFileName()` pour une copie plate dans `Managed\` |
| 5 | **Build** | Target PostBuild sans auto-copie des polyfills | `BaseModLib.csproj` PostBuild copie maintenant automatiquement `AsyncBridge.dll` et `System.Threading.dll` |
| 6 | **C# 7.3** | Support des tuples (`ValueTuple`) tenté et échoué | Définitivement supprimé — limite architecturale sur Mono 2.0 |
| 7 | **C# 7.3** | Vérification en jeu des fonctionnalités C# 7.3 | Confirmé : pattern matching, interpolation de chaînes, variable `out` inline |

### Matrice Finale des Fonctionnalités C# 7.3

| Fonctionnalité | Statut | Notes |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Confirmé | Testé en jeu via `TEST_MOD.log` |
| Interpolation de chaînes (`$""`) | ✅ Confirmé | Testé en jeu via `TEST_MOD.log` |
| Variable `out` inline | ✅ Confirmé | Testé en jeu via `TEST_MOD.log` |
| Membres à corps d'expression (`=>`) | ✅ | Géré par le compilateur |
| Fonctions locales | ✅ | Géré par le compilateur |
| `nameof` | ✅ | Géré par le compilateur |
| Opérateur null-conditionnel (`?.`, `??`) | ✅ | Géré par le compilateur |
| `async`/`await` | ✅ | Via polyfills AsyncBridge + System.Threading |
| Tuples (`ValueTuple`) | ❌ Limite dure | ABI `mscorlib` Mono 2.0 — sans contournement |

### Configuration Finale des Polyfills

| DLL | Package NuGet | Destination | Objectif |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` pour .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Dépendance AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Supprimé~~ | ~~Supprimé~~ | ~~Non fonctionnel sur Mono 2.0~~ |

---

## Architecture de Runtime

| Composant | Cible | Runtime | Raison |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | App de bureau |
| `BaseModLib.dll` | .NET Framework 3.5 | Jeu Mono 2.0 | **Fixé définitivement** |
| DLLs de Mod | .NET Framework 4.8 | Jeu Mono 2.0 (patché) | En-tête PE patché lors de l'application |

```
Build v3.5  →  En-tête PE : CLR Runtime v2.0.50727  ←  Mono 2.0 accepte  ✅
Build v4.8  →  En-tête PE : CLR Runtime v4.0.30319  ←  Mono 2.0 refuse   ❌
```

---

## Historique des Versions

| Version | Date | Résumé |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Écran noir résolu, pipeline polyfill finalisée, ValueTuple supprimé, bugs corrigés, C# 7.3 vérifié |
| v2.0.9561 | 2026-03-06 | Support C# 7.3, patch en-tête PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Onglet téléchargements, icônes, 13 langues |
| v2.0.9500 | — | Système de thèmes, Fluent Design UI |
| v2.0.9400 | — | Nettoyage du code |
| v2.0.9300 | — | Environnement build, DLL stub UnityEngine |
| v2.0.9200 | — | Migration .NET Framework 4.8 |
| v1.x | — | Version originale FluffyFish |

---

## Prérequis de Build

| Prérequis | Version | Notes |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Pour projets ModAPI |
| .NET Framework SDK | 3.5 | Uniquement pour BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — dans `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` dans `libs/polyfills/` |

---

## Licence

GNU General Public License v3.0 — suit la licence originale.
