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

# ModAPI(v1) v2.0.9620 - 20260621

**Công Cụ Quản Lý Mod cho The Forest — Phiên Bản Nâng Cấp**

> Bản gốc: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Đức)
> Nâng cấp: zzangae (Hàn Quốc)

---

## Tổng Quan

ModAPI là ứng dụng desktop dùng để quản lý mod cho **5 tựa game được hỗ trợ chính thức**. Phiên bản nâng cấp này bao gồm hỗ trợ đa game, tab Settings được thiết kế lại hoàn toàn, cấu hình đường dẫn Steam, cài đặt giao diện được lưu lâu dài, hệ thống cỡ chữ động, kiểm tra khi khởi động game, tách biệt bản dựng Debug/Release, cùng nhiều bản sửa lỗi treo/crash đã được xác minh qua kiểm thử trong game.

---

## Các Game Được Hỗ Trợ

| Game | Engine | Phiên bản | Steam ID | Tệp thực thi |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | Bản vá 2025 | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

<details>
<summary><b>The Forest</b></summary>

| Mục | Giá trị |
|---|---|
| Engine | Unity 5 (nâng cấp từ Unity 4) |
| Phiên bản mới nhất | v1.12 (VR) |
| Cập nhật gần nhất | 11 tháng 9, 2019 — bản vá hỗ trợ VR; không có bản cập nhật nội dung lớn nào tiếp theo |
| Tệp thực thi | `TheForest.exe` |
| Thư mục dữ liệu | `TheForest_Data/Managed/` |
| Thư mục mod | `mods/TheForest/` |
| Thư mục dự án | `projects/TheForest/` |
| Steam App ID | `242760` |
| IL2CPP | ❌ Mono — được hỗ trợ đầy đủ |

The Forest đã được nâng cấp từ Unity 4 lên Unity 5, cải thiện đáng kể đồ họa và vật lý. Bản vá VR tháng 9 năm 2019 là bản cập nhật lớn cuối cùng. Hiện tại game vẫn duy trì ở trạng thái ổn định, đã hoàn thiện — lý tưởng để làm mod.
</details>

<details>
<summary><b>Subnautica</b></summary>

| Mục | Giá trị |
|---|---|
| Engine | Unity (mã nguồn tích hợp, được hợp nhất với Below Zero vào năm 2022) |
| Phiên bản mới nhất | Bản vá 2025 (v18810395) |
| Cập nhật gần nhất | 12 tháng 8, 2025 — sửa lỗi và cải thiện hiệu năng cùng với bản phát hành trên di động |
| Tệp thực thi | `Subnautica.exe` |
| Thư mục dữ liệu | `Subnautica_Data/Managed/` |
| Thư mục mod | `mods/Subnautica/` |
| Thư mục dự án | `projects/Subnautica/` |
| Steam App ID | `264710` |
| IL2CPP | ❌ Mono — được hỗ trợ |

Ban đầu được xây dựng trên Unity 5, Subnautica đã nhận bản cập nhật "Living Large" (v2.0) vào cuối năm 2022, hợp nhất mã nguồn engine với Below Zero để tối ưu hóa và ổn định hơn. Lưu ý: phần tiếp theo sắp ra mắt *Subnautica 2* sử dụng Unreal Engine 5.

> **XML được viết lại trong v2.0.9610**: `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` đã được thêm vào `copyAssembly`.
</details>

<details>
<summary><b>RAFT</b></summary>

| Mục | Giá trị |
|---|---|
| Engine | Unity |
| Phiên bản mới nhất | v1.1.02 (Beta) / v1.09 (Stable) |
| Cập nhật gần nhất | Tháng 3, 2026 — sửa lỗi chat thoại và chơi mạng qua nhánh beta |
| Tệp thực thi | `Raft.exe` |
| Thư mục dữ liệu | `Raft_Data/Managed/` |
| Thư mục mod | `mods/Raft/` |
| Thư mục dự án | `projects/Raft/` |
| Steam App ID | `648800` |
| IL2CPP | ❌ Mono — được hỗ trợ |
| Versions.xml | `1.1.01` (kèm checksum) |

Sau khi kết thúc cốt truyện chính thức ở v1.0: *The Final Chapter*, các bản vá vẫn tiếp tục để cải thiện mã mạng và độ ổn định. Bản cập nhật nhánh beta vào tháng 3 năm 2026 đã khắc phục các vấn đề về chat thoại và chơi mạng.
</details>

<details>
<summary><b>Escape The Pacific</b></summary>

| Mục | Giá trị |
|---|---|
| Engine | Unity 6 (di chuyển từ Unity 2021/2022 vào cuối năm 2025) |
| Phiên bản mới nhất | v0.67.0.0 |
| Cập nhật gần nhất | 26 tháng 6, 2025 — thiết kế lại phân bố đảo và cập nhật engine; các hotfix vẫn tiếp tục đến năm 2026 |
| Tệp thực thi | `EscapeThePacific.exe` |
| Thư mục dữ liệu | `EscapeThePacific_Data/Managed/` |
| Thư mục mod | `mods/EscapeThePacific/` |
| Thư mục dự án | `projects/EscapeThePacific/` |
| IL2CPP | ❌ Mono — được hỗ trợ |

Đã hoàn thành việc tái cấu trúc hệ thống lớn và di chuyển sang Unity 6 vào cuối năm 2025, cho phép tạo ra môi trường sống động hơn. Game vẫn đang trong quá trình phát triển tích cực ở giai đoạn Early Access.

> **XML được viết lại trong v2.0.9610**: đã xóa `extends="GenericUnityGame"`; `includeAssembly` chỉ được đặt là `Assembly-CSharp.dll` — ngăn ngừa lỗi kế thừa của `Assembly-CSharp-firstpass.dll`.
</details>

<details>
<summary><b>Green Hell</b></summary>

| Mục | Giá trị |
|---|---|
| Engine | Unity 2019 |
| Phiên bản mới nhất | v2.9.5 |
| Cập nhật gần nhất | 4 tháng 2, 2026 — tối ưu hóa cho Steam Deck và cải thiện khả năng đọc văn bản |
| Tệp thực thi | `GH.exe` |
| Thư mục dữ liệu | `GH_Data/Managed/` |
| Thư mục mod | `mods/GH/` |
| Thư mục dự án | `projects/GH/` |
| Steam App ID | `763790` |
| IL2CPP | ❌ Mono — được hỗ trợ |
| Versions.xml | `2.9.5` (kèm checksum) |

Được phát triển qua Unity 2017 → 2018 → 2019 trong suốt vòng đời của game. Hotfix tháng 2 năm 2026 tập trung vào khả năng tương thích với Steam Deck và khả năng đọc giao diện.

> **XML được viết lại trong v2.0.9610**: đã thêm `AmplifyBloom.dll`, `AmplifyColor.dll`, `AmplifyMotion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll`; đã xóa `DOTweenPro.dll` (không tồn tại).
</details>

---

<details>
<summary><b>Kiến Trúc</b></summary>

### Tách Biệt Môi Trường Chạy

| Thành phần | Mục tiêu | Môi trường chạy | Lý do |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Ứng dụng desktop, API hiện đại đầy đủ |
| `ModAPI_Shared.dll` | .NET Framework 4.8 | Windows .NET 4.8 | Thư viện dùng chung |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Cố định vĩnh viễn** — header PE phải hiển thị `v2.0.50727` |
| DLL mod (người dùng) | .NET Framework 4.8 | Game Mono 2.0 (đã vá) | Được build bằng 4.8, header PE được vá khi Apply |

### Công Cụ Dành Cho Nhà Phát Triển

Các tiện ích WPF độc lập dùng cho quản lý dự án. Không được phân phối cho người dùng cuối.

| Công cụ | Dự án | Mục đích |
|---|---|---|
| `MODAPI_VersionTool.exe` | `VersionTool\MODAPI_VersionTool.csproj` | Cập nhật đồng thời phiên bản của `AssemblyInfo.cs` và `App.xaml.cs` |
| `MODAPI_LangTool.exe` | `LangTool\MODAPI_LangTool.csproj` | Quản lý các tệp ngôn ngữ — thêm, chỉnh sửa, vô hiệu hóa, tích hợp sẵn |

**VersionTool — Quản Lý Phiên Bản**

Công cụ WPF độc lập để cập nhật số phiên bản chỉ bằng một cú nhấp chuột.

- Tự động hiển thị phiên bản hiện tại (đọc từ `App.xaml.cs`)
- Nhập phiên bản mới và nhấp **Apply Version** để cập nhật cả hai tệp đồng thời
- Kiểm tra định dạng: chỉ chấp nhận định dạng `X.X.XXXX`

| Tệp | Đường dẫn | Thay đổi |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**LangTool — Hệ Thống Ngôn Ngữ**

```
resources/langs/langs.json          ← Registry ngôn ngữ (cờ builtin / active)
resources/langs/Language.XX.xaml    ← Các khóa dịch cho mỗi ngôn ngữ
resources/langs/Language.XX.png     ← Hình cờ (36×24, từ flagcdn.com/h24/)
```

Quy trình tích hợp sẵn (nút Update):
```
builtin: false → true (langs.json)
  → CreateDefaultLangsJson() được viết lại (LangTool\MainWindow.xaml.cs)
  → Language.XX.xaml được đăng ký (ModAPI\ModAPI.csproj)
  → Bản build tiếp theo: ngôn ngữ được tích hợp hoàn toàn, khả dụng ngoại tuyến
```

### Tách Biệt Bản Dựng Debug / Release

Toàn bộ quá trình kiểm tra tệp và xử lý assembly được phân nhánh theo cấu hình build thông qua `#if DEBUG` / `#else`.

| Vị trí | Bản dựng Debug | Bản dựng Release |
|---|---|---|
| `CheckSteam()` | chỉ `File.Exists()` — tệp giả vẫn qua được | `FileValidator.IsValidSteamExe()` — header PE + tối thiểu 1 MB |
| `CheckGamePath()` | chỉ `File.Exists()` — tệp giả vẫn qua được | `FileValidator.IsValidAssemblyDll()` — header PE + metadata CLR + tối thiểu 8 KB |
| `ModLib.Create()` — IncludeAssemblies | `File.Copy()` — bỏ qua phân tích Cecil | Phân tích Mono.Cecil đầy đủ + sửa đổi IL + `module.Write()` |
| `ModLib.Create()` — không tìm thấy tệp | Ghi log cảnh báo, bỏ qua và tiếp tục | Ghi log lỗi, dừng lại kèm popup |

**Kiểm thử Debug** sử dụng `create_dummy_Debug_games.ps1` để tạo các tệp giữ chỗ 0 byte trong `bin\Debug\dummy_games\`, `bin\Debug\dummy_steam\` và `bin\Debug\gamefiles\original\`. Các tệp này vượt qua kiểm tra `File.Exists()` và cho phép kiểm thử toàn bộ luồng làm việc giao diện mà không cần cài đặt game thật.

**Bản dựng Release** áp dụng `FileValidator` (xác minh header PE + metadata CLR .NET) để từ chối tệp 0 byte, tệp văn bản và tệp nhị phân tùy ý. Chỉ những tệp thực thi Windows và assembly .NET hợp lệ mới vượt qua.

### FileValidator — Xác Minh Header PE

`ModAPI_Shared\Utils\FileValidator.cs` — chỉ áp dụng trong bản dựng Release.

| Phương thức | Kiểm tra | Kích thước tối thiểu |
|---|---|---|
| `IsValidSteamExe(path)` | Chữ ký MZ + chữ ký PE\0\0 | 1 MB |
| `IsValidGameExe(path)` | Chữ ký MZ + chữ ký PE\0\0 | 512 KB |
| `IsValidAssemblyDll(path)` | MZ + PE\0\0 + header metadata CLR (thư mục dữ liệu #14) | 8 KB |

```
Bố cục header PE được kiểm tra:
[0x00] 4D 5A          ← chữ ký DOS "MZ"
[0x3C] XX XX XX XX   ← offset header PE (little-endian)
[offset] 50 45 00 00 ← chữ ký "PE\0\0"
[Optional Header → DataDirectory[14]] RVA+Size != 0 ← sự hiện diện của header CLR .NET
```

### Pipeline Ánh Xạ Lại Assembly

```
[Nhà phát triển mod build bằng .NET 4.8]
  → DLL mod: header PE v4.0.30319, mscorlib 4.0.0.0

[ModAPI Apply — ModProject.cs]
  → AssemblyVersionMap.RemapAllReferences(modModule)
      mscorlib 4.0.0.0 → 2.0.0.0, v.v.
  → modModule.RuntimeVersion = "v2.0.50727"
      header PE: v4.0.30319 → v2.0.50727

[Game Mono 2.0]
  → header PE được chấp nhận ✅  →  các tham chiếu được giải quyết ✅
```

### Cơ Chế Dự Phòng Resolver Assembly

```
1. gamefiles/original/{GameId}/{AssemblyPath}   ← thư mục sao lưu
2. {ActualGameInstallPath}/{AssemblyPath}        ← thư mục cài đặt game (dự phòng)
```

### Hỗ Trợ Tính Năng C# 7.3

| Tính năng | Trạng thái | Ghi chú |
|---|---|---|
| So khớp mẫu (`is`, `switch`) | ✅ | Đã xác minh trong game |
| Nội suy chuỗi (`$""`) | ✅ | Đã xác minh trong game |
| Biến `out` inline | ✅ | Đã xác minh trong game |
| `async` / `await` | ✅ | Thông qua AsyncBridge + polyfill System.Threading |
| Tuple (`ValueTuple`) | ❌ Giới hạn cứng | ABI `mscorlib` của Mono 2.0 — không có cách khắc phục |
</details>

<details>
<summary><b>Theme System [Detailed Reference](v2.0.9613_themes_en.md)</b></summary>

Kể từ v2.0.9613, giao diện chọn theme đã được chuyển từ tab Settings sang tab **Themes** riêng biệt. Việc thêm theme mới chỉ cần một dòng trong dictionary `App.xaml.cs`.

| Chỉ số | ID | Tệp | Bảng màu |
|---|---|---|---|
| 0 | `classic` | chỉ `Dictionary.xaml` | Nền texture gốc của ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tông sáng + điểm nhấn xanh dương |
| 2 | `dark` | `FluentStyles.xaml` | Tông tối + điểm nhấn xanh dương (mặc định) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Đỏ + đen |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Không gian tối |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Hoàng hôn tươi sáng |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Đại dương tối |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Phong cách Bắc Âu tươi sáng |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cam quýt tươi sáng |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Hoa nở tươi sáng |

Việc đổi theme sẽ khởi động lại ứng dụng tự động. (được lưu trong `theme.cfg`)

| Theme | Theme |
| :---: | :---: |
|**01. Theme Classic**|**02. Theme Light**|
| ![01. Classic theme](https://github.com/user-attachments/assets/dc81132a-149c-4d0b-a7bb-a04a900e878b) | ![02. Light theme](https://github.com/user-attachments/assets/0d6925ec-f8b2-4f8a-a1d6-c082a5aa3378) |
|**03. Theme Dark**|**04. Theme Diablo**|
| ![03. Dark theme](https://github.com/user-attachments/assets/53abe172-ee66-4f3e-9c36-830b2d659b4d) | ![04. Diablo theme](https://github.com/user-attachments/assets/8c30f223-e564-45dc-8389-c51bfc60b3eb) |
|**05. Theme Nebula**|**06. Theme Sunset**|
| ![05. Nebula theme](https://github.com/user-attachments/assets/4ff565dd-516b-4951-9d47-6027ac9e3e29) | ![06. Sunset theme](https://github.com/user-attachments/assets/192a6f16-b041-4422-8b64-4f8522f27c15) |
|**07. Theme Ocean**|**08. Theme Nordic**|
| ![07. Ocean theme](https://github.com/user-attachments/assets/50a47588-bc62-4cfc-91a0-a44f87c45867) | ![08. Nordic theme](https://github.com/user-attachments/assets/81e98f6b-2897-4fd5-bee9-604c04dc26ff) |
|**09. Theme Citrus**|**10. Theme Bloom**|
| ![09. Citrus theme](https://github.com/user-attachments/assets/64ccb11d-4ab0-41a2-8e00-4f7910558372) | ![10. Bloom theme](https://github.com/user-attachments/assets/265c9249-4d43-4f77-86d6-ccc4037071f7) |

### Texture Nền

Chọn một hình ảnh trong thẻ **Background Texture** trên tab Themes để áp dụng làm nền cho toàn bộ ứng dụng. Định dạng được hỗ trợ: `.png` / `.jpg` / `.jpeg`, tối đa 50MB, độ phân giải 4K trở xuống. Hình ảnh được nén dưới dạng JPEG Q75 với header ma thuật 16 byte và lưu dưới dạng `resources\textures\ui_bg\bg.dat` (thuộc tính Hidden). Hash SHA-256 dùng để xác minh tính toàn vẹn; việc can thiệp sẽ kích hoạt reset tự động + popup cảnh báo.

Khi nền đang hoạt động, độ trong suốt của giao diện được xử lý theo hai lớp: Lớp 1 (lớp phủ MergedDictionaries) cho các panel `{DynamicResource}`, Lớp 2 (WalkStyleBackgrounds) cho các panel dựa trên `{StaticResource}` với độ trong suốt một phần.

### Hệ Thống Cỡ Chữ

| Khóa tài nguyên | Cơ sở | Mô tả |
|---|---|---|
| `AppBaseFontSize` | 13 | Văn bản thông thường |
| `AppBaseHeaderFontSize` | 16 | Tiêu đề, tiêu đề panel |
| `AppBaseSmallFontSize` | 12 | Nhãn phụ |
| `AppBaseTinyFontSize` | 10 | Văn bản gợi ý |
| `AppBaseLargeFontSize` | 20 | Văn bản hiển thị lớn |

### Cấu Hình Giao Diện Được Lưu Lâu Dài — `ui.cfg`

| Khóa | Mặc định | Mô tả |
|-----|---------|-------------|
| `ModListWidth` | `150` | Chiều rộng danh sách trong tab Mods (px) |
| `ProjectListWidth` | `150` | Chiều rộng danh sách dự án trong tab Development (px) |
| `AppFontSize` | `13` | Cỡ chữ giao diện toàn cục (px) |
| `AlwaysOnTop` | `false` | Cửa sổ luôn hiển thị trên cùng |
| `TexturePath` | *(không có)* | Tên tệp gốc của texture nền (chỉ để hiển thị) |
| `TextureHash` | *(không có)* | Hash SHA-256 của texture nền |
| `TextureActive` | `false` | Trạng thái kích hoạt của texture nền |
| `GamePathReset_{GameId}` | *(không có)* | Cờ reset đường dẫn game |
| `SteamPathReset` | *(không có)* | Cờ reset đường dẫn Steam |
</details>

<details>
<summary><b>Cấu Trúc Dự Án</b></summary>

```
ModAPI/
├── App.xaml / App.xaml.cs              # ThemeRegistry, ThemeIds, ApplyTheme()
├── ui.cfg                               # Cài đặt giao diện được lưu lâu dài
├── theme.cfg                            # Theme hiện tại
├── Windows/
│   ├── MainWindow.xaml / .cs            # Giao diện chính — 6 tab, Themes, Settings, đường dẫn Steam,
│   │                                    #   bảo vệ khỏi tải xuống 0 byte, debounce thanh trượt, đọc cấu hình âm thầm
│   └── SubWindows/
│       ├── SpecifyGamePath.xaml / .cs   # Popup đường dẫn game (GameNameLabel động)
│       ├── FirstSetup.xaml / .cs        # Thiết lập lần đầu + khởi tạo giá trị mặc định
│       └── (14 SubWindows khác)
├── Themes/
│   ├── Dictionary.xaml                  # Theme Classic
│   ├── FluentStyles.xaml                # Theme Dark
│   ├── FluentStylesLight.xaml           # Theme Light
│   ├── FluentStylesDiablo.xaml          # Theme Diablo
│   ├── FluentStylesNebula.xaml          # Theme Nebula
│   ├── FluentStylesSunset.xaml          # Theme Sunset
│   ├── FluentStylesOcean.xaml           # Theme Ocean
│   ├── FluentStylesNordic.xaml          # Theme Nordic
│   ├── FluentStylesCitrus.xaml          # Theme Citrus
│   └── FluentStylesBloom.xaml           # Theme Bloom
├── Data/
│   ├── Mod.cs                           # Tải tệp mod, phân tích header LF/CRLF, log chẩn đoán
│   ├── ModLib.cs                        # Tạo BaseModLib + ánh xạ lại (tách #if DEBUG)
│   ├── Models/
│   │   └── ModProject.cs                # Tạo/build/áp dụng dự án + bảo vệ null
│   ├── ViewModels/
│   │   ├── ModsViewModel.cs             # FilteredMods, SelectedModItem, SelectedGameFilter,
│   │   │                                #   ngăn thử lại đối với mod bị hỏng
│   │   ├── ModViewModel.cs              # GameId từ đường dẫn thư mục
│   │   ├── ModProjectsViewModel.cs      # Dispose() cho DispatcherTimer
│   │   └── SettingsViewModel.cs         # Giá trị mặc định true cho UseSteam/AutoUpdate/UpdateVersions
│   └── AssemblyVersionMap.cs            # Ánh xạ phiên bản assembly Mono 2.0 (20 assembly)
├── Utils/
│   ├── CustomAssemblyResolver.cs        # Resolver dựa trên tên có bộ nhớ đệm
│   └── MonoHelper.cs                    # Tiện ích hỗ trợ IL Mono.Cecil
├── resources/
│   ├── langs/                           # 13 tệp ngôn ngữ + langs.json (khóa LangTool.* được thêm ở v2.0.9620)
│   └── textures/ui_bg/
│       └── bg.dat                       # Hình ảnh nền đã nén và bảo mật (được tạo lúc chạy)
└── configs/
    ├── games/
    │   ├── TheForest.xml
    │   ├── Subnautica.xml               # Viết lại hoàn toàn ở v2.0.9610
    │   ├── Raft.xml
    │   ├── EscapeThePacific.xml         # Viết lại hoàn toàn ở v2.0.9610
    │   ├── GH.xml                       # Viết lại hoàn toàn ở v2.0.9610
    │   ├── SonsOfTheForest.xml          # IL2CPP — không được hỗ trợ
    │   └── {GameId}/Versions.xml        # Raft, GH, Subnautica, EscapeThePacific
    └── UserConfiguration.xml

ModAPI_Shared/
├── Configurations/
│   └── Configuration.cs                 # GetPath/GetString/GetInt với tham số silent
├── Data/
│   ├── Game.cs                          # Tự động tạo backup cho ApplyMods, resolver có điều kiện,
│   │                                    #   dự phòng về thư mục game, sửa constructor nhẹ + khởi tạo ModLib
│   └── ModLib.cs                        # Tách #if DEBUG, dự phòng về thư mục game cho IncludeAssemblies/CopyAssemblies
└── Utils/
    └── FileValidator.cs                 # Xác thực header PE + metadata CLR (chỉ Release, tối thiểu 8 KB)

BaseModLib/
├── BaseModLib.csproj                    # .NET 3.5 + LangVersion 7.3
└── libs/polyfills/
    ├── AsyncBridge.dll
    └── System.Threading.dll

VersionTool/
├── MODAPI_VersionTool.csproj            # Công cụ WPF độc lập cập nhật phiên bản
├── App.config
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / .cs               # Nhập phiên bản, nút Apply, hiển thị phiên bản hiện tại
└── Properties/
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs / .resx
    └── Settings.Designer.cs / .settings

LangTool/
├── MODAPI_LangTool.csproj               # Công cụ WPF độc lập quản lý ngôn ngữ
├── App.xaml / App.xaml.cs              # Tải/chuyển đổi ngôn ngữ, langtool.cfg
├── MainWindow.xaml / .cs               # Giao diện chính — danh sách ngôn ngữ, panel chỉnh sửa, chọn đường dẫn
├── AddLanguageDialog.xaml / .cs        # ComboBox chọn quốc gia ISO 3166-1
├── ModApiDialog.xaml / .cs             # Hộp thoại tùy chỉnh kiểu ModAPI (Info/Cảnh báo/Xác nhận/Hỏi)
├── Models/
│   ├── LanguageEntry.cs                # Model mục ngôn ngữ (isoCode, langCode, builtin, active)
│   ├── LangsJson.cs                    # Model gốc của langs.json
│   └── IsoCountry.cs                   # Model quốc gia ISO cho ComboBox
└── Helpers/
    ├── LangsJsonHelper.cs              # Đọc/ghi langs.json
    ├── FlagDownloader.cs               # Tải cờ từ flagcdn.com h24
    ├── XamlGenerator.cs                # Tạo/lưu/phân tích Language.XX.xaml
    ├── MissingKeyDetector.cs           # Phát hiện khóa bị thiếu so với bản tham chiếu tiếng Anh
    ├── IsoCountryList.cs               # Danh sách đầy đủ quốc gia ISO 3166-1 (196 quốc gia, ngoại tuyến)
    └── BuiltinCodeWriter.cs            # Viết lại CreateDefaultLangsJson() + đăng ký trong ModAPI.csproj

bin\Debug\                               # Chỉ dùng cho kiểm thử Debug
├── create_dummy_Debug_games.ps1         # Tạo cấu trúc game/Steam giả
├── dummy_games\{GameId}\               # Đường dẫn cài đặt game giả
├── dummy_steam\Steam.exe               # Tệp thực thi Steam giả
└── gamefiles\original\{GameId}\        # Đường dẫn sao lưu giả cho ModLib
```

---

</details>

<details>
<summary><b>Cài Đặt và Thiết Lập</b></summary>

### Bước 1 — Yêu Cầu Trước Khi Cài Đặt

| Mục | Yêu cầu |
|---|---|
| Windows 10 / 11 | ✅ |
| .NET Framework 4.8 | ✅ (được cài sẵn trên Windows 11; [tải xuống](https://dotnet.microsoft.com/download/dotnet-framework/net48) cho Windows 10) |
| Steam | Bắt buộc — phải được cấu hình trong tab Settings |
| Ít nhất một game được hỗ trợ | Bắt buộc — phải được cấu hình trong tab Settings |

### Bước 2 — Cài Đặt ModAPI

1. Tải xuống phiên bản mới nhất từ GitHub
2. Giải nén vào bất kỳ thư mục nào (ví dụ: `C:\ModAPI\`)
3. Chạy `ModAPI.exe`
4. Ở lần khởi động đầu tiên, màn hình **Welcome** sẽ xuất hiện — cấu hình tùy chọn và nhấp **Continue**

### Bước 3 — Cấu Hình Đường Dẫn Steam (Tab Settings)

1. Vào tab **Settings**
2. Tìm **Steam Installation Path**
3. Nhấp **Browse** → chọn `Steam.exe`
4. Nhấp **Save**

### Bước 4 — Cấu Hình Đường Dẫn Game (Tab Settings)

1. Nhấp vào tiêu đề thẻ game để mở rộng
2. Nhấp **Browse** → chọn thư mục gốc của game (nơi chứa tệp `.exe`)
3. Nhấp **Save**

| Game | Tệp thực thi | Đường dẫn ví dụ |
|---|---|---|
| The Forest | `TheForest.exe` | `C:\Steam\steamapps\common\The Forest\` |
| Subnautica | `Subnautica.exe` | `C:\Steam\steamapps\common\Subnautica\` |
| RAFT | `Raft.exe` | `C:\Steam\steamapps\common\Raft\` |
| Escape The Pacific | `EscapeThePacific.exe` | `C:\Steam\steamapps\common\Escape The Pacific\` |
| Green Hell | `GH.exe` | `C:\Steam\steamapps\common\Green Hell\` |

### Bước 5 — Tải Xuống Mod (Tab Downloads)

1. Vào tab **Downloads**
2. Chọn một game trong bộ lọc game
3. Duyệt hoặc tìm kiếm mod rồi nhấp **Download**

> **Ngoại tuyến**: tải tệp `.mod` thủ công từ `modapi.survivetheforest.net` và đặt chúng vào thư mục tương ứng:

| Game | Thư mục |
|---|---|
| The Forest | `mods/TheForest/` |
| Subnautica | `mods/Subnautica/` |
| RAFT | `mods/Raft/` |
| Escape The Pacific | `mods/EscapeThePacific/` |
| Green Hell | `mods/GH/` |

### Bước 6 — Áp Dụng Mod & Khởi Động Game (Tab Mods)

1. Vào tab **Mods**
2. Chọn một game trong **Game Filter** (Cột 0)
3. Đánh dấu các mod cần kích hoạt trong **Mod List** (Cột 1)
4. Nhấp **Start Game**

Các kiểm tra sau sẽ tự động chạy trước khi khởi động:

| # | Kiểm tra | Popup khi thất bại |
|---|---|---|
| 1 | Đường dẫn Steam đã cấu hình và hợp lệ | SteamNotFound |
| 2 | Game trong thư mục `mods/` khớp với đường dẫn game trong Settings | GameModsMismatch |
| 3 | Đã chọn ít nhất một mod | NoModSelected |
| 4 | Không có mod của các game khác nhau lẫn lộn trong lựa chọn | MixedGameMods |
| 5 | Đường dẫn game đã cấu hình và tệp thực thi tồn tại | GamePathNotSet / GameNotInstalled |

---

</details>

<details>
<summary><b>Tổng Quan Các Tab</b></summary>

### Tab Welcome
Màn hình thiết lập lần đầu (chỉ số tab 0). Cấu hình AutoUpdate, kết nối Steam và các tùy chọn bảng VersionsData. Ở những lần khởi động sau, tab này cung cấp các liên kết cộng đồng và ghi chú phát hành.

### Tab Mods
Luồng làm việc chính để quản lý mod — bố cục 3 cột:

| Cột | Nội dung |
|---|---|
| Cột 0 | Game Filter — nút radio cho 5 game được hỗ trợ |
| Cột 1 | Mod List — các mod đã cài đặt kèm bộ chọn phiên bản và checkbox kích hoạt |
| Cột 2 | Information — chi tiết, mô tả và lịch sử phiên bản của mod đã chọn |

### Tab Downloads
Duyệt và tải mod từ `modapi.survivetheforest.net`.

- **Game filter**: TheForest / DedicatedServer / VR / Subnautica / RAFT / EscapeThePacific / GH
- **Category filter**: 12 danh mục (sửa lỗi, cân bằng, gian lận, …)
- **Search**: theo tên mod, mô tả hoặc tác giả
- **Offline mode**: hiển thị hướng dẫn thư mục cho cả 5 game được hỗ trợ

### Tab Development
Luồng làm việc phát triển mod — panel bộ lọc game (Cột 0) bao phủ cả 5 game được hỗ trợ.

- Tạo, build và áp dụng dự án mod theo từng game
- Quản lý tài nguyên ngôn ngữ
- Tạo ModLib với kiểm tra 3 bước (Steam → dự án → đường dẫn game)
- Chuyển đổi game an toàn thông qua constructor `Game` nhẹ (không gọi `Verify()`)

### Tab Themes
Chọn theme và quản lý texture nền.

- **Chọn theme**: 10 theme (Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom)
- **Texture nền**: chọn hình ảnh làm nền toàn ứng dụng (nén JPEG + xử lý bảo mật)
- Khi texture nền đang hoạt động, việc chọn theme bị khóa

### Tab Settings
Cấu hình tập trung — 4 hàng:

| Hàng | Nội dung |
|---|---|
| 0 | Ngôn ngữ / Cỡ chữ / Chiều rộng tối đa / Chiều rộng Mod List / Chiều rộng Project List |
| 1 | Giữ VersionsData / Tự động cập nhật / Kết nối Steam / Luôn hiển thị trên cùng |
| 2 | Steam Installation Path (ô văn bản + Browse + Save + Reset) |
| 3 | Game Installation Paths — thẻ có thể mở rộng cho từng game (ô văn bản + Browse + Save + Reset) |

---

</details>

<details>
<summary><b>Lang Tool</b></summary>

### MODAPI_LangTool (Công Cụ Quản Lý Ngôn Ngữ)

Công cụ WPF độc lập để quản lý các tệp ngôn ngữ của ModAPI. Được thêm vào solution dưới dạng `LangTool\MODAPI_LangTool.csproj`.

**Vị trí**: `LangTool\MODAPI_LangTool.csproj`

**Các Tính Năng Chính**

| Tính năng | Mô tả |
|---|---|
| Danh sách ngôn ngữ | Hiển thị tất cả ngôn ngữ từ `langs.json` với biểu tượng trạng thái (🔒 tích hợp sẵn / 🚫 không hoạt động / ✅ đang hoạt động) |
| Thêm ngôn ngữ | Chọn quốc gia từ ComboBox ISO 3166-1 → cờ được tự động tải xuống từ `flagcdn.com/h24/{iso}.png` → `Language.XX.xaml` được tự động tạo từ mẫu tiếng Anh |
| Chỉnh sửa ngôn ngữ | `isoCode` / `langCode` bị khóa; `langName` và các khóa dịch có thể chỉnh sửa khi đang hoạt động |
| Vô hiệu hóa / Kích hoạt | Chuyển đổi cờ `active` trong `langs.json` — tệp được giữ nguyên, ẩn khỏi danh sách ModAPI |
| Update (tích hợp sẵn) | Chuyển đổi `builtin: false` → `true` — không thể hoàn tác, xác nhận 2 bước — tự động viết lại `CreateDefaultLangsJson()` trong mã nguồn và đăng ký `Language.XX.xaml` trong `ModAPI.csproj` |
| Phát hiện khóa bị thiếu | So sánh với bản tham chiếu tiếng Anh — hiển thị số khóa bị thiếu/trống và tiến độ dịch |
| Bảo vệ ngôn ngữ tích hợp sẵn | Các ngôn ngữ có `builtin: true` chỉ đọc — không thể chỉnh sửa, vô hiệu hóa hoặc cập nhật |
| Bảo vệ ngôn ngữ không hoạt động | Các ngôn ngữ có `active: false` chỉ đọc cho đến khi được kích hoạt lại |
| Giao diện ngôn ngữ | Bản thân LangTool hỗ trợ đầy đủ 13 ngôn ngữ của ModAPI — bộ chọn ngôn ngữ kèm cờ ở góc trên bên phải |
| Ghi nhớ đường dẫn | Đường dẫn gốc ModAPI đã chọn được lưu trong `langtool.cfg` — tự động tải lại ở lần khởi động tiếp theo |
| Hộp thoại tùy chỉnh | Tất cả popup đều dùng `ModApiDialog` chủ đề tối kiểu ModAPI thay vì MessageBox hệ thống |

**Cấu Trúc langs.json**

```json
{
  "languages": [
    { "isoCode": "us", "langCode": "EN",    "langName": "English",   "builtin": true,  "active": true },
    { "isoCode": "kr", "langCode": "KR",    "langName": "한국어",     "builtin": true,  "active": true },
    { "isoCode": "gb", "langCode": "EN-GB", "langName": "English (UK)", "builtin": false, "active": true }
  ]
}
```

**Quy Ước Hình Ảnh Cờ**

```
Mã ISO (chữ thường) → flagcdn.com/h24/{iso}.png → Language.{LANGCODE}.png
                                                       resources/langs/
```

**Hành Vi Của Nút Update**

Khi nhấp nút Update cho một ngôn ngữ đang hoạt động, chưa tích hợp sẵn:

1. `langs.json` — `builtin: false` → `true`
2. `LangTool\MainWindow.xaml.cs` — `CreateDefaultLangsJson()` được viết lại với tất cả ngôn ngữ hiện có `builtin: true`
3. `ModAPI\ModAPI.csproj` — `<Resource Include="resources\langs\Language.XX.xaml" />` được đăng ký
4. Bản build tiếp theo — ngôn ngữ được tích hợp hoàn toàn, khả dụng ngoại tuyến

**Các Khóa Ngôn Ngữ Được Thêm** (`Lang.LangTool.*`)

53 khóa mới được thêm vào cả 13 tệp ngôn ngữ, bao phủ toàn bộ chuỗi giao diện LangTool, thông báo hộp thoại và văn bản trạng thái.

---

</details>

<details>
<summary><b>Version Tool</b></summary>

### MODAPI_VersionTool (Công Cụ Cập Nhật Phiên Bản)

Công cụ WPF độc lập để cập nhật số phiên bản chỉ bằng một cú nhấp chuột.

**Vị trí**: `VersionTool\MODAPI_VersionTool.csproj`

<img width="331" height="220" alt="Image" src="https://github.com/user-attachments/assets/d7d40dea-129e-457d-9978-4ca149487275" />

**Tính Năng**
- Tự động hiển thị phiên bản hiện tại (đọc từ `App.xaml.cs`)
- Nhập phiên bản mới và nhấp **Apply Version** để cập nhật cả hai tệp đồng thời
- Kiểm tra định dạng: chỉ chấp nhận định dạng `X.X.XXXX`

**Các Tệp Bị Sửa Đổi**

| Tệp | Đường dẫn | Thay đổi |
|---|---|---|
| `AssemblyInfo.cs` | `ModAPI\Properties\` | `AssemblyVersion`, `AssemblyFileVersion` |
| `App.xaml.cs` | `ModAPI\` | `public static string Version` |

**Cách Sử Dụng**
1. Chạy `MODAPI_VersionTool.exe`
2. Nhập phiên bản mới (ví dụ: `2.0.9619`)
3. Nhấp **Apply Version**
4. Build lại solution ModAPI trong Visual Studio

**Hiển Thị Phiên Bản Trong StatusBar**

- `VersionLabel.Text` giờ đây tham chiếu đến `App.Version` thay vì một mô tả cố định
- Việc cập nhật phiên bản bằng VersionTool và build lại sẽ được phản ánh ngay lập tức trong StatusBar

---

</details>

<details>
<summary><b>Log</b></summary>

### Hệ Thống Ghi Log — Tách Thành Hai Tệp (`ModAPI.log` / `ModAPI.detailed.log`)

Các log chẩn đoán chỉ dành cho nhà phát triển trước đây bị giới hạn bởi `#if DEBUG`, khiến chúng vô hình trong các bản dựng Release đúng lúc chúng cần thiết nhất để xử lý sự cố của người dùng. Hệ thống hai tệp thay thế điều này:

| Tệp | Nội dung |
|---|---|
| `ModAPI.log` | Log chính hướng tới người dùng — giao diện không thay đổi, không ồn ào hơn trước đây |
| `ModAPI.detailed.log` | Mọi cuộc gọi ghi log, luôn luôn, cả ở Release lẫn Debug — dùng để chẩn đoán các vấn đề người dùng báo cáo |

**`Debug.cs`** — `Log()` có tham số `detailedOnly`. Khi giá trị này là `true`, thông báo chỉ được ghi vào `ModAPI.detailed.log`; tất cả các khối `#if DEBUG` trước đây đã được chuyển đổi sang cờ này thay vì bị loại bỏ hoàn toàn khỏi quá trình build, do đó chúng luôn được ghi lại trong tệp chi tiết ngay cả ở Release. Điều này tạo ra mô hình mức độ nghiêm trọng gồm 4 cấp:

| Cấp | Ý nghĩa |
|---|---|
| Verbose (`detailedOnly: true`) | Trace lặp lại/máy móc — theo loại, theo tệp, theo phương thức |
| Notice | Luồng dễ đọc đối với con người — thông báo tiến trình và thành công |
| Warning | Vấn đề tiềm ẩn, chưa phải là lỗi |
| Error | Lỗi đã được xác nhận |

**Các nguồn gây nhiễu log đã được xác định và chuyển đổi sang `detailedOnly: true`:**

| Tệp | Điều gì đã làm tràn ngập `ModAPI.log` |
|---|---|
| `ModsViewModel.cs` | Thông báo quét/bỏ qua/xếp hàng của `FindMods()` lặp lại mỗi lần polling 1 giây |
| `Game.cs` | Các dòng trace TLS/URL của `UpdateVersions()`, các mục ánh xạ kiểu Cecil |
| `ModLib.cs` | Xử lý assembly theo kiểu/phương thức của Cecil (`Validating`, `Processing`, `Changed ... accessibility`) — chịu trách nhiệm cho phần lớn dung lượng của `ModAPI.log` (hàng chục nghìn dòng cho một lần build mod Green Hell duy nhất) |
| `Mod.cs` | Dump toàn bộ XML header của mod (`configuration.ToString()`) được ghi lại toàn bộ mỗi khi tải mod |

**Ghi log các sai lệch checksum — được tóm tắt thay vì theo từng mục:** `Header.Verify()` trước đây ghi một dòng `Mismatched checksum at "..."` cho mỗi mục không tương thích `InjectInto`/`AddMethod`/`AddField`/`AddClass`, có thể lên đến hàng chục dòng cho một mod đã lỗi thời. Giờ đây chỉ ghi một bản tóm tắt duy nhất ở mức Warning trong `ModAPI.log` (ví dụ: `Mod "MarsarahMod" has 14 checksum mismatch(es). This usually means the mod is incompatible with the current game version. See ModAPI.detailed.log for the full list.`), trong khi bản phân tích đầy đủ theo từng mục vẫn khả dụng trong `ModAPI.detailed.log`.

---

</details>

<details open>
<summary><b>Thay Đổi Trong v2.0.9620</b></summary>

## Thay Đổi Trong v2.0.9620

### Đã Thêm MODAPI_LangTool

Đã thêm công cụ WPF độc lập để quản lý các tệp ngôn ngữ của ModAPI (`LangTool\MODAPI_LangTool.csproj`) — xem phần **Lang Tool** ở trên để biết chi tiết đầy đủ.

---

### Sửa Lỗi

| # | Tệp | Vấn đề | Cách sửa |
|---|---|---|---|
| 1 | `App.xaml.cs` | Tiếng Pháp bị lẫn vào các thông báo ngoại lệ .NET trên Windows không phải tiếng Anh | `CultureInfo.InvariantCulture` được cố định khi khởi động constructor `App()` |
| 2 | `Game.cs` | Lỗi SSL/TLS ở `UpdateVersions()` — không thể tạo kênh bảo mật SSL/TLS | TLS 1.2 được đặt rõ ràng thông qua `ServicePointManager.SecurityProtocol` |
| 3 | `MainWindow.xaml.cs` | Popup `GamePathNotSet` của Green Hell dù đường dẫn đã được cấu hình | `App.Game.GamePath` trống → đọc đường dẫn đã lưu từ `Configuration` |
| 4 | `ModsViewModel.cs` | Tệp mod không xuất hiện trong danh sách khi đặt thủ công vào `mods\TheForest\` | Đã thêm log chẩn đoán xác thực mẫu tên tệp |
| 5 | `MainWindow.xaml.cs` | Popup `MixedGameMods` chặn việc chọn mod đa game | Đã xóa popup chặn — thay bằng `SelectGameDialog` |

---

### Tính Năng Mới

#### Khởi Động Game — Popup Chọn Game (`SelectGameDialog`)

Khi các mod của các game khác nhau được chọn, hoặc khi bộ lọc **All** đang hoạt động, một popup chọn game sẽ xuất hiện thay vì chặn khởi động.

**Điều kiện kích hoạt:**
- Đã chọn bộ lọc `All` + nhấp Start Game
- Mod của 2 game khác nhau trở lên được kích hoạt đồng thời

**Hành vi:**
- Chỉ hiển thị các game có đường dẫn đã cấu hình + tệp thực thi tồn tại
- Chỉ áp dụng mod của game đã chọn — mod của các game khác bị bỏ qua hoàn toàn
- Nút radio đồng bộ với game đã chọn sau khi popup đóng lại (`SyncModGameFilterRadioButton`)

**Tệp mới**: `ModAPI\Windows\SubWindows\SelectGameDialog.xaml / .cs`

#### Xác Minh Tính Toàn Vẹn Của Game (chỉ bản dựng Release, `#if !DEBUG`)

Kiểm tra tính toàn vẹn ba lớp được chạy trước mỗi lần khởi động game:

| Lớp | Phương thức | Khi thất bại |
|---|---|---|
| A — Header PE | `FileValidator.IsValidGameExe()` | Bị chặn + popup `GameExeCorrupted` |
| B — Checksum assembly | So sánh MD5 → `Versions.xml` | Bị chặn + popup `GameAssemblyTampered` |
| C — Chữ ký số | `HasDigitalSignature()` | Cảnh báo + lựa chọn của người dùng (`GameIntegrityWarning`) |

**Tệp mới**: `ModAPI\Windows\SubWindows\GameIntegrityWarning.xaml / .cs`

**Các phương thức mới được thêm vào `FileValidator.cs`**:
- `ComputeAssemblyChecksum(managedFolder)` — hash MD5 của Assembly-CSharp.dll (+ firstpass nếu có)
- `HasDigitalSignature(path)` — kiểm tra chữ ký Authenticode

---

### Log Chẩn Đoán Mới

#### `ModAPI_Shared\Data\Game.cs` — `UpdateVersions()` (12 mục, Release + Debug)

| # | Giai đoạn | Loại | Nội dung |
|---|---|---|---|
| 1 | Thiết lập TLS | Notice | Giao thức trước/sau |
| 2 | Bắt đầu tải xuống | Notice | Danh sách máy chủ |
| 3 | Thử URL | Notice | Mỗi URL được thử |
| 4 | Tải xuống thành công | Notice | URL, độ dài phản hồi, giao thức đã dùng |
| 5 | WebException | Error | URL, trạng thái HTTP, giao thức, chi tiết |
| 6 | Ngoại lệ khác | Error | URL, loại ngoại lệ, chi tiết |
| 7 | Tải xuống hoàn tất | Notice | Số lượng thành công / tổng số máy chủ |
| 8 | Phân tích thành công | Notice | Số lượng tệp và phiên bản trước/sau |
| 9 | Phân tích thất bại | Error | Loại ngoại lệ và chi tiết |
| 10 | Lưu thành công | Notice | Đường dẫn lưu, tổng số phiên bản/tệp |
| 11 | Lưu thất bại | Error | Đường dẫn, loại ngoại lệ, chi tiết |
| 12 | Không có phản hồi | Error | Các máy chủ đã thử, giao thức |

#### `ModAPI\Data\ViewModels\ModsViewModel.cs` — `FindMods()` (7 mục, chỉ `#if DEBUG`)

| # | Tình huống | Loại | Nội dung |
|---|---|---|---|
| 1 | Bắt đầu quét | Notice | Đường dẫn thư mục mod, tổng số tệp tìm thấy |
| 2 | Đã tải trước đó | Notice | Tên tệp |
| 3 | Không phải tệp .mod | Notice | Tên tệp |
| 4 | Khớp mẫu thành công | Notice | Tên tệp được đưa vào hàng đợi |
| 5 | Khớp mẫu thất bại | Warning | Tên tệp + lý do + định dạng mong đợi |
| 6 | Quét hoàn tất | Notice | Số lượng trong hàng đợi / tổng số tệp |
| 7 | Ngoại lệ | Error | Chi tiết ngoại lệ |

#### `ModAPI\Windows\MainWindow.xaml.cs` — `StartGame()` (10 mục, Release + Debug)

| # | Tình huống | Loại | Nội dung |
|---|---|---|---|
| 1 | Điều kiện popup | Notice | Bộ lọc hiện tại, ID game đã chọn, needGameSelect |
| 2 | Game ứng viên | Notice | Danh sách ID ứng viên cho popup |
| 3 | Đường dẫn chưa được đặt | Notice | Bỏ qua game — đường dẫn chưa cấu hình |
| 4 | Không có trong Configuration | Notice | Bỏ qua game — không có trong Configuration.Games |
| 5 | Xác nhận đã cài đặt | Notice | Game + đường dẫn tệp thực thi |
| 6 | Không tìm thấy Exe | Warning | Bỏ qua game — thiếu tệp thực thi |
| 7 | Không có game nào được cài đặt | Error | 0 ứng viên → GamePathNotSet |
| 8 | Tự động chọn | Notice | Ứng viên duy nhất được tự động chọn |
| 9 | Người dùng đã hủy | Notice | SelectGameDialog đã bị hủy |
| 10 | Đã chọn game + mod | Notice | Game đã chọn, số lượng/danh sách mod đã thu thập |

---

### Tách Biệt Log Nhà Phát Triển / Người Dùng (`#if DEBUG`)

| Tệp | Log | Lý do |
|---|---|---|
| `ModsViewModel.cs` | `Scanning mods folder`, `Skip (already loaded)`, `Skip (not .mod)`, `Queued for load`, `Scan complete` | Lặp lại mỗi giây — 81% tổng dung lượng log |
| `Game.cs` | `Modified by: SiXxKilLuR`, `Checksum:`, `Type entry:`, `Backed up:`, `Added folder to resolver`, `TLS protocol set`, `Starting version file download`, `Trying URL` | Chi tiết nội bộ chỉ dành cho nhà phát triển |

Log Release vẫn giữ lại: thành công/thất bại tải xuống, kết quả phân tích/lưu, các lỗi khớp mẫu, ngoại lệ, kết quả kiểm tra tính toàn vẹn.

---

### Cập Nhật Bảng Phiên Bản — Kiến Trúc

#### Ý Định Thiết Kế

```
Game nhận bản cập nhật Steam
  → Assembly-CSharp.dll thay đổi
  → ModAPI kiểm tra Versions.xml để tìm checksum đã biết
  → Nếu không tìm thấy → tải xuống Versions.xml mới nhất từ máy chủ
  → Phiên bản mới được tự động đăng ký mà không cần cài đặt lại ModAPI
```

#### Cấu Trúc Kết Nối

```
Tab Settings → checkbox KeepVersionsData
  → Configuration.xml: "UpdateVersions" = true/false
    → Verify() → gọi UpdateVersions()
      → tải xuống Versions.xml từ VersionUpdateDomains[]
      → ghi đè configs\games\{GameId}\Versions.xml cục bộ
```

#### Tích Hợp URL Raw GitHub

Thay vì chỉ dựa vào `modapi.survivetheforest.net`, URL Raw GitHub giờ đây được dùng làm nguồn chính để quản lý trực tiếp:

```csharp
public static readonly string[] VersionUpdateDomains =
{
    // GitHub — quản lý trực tiếp, ưu tiên 1
    "https://raw.githubusercontent.com/FluffyFishGames/ModAPI/master/ModAPI/configs/games/{0}/Versions.xml",
    // Máy chủ cũ — dự phòng, ưu tiên 2
    "http://modapi.survivetheforest.net/app/configs/games/{0}/Versions.xml",
};
```

| Mục | Chi tiết |
|---|---|
| Chính | URL Raw GitHub — cập nhật ngay khi push |
| Dự phòng | Máy chủ cũ — được dùng khi GitHub không khả dụng |
| Đường dẫn | `ModAPI/configs/games/{GameId}/Versions.xml` trong repository |
| Tệp đã sửa đổi | `ModAPI_Shared\Data\Game.cs` — `VersionUpdateDomains` |

---

### Cập Nhật Versions.xml

| Game | Tệp | Thay đổi |
|---|---|---|
| Green Hell | `configs\games\GH\Versions.xml` | Đã sửa checksum (trước đó là SHA-256 sai ở dạng chữ hoa) — `2.9.5b114117` với MD5 chính xác |
| The Forest | `configs\games\TheForest\Versions.xml` | Đã thêm `1.12` (BuildID: 20229486) — checksum MD5 128 ký tự |

---

### Khóa Ngôn Ngữ Mới (13 ngôn ngữ)

| Khóa | Giá trị tiếng Anh |
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
| `Lang.Savegames.*` (133 khóa) | Đã thêm giá trị tiếng Anh cho 12 ngôn ngữ (DE đã được dịch) |

---

### Các Tệp Bị Sửa Đổi

| Tệp | Đường dẫn | Thay đổi |
|---|---|---|
| `App.xaml.cs` | `ModAPI\` | `CultureInfo.InvariantCulture` được cố định khi khởi động |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | SelectGameDialog, kiểm tra tính toàn vẹn, đã xóa MixedGameMods, đồng bộ radio, 10 log |
| `SelectGameDialog.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Mới |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Mới |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Log chẩn đoán tên tệp, tách #if DEBUG |
| `Game.cs` | `ModAPI_Shared\Data\` | TLS 1.2, 12 log UpdateVersions, URL GitHub, tách #if DEBUG |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | `ComputeAssemblyChecksum()`, `HasDigitalSignature()` |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | 10 khóa mới + 133 khóa Savegames (tổng 515, tất cả ngôn ngữ khớp nhau) |
| `GH\Versions.xml` | `ModAPI\configs\games\` | Đã sửa checksum |
| `TheForest\Versions.xml` | `ModAPI\configs\games\` | Đã thêm `1.12` |
| `LangTool\` (13 tệp) | Gốc solution | Mới |
| `ModAPI.sln` | Gốc solution | LangTool đã được đăng ký |

---

### Các Sửa Lỗi Bổ Sung và Cải Tổ Hệ Thống Ghi Log (2026-06-21)

#### Kiểm Tra StartGame — Thiết Kế Lại Hoàn Toàn

Thứ tự kiểm tra đã được sửa thành chuỗi 3 bước nghiêm ngặt, và popup chọn game giờ đây phản ánh các mod đã kích hoạt bất kể đường dẫn game có được cấu hình hay không.

| Bước | Kiểm tra | Popup khi thất bại |
|---|---|---|
| 1 | Steam đã cài đặt | SteamNotFound |
| 2 | Đường dẫn của game đã chọn được cấu hình + tệp thực thi tồn tại | GamePathNotSet |
| 3 | Ít nhất một mod được kích hoạt cho game đã chọn | NoModSelected |

- **Chọn bộ lọc All / chọn mod của nhiều game** → popup luôn liệt kê tất cả game có mod đã kích hoạt, **kể cả những game chưa cấu hình đường dẫn** — việc chọn một game chưa được cấu hình giờ đây hiển thị đúng `GamePathNotSet` thay vì âm thầm loại bỏ hoặc hiển thị lỗi sai
- **Bộ lọc một game duy nhất** → kiểm tra đường dẫn và mod chạy trực tiếp cho game đó, theo cùng thứ tự 1→2→3

#### Sửa Lỗi Nghiêm Trọng

| # | Tệp | Vấn đề | Cách sửa |
|---|---|---|---|
| 1 | `Game.cs` | `UpdateVersions()` gộp phản hồi từ **tất cả** các máy chủ thành công (GitHub + cũ), nhân đôi checksum (64 → 128 ký tự) khi cả hai đều thành công — gây ra chặn giả `GameAssemblyTampered` | Chỉ phân tích phản hồi từ máy chủ thành công đầu tiên; các máy chủ còn lại bị bỏ qua ngay khi một máy chủ thành công |
| 2 | `MainWindow.xaml.cs` | `DeleteMod_Click` dùng `App.Game` (bộ lọc đang hoạt động hiện tại) thay vì game riêng của mod — việc xóa mod Green Hell khi The Forest đang hoạt động sẽ tìm sai thư mục `Managed` và âm thầm bỏ qua việc xóa | Giờ đây giải quyết đường dẫn DLL đã triển khai từ `mod.Game` (instance game thực sự của mod), có dự phòng về `Configuration` nếu `GamePath` trống |
| 3 | `Configuration.cs` / `MainWindow.xaml.cs` | Việc tải lại một mod đã bị xóa trước đó khôi phục huy hiệu kích hoạt của nó thành đã chọn — việc xóa mod chưa bao giờ xóa các khóa `Selected`/`Version` được lưu lâu dài của nó hoặc bộ nhớ đệm ViewModel | Đã thêm `RemoveKey()` / `RemoveKeysWithPrefix()` vào `Configuration.cs`; `DeleteMod_Click` giờ đây buộc đặt `ModViewModel.Selected = false` và xóa tất cả các khóa `Mods.{GameId}.{ModId}.*` khi xóa |
| 4 | `ModsViewModel.cs` | Việc xóa mod khi đang chọn bộ lọc game cụ thể (không phải "All") khiến mod vẫn hiển thị trong danh sách cho đến khi chuyển sang "All" rồi quay lại | Thiếu thông báo thay đổi `FilteredMods` sau `_Mods.RemoveAt()` trong vòng lặp polling xóa tệp; giờ đây sẽ kích hoạt bất cứ khi nào một mod thực sự bị xóa |
| 5 | `GameIntegrityWarning.xaml.cs` / `MainWindow.xaml.cs` | Một ngoại lệ chưa được xử lý khi xây dựng hoặc hiển thị popup cảnh báo thiếu chữ ký có thể khiến ModAPI âm thầm crash mà không ghi log lỗi nào | Việc xây dựng/hiển thị popup và định dạng thông báo đã được bọc trong try-catch; khi thất bại, cảnh báo được ghi log và người dùng được phép tiếp tục an toàn (thiếu chữ ký chỉ mang tính thông báo, không phải chặn cứng) |

#### Cảnh Báo Chữ Ký Số — Thông Báo Được Làm Rõ

Văn bản `GameNoSignature` giờ đây nêu tên game cụ thể và làm rõ rằng việc thiếu chữ ký là điều bình thường đối với các tựa game indie và không ảnh hưởng đến gameplay, thay vì ngụ ý khả năng bị can thiệp. Đã cập nhật trong cả 13 tệp ngôn ngữ với placeholder `{0}` cho tên hiển thị của game (ví dụ: "The Forest", "Green Hell").

#### Hệ Thống Ghi Log — Tách Thành Hai Tệp

Các log chẩn đoán bị giới hạn bởi `#if DEBUG` đã được chuyển đổi sang cờ `detailedOnly` và tách giữa `ModAPI.log` (hướng tới người dùng) và `ModAPI.detailed.log` (luôn chi tiết đầy đủ) — xem phần **Log** ở trên để biết bản phân tích đầy đủ.

#### Các Tệp Bị Sửa Đổi (Bổ Sung)

| Tệp | Đường dẫn | Thay đổi |
|---|---|---|
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Thiết kế lại kiểm tra StartGame, sửa instance game trong DeleteMod_Click, try-catch cho GameIntegrityWarning, ánh xạ tên hiển thị |
| `Game.cs` | `ModAPI_Shared\Data\` | Sửa phản hồi đơn trong UpdateVersions |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | `RemoveKey()`, `RemoveKeysWithPrefix()` |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Thông báo thay đổi `FilteredMods` khi xóa, `#if DEBUG` → `detailedOnly` |
| `ModLib.cs` | `ModAPI_Shared\Data\` | `#if DEBUG` → `detailedOnly` (25 điểm gọi) |
| `Mod.cs` | `ModAPI\Data\` | Dump XML header được chuyển sang `detailedOnly`, tóm tắt sai lệch checksum |
| `Debug.cs` | `ModAPI_Shared\` | Tham số `detailedOnly`, ghi vào hai tệp, chú thích hướng dẫn ghi log 4 cấp |
| `GameIntegrityWarning.xaml/.cs` | `ModAPI\Windows\SubWindows\` | Placeholder `{0}` cho tên game, bảo vệ try-catch |
| 13× `Language.XX.xaml` | `ModAPI\resources\langs\` | `GameNoSignature.Text` được viết lại với placeholder tên game |

---


</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9619</b></summary>

### Sửa Lỗi

- **Áp dụng mod bị treo khi thư mục sao lưu trống**: `gamefiles\original\` trống → tự động tạo backup từ đường dẫn cài đặt game trước khi đọc assembly
- **Khóa tệp (IOException) trên các DLL của game**: resolver assembly loại trừ có điều kiện thư mục game khi có backup — ngăn Cecil giữ khóa tệp trong quá trình `DirectoryCopy`
- **Vòng lặp thử lại vô hạn cho mod bị hỏng**: các tệp `.mod` thất bại (header bị hỏng) gây ra vòng lặp quét lại mỗi giây — giờ đây được đăng ký trong `LoadedFiles` để ngăn quét lại
- **Từ chối tệp mod có kết thúc dòng LF**: bộ phân tích header `EndsWith("</Mod>\r")` thất bại đối với các tệp `.mod` kiểu Unix — giờ đây dùng `TrimEnd` để xử lý cả CRLF và LF
- **Lỗi xác thực DLL nhỏ**: `Assembly-UnityScript-firstpass.dll` (21 KB) bị `FileValidator` từ chối — kích thước tối thiểu của assembly đã được giảm từ 64 KB xuống 8 KB
- **Log WARNING không cần thiết**: các đường dẫn game chưa cấu hình và khóa cấu hình lần chạy đầu tiên tạo ra nhiễu — tham số `silent` đã được thêm vào `GetPath`/`GetString`/`GetInt`

### Cải Tiến

- **Phát hiện tải xuống 0 byte**: popup cảnh báo + dọn dẹp tệp tạm khi máy chủ trả về tệp `.mod` trống (`Lang.Windows.DownloadEmpty`)
- **Debounce lưu thanh trượt**: `ModListWidth` / `ProjectListWidth` chỉ được lưu vào `ui.cfg` một lần (500ms sau khi kéo xong) thay vì mỗi lần thay đổi pixel
- **Tạo thư mục game có điều kiện**: các thư mục `mods/` và `projects/` chỉ được tạo cho các game đã cấu hình đường dẫn — không tạo vô điều kiện cho cả 5
- **Log chẩn đoán phân tích header**: hiển thị số dòng và bản xem trước nội dung khi phân tích tệp `.mod` thất bại, giúp dễ dàng khắc phục sự cố

### Khóa Ngôn Ngữ Mới (13 ngôn ngữ)

| Khóa | Giá trị tiếng Anh |
|-----|---------------|
| `Lang.Windows.DownloadEmpty.Title` | Download Failed |
| `Lang.Windows.DownloadEmpty.Text` | The downloaded mod file is empty (0 bytes). The file may not exist on the server. |
| `Lang.Windows.DownloadEmpty.Buttons.OK` | OK |

### Các Tệp Bị Sửa Đổi

| Tệp | Đường dẫn | Thay đổi |
|---|---|---|
| `Game.cs` | `ModAPI_Shared\Data\` | Tự động tạo backup, resolver có điều kiện, dự phòng về thư mục game |
| `ModLib.cs` | `ModAPI_Shared\Data\` | Dự phòng về thư mục game cho IncludeAssemblies/CopyAssemblies |
| `FileValidator.cs` | `ModAPI_Shared\Utils\` | MinAssemblyBytes 64 KB → 8 KB |
| `Configuration.cs` | `ModAPI_Shared\Configurations\` | Tham số `silent` trên GetPath/GetString/GetInt |
| `MainWindow.xaml.cs` | `ModAPI\Windows\` | Bảo vệ khỏi tải xuống 0 byte, debounce thanh trượt, đọc cấu hình âm thầm, tạo thư mục có điều kiện |
| `ModsViewModel.cs` | `ModAPI\Data\ViewModels\` | Ngăn thử lại đối với mod bị hỏng |
| `Mod.cs` | `ModAPI\Data\` | Phân tích header LF/CRLF, log chẩn đoán |
| 13× `Language.XX.xaml` | `resources\langs\` | Khóa popup `DownloadEmpty` |

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9618</b></summary>


### Đã Thêm MODAPI_VersionTool

Đã thêm công cụ WPF độc lập để cập nhật số phiên bản chỉ bằng một cú nhấp chuột (`VersionTool\MODAPI_VersionTool.csproj`) — xem phần **Version Tool** ở trên để biết chi tiết đầy đủ.

- `VersionLabel.Text` giờ đây tham chiếu đến `App.Version` thay vì `Version.Descriptor` cố định, do đó các cập nhật được phản ánh ngay lập tức trong StatusBar sau khi build lại.

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9617</b></summary>


### Tab Settings — Đã Thêm Nút Reset Đường Dẫn

Nút **Reset** đã được thêm vào hàng đường dẫn cài đặt Steam và mỗi hàng đường dẫn cài đặt game.

**Hàng đường dẫn Steam**
```
[TextBox] [Browse] [Save] [Reset]
```

**Hàng đường dẫn game (theo từng game)**
```
[TextBox] [Browse] [Save] [Reset]
```

**Hành Vi Của Reset**
- Xóa ngay lập tức ô văn bản đường dẫn
- Lưu một cờ reset vào `ui.cfg` (`GamePathReset_{GameId}=1`, `SteamPathReset=1`)
- Ô văn bản vẫn trống sau khi khởi động lại
- Khắc phục vấn đề Configuration XML không lưu chuỗi rỗng

**Tự Động Lưu Khi Browse**
- Trước đây: cần nhấp riêng nút Save sau khi Browse
- Bây giờ: tự động lưu khi chọn tệp — được phản ánh ngay cả sau khi chuyển sang tab Mods

**Khóa Ngôn Ngữ Mới**

| Khóa | Giá trị |
|---|---|
| `Lang.Options.Labels.PathReset` | Reset |

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9616</b></summary>

### Versions.xml — Đã Thêm / Cập Nhật 4 Game

| Game | Đường dẫn tệp | BuildID | Ghi chú |
|---|---|---|---|
| Subnautica | `configs/games/Subnautica/Versions.xml` | `20241558` | Tạo mới |
| Raft | `configs/games/Raft/Versions.xml` | `22312909` | Đã cập nhật checksum |
| EscapeThePacific | `configs/games/EscapeThePacific/Versions.xml` | `19000490` | Tạo mới |
| GH | `configs/games/GH/Versions.xml` | `21698250` | Đã cập nhật checksum |

### Quy Tắc Tạo Checksum

Định dạng checksum khác nhau tùy thuộc vào việc `Assembly-CSharp-firstpass.dll` có tồn tại cho từng game hay không.

| Game | firstpass.dll | Định dạng checksum |
|---|---|---|
| GH | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối lại (64 ký tự) |
| Subnautica | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối lại (64 ký tự) |
| EscapeThePacific | ✅ Có | `firstpass MD5` + `Assembly-CSharp MD5` nối lại (64 ký tự) |
| Raft | ❌ Không có | chỉ `Assembly-CSharp MD5` (32 ký tự) |

### Quy Trình Cập Nhật Versions.xml Khi Game Cập Nhật

Thêm một mục `<version>` mới mà không xóa các mục hiện có.

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
# Game có firstpass.dll (GH, Subnautica, EscapeThePacific)
Get-FileHash "...\Assembly-CSharp-firstpass.dll" -Algorithm MD5
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
# → Nối cả hai giá trị Hash theo thứ tự (firstpass trước)

# Game không có firstpass.dll (Raft)
Get-FileHash "...\Assembly-CSharp.dll" -Algorithm MD5
```

**Bước 3 — Thêm mục vào Versions.xml**
```xml
<version id="{new BuildID}">
    <checksum>{new checksum}</checksum>
</version>
```

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9615</b></summary>

### Đã Sửa Việc Mở Rộng Đường Dẫn Game Trong Tab Settings

- **Chiều cao mở rộng thẻ**: phần dưới cùng của cửa sổ giờ đây tăng chính xác bằng chiều cao của trường nhập liệu khi mở rộng thẻ đường dẫn game
- **Cải tiến `UpdateWindowHeight()`**: gọi `UpdateLayout()` trước khi đo `SizeToContent.Height`; tạm thời đặt `TextureLayer1` thành `Collapsed` khi texture nền đang hoạt động, để ngăn kích thước gốc của hình ảnh 4K ảnh hưởng đến việc tính toán chiều cao
- **Sửa hàng Grid nội bộ**: hàng cuối cùng của Grid nội bộ trong panel đường dẫn game đã được đổi từ `Height="*"` thành `Height="Auto"` — loại bỏ khoảng trống không cần thiết ở phía dưới

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9614</b></summary>

### Đã Sửa Hành Vi Của Nút Phóng To

- **Phóng to**: sử dụng `SystemParameters.WorkArea` cho việc phóng to thủ công thay vì `WindowState.Maximized` — khớp chính xác với độ phân giải màn hình hiện tại mà không đè lên thanh tác vụ
- **Khôi phục**: lưu `Left`, `Top`, `Width`, `Height` và `MaxWidth` trước khi phóng to và khôi phục chúng khi nhấp nút khôi phục
- **Xử lý `MaxWidth`**: được đặt thành `∞` khi phóng to, khôi phục về giá trị đã lưu khi trở về bình thường

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9613</b></summary>

### Tab Themes Mới

Thứ tự các tab giờ đây là:

```
Welcome → Mods → Downloads → Development → Themes → Settings
```

Giao diện chọn theme đã được chuyển từ tab Settings sang tab **Themes** riêng biệt.
Biểu tượng: Segoe MDL2 Assets `&#xE790;` (bảng màu)

### Theme Registry (Cấu Trúc Dựa Trên Dữ Liệu)

Việc thêm theme mới giờ đây chỉ cần **một dòng** trong dictionary `App.xaml.cs`.
Tất cả các câu lệnh switch đã được loại bỏ — không cần thay đổi mã ở bất kỳ đâu khác.

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

Các mục ComboBox của `ThemeSelector` được tự động tạo từ vòng lặp `ThemeIds`.
Quy ước khóa ngôn ngữ: `Lang.Options.Theme.{PascalCase}` (ví dụ: `Lang.Options.Theme.Nebula`)

### Các Theme Được Hỗ Trợ

| Chỉ số | ID | Tệp | Bảng màu |
|---|---|---|---|
| 0 | `classic` | chỉ `Dictionary.xaml` | Nền texture gốc của ModAPI |
| 1 | `light` | `FluentStylesLight.xaml` | Tông sáng + điểm nhấn xanh dương |
| 2 | `dark` | `FluentStyles.xaml` | Tông tối + điểm nhấn xanh dương (mặc định) |
| 3 | `diablo` | `FluentStylesDiablo.xaml` | Đỏ + đen |
| 4 | `nebula` | `FluentStylesNebula.xaml` | Không gian tối |
| 5 | `sunset` | `FluentStylesSunset.xaml` | Hoàng hôn tươi sáng |
| 6 | `ocean` | `FluentStylesOcean.xaml` | Đại dương tối |
| 7 | `nordic` | `FluentStylesNordic.xaml` | Phong cách Bắc Âu tươi sáng |
| 8 | `citrus` | `FluentStylesCitrus.xaml` | Cam quýt tươi sáng |
| 9 | `bloom` | `FluentStylesBloom.xaml` | Hoa nở tươi sáng |

Việc đổi theme sẽ khởi động lại ứng dụng tự động. (được lưu trong `theme.cfg`)

### Tính Năng Texture Nền

Chọn một hình ảnh trong thẻ **Background Texture** trên tab Themes để áp dụng làm nền cho toàn bộ ứng dụng. Hoạt động với bất kỳ theme nào đã chọn.

**Định dạng đầu vào được hỗ trợ**: `.png` / `.jpg` / `.jpeg`, tối đa 50MB, độ phân giải 4K trở xuống

**Pipeline Xử Lý Hình Ảnh**

```
Hình ảnh do người dùng chọn (.png / .jpg / .jpeg, tối đa 50MB, 4K trở xuống)
  ↓
Nén JPEG Q75 (bộ đệm bộ nhớ)
  ↓
Chèn header ma thuật 16 byte
  "MODAPI" + "BG" + phiên bản + đệm (FF 00 FE 00)
  ↓
Lưu dưới dạng resources\textures\ui_bg\bg.dat (thuộc tính Hidden)
  ↓
Hash SHA-256 → lưu trong ui.cfg dưới dạng TextureHash
```

**Các Lớp Bảo Mật**

| Lớp | Phương thức | Hiệu ứng |
|---|---|---|
| Header ma thuật | 16 byte được thêm vào trước chữ ký JPEG (FF D8 FF) | Trình xem bên ngoài không thể nhận diện tệp |
| Thuộc tính Hidden | `FileAttributes.Hidden` | Ẩn khỏi Explorer theo mặc định |
| Tính toàn vẹn SHA-256 | Hash được xác minh khi tải | Việc can thiệp kích hoạt reset tự động + popup cảnh báo |

**Hành Vi Phát Hiện Can Thiệp**
1. `bg.dat` bị xóa
2. Các khóa `ui.cfg` `TexturePath`, `TextureHash`, `TextureActive` được reset
3. Ô văn bản và công tắc được reset
4. Popup `Lang.Windows.TextureTampered` được hiển thị

**Các Khóa ui.cfg**

| Khóa | Giá trị | Mô tả |
|---|---|---|
| `TexturePath` | Tên tệp (chỉ hiển thị) | Tên tệp gốc được hiển thị trong ô văn bản |
| `TextureHash` | Chuỗi hex SHA-256 | Hash xác minh tính toàn vẹn |
| `TextureActive` | `true` / `false` | Trạng thái kích hoạt |

**Xử Lý Độ Trong Suốt**

Khi hình ảnh nền đang hoạt động, các nền giao diện được xử lý theo hai lớp.

- **Lớp 1 — Lớp phủ MergedDictionaries**: các panel tham chiếu đến `{DynamicResource FluentBgBrush}` v.v. tự động trở nên trong suốt. Được khôi phục bằng một lệnh gọi `Remove()` duy nhất khi tắt.

  Các khóa mục tiêu: `FluentBgBrush`, `FluentBgSecondaryBrush`, `FluentBgTertiaryBrush`, `FluentSurfaceBrush`, `FluentCardBrush`, `FluentTabBarBrush`, `FluentBorderBrush`

- **Lớp 2 — Duyệt cây trực quan (`WalkStyleBackgrounds`)**: các phần tử `{StaticResource}` trong các theme Fluent không bị ảnh hưởng bởi Lớp 1, vì vậy cây trực quan được duyệt trực tiếp để áp dụng cọ vẽ trong suốt một phần dựa trên màu gốc.

  ```
  MakeSemiTransparent(originalBrush, alpha: 100)
  // alpha 0=hoàn toàn trong suốt, 255=không trong suốt → 100 ≈ 39% không trong suốt
  ```

  Được xử lý: `Panel` (trừ Grid), `Border`, `ListBox` / `ListView`

  Loại trừ: `Grid` (giữ nguyên nền, các phần tử con được duyệt), `TabPanel` (bảo vệ header tab), `ButtonBase` / `ComboBox`, các phần tử `Collapsed`

  Khôi phục: nguồn Setter của style → `ClearValue()`, nguồn giá trị cục bộ XAML → khôi phục trực tiếp cọ vẽ gốc

**Chuyển Đổi Tab**

Vì TabControl của WPF tải nội dung tab theo kiểu lazy, `WalkStyleBackgrounds(this)` được chạy lại với mức ưu tiên `ContextIdle` khi chuyển tab. Các phần tử đã được xử lý sẽ được bỏ qua thông qua kiểm tra `ContainsKey`.

**Khóa ThemeSelector**

Khi texture nền đang hoạt động, một viền `ThemeSelectorOverlay` sẽ được hiển thị trên bộ chọn theme để chặn tương tác.

- XAML: viền `ThemeSelectorOverlay` được thêm phía trên ThemeSelector (`IsHitTestVisible=True`)
- Đang hoạt động: `ThemeSelectorOverlay.Visibility = Visible`
- Không hoạt động: `ThemeSelectorOverlay.Visibility = Collapsed`
- `ThemeSelector_SelectionChanged` cũng được bảo vệ bởi cờ `_textureActive`

**Luồng Trạng Thái Giao Diện**

```
Đã chọn hình ảnh (Browse)
  → bg.dat được tạo → công tắc được mở khóa → tự động kích hoạt → TextureLayer1 hiển thị
  → SaveAndClearBrushes() → ThemeSelectorOverlay hiển thị

Công tắc bị tắt
  → RestoreThemeState() → RestoreBrushes() → ThemeSelectorOverlay ẩn
  → TextureLayer1 ẩn

Nút Clear
  → bg.dat bị xóa → công tắc bị khóa → TextureLayer1 ẩn → cọ vẽ được khôi phục
  → GC.Collect() (giải phóng bộ nhớ hình ảnh 4K)
```

**Khóa Ngôn Ngữ Mới**

| Khóa | Mô tả |
|---|---|
| `Lang.Options.Theme.Diablo` ~ `Lang.Options.Theme.Bloom` | 7 tên theme mới |
| `Lang.Options.Labels.TextureBackground` | Nhãn texture nền |
| `Lang.Options.Labels.TextureEnable` | Nhãn kích hoạt |
| `Lang.Options.Labels.TextureClear` | Nút Clear |
| `Lang.Windows.TextureTooLarge` | Cảnh báo vượt quá kích thước tệp |
| `Lang.Windows.TextureTampered` | Cảnh báo phát hiện can thiệp |

**Cấu Trúc Tệp**

```
ModAPI\
├── App.xaml.cs                    # ThemeRegistry, ThemeIds, ApplyTheme()
├── Windows\
│   ├── MainWindow.xaml            # Tab Themes, ThemeSelectorOverlay, TextureLayer1
│   └── MainWindow.xaml.cs         # Logic theme & texture
├── Themes\
│   ├── Dictionary.xaml            # Theme Classic
│   ├── FluentStyles.xaml          # Theme Dark
│   ├── FluentStylesLight.xaml     # Theme Light
│   ├── FluentStylesDiablo.xaml    # Theme Diablo
│   ├── FluentStylesNebula.xaml    # Theme Nebula
│   ├── FluentStylesSunset.xaml    # Theme Sunset
│   ├── FluentStylesOcean.xaml     # Theme Ocean
│   ├── FluentStylesNordic.xaml    # Theme Nordic
│   ├── FluentStylesCitrus.xaml    # Theme Citrus
│   └── FluentStylesBloom.xaml     # Theme Bloom
└── resources\
    └── textures\
        └── ui_bg\
            └── bg.dat             # Hình ảnh nền đã nén và bảo mật (được tạo lúc chạy)
```

**Các Ràng Buộc Thiết Kế Đã Biết**

| Mục | Chi tiết |
|---|---|
| `IsEnabled=false` trên ComboBox | Gây crash `ElementNotEnabledException` → sử dụng phương pháp lớp phủ `IsHitTestVisible` |
| Thay thế trực tiếp các khóa `MergedDictionaries` | Crash trong quá trình layout → chỉ dùng mẫu `Add`/`Remove` |
| Ghi đè tệp ẩn | `Access Denied` → phải reset `FileAttributes.Normal` trước khi ghi |
| Nền `{StaticResource}` | Không bị ảnh hưởng bởi Lớp 1 → cần WalkStyleBackgrounds (Lớp 2) |

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9612</b></summary>

### Tách Biệt Module Theme

- **Thư mục mới `Themes/`**: `Dictionary.xaml`, `FluentStyles.xaml`, `FluentStylesLight.xaml` và `FluentStylesClassic.xaml` đã được chuyển sang `ModAPI\Themes\`
- **`App.xaml.cs`**: `ApplyTheme()` — theme Classic chỉ dùng `Dictionary.xaml`; các theme Light/Dark/Fluent khác tải XAML tương ứng
- **`ModAPI.csproj`**: đã cập nhật đường dẫn XAML theme sang thư mục con `Themes\`; đã đăng ký `FluentStylesClassic.xaml`

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9611</b></summary>

### Sửa Lỗi

- **Chiều rộng Mod List không được áp dụng sau khi đổi theme**: đã sửa vấn đề chiều rộng danh sách mod không được áp dụng sau khi chuyển đổi giữa theme Light/Dark và khởi động lại — đã thêm lệnh gọi `ApplyModListWidth(width)` bên trong `InitModListWidth()`

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9610</b></summary>

### Đã Thêm

#### XML Game và Cấu Hình Versions

| # | Tệp | Thay đổi |
|---|------|--------|
| 1 | `GH.xml` | Viết lại hoàn toàn — đã xóa `DOTweenPro.dll` không tồn tại; đã thêm `AmplifyBloom/Color/Motion.dll`, `com.rlabrecque.steamworks.net.dll`, `Unity.ProBuilder.dll`, `Unity.Postprocessing.Runtime.dll` |
| 2 | `Subnautica.xml` | Viết lại hoàn toàn — đã xóa `extends="GenericUnityGame"`; đã thêm `XGamingRuntime.dll`, `XblPCSandbox.dll`, `FMODUnity.dll`, `Newtonsoft.Json.dll`, `Unity.InputSystem.dll`, `Unity.Collections.dll`, `Unity.Burst.dll` |
| 3 | `EscapeThePacific.xml` | Viết lại hoàn toàn — đã xóa `extends="GenericUnityGame"`; `includeAssembly` → chỉ `Assembly-CSharp.dll` |
| 4 | `Raft/Versions.xml` | Đã tạo — phiên bản `1.1.01` kèm checksum |
| 5 | `GH/Versions.xml` | Đã tạo — phiên bản `2.9.5` kèm checksum |
| 6 | `Subnautica/Versions.xml` | Đã tạo — không có checksum (cập nhật quá thường xuyên) |

#### Sửa Lỗi Nghiêm Trọng

| # | Loại | Vấn đề | Cách sửa |
|---|------|-------|-----|
| 1 | Treo | `extends="GenericUnityGame"` gây kế thừa `Assembly-CSharp-firstpass.dll` → `CreateModLibrary` bị treo | Đã xóa `extends` khỏi tất cả XML không phải TheForest |
| 2 | Crash | `ResolutionException: XGamingRuntime.XUserGamertagComponent` trong khi áp dụng cho Subnautica | Đã thêm `XGamingRuntime.dll`, `XblPCSandbox.dll` vào `copyAssembly` |
| 3 | Crash | Resolver thất bại trên các DLL được thêm vào `copyAssembly` sau khi tạo backup | `Game.cs`: đã thêm thư mục cài đặt thực tế làm dự phòng của resolver |
| 4 | Crash | `IOException`: khóa tệp `BaseModLib.dll` giữa `CreateModLibrary` và `ApplyMods` | Vòng lặp thử lại: tối đa 10 × 500ms đọc + tối đa 30 × 500ms chờ tồn tại |
| 5 | Crash | `NullReferenceException` — entry.Value của `typesMap` rỗng (game chưa cài đặt) | Đã thêm `if (entry.Value == null) continue` |
| 6 | Crash | `NullReferenceException` — constructor nhẹ `Game` thiếu `ModLibrary = new ModLib(this)` → crash `CreateModLibrary()` | Đã thêm `ModLibrary = new ModLib(this)` vào constructor nhẹ |
| 7 | Crash | `SwitchDevGame()` — `App.Game.GamePath` trống sau constructor nhẹ → crash `CreateModLibrary` | Đã đặt `App.Game.GamePath = savedPath` sau constructor nhẹ |
| 8 | Sai game | Mod `EscapeThePacific` bị phân loại là TheForest | `ModsViewModel`: `GameId` được trích xuất từ đường dẫn thư mục |
| 9 | Sai đường dẫn | `GetGameFolder()` → `""` → được giải quyết thành gốc ổ đĩa (ví dụ: `E:\`) | Bảo vệ null/rỗng ở cả 6 điểm gọi |

#### Tách Biệt Bản Dựng Debug / Release

- **`FileValidator.cs`** — tệp mới `ModAPI_Shared\Utils\FileValidator.cs`; đã đăng ký trong `ModAPI_Shared.csproj`
  - `IsValidSteamExe()` — header PE (MZ + PE\0\0) + tối thiểu 1 MB
  - `IsValidGameExe()` — header PE + tối thiểu 512 KB
  - `IsValidAssemblyDll()` — header PE + header metadata .NET CLR + tối thiểu 64 KB
- **`CheckSteam()`** — `#if DEBUG`: chỉ `File.Exists()` / `#else`: `FileValidator.IsValidSteamExe()`
- **`CheckGamePath()`** — `#if DEBUG`: chỉ `File.Exists()` / `#else`: `FileValidator.IsValidAssemblyDll()`
- **`ModLib.Create()` IncludeAssemblies** — `#if DEBUG`: `File.Copy()` bỏ qua Cecil / `#else`: phân tích Cecil đầy đủ + sửa đổi IL
- **`ModLib.Create()` không tìm thấy tệp** — `#if DEBUG`: ghi log cảnh báo, bỏ qua / `#else`: ghi log lỗi, dừng lại

#### Kiểm Thử Debug

- **`create_dummy_Debug_games.ps1`** — script PowerShell dành cho `bin\Debug\`; tạo các tệp giữ chỗ 0 byte cho cả 5 game trong `dummy_games\`, `dummy_steam\` và `gamefiles\original\` — cho phép kiểm thử toàn bộ luồng làm việc giao diện mà không cần cài đặt game thật

#### Tab Settings

- **Thẻ đường dẫn Steam** — được tích hợp vào thẻ Game Installation Paths; `InitSteamPath()`, `SteamBrowse_Click()`, `SteamSave_Click()`
- **Panel đường dẫn game** — `BuildGamePathsPanel()` với các thẻ có thể mở rộng theo từng game; ô văn bản dùng `HorizontalAlignment=Stretch`
- Nút **Expand All / Collapse All**
- Checkbox **AlwaysOnTop** (được lưu vào `ui.cfg`)
- Thanh trượt **Mod/Project List Width** — bắt đầu từ mức tối thiểu `150`; được lưu vào `ui.cfg`
- ComboBox **Font Size** — FHD 10–16, 4K 10–22, 8K 10–28
- **Đồng bộ checkbox** — `SettingsCheckboxes.DataContext = SettingsVm`; AutoUpdate / UseSteam / UpdateVersions giờ đây đồng bộ chính xác
- **Cờ `_uiInitialized`** — ngăn việc ghi `ui.cfg` quá sớm trong quá trình khởi động WPF

#### Tab Mods — Kiểm Tra Khi Khởi Động Game

Kiểm tra 5 bước chạy mỗi khi nhấp Start Game, bất kể trạng thái danh sách mod:

| Bước | Kiểm tra | Popup |
|---|---|---|
| 1 | Đường dẫn Steam trong tab Settings hợp lệ (`Steam.exe` tồn tại) | SteamNotFound |
| 2 | Game trong thư mục `mods/{GameId}/` khớp với game đã cấu hình trong Settings | GameModsMismatch |
| 3 | Đã chọn ít nhất một mod | NoModSelected |
| 4 | Không có mod của các game khác nhau lẫn lộn trong lựa chọn | MixedGameMods |
| 5 | Đường dẫn game đã cấu hình + tệp thực thi tồn tại | GamePathNotSet / GameNotInstalled |

#### Tab Development — Kiểm Tra ModLib

Kiểm tra 3 bước khi nhấp Mod Library Regeneration:

| Bước | Kiểm tra | Popup |
|---|---|---|
| 1 | Đường dẫn Steam trong tab Settings hợp lệ | SteamNotFound |
| 2 | Tồn tại ít nhất một dự án | NoProjectWarning |
| 3 | `App.Game.GamePath` đã được đặt | GamePathNotSet |

#### Tab Downloads
- Đã thay chuỗi debug bằng `Lang.Downloads.Status.NoDownloads`
- Padding nhất quán cho tất cả thông báo trạng thái
- Đã cập nhật văn bản hướng dẫn ngoại tuyến cho cả 5 game được hỗ trợ; ngắt dòng thông qua hai TextBlock

#### First Setup & Hệ Thống Đường Dẫn Game
- `FirstSetup.Check()` — giá trị mặc định `true` cho `UseSteam`, `AutoUpdate`, `UpdateVersions`
- `FirstSetupDone()` — tạo các thư mục `mods/` và `projects/` cho cả 5 game
- `SpecifyGamePath` — `GameNameLabel` hiển thị là game nào; `NavigateToSettings()` chuyển hướng đến tab Settings

#### Khóa Ngôn Ngữ Mới/Đã Cập Nhật

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
| Tự động cập nhật (giữ phiên bản mới nhất) | Hạ tầng phía máy chủ chưa khả dụng |
| Tìm kiếm bản cập nhật | Hạ tầng phía máy chủ chưa khả dụng |

### Đã Loại Bỏ

| Mục | Lý do |
|---|---|
| Popup `SpecifyGamePath` khi khởi động | Tất cả đường dẫn đều được cấu hình trong tab Settings |
| Popup `SpecifySteamPath` khi khởi động | Đường dẫn Steam được cấu hình trong tab Settings |
| Hệ thống đăng nhập | Máy chủ gốc không còn hoạt động (đã loại bỏ ở v2.0.9400) |
| `Portable.System.ValueTuple.dll` | Không hoạt động trên Mono 2.0 (đã loại bỏ ở v2.0.9586) |
| Điều kiện `UseSteam` trong kiểm tra Steam | Steam giờ đây luôn được xác thực đầu tiên khi Start Game và Mod Library Regeneration |

## Dự Kiến Cho Các Phiên Bản Trong Tương Lai

| # | Tính năng | Mô tả |
|---|---|---|
| 1 | Tự động cập nhật ModAPI | Tự động tải xuống và áp dụng các bản phát hành ModAPI mới |
| 2 | Cập nhật bảng VersionsData của ModAPI | Tự động cập nhật bảng VersionsData của game khi có bản vá game mới được phát hành |

---

</details>

<details>
<summary><b>Thay Đổi Trong v2.0.9600</b></summary>

### Đã Thêm

- **Tab Downloads**: 5 bộ lọc game (TheForest, Subnautica, RAFT, EscapeThePacific, GH)
- **Tab Welcome**: được thêm vào vị trí ngoài cùng bên trái (chỉ số 0)
- **Tab Mods**: bố cục 3 cột (WrapPanel → danh sách dọc); tự động điều chỉnh chiều rộng; ngắt dòng tên mod
- **`ModsViewModel`**: lọc theo từng game cụ thể, `ResolveGame()` cho instance `Game` chính xác theo từng mod
- **`Game.cs`**: constructor nhẹ `new Game(config, true)` — chỉ để nhận diện, không có `Verify()`
- **Build**: 4 tệp XML game được đăng ký trong `ModAPI.csproj` với `CopyToOutputDirectory=Always`
- **Build**: đã dọn dẹp cảnh báo — CS0168, CS0618, CS0252
- **XML game**: đã sửa danh sách DLL cho TheForest, Raft, GH
- **Cờ ngôn ngữ**: đã chuẩn hóa kích thước hình ảnh trên cả 13 huy hiệu ngôn ngữ

### Đã Loại Bỏ

| Mục | Lý do |
|---|---|
| `extends="GenericUnityGame"` trong các tệp XML game | Gây kế thừa sai `Assembly-CSharp-firstpass.dll` — đã loại bỏ khỏi Subnautica, Raft, EscapeThePacific, GH |
| Bố cục `WrapPanel` trong tab Mods | Được thay thế bằng bố cục Grid 3 cột (Game Filter / Mod List / Information) |

---

</details>

---

## Lịch Sử Phiên Bản

<details>
<summary><b>Giai Đoạn 6-3 — Mở Rộng Hệ Thống Theme, Cải Tiến Cài Đặt, Ổn Định và Công Cụ</b></summary>

### v2.0.9620 — 2026-06-21

**MODAPI_LangTool và các sửa lỗi cốt lõi**
- Đã thêm MODAPI_LangTool (công cụ WPF độc lập quản lý ngôn ngữ)
- Sửa SSL/TLS (TLS 1.2)
- Sửa lỗi ngôn ngữ tiếng Pháp (`CultureInfo.InvariantCulture`)
- Sửa lỗi `GamePathNotSet` của Green Hell
- SelectGameDialog (bộ lọc All + khởi động mod nhiều game)
- Đã xóa chặn của MixedGameMods
- Kiểm tra tính toàn vẹn game 3 lớp (header PE / checksum assembly / chữ ký số)
- Tách biệt log nhà phát triển và người dùng
- 12 log UpdateVersions + 7 log FindMods + 10 log StartGame
- URL Raw GitHub làm `VersionUpdateDomains` chính
- Đã sửa checksum `Versions.xml` của GH
- Đã thêm `1.12` vào `Versions.xml` của TheForest
- 515 khóa trong cả 13 tệp ngôn ngữ

**Sửa lỗi bổ sung (2026-06-21)**
- Đã sửa thứ tự kiểm tra StartGame (Steam → đường dẫn game → mod)
- Popup chọn game giờ đây liệt kê đúng các game có đường dẫn chưa cấu hình
- Đã sửa phản hồi đơn trong UpdateVersions (không còn checksum bị nhân đôi)
- `DeleteMod` giờ đây giải quyết instance game riêng của mod thay vì bộ lọc đang hoạt động
- Các mod đã xóa không còn để lại huy hiệu "Selected" lỗi thời khi tải lại
- Danh sách mod giờ đây cập nhật ngay lập tức khi xóa, ở bất kỳ bộ lọc game nào
- Popup `GameIntegrityWarning` được củng cố chống lại các crash do ngoại lệ chưa xử lý
- Thông báo cảnh báo chữ ký số giờ đây nêu tên game và làm rõ rằng đây là điều bình thường đối với các tựa game indie
- Hệ thống ghi log hai tệp (`ModAPI.log` / `ModAPI.detailed.log`) thay thế các log bị giới hạn bởi `#if DEBUG`, để bản dựng Release vẫn có thể ghi lại đầy đủ chi tiết chẩn đoán mà không làm rối log hướng tới người dùng

### v2.0.9619 — 2026-05-25

- Tự động tạo backup từ đường dẫn cài đặt game
- Đã sửa khóa tệp (resolver có điều kiện)
- Ngăn vòng lặp vô hạn cho mod bị hỏng
- Tương thích với mod có kết thúc dòng LF
- Phát hiện tải xuống 0 byte kèm popup
- Debounce lưu thanh trượt (500ms)
- Tạo thư mục game có điều kiện
- Kích thước tối thiểu của assembly trong `FileValidator` được giảm từ 64 KB xuống 8 KB
- Tham số `silent` trên `GetPath`/`GetString`/`GetInt`
- Log chẩn đoán phân tích header
- Khóa ngôn ngữ `DownloadEmpty` (13 ngôn ngữ)

### v2.0.9618 — 2026-04-25
Đã thêm MODAPI_VersionTool (công cụ WPF độc lập cập nhật phiên bản), hiển thị phiên bản trong StatusBar được liên kết với App.Version

### v2.0.9617 — 2026-04-24
Đã thêm các nút reset đường dẫn Steam/game trong tab Settings, tự động lưu khi Browse, trạng thái reset được lưu giữ thông qua cờ ui.cfg

### v2.0.9616 — 2026-04-18
Versions.xml đã được tạo/cập nhật cho 4 game (Subnautica, Raft, EscapeThePacific, GH), đã thiết lập quy tắc tạo checksum, đã tài liệu hóa quy trình cập nhật game

### v2.0.9615 — 2026-04-18
Đã sửa độ chính xác của chiều cao mở rộng thẻ đường dẫn game trong tab Settings, đã ngăn UpdateWindowHeight bị ảnh hưởng bởi texture nền

### v2.0.9614 — 2026-04-18
Phóng to thủ công của nút Phóng to dựa trên WorkArea, lưu và khôi phục kích thước/vị trí trước đó

### v2.0.9613 — 2026-04-18
Đã thêm tab Themes, cấu trúc theme registry dựa trên dữ liệu, hỗ trợ 10 theme, tính năng texture nền (nén, bảo mật, độ trong suốt 2 lớp), lớp phủ khóa ThemeSelector, 12 khóa ngôn ngữ mới

### v2.0.9612 — 2026-04-18
Tách biệt thư mục Themes/, module hóa XAML theme

### v2.0.9611 — 2026-04-18
Đã sửa: chiều rộng Mod List không được áp dụng sau khi đổi theme

</details>

<details>
<summary><b>Giai Đoạn 6-2 — Cài Đặt, Bảo Mật, Sửa Lỗi Crash và Tách Biệt Debug/Release</b></summary>

### v2.0.9610 — 2026-04-13

- Đã sửa XML đa game (GH, Subnautica, EscapeThePacific)
- Đã thêm `Versions.xml`
- Đã thiết kế lại tab Settings (đường dẫn Steam, panel đường dẫn game, thanh trượt chiều rộng, cỡ chữ, đồng bộ checkbox)
- Bảo vệ null cho đường dẫn game (6 điểm)
- Đã thay thế popup khởi động bằng tab Settings
- Kiểm tra 5 bước khi khởi động game trong tab Mods (Steam luôn được kiểm tra đầu tiên)
- Kiểm tra ModLib 3 bước trong tab Dev
- Đã thêm popup `GameModsMismatch`
- Đã sửa lỗi null của `ModLibrary` trong constructor nhẹ
- Đã sửa `GamePath` trong `SwitchDevGame`
- Xác minh header PE của `FileValidator` (Release)
- Tách biệt bản dựng `#if DEBUG` (`CheckSteam` / `CheckGamePath` / `ModLib.Create`)
- `create_dummy_Debug_games.ps1`
- `ui.cfg` được lưu lâu dài
- Hệ thống cỡ chữ 5 khóa
- Nhiều bản sửa lỗi crash
- Đã cập nhật khóa ngôn ngữ

</details>

<details>
<summary><b>Giai Đoạn 6-1 — Đa Game và Thiết Kế Lại Mod</b></summary>

### v2.0.9600 — 2026-04-09
> 5 bộ lọc game, bố cục 3 cột của tab Mods, tự động điều chỉnh chiều rộng, constructor `Game` nhẹ, lọc game trong `ModsViewModel`, 4 tệp XML đã đăng ký, đã dọn dẹp cảnh báo build, tab Welcome, đã chuẩn hóa cờ ngôn ngữ

</details>

<details>
<summary><b>Giai Đoạn 5-6B — C# 7.3 và Polyfill</b></summary>

### v2.0.9586 — 2026-03-31
> Đã sửa màn hình đen, đã hoàn thiện polyfill, đã loại bỏ ValueTuple, đã xác minh C# 7.3

</details>

<details>
<summary><b>Giai Đoạn 5-5 — Giải Quyết Assembly</b></summary>

### v2.0.9561 — 2026-03-06
> Hỗ trợ C# 7.3, vá header PE, pipeline polyfill, đã khôi phục việc giải quyết assembly

</details>

<details>
<summary><b>Giai Đoạn 5-1 — Tab Downloads và 13 Ngôn Ngữ</b></summary>

### v2.0.9552 — 2026-02-25
> Tab Downloads, hiện đại hóa biểu tượng, thống nhất theme, hỗ trợ 13 ngôn ngữ

</details>

<details>
<summary><b>Các Giai Đoạn Trước</b></summary>

### Giai Đoạn 3 — Thiết Kế Lại Giao Diện và Hệ Thống Theme
v2.0.9500
> Hệ thống theme (Classic/Light/Dark), giao diện Fluent Design, hệ thống SubWindow

### Giai Đoạn 4 — Dọn Dẹp Mã Nguồn
v2.0.9400
> Dọn dẹp mã nguồn, loại bỏ đăng nhập, hiện đại hóa mã cũ

### Giai Đoạn 2 — Môi Trường Build và Fluent Design
v2.0.9300
> Môi trường build, DLL stub UnityEngine, tích hợp ModernWpf

### Giai Đoạn 1 — Di Chuyển Sang .NET 4.8
v2.0.9200
> Di chuyển sang .NET Framework 4.8

### v1.x
Bản phát hành gốc của FluffyFish

</details>

---

## Yêu Cầu Build

| Yêu cầu | Phiên bản | Ghi chú |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Các dự án ModAPI |
| .NET Framework SDK | 3.5 | Chỉ BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` trong `libs/polyfills/` |

---

## Giấy Phép

GNU General Public License v3.0 — tuân theo giấy phép gốc.
