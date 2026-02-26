# ModAPI(v1) v2.0.9552 - 20260225

**The Forest 모드 관리 도구 — 업그레이드 에디션**

> 원본: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Germany)
> 업그레이드: zzangae (Republic of Korea)

---

## 개요

ModAPI는 The Forest 게임의 모드를 관리하는 데스크톱 애플리케이션입니다. 이 업그레이드 에디션은 .NET Framework 4.8 마이그레이션, Windows 11 Fluent Design UI, 3-테마 시스템, 다국어 지원 강화, 다운로드 탭 구현 등을 포함합니다.

---

## 주요 변경사항

### Phase 1 — .NET Framework 4.8 업그레이드

- 전체 프로젝트(5개) `.NET Framework 4.5` → `4.8` 마이그레이션
- `TargetFrameworkVersion`, `App.config`, `packages.config` 일괄 업데이트
- 어셈블리 버전 통일

### Phase 2 — 빌드 환경 정비 및 Fluent Design 기반 구축

- **ModernWpf 0.9.6** NuGet 패키지 도입
- **FluentStyles.xaml** 생성 — Windows 11 Fluent Design 오버라이드 레이어
  - Fluent 색상 팔레트, 타이포그래피, 버튼, 탭, 콤보박스, 스크롤바 스타일
  - Window, SubWindow, SplashScreen 템플릿
- **UnityEngine 스텁 DLL** 컴파일
  - 누락 타입 추가: `WWW`, `Event`, `TextEditor`, `Physics` 등
- 의존성 참조 수정 및 빌드 성공 확인

### Phase 3 — UI 재설계 및 테마 시스템

#### Fluent UI 재설계
- **MainWindow.xaml** 완전 재구성
  - Fluent Design 기반 레이아웃, 색상, 타이포그래피
  - 탭 컨트롤, 상태바, 캡션 버튼 재설계
- 런타임 오류 수정: SplashScreen 프리징, 탭 전환, 아이콘 상태, 창 드래그

#### 3-테마 시스템

| 테마 | 스타일 파일 | 설명 |
|------|------------|------|
| 클래식 테마 | Dictionary.xaml only | 원본 ModAPI 디자인 (텍스처 배경) |
| 화이트 테마 | FluentStylesLight.xaml | 밝은 톤 + 파란 악센트 |
| 다크 테마 | FluentStyles.xaml | 어두운 톤 + 파란 악센트 (기본값) |

- 설정 탭에 **테마 선택 ComboBox** 추가
- 테마 변경 시 **확인 팝업** → **자동 재시작**
- `theme.cfg` 파일로 테마 설정 저장/로드

#### 창 드래그 / SubWindow / 하이퍼링크
- 루트 Grid `MouseLeftButtonDown` 이벤트로 직접 드래그 처리
- ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm 팝업
- 테마별 링크 색상: 다크/클래식(`#FFD700`), 화이트(`#0078D4`)

### Phase 4 — 코드 정리 및 레거시 제거

- 로그인 시스템 제거 (서버 미운영)
- 업데이트 메커니즘 현대화
- 사용하지 않는 코드 정리
- SubWindow UI 수정 (경로 선택 다이얼로그 등)

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

### Phase 5-1 — 다운로드 탭 구현 및 테마 완성

#### 다운로드 탭
- 3개 소스에서 모드 목록 로드 (`mods.json`, `versions.xml`, HTML 파싱)
- 검색 기능 (모드명/설명/저자 필터링)
- **게임 필터** (All / The Forest / Dedicated Server / VR)
- **카테고리 필터** (All / Bugfixes / Balancing / Cheats 등 12종)
- 버전 선택 스플릿 패널 UI
- `.mod` 파일 직접 다운로드 → 게임 폴더 설치
- 컬럼 정렬 (이름/카테고리/저자 클릭 정렬) 및 리사이즈
- 모드 삭제 (DLL + staging 파일 정리)

#### 전 테마 아이콘 현대화
- 모든 버튼 PNG 아이콘 → **Segoe MDL2 Assets** 폰트 아이콘 교체
- MainWindow.xaml + SubWindow 14개 파일 전체 적용
- 테마 Foreground 자동 상속으로 모든 테마에서 가시성 보장

| 기존 PNG | 폰트 아이콘 | 용도 |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | 추가 / 게임 시작 |
| Icon_Delete | &#xE74D; | 삭제 |
| Icon_Refresh | &#xE72C; | 새로고침 |
| Icon_Download | &#xE896; | 다운로드 |
| Icon_Continue/Accept | &#xE8FB; | 확인/계속 |
| Icon_Decline | &#xE711; | 취소/닫기 |
| Icon_Information | &#xE946; | 정보 |
| Icon_Warning | &#xE7BA; | 경고 |
| Icon_Error | &#xEA39; | 오류 |
| Icon_Browse | &#xED25; | 탐색 |
| Icon_CreateMod | &#xE713; | 모드 생성 |

#### 전 테마 컨트롤 통일

| 컨트롤 | 클래식 | 다크 | 화이트 |
|--------|--------|------|--------|
| CheckBox | 토글 (Gold) | 토글 (AccentBrush) | 토글 (AccentBrush) |
| RadioButton | 원형 (Gold) | 원형 (AccentBrush) | 원형 (AccentBrush) |
| ComboBox | Scale9 원본 | Fluent 커스텀 | Fluent 커스텀 |

#### 테마별 가시성 수정
- 화이트: AccentButton 텍스트 White 강제, 탭 아이콘 Opacity 조정
- 다크/화이트: ComboBoxItem `TextElement.Foreground` 방식으로 선택 텍스트 문제 해결
- 클래식: Dictionary.xaml에 Fluent 폴백 리소스 추가

---

## 파일 구조

```
ModAPI/
├── App.xaml / App.xaml.cs          # 테마 로드/저장/적용
├── Dictionary.xaml                  # 원본 스타일 + 토글/라디오/폴백 리소스
├── FluentStyles.xaml                # 다크 테마 + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # 화이트 테마 + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # 메인 UI + 다운로드탭 + 테마 선택기
│   └── SubWindows/                  # 16개 SubWindow (모두 폰트 아이콘 적용)
├── resources/
│   ├── langs/                       # 13개 언어 파일
│   └── textures/Icons/flags/        # 국기 아이콘 (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # 스텁 DLL
```

---

## 빌드 요구사항

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## 라이선스

GNU General Public License v3.0 — 원본 라이선스를 따릅니다.
