[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](../vi/README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Outil de Gestion de Mods The Forest — Édition Améliorée**

> Original : FluffyFish / Philipp Mohrenstecher (Engelskirchen, Allemagne)
> Amélioration : zzangae (République de Corée)

---

## Aperçu

ModAPI est une application de bureau pour gérer les mods de The Forest. Cette édition améliorée comprend la migration vers .NET Framework 4.8, l'interface Windows 11 Fluent Design, un système à 3 thèmes, un support multilingue étendu et une implémentation complète de l'onglet Téléchargements.

---

## Changements Principaux

### Phase 1 — Mise à niveau .NET Framework 4.8

- Migration de tous les projets (5) de `.NET Framework 4.5` → `4.8`
- Mise à jour de `TargetFrameworkVersion`, `App.config`, `packages.config` dans tous les projets
- Version d'assemblage unifiée

### Phase 2 — Environnement de Build et Fondation Fluent Design

- Introduction du package NuGet **ModernWpf 0.9.6**
- Création de **FluentStyles.xaml** — couche de surcharge Windows 11 Fluent Design
  - Palette de couleurs Fluent, typographie, boutons, onglets, comboboxes, styles de barres de défilement
  - Modèles Window, SubWindow, SplashScreen
- Compilation du **DLL stub UnityEngine**
  - Types manquants ajoutés : `WWW`, `Event`, `TextEditor`, `Physics`, etc.
- Références de dépendances corrigées et build réussi confirmé

### Phase 3 — Refonte de l'UI et Système de Thèmes

#### Refonte Fluent UI
- Restructuration complète de **MainWindow.xaml**
  - Mise en page, couleurs et typographie basées sur Fluent Design
  - Contrôles d'onglets, barre d'état et boutons de titre repensés
- Corrections d'exécution : gel du SplashScreen, changement d'onglets, états des icônes, déplacement de fenêtre

#### Système à 3 Thèmes

| Thème | Fichier de Style | Description |
|-------|-----------------|-------------|
| Classique | Dictionary.xaml uniquement | Design original de ModAPI (fond texturé) |
| Clair | FluentStylesLight.xaml | Ton lumineux + accent bleu |
| Sombre | FluentStyles.xaml | Ton sombre + accent bleu (par défaut) |

- **ComboBox de sélection de thème** ajouté dans l'onglet Paramètres
- Le changement de thème déclenche un **dialogue de confirmation** → **redémarrage automatique**
- Paramètre de thème sauvegardé/chargé via le fichier `theme.cfg`

#### Déplacement de Fenêtre / SubWindows / Hyperliens
- Événement `MouseLeftButtonDown` sur la grille racine pour le déplacement direct
- Dialogues ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Couleurs de liens spécifiques au thème : Sombre/Classique (`#FFD700`), Clair (`#0078D4`)

### Phase 4 — Nettoyage du Code et Suppression du Système Legacy

- Système de connexion supprimé (serveur hors service)
- Mécanisme de mise à jour modernisé
- Code inutilisé nettoyé
- UI SubWindow corrigée (dialogues de chemin de jeu, etc.)

### Phase 5 — Extension du Support Multilingue (13 Langues)

| Langue | Fichier | Langue | Fichier |
|--------|---------|--------|---------|
| Coréen | Language.KR.xaml | Italien | Language.IT.xaml |
| Anglais | Language.EN.xaml | Japonais | Language.JA.xaml |
| Allemand | Language.DE.xaml | Portugais | Language.PT.xaml |
| Espagnol | Language.ES.xaml | Vietnamien | Language.VI.xaml |
| Français | Language.FR.xaml | Chinois (Simplifié) | Language.ZH.xaml |
| Polonais | Language.PL.xaml | Chinois (Traditionnel) | Language.ZH-TW.xaml |
| Russe | Language.RU.xaml | | |

### Phase 5-1 — Onglet Téléchargements et Finalisation des Thèmes

#### Onglet Téléchargements
- Chargement de la liste des mods depuis 3 sources (`mods.json`, `versions.xml`, analyse HTML)
- Fonctionnalité de recherche (filtrer par nom/description/auteur du mod)
- **Filtre de jeu** (Tous / The Forest / Serveur Dédié / VR)
- **Filtre de catégorie** (Tous / Corrections de bugs / Équilibrage / Triches, etc. — 12 catégories)
- UI à panneau divisé pour la sélection de version
- Téléchargement direct de fichiers `.mod` → installation dans le dossier du jeu
- Tri des colonnes (clic sur nom/catégorie/auteur) et redimensionnement
- Suppression de mods (nettoyage DLL + fichiers intermédiaires)

#### Modernisation des Icônes (Tous les Thèmes)
- Toutes les icônes PNG de boutons → icônes de police **Segoe MDL2 Assets**
- Appliqué sur MainWindow.xaml + 14 fichiers SubWindow
- Les icônes de police héritent de la couleur de premier plan, assurant la visibilité dans tous les thèmes

| PNG Original | Icône de Police | Utilisation |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Ajouter / Lancer le Jeu |
| Icon_Delete | &#xE74D; | Supprimer |
| Icon_Refresh | &#xE72C; | Rafraîchir |
| Icon_Download | &#xE896; | Télécharger |
| Icon_Continue/Accept | &#xE8FB; | Confirmer/Continuer |
| Icon_Decline | &#xE711; | Annuler/Fermer |
| Icon_Information | &#xE946; | Information |
| Icon_Warning | &#xE7BA; | Avertissement |
| Icon_Error | &#xEA39; | Erreur |
| Icon_Browse | &#xED25; | Parcourir |
| Icon_CreateMod | &#xE713; | Créer un Mod |

#### Contrôles Unifiés à Travers Tous les Thèmes

| Contrôle | Classique | Sombre | Clair |
|----------|-----------|--------|-------|
| Case à cocher | Bascule (Or) | Bascule (AccentBrush) | Bascule (AccentBrush) |
| Bouton radio | Cercle (Or) | Cercle (AccentBrush) | Cercle (AccentBrush) |
| ComboBox | Scale9 original | Fluent personnalisé | Fluent personnalisé |

#### Corrections de Visibilité des Thèmes
- Clair : texte AccentButton forcé en Blanc, ajustement de l'Opacité des icônes d'onglets
- Sombre/Clair : approche `TextElement.Foreground` de ComboBoxItem pour la visibilité du texte sélectionné
- Classique : ressources de secours Fluent ajoutées à Dictionary.xaml

---

## Structure des Fichiers

```
ModAPI/
├── App.xaml / App.xaml.cs          # Charger/sauvegarder/appliquer le thème
├── Dictionary.xaml                  # Styles originaux + ressources bascule/radio/secours
├── FluentStyles.xaml                # Thème sombre + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Thème clair + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # UI principale + onglet téléchargements + sélecteur de thème
│   └── SubWindows/                  # 16 SubWindows (tous avec icônes de police)
├── resources/
│   ├── langs/                       # 13 fichiers de langue
│   └── textures/Icons/flags/        # Icônes de drapeaux (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Prérequis de Build

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Licence

GNU General Public License v3.0 — suit la licence originale.
