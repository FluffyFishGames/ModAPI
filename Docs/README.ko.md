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

**The Forest 모드 관리 도구 — 업그레이드 에디션**

> 원본: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germany)
> 업그레이드: zzangae (Republic of Korea)

---

## 개요

ModAPI는 The Forest 게임의 모드를 관리하는 데스크톱 애플리케이션입니다. 이 업그레이드 에디션은 .NET Framework 4.8 마이그레이션, Windows 11 Fluent Design UI, 3-테마 시스템, 다국어 지원 강화, 다운로드 탭 구현, C# 7.3 모드 개발 지원 등을 포함합니다.

---

## v2.0.9586 변경사항

v2.0.9561 이후 확인 및 해결된 항목들입니다. 모든 결과는 인게임 테스트를 통해 검증되었습니다.

| # | 분류 | 문제 | 해결 |
|---|---|---|---|
| 1 | **치명적** | 모드 적용 후 게임 메인 메뉴 검은화면 | 해결 — 어셈블리 리매핑 파이프라인이 PE 헤더와 참조 테이블을 올바르게 패치 |
| 2 | **폴리필** | `Portable.System.ValueTuple.dll` 포함했으나 동작 불가 | 완전 제거 — Mono 2.0의 `mscorlib`가 `ValueTuple`을 직접 참조하는 IL을 생성하므로 폴리필로 재정의 불가 |
| 3 | **폴리필** | 잘못된 파일명: `System.Threading.Tasks.dll` | `System.Threading.dll`로 수정 — `TaskParallelLibrary 1.0.2856` NuGet의 실제 파일명 |
| 4 | **폴리필** | `Game.cs` 복사 경로 버그: `Managed\polyfills\`에 복사됨 | `Path.GetFileName()`으로 파일명만 추출하여 `Managed\`에 플랫 복사하도록 수정 |
| 5 | **빌드** | PostBuild 타겟에 폴리필 자동 복사 누락 | `BaseModLib.csproj` PostBuild가 `AsyncBridge.dll`, `System.Threading.dll`을 `bin\{Config}\libs\polyfills\`로 자동 복사 |
| 6 | **C# 7.3** | 튜플(`ValueTuple`) 지원 시도 실패 | 모든 설정에서 완전 제거 — Mono 2.0에서 튜플은 아키텍처적 한계로 확정 |
| 7 | **C# 7.3** | 나머지 C# 7.3 기능 인게임 검증 | 실제 게임플레이에서 확인: 패턴 매칭, 문자열 보간, `out` 변수 인라인 |

### C# 7.3 최종 기능 매트릭스

| 기능 | 상태 | 비고 |
|---|---|---|
| 패턴 매칭 (`is`, `switch`) | ✅ 확인됨 | `TEST_MOD.log`로 인게임 테스트 |
| 문자열 보간 (`$""`) | ✅ 확인됨 | `TEST_MOD.log`로 인게임 테스트 |
| `out` 변수 인라인 | ✅ 확인됨 | `TEST_MOD.log`로 인게임 테스트 |
| 표현식 본문 멤버 (`=>`) | ✅ | 컴파일러 처리, 런타임 의존성 없음 |
| 로컬 함수 | ✅ | 컴파일러 처리, 런타임 의존성 없음 |
| `nameof` | ✅ | 컴파일러 처리, 런타임 의존성 없음 |
| Null 조건 연산자 (`?.`, `??`) | ✅ | 컴파일러 처리, 런타임 의존성 없음 |
| `async`/`await` | ✅ | AsyncBridge + System.Threading 폴리필 |
| 튜플 (`ValueTuple`) | ❌ 하드 한계 | Mono 2.0 `mscorlib` ABI — 우회 불가 |

### 최종 폴리필 구성

| DLL | NuGet 패키지 | 경로 | 용도 |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | .NET 3.5용 `async`/`await` |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | AsyncBridge 의존성 |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~제거됨~~ | ~~제거됨~~ | ~~Mono 2.0에서 동작 불가~~ |

---

## 런타임 아키텍처 — .NET / Mono 설계 결정

### 런타임 분리 구조

| 컴포넌트 | 타겟 | 런타임 | 이유 |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | 데스크톱 앱, 최신 API 완전 사용 |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | ModAPI 데스크톱 공유 라이브러리 |
| `BaseModLib.dll` | .NET Framework 3.5 | 게임 Mono 2.0 | **영구 고정 — 아래 참조** |
| 모드 DLL (사용자) | .NET Framework 4.8 | 게임 Mono 2.0 (패치됨) | 4.8로 빌드, Apply 시 PE 헤더 패치 |

### BaseModLib가 .NET 3.5에 영구 고정되어야 하는 이유

The Forest는 **Unity 5.6.x** 기반으로, **Mono 2.0** (`mono.dll`, CLR Runtime `v2.0.50727`)을 내장합니다. 이 런타임은 게임 실행 파일에 물리적으로 내장되어 외부에서 교체할 수 없습니다.

```
v3.5 빌드  →  PE 헤더: CLR Runtime v2.0.50727  ←  Mono 2.0 수락  ✅
v4.8 빌드  →  PE 헤더: CLR Runtime v4.0.30319  ←  Mono 2.0 거부  ❌  (검은 화면)
```

### 어셈블리 리매핑 파이프라인

```
[모드 개발자가 .NET 4.8로 빌드]
  → 모드 DLL: PE 헤더 v4.0.30319, mscorlib 4.0.0.0 참조

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      참조 테이블 패치: mscorlib 4.0.0.0 → 2.0.0.0 등
  → modModule.RuntimeVersion = "v2.0.50727"
      PE 헤더 패치: v4.0.30319 → v2.0.50727

[게임 런타임 — Mono 2.0]
  → PE 헤더 수락 ✅  /  어셈블리 참조 해결 ✅
```

### 폴리필 배포 파이프라인

```
[BaseModLib PostBuild]
  New_MODAPI2\libs\polyfills\AsyncBridge.dll
  New_MODAPI2\libs\polyfills\System.Threading.dll
    → bin\{Config}\libs\polyfills\로 자동 복사

[ModAPI Apply — Game.cs]
  bin\{Config}\libs\polyfills\AsyncBridge.dll
  bin\{Config}\libs\polyfills\System.Threading.dll
    → Path.GetFileName()으로 파일명만 추출
    → TheForest_Data\Managed\AsyncBridge.dll로 플랫 복사
    → TheForest_Data\Managed\System.Threading.dll로 플랫 복사
```

---

## 주요 변경사항

### Phase 1 — .NET Framework 4.8 업그레이드
- 전체 프로젝트(5개) `.NET Framework 4.5` → `4.8` 마이그레이션

### Phase 2 — 빌드 환경 및 Fluent Design 기반
- **ModernWpf 0.9.6** NuGet 도입, **FluentStyles.xaml** 생성, **UnityEngine 스텁 DLL** 컴파일

### Phase 3 — UI 재설계 및 테마 시스템

| 테마 | 스타일 파일 | 설명 |
|------|------------|------|
| 클래식 | Dictionary.xaml only | 원본 ModAPI 디자인 (텍스처 배경) |
| 화이트 | FluentStylesLight.xaml | 밝은 톤 + 파란 악센트 |
| 다크 | FluentStyles.xaml | 어두운 톤 + 파란 악센트 (기본값) |

### Phase 4 — 코드 정리 및 레거시 제거
- 로그인 시스템 제거, 업데이트 메커니즘 현대화

### Phase 5 — 다국어 지원 확장 (13개 언어)

| 언어 | 파일 | 언어 | 파일 |
|------|------|------|------|
| 한국어 | Language.KR.xaml | 이탈리아어 | Language.IT.xaml |
| 영어 | Language.EN.xaml | 일본어 | Language.JA.xaml |
| 독일어 | Language.DE.xaml | 포르투갈어 | Language.PT.xaml |
| 스페인어 | Language.ES.xaml | 베트남어 | Language.VI.xaml |
| 프랑스어 | Language.FR.xaml | 중국어(간체) | Language.ZH.xaml |
| 폴란드어 | Language.PL.xaml | 중국어(번체) | Language.ZH-TW.xaml |
| 러시아어 | Language.RU.xaml | | |

### Phase 5-1 — 다운로드 탭 및 테마 완성
- 3개 소스 모드 목록, 검색/필터, `.mod` 직접 다운로드
- 모든 PNG 아이콘 → **Segoe MDL2 Assets** 폰트 아이콘

### Phase 5-5 — 어셈블리 해결 복원
- `AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, `ModLib.cs`, `Game.cs`, `ModProject.cs`, `MonoHelper.cs` 업데이트
- `CS0723` 빌드 오류 수정

### Phase 5-6 — C# 7.3 모드 개발 지원
- `BaseModLib.csproj`: `.NET 3.5` 영구 고정 + `<LangVersion>7.3</LangVersion>`
- `ModProject.cs`: PE 헤더 패치 추가
- `Game.cs`: 폴리필 자동 배포

### Phase 5-6B — 검은화면 수정 및 폴리필 파이프라인 완성
- 검은화면 해결 확인
- `Portable.System.ValueTuple.dll` 완전 제거
- `System.Threading.dll` 파일명 수정
- `Game.cs` 복사 경로 버그 수정
- C# 7.3 인게임 검증 완료

---

## 버전 히스토리

| 버전 | 날짜 | 요약 |
|---|---|---|
| v2.0.9586 | 2026-03-31 | 검은화면 수정 확인, 폴리필 파이프라인 완성, ValueTuple 제거, 파일명/경로 버그 수정, C# 7.3 인게임 검증 |
| v2.0.9561 | 2026-03-06 | C# 7.3 모드 개발 지원, PE 헤더 패치, 폴리필 파이프라인, 어셈블리 해결 복원 |
| v2.0.9552 | 2026-02-25 | 다운로드 탭, 아이콘 현대화, 테마 통일, 13개 언어 지원 |
| v2.0.9500 | — | 테마 시스템, Fluent Design UI, SubWindow 시스템 |
| v2.0.9400 | — | 코드 정리, 로그인 제거 |
| v2.0.9300 | — | 빌드 환경, UnityEngine 스텁 DLL, ModernWpf 통합 |
| v2.0.9200 | — | .NET Framework 4.8 마이그레이션 |
| v1.x | — | FluffyFish 원본 릴리즈 |

---

## 파일 구조

```
ModAPI/
├── App.xaml / App.xaml.cs              # 테마 로드/저장/적용
├── Dictionary.xaml                      # 원본 스타일 + 폴백 리소스
├── FluentStyles.xaml                    # 다크 테마
├── FluentStylesLight.xaml               # 화이트 테마
├── Windows/
│   ├── MainWindow.xaml / .cs            # 메인 UI + 다운로드탭 + 테마 선택기
│   └── SubWindows/                      # 16개 SubWindow
├── Data/
│   ├── Game.cs                          # 게임 어셈블리 패치 + 폴리필 배포
│   ├── ModLib.cs                        # BaseModLib 생성 + 어셈블리 리매핑
│   ├── Models/
│   │   └── ModProject.cs                # 모드 프로젝트 생성/빌드/적용 + PE 헤더 패치
│   └── AssemblyVersionMap.cs            # Mono 2.0 어셈블리 버전 매핑 (20개)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # 이름 기반 어셈블리 리졸버
│   └── MonoHelper.cs                    # Mono.Cecil IL 헬퍼
├── resources/
│   ├── langs/                           # 13개 언어 파일
│   └── textures/Icons/flags/            # 국기 아이콘
└── libs/
    ├── UnityEngine.dll                  # 스텁 DLL
    └── polyfills/
        ├── AsyncBridge.dll
        └── System.Threading.dll

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3 + PostBuild
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll
```

---

## 빌드 요구사항

| 항목 | 버전 | 비고 |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | ModAPI 프로젝트용 |
| .NET Framework SDK | 3.5 | BaseModLib 전용 |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll`로 `libs/polyfills/`에 배치 |

---

## 라이선스

GNU General Public License v3.0 — 원본 라이선스를 따릅니다.
