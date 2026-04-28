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

**The Forest 모드 관리 도구 — 업그레이드 에디션**

> 원작: FluffyFish / Philipp Mohrenstecher (독일 엥엘스키르헨)
> 업그레이드: zzangae (대한민국)

---

## 개요

ModAPI는 **정식 지원 5종 게임**의 모드를 관리하는 데스크톱 애플리케이션입니다. 이번 업그레이드 에디션은 멀티 게임 지원, Settings 탭 전면 재설계, 스팀 경로 설정, 영구 UI 설정 저장, 동적 폰트 크기 시스템, 게임 시작 검증, Debug/Release 빌드 분기, 실게임 테스트로 확인된 다수의 충돌 수정을 포함합니다.

---

## 지원 게임

| 게임 | 엔진 | 버전 | Steam ID | 실행 파일 |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (베타) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest (더 포레스트)</b></summary>

| 항목 | 값 |
|---|---|
| 엔진 | Unity 5 (Unity 4에서 업그레이드) |
| 최신 버전 | v1.12 (VR) |
| 마지막 업데이트 | 2019년 9월 11일 — VR 지원 패치; 이후 주요 콘텐츠 업데이트 없음 |
| 실행 파일 | `TheForest.exe` |
| 데이터 폴더 | `TheForest_Data/Managed/` |
| 모드 폴더 | `mods/TheForest/` |
| 프로젝트 폴더 | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — 완전 지원 |

Unity 4에서 Unity 5로 엔진을 업그레이드하며 비주얼과 물리 효과를 대폭 개선했습니다. 2019년 9월 VR 지원 패치를 마지막으로 주요 콘텐츠 업데이트는 종료되었으며, 안정적인 정식 버전 상태를 유지하고 있어 모딩에 최적화된 환경입니다.
</details>

<details>
<summary><b>Subnautica (서브노티카)</b></summary>

| 항목 | 값 |
|---|---|
| 엔진 | Unity (2022년 Below Zero 통합 코드베이스) |
| 최신 버전 | 2025 Patch (v18810395) |
| 마지막 업데이트 | 2025년 8월 12일 — 모바일 출시와 함께 PC/콘솔 버그 수정 및 성능 향상 패치 |
| 실행 파일 | `Subnautica.exe` |
| 데이터 폴더 | `Subnautica_Data/Managed/` |
| 모드 폴더 | `mods/Subnautica/` |
| 프로젝트 폴더 | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — 지원 |

원래 Unity 5 계열을 사용했으나 2022년 말 'Living Large' 업데이트(v2.0)를 통해 후속작 Below Zero의 엔진 코드를 통합하며 최적화 및 안정성을 강화했습니다. 차기작 *Subnautica 2*는 Unreal Engine 5를 사용합니다.

> **v2.0.9610 XML 재작성**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll`을 `copyAssembly`에 추가.
</details>

<details>
<summary><b>RAFT (래프트)</b></summary>

| 항목 | 값 |
|---|---|
| 엔진 | Unity |
| 최신 버전 | v1.1.02 (베타) / v1.09 (안정화) |
| 마지막 업데이트 | 2026년 3월 — 베타 브랜치 음성 채팅 및 멀티플레이 버그 수정 |
| 실행 파일 | `Raft.exe` |
| 데이터 폴더 | `Raft_Data/Managed/` |
| 모드 폴더 | `mods/Raft/` |
| 프로젝트 폴더 | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — 지원 |
| Versions.xml | `1.1.01` (체크섬 포함) |

공식 스토리 완결 버전인 v1.0: *The Final Chapter* 이후에도 네트워크 코드 개선 및 안정화를 위한 패치가 지속되고 있습니다.
</details>

<details>
<summary><b>Escape The Pacific (이스케이프 더 퍼시픽)</b></summary>

| 항목 | 값 |
|---|---|
| 엔진 | Unity 6 (2025년 말 Unity 2021/2022에서 마이그레이션) |
| 최신 버전 | v0.67.0.0 |
| 마지막 업데이트 | 2025년 6월 26일 — 섬 분포 방식 변경 및 엔진 업데이트; 2026년 초 소규모 핫픽스 지속 |
| 실행 파일 | `EscapeThePacific.exe` |
| 데이터 폴더 | `EscapeThePacific_Data/Managed/` |
| 모드 폴더 | `mods/EscapeThePacific/` |
| 프로젝트 폴더 | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — 지원 |

2025년 말 대규모 시스템 리빌딩과 함께 Unity 6 마이그레이션을 완료하여 더욱 다이내믹한 환경을 구현했습니다. 얼리 액세스 개발이 지속되고 있습니다.

> **v2.0.9610 XML 재작성**: `extends="GenericUnityGame"` 제거; `includeAssembly`를 `Assembly-CSharp.dll` 단독으로 설정 — `Assembly-CSharp-firstpass.dll` 상속 오류 방지.
</details>

<details>
<summary><b>Green Hell (그린 헬)</b></summary>

| 항목 | 값 |
|---|---|
| 엔진 | Unity 2019 |
| 최신 버전 | v2.9.5 |
| 마지막 업데이트 | 2026년 2월 4일 — 스팀 덱 최적화 및 텍스트 가독성 개선 핫픽스 |
| 실행 파일 | `GH.exe` |
| 데이터 폴더 | `GH_Data/Managed/` |
| 모드 폴더 | `mods/GH/` |
| 프로젝트 폴더 | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — 지원 |
| Versions.xml | `2.9.5` (체크섬 포함) |

개발 과정에서 Unity 2017 → 2018 → 2019로 엔진을 단계적으로 업그레이드했습니다. 2026년 2월 최신 핫픽스는 스팀 덱 호환성과 UI 텍스트 가독성 향상에 초점을 맞췄습니다.

> **v2.0.9610 XML 재작성**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` 추가; 존재하지 않는 `DOTweenPro.dll` 제거.
</details>

---

## 아키텍처

### 런타임 분리

| 구성 요소 | 대상 | 런타임 | 이유 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 데스크톱 앱, 최신 API 전체 접근 |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | 공유 라이브러리 |
| `BaseModLib.dll` | .NET Framework 3.5 | 게임 Mono 2.0 | **영구 고정** — PE 헤더가 `v2.0.50727`이어야 함 |
| 모드 DLL (사용자) | .NET Framework 4.8 | 게임 Mono 2.0 (패치됨) | 4.8로 빌드, Apply 시 PE 헤더 패치 |

### Debug / Release 빌드 분기

모든 파일 유효성 검사와 어셈블리 처리는 `#if DEBUG` / `#else`로 빌드 구성에 따라 분기됩니다.

| 위치 | Debug 빌드 | Release 빌드 |
|---|---|---|
| `CheckSteam()` | `File.Exists()` 만 확인 — 더미 파일 통과 | `FileValidator.IsValidSteamExe()` — PE 헤더 + 최소 1 MB |
| `CheckGamePath()` | `File.Exists()` 만 확인 — 더미 파일 통과 | `FileValidator.IsValidAssemblyDll()` — PE 헤더 + CLR 메타데이터 + 최소 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — Cecil 파싱 생략 | 전체 Mono.Cecil 파싱 + IL 수정 + `module.Write()` |
| `ModLib.Create()` — 파일 없음 | 경고 로그 후 건너뜀 | 오류 로그 후 중단 |

**디버그 테스트**는 `create_dummy_Debug_games.ps1`로 `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\`, `bin\Debug\gamefiles\original\` 아래에 0바이트 더미 파일을 생성합니다. `File.Exists()` 검사를 통과하므로 실제 게임 설치 없이 전체 UI 작업 흐름 테스트가 가능합니다.

**릴리즈 빌드**에서는 `FileValidator`(PE 헤더 + .NET CLR 메타데이터 검증)가 적용되어 0바이트 파일, 텍스트 파일, 임의 바이너리는 모두 차단됩니다. 실제 Windows 실행 파일과 .NET 어셈블리만 통과합니다.

### FileValidator — PE 헤더 검증

`ModAPI_Shared\Utils\FileValidator.cs` — Release 빌드에서만 적용됩니다.

| 메서드 | 검사 항목 | 최소 크기 |
|---|---|---|
| `IsValidSteamExe(path)` | MZ 서명 + PE\0\0 서명 | 1 MB |
| `IsValidGameExe(path)` | MZ 서명 + PE\0\0 서명 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + .NET CLR 메타데이터 헤더 (데이터 디렉토리 #14) | 64 KB |

### 어셈블리 재매핑 처리 과정

```
[모드 개발자가 .NET 4.8로 빌드]
  → 모드 DLL: PE 헤더 v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → RemapAllReferences: mscorlib 4.0.0.0 → 2.0.0.0 등
  → modModule.RuntimeVersion = "v2.0.50727"

[게임 Mono 2.0]
  → PE 헤더 수락 ✅  →  참조 해결 ✅
```

### 어셈블리 해석기 대체 경로

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← 백업 폴더
2. {실제 게임 설치 경로}/{AssemblyPath}          ← 게임 설치 폴더 (폴백)
```

### C# 7.3 모드 개발 지원

| 기능 | 상태 | 비고 |
|---|---|---|
| 패턴 매칭 (`is`, `switch`) | ✅ | 실게임 검증 완료 |
| 문자열 보간 (`$""`) | ✅ | 실게임 검증 완료 |
| `out` 변수 인라인 | ✅ | 실게임 검증 완료 |
| `async` / `await` | ✅ | AsyncBridge + System.Threading 폴리필 경유 |
| 튜플 (`ValueTuple`) | ❌ 절대 제한 | Mono 2.0 `mscorlib` ABI — 우회 불가 |

### 테마 시스템 [상세정보](v2.0.9613_themes_ko.md)

v2.0.9613에서 Settings 탭의 테마 UI를 별도 **Themes 탭**으로 분리했습니다. 새 테마 추가 시 `App.xaml.cs` 사전에 한 줄만 추가하면 됩니다.

| 번호 | ID | 파일 | 색상 |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` 단독 | 원작 ModAPI 텍스처 배경 |
| 1 | `light` | `FluentStylesLight.xaml` | 밝은 톤 + 파랑 강조 |
| 2 | `dark` | `FluentStyles.xaml` | 어두운 톤 + 파랑 강조 (기본값) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 적색 + 검정 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 어두운 우주 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 밝은 노을 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 어두운 바다 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 밝은 북유럽 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 밝은 감귤 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 밝은 꽃 |

테마 변경 시 앱이 자동 재시작됩니다. (`theme.cfg`에 저장)

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

### 배경 텍스처

Themes 탭의 **Background Texture** 카드에서 이미지를 선택하면 앱 전체 배경으로 적용됩니다. 지원 입력 형식: `.png` / `.jpg` / `.jpeg`, 최대 50MB, 4K 이하. 이미지는 JPEG Q75 압축 후 매직 헤더(16바이트)가 삽입되어 `resources\textures\ui_bg\bg.dat`에 Hidden 속성으로 저장됩니다. SHA-256 해시로 무결성을 검증하며, 변조 감지 시 자동 초기화 + 경고 팝업이 표시됩니다.

배경 활성화 시 두 계층으로 UI를 투명화합니다: Layer 1(MergedDictionaries 덮개층)은 `{DynamicResource}` 패널을, Layer 2(WalkStyleBackgrounds)는 `{StaticResource}` 패널을 반투명 처리합니다.

### 폰트 크기 시스템

| 리소스 키 | 기본값 | 설명 |
|---|---|---|
| `AppBaseFontSize` | 13 | 일반 텍스트 |
| `AppBaseHeaderFontSize` | 16 | 헤더, 패널 제목 |
| `AppBaseSmallFontSize` | 12 | 보조 레이블 |
| `AppBaseTinyFontSize` | 10 | 힌트 텍스트 |
| `AppBaseLargeFontSize` | 20 | 대형 표시 텍스트 |

### 영구 UI 설정 — `ui.cfg`

| 키 | 기본값 | 설명 |
|-----|---------|------|
| `ModListWidth` | `150` | Mods 탭 모드 목록 너비 (px) |
| `ProjectListWidth` | `150` | 개발 탭 프로젝트 목록 너비 (px) |
| `AppFontSize` | `13` | 전체 UI 폰트 크기 (px) |
| `AlwaysOnTop` | `false` | 창 항상 위에 상태 |
| `TexturePath` | *(없음)* | 배경 텍스처 원본 파일명 (표시용) |
| `TextureHash` | *(없음)* | 배경 텍스처 SHA-256 해시 |
| `TextureActive` | `false` | 배경 텍스처 활성화 상태 |
| `GamePathReset_{GameId}` | *(없음)* | 게임 경로 초기화 플래그 |
| `SteamPathReset` | *(없음)* | 스팀 경로 초기화 플래그 |

### 파일 구조

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # 영구 UI 설정
├── theme.cfg                            # 현재 테마
├── Windows/
│   ├── MainWindow.xaml / .cs            # 메인 UI — 6개 탭, Themes, Settings, 스팀 경로
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # 게임 경로 팝업 (동적 GameNameLabel)
│       ├── FirstSetup.xaml / .cs        # 최초 실행 설정 + 기본값 초기화
│       └── (기타 14개 SubWindow)
├── Themes/
│   ├── Dictionary.xaml                  # Classic 테마
│   ├── FluentStyles.xaml                # Dark 테마
│   ├── FluentStylesLight.xaml           # Light 테마
│   ├── FluentStylesDiablo.xaml          # Diablo 테마
│   ├── FluentStylesNebula.xaml          # Nebula 테마
│   ├── FluentStylesSunset.xaml          # Sunset 테마
│   ├── FluentStylesOcean.xaml           # Ocean 테마
│   ├── FluentStylesNordic.xaml          # Nordic 테마
│   ├── FluentStylesCitrus.xaml          # Citrus 테마
│   └── FluentStylesBloom.xaml           # Bloom 테마
├── Data/
│   ├── Game.cs                          # 패칭, null 가드, 해석기 대체
│   ├── ModLib.cs                        # BaseModLib 생성 + 리매핑 (#if DEBUG 분기)
│   ├── Models/
│   │   └── ModProject.cs                # 프로젝트 생성/빌드/적용 + null 가드
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter
│   │   ├── ModViewModel.cs              # 폴더에서 GameId 읽기
│   │   ├── ModProjectsViewModel.cs      # Dispose() — DispatcherTimer 정지
│   │   └── SettingsViewModel.cs         # UseSteam/AutoUpdate/UpdateVersions 기본값 true
│   └── AssemblyVersionMap.cs            # Mono 2.0 어셈블리 버전 매핑 (20개)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 이름 기반 리졸버 + 캐싱
│   └── MonoHelper.cs                    # Mono.Cecil IL 헬퍼
├── resources/
│   ├── langs/                           # 13개 언어 파일
│   └── textures/ui_bg/
│       └── bg.dat                       # 압축·보안 처리된 배경 이미지 (런타임 생성)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # v2.0.9610 전면 재작성
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # v2.0.9610 전면 재작성
    │   ├── GH.xml                       # v2.0.9610 전면 재작성
    │   ├── SonsOfTheForest.xml          # IL2CPP — 미지원
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # 경량 생성자 ModLibrary 초기화 수정
│   └── ModLib.cs                        # #if DEBUG 분기 (Cecil 파싱 / 파일 없음 처리)
└── Utils/
    └── FileValidator.cs                 # PE 헤더 + CLR 메타데이터 검증 (Release 전용)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # 버전 업데이트 전용 WPF 도구

bin\Debug\                               # 디버그 테스트 전용
├── create_dummy_Debug_games.ps1         # 더미 게임/스팀 구조 생성 스크립트
├── dummy_games\{GameId}\               # 더미 게임 설치 경로
├── dummy_steam\Steam.exe               # 더미 스팀 실행 파일
└── gamefiles\original\{GameId}\        # ModLib용 더미 백업 경로
```

---

## 설치 및 설정 가이드

### Step 1 — 사전 요구사항

| 항목 | 필요 여부 |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (Windows 11 기본 포함; Windows 10은 [다운로드](https://dotnet.microsoft.com/download/dotnet-framework/net48) 필요) |
| Steam | 필수 — Settings 탭에서 경로 설정 필요 |
| 지원 게임 1종 이상 | 필수 — Settings 탭에서 경로 설정 필요 |

### Step 2 — ModAPI 설치

1. GitHub에서 최신 릴리즈를 다운로드합니다
2. 원하는 폴더에 압축을 풉니다 (예: `C:\ModAPI\`)
3. `ModAPI.exe`를 실행합니다
4. 최초 실행 시 **환영** 화면이 표시됩니다 — 환경 설정 후 **계속** 버튼을 클릭합니다

### Step 3 — 스팀 경로 설정 (Settings 탭)

1. **Settings** 탭으로 이동합니다
2. **스팀 설치 경로** 항목을 확인합니다
3. **찾아보기** 버튼 클릭 → `Steam.exe` 선택
4. **저장** 버튼을 클릭합니다

### Step 4 — 게임 경로 설정 (Settings 탭)

1. 설치된 게임의 카드 헤더를 클릭하여 펼칩니다
2. **찾아보기** 버튼 클릭 → 게임 루트 폴더 선택 (`.exe` 파일이 있는 폴더)
3. **저장** 버튼을 클릭합니다

| 게임 | 실행 파일 | 경로 예시 |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Step 5 — 모드 다운로드 (Downloads 탭)

1. **Downloads** 탭으로 이동합니다
2. 게임 필터에서 원하는 게임을 선택합니다
3. 원하는 모드를 검색하거나 목록에서 선택 후 **다운로드** 버튼을 클릭합니다

> **오프라인 시**: `modapi.survivetheforest.net`에서 `.mod` 파일을 수동으로 다운로드한 후 해당 게임 폴더에 넣어주세요.

### Step 6 — 모드 적용 및 게임 시작 (Mods 탭)

1. **Mods** 탭으로 이동합니다
2. **게임 필터** (Col 0)에서 원하는 게임을 선택합니다
3. **모드 목록** (Col 1)에서 활성화할 모드를 체크합니다
4. **게임 시작** 버튼을 클릭합니다

게임 시작 전 5단계 검증이 자동으로 실행됩니다:

| 단계 | 검증 항목 | 실패 시 팝업 |
|---|---|---|
| 1 | Settings 탭 스팀 경로 유효 여부 | SteamNotFound |
| 2 | `mods/` 폴더 게임과 Settings 설정 게임 일치 여부 | GameModsMismatch |
| 3 | 모드 선택 여부 | NoModSelected |
| 4 | 혼합 게임 모드 여부 | MixedGameMods |
| 5 | 게임 경로 설정 및 실행파일 존재 여부 | GamePathNotSet / GameNotInstalled |

---

## 탭 개요

### 환영 탭 (Welcome)
최초 실행 설정 화면 (탭 번호 0). AutoUpdate, 스팀 연결, VersionsData 테이블 업데이트 여부를 설정합니다. 이후 실행에서는 커뮤니티 링크 및 릴리즈 노트를 제공합니다.

### Mods 탭
모드 사용의 주 작업 흐름 — 3-컬럼 레이아웃:

| 컬럼 | 내용 |
|---|---|
| Col 0 | 게임 필터 — 지원 5종 게임 라디오버튼 |
| Col 1 | 모드 목록 — 버전 선택 및 체크박스 활성화 |
| Col 2 | 정보 — 선택된 모드 상세, 설명, 버전 히스토리 |

### 다운로드 탭 (Downloads)
`modapi.survivetheforest.net`에서 모드 탐색 및 다운로드.

- **게임 필터**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **카테고리 필터**: 12개 카테고리
- **검색**: 모드명, 설명, 제작자 기준
- **오프라인 모드**: 지원 5종 게임 폴더 기준 수동 다운로드 안내

### 개발 탭 (Development)
모드 개발자용. 게임 필터 패널(Col 0)로 5종 게임 전환.

- 게임별 모드 프로젝트 생성, 빌드, 적용
- ModLib 재생성 3단계 검증 (스팀 → 프로젝트 → 게임 경로)
- 경량 `Game` 생성자로 안전한 게임 전환

### 테마 탭 (Themes)
테마 선택 및 배경 텍스처 관리 화면.

- **테마 선택**: 10종 테마 (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **배경 텍스처**: 이미지를 선택하여 앱 전체 배경으로 적용 (JPEG 압축 + 보안 처리)
- 배경 텍스처 활성화 시 테마 선택 잠금

### 설정 탭 (Settings)
통합 환경설정 — 4행 구성:

| 행 | 내용 |
|---|---|
| 0 | 언어 / 폰트 크기 / 테마 / 최대 너비 / 모드목록 너비 / 프로젝트목록 너비 |
| 1 | VersionsData 유지 / 자동업데이트 / 스팀 연결 / 항상 위에 |
| 2 | 스팀 설치 경로 (TextBox + 찾아보기 + 저장 + 초기화) |
| 3 | 게임 설치 경로 — 게임별 접기/펼치기 카드 (TextBox + 찾아보기 + 저장 + 초기화) |

---

## v2.0.9618 변경사항

### 버전 업데이트 도구 (MODAPI_VersionTool)

버전 번호를 손쉽게 업데이트할 수 있는 독립 WPF 도구를 추가했습니다.

**위치**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**기능**
- 현재 버전 자동 표시 (`App.xaml.cs`에서 읽어옴)
- 새 버전 직접 입력 후 **Apply Version** 클릭 한 번으로 두 파일 동시 수정
- 형식 검증: `X.X.XXXX` 형식만 허용

**수정 대상 파일**

| 파일 | 경로 | 수정 내용 |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**사용 순서**
1. `MODAPI_VersionTool.exe` 실행
2. 새 버전 입력 (예: `2.0.9619`)
3. **Apply Version** 클릭
4. Visual Studio에서 ModAPI 솔루션 다시 빌드

### StatusBar 버전 표시 수정

- `VersionLabel.Text`가 하드코딩된 `Version.Descriptor` 대신 `App.Version`을 참조하도록 수정
- 이제 VersionTool로 버전을 변경하고 빌드하면 StatusBar에 즉시 반영됨

---

## v2.0.9617 변경사항

### 설정 탭 — 경로 초기화 버튼 추가

Steam 설치 경로와 게임 설치 경로 각각에 **초기화** 버튼을 추가했습니다.

**Steam 경로 행**
```
[TextBox] [Browse] [저장] [초기화]
```

**게임 경로 행 (게임별)**
```
[TextBox] [Browse] [저장] [초기화]
```

**초기화 동작**
- 경로 TextBox 즉시 클리어
- `ui.cfg`에 초기화 플래그 저장 (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- 재시작 후에도 TextBox 비어있음 유지
- Configuration XML이 빈 문자열을 저장하지 않는 한계를 `ui.cfg` 플래그로 보완

**Browse 자동 저장**
- 이전: Browse 선택 후 저장 버튼을 별도로 눌러야 했음
- 이후: Browse에서 파일 선택 즉시 자동 저장 — Mods탭으로 이동해도 경로 반영됨

**추가된 언어 키**

| 키 | 한국어 |
|---|---|
| `Lang.Options.Labels.PathReset` | 초기화 |

---

## v2.0.9616 변경사항

### Versions.xml — 4개 게임 신규 추가 및 체크섬 업데이트

| 게임 | 파일 경로 | BuildID | 비고 |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | 신규 생성 |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | 체크섬 업데이트 |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | 신규 생성 |
| GH | `configs/games/GH/Versions.xml` | `21698250` | 체크섬 업데이트 |

### 체크섬 구성 규칙

게임별 `Assembly-CSharp-firstpass.dll` 존재 여부에 따라 체크섬 구성 방식이 다릅니다.

| 게임 | firstpass.dll | 체크섬 구성 |
|---|---|---|
| GH | ✅ 있음 | `firstpass MD5` + `Assembly-CSharp MD5` 연결 (64자) |
| Subnautica | ✅ 있음 | `firstpass MD5` + `Assembly-CSharp MD5` 연결 (64자) |
| EscapeThePacific | ✅ 있음 | `firstpass MD5` + `Assembly-CSharp MD5` 연결 (64자) |
| Raft | ❌ 없음 | `Assembly-CSharp MD5` 단독 (32자) |

### 게임 업데이트 시 Versions.xml 갱신 절차

기존 항목은 삭제하지 않고 새 `<version>` 항목만 추가합니다.

**Step 1 — 새 BuildID 확인**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| 게임 | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Step 2 — 새 체크섬 추출**
```powershell
# firstpass.dll 있는 게임 (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → 두 Hash 값을 순서대로 이어붙임 (firstpass 먼저)

# firstpass.dll 없는 게임 (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Step 3 — Versions.xml에 항목 추가**
```xml
<version id="{새 BuildID}">
    <checksum>{새 체크섬}</checksum>
</version>
```

---

## v2.0.9615 변경사항

### 설정 탭 게임 경로 펼침 동작 수정

- **카드 펼침 시 높이**: 게임 설치 경로 카드를 펼칠 때 창 하단이 입력필드 높이만큼만 정확히 늘어나도록 수정
- **`UpdateWindowHeight()` 개선**: `SizeToContent.Height` 측정 전 `UpdateLayout()` 호출, 배경 텍스처 활성 시 `TextureLayer1`을 일시 `Collapsed` 처리하여 4K 이미지 원본 크기가 높이 계산에 영향을 주지 않도록 수정
- **내부 Grid Row 수정**: 게임 경로 패널 내부 Grid의 마지막 Row `Height="*"` → `Height="Auto"` 변경 — 불필요한 하단 공백 제거

---

## v2.0.9614 변경사항

### 최대화 버튼 동작 수정

- **최대화**: `WindowState.Maximized` 대신 `SystemParameters.WorkArea` 기준으로 수동 최대화 — 작업표시줄을 침범하지 않고 현재 화면 해상도에 정확히 맞춤
- **복원**: 최대화 전 `Left`, `Top`, `Width`, `Height`, `MaxWidth` 5개 값을 저장하고 복원 버튼 클릭 시 원래 크기/위치로 복원
- **`MaxWidth` 처리**: 최대화 시 `MaxWidth = ∞`로 해제, 복원 시 저장된 값 재적용

---

## v2.0.9613 변경사항

### Themes 탭 신설

탭 순서가 아래와 같이 변경되었습니다.

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

기존 Settings 탭 내부의 테마 선택 UI를 별도 **Themes 탭**으로 분리했습니다.
아이콘: Segoe MDL2 Assets `&#xE790;` (색상표)

### 테마 등록부 구조 (데이터 기반)

새 테마 추가 시 `App.xaml.cs` 사전에 **한 줄**만 추가하면 됩니다.
`MainWindow.xaml.cs`의 switch 문이 완전히 제거되어 코드 수정이 불필요합니다.

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

`ThemeSelector` ComboBox 항목은 `ThemeIds` 루프로 자동 생성됩니다.
언어 키 규칙: `Lang.Options.Theme.{첫글자대문자 + 나머지}` (예: `Lang.Options.Theme.Nebula`)

### 지원 테마 목록

| 번호 | ID | 파일 | 색상 |
|---|---|---|---|
| 0 | `classic` | `Dictionary.xaml` 단독 | 원본 ModAPI 텍스처 배경 |
| 1 | `light` | `FluentStylesLight.xaml` | 밝은 톤 + 파랑 강조 |
| 2 | `dark` | `FluentStyles.xaml` | 어두운 톤 + 파랑 강조 (기본값) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | 적색 + 검정 |
| 4 | `nebula` | `FluentStylesNebula.xaml` | 어두운 우주 |
| 5 | `sunset` | `FluentStylesSunset.xaml` | 밝은 노을 |
| 6 | `ocean` | `FluentStylesOcean.xaml` | 어두운 바다 |
| 7 | `nordic` | `FluentStylesNordic.xaml` | 밝은 북유럽 |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | 밝은 감귤 |
| 9 | `bloom` | `FluentStylesBloom.xaml` | 밝은 꽃 |

테마 변경 시 앱이 자동 재시작됩니다. (`theme.cfg`에 저장)

### 배경 텍스처 기능

Themes 탭의 **Background Texture** 카드에서 이미지를 선택하면 앱 전체 배경으로 적용됩니다.
어떤 테마가 선택되어 있어도 동일하게 작동합니다.

**지원 입력 형식**: `.png` / `.jpg` / `.jpeg`, 최대 50MB, 4K 이하 해상도

**이미지 처리 과정**

```
사용자 선택 (.png / .jpg / .jpeg, 최대 50MB, 4K 이하)
  ↓
JPEG Q75 압축 (메모리 버퍼)
  ↓
매직 헤더 16바이트 삽입
  "MODAPI" + "BG" + version + padding (FF 00 FE 00)
  ↓
resources\textures\ui_bg\bg.dat 저장 (Hidden 속성)
  ↓
SHA-256 해시 → ui.cfg 의 TextureHash 키 저장
```

**보안 계층**

| 계층 | 방법 | 효과 |
|---|---|---|
| 매직 헤더 | JPEG 서명(FF D8 FF) 앞에 16바이트 삽입 | 확장자 변경 시 외부 뷰어 인식 불가 |
| Hidden 속성 | `FileAttributes.Hidden` | 탐색기 기본 설정에서 미표시 |
| SHA-256 무결성 | 로드 시 해시 비교 | 변조 감지 시 자동 초기화 + 경고 팝업 |

**변조 감지 시 동작**
1. `bg.dat` 삭제
2. `ui.cfg`의 `TexturePath`, `TextureHash`, `TextureActive` 초기화
3. TextBox, 토글 초기화
4. `Lang.Windows.TextureTampered` 팝업 표시

**ui.cfg 저장 키**

| 키 | 값 | 설명 |
|---|---|---|
| `TexturePath` | 파일명 (표시용) | TextBox에 표시할 원본 파일명 |
| `TextureHash` | SHA-256 hex | 무결성 검증용 해시 |
| `TextureActive` | `true` / `false` | 활성화 상태 |

**투명화 처리 구조**

배경 이미지가 활성화되면 두 계층으로 UI 배경을 투명화합니다.

- **Layer 1 — MergedDictionaries 덮개층**: `{DynamicResource FluentBgBrush}` 등을 참조하는 패널이 자동으로 투명화됩니다. 비활성화 시 `Remove()` 한 줄로 복원됩니다.

  대상 키: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Layer 2 — 비주얼 트리 순회 (`WalkStyleBackgrounds`)**: Fluent 테마의 `{StaticResource}` 참조 요소는 Layer 1의 영향을 받지 않으므로 비주얼 트리를 직접 순회해서 원본 색상 기반 반투명 브러시를 적용합니다.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=완전투명, 255=불투명 → 100 ≒ 39% 불투명
  ```

  처리 대상: `Panel` (Grid 제외), `Border`, `ListBox` / `ListView`

  처리 제외: `Grid` (배경 유지, 자식 순회 계속), `TabPanel` (탭 헤더 버튼 보호), `ButtonBase` / `ComboBox`, `Collapsed` 요소

  복원 방식: Style Setter 출처 → `ClearValue()`, XAML 로컬값 출처 → 원본 브러시 직접 복원

**탭 전환 처리**

WPF TabControl은 탭 콘텐츠를 지연 로드하므로 탭 전환 시 새 콘텐츠에 대해 `ContextIdle` 우선순위로 `WalkStyleBackgrounds(this)`를 재실행합니다. 이미 처리된 요소는 `ContainsKey` 체크로 건너뜁니다.

**ThemeSelector 잠금**

배경 텍스처가 활성화되면 테마 선택박스를 선택할 수 없도록 잠금 처리합니다.

- XAML: ThemeSelector 위에 `ThemeSelectorOverlay` Border (`IsHitTestVisible=True`) 추가
- 활성화 시: `ThemeSelectorOverlay.Visibility = Visible`
- 비활성화 시: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged`에서 `_textureActive` 가드로 이중 차단

**UI 상태 흐름**

```
이미지 선택 (Browse)
  → bg.dat 생성 → 토글 잠금 해제 → 자동 활성화 → TextureLayer1 표시
  → SaveAndClearBrushes() → ThemeSelectorOverlay 표시

토글 비활성화
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay 숨김
  → TextureLayer1 숨김

Clear 버튼
  → bg.dat 삭제 → 토글 잠금 → TextureLayer1 숨김 → 브러시 복원
  → GC.Collect() (4K 이미지 메모리 반환)
```

**추가된 언어 키**

| 키 | 한국어 값 |
|---|---|
| `Lang.Options.Theme.Diablo` | 디아블로 |
| `Lang.Options.Theme.Nebula` | 네뷸라 |
| `Lang.Options.Theme.Sunset` | 선셋 |
| `Lang.Options.Theme.Ocean` | 오션 |
| `Lang.Options.Theme.Nordic` | 노르딕 |
| `Lang.Options.Theme.Citrus` | 감귤 |
| `Lang.Options.Theme.Bloom` | 블룸 |
| `Lang.Options.Labels.TextureBackground` | 배경 텍스처 |
| `Lang.Options.Labels.TextureEnable` | 활성화 |
| `Lang.Options.Labels.TextureClear` | 초기화 |
| `Lang.Windows.TextureTooLarge` | 이미지 용량 초과 경고 |
| `Lang.Windows.TextureTampered` | 텍스처 변조 감지 경고 |

**파일 구조**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Themes 탭, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # 테마·텍스처 전체 로직
├── Themes\
│   ├── Dictionary.xaml            # Classic 테마
│   ├── FluentStyles.xaml          # Dark 테마
│   ├── FluentStylesLight.xaml     # Light 테마
│   ├── FluentStylesDiablo.xaml    # Diablo 테마
│   ├── FluentStylesNebula.xaml    # Nebula 테마
│   ├── FluentStylesSunset.xaml    # Sunset 테마
│   ├── FluentStylesOcean.xaml     # Ocean 테마
│   ├── FluentStylesNordic.xaml    # Nordic 테마
│   ├── FluentStylesCitrus.xaml    # Citrus 테마
│   └── FluentStylesBloom.xaml     # Bloom 테마
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # 압축·보안 처리된 배경 이미지 (런타임 생성)
```

**알려진 설계 제약**

| 항목 | 내용 |
|---|---|
| `IsEnabled=false` on ComboBox | `ElementNotEnabledException` 충돌 → `IsHitTestVisible` 덮개층 방식 사용 |
| `MergedDictionaries` 키 직접 교체 | 레이아웃 패스 중 충돌 → `Add`/`Remove` 방식만 사용 |
| Hidden 파일 덮어쓰기 | `Access Denied` → 쓰기 전 `FileAttributes.Normal` 초기화 필수 |
| `{StaticResource}` 배경 | Layer 1 미적용 → WalkStyleBackgrounds(Layer 2) 별도 처리 필요 |

---

## v2.0.9612 변경사항

### 테마 모듈 분리

- **`Themes/` 폴더 신설**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml`, `FluentStylesClassic.xaml`을 `ModAPI\Themes\` 디렉터리로 이동
- **`App.xaml.cs`**: `ApplyTheme()` — Classic 테마는 `Dictionary.xaml` 단독, Light/Dark/기타 Fluent 테마는 해당 XAML 로드
- **`ModAPI.csproj`**: 테마 XAML 경로 `Themes\` 하위로 업데이트, `FluentStylesClassic.xaml` 신규 등록

---

## v2.0.9611 변경사항

### 버그 수정

- **Mods 탭 너비 미적용 버그 수정**: Light/Dark 테마 전환 후 재시작 시 Mod 목록 너비가 적용되지 않던 문제 수정 — `InitModListWidth()`에 `ApplyModListWidth(width)` 호출 추가

---

## v2.0.9610 변경사항

### 추가된 항목

#### 게임 XML 및 Versions 설정

| # | 파일 | 변경 내용 |
|---|------|-----------|
| 1 | `GH.xml` | 전면 재작성 — `DOTweenPro.dll` 제거; `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` 추가 |
| 2 | `Subnautica.xml` | 전면 재작성 — `extends="GenericUnityGame"` 제거; `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` 추가 |
| 3 | `EscapeThePacific.xml` | 전면 재작성 — `extends="GenericUnityGame"` 제거; `includeAssembly` → `Assembly-CSharp.dll` 단독 |
| 4 | `Raft/Versions.xml` | 신규 생성 — 버전 `1.1.01` + 체크섬 |
| 5 | `GH/Versions.xml` | 신규 생성 — 버전 `2.9.5` + 체크섬 |
| 6 | `Subnautica/Versions.xml` | 신규 생성 — 잦은 업데이트로 체크섬 미포함 |

#### 치명적 버그 수정

| # | 유형 | 현상 | 수정 내용 |
|---|------|------|-----------|
| 1 | 무한대기 | `extends="GenericUnityGame"` → `Assembly-CSharp-firstpass.dll` 상속 → `CreateModLibrary` 중단 | 모든 비-TheForest XML에서 `extends` 제거 |
| 2 | 충돌 | `ResolutionException: XGamingRuntime.XUserGamertagComponent` — Subnautica 적용 중 | `XGamingRuntime.dll`, `XblPCSandbox.dll`을 `copyAssembly`에 추가 |
| 3 | 충돌 | 백업 생성 이후 추가된 DLL을 해석기가 찾지 못함 | 실제 게임 설치 폴더를 해석기 대체 경로로 추가 |
| 4 | 충돌 | `BaseModLib.dll` 파일 잠금 충돌 | 재시도 루프: 읽기 최대 10회 × 500ms + 생성 대기 최대 30회 × 500ms |
| 5 | 충돌 | `NullReferenceException` — `typesMap` entry.Value null | `if (entry.Value == null) continue` 추가 |
| 6 | 충돌 | 경량 생성자에 `ModLibrary = new ModLib(this)` 누락 → `CreateModLibrary()` 즉시 강제 종료 | 경량 생성자에 `ModLibrary = new ModLib(this)` 추가 |
| 7 | 충돌 | `SwitchDevGame()` 후 `App.Game.GamePath` 비어있어 `CreateModLibrary` 강제 종료 | 경량 생성자 후 `App.Game.GamePath = savedPath` 설정 |
| 8 | 오분류 | `EscapeThePacific` 모드가 TheForest로 분류됨 | `ModsViewModel`: 폴더 경로에서 `GameId` 추출 |
| 9 | 잘못된 경로 | `GetGameFolder()` → `""` → 드라이브 루트로 해석 | `GetGameFolder()` 6곳 전체에 null/empty 가드 추가 |

#### Debug / Release 빌드 분기

- **`FileValidator.cs`** — 신규 파일 `ModAPI_Shared\Utils\FileValidator.cs`; `ModAPI_Shared.csproj`에 등록
  - `IsValidSteamExe()` — PE 헤더(MZ + PE\0\0) + 최소 1 MB
  - `IsValidGameExe()` — PE 헤더 + 최소 512 KB
  - `IsValidAssemblyDll()` — PE 헤더 + .NET CLR 메타데이터 헤더 + 최소 64 KB
- **`CheckSteam()`** — `#if DEBUG`: `File.Exists()` 만 / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: `File.Exists()` 만 / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` Cecil 생략 / `#else`: 전체 Cecil 파싱 + IL 수정
- **`ModLib.Create()` 파일 없음** — `#if DEBUG`: 경고 로그 후 건너뜀 / `#else`: 오류 로그 후 중단

#### 디버그 테스트

- **`create_dummy_Debug_games.ps1`** — `bin\Debug\`용 PowerShell 스크립트; 5종 게임 전체의 더미 파일을 `dummy_games\`, `dummy_steam\`, `gamefiles\original\` 아래에 생성 — 실제 게임 설치 없이 전체 UI 작업 흐름 테스트 가능

#### Mods 탭 — 게임 시작 검증 전면 재작성

게임 시작 버튼 클릭 시 모드 목록 상태와 무관하게 항상 5단계 검증 실행:

| 단계 | 검증 항목 | 팝업 |
|---|---|---|
| 1 | Settings 탭 스팀 경로 유효 여부 | SteamNotFound |
| 2 | `mods/{GameId}/` 폴더 게임과 Settings 설정 게임 일치 여부 | GameModsMismatch |
| 3 | 모드 선택 여부 | NoModSelected |
| 4 | 혼합 게임 모드 여부 | MixedGameMods |
| 5 | 게임 경로 설정 + 실행파일 존재 여부 | GamePathNotSet / GameNotInstalled |

#### 개발 탭 — ModLib 재생성 검증

Mod 라이브러리 재생성 버튼 클릭 시 3단계 검증:

| 단계 | 검증 항목 | 팝업 |
|---|---|---|
| 1 | Settings 탭 스팀 경로 유효 여부 | SteamNotFound |
| 2 | 프로젝트 목록 존재 여부 | NoProjectWarning |
| 3 | `App.Game.GamePath` 설정 여부 | GamePathNotSet |

#### Settings 탭

- **스팀 경로 카드** — 게임 설치 경로 카드 내부 통합; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **게임 경로 패널** — `BuildGamePathsPanel()`, TextBox 전체 너비, 모두 펼치기/접기 버튼
- **모드/프로젝트목록 너비** 슬라이더 — 저장값 없을 때 최솟값 `150`으로 시작
- **폰트 크기** ComboBox — FHD 10–16, 4K 10–22, 8K 10–28
- **체크박스 동기화** — `SettingsCheckboxes.DataContext = SettingsVm`
- **`_uiInitialized` 플래그** — WPF 시작 중 조기 `ui.cfg` 덮어쓰기 방지

#### 다운로드 탭
- 디버그 문자열 → `Lang.Downloads.Status.NoDownloads`; 일관된 Padding; 오프라인 안내 업데이트

#### 최초 설정 및 게임 경로 시스템
- `FirstSetup.Check()` — 기본값 `true` 동기화
- `FirstSetupDone()` — 5종 게임 `mods/`, `projects/` 폴더 자동 생성
- `SpecifyGamePath` — `GameNameLabel`, `NavigateToSettings()`

#### 신규/업데이트 언어 키 (13개 언어 전체)

| 키 | 한국어 값 |
|-----|-----------|
| `Lang.Downloads.Status.NoDownloads` | 이 모드에 다운로드 가능한 파일이 없습니다. |
| `Lang.Options.Labels.ModListWidth` | 모드목록 너비 |
| `Lang.Options.Labels.ProjectListWidth` | 프로젝트목록 너비 |
| `Lang.Options.Labels.FontSize` | 폰트 크기 |
| `Lang.Options.Labels.MaxWidth` | 최대 너비 |
| `Lang.Development.Labels.GameFilter` | 게임 필터 |
| `Lang.Options.Labels.SteamPath` | 스팀 설치 경로 |
| `Lang.Windows.SteamNotFound.Title` | 스팀을 찾을 수 없음 |
| `Lang.Windows.SteamNotFound.Text` | 설치된 스팀이 없습니다. Settings탭에서 스팀을 설정해주십시오. |
| `Lang.Windows.GameModsMismatch.Title` | 게임 불일치 |
| `Lang.Windows.GameModsMismatch.Text` | mods 폴더의 게임과 Settings탭에 설정된 게임이 일치하지 않습니다. |
| `Lang.Downloads.Offline.Manual2` | (예: mods/TheForest, mods/Subnautica, …) |

### 포함되지 않은 항목

| 항목 | 이유 |
|---|---|
| 최신버전 자동 유지 | 서버 인프라 미운영 |
| 업데이트 검색 | 서버 인프라 미운영 |

### 제거된 항목

| 항목 | 이유 |
|---|---|
| 시작 시 `SpecifyGamePath` 팝업 | 모든 경로는 Settings 탭에서 설정 |
| 시작 시 `SpecifySteamPath` 팝업 | 스팀 경로는 Settings 탭에서 설정 |
| 로그인 시스템 | 원본 서버 종료 (v2.0.9400에서 제거됨) |
| `Portable.System.ValueTuple.dll` | Mono 2.0 동작 불가 (v2.0.9586에서 제거됨) |
| `UseSteam` 조건부 스팀 검증 | 스팀은 이제 게임 시작 및 ModLib 재생성 시 항상 첫 번째로 검증 |

---

## 향후 릴리즈 예정

| # | 기능 | 설명 |
|---|---|---|
| 1 | ModAPI 자동 업데이트 | 새로운 ModAPI 릴리즈를 자동으로 다운로드하고 적용 |
| 2 | ModAPI VersionsData 테이블 업데이트 | 게임 신규 패치 시 VersionsData 테이블 자동 업데이트 |

---

## v2.0.9600 변경사항

### 추가된 항목

- **다운로드 탭**: 게임 필터 5종 추가 (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Welcome 탭**: 탭 목록 맨 앞(번호 0) 배치
- **Mods 탭**: 3-컬럼 레이아웃(WrapPanel → 세로 목록), 너비 자동 조절, 모드명 줄바꿈
- **`ModsViewModel`**: 게임별 필터링, `ResolveGame()`으로 올바른 `Game` 인스턴스 생성
- **`Game.cs`**: 경량 생성자 `new Game(config, true)` — 식별 전용, `Verify()` 생략
- **빌드**: 4개 게임 XML `CopyToOutputDirectory=Always` 등록; 경고 정리 (CS0168, CS0618, CS0252)
- **게임 XML**: TheForest, Raft, GH DLL 목록 수정
- **언어 국기**: 13개 언어 배지 이미지 크기 통일

### 제거된 항목

| 항목 | 이유 |
|---|---|
| 게임 XML의 `extends="GenericUnityGame"` | `Assembly-CSharp-firstpass.dll`이 `includeAssembly`로 잘못 상속되는 문제 |
| Mods 탭의 `WrapPanel` 레이아웃 | 3-컬럼 Grid 레이아웃으로 교체 |

---

## 주요 변경사항 (단계별)

### Phase 1 *(v2.0.9200)* — .NET 4.8 마이그레이션
전체 5개 프로젝트 .NET 4.5 → 4.8 마이그레이션.

### Phase 2 *(v2.0.9300)* — 빌드 환경 & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, UnityEngine 스텁 DLL.

### Phase 3 *(v2.0.9500)* — UI 재설계 & 테마 시스템
3-테마 시스템, `theme.cfg`, 창 드래그 수정.

### Phase 4 *(v2.0.9400)* — 코드 정리
로그인 시스템 제거, 업데이트 메커니즘 현대화.

### Phase 5-1 *(v2.0.9552)* — 다운로드 탭 & 13개 언어
다운로드 탭, Segoe MDL2 Assets 아이콘, 13개 언어 지원.

### Phase 5-5 *(v2.0.9561)* — 어셈블리 해결
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, PE 헤더 패칭.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & 폴리필
블랙 스크린 수정, `ValueTuple` 제거, C# 7.3 실게임 검증.

### Phase 6-1 *(v2.0.9600)* — 멀티 게임 & Mods 재설계
5종 게임 필터, 3-컬럼 Mods 탭, 경량 생성자, XML 등록.

### Phase 6-2 *(v2.0.9610)* — Settings, 경로 안전화, 충돌 수정 & Debug/Release 분기
XML 전면 수정, 스팀 경로, 5단계 게임 시작 검증, 3단계 ModLib 검증, `FileValidator` PE 헤더 검증, `#if DEBUG` 빌드 분기, `create_dummy_Debug_games.ps1`, 경량 생성자 ModLibrary 수정, SwitchDevGame GamePath 수정, 5종 폴더 생성, 다수 충돌 수정.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — 테마 시스템 확장, 설정 개선 & 도구 추가
Themes 탭 신설, 10개 테마 + 배경 텍스처 기능, Themes/ 폴더 분리, 최대화 버튼 수정, 게임 경로 펼침 수정, Versions.xml 4개 게임 업데이트, 경로 초기화 버튼, Browse 자동 저장, MODAPI_VersionTool.

---

## 버전 히스토리

### v2.0.9618 — 2026-04-25
MODAPI_VersionTool 추가 (버전 업데이트 전용 WPF 도구), StatusBar 버전 표시 App.Version 연동

### v2.0.9617 — 2026-04-24
설정 탭 Steam/게임 경로 초기화 버튼 추가, Browse 자동 저장, 초기화 상태 ui.cfg 플래그 보존

### v2.0.9616 — 2026-04-18
Versions.xml 4개 게임 신규/업데이트 (Subnautica, Raft, EscapeThePacific, GH), 체크섬 구성 규칙 정립, 게임 업데이트 시 갱신 절차 문서화

### v2.0.9615 — 2026-04-18
설정 탭 게임 경로 카드 펼침 높이 정확도 수정, UpdateWindowHeight 배경 텍스처 간섭 방지

### v2.0.9614 — 2026-04-18
최대화 버튼 WorkArea 기반 수동 최대화, 이전 크기/위치 저장 및 복원

### v2.0.9613 — 2026-04-18
Themes 탭 신설, 테마 등록부 데이터 기반 구조, 10개 테마 지원, 배경 텍스처 기능 (압축·보안·투명화 2계층), ThemeSelector 잠금 덮개층, 언어 키 12개 추가

### v2.0.9612 — 2026-04-18
Themes/ 폴더 분리, 테마 XAML 모듈화

### v2.0.9611 — 2026-04-18
테마 전환 후 Mod 목록 너비 미적용 버그 수정

### v2.0.9610 — 2026-04-13
멀티 게임 XML 전면 수정(GH, Subnautica, EscapeThePacific), Versions.xml 추가, Settings 탭 전면 재설계(스팀 경로 카드, 게임 경로 패널, 너비 슬라이더, 폰트 크기, 체크박스 동기화), 게임 경로 null 안전화(6곳), 시작 팝업 제거(Settings 탭 방식), Mods 탭 5단계 게임 시작 검증(스팀 항상 첫 번째), 개발 탭 3단계 ModLib 검증, GameModsMismatch 팝업 추가, 경량 생성자 ModLibrary null 수정, SwitchDevGame GamePath 수정, FileValidator PE 헤더 검증(Release), #if DEBUG 빌드 분기(CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, 영구 ui.cfg, 5-키 폰트 시스템, 다수 충돌 수정, 언어 키 업데이트

### v2.0.9600 — 2026-04-09
다운로드 탭 게임 필터 5종, Mods 탭 3-컬럼 레이아웃, 너비 자동 조절, 경량 생성자, ModsViewModel 게임별 필터링, 4개 XML 등록, 빌드 경고 정리, Welcome 탭 추가, 언어 국기 이미지 크기 통일

### v2.0.9586 — 2026-03-31
블랙 스크린 수정, 폴리필 처리 과정 확정, ValueTuple 제거, C# 7.3 실게임 검증

### v2.0.9561 — 2026-03-06
C# 7.3 모드 개발 지원, PE 헤더 패칭, 폴리필 처리 과정, 어셈블리 해결 복원

### v2.0.9552 — 2026-02-25
다운로드 탭, 아이콘 현대화, 테마 통합, 13개 언어 지원

### v2.0.9500
테마 시스템 (Classic/Light/Dark), Fluent Design UI, SubWindow 시스템

### v2.0.9400
코드 정리, 로그인 제거, 레거시 현대화

### v2.0.9300
빌드 환경, UnityEngine 스텁 DLL, ModernWpf 통합

### v2.0.9200
.NET Framework 4.8 마이그레이션

### v1.x
FluffyFish 원작 릴리즈

---

## 빌드 요구사항

| 요구사항 | 버전 | 비고 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI 프로젝트용 |
| .NET Framework SDK | 3.5 | BaseModLib 전용 |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/`에 배치 |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll`을 `libs/polyfills/`에 배치 |

---

## 라이선스

GNU General Public License v3.0 — 원작 라이선스를 따릅니다.
