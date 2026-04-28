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

**Công Cụ Quản Lý Mod The Forest — Phiên Bản Nâng Cấp**

> Nguyên bản: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Đức)
> Nâng cấp: zzangae (Cộng hòa Hàn Quốc)

---

## Tổng Quan

ModAPI là ứng dụng máy tính để quản lý mod cho **5 trò chơi được hỗ trợ chính thức**. Phiên bản nâng cấp này bao gồm hỗ trợ đa trò chơi, tab Cài đặt được thiết kế lại hoàn toàn, cấu hình đường dẫn Steam, cài đặt UI lâu dài, hệ thống cỡ chữ động, xác thực khởi động trò chơi, phân tách build Debug/Release và nhiều bản sửa lỗi được xác minh.

---

## Trò Chơi Được Hỗ Trợ

| Trò Chơi | Engine | Phiên Bản | Steam ID | Tệp Thực Thi |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Patch | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Mục | Giá Trị |
|---|---|
| Engine | Unity 5 (nâng cấp từ Unity 4) |
| Phiên Bản Mới Nhất | v1.12 (VR) |
| Cập Nhật Cuối | 11 tháng 9 năm 2019 — bản vá hỗ trợ VR; không có cập nhật nội dung lớn nào sau đó |
| Tệp Thực Thi | `TheForest.exe` |
| Thư Mục Dữ Liệu | `TheForest_Data/Managed/` |
| Thư Mục Mod | `mods/TheForest/` |
| Thư Mục Dự Án | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — hỗ trợ đầy đủ |

The Forest được nâng cấp từ Unity 4 lên Unity 5, cải thiện đáng kể hình ảnh và vật lý. Bản vá VR tháng 9 năm 2019 là bản cập nhật lớn cuối cùng. Trò chơi hiện duy trì trạng thái ổn định, hoàn thiện — lý tưởng cho modding.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Mục | Giá Trị |
|---|---|
| Engine | Unity (mã nguồn tích hợp, hợp nhất với Below Zero năm 2022) |
| Phiên Bản Mới Nhất | 2025 Patch (v18810395) |
| Cập Nhật Cuối | 12 tháng 8 năm 2025 — sửa lỗi và cải thiện hiệu suất cùng với phát hành di động |
| Tệp Thực Thi | `Subnautica.exe` |
| Thư Mục Dữ Liệu | `Subnautica_Data/Managed/` |
| Thư Mục Mod | `mods/Subnautica/` |
| Thư Mục Dự Án | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — hỗ trợ |

Ban đầu được xây dựng trên Unity 5, Subnautica nhận bản cập nhật 'Living Large' (v2.0) cuối năm 2022 hợp nhất mã nguồn engine với Below Zero để tối ưu hóa và ổn định hơn. Lưu ý: *Subnautica 2* sắp tới sử dụng Unreal Engine 5.

> **XML viết lại trong v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` được thêm vào `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Mục | Giá Trị |
|---|---|
| Engine | Unity |
| Phiên Bản Mới Nhất | v1.1.02 (Beta) / v1.09 (Ổn Định) |
| Cập Nhật Cuối | Tháng 3 năm 2026 — sửa lỗi chat thoại và nhiều người chơi qua nhánh beta |
| Tệp Thực Thi | `Raft.exe` |
| Thư Mục Dữ Liệu | `Raft_Data/Managed/` |
| Thư Mục Mod | `mods/Raft/` |
| Thư Mục Dự Án | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — hỗ trợ |
| Versions.xml | `1.1.01` (có checksum) |

Sau khi kết thúc chính thức cốt truyện trong v1.0: *The Final Chapter*, các bản vá tiếp tục cho cải thiện mã mạng và ổn định.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Mục | Giá Trị |
|---|---|
| Engine | Unity 6 (di chuyển từ Unity 2021/2022 cuối năm 2025) |
| Phiên Bản Mới Nhất | v0.67.0.0 |
| Cập Nhật Cuối | 26 tháng 6 năm 2025 — tái cấu trúc phân bố đảo và cập nhật engine; hotfix đang tiếp tục đến 2026 |
| Tệp Thực Thi | `EscapeThePacific.exe` |
| Thư Mục Dữ Liệu | `EscapeThePacific_Data/Managed/` |
| Thư Mục Mod | `mods/EscapeThePacific/` |
| Thư Mục Dự Án | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — hỗ trợ |

Hoàn thành việc tái xây dựng hệ thống lớn và di chuyển sang Unity 6 cuối năm 2025, cho phép môi trường năng động hơn. Trò chơi vẫn đang trong giai đoạn phát triển Early Access.

> **XML viết lại trong v2.0.9610**: `extends="GenericUnityGame"` đã xóa; `includeAssembly` đặt chỉ `Assembly-CSharp.dll` — ngăn lỗi kế thừa `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Mục | Giá Trị |
|---|---|
| Engine | Unity 2019 |
| Phiên Bản Mới Nhất | v2.9.5 |
| Cập Nhật Cuối | 4 tháng 2 năm 2026 — tối ưu hóa Steam Deck và cải thiện khả năng đọc văn bản |
| Tệp Thực Thi | `GH.exe` |
| Thư Mục Dữ Liệu | `GH_Data/Managed/` |
| Thư Mục Mod | `mods/GH/` |
| Thư Mục Dự Án | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — hỗ trợ |
| Versions.xml | `2.9.5` (có checksum) |

Phát triển với các nâng cấp engine từng bước Unity 2017 → 2018 → 2019. Bản hotfix tháng 2 năm 2026 tập trung vào khả năng tương thích Steam Deck và khả năng đọc văn bản UI.

> **XML viết lại trong v2.0.9610**: `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` đã thêm; `DOTweenPro.dll` không tồn tại đã xóa.
</details>

---

## Kiến Trúc

### Phân Tách Thời Gian Chạy

| Thành phần | Mục tiêu | Thời gian chạy | Lý do |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Ứng dụng desktop, API hiện đại đầy đủ |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Thư viện dùng chung |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Cố định vĩnh viễn** — header PE phải chứa `v2.0.50727` |
| DLL Mod (người dùng) | .NET Framework 4.8 | Game Mono 2.0 (đã vá) | Được build với 4.8, header PE được vá khi áp dụng |

### Phân Tách Bản Dựng Debug / Release

Tất cả xác thực tệp và xử lý assembly phân nhánh dựa trên cấu hình bản dựng qua `#if DEBUG` / `#else`.

| Vị trí | Bản dựng Debug | Bản dựng Release |
|---|---|---|
| `CheckSteam()` | Chỉ `File.Exists()` — tệp giả đạt | `FileValidator.IsValidSteamExe()` — header PE + tối thiểu 1 MB |
| `CheckGamePath()` | Chỉ `File.Exists()` — tệp giả đạt | `FileValidator.IsValidAssemblyDll()` — header PE + metadata CLR + tối thiểu 64 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — bỏ qua phân tích Cecil | Phân tích đầy đủ Mono.Cecil + sửa đổi IL + `module.Write()` |
| `ModLib.Create()` — không tìm thấy tệp | Ghi cảnh báo, bỏ qua và tiếp tục | Ghi lỗi, hủy bỏ với popup |

**Kiểm thử Debug** sử dụng `create_dummy_Debug_games.ps1` để tạo tệp giữ chỗ 0 byte dưới `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` và `bin\Debug\gamefiles\original\`. Chúng đạt kiểm tra `File.Exists()` và cho phép kiểm thử đầy đủ luồng công việc UI mà không cần cài đặt trò chơi thực.

**Bản dựng Release** áp dụng `FileValidator` (xác minh header PE + metadata CLR .NET) để từ chối tệp 0 byte, tệp văn bản và nhị phân tùy ý. Chỉ các tệp thực thi Windows hợp lệ và assembly .NET đạt.

### FileValidator — Xác Minh Header PE

`ModAPI_Shared\Utils\FileValidator.cs` — chỉ áp dụng trong bản dựng Release.

| Phương thức | Kiểm tra | Kích thước tối thiểu |
|---|---|---|
| `IsValidSteamExe(path)` | Chữ ký MZ + chữ ký PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Chữ ký MZ + chữ ký PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + header metadata CLR (thư mục dữ liệu #14) | 64 KB |

```
PE Header layout checked:
[0x00] 4D 5A          ← "MZ" DOS signature
[0x3C] XX XX XX XX   ← PE header offset (little-endian)
[offset] 50 45 00 00 ← "PE\0\0" signature
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← .NET CLR header present
```

### Pipeline Ánh Xạ Lại Assembly

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

### Dự Phòng Bộ Giải Quyết Assembly

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← backup folder
2. {ActualGameInstallPath}/{AssemblyPath}        ← game install folder (fallback)
```

### Hỗ Trợ Tính Năng C# 7.3

| Tính năng | Trạng thái | Ghi chú |
|---|---|---|
| Khớp mẫu (`is`, `switch`) | ✅ | Đã xác minh trong trò chơi |
| Nội suy chuỗi (`$""`) | ✅ | Đã xác minh trong trò chơi |
| Biến `out` nội tuyến | ✅ | Đã xác minh trong trò chơi |
| `async` / `await` | ✅ | Qua AsyncBridge + polyfill System.Threading |
| Tuple (`ValueTuple`) | ❌ Giới hạn tuyệt đối | ABI `mscorlib` Mono 2.0 — không có giải pháp |

### Hệ Thống Giao Diện

Từ v2.0.9613, giao diện chọn chủ đề đã được chuyển từ tab Settings sang **tab Themes** riêng biệt. Để thêm chủ đề mới chỉ cần một dòng trong từ điển `App.xaml.cs`.

| Chỉ mục | ID | Tệp | Bảng màu |
|---|---|---|---|
| 0 | `classic` | Chỉ `Dictionary.xaml` | Nền kết cấu gốc ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tông sáng + điểm nhấn xanh |
| 2 | `dark` | `FluentStyles.xaml` | Tông tối + điểm nhấn xanh (mặc định) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Đỏ + đen |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Không gian tối |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Hoàng hôn sáng |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Đại dương tối |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Bắc Âu sáng |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cam chanh sáng |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Hoa sáng |

Thay đổi chủ đề kích hoạt khởi động lại ứng dụng tự động. (lưu trong `theme.cfg`)

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

### Kết Cấu Nền

Chọn hình ảnh trong thẻ **Background Texture** trên tab Themes để áp dụng làm nền toàn ứng dụng. Định dạng hỗ trợ: `.png` / `.jpg` / `.jpeg`, tối đa 50MB, độ phân giải 4K trở xuống. Hình ảnh được nén JPEG Q75 với header ma thuật 16 byte và lưu dưới dạng `resources\textures\ui_bg\bg.dat` (thuộc tính Hidden). Hash SHA-256 để xác minh tính toàn vẹn; khi phát hiện giả mạo sẽ tự động đặt lại + popup cảnh báo.

Khi nền hoạt động, tính trong suốt của UI được xử lý theo hai lớp: Layer 1 (lớp phủ MergedDictionaries) cho các panel `{DynamicResource}`, Layer 2 (WalkStyleBackgrounds) cho các panel dựa trên `{StaticResource}` với bán trong suốt.

### Hệ Thống Cỡ Chữ

| Khóa tài nguyên | Cơ sở | Mô tả |
|---|---|---|
| `AppBaseFontSize` | 13 | Văn bản thường |
| `AppBaseHeaderFontSize` | 16 | Tiêu đề, tên bảng |
| `AppBaseSmallFontSize` | 12 | Nhãn phụ |
| `AppBaseTinyFontSize` | 10 | Văn bản gợi ý |
| `AppBaseLargeFontSize` | 20 | Văn bản hiển thị lớn |

### Cấu Hình UI Bền Vững — `ui.cfg`

| Khóa | Mặc định | Mô tả |
|-----|---------|-------------|
| `ModListWidth` | `150` | Chiều rộng danh sách mod (px) |
| `ProjectListWidth` | `150` | Chiều rộng danh sách dự án (px) |
| `AppFontSize` | `13` | Cỡ chữ UI toàn cục (px) |
| `AlwaysOnTop` | `false` | Cửa sổ luôn ở trên cùng |
| `TexturePath` | *(không)* | Tên tệp gốc kết cấu nền (chỉ hiển thị) |
| `TextureHash` | *(không)* | Hash SHA-256 kết cấu nền |
| `TextureActive` | `false` | Trạng thái kích hoạt kết cấu nền |
| `GamePathReset_{GameId}` | *(không)* | Cờ đặt lại đường dẫn trò chơi |
| `SteamPathReset` | *(không)* | Cờ đặt lại đường dẫn Steam |

### Cấu Trúc Tệp

```
ModAPI/
├── App.xaml / App.xaml.cs              # Đăng ký chủ đề, ID chủ đề, Áp dụng chủ đề
├── ui.cfg                               # Cài đặt UI bền vững
├── theme.cfg                            # Chủ đề hiện tại
├── Windows/
│   ├── MainWindow.xaml / .cs            # Giao diện chính — 6 tab, Chủ đề, Cài đặt, Đường dẫn Steam
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup đường dẫn trò chơi (GameNameLabel động)
│       ├── FirstSetup.xaml / .cs        # Cấu hình lần đầu + khởi tạo mặc định
│       └── (14 cửa sổ phụ khác)
├── Themes/
│   ├── Dictionary.xaml                  # Chủ đề Classic
│   ├── FluentStyles.xaml                # Chủ đề Dark
│   ├── FluentStylesLight.xaml           # Chủ đề Light
│   ├── FluentStylesDiablo.xaml          # Chủ đề Diablo
│   ├── FluentStylesNebula.xaml          # Chủ đề Nebula
│   ├── FluentStylesSunset.xaml          # Chủ đề Sunset
│   ├── FluentStylesOcean.xaml           # Chủ đề Ocean
│   ├── FluentStylesNordic.xaml          # Chủ đề Nordic
│   ├── FluentStylesCitrus.xaml          # Chủ đề Citrus
│   └── FluentStylesBloom.xaml           # Chủ đề Bloom
├── Data/
│   ├── Game.cs                          # Vá assembly, bảo vệ null, dự phòng bộ giải quyết
│   ├── ModLib.cs                        # Tạo BaseModLib + ánh xạ lại (#if DEBUG phân nhánh)
│   ├── Models/
│   │   └── ModProject.cs                # Tạo/build/áp dụng dự án + bảo vệ null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # Mod đã lọc, Mod đã chọn, Bộ lọc trò chơi đã chọn
│   │   ├── ModViewModel.cs              # Lấy GameId từ đường dẫn thư mục
│   │   ├── ModProjectsViewModel.cs      # Dispose() cho DispatcherTimer
│   │   └── SettingsViewModel.cs         # Mặc định true cho UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Ánh xạ phiên bản assembly Mono 2.0 (20 assembly)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Bộ giải quyết theo tên (có bộ nhớ đệm)
│   └── MonoHelper.cs                    # Tiện ích hỗ trợ IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 tệp ngôn ngữ
│   └── textures/ui_bg/
│       └── bg.dat                       # Ảnh nền đã nén và bảo mật (tạo khi chạy)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Viết lại hoàn toàn v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Viết lại hoàn toàn v2.0.9610
    │   ├── GH.xml                       # Viết lại hoàn toàn v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — không hỗ trợ
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Data/
│   ├── Game.cs                          # Constructor nhẹ + sửa khởi tạo ModLibrary
│   └── ModLib.cs                        # Phân nhánh #if DEBUG cho phân tích Cecil
└── Utils/
    └── FileValidator.cs                 # Xác minh header PE + metadata CLR (chỉ Release)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
└── MODAPI_VersionTool.csproj            # Công cụ cập nhật phiên bản WPF độc lập

bin\Debug\                               # Debug testing only
├── create_dummy_Debug_games.ps1         # Tạo cấu trúc trò chơi/Steam giả
├── dummy_games\{GameId}\               # Đường dẫn cài đặt trò chơi giả
├── dummy_steam\Steam.exe               # Tệp thực thi Steam giả
└── gamefiles\original\{GameId}\        # Đường dẫn sao lưu giả cho ModLib
```

---

## Cài Đặt & Cấu Hình

### Bước 1 — Điều kiện tiên quyết

| Mục | Bắt buộc |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (đã cài sẵn trên Windows 11; [tải xuống](https://dotnet.microsoft.com/download/dotnet-framework/net48) cho Windows 10) |
| Steam | Bắt buộc — phải được cấu hình trong tab Settings |
| Ít nhất một trò chơi được hỗ trợ | Bắt buộc — phải được cấu hình trong tab Settings |

### Bước 2 — Cài đặt ModAPI

1. Tải bản phát hành mới nhất từ GitHub
2. Giải nén vào thư mục bất kỳ (ví dụ: `C:\ModAPI\`)
3. Chạy `ModAPI.exe`
4. Khi khởi chạy lần đầu, màn hình **Welcome** xuất hiện — cấu hình tùy chọn và nhấp **Continue**

### Bước 3 — Cấu hình đường dẫn Steam (tab Settings)

1. Chuyển đến tab **Settings**
2. Tìm **Steam Installation Path**
3. Nhấp **Browse** → chọn `Steam.exe`
4. Nhấp **Save**

### Bước 4 — Cấu hình đường dẫn trò chơi (tab Settings)

1. Nhấp vào tiêu đề thẻ trò chơi để mở rộng
2. Nhấp **Browse** → chọn thư mục gốc trò chơi (nơi có tệp `.exe`)
3. Nhấp **Save**

| Trò chơi | Tệp thực thi | Đường dẫn ví dụ |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Bước 5 — Tải Mod (tab Downloads)

1. Chuyển đến tab **Downloads**
2. Chọn trò chơi từ bộ lọc trò chơi
3. Tìm kiếm mod và nhấp **Download**

> **Ngoại tuyến**: Tải tệp `.mod` thủ công từ `modapi.survivetheforest.net` và đặt vào thư mục tương ứng:

| Trò chơi | Thư mục |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Bước 6 — Áp dụng Mod và Khởi động Trò chơi (tab Mods)

1. Chuyển đến tab **Mods**
2. Chọn trò chơi từ **Bộ lọc Trò chơi** (Cột 0)
3. Đánh dấu mod để kích hoạt trong **Danh sách Mod** (Cột 1)
4. Nhấp **Start Game**

Các kiểm tra sau được thực hiện tự động trước khi khởi chạy:

| # | Kiểm tra | Popup lỗi |
|---|---|---|
| 1 | Đường dẫn Steam đã cấu hình và hợp lệ | SteamNotFound |
| 2 | Trò chơi trong thư mục `mods/` khớp với đường dẫn trong Settings | GameModsMismatch |
| 3 | Ít nhất một mod đã chọn | NoModSelected |
| 4 | Không có mod trò chơi hỗn hợp trong lựa chọn | MixedGameMods |
| 5 | Đường dẫn trò chơi đã cấu hình và tệp thực thi tồn tại | GamePathNotSet / GameNotInstalled |

---

## Tổng Quan Tab

### Tab Welcome
Màn hình cấu hình lần đầu (chỉ mục tab 0). Cấu hình AutoUpdate, kết nối Steam và tùy chọn bảng VersionsData. Trong các lần khởi chạy sau, tab này cung cấp liên kết cộng đồng và ghi chú phát hành.

### Tab Mods
Luồng công việc quản lý mod chính — bố cục 3 cột:

| Cột | Nội dung |
|---|---|
| Cột 0 | Bộ lọc Trò chơi — nút radio cho 5 trò chơi được hỗ trợ |
| Cột 1 | Danh sách Mod — mod đã cài với bộ chọn phiên bản và hộp kiểm kích hoạt |
| Cột 2 | Thông tin — chi tiết mod đã chọn, mô tả, lịch sử phiên bản |

### Tab Downloads
Duyệt và tải mod từ `modapi.survivetheforest.net`.

- **Bộ lọc trò chơi**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Bộ lọc danh mục**: 12 danh mục (Bugfixes, Balancing, Cheats, …)
- **Tìm kiếm**: theo tên mod, mô tả hoặc tác giả
- **Chế độ ngoại tuyến**: hiển thị hướng dẫn thư mục cho tất cả 5 trò chơi được hỗ trợ

### Tab Development
Luồng công việc phát triển mod — bảng bộ lọc trò chơi (Cột 0) bao gồm tất cả 5 trò chơi được hỗ trợ.

- Tạo, build và áp dụng dự án mod cho mỗi trò chơi
- Quản lý tài nguyên ngôn ngữ
- Tạo ModLib với xác thực 3 bước (Steam → dự án → đường dẫn trò chơi)
- Chuyển đổi trò chơi an toàn qua constructor nhẹ `Game` (không gọi `Verify()`)

### Tab Themes
Chọn chủ đề và quản lý kết cấu nền.

- **Chọn chủ đề**: 10 chủ đề (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Kết cấu nền**: Chọn hình ảnh làm nền toàn ứng dụng (nén JPEG + xử lý bảo mật)
- Khi kết cấu nền hoạt động, việc chọn chủ đề bị khóa

### Tab Settings
Cấu hình tập trung — 4 hàng:

| Hàng | Nội dung |
|---|---|
| 0 | Ngôn ngữ / Cỡ chữ / Chủ đề / Chiều rộng tối đa / Chiều rộng danh sách mod / Chiều rộng danh sách dự án |
| 1 | Giữ VersionsData / Tự động cập nhật / Kết nối Steam / Luôn ở trên cùng |
| 2 | Đường dẫn cài đặt Steam (TextBox + Duyệt + Lưu + Đặt lại) |
| 3 | Đường dẫn cài đặt trò chơi — thẻ mở rộng cho mỗi trò chơi (TextBox + Duyệt + Lưu + Đặt lại) |

---

## Thay Đổi trong v2.0.9618

### Công Cụ Cập Nhật Phiên Bản (MODAPI_VersionTool)

Công cụ WPF độc lập để cập nhật số phiên bản chỉ với một cú nhấp chuột.

**Vị trí**: `VersionTool\MODAPI_VersionTool.csproj`

## Version Tool
<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/1310a99b-d4ac-4baa-89c3-cd0640fbbe26" />

**Tính năng**
- Tự động hiển thị phiên bản hiện tại (đọc từ `App.xaml.cs`)
- Nhập phiên bản mới và nhấp **Apply Version** để cập nhật cả hai tệp đồng thời
- Xác thực định dạng: chỉ chấp nhận định dạng `X.X.XXXX`

**Tệp được sửa đổi**

| File | Path | Change |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Cách sử dụng**
1. Run `MODAPI_VersionTool.exe`
2. Nhập phiên bản mới (ví dụ: `2.0.9619`)
3. Click **Apply Version**
4. Build lại giải pháp ModAPI trong Visual Studio

### Sửa Hiển Thị Phiên Bản StatusBar

- `VersionLabel.Text` giờ tham chiếu `App.Version` thay vì `Version.Descriptor` được mã hóa cứng
- Cập nhật phiên bản bằng VersionTool và build lại giờ phản ánh ngay trong StatusBar

---

## Thay Đổi trong v2.0.9617

### Tab Settings — Thêm Nút Đặt Lại Đường Dẫn

Nút **Reset** đã được thêm to the Steam installation path and each game installation path row.

**Hàng đường dẫn Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Hàng đường dẫn trò chơi (mỗi trò chơi)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Hành vi đặt lại**
- Xóa TextBox đường dẫn ngay lập tức
- Lưu cờ đặt lại vào `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- TextBox vẫn trống sau khi khởi động lại
- Khắc phục hạn chế Configuration XML không lưu chuỗi rỗng

**Tự động lưu Browse**
- Trước: cần nhấp riêng nút Save sau Browse
- Sau: tự động lưu khi chọn tệp — phản ánh ngay cả sau khi chuyển sang tab Mods

**Khóa ngôn ngữ mới**

| Key | Value |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

## Thay Đổi trong v2.0.9616

### Versions.xml — 4 Trò Chơi Được Thêm / Cập Nhật

| Game | File Path | BuildID | Notes |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Mới tạo |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Checksum đã cập nhật |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Mới tạo |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Checksum đã cập nhật |

### Quy Tắc Tạo Checksum

Định dạng checksum khác nhau tùy thuộc vào việc `Assembly-CSharp-firstpass.dll` có tồn tại cho mỗi trò chơi hay không.

| Trò chơi | firstpass.dll | Định dạng Checksum |
|---|---|---|
| GH | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối (64 ký tự) |
| Subnautica | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối (64 ký tự) |
| EscapeThePacific | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối (64 ký tự) |
| Raft | ❌ Không có | Chỉ `Assembly-CSharp MD5` (32 ký tự) |

### Quy Trình Cập Nhật Versions.xml

Thêm mục `<version>` mới mà không xóa các mục hiện có.

**Bước 1 — Tìm BuildID mới**
```powershell
Get-Content "C:\Program Files (x86)\Steam\steamapps\appmanifest_{AppID}.acf" | Select-String "buildid"
```

| Game | AppID |
|---|---|
| Subnautica | 264710 |
| Raft | 648800 |
| EscapeThePacific | 655290 |
| GH | 815370 |

**Bước 2 — Trích xuất checksum mới**
```powershell
# Games with firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Concatenate both Hash values in order (firstpass first)

# Games without firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Bước 3 — Thêm mục vào Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

## Thay Đổi trong v2.0.9615

### Sửa Mở Rộng Đường Dẫn Trò Chơi Trong Tab Settings

- **Chiều cao mở rộng thẻ**: Đáy cửa sổ giờ tăng chính xác bằng chiều cao trường nhập khi mở rộng thẻ đường dẫn trò chơi
- **`UpdateWindowHeight()` cải tiến**: Gọi `UpdateLayout()` trước khi đo `SizeToContent.Height`; tạm đặt `TextureLayer1` thành `Collapsed` khi kết cấu nền hoạt động để kích thước gốc hình ảnh 4K không ảnh hưởng đến tính toán chiều cao
- **Sửa Row Grid bên trong**: Đổi Row cuối cùng của Grid bên trong bảng đường dẫn trò chơi từ `Height="*"` thành `Height="Auto"` — xóa khoảng trắng đáy không cần thiết

---

## Thay Đổi trong v2.0.9614

### Sửa Hành Vi Nút Phóng To

- **Phóng to**: Sử dụng `SystemParameters.WorkArea` để phóng to thủ công thay vì `WindowState.Maximized` — vừa chính xác với độ phân giải màn hình hiện tại mà không chồng lên thanh tác vụ
- **Khôi phục**: Lưu `Left`, `Top`, `Width`, `Height` và `MaxWidth` trước khi phóng to và khôi phục khi nhấp nút khôi phục
- **Xử lý `MaxWidth`**: Đặt thành `∞` khi phóng to, khôi phục giá trị đã lưu khi bình thường hóa

---

## Thay Đổi trong v2.0.9613

### Tab Themes Mới

Tab order is now:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Giao diện chọn chủ đề đã được chuyển từ tab Settings sang **tab Themes** chuyên dụng.
Icon: Segoe MDL2 Assets `&#xE790;` (palette)

### Đăng Ký Chủ Đề (Cấu Trúc Dữ Liệu)

Thêm chủ đề mới giờ chỉ cần **một dòng** trong dictionary `App.xaml.cs`.
Tất cả câu lệnh switch đã được xóa — không cần thay đổi mã ở nơi khác.

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
Quy ước khóa ngôn ngữ: `Lang.Options.Theme.{PascalCase}` (ví dụ: `Lang.Options.Theme.Nebula`)

### Chủ Đề Được Hỗ Trợ

| Index | ID | File | Palette |
|---|---|---|---|
| 0 | `classic` | Chỉ `Dictionary.xaml` | Nền kết cấu gốc ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tông sáng + điểm nhấn xanh |
| 2 | `dark` | `FluentStyles.xaml` | Tông tối + điểm nhấn xanh (mặc định) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Đỏ + đen |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Không gian tối |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Hoàng hôn sáng |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Đại dương tối |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Bắc Âu sáng |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cam chanh sáng |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Hoa sáng |

Thay đổi chủ đề kích hoạt khởi động lại ứng dụng tự động. (lưu trong `theme.cfg`)

### Tính Năng Kết Cấu Nền

Chọn hình ảnh trong thẻ **Background Texture** trên tab Themes để áp dụng làm nền toàn ứng dụng. Hoạt động với bất kỳ chủ đề nào được chọn.

**Định dạng đầu vào hỗ trợ**: `.png` / `.jpg` / `.jpeg`, tối đa 50MB, độ phân giải 4K trở xuống

**Pipeline xử lý hình ảnh**

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

**Các lớp bảo mật**

| Lớp | Phương thức | Hiệu quả |
|---|---|---|
| Header ma thuật | 16 byte chèn trước chữ ký JPEG (FF D8 FF) | Trình xem bên ngoài không thể nhận dạng tệp |
| Thuộc tính Hidden | `FileAttributes.Hidden` | Ẩn khỏi Explorer theo mặc định |
| Tính toàn vẹn SHA-256 | Hash được xác minh khi tải | Giả mạo kích hoạt đặt lại tự động + popup cảnh báo |

**Hành vi phát hiện giả mạo**
1. `bg.dat` deleted
2. Các khóa `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` được đặt lại
3. TextBox và toggle được đặt lại
4. Popup `Lang.Windows.TextureTampered` được hiển thị

**ui.cfg keys**

| Key | Value | Description |
|---|---|---|
| `TexturePath` | Filename (display only) | Original filename shown in TextBox |
| `TextureHash` | SHA-256 hex | Integrity verification hash |
| `TextureActive` | `true` / `false` | Activation state |

**Xử lý trong suốt**

Khi hình nền hoạt động, nền UI được xử lý theo hai lớp.

- **Lớp 1 — lớp phủ MergedDictionaries**: Các panel tham chiếu `{DynamicResource FluentBgBrush}` v.v. tự động trở nên trong suốt. Khôi phục bằng một lệnh `Remove()` khi hủy kích hoạt.

  Target keys: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Lớp 2 — Duyệt cây trực quan (`WalkStyleBackgrounds`)**: Các phần tử `{StaticResource}` trong chủ đề Fluent không bị ảnh hưởng bởi Lớp 1, vì vậy cây trực quan được duyệt trực tiếp để áp dụng các brush bán trong suốt dựa trên màu gốc.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=fully transparent, 255=opaque → 100 ≈ 39% opaque
  ```

  Xử lý: `Panel` (trừ Grid), `Border`, `ListBox` / `ListView`

  Loại trừ: `Grid` (nền được giữ, con được duyệt), `TabPanel` (bảo vệ header tab), `ButtonBase` / `ComboBox`, phần tử `Collapsed`

  Khôi phục: nguồn Style Setter → `ClearValue()`, nguồn giá trị cục bộ XAML → khôi phục brush gốc trực tiếp

**Chuyển tab**

WPF TabControl tải nội dung tab chậm, vì vậy `WalkStyleBackgrounds(this)` được chạy lại với ưu tiên `ContextIdle` khi chuyển tab. Các phần tử đã xử lý được bỏ qua qua kiểm tra `ContainsKey`.

**Khóa ThemeSelector**

Khi kết cấu nền hoạt động, một Border `ThemeSelectorOverlay` được hiển thị trên bộ chọn chủ đề để chặn tương tác.

- XAML: `ThemeSelectorOverlay` Border added above ThemeSelector (`IsHitTestVisible=True`)
- Active: `ThemeSelectorOverlay.Visibility = Visible`
- Inactive: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` cũng được bảo vệ bởi cờ `_textureActive`

**Luồng trạng thái UI**

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

**Khóa ngôn ngữ mới**

| Key | Description |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 new theme names |
| `Lang.Options.Labels.TextureBackground` | Background texture label |
| `Lang.Options.Labels.TextureEnable` | Enable label |
| `Lang.Options.Labels.TextureClear` | Clear button |
| `Lang.Windows.TextureTooLarge` | File size exceeded warning |
| `Lang.Windows.TextureTampered` | Tampering detected warning |

**Cấu trúc tệp**

```
ModAPI\
├── App.xaml.cs                    # Đăng ký chủ đề, ID chủ đề, Áp dụng chủ đề
├── Windows\
│   ├── MainWindow.xaml            # Tab Themes, lớp phủ chọn chủ đề, lớp kết cấu 1
│   └── MainWindow.xaml.cs         # Logic chủ đề và kết cấu
├── Themes\
│   ├── Dictionary.xaml            # Chủ đề Classic
│   ├── FluentStyles.xaml          # Chủ đề Dark
│   ├── FluentStylesLight.xaml     # Chủ đề Light
│   ├── FluentStylesDiablo.xaml    # Chủ đề Diablo
│   ├── FluentStylesNebula.xaml    # Chủ đề Nebula
│   ├── FluentStylesSunset.xaml    # Chủ đề Sunset
│   ├── FluentStylesOcean.xaml     # Chủ đề Ocean
│   ├── FluentStylesNordic.xaml    # Chủ đề Nordic
│   ├── FluentStylesCitrus.xaml    # Chủ đề Citrus
│   └── FluentStylesBloom.xaml     # Chủ đề Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Ảnh nền đã nén và bảo mật (tạo khi chạy)
```

**Ràng buộc thiết kế đã biết**

| Item | Details |
|---|---|
| `IsEnabled=false` on ComboBox | Causes `ElementNotEnabledException` crash → `IsHitTestVisible` overlay approach used |
| Thay thế trực tiếp khóa `MergedDictionaries` | Sập trong quá trình layout → chỉ sử dụng mẫu `Add`/`Remove` |
| Ghi đè tệp Hidden | `Access Denied` → phải đặt lại `FileAttributes.Normal` trước khi ghi |
| `{StaticResource}` backgrounds | Unaffected by Layer 1 → requires WalkStyleBackgrounds (Layer 2) |

---

## Thay Đổi trong v2.0.9612

### Tách Mô-đun Chủ Đề

- **Thư mục `Themes/` mới**: Di chuyển `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` và `FluentStylesClassic.xaml` vào `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — chủ đề Classic chỉ dùng `Dictionary.xaml`; Light/Dark/các chủ đề Fluent khác tải XAML tương ứng
- **`ModAPI.csproj`**: Đường dẫn XAML chủ đề cập nhật vào thư mục con `Themes\`; đã đăng ký `FluentStylesClassic.xaml`

---

## Thay Đổi trong v2.0.9611

### Sửa Lỗi

- **Chiều rộng danh sách mod không được áp dụng sau khi đổi chủ đề**: Đã sửa vấn đề chiều rộng danh sách Mod không được áp dụng sau khi chuyển đổi giữa chủ đề Light/Dark và khởi động lại — đã thêm lệnh gọi `ApplyModListWidth(width)` bên trong `InitModListWidth()`

---

---

## Thay Đổi trong v2.0.9610

### Đã Thêm

#### Cấu Hình XML Trò Chơi và Phiên Bản

| # | Tệp | Thay đổi |
|---|------|--------|
| 1 | `GH.xml` | Viết lại hoàn toàn — xóa không tồn tại `DOTweenPro.dll`; đã thêm `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Viết lại hoàn toàn — xóa `extends="GenericUnityGame"`; đã thêm `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Viết lại hoàn toàn — xóa `extends="GenericUnityGame"`; `includeAssembly` → `Assembly-CSharp.dll` only |
| 4 | `Raft/Versions.xml` | Đã tạo — phiên bản `1.1.01` có checksum |
| 5 | `GH/Versions.xml` | Đã tạo — phiên bản `2.9.5` có checksum |
| 6 | `Subnautica/Versions.xml` | Đã tạo — không có checksum (cập nhật quá thường xuyên) |

#### Sửa Lỗi Nghiêm Trọng

| # | Loại | Vấn đề | Sửa |
|---|------|-------|-----|
| 1 | Treo | `extends="GenericUnityGame"` gây ra kế thừa `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` bị treo | Đã xóa `extends` khỏi tất cả XML không phải TheForest |
| 2 | Sập | `ResolutionException: XGamingRuntime.XUserGamertagComponent` trong quá trình áp dụng Subnautica | Đã thêm `XGamingRuntime.dll`, `XblPCSandbox.dll` vào `copyAssembly` |
| 3 | Sập | Bộ giải quyết thất bại trên DLL được thêm vào `copyAssembly` sau khi tạo backup | `Game.cs`: thư mục cài đặt thực được thêm làm dự phòng bộ giải quyết |
| 4 | Sập | `IOException`: `BaseModLib.dll` khóa tệp giữa `CreateModLibrary` và `ApplyMods` | Vòng lặp thử lại: tối đa 10 × 500ms đọc + tối đa 30 × 500ms chờ tồn tại |
| 5 | Sập | `NullReferenceException` — `typesMap` entry.Value null (trò chơi chưa cài đặt) | Đã thêm `if (entry.Value == null) continue` |
| 6 | Sập | `NullReferenceException` — constructor nhẹ `Game` constructor thiếu `ModLibrary = new ModLib(this)` → sập `CreateModLibrary()` | Đã thêm `ModLibrary = new ModLib(this)` vào constructor nhẹ |
| 7 | Sập | `SwitchDevGame()` — `App.Game.GamePath` trống sau constructor nhẹ → sập `CreateModLibrary` | Đặt `App.Game.GamePath = savedPath` sau constructor nhẹ |
| 8 | Sai Trò Chơi | `EscapeThePacific` mod được phân loại là TheForest | `ModsViewModel`: `GameId` được trích xuất từ đường dẫn thư mục |
| 9 | Sai Đường Dẫn | `GetGameFolder()` → `""` → giải quyết thành gốc ổ đĩa (ví dụ: `E:\`) | Bảo vệ null/rỗng tại tất cả 6 điểm gọi |

#### Phân Tách Bản Dựng Debug / Release

- **`FileValidator.cs`** — tệp mới `ModAPI_Shared\Utils\FileValidator.cs`; đã đăng ký trong `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — header PE (MZ + PE\0\0) + tối thiểu 1 MB
  - `IsValidGameExe()` — header PE + tối thiểu 512 KB
  - `IsValidAssemblyDll()` — header PE + header metadata CLR .NET + tối thiểu 64 KB
- **`CheckSteam()`** — `#if DEBUG`: chỉ `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: chỉ `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` bỏ qua Cecil / `#else`: phân tích Cecil đầy đủ + sửa đổi IL
- **`ModLib.Create()` không tìm thấy tệp** — `#if DEBUG`: ghi cảnh báo, bỏ qua / `#else`: ghi lỗi, hủy bỏ

#### Kiểm Thử Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell cho `bin\Debug\`; tạo tệp giữ chỗ 0 byte cho tất cả 5 trò chơi dưới `dummy_games\`, `dummy_steam\` và `gamefiles\original\` — cho phép kiểm thử đầy đủ luồng công việc UI mà không cần cài đặt trò chơi thực

#### Tab Settings

- **Thẻ đường dẫn Steam** — được tích hợp vào thẻ Đường Dẫn Cài Đặt Trò Chơi; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Bảng đường dẫn trò chơi** — `BuildGamePathsPanel()` với thẻ mở rộng cho mỗi trò chơi; TextBox sử dụng `HorizontalAlignment=Stretch`
- Nút **Mở Rộng Tất Cả / Thu Gọn Tất Cả**
- Hộp kiểm **Luôn Ở Trên Cùng** (lưu trong `ui.cfg`)
- Thanh trượt **Chiều Rộng Danh Sách Mod/Dự Án** — bắt đầu từ tối thiểu `150`; lưu trong `ui.cfg`
- ComboBox **Cỡ Chữ** — FHD 10–16, 4K 10–22, 8K 10–28
- **Đồng bộ hộp kiểm** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions giờ đồng bộ chính xác
- **Cờ `_uiInitialized`** — ngăn ghi `ui.cfg` sớm trong quá trình khởi động WPF

#### Tab Mods — Xác Thực Khởi Động Trò Chơi

Xác thực năm bước chạy mỗi lần nhấp Start Game, bất kể trạng thái danh sách mod:

| Bước | Kiểm tra | Popup |
|---|---|---|
| 1 | Đường dẫn Steam trong tab Settings hợp lệ (`Steam.exe` tồn tại) | SteamNotFound |
| 2 | Trò chơi trong thư mục `mods/{GameId}/` khớp với trò chơi cấu hình trong Settings | GameModsMismatch |
| 3 | Ít nhất một mod đã chọn | NoModSelected |
| 4 | Không có mod trò chơi hỗn hợp trong lựa chọn | MixedGameMods |
| 5 | Đường dẫn trò chơi đã cấu hình + tệp thực thi tồn tại | GamePathNotSet / GameNotInstalled |

#### Tab Development — Xác Thực ModLib

Xác thực ba bước khi nhấp Tái Tạo Thư Viện Mod:

| Bước | Kiểm tra | Popup |
|---|---|---|
| 1 | Đường dẫn Steam trong tab Settings hợp lệ | SteamNotFound |
| 2 | Ít nhất một dự án tồn tại | NoProjectWarning |
| 3 | `App.Game.GamePath` đã đặt | GamePathNotSet |

#### Tab Downloads
- Chuỗi debug được thay thế bằng `Lang.Downloads.Status.NoDownloads`
- Padding nhất quán cho tất cả thông báo trạng thái
- Văn bản hướng dẫn ngoại tuyến cập nhật cho 5 trò chơi được hỗ trợ; ngắt dòng qua hai TextBlock

#### Cấu Hình Ban Đầu và Hệ Thống Đường Dẫn Trò Chơi
- `FirstSetup.Check()` — giá trị mặc định `true` cho `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — tạo thư mục `mods/` và `projects/` cho tất cả 5 trò chơi
- `SpecifyGamePath` — `GameNameLabel` hiển thị trò chơi nào; `NavigateToSettings()` chuyển hướng đến tab Settings

#### Khóa Ngôn Ngữ Mới / Cập Nhật

| Khóa | Giá trị tiếng Anh |
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

### Không Bao Gồm

| Tính năng | Lý do |
|---|---|
| Tự động cập nhật (giữ phiên bản mới nhất) | Cơ sở hạ tầng phía máy chủ không khả dụng |
| Tìm kiếm cập nhật | Cơ sở hạ tầng phía máy chủ không khả dụng |

### Đã Xóa

| Mục | Lý do |
|---|---|
| Popup `SpecifyGamePath` khi khởi động | Tất cả đường dẫn được cấu hình trong tab Settings |
| Popup `SpecifySteamPath` khi khởi động | Đường dẫn Steam được cấu hình trong tab Settings |
| Hệ thống đăng nhập | Máy chủ gốc không còn hoạt động (đã xóa trong v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Không hoạt động trên Mono 2.0 (đã xóa trong v2.0.9586) |
| Điều kiện `UseSteam` trong kiểm tra Steam | Steam giờ luôn được xác thực đầu tiên khi Start Game và Tái Tạo Thư Viện Mod |

---

## Dự Kiến Cho Phiên Bản Tương Lai

| # | Tính năng | Mô tả |
|---|---|---|
| 1 | Tự động cập nhật ModAPI | Tự động tải xuống và áp dụng phiên bản ModAPI mới |
| 2 | Cập nhật bảng VersionsData ModAPI | Tự động cập nhật bảng VersionsData khi có bản vá game mới |

---

## Thay Đổi trong v2.0.9600

### Đã Thêm

- **Tab Downloads**: 5 bộ lọc trò chơi (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Tab Welcome**: thêm ở vị trí ngoài cùng bên trái (chỉ mục 0)
- **Tab Mods**: bố cục 3 cột (WrapPanel → danh sách dọc); điều chỉnh chiều rộng tự động; xuống dòng tên mod
- **`ModsViewModel`**: lọc theo trò chơi, `ResolveGame()` cho instance `Game` chính xác cho mỗi mod
- **`Game.cs`**: constructor nhẹ `new Game(config, true)` — chỉ nhận dạng, không `Verify()`
- **Build**: 4 tệp XML trò chơi đăng ký trong `ModAPI.csproj` với `CopyToOutputDirectory=Always`
- **Build**: cảnh báo đã dọn — CS0168, CS0618, CS0252
- **XML Trò Chơi**: danh sách DLL của TheForest, Raft, GH đã sửa
- **Cờ ngôn ngữ**: kích thước hình ảnh chuẩn hóa trên tất cả 13 huy hiệu ngôn ngữ

### Đã Xóa

| Mục | Lý do |
|---|---|
| `extends="GenericUnityGame"` trong tệp XML trò chơi | Gây ra kế thừa sai `Assembly-CSharp-firstpass.dll` — đã xóa khỏi Subnautica, Raft, EscapeThePacific, GH |
| Bố cục `WrapPanel` trong tab Mods | Thay thế bằng bố cục Grid 3 cột (Bộ lọc Trò chơi / Danh sách Mod / Thông tin) |

---

## Thay Đổi Chính Theo Giai Đoạn

### Phase 1 *(v2.0.9200)* — .NET 4.8 Migration
Tất cả 5 dự án được di chuyển từ .NET 4.5 → 4.8.

### Phase 2 *(v2.0.9300)* — Build Environment & Fluent Design
ModernWpf 0.9.6, `FluentStyles.xaml`, DLL stub UnityEngine.

### Phase 3 *(v2.0.9500)* — UI Redesign & Theme System
Hệ thống 3 chủ đề, `theme.cfg`, sửa kéo cửa sổ, hỗ trợ siêu liên kết.

### Phase 4 *(v2.0.9400)* — Code Cleanup
Hệ thống đăng nhập đã xóa, cơ chế cập nhật hiện đại hóa.

### Phase 5-1 *(v2.0.9552)* — Downloads Tab & 13 Languages
Tab Downloads, biểu tượng Segoe MDL2 Assets, hỗ trợ 13 ngôn ngữ.

### Phase 5-5 *(v2.0.9561)* — Assembly Resolution
`AssemblyVersionMap.cs`, `CustomAssemblyResolver.cs`, vá header PE.

### Phase 5-6B *(v2.0.9586)* — C# 7.3 & Polyfill
Màn hình đen đã sửa, `ValueTuple` đã xóa, C# 7.3 đã xác minh trong trò chơi.

### Phase 6-1 *(v2.0.9600)* — Multi-Game & Mods Redesign
5 bộ lọc trò chơi, tab Mods 3 cột, constructor nhẹ `Game`, XML đã đăng ký.

### Phase 6-2 *(v2.0.9610)* — Settings, Safety, Crash Fixes & Debug/Release Split
XML đã sửa, đường dẫn Steam, an toàn đường dẫn trò chơi, xác thực Start Game 5 bước, xác thực ModLib 3 bước, xác minh header PE `FileValidator`, phân tách bản dựng `#if DEBUG`, `create_dummy_Debug_games.ps1`, sửa constructor nhẹ `ModLibrary`, sửa GamePath trong `SwitchDevGame`, tạo thư mục cho 5 trò chơi, sửa lỗi sập.

### Phase 6-3 *(v2.0.9611 ~ v2.0.9618)* — Theme System Expansion, Settings Improvements & Tools
Thêm tab Themes, 10 chủ đề + tính năng kết cấu nền, phân tách thư mục Themes/, sửa nút phóng to, sửa mở rộng đường dẫn trò chơi, cập nhật Versions.xml cho 4 trò chơi, nút đặt lại đường dẫn, tự động lưu Browse, MODAPI_VersionTool.

---

## Lịch Sử Phiên Bản

### v2.0.9618 — 2026-04-25
Thêm MODAPI_VersionTool (công cụ WPF cập nhật phiên bản độc lập), hiển thị phiên bản StatusBar liên kết với App.Version

### v2.0.9617 — 2026-04-24
Thêm nút đặt lại đường dẫn Steam/trò chơi trong tab Settings, tự động lưu Browse, trạng thái đặt lại được bảo toàn qua cờ ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml tạo/cập nhật cho 4 trò chơi (Subnautica, Raft, EscapeThePacific, GH), thiết lập quy tắc tạo checksum, tài liệu hóa quy trình cập nhật trò chơi

### v2.0.9615 — 2026-04-18
Sửa độ chính xác chiều cao mở rộng thẻ đường dẫn trò chơi trong Settings, ngăn kết cấu nền can thiệp UpdateWindowHeight

### v2.0.9614 — 2026-04-18
Nút phóng to với phóng to thủ công dựa trên WorkArea, lưu và khôi phục kích thước/vị trí trước đó

### v2.0.9613 — 2026-04-18
Thêm tab Themes, cấu trúc đăng ký chủ đề dữ liệu, hỗ trợ 10 chủ đề, tính năng kết cấu nền (nén, bảo mật, trong suốt 2 lớp), lớp phủ khóa ThemeSelector, 12 khóa ngôn ngữ mới

### v2.0.9612 — 2026-04-18
Tách thư mục Themes/, mô-đun hóa XAML chủ đề

### v2.0.9611 — 2026-04-18
Sửa chiều rộng danh sách mod không áp dụng sau khi đổi chủ đề

### v2.0.9610 — 2026-04-13
Multi-game XML corrected (GH, Subnautica, EscapeThePacific), Versions.xml added, Settings tab redesigned (Steam path, game paths panel, width sliders, font size, checkbox sync), game path null safety (6 sites), startup popups replaced by Settings tab, Mods tab 5-step Start Game validation (Steam always first), Dev tab 3-step ModLib validation, GameModsMismatch popup added, lightweight constructor ModLibrary null fix, SwitchDevGame GamePath fix, FileValidator PE header verification (Release), #if DEBUG build split (CheckSteam / CheckGamePath / ModLib.Create), create_dummy_Debug_games.ps1, persistent ui.cfg, 5-key font system, multiple crash fixes, language keys updated

### v2.0.9600 — 2026-04-09
5 bộ lọc trò chơi, bố cục 3 cột tab Mods, chiều rộng tự động, constructor nhẹ `Game`, lọc trò chơi `ModsViewModel`, 4 tệp XML đã đăng ký, cảnh báo build đã dọn, tab Welcome, cờ ngôn ngữ chuẩn hóa

### v2.0.9586 — 2026-03-31
Màn hình đen đã sửa, polyfill hoàn thiện, ValueTuple đã xóa, C# 7.3 đã xác minh

### v2.0.9561 — 2026-03-06
Hỗ trợ C# 7.3, vá header PE, pipeline polyfill, giải quyết assembly phục hồi

### v2.0.9552 — 2026-02-25
Tab Downloads, hiện đại hóa biểu tượng, thống nhất chủ đề, hỗ trợ 13 ngôn ngữ

### v2.0.9500
Hệ thống chủ đề (Classic/Light/Dark), Fluent Design UI, hệ thống SubWindow

### v2.0.9400
Dọn dẹp mã, xóa đăng nhập, hiện đại hóa legacy

### v2.0.9300
Môi trường build, DLL stub UnityEngine, tích hợp ModernWpf

### v2.0.9200
.NET Framework 4.8 migration

### v1.x
Original FluffyFish release

---

## Yêu Cầu Biên Dịch

| Yêu cầu | Phiên bản | Ghi chú |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Dự án ModAPI |
| .NET Framework SDK | 3.5 | Chỉ BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` in `libs/polyfills/` |

---

## Giấy Phép

GNU General Public License v3.0 — tuân theo giấy phép gốc.
