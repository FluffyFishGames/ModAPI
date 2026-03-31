[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../../README.md)
[![한국어](https://img.shields.io/badge/한국어-🇰🇷-red)](../ko/README.md)
[![Deutsch](https://img.shields.io/badge/Deutsch-🇩🇪-black)](../de/README.md)
[![Español](https://img.shields.io/badge/Español-🇪🇸-yellow)](../es/README.md)
[![Français](https://img.shields.io/badge/Français-🇫🇷-blue)](../fr/README.md)
[![Polski](https://img.shields.io/badge/Polski-🇵🇱-red)](../pl/README.md)
[![Русский](https://img.shields.io/badge/Русский-🇷🇺-blue)](../ru/README.md)
[![Italiano](https://img.shields.io/badge/Italiano-🇮🇹-green)](../it/README.md)
[![日本語](https://img.shields.io/badge/日本語-🇯🇵-red)](../jp/README.md)
[![Português](https://img.shields.io/badge/Português-🇵🇹-green)](../pt/README.md)
[![Tiếng Việt](https://img.shields.io/badge/Tiếng%20Việt-🇻🇳-green)](README.md)
[![简体中文](https://img.shields.io/badge/简体中文-🇨🇳-red)](../zh-CN/README.md)
[![繁體中文](https://img.shields.io/badge/繁體中文-🇹🇼-blue)](../zh-TW/README.md)

# ModAPI(v1) v2.0.9552 - 20260225

**Công cụ Quản lý Mod The Forest — Phiên bản Nâng cấp**

> Gốc: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Đức)
> Nâng cấp: zzangae (Đại Hàn Dân Quốc)

---

## Tổng quan

ModAPI là ứng dụng desktop để quản lý mod cho The Forest. Phiên bản nâng cấp này bao gồm di chuyển sang .NET Framework 4.8, giao diện Windows 11 Fluent Design, hệ thống 3 giao diện, hỗ trợ đa ngôn ngữ nâng cao và triển khai đầy đủ tab Tải xuống.

---

## Các Thay đổi Chính

### Giai đoạn 1 — Nâng cấp .NET Framework 4.8

- Di chuyển tất cả dự án (5) từ `.NET Framework 4.5` → `4.8`
- Cập nhật `TargetFrameworkVersion`, `App.config`, `packages.config` trong tất cả dự án
- Thống nhất phiên bản assembly

### Giai đoạn 2 — Môi trường Build và Nền tảng Fluent Design

- Giới thiệu gói NuGet **ModernWpf 0.9.6**
- Tạo **FluentStyles.xaml** — lớp ghi đè Windows 11 Fluent Design
  - Bảng màu Fluent, kiểu chữ, nút, tab, combobox, kiểu thanh cuộn
  - Mẫu Window, SubWindow, SplashScreen
- Biên dịch **DLL stub UnityEngine**
  - Thêm các kiểu thiếu: `WWW`, `Event`, `TextEditor`, `Physics`, v.v.
- Sửa tham chiếu phụ thuộc và xác nhận build thành công

### Giai đoạn 3 — Thiết kế lại UI và Hệ thống Giao diện

#### Thiết kế lại Fluent UI
- Tái cấu trúc hoàn toàn **MainWindow.xaml**
  - Bố cục, màu sắc và kiểu chữ dựa trên Fluent Design
  - Thiết kế lại điều khiển tab, thanh trạng thái, nút tiêu đề
- Sửa lỗi runtime: đóng băng SplashScreen, chuyển tab, trạng thái biểu tượng, kéo cửa sổ

#### Hệ thống 3 Giao diện

| Giao diện | Tệp Kiểu | Mô tả |
|-----------|----------|-------|
| Cổ điển | Chỉ Dictionary.xaml | Thiết kế ModAPI gốc (nền texture) |
| Sáng | FluentStylesLight.xaml | Tông sáng + điểm nhấn xanh |
| Tối | FluentStyles.xaml | Tông tối + điểm nhấn xanh (mặc định) |

- Thêm **ComboBox chọn giao diện** trong tab Cài đặt
- Thay đổi giao diện kích hoạt **hộp thoại xác nhận** → **tự động khởi động lại**
- Cài đặt giao diện lưu/tải qua tệp `theme.cfg`

#### Kéo Cửa sổ / SubWindows / Siêu liên kết
- Sự kiện `MouseLeftButtonDown` trên Root Grid để xử lý kéo trực tiếp
- Hộp thoại ThemeConfirm, ThemeRestartNotice, NoProjectWarning, DeleteModConfirm
- Màu liên kết theo giao diện: Tối/Cổ điển (`#FFD700`), Sáng (`#0078D4`)

### Giai đoạn 4 — Dọn dẹp Mã nguồn và Loại bỏ Cũ

- Xóa hệ thống đăng nhập (máy chủ ngừng hoạt động)
- Hiện đại hóa cơ chế cập nhật
- Dọn dẹp mã không sử dụng
- Sửa UI SubWindow (hộp thoại đường dẫn trò chơi, v.v.)

### Giai đoạn 5 — Mở rộng Hỗ trợ Đa ngôn ngữ (13 Ngôn ngữ)

| Ngôn ngữ | Tệp | Ngôn ngữ | Tệp |
|----------|-----|----------|-----|
| Hàn Quốc | Language.KR.xaml | Ý | Language.IT.xaml |
| Anh | Language.EN.xaml | Nhật | Language.JA.xaml |
| Đức | Language.DE.xaml | Bồ Đào Nha | Language.PT.xaml |
| Tây Ban Nha | Language.ES.xaml | Việt Nam | Language.VI.xaml |
| Pháp | Language.FR.xaml | Trung Quốc (Giản thể) | Language.ZH.xaml |
| Ba Lan | Language.PL.xaml | Trung Quốc (Phồn thể) | Language.ZH-TW.xaml |
| Nga | Language.RU.xaml | | |

### Giai đoạn 5-1 — Tab Tải xuống và Hoàn thiện Giao diện

#### Tab Tải xuống
- Tải danh sách mod từ 3 nguồn (`mods.json`, `versions.xml`, phân tích HTML)
- Chức năng tìm kiếm (lọc theo tên/mô tả/tác giả mod)
- **Bộ lọc trò chơi** (Tất cả / The Forest / Máy chủ Chuyên dụng / VR)
- **Bộ lọc danh mục** (Tất cả / Sửa lỗi / Cân bằng / Gian lận, v.v. — 12 danh mục)
- UI bảng chia để chọn phiên bản
- Tải trực tiếp tệp `.mod` → cài đặt vào thư mục trò chơi
- Sắp xếp cột (nhấp tên/danh mục/tác giả) và thay đổi kích thước
- Xóa mod (dọn dẹp DLL + tệp tạm)

#### Hiện đại hóa Biểu tượng (Tất cả Giao diện)
- Tất cả biểu tượng PNG nút → biểu tượng phông chữ **Segoe MDL2 Assets**
- Áp dụng trên MainWindow.xaml + 14 tệp SubWindow
- Biểu tượng phông chữ kế thừa màu Foreground, đảm bảo hiển thị trên tất cả giao diện

| PNG Gốc | Biểu tượng Phông chữ | Sử dụng |
|---|---|---|
| Icon_Add | &#xE710; / &#xE768; | Thêm / Khởi động Trò chơi |
| Icon_Delete | &#xE74D; | Xóa |
| Icon_Refresh | &#xE72C; | Làm mới |
| Icon_Download | &#xE896; | Tải xuống |
| Icon_Continue/Accept | &#xE8FB; | Xác nhận/Tiếp tục |
| Icon_Decline | &#xE711; | Hủy/Đóng |
| Icon_Information | &#xE946; | Thông tin |
| Icon_Warning | &#xE7BA; | Cảnh báo |
| Icon_Error | &#xEA39; | Lỗi |
| Icon_Browse | &#xED25; | Duyệt |
| Icon_CreateMod | &#xE713; | Tạo Mod |

#### Điều khiển Thống nhất trên Tất cả Giao diện

| Điều khiển | Cổ điển | Tối | Sáng |
|-----------|---------|-----|------|
| Hộp kiểm | Công tắc (Vàng) | Công tắc (AccentBrush) | Công tắc (AccentBrush) |
| Nút radio | Tròn (Vàng) | Tròn (AccentBrush) | Tròn (AccentBrush) |
| ComboBox | Scale9 gốc | Fluent tùy chỉnh | Fluent tùy chỉnh |

#### Sửa Hiển thị Giao diện
- Sáng: văn bản AccentButton bắt buộc Trắng, điều chỉnh Opacity biểu tượng tab
- Tối/Sáng: phương pháp `TextElement.Foreground` ComboBoxItem cho hiển thị văn bản đã chọn
- Cổ điển: tài nguyên dự phòng Fluent thêm vào Dictionary.xaml

---

## Cấu trúc Tệp

```
ModAPI/
├── App.xaml / App.xaml.cs          # Tải/lưu/áp dụng giao diện
├── Dictionary.xaml                  # Kiểu gốc + tài nguyên công tắc/radio/dự phòng
├── FluentStyles.xaml                # Giao diện tối + ComboBox/CheckBox/RadioButton
├── FluentStylesLight.xaml           # Giao diện sáng + ComboBox/CheckBox/RadioButton
├── Windows/
│   ├── MainWindow.xaml / .cs        # UI chính + tab tải xuống + bộ chọn giao diện
│   └── SubWindows/                  # 16 SubWindows (tất cả có biểu tượng phông chữ)
├── resources/
│   ├── langs/                       # 13 tệp ngôn ngữ
│   └── textures/Icons/flags/        # Biểu tượng cờ (16x11 PNG)
└── libs/
    └── UnityEngine.dll              # DLL stub
```

---

## Yêu cầu Build

- **Visual Studio 2022**
- **.NET Framework 4.8** SDK
- **ModernWpf 0.9.6** (NuGet)

---

## Giấy phép

GNU General Public License v3.0 — tuân theo giấy phép gốc.
