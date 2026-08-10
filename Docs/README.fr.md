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

# ModAPI(v1) v2.0.9622 - 20260808

**Outil de Gestion de Mods pour The Forest — Édition Améliorée**

> Original : FluffyFish / Philipp Mohrenstecher (Engelskirchen, Allemagne)
> Amélioration : zzangae (République de Corée)

---

## Vue d'ensemble

ModAPI est une application de bureau permettant de gérer des mods pour **5 jeux officiellement pris en charge**. Cette édition améliorée comprend la prise en charge multi-jeux, un onglet Settings entièrement repensé, la configuration du chemin Steam, des paramètres d'interface persistants, un système dynamique de taille de police, la validation au lancement du jeu, une séparation des builds Debug/Release, ainsi que de nombreuses corrections de plantages vérifiées par des tests en jeu.

---

## Jeux Pris en Charge

| Jeu | Moteur | Version | ID Steam | Exécutable |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Patch 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Bêta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 5 (mis à niveau depuis Unity 4) |
| Dernière version | v1.12 (VR) |
| Dernière mise à jour | 11 septembre 2019 — patch de prise en charge VR ; aucune mise à jour de contenu majeure depuis |
| Exécutable | `TheForest.exe` |
| Dossier de données | `TheForest_Data/Managed/` |
| Dossier des mods | `mods/TheForest/` |
| Dossier des projets | `projects/TheForest/` |
| ID d'app Steam | `242760` |
| IL2CPP | ❌ Mono — entièrement pris en charge |

The Forest est passé de Unity 4 à Unity 5, améliorant considérablement les graphismes et la physique. Le patch VR de septembre 2019 fut la dernière mise à jour majeure. Le jeu reste désormais dans un état stable et finalisé — idéal pour le modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity (base de code intégrée, unifiée avec Below Zero en 2022) |
| Dernière version | Patch 2025 (v18810395) |
| Dernière mise à jour | 12 août 2025 — corrections de bugs et améliorations de performance accompagnant la sortie mobile |
| Exécutable | `Subnautica.exe` |
| Dossier de données | `Subnautica_Data/Managed/` |
| Dossier des mods | `mods/Subnautica/` |
| Dossier des projets | `projects/Subnautica/` |
| ID d'app Steam | `264710` |
| IL2CPP | ❌ Mono — pris en charge |

Construit à l'origine sur Unity 5, Subnautica a reçu la mise à jour « Living Large » (v2.0) fin 2022, qui a fusionné la base de code du moteur avec Below Zero pour une optimisation et une stabilité améliorées. Remarque : le prochain *Subnautica 2* utilise l'Unreal Engine 5.

> **XML réécrit en v2.0.9610** : `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` ajoutés à `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity |
| Dernière version | v1.1.02 (Bêta) / v1.09 (Stable) |
| Dernière mise à jour | Mars 2026 — corrections de bugs de chat vocal et multijoueur via la branche bêta |
| Exécutable | `Raft.exe` |
| Dossier de données | `Raft_Data/Managed/` |
| Dossier des mods | `mods/Raft/` |
| Dossier des projets | `projects/Raft/` |
| ID d'app Steam | `648800` |
| IL2CPP | ❌ Mono — pris en charge |
| Versions.xml | `1.1.01` (avec somme de contrôle) |

Après la conclusion officielle de l'histoire dans la v1.0 : *The Final Chapter*, les correctifs se sont poursuivis pour améliorer le code réseau et la stabilité. Une mise à jour de la branche bêta en mars 2026 a résolu des problèmes de chat vocal et de multijoueur.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 6 (migré depuis Unity 2021/2022 fin 2025) |
| Dernière version | v0.67.0.0 |
| Dernière mise à jour | 26 juin 2025 — refonte de la distribution des îles et mise à jour du moteur ; correctifs en cours jusqu'en 2026 |
| Exécutable | `EscapeThePacific.exe` |
| Dossier de données | `EscapeThePacific_Data/Managed/` |
| Dossier des mods | `mods/EscapeThePacific/` |
| Dossier des projets | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — pris en charge |

A achevé une refonte majeure du système et la migration vers Unity 6 fin 2025, permettant des environnements plus dynamiques. Le jeu reste en développement actif en Accès Anticipé.

> **XML réécrit en v2.0.9610** : `extends="GenericUnityGame"` supprimé ; `includeAssembly` défini uniquement sur `Assembly-CSharp.dll` — empêche les erreurs d'héritage de `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Élément | Valeur |
|---|---|
| Moteur | Unity 2019 |
| Dernière version | v2.9.5 |
| Dernière mise à jour | 4 février 2026 — optimisation Steam Deck et améliorations de la lisibilité du texte |
| Exécutable | `GH.exe` |
| Dossier de données | `GH_Data/Managed/` |
| Dossier des mods | `mods/GH/` |
| Dossier des projets | `projects/GH/` |
| ID d'app Steam | `763790` |
| IL2CPP | ❌ Mono — pris en charge |
| Versions.xml | `2.9.5` (avec somme de contrôle) |

Développé à travers Unity 2017 → 2018 → 2019 tout au long de son cycle de vie. Le correctif de février 2026 s'est concentré sur la compatibilité Steam Deck et la lisibilité de l'interface.

> **XML réécrit en v2.0.9610** : `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` ajoutés ; `DOTweenPro.dll` (inexistant) supprimé.
</details>

---

<details>
<summary><b>Architecture</b></summary>

### Séparation de l'Environnement d'Exécution

| Composant | Cible | Environnement d'exécution | Raison |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Application de bureau, API moderne complète |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Bibliothèque partagée |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Fixé de façon permanente** — l'en-tête PE doit indiquer `v2.0.50727` |
| DLL de mods (utilisateur) | .NET Framework 4.8 | Game Mono 2.0 (patché) | Compilé avec 4.8, en-tête PE patché lors de l'application |

### Outils de Développement

Utilitaires WPF autonomes pour la gestion de projets. Non distribués aux utilisateurs finaux.

| Outil | Projet | Objectif |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Met à jour simultanément la version de `AssemblyInfo.cs` et `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Gère les fichiers de langue — ajout, modification, désactivation, intégration native |

**VersionTool — Gestion des Versions**

Un outil WPF autonome pour mettre à jour le numéro de version en un clic.

- Affiche automatiquement la version actuelle (lue depuis `App.xaml.cs`)
- Saisissez une nouvelle version et cliquez sur **Apply Version** pour mettre à jour les deux fichiers simultanément
- Validation de format : seul le format `X.X.XXXX` est accepté

| Fichier | Chemin | Modification |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Système de Langues**

```
resources/langs/langs.json          ← Registre des langues (indicateurs builtin / active)
resources/langs/Language.XX.xaml    ← Clés de traduction par langue
resources/langs/Language.XX.png     ← Image de drapeau (36×24, depuis flagcdn.com/h24/)
```

Flux d'intégration native (bouton Update) :
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() réécrit (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml enregistré (ModAPI\ModAPI.csproj)
  → Prochaine compilation : langue entièrement intégrée, disponible hors ligne
```

### Séparation des Builds Debug / Release

Toute la validation de fichiers et le traitement des assemblys se ramifient selon la configuration de build via `#if DEBUG` / `#else`.

| Emplacement | Build Debug | Build Release |
|---|---|---|
| `CheckSteam()` | uniquement `File.Exists()` — les fichiers factices passent | `FileValidator.IsValidSteamExe()` — en-tête PE + min. 1 Mo |
| `CheckGamePath()` | uniquement `File.Exists()` — les fichiers factices passent | `FileValidator.IsValidAssemblyDll()` — en-tête PE + métadonnées CLR + min. 8 Ko |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — analyse Cecil ignorée | Analyse Mono.Cecil complète + modification IL + `module.Write()` |
| `ModLib.Create()` — fichier introuvable | Enregistre un avertissement, ignore et continue | Enregistre une erreur, interrompt avec une fenêtre contextuelle |

**Les tests Debug** utilisent `create_dummy_Debug_games.ps1` pour générer des fichiers factices de 0 octet sous `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` et `bin\Debug\gamefiles\original\`. Ceux-ci passent les vérifications `File.Exists()` et permettent de tester l'ensemble du flux de travail de l'interface sans installation réelle du jeu.

**Les builds Release** appliquent `FileValidator` (vérification de l'en-tête PE + métadonnées CLR .NET) pour rejeter les fichiers de 0 octet, les fichiers texte et les binaires arbitraires. Seuls les exécutables Windows et assemblys .NET valides passent.

### FileValidator — Vérification de l'En-tête PE

`ModAPI_Shared\Utils\FileValidator.cs` — appliqué uniquement dans les builds Release.

| Méthode | Vérifications | Taille minimale |
|---|---|---|
| `IsValidSteamExe(path)` | Signature MZ + signature PE\0\0 | 1 Mo |
| `IsValidGameExe(path)` | Signature MZ + signature PE\0\0 | 512 Ko |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + en-tête de métadonnées CLR (répertoire de données #14) | 8 Ko |

```
Disposition de l'en-tête PE vérifiée :
[0x00] 4D 5A          ← signature DOS "MZ"
[0x3C] XX XX XX XX   ← décalage de l'en-tête PE (petit-boutiste)
[offset] 50 45 00 00 ← signature "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← présence de l'en-tête CLR .NET
```

### Pipeline de Remappage des Assemblys

```
[Le développeur du mod compile avec .NET 4.8]
  → DLL du mod : en-tête PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, etc.
  → modModule.RuntimeVersion = "v2.0.50727"
      en-tête PE : v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → en-tête PE accepté ✅  →  références résolues ✅
```

### Repli du Résolveur d'Assemblys

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← dossier de sauvegarde
2. {ActualGameInstallPath}/{AssemblyPath}        ← dossier d'installation du jeu (repli)
```

### Prise en Charge des Fonctionnalités C# 7.3

| Fonctionnalité | État | Remarques |
|---|---|---|
| Correspondance de motifs (`is`, `switch`) | ✅ | Vérifié en jeu |
| Interpolation de chaînes (`$""`) | ✅ | Vérifié en jeu |
| Variable `out` en ligne | ✅ | Vérifié en jeu |
| `async` / `await` | ✅ | Via AsyncBridge + polyfills System.Threading |
| Tuples (`ValueTuple`) | ❌ Limite stricte | ABI `mscorlib` de Mono 2.0 — aucune solution de contournement |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Depuis la v2.0.9613, l'interface de sélection de thème a été déplacée de l'onglet Settings vers un onglet **Themes** dédié. Ajouter un nouveau thème ne nécessite qu'une seule ligne dans le dictionnaire `App.xaml.cs`.

| Index | ID | Fichier | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` uniquement | Fond de texture original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Ton clair + accent bleu |
| 2 | `dark` | `FluentStyles.xaml` | Ton foncé + accent bleu (par défaut) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rouge + noir |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espace sombre |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Coucher de soleil lumineux |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océan sombre |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordique lumineux |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumes lumineux |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral lumineux |

Le changement de thème déclenche un redémarrage automatique de l'application. (enregistré dans `theme.cfg`)

| Thème | Thème |
| :---: | :---: |
|**01. Thème Classic**|**02. Thème Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/1f8866b2-1715-45b6-9ada-c550da6d14fc) | ![02. Light theme](https://github.com/user-attachments/assets/180bb717-d4a4-490d-8fd5-c32338ad338f) |
|**03. Thème Dark**|**04. Thème Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/577934f1-9962-4042-9595-023eecc12ab0) | ![04. Diablo theme](https://github.com/user-attachments/assets/7b32e134-d661-4493-b275-54b8c2c04abf) |
|**05. Thème Nebula**|**06. Thème Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/e88b5162-58f6-460a-90a1-f26f2b589591) | ![06. Sunset theme](https://github.com/user-attachments/assets/12bb187c-0187-432e-8819-235abc68d149) |
|**07. Thème Ocean**|**08. Thème Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/3be28095-8872-471a-b066-36c58585a0db) | ![08. Nordic theme](https://github.com/user-attachments/assets/b43a8183-5b43-41a0-ba59-f9a37cc44e2e) |
|**09. Thème Citrus**|**10. Thème Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/1f971fdf-411a-4db4-9941-4c37f6567656) | ![10. Bloom theme](https://github.com/user-attachments/assets/5b8ed319-7947-4209-b85e-1caeacac39e8) |

### Texture de Fond

Sélectionnez une image dans la carte **Background Texture** de l'onglet Themes pour l'appliquer comme fond d'écran de toute l'application. Formats pris en charge : `.png` / `.jpg` / `.jpeg`, jusqu'à 50 Mo, résolution 4K ou inférieure. L'image est compressée en JPEG Q75 avec un en-tête magique de 16 octets et enregistrée sous `resources\textures\ui_bg\bg.dat` (attribut Hidden). Hash SHA-256 pour la vérification d'intégrité ; toute altération déclenche une réinitialisation automatique + une fenêtre d'avertissement.

Lorsque le fond est actif, la transparence de l'interface est traitée en deux couches : Couche 1 (superposition MergedDictionaries) pour les panneaux `{DynamicResource}`, Couche 2 (WalkStyleBackgrounds) pour les panneaux basés sur `{StaticResource}` avec semi-transparence.

### Système de Taille de Police

| Clé de ressource | Base | Description |
|---|---|---|
| `AppBaseFontSize` | 13 | Texte normal |
| `AppBaseHeaderFontSize` | 16 | En-têtes, titres de panneaux |
| `AppBaseSmallFontSize` | 12 | Étiquettes secondaires |
| `AppBaseTinyFontSize` | 10 | Texte d'indication |
| `AppBaseLargeFontSize` | 20 | Texte d'affichage large |

### Configuration Persistante de l'Interface — `ui.cfg`

| Clé | Par défaut | Description |
|-----|---------|-------------|
| `ModListWidth` | `150` | Largeur de la liste de l'onglet Mods (px) |
| `ProjectListWidth` | `150` | Largeur de la liste de projets de l'onglet Development (px) |
| `AppFontSize` | `13` | Taille de police globale de l'interface (px) |
| `AlwaysOnTop` | `false` | Fenêtre toujours au premier plan |
| `TexturePath` | *(aucun)* | Nom de fichier original de la texture de fond (affichage uniquement) |
| `TextureHash` | *(aucun)* | Hash SHA-256 de la texture de fond |
| `TextureActive` | `false` | État d'activation de la texture de fond |
| `GamePathReset_{GameId}` | *(aucun)* | Indicateur de réinitialisation du chemin du jeu |
| `SteamPathReset` | *(aucun)* | Indicateur de réinitialisation du chemin Steam |
</details>

<details>
<summary><b>Structure du Projet</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Paramètres persistants de l'interface
├── theme.cfg                            # Thème actuel
├── Windows/
│   ├── MainWindow.xaml / .cs            # Interface principale — 6 onglets, Themes, Settings, chemin Steam,
│   │                                    #   protection contre les téléchargements de 0 octet, anti-rebond du curseur, lectures silencieuses de la configuration
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Fenêtre contextuelle de chemin de jeu (GameNameLabel dynamique)
│       ├── FirstSetup.xaml / .cs        # Configuration initiale + initialisation des valeurs par défaut
│       └── (14 autres SubWindows)
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
│   ├── Mod.cs                           # Chargement de fichiers de mods, analyse d'en-tête LF/CRLF, journal de diagnostic
│   ├── ModLib.cs                        # Génération de BaseModLib + remappage (séparation #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Création/compilation/application de projet + protections null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   prévention des nouvelles tentatives pour mods corrompus
│   │   ├── ModViewModel.cs              # GameId à partir du chemin du dossier
│   │   ├── ModProjectsViewModel.cs      # Dispose() pour DispatcherTimer
│   │   └── SettingsViewModel.cs         # Valeur par défaut true pour UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Mappage des versions d'assemblys Mono 2.0 (20 assemblys)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Résolveur basé sur le nom avec mise en cache
│   └── MonoHelper.cs                    # Utilitaires d'aide IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 fichiers de langue + langs.json (clés LangTool.* ajoutées en v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Image de fond compressée et sécurisée (générée à l'exécution)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Réécriture complète en v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Réécriture complète en v2.0.9610
    │   ├── GH.xml                       # Réécriture complète en v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — non pris en charge
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt avec paramètre silent
├── Data/
│   ├── Game.cs                          # Création automatique de sauvegarde pour ApplyMods, résolveur conditionnel,
│   │                                    #   repli sur le dossier du jeu, correction du constructeur léger + initialisation ModLib
│   └── ModLib.cs                        # Séparation #if DEBUG, repli sur le dossier du jeu pour IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Validation de l'en-tête PE + métadonnées CLR (Release uniquement, min. 8 Ko)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Outil WPF autonome de mise à jour de version
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Saisie de version, bouton Apply, affichage de la version actuelle
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Outil WPF autonome de gestion des langues
├── App.xaml / App.xaml.cs              # Chargement/changement de langue, langtool.cfg
├── MainWindow.xaml / .cs               # Interface principale — liste des langues, panneau d'édition, sélecteur de chemin
├── AddLanguageDialog.xaml / .cs        # ComboBox de sélection de pays ISO 3166-1
├── ModApiDialog.xaml / .cs             # Boîte de dialogue personnalisée au style ModAPI (Info/Avertissement/Confirmation/Question)
├── Models/
│   ├── LanguageEntry.cs                # Modèle d'entrée de langue (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Modèle racine de langs.json
│   └── IsoCountry.cs                   # Modèle de pays ISO pour ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Lecture/écriture de langs.json
    ├── FlagDownloader.cs               # Téléchargement de drapeau depuis flagcdn.com h24
    ├── XamlGenerator.cs                # Génération/enregistrement/analyse de Language.XX.xaml
    ├── MissingKeyDetector.cs           # Détection des clés manquantes par rapport à la référence anglaise
    ├── IsoCountryList.cs               # Liste complète des pays ISO 3166-1 (196 pays, hors ligne)
    └── BuiltinCodeWriter.cs            # Réécriture de CreateDefaultLangsJson() + enregistrement dans ModAPI.csproj

bin\Debug\                               # Pour les tests Debug uniquement
├── create_dummy_Debug_games.ps1         # Génère une structure de jeu/Steam factice
├── dummy_games\{GameId}\               # Chemins d'installation de jeux factices
├── dummy_steam\Steam.exe               # Exécutable Steam factice
└── gamefiles\original\{GameId}\        # Chemins de sauvegarde factices pour ModLib
```

---

</details>

<details>
<summary><b>Installation et Configuration</b></summary>

### Étape 1 — Prérequis

| Élément | Requis |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (préinstallé sur Windows 11 ; [télécharger](https://dotnet.microsoft.com/download/dotnet-framework/net48) pour Windows 10) |
| Steam | Requis — doit être configuré dans l'onglet Settings |
| Au moins un jeu pris en charge | Requis — doit être configuré dans l'onglet Settings |

### Étape 2 — Installer ModAPI

1. Téléchargez la dernière version depuis GitHub
2. Extrayez dans un dossier quelconque (par ex. `C:\ModAPI\`)
3. Exécutez `ModAPI.exe`
4. Au premier lancement, l'écran **Welcome** apparaît — configurez les préférences et cliquez sur **Continue**

### Étape 3 — Configurer le Chemin Steam (Onglet Settings)

1. Accédez à l'onglet **Settings**
2. Recherchez **Steam Installation Path**
3. Cliquez sur **Browse** → sélectionnez `Steam.exe`
4. Cliquez sur **Save**

### Étape 4 — Configurer les Chemins des Jeux (Onglet Settings)

1. Cliquez sur l'en-tête d'une carte de jeu pour la développer
2. Cliquez sur **Browse** → sélectionnez le dossier racine du jeu (où se trouve le `.exe`)
3. Cliquez sur **Save**

| Jeu | Exécutable | Exemple de chemin |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Étape 5 — Télécharger des Mods (Onglet Downloads)

1. Accédez à l'onglet **Downloads**
2. Sélectionnez un jeu dans le filtre de jeu
3. Parcourez ou recherchez un mod et cliquez sur **Download**

> **Hors ligne** : téléchargez manuellement les fichiers `.mod` depuis `modapi.survivetheforest.net` et placez-les dans le dossier correspondant :

| Jeu | Dossier |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Étape 6 — Appliquer les Mods et Lancer le Jeu (Onglet Mods)

1. Accédez à l'onglet **Mods**
2. Sélectionnez un jeu dans **Game Filter** (colonne 0)
3. Cochez les mods à activer dans **Mod List** (colonne 1)
4. Cliquez sur **Start Game**

Les vérifications suivantes s'exécutent automatiquement avant le lancement :

| # | Vérification | Fenêtre contextuelle en cas d'échec |
|---|---|---|
| 1 | Chemin Steam configuré et valide | SteamNotFound |
| 2 | Le jeu du dossier `mods/` correspond au chemin de jeu de Settings | GameModsMismatch |
| 3 | Au moins un mod sélectionné | NoModSelected |
| 4 | Aucun mélange de mods de différents jeux dans la sélection | MixedGameMods |
| 5 | Chemin du jeu configuré et exécutable existant | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Aperçu des Onglets</b></summary>

### Onglet Welcome
Écran de configuration initiale (index d'onglet 0). Configurez AutoUpdate, la connexion Steam et les préférences du tableau VersionsData. Lors des lancements suivants, cet onglet propose des liens communautaires et des notes de version.

### Onglet Mods
Flux de travail principal de gestion des mods — disposition à 3 colonnes :

| Colonne | Contenu |
|---|---|
| Colonne 0 | Game Filter — boutons radio pour les 5 jeux pris en charge |
| Colonne 1 | Mod List — mods installés avec sélecteur de version et case d'activation |
| Colonne 2 | Information — détails, description et historique des versions du mod sélectionné |

### Onglet Downloads
Parcourez et téléchargez des mods depuis `modapi.survivetheforest.net`.

- **Game filter** : TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter** : 12 catégories (corrections de bugs, équilibrage, triches, …)
- **Search** : par nom de mod, description ou auteur
- **Offline mode** : affiche les instructions de dossier pour les 5 jeux pris en charge

### Onglet Development
Flux de travail de développement de mods — le panneau de filtre de jeu (colonne 0) couvre les 5 jeux pris en charge.

- Création, compilation et application de projets de mods par jeu
- Gestion des ressources linguistiques
- Génération de ModLib avec validation en 3 étapes (Steam → projet → chemin du jeu)
- Changement de jeu sécurisé via un constructeur `Game` léger (pas d'appel à `Verify()`)

### Onglet Themes
Sélection de thème et gestion de la texture de fond.

- **Sélection de thème** : 10 thèmes (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Texture de fond** : sélectionnez une image comme fond pour toute l'application (compression JPEG + traitement de sécurité)
- Lorsque la texture de fond est active, la sélection de thème est verrouillée

### Onglet Settings
Configuration centralisée — 4 lignes :

| Ligne | Contenu |
|---|---|
| 0 | Langue / Taille de police / Largeur maximale / Largeur de Mod List / Largeur de Project List |
| 1 | Conserver VersionsData / Mise à jour automatique / Connexion Steam / Toujours au premier plan |
| 2 | Steam Installation Path (champ texte + Browse + Save + Reset) |
| 3 | Game Installation Paths — carte extensible par jeu (champ texte + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Outil de Gestion des Langues)

Un outil WPF autonome pour gérer les fichiers de langue de ModAPI. Ajouté à la solution sous `LangTool\MODAPI_LangTool.csproj`.

**Emplacement** : `LangTool\MODAPI_LangTool.csproj`

**Fonctionnalités Principales**

| Fonctionnalité | Description |
|---|---|
| Liste des langues | Affiche toutes les langues de `langs.json` avec des icônes d'état (🔒 intégré / 🚫 inactif / ✅ actif) |
| Ajout de langue | Sélectionnez un pays dans le ComboBox ISO 3166-1 → le drapeau est téléchargé automatiquement depuis `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` est généré automatiquement à partir du modèle anglais |
| Modification de langue | `isoCode` / `langCode` verrouillés ; `langName` et les clés de traduction sont modifiables lorsque actif |
| Désactiver / Activer | Bascule l'indicateur `active` dans `langs.json` — le fichier est conservé, masqué de la liste ModAPI |
| Mise à jour (intégration native) | Convertit `builtin: false` → `true` — irréversible, confirmation en 2 étapes — réécrit automatiquement `CreateDefaultLangsJson()` dans le code source et enregistre `Language.XX.xaml` dans `ModAPI.csproj` |
| Détection des clés manquantes | Compare avec la référence anglaise — affiche le nombre de clés manquantes/vides et la progression de la traduction |
| Protection des langues intégrées | Les langues avec `builtin: true` sont en lecture seule — aucune modification, désactivation ou mise à jour possible |
| Protection des langues inactives | Les langues avec `active: false` sont en lecture seule jusqu'à réactivation |
| Interface de langue | LangTool prend lui-même en charge les 13 langues de ModAPI — sélecteur de langue avec drapeau en haut à droite |
| Mémorisation du chemin | Le chemin racine de ModAPI sélectionné est enregistré dans `langtool.cfg` — chargé automatiquement au prochain lancement |
| Boîtes de dialogue personnalisées | Toutes les fenêtres contextuelles utilisent le `ModApiDialog` à thème sombre au style ModAPI au lieu de la MessageBox système |

**Structure de langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Convention des Images de Drapeau**

```
Code ISO (minuscules) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                        resources/langs/
```

**Comportement du Bouton Update**

Lors du clic sur le bouton Update pour une langue active non intégrée :

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` réécrit avec toutes les langues actuellement `builtin: true`
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` enregistré
4. Prochaine compilation — langue entièrement intégrée, disponible hors ligne

**Clés de Langue Ajoutées** (`Lang.LangTool.*`)

53 nouvelles clés ajoutées aux 13 fichiers de langue couvrant toutes les chaînes de l'interface LangTool, les messages de dialogue et les textes d'état.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Outil de Mise à Jour de Version)

Un outil WPF autonome pour mettre à jour le numéro de version en un clic.

**Emplacement** : `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Fonctionnalités**
- Affiche automatiquement la version actuelle (lue depuis `App.xaml.cs`)
- Saisissez une nouvelle version et cliquez sur **Apply Version** pour mettre à jour les deux fichiers simultanément
- Validation de format : seul le format `X.X.XXXX` est accepté

**Fichiers Modifiés**

| Fichier | Chemin | Modification |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Utilisation**
1. Exécutez `MODAPI_VersionTool.exe`
2. Saisissez la nouvelle version (par ex. `2.0.9619`)
3. Cliquez sur **Apply Version**
4. Reconstruisez la solution ModAPI dans Visual Studio

**Affichage de la Version dans la StatusBar**

- `VersionLabel.Text` fait désormais référence à `App.Version` au lieu d'un descripteur codé en dur
- La mise à jour de la version avec VersionTool et une reconstruction se reflètent immédiatement dans la StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Système de Journalisation — Séparation en Deux Fichiers (`ModAPI.log` / `ModAPI.detailed.log`)

Les journaux de diagnostic réservés aux développeurs étaient auparavant limités par `#if DEBUG`, ce qui les rendait invisibles dans les builds Release exactement au moment où ils étaient le plus nécessaires pour résoudre un problème utilisateur. Un système à deux fichiers remplace cela :

| Fichier | Contenu |
|---|---|
| `ModAPI.log` | Journal principal orienté utilisateur — apparence inchangée, pas plus bruyant qu'avant |
| `ModAPI.detailed.log` | Chaque appel de journalisation, toujours, en Release comme en Debug — pour diagnostiquer les problèmes signalés par les utilisateurs |

**`Debug.cs`** — `Log()` possède un paramètre `detailedOnly`. Lorsqu'il est `true`, le message n'est écrit que dans `ModAPI.detailed.log` ; tous les blocs `#if DEBUG` précédents ont été convertis en cet indicateur au lieu d'être entièrement exclus de la compilation, de sorte qu'ils soient toujours capturés dans le fichier détaillé, même en Release. Cela aboutit à un modèle de gravité à 4 niveaux :

| Niveau | Signification |
|---|---|
| Verbose (`detailedOnly: true`) | Traces répétitives/mécaniques — par type, par fichier, par méthode |
| Notice | Flux lisible par l'humain — messages de progression et de succès |
| Warning | Problèmes potentiels, pas encore des échecs |
| Error | Échecs confirmés |

**Sources de bruit de journalisation identifiées et converties en `detailedOnly: true` :**

| Fichier | Ce qui inondait `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Messages de scan/ignorer/file d'attente de `FindMods()` répétés à chaque sondage d'1 seconde |
| `Game.cs` | Lignes de trace TLS/URL de `UpdateVersions()`, entrées de mappage de types Cecil |
| `ModLib.cs` | Traitement des assemblys par type/méthode par Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — responsable de la grande majorité du volume de `ModAPI.log` (des dizaines de milliers de lignes pour une seule compilation de mod Green Hell) |
| `Mod.cs` | Vidage complet du XML d'en-tête du mod (`configuration.ToString()`) enregistré intégralement à chaque chargement de mod |

**Journalisation des discordances de somme de contrôle — résumée plutôt que par élément :** `Header.Verify()` enregistrait auparavant une ligne `Mismatched checksum at "..."` par entrée incompatible `InjectInto`/`AddMethod`/`AddField`/`AddClass`, ce qui pouvait représenter des dizaines de lignes pour un seul mod obsolète. Il enregistre désormais un résumé unique de niveau Warning dans `ModAPI.log` (par ex. `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), tandis que la ventilation complète par élément reste disponible dans `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Changements dans la v2.0.9622</b></summary>

## Changements dans la v2.0.9622

### Correction de Bug — Calcul du Checksum Unifié

La vérification d'intégrité de `StartGame()` (Vérification B) recalculait elle-même le checksum via `FileValidator.ComputeAssemblyChecksum()`, qui ne hache jamais qu'une paire fixe de fichiers (`Assembly-CSharp` + `Assembly-CSharp-firstpass`). Cela ne correspondait pas structurellement à des jeux comme The Forest, qui lient 4 fichiers (firstpass + principal + UnityScript-firstpass + UnityScript) — la vérification signalait une fausse incohérence de checksum même lorsque les fichiers du jeu n'avaient pas été modifiés.

- `Game.CheckSumGame` (déjà calculé correctement par `GenerateCheckSums()` au moment de `Verify()`, en suivant la vraie liste `VersionsData.CheckFiles` de chaque jeu — 2 fichiers pour Green Hell, 4 pour The Forest, etc.) est désormais exposé en `public` et réutilisé directement dans `StartGame()` au lieu d'être recalculé avec un jeu de fichiers différent et codé en dur.
- Le calcul du checksum est désormais unifié en une seule source de vérité (`GenerateCheckSums()`), quel que soit le nombre de fichiers réellement requis par un jeu donné.

### Fichiers modifiés

| Fichier | Chemin | Modification |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | `CheckSumGame` changé de `protected` à `public` |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | La vérification d'intégrité de `StartGame()` réutilise `targetGame.CheckSumGame` au lieu de recalculer via `FileValidator.ComputeAssemblyChecksum()` |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9621</b></summary>

## Changements dans la v2.0.9621

### Nouvelles fonctionnalités

#### Détection automatique sur l'ensemble des bibliothèques Steam

`FindGamePath()` recherche désormais, lorsqu'un jeu n'est pas trouvé via ses `SearchPaths` codés en dur, dans **toutes les bibliothèques Steam enregistrées sur le système** (analysées une fois depuis `libraryfolders.vdf`, mises en cache pour la session). Cela s'applique aux 5 jeux pris en charge, pas seulement au jeu actif.

- Nouveau `Game.GetSteamLibraryFolders()` — analyse `libraryfolders.vdf`, mis en cache statiquement par session
- Contrôlé par la case **Connexion Steam** : décochée (valeur par défaut à l'installation) → la détection automatique est ignorée pour les 5 jeux, les chemins restent vides jusqu'à configuration manuelle. Cochée → les 5 jeux sont recherchés de façon cohérente via la même méthode.

#### Détection automatique des mods pour le mauvais jeu

Un fichier `.mod` placé dans le dossier du mauvais jeu (par exemple un mod Green Hell copié dans `mods\TheForest\`) est désormais détecté automatiquement au lieu de corrompre silencieusement une opération d'application.

- `Game.CheckModGameCompatibility()` (utilisé dans `ApplyMods()`) vérifie que chaque type `AddMethod`/`AddField`/`InjectInto` déclaré par un mod existe réellement dans les assemblies réelles du jeu cible avant le début de l'injection. Les mods incompatibles sont automatiquement exclus de cette application ; le reste s'applique normalement.
- `Game.CheckModGameCompatibilityLight()` + `Game.GetCachedTypeNames()` effectuent la même vérification au moment du chargement du mod (léger — lit les octets de l'assembly en mémoire, extrait les noms de types, libère immédiatement le fichier). Les mods incompatibles affichent un **badge d'avertissement ⚠** avec infobulle dans l'onglet Mods, avant même de cliquer sur Appliquer.
- Si des mods ont été exclus et/ou que rien n'a finalement été appliqué, Démarrer le jeu affiche une seule fenêtre combinée au lieu de plusieurs empilées ; le jeu n'est pas lancé s'il ne reste aucun mod appliqué (`Game.LastAppliedModCount`).

#### Onglet Paramètres — Journal développeur / Effacer les journaux au démarrage

Deux nouvelles cases, après **Connexion Steam** et avant **Toujours au premier plan** :

| Clé | Description |
|---|---|
| `Lang.Options.Labels.DevLog` | Active `ModAPI.dev.log` (renommé depuis `ModAPI.detailed.log`) — équivalent à un lancement avec `--dev` |
| `Lang.Options.Labels.ClearLogsOnStart` | Vide le dossier `logs\` à chaque démarrage |

`Debug.ClearLogs()` ferme les flux de journalisation ouverts avant de supprimer les fichiers, évitant les erreurs de "fichier en cours d'utilisation".

#### Journalisation globale des exceptions non gérées

`App.xaml.cs` intercepte désormais `DispatcherUnhandledException` (thread UI) et `AppDomain.UnhandledException` (threads en arrière-plan). Les exceptions qui faisaient auparavant planter l'application sans aucune trace sont maintenant enregistrées — type, message et trace de pile complète — avant la fin du processus.

---

### Corrections critiques

| # | Fichier | Problème | Correction |
|---|---|---|---|
| 1 | `Configuration.cs` | `GetPath()` résolvait un chemin explicitement réinitialisé (chaîne vide) en `RootPath` au lieu de `""`, car `Path.GetFullPath(RootPath + séparateur + "")` se réduit à `RootPath` | Les valeurs stockées vides retournent désormais `""` directement, avant la jonction de chemin |
| 2 | `MainWindow.xaml.cs` | L'ordre de validation de Démarrer le jeu différait entre le filtre "Tous" et un filtre spécifique, affichant parfois une fenêtre de sélection de mod ou de jeu avant un problème plus fondamental (chemin Steam/jeu manquant) | Les deux chemins suivent désormais le même ordre : Steam → chemin du jeu → sélection des mods → sélection du jeu |
| 3 | `MainWindow.xaml.cs` | La collecte des mods pour Démarrer le jeu ignorait le filtre de jeu actif — les mods cochés pour un autre jeu (invisible) étaient tout de même comptabilisés, déclenchant la mauvaise fenêtre | La collecte des mods respecte désormais le filtre actuel ; seul "Tous" agrège l'ensemble des jeux |
| 4 | `ModsViewModel.cs` | `Mod.Mods` était indexé uniquement par `{ModId}-{Version}`, donc des noms de fichiers identiques dans deux dossiers de jeux différents entraient en collision — `Load()` du second n'était jamais appelé | La clé inclut désormais le GameId : `{GameId}-{ModId}-{Version}` |
| 5 | `ModsViewModel.cs` | Après la correction n°4, `UpdateMods()` regroupait toujours les entrées de liste uniquement par ModId, fusionnant deux mods portant le même nom de jeux différents en une seule entrée — plantage avec `ArgumentException: An item with the same key has already been added` lorsque les deux déclaraient la même version | Le regroupement d'affichage compare désormais aussi le GameId |
| 6 | `Game.cs` | La liste `<files>` du `Versions.xml` de Green Hell contient les deux mêmes fichiers en double avec une casse différente (`_Data`/`_data`) ; `CheckFiles` était un `HashSet<string>` sensible à la casse, donc les deux étaient hachés, doublant la somme de contrôle calculée et provoquant de faux échecs d'intégrité | `CheckFiles` utilise désormais `StringComparer.OrdinalIgnoreCase` |
| 7 | `Game.cs` / `ModLib.cs` | L'étape de "suppression des anciens fichiers" de `ModLib.Create()` n'avait aucune protection par nouvelle tentative contre un `BaseModLib.dll` verrouillé, et `Game.CreateModLibrary()` n'avait aucune gestion d'exceptions — un verrou faisait planter toute l'application dans un thread en arrière-plan | Boucle de nouvelle tentative de 10×500 ms ajoutée à l'étape de suppression ; `CreateModLibrary()` encapsule désormais l'appel dans un try/catch |
| 8 | `MainWindow.xaml.cs` | Lorsque `ApplyMods()` se terminait sans qu'aucun mod ne soit réellement appliqué (par exemple tous exclus), il signalait quand même l'achèvement comme un vrai succès, donc le jeu se lançait sans aucune modification | `Game.LastAppliedModCount` distingue "rien d'appliqué" de "N appliqués" ; le lancement est ignoré à 0 |
| 9 | `MainWindow.xaml.cs` | La hauteur de la fenêtre n'était recalculée ni lors du changement de taille de police, ni au chargement au démarrage d'une grande taille de police enregistrée, ni lors du passage à l'onglet Paramètres (`Tabs_SelectionChanged` était vide) — la dernière carte de chemin de jeu était rognée avec de grandes tailles de police | Recalcul de la hauteur ajouté aux trois points |
| 10 | `MainWindow.xaml.cs` | `UpdateWindowHeight()` n'avait pas de limite supérieure — développer les 5 cartes de chemin de jeu en même temps pouvait faire atteindre à la fenêtre la taille de l'écran entier ou plus | Hauteur désormais plafonnée à `SystemParameters.WorkArea.Height` |
| 11 | `MainWindow.xaml.cs` | Les dossiers `mods\`/`projects\` étaient créés sans condition pour les 5 jeux à chaque démarrage, que le jeu soit installé ou non | Les dossiers ne sont désormais créés que pour les jeux avec un chemin vérifié et un exécutable existant |
| 12 | `Game.cs` | `UpdateVersions()` pouvait échouer à enregistrer `Versions.xml` si le dossier de destination n'existait pas encore (masqué jusqu'ici car les 5 dossiers sont livrés pré-validés) | Le dossier est créé via `Directory.CreateDirectory()` juste avant l'enregistrement |

---

### Onglet Paramètres — Valeurs par défaut au premier lancement modifiées

`AutoUpdate`, `UseSteam` (Connexion Steam) et `UpdateVersionsTable` (Maintenir la table VersionsData) sont désormais **décochées** par défaut lors d'une installation neuve (auparavant cochées par défaut). Ces trois fonctionnalités restent incomplètes côté serveur, elles sont donc désormais opt-in — comme `DevLog`/`ClearLogsOnStart`.

### Interface

- Ligne de cases à cocher de l'onglet Paramètres (`SettingsCheckboxes`) : `StackPanel` → `WrapPanel`, afin que les libellés passent à la ligne suivante au lieu d'être rognés avec de grandes tailles de police.

### Nouvelles clés de langue (13 langues)

| Clé | Valeur anglaise |
|---|---|
| `Lang.Options.Labels.DevLog` | Developer Log |
| `Lang.Options.Labels.ClearLogsOnStart` | Clear Logs on Start |
| `Lang.Windows.IncompatibleModsExcluded.Title` | Some Mods Excluded |
| `Lang.Windows.IncompatibleModsExcluded.Text` | The following mod(s) appear to be built for a different game and were excluded: {0} |
| `Lang.Windows.IncompatibleModsExcluded.OK` | OK |
| `Lang.Windows.NoModsApplied.Title` | No Mods Applied |
| `Lang.Windows.NoModsApplied.Text` | No valid mods remained to apply, so the game was not started. |
| `Lang.Windows.NoModsApplied.OK` | OK |

### Fichiers modifiés

| Fichier | Chemin | Modification |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Ordre de validation de Démarrer le jeu unifié, collecte de mods sensible au filtre, fenêtre de résultat combinée, détection automatique sur 4 jeux via bibliothèque Steam contrôlée par UseSteam, corrections de hauteur de fenêtre (taille de police / changement d'onglet / plafond) |
| `MainWindow.xaml` | `ModAPI\Windows\` | Cases DevLog/ClearLogsOnStart de l'onglet Paramètres, `WrapPanel` |
| `Game.cs` | `ModAPI_Shared\Data\` | Recherche en bibliothèque Steam, `CheckFiles` insensible à la casse, vérifications de compatibilité des mods (complète + légère), `LastAppliedModCount`/`LastExcludedModsSummary`, gestion des exceptions dans `CreateModLibrary()`, détection automatique contrôlée par UseSteam |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Boucle de nouvelle tentative à la suppression des anciens fichiers |
| `Mod.cs` | `ModAPI_Shared\Data\` | Champ `GameMismatchReason` |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Correction du bug de chemin vide dans `GetPath()` |
| `Debug.cs` | `ModAPI_Shared\` | Renommage en `ModAPI.dev.log`, champ `DevMode`, `ClearLogs()` |
| `App.xaml.cs` | `ModAPI\` | Gestionnaires d'exceptions globaux, connexion de `Debug.DevMode` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Clés `Mod.Mods` par jeu, regroupement d'affichage par jeu, badge d'incompatibilité, suppression du spam de journaux |
| `ModViewModel.cs` | `ModAPI\Data\ViewModels\` | `HasGameMismatch`/`GameMismatchTooltip` |
| `SettingsViewModel.cs` | `ModAPI\Data\ViewModels\` | `DevLog`/`ClearLogsOnStart`, valeurs par défaut opt-in pour 3 cases existantes |
| `FirstSetup.xaml` | `ModAPI\Windows\SubWindows\` | Valeurs par défaut de 3 cases changées à décoché |
| `ModsExcludedWarning.xaml` / `.cs` | `ModAPI\Windows\SubWindows\` | Nouveau |
| 13x `Language.XX.xaml` | `ModAPI\resources\langs\` | 8 nouvelles clés |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9620</b></summary>

## Changements dans la v2.0.9620

### Ajout de MODAPI_LangTool

Un outil WPF autonome pour gérer les fichiers de langue de ModAPI a été ajouté (`LangTool\MODAPI_LangTool.csproj`) — voir la section **Lang Tool** ci-dessus pour tous les détails.

---

### Corrections de Bugs

| # | Fichier | Problème | Correction |
|---|---|---|---|
| 1 | `App.xaml.cs` | Le français se mélangeait aux messages d'exception .NET sur Windows non anglais | `CultureInfo.InvariantCulture` fixé au démarrage du constructeur `App()` |
| 2 | `Game.cs` | Erreur SSL/TLS lors de `UpdateVersions()` — impossible de créer un canal sécurisé SSL/TLS | TLS 1.2 défini explicitement via `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Fenêtre contextuelle `GamePathNotSet` pour Green Hell malgré un chemin configuré | `App.Game.GamePath` vide → lit le chemin enregistré depuis `Configuration` |
| 4 | `ModsViewModel.cs` | Les fichiers de mods n'apparaissaient pas dans la liste lorsqu'ils étaient placés manuellement dans `mods\TheForest\` | Ajout d'un journal de diagnostic de validation du motif de nom de fichier |
| 5 | `MainWindow.xaml.cs` | La fenêtre contextuelle `MixedGameMods` bloquait la sélection de mods multi-jeux | Fenêtre contextuelle bloquante supprimée — remplacée par `SelectGameDialog` |

---

### Nouvelles Fonctionnalités

#### Lancement du Jeu — Fenêtre Contextuelle de Sélection de Jeu (`SelectGameDialog`)

Lorsque des mods de différents jeux sont sélectionnés, ou lorsque le filtre **All** est actif, une fenêtre contextuelle de sélection de jeu apparaît au lieu de bloquer le lancement.

**Conditions de déclenchement :**
- Filtre `All` sélectionné + clic sur Start Game
- Mods de 2 jeux différents ou plus activés simultanément

**Comportement :**
- N'affiche que les jeux avec des chemins configurés et un exécutable existant
- Seuls les mods du jeu sélectionné sont appliqués — les mods des autres jeux sont totalement ignorés
- Le bouton radio se synchronise avec le jeu sélectionné après la fermeture de la fenêtre contextuelle (`SyncModGameFilterRadioButton`)

**Nouveaux fichiers** : `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Vérification de l'Intégrité du Jeu (build Release uniquement, `#if !DEBUG`)

Une vérification d'intégrité à trois couches s'exécute avant chaque lancement du jeu :

| Couche | Méthode | En cas d'échec |
|---|---|---|
| A — En-tête PE | `FileValidator.IsValidGameExe()` | Bloqué + fenêtre contextuelle `GameExeCorrupted` |
| B — Somme de contrôle de l'assembly | Comparaison MD5 → `Versions.xml` | Bloqué + fenêtre contextuelle `GameAssemblyTampered` |
| C — Signature numérique | `HasDigitalSignature()` | Avertissement + choix de l'utilisateur (`GameIntegrityWarning`) |

**Nouveaux fichiers** : `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Nouvelles méthodes ajoutées à `FileValidator.cs`** :
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 de Assembly-CSharp.dll (+ firstpass s'il existe)
- `HasDigitalSignature(path)` — vérification de signature Authenticode

---

### Nouveaux Journaux de Diagnostic

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 éléments, Release + Debug)

| # | Phase | Type | Contenu |
|---|---|---|---|
| 1 | Configuration TLS | Notice | Protocole avant/après |
| 2 | Début du téléchargement | Notice | Liste des serveurs |
| 3 | Tentative d'URL | Notice | Chaque URL tentée |
| 4 | Téléchargement réussi | Notice | URL, longueur de la réponse, protocole utilisé |
| 5 | WebException | Error | URL, statut HTTP, protocole, détail |
| 6 | Autre exception | Error | URL, type d'exception, détail |
| 7 | Téléchargement terminé | Notice | Nombre de succès / total des serveurs |
| 8 | Analyse réussie | Notice | Nombre de fichiers et versions avant/après |
| 9 | Échec d'analyse | Error | Type d'exception et détail |
| 10 | Enregistrement réussi | Notice | Chemin d'enregistrement, total versions/fichiers |
| 11 | Échec d'enregistrement | Error | Chemin, type d'exception, détail |
| 12 | Aucune réponse | Error | Serveurs tentés, protocole |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 éléments, `#if DEBUG` uniquement)

| # | Situation | Type | Contenu |
|---|---|---|---|
| 1 | Début du scan | Notice | Chemin du dossier des mods, total des fichiers trouvés |
| 2 | Déjà chargé | Notice | Nom de fichier |
| 3 | Pas un fichier .mod | Notice | Nom de fichier |
| 4 | Correspondance de motif réussie | Notice | Nom de fichier mis en file d'attente |
| 5 | Échec de correspondance de motif | Warning | Nom de fichier + raison + format attendu |
| 6 | Scan terminé | Notice | Nombre en file d'attente / total des fichiers |
| 7 | Exception | Error | Détail de l'exception |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 éléments, Release + Debug)

| # | Situation | Type | Contenu |
|---|---|---|---|
| 1 | Condition de la fenêtre contextuelle | Notice | Filtre actuel, IDs de jeux sélectionnés, needGameSelect |
| 2 | Jeux candidats | Notice | Liste des IDs candidats pour la fenêtre contextuelle |
| 3 | Chemin non défini | Notice | Jeu ignoré — chemin non configuré |
| 4 | Absent de Configuration | Notice | Jeu ignoré — absent de Configuration.Games |
| 5 | Installation confirmée | Notice | Jeu + chemin de l'exécutable |
| 6 | Exe introuvable | Warning | Jeu ignoré — exécutable manquant |
| 7 | Aucun jeu installé | Error | 0 candidat → GamePathNotSet |
| 8 | Sélection automatique | Notice | Candidat unique sélectionné automatiquement |
| 9 | Annulé par l'utilisateur | Notice | SelectGameDialog annulé |
| 10 | Jeu sélectionné + mods | Notice | Jeu sélectionné, nombre/liste de mods collectés |

---

### Séparation des Journaux Développeur / Utilisateur (`#if DEBUG`)

| Fichier | Journal | Raison |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Se répète chaque seconde — 81 % du volume total de journalisation |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Détail interne réservé aux développeurs |

Le journal Release conserve : succès/échec de téléchargement, résultats d'analyse/enregistrement, échecs de correspondance de motifs, exceptions, résultats de vérification d'intégrité.

---

### Mise à Jour du Tableau des Versions — Architecture

#### Intention de Conception

```
Le jeu reçoit une mise à jour Steam
  → Assembly-CSharp.dll change
  → ModAPI vérifie Versions.xml pour une somme de contrôle connue
  → Si introuvable → télécharge le Versions.xml le plus récent depuis le serveur
  → La nouvelle version est enregistrée automatiquement sans réinstaller ModAPI
```

#### Structure de Connexion

```
Onglet Settings → case à cocher KeepVersionsData
  → Configuration.xml : "UpdateVersions" = true/false
    → Verify() → appel de UpdateVersions()
      → télécharge Versions.xml depuis VersionUpdateDomains[]
      → écrase le configs\games\{GameId}\Versions.xml local
```

#### Intégration de l'URL Raw de GitHub

Au lieu de dépendre uniquement de `modapi.survivetheforest.net`, l'URL Raw de GitHub est désormais utilisée comme source principale pour la gestion directe :

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — géré directement, priorité 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Serveur hérité — repli, priorité 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Élément | Détail |
|---|---|
| Principal | URL Raw de GitHub — mise à jour immédiate à chaque push |
| Repli | Serveur hérité — utilisé lorsque GitHub est indisponible |
| Chemin | `ModAPI/configs/games/{GameId}/Versions.xml` dans le dépôt |
| Fichier modifié | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Mises à Jour de Versions.xml

| Jeu | Fichier | Modification |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Somme de contrôle corrigée (SHA-256 incorrect en majuscules) — `2.9.5b114117` avec le MD5 correct |
| The Forest | `configs\games\TheForest\Versions.xml` | `1.12` (BuildID : 20229486) ajouté — somme de contrôle MD5 à 128 caractères |

---

### Nouvelles Clés de Langue (13 langues)

| Clé | Valeur anglaise |
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
| `Lang.Savegames.*` (133 clés) | Valeurs anglaises ajoutées à 12 langues (DE déjà traduit) |

---

### Fichiers Modifiés

| Fichier | Chemin | Modification |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` fixé au démarrage |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, vérification d'intégrité, MixedGameMods supprimé, synchronisation radio, 10 journaux |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nouveau |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Nouveau |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Journal de diagnostic de nom de fichier, séparation #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 journaux d'UpdateVersions, URL GitHub, séparation #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 nouvelles clés + 133 clés Savegames (515 au total, toutes langues alignées) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Somme de contrôle corrigée |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | `1.12` ajouté |
| `LangTool\` (13 fichiers) | Racine de la solution | Nouveau |
| `ModAPI.sln` | Racine de la solution | LangTool enregistré |

---

### Corrections Supplémentaires et Refonte du Système de Journalisation (2026-06-21)

#### Validation de StartGame — Refonte Complète

L'ordre de validation a été corrigé selon une séquence stricte en 3 étapes, et la fenêtre contextuelle de sélection de jeu reflète désormais les mods activés, que le chemin du jeu soit configuré ou non.

| Étape | Vérification | Fenêtre contextuelle en cas d'échec |
|---|---|---|
| 1 | Steam installé | SteamNotFound |
| 2 | Chemin du jeu sélectionné configuré + exécutable existant | GamePathNotSet |
| 3 | Au moins un mod activé pour le jeu sélectionné | NoModSelected |

- **Filtre All / mods de plusieurs jeux sélectionnés** → la fenêtre contextuelle liste toujours tous les jeux avec un mod activé, **y compris ceux sans chemin configuré** — sélectionner un jeu non configuré affiche désormais correctement `GamePathNotSet` au lieu de l'exclure silencieusement ou d'afficher la mauvaise erreur
- **Filtre pour un seul jeu** → les vérifications de chemin et de mods s'exécutent directement pour ce jeu, dans le même ordre 1→2→3

#### Corrections Critiques de Bugs

| # | Fichier | Problème | Correction |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` fusionnait les réponses de **tous** les serveurs réussis (GitHub + hérité), doublant les sommes de contrôle (64 → 128 caractères) lorsque les deux réussissaient — provoquait de faux blocages `GameAssemblyTampered` | Seule la réponse du premier serveur réussi est analysée ; les serveurs restants sont ignorés dès qu'un succès est obtenu |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` utilisait `App.Game` (filtre actif actuel) au lieu du propre jeu du mod — supprimer un mod Green Hell alors que The Forest était actif recherchait dans le mauvais dossier `Managed` et ignorait silencieusement la suppression | Résout désormais le chemin de la DLL déployée à partir de `mod.Game` (l'instance de jeu réelle du mod), avec un repli sur `Configuration` si `GamePath` est vide |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Retélécharger un mod précédemment supprimé restaurait son badge d'activation comme coché — la suppression d'un mod n'effaçait jamais ses clés persistantes `Selected`/`Version` ni le cache ViewModel en mémoire | Ajout de `RemoveKey()` / `RemoveKeysWithPrefix()` à `Configuration.cs` ; `DeleteMod_Click` force désormais `ModViewModel.Selected = false` et supprime toutes les clés `Mods.{GameId}.{ModId}.*` lors de la suppression |
| 4 | `ModsViewModel.cs` | Supprimer un mod alors qu'un filtre de jeu spécifique (pas « All ») était sélectionné laissait le mod visible dans la liste jusqu'à basculer sur « All » puis revenir | La notification de changement de `FilteredMods` était absente après `_Mods.RemoveAt()` dans la boucle de sondage de suppression de fichier ; elle se déclenche désormais chaque fois qu'un mod est réellement supprimé |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Une exception non gérée lors de la construction ou de l'affichage de la fenêtre contextuelle d'avertissement d'absence de signature pouvait faire planter silencieusement ModAPI sans qu'aucune erreur ne soit journalisée | La construction/affichage de la fenêtre contextuelle et le formatage des messages ont été enveloppés dans un try-catch ; en cas d'échec, l'avertissement est journalisé et l'utilisateur peut continuer en toute sécurité (l'absence de signature est informative, pas un blocage strict) |

#### Avertissement de Signature Numérique — Message Clarifié

Le texte de `GameNoSignature` nomme désormais le jeu concerné et précise que l'absence de signature est attendue pour les titres indépendants et n'affecte pas le jeu, plutôt que de suggérer une possible altération. Mis à jour dans les 13 fichiers de langue avec un espace réservé `{0}` pour le nom d'affichage du jeu (par ex. « The Forest », « Green Hell »).

#### Système de Journalisation — Séparation en Deux Fichiers

Les journaux de diagnostic limités par `#if DEBUG` ont été convertis en un indicateur `detailedOnly` et répartis entre `ModAPI.log` (orienté utilisateur) et `ModAPI.detailed.log` (toujours en détail complet) — voir la section **Log** ci-dessus pour la ventilation complète.

#### Fichiers Modifiés (Supplémentaires)

| Fichier | Chemin | Modification |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Refonte de la validation StartGame, correction de l'instance de jeu dans DeleteMod_Click, try-catch pour GameIntegrityWarning, mappage des noms d'affichage |
| `Game.cs` | `ModAPI_Shared\Data\` | Correction de la réponse unique dans UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Notification de changement de `FilteredMods` lors de la suppression, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 points d'appel) |
| `Mod.cs` | `ModAPI\Data\` | Vidage du XML d'en-tête déplacé vers `detailedOnly`, résumé des discordances de somme de contrôle |
| `Debug.cs` | `ModAPI_Shared\` | Paramètre `detailedOnly`, écriture double fichier, commentaire guide de journalisation à 4 niveaux |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Espace réservé `{0}` pour le nom du jeu, sécurisation try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` réécrit avec un espace réservé pour le nom du jeu |

---


</details>

<details>
<summary><b>Changements dans la v2.0.9619</b></summary>

### Corrections de Bugs

- **Blocage de l'application des mods avec un dossier de sauvegarde vide** : `gamefiles\original\` vide → création automatique de sauvegarde depuis le chemin d'installation du jeu avant la lecture de l'assembly
- **Verrouillage de fichier (IOException) sur les DLL du jeu** : le résolveur d'assemblys exclut conditionnellement le dossier du jeu lorsqu'une sauvegarde existe — empêche Cecil de maintenir des verrous de fichier pendant `DirectoryCopy`
- **Boucle de nouvelle tentative infinie pour mods corrompus** : les fichiers `.mod` défaillants (en-tête corrompu) provoquaient une boucle de rescan d'1 seconde — désormais enregistrés dans `LoadedFiles` pour empêcher le rescan
- **Fichiers de mod à fin de ligne LF rejetés** : l'analyseur d'en-tête `EndsWith("</Mod>\r")` échouait pour les fichiers `.mod` de style Unix — utilise désormais `TrimEnd` pour gérer à la fois CRLF et LF
- **Échec de validation des petites DLL** : `Assembly-UnityScript-firstpass.dll` (21 Ko) était rejeté par `FileValidator` — taille minimale d'assembly abaissée de 64 Ko à 8 Ko
- **Journaux WARNING inutiles** : les chemins de jeu non configurés et les clés de configuration au premier lancement généraient du bruit — paramètre `silent` ajouté à `GetPath`/`GetString`/`GetInt`

### Améliorations

- **Détection des téléchargements de 0 octet** : alerte contextuelle + nettoyage des fichiers temporaires lorsque le serveur renvoie un fichier `.mod` vide (`Lang.Windows.DownloadEmpty`)
- **Anti-rebond pour l'enregistrement du curseur** : `ModListWidth` / `ProjectListWidth` n'est enregistré dans `ui.cfg` qu'une seule fois (500 ms après la fin du glissement) au lieu de à chaque changement de pixel
- **Création conditionnelle de dossiers de jeu** : les dossiers `mods/` et `projects/` ne sont créés que pour les jeux avec des chemins configurés — plus pour les 5 sans condition
- **Journal de diagnostic d'analyse d'en-tête** : affiche le nombre de lignes et un aperçu du contenu en cas d'échec d'analyse d'un fichier `.mod`, pour faciliter le dépannage

### Nouvelles Clés de Langue (13 langues)

| Clé | Valeur anglaise |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Fichiers Modifiés

| Fichier | Chemin | Modification |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Création automatique de sauvegarde, résolveur conditionnel, repli sur le dossier du jeu |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Repli sur le dossier du jeu pour IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 Ko → 8 Ko |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Paramètre `silent` sur GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Protection contre les téléchargements de 0 octet, anti-rebond du curseur, lectures silencieuses de configuration, création conditionnelle de dossiers |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Prévention des nouvelles tentatives pour mods corrompus |
| `Mod.cs` | `ModAPI\Data\` | Analyse d'en-tête LF/CRLF, journal de diagnostic |
| 13× `Language.XX.xaml` | `resources\langs\` | Clés de fenêtre contextuelle `DownloadEmpty` |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9618</b></summary>


### Ajout de MODAPI_VersionTool

Un outil WPF autonome pour mettre à jour le numéro de version en un clic a été ajouté (`VersionTool\MODAPI_VersionTool.csproj`) — voir la section **Version Tool** ci-dessus pour tous les détails.

- `VersionLabel.Text` fait désormais référence à `App.Version` au lieu du `Version.Descriptor` codé en dur, de sorte que les mises à jour se reflètent immédiatement dans la StatusBar après une reconstruction.

---

</details>

<details>
<summary><b>Changements dans la v2.0.9617</b></summary>


### Onglet Settings — Ajout de Boutons de Réinitialisation de Chemin

Un bouton **Reset** a été ajouté à la ligne du chemin d'installation Steam et à chaque ligne de chemin d'installation de jeu.

**Ligne du chemin Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Ligne du chemin de jeu (par jeu)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Comportement de Reset**
- Efface immédiatement le champ texte du chemin
- Enregistre un indicateur de réinitialisation dans `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Le champ texte reste vide après redémarrage
- Contourne le problème selon lequel Configuration XML ne persiste pas les chaînes vides

**Enregistrement automatique de Browse**
- Avant : un clic séparé sur Save était nécessaire après Browse
- Après : enregistrement automatique lors de la sélection de fichier — reflété même après le passage à l'onglet Mods

**Nouvelle clé de langue**

| Clé | Valeur |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9616</b></summary>

### Versions.xml — 4 Jeux Ajoutés / Mis à Jour

| Jeu | Chemin du fichier | BuildID | Remarques |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Nouvellement créé |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Somme de contrôle mise à jour |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Nouvellement créé |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Somme de contrôle mise à jour |

### Règles de Composition de la Somme de Contrôle

Le format de la somme de contrôle diffère selon que `Assembly-CSharp-firstpass.dll` existe ou non pour chaque jeu.

| Jeu | firstpass.dll | Format de somme de contrôle |
|---|---|---|
| GH | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| Subnautica | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| EscapeThePacific | ✅ Présent | `firstpass MD5` + `Assembly-CSharp MD5` concaténés (64 caractères) |
| Raft | ❌ Absent | uniquement `Assembly-CSharp MD5` (32 caractères) |

### Procédure de Mise à Jour de Versions.xml lors d'une Mise à Jour de Jeu

Ajoutez une nouvelle entrée `<version>` sans supprimer les entrées existantes.

**Étape 1 — Trouver le nouveau BuildID**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Jeu | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Étape 2 — Extraire la nouvelle somme de contrôle**
```powershell
# Jeux avec firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concaténer les deux valeurs Hash dans l'ordre (firstpass en premier)

# Jeux sans firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Étape 3 — Ajouter l'entrée à Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Changements dans la v2.0.9615</b></summary>

### Correction de l'Expansion du Chemin de Jeu dans l'Onglet Settings

- **Hauteur d'expansion de la carte** : le bas de la fenêtre s'agrandit désormais exactement de la hauteur du champ de saisie lors de l'expansion d'une carte de chemin de jeu
- **Amélioration de `UpdateWindowHeight()`** : appelle `UpdateLayout()` avant la mesure de `SizeToContent.Height` ; définit temporairement `TextureLayer1` sur `Collapsed` lorsque la texture de fond est active pour empêcher la taille originale d'une image 4K d'affecter le calcul de hauteur
- **Correction de la ligne Grid interne** : la dernière ligne du Grid interne du panneau des chemins de jeu a été changée de `Height="*"` à `Height="Auto"` — supprime l'espace vide inutile en bas

---

</details>

<details>
<summary><b>Changements dans la v2.0.9614</b></summary>

### Correction du Comportement du Bouton Maximiser

- **Maximiser** : utilise `SystemParameters.WorkArea` pour la maximisation manuelle au lieu de `WindowState.Maximized` — s'ajuste exactement à la résolution d'écran actuelle sans chevaucher la barre des tâches
- **Restaurer** : enregistre `Left`, `Top`, `Width`, `Height` et `MaxWidth` avant de maximiser et les restaure lors du clic sur le bouton de restauration
- **Gestion de `MaxWidth`** : défini sur `∞` lors de la maximisation, restauré à la valeur enregistrée lors de la normalisation

---

</details>

<details>
<summary><b>Changements dans la v2.0.9613</b></summary>

### Nouvel Onglet Themes

L'ordre des onglets est désormais :

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

L'interface de sélection de thème a été déplacée de l'onglet Settings vers un onglet **Themes** dédié.
Icône : Segoe MDL2 Assets `&#xE790;` (palette)

### Registre des Thèmes (Structure Basée sur les Données)

Ajouter un nouveau thème ne nécessite désormais qu'**une seule ligne** dans le dictionnaire `App.xaml.cs`.
Toutes les instructions switch ont été supprimées — aucune modification de code n'est nécessaire ailleurs.

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

Les éléments ComboBox de `ThemeSelector` sont générés automatiquement à partir de la boucle `ThemeIds`.
Convention de clé de langue : `Lang.Options.Theme.{PascalCase}` (par ex. `Lang.Options.Theme.Nebula`)

### Thèmes Pris en Charge

| Index | ID | Fichier | Palette |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` uniquement | Fond de texture original de ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Ton clair + accent bleu |
| 2 | `dark` | `FluentStyles.xaml` | Ton foncé + accent bleu (par défaut) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Rouge + noir |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Espace sombre |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Coucher de soleil lumineux |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Océan sombre |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Nordique lumineux |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Agrumes lumineux |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Floral lumineux |

Le changement de thème déclenche un redémarrage automatique de l'application. (enregistré dans `theme.cfg`)

### Fonctionnalité de Texture de Fond

Sélectionnez une image dans la carte **Background Texture** de l'onglet Themes pour l'appliquer comme fond pour toute l'application. Fonctionne avec n'importe quel thème sélectionné.

**Formats d'entrée pris en charge** : `.png` / `.jpg` / `.jpeg`, jusqu'à 50 Mo, résolution 4K ou inférieure

**Pipeline de Traitement d'Image**

```
Image sélectionnée par l'utilisateur (.png / .jpg / .jpeg, max 50 Mo, 4K ou inférieur)
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

**Couches de Sécurité**

| Couche | Méthode | Effet |
|---|---|---|
| En-tête magique | 16 octets ajoutés avant la signature JPEG (FF D8 FF) | Les visionneuses externes ne peuvent pas reconnaître le fichier |
| Attribut Hidden | `FileAttributes.Hidden` | Masqué de l'Explorateur par défaut |
| Intégrité SHA-256 | Hash vérifié au chargement | Toute altération déclenche une réinitialisation automatique + fenêtre d'avertissement |

**Comportement de Détection d'Altération**
1. `bg.dat` supprimé
2. Clés `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` réinitialisées
3. Champ texte et interrupteur réinitialisés
4. Fenêtre contextuelle `Lang.Windows.TextureTampered` affichée

**Clés ui.cfg**

| Clé | Valeur | Description |
|---|---|---|
| `TexturePath` | Nom de fichier (affichage uniquement) | Nom de fichier original affiché dans le champ texte |
| `TextureHash` | Hexadécimal SHA-256 | Hash de vérification d'intégrité |
| `TextureActive` | `true` / `false` | État d'activation |

**Traitement de la Transparence**

Lorsque l'image de fond est active, les fonds de l'interface sont traités en deux couches.

- **Couche 1 — Superposition MergedDictionaries** : les panneaux référençant `{DynamicResource FluentBgBrush}`, etc., deviennent automatiquement transparents. Restaurés par un seul appel à `Remove()` lors de la désactivation.

  Clés cibles : `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Couche 2 — Parcours de l'arbre visuel (`WalkStyleBackgrounds`)** : les éléments `{StaticResource}` des thèmes Fluent ne sont pas affectés par la Couche 1, donc l'arbre visuel est parcouru directement pour appliquer des pinceaux semi-transparents basés sur les couleurs d'origine.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=totalement transparent, 255=opaque → 100 ≈ 39 % opaque
  ```

  Traité : `Panel` (sauf Grid), `Border`, `ListBox` / `ListView`

  Exclu : `Grid` (fond conservé, enfants parcourus), `TabPanel` (protection de l'en-tête d'onglet), `ButtonBase` / `ComboBox`, éléments `Collapsed`

  Restauration : source du Setter de style → `ClearValue()`, source de valeur locale XAML → restaure directement le pinceau d'origine

**Changement d'Onglet**

Comme le TabControl WPF charge paresseusement le contenu des onglets, `WalkStyleBackgrounds(this)` est réexécuté avec la priorité `ContextIdle` lors du changement d'onglet. Les éléments déjà traités sont ignorés via une vérification `ContainsKey`.

**Verrouillage de ThemeSelector**

Lorsque la texture de fond est active, une bordure `ThemeSelectorOverlay` s'affiche par-dessus le sélecteur de thème pour bloquer l'interaction.

- XAML : bordure `ThemeSelectorOverlay` ajoutée au-dessus de ThemeSelector (`IsHitTestVisible=True`)
- Actif : `ThemeSelectorOverlay.Visibility = Visible`
- Inactif : `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` également protégé par l'indicateur `_textureActive`

**Flux d'État de l'Interface**

```
Image sélectionnée (Browse)
  → bg.dat créé → interrupteur déverrouillé → activation automatique → TextureLayer1 affiché
  → SaveAndClearBrushes() → ThemeSelectorOverlay affiché

Interrupteur désactivé
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay masqué
  → TextureLayer1 masqué

Bouton Clear
  → bg.dat supprimé → interrupteur verrouillé → TextureLayer1 masqué → pinceaux restaurés
  → GC.Collect() (libère la mémoire de l'image 4K)
```

**Nouvelles Clés de Langue**

| Clé | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 nouveaux noms de thème |
| `Lang.Options.Labels.TextureBackground` | Étiquette de texture de fond |
| `Lang.Options.Labels.TextureEnable` | Étiquette d'activation |
| `Lang.Options.Labels.TextureClear` | Bouton Clear |
| `Lang.Windows.TextureTooLarge` | Avertissement de taille de fichier dépassée |
| `Lang.Windows.TextureTampered` | Avertissement d'altération détectée |

**Structure de Fichiers**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Onglet Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Logique de thème et de texture
├── Themes\
│   ├── Dictionary.xaml            # Thème Classic
│   ├── FluentStyles.xaml          # Thème Dark
│   ├── FluentStylesLight.xaml     # Thème Light
│   ├── FluentStylesDiablo.xaml    # Thème Diablo
│   ├── FluentStylesNebula.xaml    # Thème Nebula
│   ├── FluentStylesSunset.xaml    # Thème Sunset
│   ├── FluentStylesOcean.xaml     # Thème Ocean
│   ├── FluentStylesNordic.xaml    # Thème Nordic
│   ├── FluentStylesCitrus.xaml    # Thème Citrus
│   └── FluentStylesBloom.xaml     # Thème Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Image de fond compressée et sécurisée (générée à l'exécution)
```

**Contraintes de Conception Connues**

| Élément | Détails |
|---|---|
| `IsEnabled=false` sur ComboBox | Provoque un plantage `ElementNotEnabledException` → approche de superposition `IsHitTestVisible` utilisée |
| Remplacement direct des clés `MergedDictionaries` | Plante pendant le passage de mise en page → uniquement le motif `Add`/`Remove` |
| Écrasement d'un fichier caché | `Access Denied` → doit réinitialiser `FileAttributes.Normal` avant l'écriture |
| Fonds `{StaticResource}` | Non affectés par la Couche 1 → nécessitent WalkStyleBackgrounds (Couche 2) |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9612</b></summary>

### Séparation du Module de Thèmes

- **Nouveau dossier `Themes/`** : `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` et `FluentStylesClassic.xaml` déplacés vers `ModAPI\Themes\`
- **`App.xaml.cs`** : `ApplyTheme()` — le thème Classic utilise uniquement `Dictionary.xaml` ; les thèmes Light/Dark/autres Fluent chargent le XAML correspondant
- **`ModAPI.csproj`** : chemins XAML des thèmes mis à jour vers le sous-répertoire `Themes\` ; `FluentStylesClassic.xaml` enregistré

---

</details>

<details>
<summary><b>Changements dans la v2.0.9611</b></summary>

### Correction de Bug

- **Largeur de Mod List non appliquée après changement de thème** : correction d'un problème où la largeur de la liste de mods n'était pas appliquée après un changement entre les thèmes Light/Dark et un redémarrage — ajout de l'appel `ApplyModListWidth(width)` dans `InitModListWidth()`

---

</details>

<details>
<summary><b>Changements dans la v2.0.9610</b></summary>

### Ajouté

#### XML de Jeu et Configuration Versions

| # | Fichier | Modification |
|---|------|--------|
| 1 | `GH.xml` | Réécriture complète — `DOTweenPro.dll` inexistant supprimé ; `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` ajoutés |
| 2 | `Subnautica.xml` | Réécriture complète — `extends="GenericUnityGame"` supprimé ; `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` ajoutés |
| 3 | `EscapeThePacific.xml` | Réécriture complète — `extends="GenericUnityGame"` supprimé ; `includeAssembly` → uniquement `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Créé — version `1.1.01` avec somme de contrôle |
| 5 | `GH/Versions.xml` | Créé — version `2.9.5` avec somme de contrôle |
| 6 | `Subnautica/Versions.xml` | Créé — sans somme de contrôle (se met à jour trop fréquemment) |

#### Corrections Critiques de Bugs

| # | Type | Problème | Correction |
|---|------|-------|-----|
| 1 | Blocage | `extends="GenericUnityGame"` provoquait l'héritage de `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` se bloquait | `extends` supprimé de tous les XML non-TheForest |
| 2 | Plantage | `ResolutionException: XGamingRuntime.XUserGamertagComponent` lors de l'application sur Subnautica | `XGamingRuntime.dll`, `XblPCSandbox.dll` ajoutés à `copyAssembly` |
| 3 | Plantage | Le résolveur échouait sur les DLL ajoutées à `copyAssembly` après la création de la sauvegarde | `Game.cs` : dossier d'installation réel ajouté comme repli du résolveur |
| 4 | Plantage | `IOException` : verrouillage de fichier de `BaseModLib.dll` entre `CreateModLibrary` et `ApplyMods` | Boucle de nouvelle tentative : max 10 × 500 ms de lecture + max 30 × 500 ms d'attente d'existence |
| 5 | Plantage | `NullReferenceException` — entry.Value de `typesMap` nul (jeu non installé) | Ajout de `if (entry.Value == null) continue` |
| 6 | Plantage | `NullReferenceException` — le constructeur `Game` léger manquait `ModLibrary = new ModLib(this)` → plantage de `CreateModLibrary()` | Ajout de `ModLibrary = new ModLib(this)` au constructeur léger |
| 7 | Plantage | `SwitchDevGame()` — `App.Game.GamePath` vide après le constructeur léger → plantage de `CreateModLibrary` | Définition de `App.Game.GamePath = savedPath` après le constructeur léger |
| 8 | Mauvais jeu | Mods `EscapeThePacific` classés comme TheForest | `ModsViewModel` : `GameId` extrait du chemin du dossier |
| 9 | Mauvais chemin | `GetGameFolder()` → `""` → résolu vers la racine du lecteur (par ex. `E:\`) | Protection null/vide aux 6 points d'appel |

#### Séparation des Builds Debug / Release

- **`FileValidator.cs`** — nouveau fichier `ModAPI_Shared\Utils\FileValidator.cs` ; enregistré dans `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — en-tête PE (MZ + PE\0\0) + minimum 1 Mo
  - `IsValidGameExe()` — en-tête PE + minimum 512 Ko
  - `IsValidAssemblyDll()` — en-tête PE + en-tête de métadonnées CLR .NET + minimum 64 Ko
- **`CheckSteam()`** — `#if DEBUG` : uniquement `File.Exists()` / `#else` : `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG` : uniquement `File.Exists()` / `#else` : `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG` : `File.Copy()` sans Cecil / `#else` : analyse Cecil complète + modification IL
- **`ModLib.Create()` fichier introuvable** — `#if DEBUG` : enregistre un avertissement, ignore / `#else` : enregistre une erreur, interrompt

#### Tests Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell pour `bin\Debug\` ; crée des fichiers factices de 0 octet pour les 5 jeux sous `dummy_games\`, `dummy_steam\` et `gamefiles\original\` — permet de tester l'ensemble du flux de travail de l'interface sans installation réelle du jeu

#### Onglet Settings

- **Carte du chemin Steam** — intégrée à la carte Game Installation Paths ; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panneau des chemins de jeu** — `BuildGamePathsPanel()` avec cartes extensibles par jeu ; le champ texte utilise `HorizontalAlignment=Stretch`
- Bouton **Expand All / Collapse All**
- Case à cocher **AlwaysOnTop** (enregistrée dans `ui.cfg`)
- Curseurs **Mod/Project List Width** — démarrent au minimum `150` ; enregistrés dans `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Synchronisation des cases à cocher** — `SettingsCheckboxes.DataContext = SettingsVm` ; AutoUpdate / UseSteam / UpdateVersions se synchronisent désormais correctement
- **Indicateur `_uiInitialized`** — empêche les écritures prématurées de `ui.cfg` pendant le démarrage WPF

#### Onglet Mods — Validation au Lancement du Jeu

Une validation en cinq étapes s'exécute à chaque clic sur Start Game, quel que soit l'état de la liste des mods :

| Étape | Vérification | Fenêtre contextuelle |
|---|---|---|
| 1 | Chemin Steam de l'onglet Settings valide (`Steam.exe` existe) | SteamNotFound |
| 2 | Le jeu du dossier `mods/{GameId}/` correspond au jeu configuré dans Settings | GameModsMismatch |
| 3 | Au moins un mod sélectionné | NoModSelected |
| 4 | Aucun mélange de mods de différents jeux dans la sélection | MixedGameMods |
| 5 | Chemin du jeu configuré + exécutable existant | GamePathNotSet / GameNotInstalled |

#### Onglet Development — Validation de ModLib

Validation en trois étapes lors du clic sur Mod Library Regeneration :

| Étape | Vérification | Fenêtre contextuelle |
|---|---|---|
| 1 | Chemin Steam de l'onglet Settings valide | SteamNotFound |
| 2 | Au moins un projet existant | NoProjectWarning |
| 3 | `App.Game.GamePath` défini | GamePathNotSet |

#### Onglet Downloads
- Chaîne de débogage remplacée par `Lang.Downloads.Status.NoDownloads`
- Marge intérieure cohérente pour tous les messages d'état
- Texte manuel hors ligne mis à jour pour les 5 jeux pris en charge ; saut de ligne via deux TextBlocks

#### First Setup et Système de Chemin de Jeu
- `FirstSetup.Check()` — valeur par défaut `true` pour `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — crée les dossiers `mods/` et `projects/` pour les 5 jeux
- `SpecifyGamePath` — `GameNameLabel` indique de quel jeu il s'agit ; `NavigateToSettings()` redirige vers l'onglet Settings

#### Clés de Langue Nouvelles/Mises à Jour

| Clé | Valeur anglaise |
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
| Mise à jour automatique (conserver la dernière version) | Infrastructure côté serveur non disponible |
| Recherche de mises à jour | Infrastructure côté serveur non disponible |

### Supprimé

| Élément | Raison |
|---|---|
| Fenêtre contextuelle `SpecifyGamePath` au démarrage | Tous les chemins sont configurés dans l'onglet Settings |
| Fenêtre contextuelle `SpecifySteamPath` au démarrage | Le chemin Steam est configuré dans l'onglet Settings |
| Système de connexion | Le serveur original n'est plus opérationnel (supprimé en v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Ne fonctionne pas sur Mono 2.0 (supprimé en v2.0.9586) |
| Condition `UseSteam` sur la vérification Steam | Steam est désormais toujours validé en premier lors de Start Game et de Mod Library Regeneration |

## Prévu pour les Futures Versions

| # | Fonctionnalité | Description |
|---|---|---|
| 1 | Mise à jour automatique de ModAPI | Télécharger et appliquer automatiquement les nouvelles versions de ModAPI |
| 2 | Mise à jour du tableau VersionsData de ModAPI | Mettre à jour automatiquement le tableau VersionsData du jeu lorsque de nouveaux correctifs de jeu sont publiés |

---

</details>

<details>
<summary><b>Changements dans la v2.0.9600</b></summary>

### Ajouté

- **Onglet Downloads** : 5 filtres de jeu (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Onglet Welcome** : ajouté à la position la plus à gauche (index 0)
- **Onglet Mods** : disposition à 3 colonnes (WrapPanel → liste verticale) ; ajustement automatique de la largeur ; retour à la ligne des noms de mods
- **`ModsViewModel`** : filtrage spécifique par jeu, `ResolveGame()` pour l'instance `Game` correcte par mod
- **`Game.cs`** : constructeur léger `new Game(config, true)` — identification uniquement, sans `Verify()`
- **Compilation** : 4 fichiers XML de jeu enregistrés dans `ModAPI.csproj` avec `CopyToOutputDirectory=Always`
- **Compilation** : avertissements nettoyés — CS0168, CS0618, CS0252
- **XML de jeu** : listes DLL de TheForest, Raft, GH corrigées
- **Drapeaux de langue** : tailles d'image standardisées sur les 13 badges de langue

### Supprimé

| Élément | Raison |
|---|---|
| `extends="GenericUnityGame"` dans les fichiers XML de jeu | Provoquait l'héritage incorrect de `Assembly-CSharp-firstpass.dll` — supprimé de Subnautica, Raft, EscapeThePacific, GH |
| Disposition `WrapPanel` dans l'onglet Mods | Remplacée par une disposition Grid à 3 colonnes (Game Filter / Mod List / Information) |

---

</details>

---

## Historique des Versions

<details>
<summary><b>Phase 6-3 — Expansion du Système de Thèmes, Améliorations des Paramètres, Stabilité et Outils</b></summary>

### v2.0.9621 — 2026-07-28

- Détection automatique sur l'ensemble des bibliothèques Steam pour les 5 jeux, contrôlée par la case Connexion Steam
- Détection et exclusion automatique des mods conçus pour un autre jeu (liste + au moment de l'application), avec badge ⚠ dans l'onglet Mods
- Fenêtre de résultat combinée pour les mods exclus / aucun mod appliqué au lieu de fenêtres empilées ; le jeu ne se lance plus avec zéro mod appliqué
- Journalisation globale des exceptions non gérées (thread UI + threads en arrière-plan)
- `ModAPI.dev.log` remplace `ModAPI.detailed.log` ; nouveaux interrupteurs dans l'onglet Paramètres pour le Journal développeur et Effacer les journaux au démarrage
- `AutoUpdate`/`UseSteam`/`UpdateVersionsTable` sont désormais décochées par défaut lors d'une installation neuve
- Corrigé : bug de chemin vide dans `Configuration.GetPath()`, ordre de validation incohérent de Démarrer le jeu, collecte de mods ignorant le filtre, collisions de clés `Mod.Mods` entre jeux et le plantage de `UpdateMods()` qui en résultait, doublement de la somme de contrôle de Green Hell (`_Data`/`_data`), plantage par verrouillage de fichier `BaseModLib.dll`, création inconditionnelle de `mods\`/`projects\`, échec de sauvegarde de `Versions.xml` avec dossier manquant, absence de recalcul de la hauteur de fenêtre au changement de taille de police / d'onglet, hauteur de fenêtre illimitée au "Tout développer"

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool et corrections principales**
- MODAPI_LangTool ajouté (outil WPF autonome de gestion des langues)
- Correction SSL/TLS (TLS 1.2)
- Correction du réglage régional français (`CultureInfo.InvariantCulture`)
- Correction de `GamePathNotSet` pour Green Hell
- SelectGameDialog (filtre All + lancement multi-jeux de mods)
- Blocage par MixedGameMods supprimé
- Vérification d'intégrité du jeu à 3 couches (en-tête PE / somme de contrôle d'assembly / signature numérique)
- Séparation des journaux développeur et utilisateur
- 12 journaux UpdateVersions + 7 journaux FindMods + 10 journaux StartGame
- URL Raw de GitHub comme `VersionUpdateDomains` principale
- Somme de contrôle de `Versions.xml` de GH corrigée
- `1.12` ajouté à `Versions.xml` de TheForest
- 515 clés dans les 13 fichiers de langue

**Corrections supplémentaires (2026-06-21)**
- Ordre de validation de StartGame corrigé (Steam → chemin du jeu → mods)
- La fenêtre contextuelle de sélection de jeu liste désormais correctement les jeux au chemin non configuré
- Correction de la réponse unique dans UpdateVersions (plus de sommes de contrôle dupliquées)
- `DeleteMod` résout désormais la propre instance de jeu du mod au lieu du filtre actif
- Les mods supprimés ne laissent plus de badge « Selected » obsolète lors d'un nouveau téléchargement
- La liste des mods se met désormais à jour immédiatement après suppression, quel que soit le filtre de jeu
- Fenêtre contextuelle `GameIntegrityWarning` renforcée contre les plantages par exceptions non gérées
- Le message d'avertissement de signature numérique nomme désormais le jeu et précise que c'est attendu pour les titres indépendants
- Le système de journalisation à deux fichiers (`ModAPI.log` / `ModAPI.detailed.log`) remplace les journaux limités par `#if DEBUG`, de sorte que les builds Release puissent toujours capturer tous les détails de diagnostic sans surcharger le journal orienté utilisateur

### v2.0.9619 — 2026-05-25

- Création automatique de sauvegarde depuis le chemin d'installation du jeu
- Correction du verrouillage de fichier (résolveur conditionnel)
- Prévention de boucle infinie pour mods corrompus
- Compatibilité avec les mods à fin de ligne LF
- Détection des téléchargements de 0 octet avec fenêtre contextuelle
- Anti-rebond pour l'enregistrement du curseur (500 ms)
- Création conditionnelle de dossiers de jeu
- Taille minimale d'assembly dans `FileValidator` réduite de 64 Ko à 8 Ko
- Paramètre `silent` sur `GetPath`/`GetString`/`GetInt`
- Journal de diagnostic d'analyse d'en-tête
- Clés de langue `DownloadEmpty` (13 langues)

### v2.0.9618 — 2026-04-25
Ajout de MODAPI_VersionTool (outil WPF autonome de mise à jour de version), affichage de version dans la StatusBar lié à App.Version

### v2.0.9617 — 2026-04-24
Ajout de boutons de réinitialisation de chemin Steam/jeu dans l'onglet Settings, enregistrement automatique de Browse, état de réinitialisation préservé via l'indicateur ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml créé/mis à jour pour 4 jeux (Subnautica, Raft, EscapeThePacific, GH), règles de composition de somme de contrôle établies, procédure de mise à jour de jeu documentée

### v2.0.9615 — 2026-04-18
Précision de la hauteur d'expansion de la carte de chemin de jeu dans l'onglet Settings corrigée, interférence de UpdateWindowHeight avec la texture de fond empêchée

### v2.0.9614 — 2026-04-18
Maximisation manuelle du bouton Maximiser basée sur WorkArea, enregistrement et restauration de la taille/position précédente

### v2.0.9613 — 2026-04-18
Onglet Themes ajouté, structure du registre de thèmes basée sur les données, prise en charge de 10 thèmes, fonctionnalité de texture de fond (compression, sécurité, transparence à 2 couches), superposition de verrouillage ThemeSelector, 12 nouvelles clés de langue

### v2.0.9612 — 2026-04-18
Séparation du dossier Themes/, modularisation du XAML de thème

### v2.0.9611 — 2026-04-18
Correction : largeur de Mod List non appliquée après changement de thème

</details>

<details>
<summary><b>Phase 6-2 — Paramètres, Sécurité, Corrections de Plantages et Séparation Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- XML multi-jeux corrigé (GH, Subnautica, EscapeThePacific)
- `Versions.xml` ajouté
- Onglet Settings repensé (chemin Steam, panneau des chemins de jeu, curseurs de largeur, taille de police, synchronisation des cases à cocher)
- Sécurité null du chemin de jeu (6 points)
- Fenêtres contextuelles de démarrage remplacées par l'onglet Settings
- Validation en 5 étapes du lancement du jeu dans l'onglet Mods (Steam toujours en premier)
- Validation ModLib en 3 étapes dans l'onglet Dev
- Fenêtre contextuelle `GameModsMismatch` ajoutée
- Correction du null de `ModLibrary` dans le constructeur léger
- Correction de `GamePath` dans `SwitchDevGame`
- Vérification de l'en-tête PE de `FileValidator` (Release)
- Séparation de build `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- `ui.cfg` persistant
- Système de police à 5 clés
- Multiples corrections de plantages
- Clés de langue mises à jour

</details>

<details>
<summary><b>Phase 6-1 — Multi-Jeux et Refonte des Mods</b></summary>

### v2.0.9600 — 2026-04-09
> 5 filtres de jeu, disposition à 3 colonnes de l'onglet Mods, largeur automatique, constructeur `Game` léger, filtrage de jeu dans `ModsViewModel`, 4 fichiers XML enregistrés, avertissements de compilation nettoyés, onglet Welcome, drapeaux de langue standardisés

</details>

<details>
<summary><b>Phase 5-6B — C# 7.3 et Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Écran noir corrigé, polyfill finalisé, ValueTuple supprimé, C# 7.3 vérifié

</details>

<details>
<summary><b>Phase 5-5 — Résolution d'Assemblys</b></summary>

### v2.0.9561 — 2026-03-06
> Prise en charge de C# 7.3, patching de l'en-tête PE, pipeline de polyfill, résolution d'assemblys restaurée

</details>

<details>
<summary><b>Phase 5-1 — Onglet Downloads et 13 Langues</b></summary>

### v2.0.9552 — 2026-02-25
> Onglet Downloads, modernisation des icônes, unification des thèmes, prise en charge de 13 langues

</details>

<details>
<summary><b>Phases Antérieures</b></summary>

### Phase 3 — Refonte de l'Interface et Système de Thèmes
v2.0.9500
> Système de thèmes (Classic/Light/Dark), interface Fluent Design, système SubWindow

### Phase 4 — Nettoyage du Code
v2.0.9400
> Nettoyage du code, suppression de la connexion, modernisation de l'héritage

### Phase 2 — Environnement de Compilation et Fluent Design
v2.0.9300
> Environnement de compilation, DLL stub UnityEngine, intégration ModernWpf

### Phase 1 — Migration vers .NET 4.8
v2.0.9200
> Migration vers .NET Framework 4.8

### v1.x
Version originale de FluffyFish

</details>

---

## Exigences de Compilation

| Exigence | Version | Remarques |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Projets ModAPI |
| .NET Framework SDK | 3.5 | BaseModLib uniquement |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` dans `libs/polyfills/` |

---

## Licence

GNU General Public License v3.0 — suit la licence originale.
