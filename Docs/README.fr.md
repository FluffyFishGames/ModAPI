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

**Outil de Gestion de Mods The Forest — Édition Améliorée**

> Original: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Allemagne)
> Amélioration: zzangae (République de Corée)

---

## Présentation

ModAPI est une application de bureau pour gérer les mods de **5 jeux officiellement pris en charge**. Cette édition améliorée comprend le support multi-jeux, un onglet Paramètres entièrement repensé, la configuration du chemin Steam, des paramètres UI persistants, un système de taille de police dynamique, la validation du démarrage du jeu, une séparation des builds Debug/Release et de nombreuses corrections de plantages vérifiées en jeu.

---

## Jeux Supportés

| Jeu | Moteur | Version | Steam ID | Exécutable |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Bêta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 5 (mis à jour depuis Unity 4) |
| Dernière Version | v1.12 (VR) |
| Dernière Mise à Jour | 11 septembre 2019 — patch de support VR ; aucune mise à jour de contenu majeure depuis |
| Exécutable | `TheForest.exe` |
| Dossier de Données | `TheForest_Data/Managed/` |
| Dossier de Mods | `mods/TheForest/` |
| Dossier de Projets | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — entièrement supporté |

The Forest a été mis à jour de Unity 4 vers Unity 5, améliorant considérablement les graphismes et la physique. Le patch VR de septembre 2019 a été la dernière mise à jour majeure. Le jeu reste dans un état stable et finalisé — idéal pour le modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity (base de code intégrée, unifiée avec Below Zero en 2022) |
| Dernière Version | 2025 Patch (v18810395) |
| Dernière Mise à Jour | 12 août 2025 — corrections de bugs et améliorations de performances avec la sortie mobile |
| Exécutable | `Subnautica.exe` |
| Dossier de Données | `Subnautica_Data/Managed/` |
| Dossier de Mods | `mods/Subnautica/` |
| Dossier de Projets | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — supporté |

Construit à l'origine sur Unity 5, Subnautica a reçu la mise à jour 'Living Large' (v2.0) fin 2022, fusionnant la base de code du moteur avec Below Zero pour une optimisation et une stabilité améliorées. Note : le prochain *Subnautica 2* utilise Unreal Engine 5.

> **XML réécrit dans v2.0.9610** : `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` ajoutés à `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity |
| Dernière Version | v1.1.02 (Bêta) / v1.09 (Stable) |
| Dernière Mise à Jour | Mars 2026 — corrections du chat vocal et multijoueur via la branche bêta |
| Exécutable | `Raft.exe` |
| Dossier de Données | `Raft_Data/Managed/` |
| Dossier de Mods | `mods/Raft/` |
| Dossier de Projets | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — supporté |
| Versions.xml | `1.1.01` (avec checksum) |

Après la conclusion officielle de l'histoire dans v1.0 : *The Final Chapter*, les patchs ont continué pour les améliorations du code réseau et la stabilité.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 6 (migré depuis Unity 2021/2022 fin 2025) |
| Dernière Version | v0.67.0.0 |
| Dernière Mise à Jour | 26 juin 2025 — refonte de la distribution des îles et mise à jour du moteur ; correctifs en cours jusqu'en 2026 |
| Exécutable | `EscapeThePacific.exe` |
| Dossier de Données | `EscapeThePacific_Data/Managed/` |
| Dossier de Mods | `mods/EscapeThePacific/` |
| Dossier de Projets | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — supporté |

Reconstruction majeure du système et migration vers Unity 6 complétées fin 2025, permettant des environnements plus dynamiques. Le jeu reste en développement Accès Anticipé actif.

> **XML réécrit dans v2.0.9610** : `extends="GenericUnityGame"` supprimé ; `includeAssembly` défini sur `Assembly-CSharp.dll` uniquement — empêche les erreurs d'héritage de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 2019 |
| Dernière Version | v2.9.5 |
| Dernière Mise à Jour | 4 février 2026 — optimisation Steam Deck et améliorations de la lisibilité du texte |
| Exécutable | `GH.exe` |
| Dossier de Données | `GH_Data/Managed/` |
| Dossier de Mods | `mods/GH/` |
| Dossier de Projets | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — supporté |
| Versions.xml | `2.9.5` (avec checksum) |

Développé avec des mises à jour progressives du moteur Unity 2017 → 2018 → 2019. Le correctif de février 2026 s'est concentré sur la compatibilité Steam Deck et la lisibilité du texte de l'UI.

> **XML réécrit dans v2.0.9610** : `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` ajoutés ; `DOTweenPro.dll` inexistant supprimé.
</details>

---

## Architecture

### Séparation du Temps d'Exécution

| Composant | Cible | Temps d'Exécution | Raison |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Application de bureau, API moderne complète |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Bibliothèque partagée |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fixé en permanence** — l'en-tête PE doit contenir `v2.0.50727` |
| DLLs de Mod (utilisateur) | .NET Framework 4.8 | Game Mono 2.0 (patché) | Compilé avec 4.8, en-tête PE patché à l'application |

### Séparation de Compilation Debug / Release

Toutes les validations de fichiers et le traitement des assemblages se ramifient selon la configuration de compilation via `#if DEBUG` / `#else`.

| Emplacement | Compilation Debug | Compilation Release |
|---|---|---|
| `CheckSteam()` | `File.Exists()` uniquement — les fichiers factices passent | `FileValidator.IsValidSteamExe()` — en-tête PE + min 1 Mo |
| `CheckGamePath()` | `File.Exists()` uniquement — les fichiers factices passent | `FileValidator.IsValidAssemblyDll()` — en-tête PE + métadonnées CLR + min 64 Ko |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — analyse Cecil omise | Analyse complète Mono.Cecil + modification IL + `module.Write()` |
| `ModLib.Create()` — fichier non trouvé | Journaliser avertissement, ignorer et continuer | Journaliser erreur, abandonner avec popup |

**Les tests Debug** utilisent `create_dummy_Debug_games.ps1` pour générer des fichiers de 0 octet sous `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` et `bin\Debug\gamefiles\original\`. Ceux-ci passent les vérifications `File.Exists()` et permettent des tests complets du flux de travail de l'UI sans installation réelle du jeu.

**Les compilations Release** appliquent `FileValidator` (vérification en-tête PE + métadonnées CLR .NET) pour rejeter les fichiers de 0 octet, les fichiers texte et les binaires arbitraires. Seuls les exécutables Windows valides et les assemblages .NET passent.

### FileValidator — Vérification d'En-tête PE

`ModAPI_Shared\Utils\FileValidator.cs` — appliqué uniquement en compilations Release.

| Méthode | Vérifications | Taille Min. |
|---|---|---|
| `IsValidSteamExe(path)` | Signature MZ + signature PE\0\0 | 1 Mo |
| `IsValidGameExe(path)` | Signature MZ + signature PE\0\0 | 512 Ko |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + en-tête de métadonnées CLR (répertoire de données #14) | 64 Ko |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline de Remappage des Assemblages

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

### Repli du Résolveur d'Assemblages

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Prise en Charge des Fonctionnalités C# 7.3

| Fonctionnalité | Statut | Notes |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ | Vérifié en jeu |
| Interpolation de chaînes (`$""`) | ✅ | Vérifié en jeu |
| Variable `out` en ligne | ✅ | Vérifié en jeu |
| `async` / `await` | ✅ | Via AsyncBridge + polyfills System.Threading |
| Tuples (`ValueTuple`) | ❌ Limite absolue | ABI `mscorlib` Mono 2.0 — aucune solution |

### Theme System

À partir de v2.0.9613, l'interface de sélection de thème a été déplacée de l'onglet Settings vers un **onglet Themes** dédié. L'ajout d'un nouveau thème ne nécessite qu'une seule ligne dans le dictionnaire de `App.xaml.cs`.

| Index | ID | Fichier | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` uniquement | Arrière-plan texturé original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Ton clair + accent bleu |
| 2 | `dark` | `FluentStyles.xaml` | Ton sombre + accent bleu (par défaut) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rouge + noir |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espace sombre |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Coucher de soleil lumineux |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océan sombre |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordique lumineux |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumes lumineux |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral lumineux |

Les changements de thème déclenchent un redémarrage automatique de l'application. (enregistré dans `theme.cfg`)

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

### Texture d'Arrière-plan

Sélectionnez une image dans la carte **Background Texture** de l'onglet Themes pour l'appliquer comme arrière-plan de toute l'application. Formats pris en charge : `.png` / `.jpg` / `.jpeg`, max 50Mo, résolution 4K ou inférieure. L'image est compressée en JPEG Q75 avec un en-tête magique de 16 octets et enregistrée sous `resources\textures\ui_bg\bg.dat` (attribut Hidden). Hash SHA-256 pour la vérification d'intégrité ; en cas de falsification, réinitialisation automatique + popup d'avertissement.

Lorsque l'arrière-plan est actif, la transparence de l'interface est traitée en deux couches : Layer 1 (overlay MergedDictionaries) pour les panneaux `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) pour les panneaux basés sur `{StaticResource}` avec semi-transparence.

### Système de Taille de Police

| Clé de Ressource | Base | Description |
|---|---|---|
| `AppBaseFontSize` | 13 | Texte normal |
| `AppBaseHeaderFontSize` | 16 | En-têtes, titres de panneau |
| `AppBaseSmallFontSize` | 12 | Étiquettes secondaires |
| `AppBaseTinyFontSize` | 10 | Texte d'indication |
| `AppBaseLargeFontSize` | 20 | Texte d'affichage grand |

### Configuration Persistante de l'UI — `ui.cfg`

| Clé | Défaut | Description |
|-----|---------|-------------|
| `ModListWidth` | `150` | Largeur de liste de mods (px) |
| `ProjectListWidth` | `150` | Largeur de liste de projets (px) |
| `AppFontSize` | `13` | Taille de police globale de l'UI (px) |
| `AlwaysOnTop` | `false` | Fenêtre toujours au premier plan |
| `TexturePath` | *(aucun)* | Nom de fichier original de texture de fond (affichage uniquement) |
| `TextureHash` | *(aucun)* | Hash SHA-256 de texture de fond |
| `TextureActive` | `false` | État d'activation de texture de fond |
| `GamePathReset_{GameId}` | *(aucun)* | Indicateur de réinitialisation de chemin de jeu |
| `SteamPathReset` | *(aucun)* | Indicateur de réinitialisation de chemin Steam |

### Structure de Fichiers

```
ModAPI/
├── App.xaml / App.xaml.cs              # Registre de thèmes, ID de thèmes, application du thème
├── ui.cfg                               # Paramètres UI persistants
├── theme.cfg                            # Thème actuel
├── Windows/
│   ├── MainWindow.xaml / .cs            # UI principale — 6 onglets, Thèmes, Paramètres, chemin Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup de chemin de jeu (GameNameLabel dynamique)
│       ├── FirstSetup.xaml / .cs        # Configuration initiale + initialisation par défaut
│       └── (14 autres sous-fenêtres)
├── Themes/
│   ├── Dictionary.xaml                  # Thème Classic
│   ├── FluentStyles.xaml                # Thème Dark
│   ├── FluentStylesLight.xaml           # Thème Light
│   ├── FluentStylesDiablo.xaml          # Thème Diablo
│   ├── FluentStylesNebula.xaml          # Thème Nebula
│   ├── FluentStylesSunset.xaml          # Thème Sunset
│   ├── FluentStylesOcean.xaml           # Thème Ocean
│   ├── FluentStylesNordic.xaml          # Thème Nordic
│   ├── FluentStylesCitrus.xaml          # Thème Citrus
│   └── FluentStylesBloom.xaml           # Thème Bloom
├── Data/
│   ├── Game.cs                          # Patchage d'assemblage, gardes null, repli du résolveur
│   ├── ModLib.cs                        # Génération BaseModLib + remappage (#if DEBUG séparation)
│   ├── Models/
│   │   └── ModProject.cs                # Création/compilation/application de projet + gardes null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Mods filtrés, mod sélectionné, filtre de jeu sélectionné
│   │   ├── ModViewModel.cs              # GameId depuis le chemin du dossier
│   │   ├── ModProjectsViewModel.cs      # Dispose() pour DispatcherTimer
│   │   └── SettingsViewModel.cs         # Par défaut true pour UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mappage de versions d'assemblages Mono 2.0 (20 assemblages)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Résolveur basé sur le nom avec mise en cache
│   └── MonoHelper.cs                    # Utilitaires d'aide IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 fichiers de langue
│   └── textures/ui_bg/
│       └── bg.dat                       # Image de fond compressée et sécurisée (générée à l'exécution)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Réécriture complète v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Réécriture complète v2.0.9610
    │   ├── GH.xml                       # Réécriture complète v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — non supporté
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Constructeur léger + correction d'initialisation ModLibrary
│   └── ModLib.cs                        # Séparation #if DEBUG pour l'analyse Cecil
└── Utils/
    └── FileValidator.cs                 # Validation en-tête PE + métadonnées CLR (Release uniquement)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Outil autonome de mise à jour de version WPF

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Génère une structure de jeu/Steam fictive
├── dummy_games\{GameId}\               # Chemins d'installation de jeu fictifs
├── dummy_steam\Steam.exe               # Exécutable Steam fictif
└── gamefiles\original\{GameId}\        # Chemins de sauvegarde fictifs pour ModLib
```

---

## Installation et Configuration

### Étape 1 — Prérequis

| Élément | Requis |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (préinstallé sur Windows 11 ; [télécharger](https://dotnet.microsoft.com/download/dotnet-framework/net48) pour Windows 10) |
| Steam | Requis — doit être configuré dans l'onglet Settings |
| Au moins un jeu supporté | Requis — doit être configuré dans l'onglet Settings |

### Étape 2 — Installer ModAPI

1. Télécharger la dernière version depuis GitHub
2. Extraire dans un dossier quelconque (ex. `C:\ModAPI\`)
3. Exécuter `ModAPI.exe`
4. Au premier lancement, l'écran **Welcome** apparaît — configurer les préférences et cliquer sur **Continue**

### Étape 3 — Configurer le chemin Steam (onglet Settings)

1. Aller à l'onglet **Settings**
2. Trouver **Steam Installation Path**
3. Cliquer sur **Browse** → sélectionner `Steam.exe`
4. Cliquer sur **Save**

### Étape 4 — Configurer les chemins de jeux (onglet Settings)

1. Cliquer sur l'en-tête d'une carte de jeu pour la développer
2. Cliquer sur **Browse** → sélectionner le dossier racine du jeu (où se trouve le `.exe`)
3. Cliquer sur **Save**

| Jeu | Exécutable | Exemple de Chemin |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Étape 5 — Télécharger des Mods (onglet Downloads)

1. Aller à l'onglet **Downloads**
2. Sélectionner un jeu dans le filtre de jeux
3. Rechercher un mod et cliquer sur **Download**

> **Hors ligne** : Télécharger les fichiers `.mod` manuellement depuis `modapi.survivetheforest.net` et les placer dans le dossier correspondant :

| Jeu | Dossier |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Étape 6 — Appliquer les Mods et Lancer le Jeu (onglet Mods)

1. Aller à l'onglet **Mods**
2. Sélectionner un jeu dans le **Filtre de Jeux** (Colonne 0)
3. Activer les mods dans la **Liste de Mods** (Colonne 1)
4. Cliquer sur **Start Game**

Les vérifications suivantes s'exécutent automatiquement avant le lancement :

| # | Vérification | Popup d'Erreur |
|---|---|---|
| 1 | Chemin Steam configuré et valide | SteamNotFound |
| 2 | Jeu dans le dossier `mods/` correspond au chemin dans Settings | GameModsMismatch |
| 3 | Au moins un mod sélectionné | NoModSelected |
| 4 | Pas de mods de jeux mixtes dans la sélection | MixedGameMods |
| 5 | Chemin du jeu configuré et exécutable existe | GamePathNotSet / GameNotInstalled |

---

## Aperçu des Onglets

### Onglet Welcome
Écran de configuration initiale (index d'onglet 0). Configurer AutoUpdate, connexion Steam et préférences de table VersionsData. Lors des lancements suivants, cet onglet fournit des liens communautaires et des notes de version.

### Onglet Mods
Flux de travail principal de gestion des mods — disposition en 3 colonnes :

| Colonne | Contenu |
|---|---|
| Colonne 0 | Filtre de Jeux — boutons radio pour 5 jeux supportés |
| Colonne 1 | Liste de Mods — mods installés avec sélecteur de version et case d'activation |
| Colonne 2 | Information — détails du mod sélectionné, description, historique de versions |

### Onglet Downloads
Parcourir et télécharger des mods depuis `modapi.survivetheforest.net`.

- **Filtre de jeux** : TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Filtre de catégories** : 12 catégories (Bugfixes, Balancing, Cheats, …)
- **Recherche** : par nom de mod, description ou auteur
- **Mode hors ligne** : affiche les instructions de dossier pour les 5 jeux supportés

### Onglet Development
Flux de travail de développement de mods — panneau de filtre de jeux (Colonne 0) couvre les 5 jeux supportés.

- Créer, compiler et appliquer des projets de mods par jeu
- Gestion des ressources linguistiques
- Génération de ModLib avec validation en 3 étapes (Steam → projet → chemin du jeu)
- Changement de jeu sécurisé via constructeur léger `Game` (sans appel `Verify()`)

### Onglet Themes
Sélection de thèmes et gestion des textures d'arrière-plan.

- **Sélection de thème** : 10 thèmes (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Texture d'arrière-plan** : Sélectionner une image comme arrière-plan de toute l'application (compression JPEG + traitement de sécurité)
- Lorsque la texture d'arrière-plan est active, la sélection de thème est verrouillée

### Onglet Settings
Configuration centralisée — 4 lignes :

| Ligne | Contenu |
|---|---|
| 0 | Langue / Taille de police / Thème / Largeur max / Largeur de liste de mods / Largeur de liste de projets |
| 1 | Conserver VersionsData / Mise à jour auto / Connexion Steam / Toujours au premier plan |
| 2 | Chemin d'installation Steam (TextBox + Parcourir + Enregistrer + Réinitialiser) |
| 3 | Chemins d'installation des jeux — carte dépliante par jeu (TextBox + Parcourir + Enregistrer + Réinitialiser) |

---

## Changements dans v2.0.9618

### Outil de Mise à Jour de Version (MODAPI_VersionTool)

Un outil WPF autonome pour mettre à jour le numéro de version en un clic.

**Emplacement** : `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Fonctionnalités**
- Affiche automatiquement la version actuelle (lue depuis `App.xaml.cs`)
- Entrez une nouvelle version et cliquez sur **Apply Version** pour mettre à jour les deux fichiers simultanément
- Validation du format : seul le format `X.X.XXXX` est accepté

**Fichiers Modifiés**

| Fichier | Chemin | Modification |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Utilisation**
1. Exécuter `MODAPI_VersionTool.exe`
2. Entrer la nouvelle version (ex. `2.0.9619`)
3. Cliquer sur **Apply Version**
4. Reconstruire la solution ModAPI dans Visual Studio

### Correction de l\'Affichage de Version dans la StatusBar

- `VersionLabel.Text` référence maintenant `App.Version` au lieu du `Version.Descriptor` codé en dur
- La mise à jour de la version avec VersionTool et la reconstruction se reflètent immédiatement dans la StatusBar

---

## Changements dans v2.0.9617

### Onglet Settings — Boutons de Réinitialisation de Chemin Ajoutés

Un bouton **Reset** a été ajouté au chemin d\'installation de Steam et à chaque ligne de chemin d\'installation de jeu.

**Ligne de chemin Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Ligne de chemin de jeu (par jeu)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportement de la réinitialisation**
- Efface immédiatement le TextBox de chemin
- Enregistre un drapeau de réinitialisation dans `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Le TextBox reste vide après le redémarrage
- Contourne la limitation de Configuration XML qui ne persiste pas les chaînes vides

**Auto-enregistrement Browse**
- Avant : nécessitait un clic séparé sur le bouton Save après Browse
- Après : enregistrement automatique à la sélection du fichier — reflété même après le passage à l\'onglet Mods

**Nouvelle clé de langue**

| Clé | Valeur |
|---|---|
| `Lang.Options.Labels.PathReset` | Réinitialiser |

---

## Changements dans v2.0.9616

### Versions.xml — 4 Jeux Ajoutés / Mis à Jour

| Jeu | Chemin du Fichier | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Nouvellement créé |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum mis à jour |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Nouvellement créé |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum mis à jour |

### Règles de Composition du Checksum

Le format du checksum diffère selon que `Assembly-CSharp-firstpass.dll` existe pour chaque jeu.

| Jeu | firstpass.dll | Format du Checksum |
|---|---|---|
| GH | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| Subnautica | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| EscapeThePacific | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| Raft | ❌ Non présent | `Assembly-CSharp MD5` uniquement (32 caractères) |

### Procédure de Mise à Jour de Versions.xml

Ajouter une nouvelle entrée `<version>` sans supprimer les entrées existantes.

**Step 1 — Trouver le nouveau BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Jeu | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Step 2 — Extraire le nouveau checksum**
```powershell
# Jeux avec firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concaténer les deux valeurs Hash dans l\'ordre (firstpass en premier)

# Jeux sans firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Step 3 — Ajouter l\'entrée à Versions.xml**
```xml
<version id="{nouveau BuildID}">
    <checksum>{nouveau checksum}</checksum>
</version>
```

---

## Changements dans v2.0.9615

### Correction de l\'Expansion de Chemin de Jeu dans Settings

- **Hauteur d\'expansion de carte** : Le bord inférieur de la fenêtre grandit maintenant exactement de la hauteur du champ de saisie lors de l\'expansion d\'une carte de chemin de jeu
- **`UpdateWindowHeight()` amélioré** : Appelle `UpdateLayout()` avant la mesure `SizeToContent.Height` ; définit temporairement `TextureLayer1` sur `Collapsed` lorsque la texture d\'arrière-plan est active pour éviter que la taille originale de l\'image 4K n\'affecte le calcul de hauteur
- **Correction de Grid Row interne** : Dernière Row du panneau de chemins de jeu changée de `Height="*"` à `Height="Auto"` — supprime l\'espace blanc inférieur inutile

---

## Changements dans v2.0.9614

### Correction du Comportement du Bouton Maximiser

- **Maximiser** : Utilise `SystemParameters.WorkArea` pour une maximisation manuelle au lieu de `WindowState.Maximized` — s\'ajuste exactement à la résolution d\'écran actuelle sans chevaucher la barre des tâches
- **Restaurer** : Sauvegarde `Left`, `Top`, `Width`, `Height` et `MaxWidth` avant de maximiser et les restaure au clic sur le bouton de restauration
- **Gestion de `MaxWidth`** : Défini à `∞` lors de la maximisation, valeur sauvegardée restaurée lors de la normalisation

---

## Changements dans v2.0.9613

### Nouvel Onglet Themes

L\'ordre des onglets est maintenant :

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

L\'interface de sélection de thème a été déplacée de l\'onglet Settings vers un **onglet Themes** dédié.
Icône : Segoe MDL2 Assets `&#xE790;` (palette)

### Registre de Thèmes (Structure Pilotée par les Données)

L\'ajout d\'un nouveau thème ne nécessite maintenant qu\'**une seule ligne** dans le dictionnaire de `App.xaml.cs`.
Toutes les instructions switch ont été supprimées — aucune modification de code nécessaire ailleurs.

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

Les éléments du ComboBox `ThemeSelector` sont générés automatiquement à partir de la boucle `ThemeIds`.
Convention de clés de langue : `Lang.Options.Theme.{PascalCase}` (ex. `Lang.Options.Theme.Nebula`)

### Thèmes Supportés

| Index | ID | Fichier | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` uniquement | Arrière-plan texturé original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Ton clair + accent bleu |
| 2 | `dark` | `FluentStyles.xaml` | Ton sombre + accent bleu (par défaut) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rouge + noir |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espace sombre |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Coucher de soleil lumineux |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océan sombre |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordique lumineux |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumes lumineux |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral lumineux |

Les changements de thème déclenchent un redémarrage automatique de l\'application. (enregistré dans `theme.cfg`)

### Fonction de Texture d\'Arrière-plan

Sélectionnez une image dans la carte **Background Texture** de l\'onglet Themes pour l\'appliquer comme arrière-plan de toute l\'application. Fonctionne avec n\'importe quel thème sélectionné.

**Formats d\'entrée pris en charge** : `.png` / `.jpg` / `.jpeg`, jusqu\'à 50Mo, résolution 4K ou inférieure

**Pipeline de traitement d\'image**

```
Image sélectionnée par l\'utilisateur (.png / .jpg / .jpeg, max 50Mo, 4K ou inférieur)
  ↓
Compression JPEG Q75 (tampon mémoire)
  ↓
En-tête magique de 16 octets inséré
  "MODAPI" + "BG" + version + remplissage (FF 00 FE 00)
  ↓
Enregistré sous resources\textures\ui_bg\bg.dat (attribut Hidden)
  ↓
Hash SHA-256 → stocké dans ui.cfg comme TextureHash
```

**Couches de sécurité**

| Couche | Méthode | Effet |
|---|---|---|
| En-tête magique | 16 octets ajoutés avant la signature JPEG (FF D8 FF) | Les visionneuses externes ne peuvent pas reconnaître le fichier |
| Attribut Hidden | `FileAttributes.Hidden` | Caché de l\'Explorateur par défaut |
| Intégrité SHA-256 | Hash vérifié au chargement | La falsification déclenche une réinitialisation automatique + popup d\'avertissement |

**Comportement de détection de falsification**
1. `bg.dat` supprimé
2. Clés `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` réinitialisées
3. TextBox et toggle réinitialisés
4. Popup `Lang.Windows.TextureTampered` affiché

**Clés ui.cfg**

| Clé | Valeur | Description |
|---|---|---|
| `TexturePath` | Nom de fichier (affichage uniquement) | Nom de fichier original affiché dans TextBox |
| `TextureHash` | SHA-256 hex | Hash de vérification d\'intégrité |
| `TextureActive` | `true` / `false` | État d\'activation |

**Traitement de transparence**

Lorsque l\'image d\'arrière-plan est active, les arrière-plans de l\'UI sont traités en deux couches.

- **Layer 1 — Overlay MergedDictionaries** : Les panneaux référençant `{DynamicResource FluentBgBrush}` etc. sont automatiquement rendus transparents. Restaurés par un seul appel `Remove()` lors de la désactivation.

  Clés cibles : `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — Parcours de l\'arbre visuel (`WalkStyleBackgrounds`)** : Les éléments `{StaticResource}` dans les thèmes Fluent ne sont pas affectés par Layer 1, donc l\'arbre visuel est parcouru directement pour appliquer des brosses semi-transparentes basées sur les couleurs originales.

  Traités : `Panel` (sauf Grid), `Border`, `ListBox` / `ListView`

  Exclus : `Grid` (arrière-plan préservé, enfants parcourus), `TabPanel` (protection d\'en-tête d\'onglet), `ButtonBase` / `ComboBox`, éléments `Collapsed`

  Restauration : source Style Setter → `ClearValue()`, source valeur locale XAML → restaurer la brosse originale directement

**Changement d\'onglet** : WPF TabControl charge le contenu des onglets de manière différée, donc `WalkStyleBackgrounds(this)` est ré-exécuté avec la priorité `ContextIdle` lors du changement d\'onglet.

**Verrouillage ThemeSelector** : Lorsque la texture d\'arrière-plan est active, un Border `ThemeSelectorOverlay` est affiché au-dessus du sélecteur de thème pour bloquer l\'interaction.

**Nouvelles clés de langue**

| Clé | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nouveaux noms de thèmes |
| `Lang.Options.Labels.TextureBackground` | Étiquette de texture d\'arrière-plan |
| `Lang.Options.Labels.TextureEnable` | Étiquette d\'activation |
| `Lang.Options.Labels.TextureClear` | Bouton effacer |
| `Lang.Windows.TextureTooLarge` | Avertissement de taille de fichier dépassée |
| `Lang.Windows.TextureTampered` | Avertissement de falsification détectée |

**Contraintes de conception connues**

| Élément | Détails |
|---|---|
| `IsEnabled=false` sur ComboBox | Cause un crash `ElementNotEnabledException` → approche overlay `IsHitTestVisible` utilisée |
| Remplacement direct de clés `MergedDictionaries` | Crash pendant le passe de mise en page → uniquement pattern `Add`/`Remove` |
| Écrasement de fichier Hidden | `Access Denied` → doit réinitialiser `FileAttributes.Normal` avant l\'écriture |
| Arrière-plans `{StaticResource}` | Non affectés par Layer 1 → nécessite WalkStyleBackgrounds (Layer 2) |

---

## Changements dans v2.0.9612

### Séparation du Module de Thèmes

- **Nouveau dossier `Themes/`** : Déplacés `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` et `FluentStylesClassic.xaml` vers `ModAPI\Themes\`
- **`App.xaml.cs`** : `ApplyTheme()` — le thème Classic utilise uniquement `Dictionary.xaml` ; Light/Dark/autres thèmes Fluent chargent le XAML correspondant
- **`ModAPI.csproj`** : Chemins XAML de thèmes mis à jour vers le sous-répertoire `Themes\` ; enregistré `FluentStylesClassic.xaml`

---

## Changements dans v2.0.9611

### Correction de Bug

- **Largeur de liste de mods non appliquée après changement de thème** : Corrigé un problème où la largeur de la liste Mods n\'était pas appliquée après le changement entre thèmes Light/Dark et le redémarrage — ajouté l\'appel `ApplyModListWidth(width)` dans `InitModListWidth()`

---

## Changements dans v2.0.9610

### Ajouté

#### Configuration XML de Jeux et Versions

| # | Fichier | Modification |
|---|------|--------|
| 1 | `GH.xml` | Réécriture complète — supprimé l'inexistant `DOTweenPro.dll`; added `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Réécriture complète — supprimé `extends="GenericUnityGame"`; added `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Réécriture complète — supprimé `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Créé — version `1.1.01` with checksum |
| 5 | `GH/Versions.xml` | Créé — version `2.9.5` with checksum |
| 6 | `Subnautica/Versions.xml` | Créé — sans checksum (mises à jour trop fréquentes) |

#### Corrections de Bugs Critiques

| # | Type | Problème | Correctif |
|---|------|-------|-----|
| 1 | Blocage | `extends="GenericUnityGame"` caused `Assembly-CSharp-firstpass.dll` inheritance → `CreateModLibrary` stalled | Removed `extends` from all non-TheForest XML |
| 2 | Plantage | `ResolutionException: XGamingRuntime.XUserGamertagComponent` during Subnautica apply | Added `XGamingRuntime.dll`, `XblPCSandbox.dll` to `copyAssembly` |
| 3 | Plantage | Le résolveur a échoué on DLLs added to `copyAssembly` after backup created | `Game.cs`: actual install folder added as resolver fallback |
| 4 | Plantage | `IOException`: `BaseModLib.dll` file-lock between `CreateModLibrary` and `ApplyMods` | Retry loop: max 10 × 500ms read + max 30 × 500ms existence wait |
| 5 | Plantage | `NullReferenceException` — `typesMap` entry.Value null (game not installed) | Added `if (entry.Value == null) continue` |
| 6 | Plantage | `NullReferenceException` — constructeur léger `Game` constructor missing `ModLibrary = new ModLib(this)` → `CreateModLibrary()` crash | Added `ModLibrary = new ModLib(this)` to lightweight constructor |
| 7 | Plantage | `SwitchDevGame()` — `App.Game.GamePath` empty after lightweight constructor → `CreateModLibrary` crash | Set `App.Game.GamePath = savedPath` after lightweight constructor |
| 8 | Mauvais Jeu | `EscapeThePacific` mods classified as TheForest | `ModsViewModel`: `GameId` extracted from folder path |
| 9 | Mauvais Chemin | `GetGameFolder()` → `""` → resolves to drive root (e.g. `E:\`) | Null/empty guard at all 6 call sites |

#### Séparation de Compilation Debug / Release

- **`FileValidator.cs`** — nouveau fichier `ModAPI_Shared\Utils\FileValidator.cs` ; enregistré dans `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — en-tête PE (MZ + PE\0\0) + minimum 1 Mo
  - `IsValidGameExe()` — en-tête PE + minimum 512 Ko
  - `IsValidAssemblyDll()` — en-tête PE + en-tête de métadonnées CLR .NET + minimum 64 Ko
- **`CheckSteam()`** — `#if DEBUG` : `File.Exists()` uniquement / `#else` : `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG` : `File.Exists()` uniquement / `#else` : `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG` : `File.Copy()` Cecil omis / `#else` : analyse Cecil complète + modification IL
- **`ModLib.Create()` fichier non trouvé** — `#if DEBUG` : journaliser avertissement, ignorer / `#else` : journaliser erreur, abandonner

#### Tests Debug

- **`create_dummy_Debug_games.ps1`** — Script PowerShell pour `bin\Debug\` ; crée des fichiers de 0 octet pour les 5 jeux sous `dummy_games\`, `dummy_steam\` et `gamefiles\original\` — permet des tests complets du flux de travail de l'UI sans installation réelle du jeu

#### Onglet Settings

- **Carte de chemin Steam** — intégrée dans la carte des Chemins d'Installation des Jeux ; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Game paths panel** — `BuildGamePathsPanel()` with per-game expandable cards ; TextBox utilise `HorizontalAlignment=Stretch`
- Bouton **Tout Développer / Tout Réduire**
- Case à cocher **Toujours au Premier Plan** (enregistrée dans `ui.cfg`)
- Curseurs de **Largeur de Liste Mods/Projets** — début au minimum `150` ; enregistré dans `ui.cfg`
- ComboBox **Taille de Police** — FHD 10–16, 4K 10–22, 8K 10–28
- **Synchronisation des cases** — `SettingsCheckboxes.DataContext = SettingsVm` ; AutoUpdate / UseSteam / UpdateVersions se synchronisent maintenant correctement
- **Indicateur `_uiInitialized`** — empêche les écritures prématurées de `ui.cfg` pendant le démarrage WPF

#### Onglet Mods — Validation de Lancement de Jeu

La validation en cinq étapes s'exécute à chaque clic de Lancement de Jeu, quel que soit l'état de la liste de mods :

| Étape | Vérification | Popup |
|---|---|---|
| 1 | Chemin Steam dans l'onglet Settings valide (`Steam.exe` existe) | SteamNotFound |
| 2 | Jeu dans le dossier `mods/{GameId}/` correspond au jeu configuré dans Settings | GameModsMismatch |
| 3 | Au moins un mod sélectionné | NoModSelected |
| 4 | Pas de mods de jeux mixtes dans la sélection | MixedGameMods |
| 5 | Chemin du jeu configuré + exécutable existe | GamePathNotSet / GameNotInstalled |

#### Onglet Development — Validation ModLib

Validation en trois étapes au clic de Régénération de Bibliothèque de Mods :

| Étape | Vérification | Popup |
|---|---|---|
| 1 | Chemin Steam dans l'onglet Settings valide | SteamNotFound |
| 2 | Au moins un projet existe | NoProjectWarning |
| 3 | `App.Game.GamePath` défini | GamePathNotSet |

#### Onglet Downloads
- Chaîne de débogage remplacée par `Lang.Downloads.Status.NoDownloads`
- Remplissage cohérent pour tous les messages de statut
- Texte manuel hors ligne mis à jour pour 5 jeux supportés ; saut de ligne via deux TextBlocks

#### Configuration Initiale et Système de Chemins de Jeux
- `FirstSetup.Check()` — valeur par défaut `true` pour `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crée les dossiers `mods/` et `projects/` pour les 5 jeux
- `SpecifyGamePath` — `GameNameLabel` affiche quel jeu ; `NavigateToSettings()` redirige vers l'onglet Settings

#### Clés de Langue Nouvelles / Mises à Jour

| Clé | Valeur Anglaise |
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

### Non Inclus

| Fonctionnalité | Raison |
|---|---|
| Mise à jour auto (garder la dernière version) | Infrastructure côté serveur non disponible |
| Recherche de mises à jour | Infrastructure côté serveur non disponible |

### Supprimé

| Élément | Raison |
|---|---|
| Popup `SpecifyGamePath` au démarrage | Tous les chemins configurés dans l'onglet Settings |
| Popup `SpecifySteamPath` au démarrage | Chemin Steam configuré dans l'onglet Settings |
| Système de connexion | Serveur original plus opérationnel (supprimé dans v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Non fonctionnel sur Mono 2.0 (supprimé dans v2.0.9586) |
| Condition `UseSteam` sur la vérification Steam | Steam est maintenant toujours validé en premier au Lancement de Jeu et à la Régénération de Bibliothèque de Mods |

---

## Prévu pour les Versions Futures

| # | Fonctionnalité | Description |
|---|---|---|
| 1 | Mise à jour automatique de ModAPI | Télécharger et appliquer automatiquement les nouvelles versions de ModAPI |
| 2 | Mise à jour de la table VersionsData | Mettre à jour automatiquement la table VersionsData lors de nouveaux correctifs du jeu |

---

## Changements dans v2.0.9600

### Ajouté

- **Onglet Downloads** : 5 filtres de jeux (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Onglet Welcome** : ajouté à la position la plus à gauche (index 0)
- **Onglet Mods** : disposition en 3 colonnes (WrapPanel → liste verticale) ; ajustement automatique de largeur ; retour à la ligne du nom de mod
- **`ModsViewModel`** : filtrage spécifique par jeu, `ResolveGame()` pour l'instance `Game` correcte par mod
- **`Game.cs`** : constructeur léger `new Game(config, true)` — identification uniquement, sans `Verify()`
- **Build** : 4 fichiers XML de jeux enregistrés dans `ModAPI.csproj` avec `CopyToOutputDirectory=Always`
- **Build** : avertissements nettoyés — CS0168, CS0618, CS0252
- **XML de Jeux** : listes de DLL de TheForest, Raft, GH corrigées
- **Drapeaux de langue** : tailles d'image standardisées sur les 13 badges de langue

### Supprimé

| Élément | Raison |
|---|---|
| `extends="GenericUnityGame"` dans les fichiers XML de jeux | Causait un héritage incorrect de `Assembly-CSharp-firstpass.dll` — supprimé de Subnautica, Raft, EscapeThePacific, GH |
| Disposition `WrapPanel` dans l'onglet Mods | Remplacé par une disposition Grid en 3 colonnes (Filtre de Jeux / Liste de Mods / Information) |

---

## Changements Principaux par Phase

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Les 5 projets migrés de .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Système de 3 thèmes, `theme.cfg`, correction du glissement de fenêtre, support des hyperliens.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Système de connexion supprimé, mécanisme de mise à jour modernisé.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Onglet Downloads, icônes Segoe MDL2 Assets, support de 13 langues.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, patchage d'en-tête PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Écran noir corrigé, `ValueTuple` supprimé, C# 7.3 vérifié en jeu.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 filtres de jeux, onglet Mods en 3 colonnes, constructeur léger `Game`, XML enregistré.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML corrigé, chemin Steam, sécurité des chemins de jeux, validation en 5 étapes pour le lancement de jeu, validation en 3 étapes pour ModLib, vérification d'en-tête PE `FileValidator`, séparation de compilation `#if DEBUG`, `create_dummy_Debug_games.ps1`, correction du constructeur léger `ModLibrary`, correction de GamePath dans `SwitchDevGame`, création de dossiers pour 5 jeux, corrections de plantages.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Onglet Themes ajouté, 10 thèmes + fonction de texture de fond, séparation du dossier Themes/, correction du bouton maximiser, correction de l'expansion de chemin de jeu, mise à jour de Versions.xml pour 4 jeux, boutons de réinitialisation de chemin, auto-enregistrement Browse, MODAPI_VersionTool.

---

## Historique des Versions

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool ajouté (outil WPF autonome de mise à jour de version), affichage de version dans StatusBar lié à App.Version

### v2.0.9617 — 2026-04-24
Boutons de réinitialisation de chemin Steam/jeu ajoutés dans l'onglet Settings, auto-enregistrement Browse, état de réinitialisation préservé via drapeau ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml créé/mis à jour pour 4 jeux (Subnautica, Raft, EscapeThePacific, GH), règles de composition de checksum établies, procédure de mise à jour de jeu documentée

### v2.0.9615 — 2026-04-18
Correction de précision de hauteur d'expansion de carte de chemin de jeu dans Settings, prévention d'interférence de texture d'arrière-plan dans UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Bouton maximiser avec maximisation manuelle basée sur WorkArea, sauvegarde et restauration de taille/position précédente

### v2.0.9613 — 2026-04-18
Onglet Themes ajouté, structure de registre de thèmes pilotée par les données, 10 thèmes supportés, fonction de texture d'arrière-plan (compression, sécurité, transparence à 2 couches), overlay de verrouillage ThemeSelector, 12 nouvelles clés de langue

### v2.0.9612 — 2026-04-18
Séparation du dossier Themes/, modularisation XAML des thèmes

### v2.0.9611 — 2026-04-18
Correction de largeur de liste de mods non appliquée après changement de thème

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 game filters, Mods tab 3-column layout, auto width, lightweight `Game` constructor, `ModsViewModel` game filtering, 4 XML files registered, build warnings cleaned, Welcome tab, language flags standardized

### v2.0.9586 — 2026-03-31
Black screen fixed, polyfill finalized, ValueTuple removed, C# 7.3 verified

### v2.0.9561 — 2026-03-06
C# 7.3 support, PE header patching, polyfill pipeline, assembly resolution restored

### v2.0.9552 — 2026-02-25
Downloads tab, icon modernization, theme unification, 13-language support

### v2.0.9500
Theme system (Classic/Light/Dark), Fluent Design UI, SubWindow system

### v2.0.9400
Code cleanup, login removal, legacy modernization

### v2.0.9300
Build environment, UnityEngine stub DLL, ModernWpf integration

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Exigences de Compilation

| Exigence | Version | Notes |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projets ModAPI |
| .NET Framework SDK | 3.5 | BaseModLib uniquement |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Licence

GNU General Public License v3.0 — suit la licence originale.
