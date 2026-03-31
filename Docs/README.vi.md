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

**Công cụ Quản lý Mod The Forest — Phiên bản Nâng cấp**

> Gốc: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Đức)
> Nâng cấp: zzangae (Đại Hàn Dân Quốc)

---

## Tổng quan

ModAPI là ứng dụng desktop để quản lý mod cho The Forest. Phiên bản nâng cấp này bao gồm di chuyển sang .NET Framework 4.8, giao diện Windows 11 Fluent Design, hệ thống 3 giao diện, hỗ trợ đa ngôn ngữ nâng cao, triển khai đầy đủ tab Tải xuống và hỗ trợ phát triển mod C# 7.3.

---

## Những gì thay đổi trong v2.0.9586

| # | Danh mục | Vấn đề | Giải pháp |
|---|---|---|---|
| 1 | **Nghiêm trọng** | Màn hình đen trong menu chính sau khi áp dụng mod | Đã giải quyết — pipeline ánh xạ lại assembly vá đúng header PE và bảng tham chiếu |
| 2 | **Polyfill** | `Portable.System.ValueTuple.dll` được đưa vào nhưng không hoạt động | Đã xóa hoàn toàn — `mscorlib` của Mono 2.0 tạo IL tham chiếu trực tiếp đến `ValueTuple`; không polyfill nào có thể ghi đè |
| 3 | **Polyfill** | Tên tệp sai: `System.Threading.Tasks.dll` | Đã sửa thành `System.Threading.dll` — tên thực tế từ NuGet `TaskParallelLibrary 1.0.2856` |
| 4 | **Polyfill** | Lỗi đường dẫn sao chép trong `Game.cs`: tệp được sao chép vào `Managed\polyfills\` | Đã sửa bằng `Path.GetFileName()` để sao chép phẳng vào `Managed\` |
| 5 | **Build** | Target PostBuild thiếu tự động sao chép polyfill | `BaseModLib.csproj` PostBuild giờ tự động sao chép `AsyncBridge.dll` và `System.Threading.dll` |
| 6 | **C# 7.3** | Thử hỗ trợ tuple (`ValueTuple`) thất bại | Đã xóa dứt khoát — tuple là giới hạn kiến trúc trên Mono 2.0 |
| 7 | **C# 7.3** | Xác minh trong game các tính năng C# 7.3 còn lại | Đã xác nhận: pattern matching, nội suy chuỗi, biến `out` inline |

### Ma trận Tính năng C# 7.3 Cuối cùng

| Tính năng | Trạng thái | Ghi chú |
|---|---|---|
| Pattern matching (`is`, `switch`) | ✅ Đã xác nhận | Kiểm tra trong game qua `TEST_MOD.log` |
| Nội suy chuỗi (`$""`) | ✅ Đã xác nhận | Kiểm tra trong game qua `TEST_MOD.log` |
| Biến `out` inline | ✅ Đã xác nhận | Kiểm tra trong game qua `TEST_MOD.log` |
| Thành viên thân biểu thức (`=>`) | ✅ | Xử lý bởi compiler |
| Hàm cục bộ | ✅ | Xử lý bởi compiler |
| `nameof` | ✅ | Xử lý bởi compiler |
| Toán tử null-điều kiện (`?.`, `??`) | ✅ | Xử lý bởi compiler |
| `async`/`await` | ✅ | Qua polyfill AsyncBridge + System.Threading |
| Tuple (`ValueTuple`) | ❌ Giới hạn cứng | ABI mscorlib Mono 2.0 — không có giải pháp thay thế |

### Cấu hình Polyfill Cuối cùng

| DLL | Gói NuGet | Đích | Mục đích |
|---|---|---|---|
| `AsyncBridge.dll` | AsyncBridge 0.3.1 | `libs/polyfills/` → `Managed/` | `async`/`await` cho .NET 3.5 |
| `System.Threading.dll` | TaskParallelLibrary 1.0.2856 | `libs/polyfills/` → `Managed/` | Phụ thuộc AsyncBridge |
| ~~`Portable.System.ValueTuple.dll`~~ | ~~Đã xóa~~ | ~~Đã xóa~~ | ~~Không hoạt động trên Mono 2.0~~ |

---

## Kiến trúc Runtime

| Thành phần | Mục tiêu | Runtime | Lý do |
|---|---|---|---|
| `ModAPI.exe` | .NET Framework 4.8 | Windows .NET 4.8 | Ứng dụng desktop |
| `BaseModLib.dll` | .NET Framework 3.5 | Game Mono 2.0 | **Cố định vĩnh viễn** |
| DLL Mod | .NET Framework 4.8 | Game Mono 2.0 (đã vá) | Vá header PE khi Apply |

```
Build v3.5  →  Header PE: CLR Runtime v2.0.50727  ←  Mono 2.0 chấp nhận  ✅
Build v4.8  →  Header PE: CLR Runtime v4.0.30319  ←  Mono 2.0 từ chối    ❌
```

---

## Lịch sử Phiên bản

| Phiên bản | Ngày | Tóm tắt |
|---|---|---|
| v2.0.9586 | 2026-03-31 | Xác nhận sửa màn hình đen, hoàn thiện pipeline polyfill, xóa ValueTuple, sửa lỗi, xác minh C# 7.3 trong game |
| v2.0.9561 | 2026-03-06 | Hỗ trợ phát triển mod C# 7.3, vá header PE, pipeline polyfill |
| v2.0.9552 | 2026-02-25 | Tab tải xuống, biểu tượng, 13 ngôn ngữ |
| v2.0.9500 | — | Hệ thống giao diện, Fluent Design UI |
| v2.0.9400 | — | Dọn dẹp mã |
| v2.0.9300 | — | Môi trường build, DLL stub UnityEngine |
| v2.0.9200 | — | Di chuyển .NET Framework 4.8 |
| v1.x | — | Phát hành gốc FluffyFish |

---

## Yêu cầu Build

| Yêu cầu | Phiên bản | Ghi chú |
|---|---|---|
| Visual Studio | 2022 | |
| .NET Framework SDK | 4.8 | Cho các dự án ModAPI |
| .NET Framework SDK | 3.5 | Chỉ cho BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — đặt trong `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `System.Threading.dll` trong `libs/polyfills/` |

---

## Giấy phép

GNU General Public License v3.0 — tuân theo giấy phép gốc.
