[![English](https://img.shields.io/badge/English-🇺🇸-blue)](../README.md)
[![Türkçe](https://img.shields.io/badge/Türkçe-🇹🇷-red)](README.tr.md)
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

# ModAPI(v1) v2.0.9623 - 20260920

> Orijinal: FluffyFish / Philipp Mohrenstecher (Engelskirchen, Almanya)
> Geliştirme: zzangae (Kore Cumhuriyeti)
> Türkçe çeviri: Topluluk katkısı

---

## Genel Bakış

ModAPI, **5 resmi olarak desteklenen oyun** için modları yöneten bir masaüstü uygulamasıdır. Bu geliştirilmiş sürüm; çoklu oyun desteği, tamamen yenilenmiş Ayarlar sekmesi, Steam yolu yapılandırması, kalıcı arayüz ayarları, dinamik yazı tipi boyutu sistemi, oyun başlatma doğrulaması, Debug/Release derleme ayrımı ve oyun içinde test edilerek doğrulanmış çok sayıda çökme düzeltmesi içerir.

Bu Türkçe sürüm şunları ekler:

- Tam Türkçe arayüz (`ModAPI/resources/langs/Language.TR.xaml`, 535 metin)
- Türkçe bayrak simgesi (`Language.TR.png`)
- Ayarlar dil listesinden seçilebilen `Türkçe` seçeneği
- Bu belge (`Docs/README.tr.md`)

---

## Desteklenen Oyunlar

| Oyun | Motor | Sürüm | Steam ID | Çalıştırılabilir |
|---|---|---|---|---|
| The Forest | Unity 5 | v1.12 (VR) | 242760 | `TheForest.exe` |
| Subnautica | Unity | 2025 Yaması | 264710 | `Subnautica.exe` |
| RAFT | Unity | v1.1.02 (Beta) | 648800 | `Raft.exe` |
| Escape The Pacific | Unity 6 | v0.67.0.0 | 655290 | `EscapeThePacific.exe` |
| Green Hell | Unity 2019 | v2.9.5 | 763790 | `GH.exe` |

Tüm oyunlar Mono tabanlıdır (IL2CPP yok). Modlar `mods/{Oyun}/`, projeler `projects/{Oyun}/` altında tutulur.

- **The Forest:** `TheForest_Data/Managed/`, `mods/TheForest/`, Steam App ID `242760`
- **Subnautica:** `Subnautica_Data/Managed/`, `mods/Subnautica/`, Steam App ID `264710`
- **RAFT:** `Raft_Data/Managed/`, `mods/Raft/`, Steam App ID `648800`
- **Escape The Pacific:** `EscapeThePacific_Data/Managed/`, `mods/EscapeThePacific/`, Steam App ID `655290`
- **Green Hell:** `GH_Data/Managed/`, `mods/GH/`, Steam App ID `763790`

---

## Mimari

### Çalışma Zamanı Ayrımı

- `ModAPI.exe`: .NET Framework 4.8
- `BaseModLib.dll`: .NET Framework 3.5 (sürüm `v2.0.50727` sabit). Kullanıcı mod DLL'leri bu eski çalışma zamanına yeniden eşlenir (remap), böylece eski Unity Mono oyunlarıyla uyumlu kalır.

### Geliştirici Araçları

- **VersionTool:** `Versions.xml` dosyalarını günceller. Oyun yamalandığında sağlama toplamı (checksum) değişir; bu araç yeni sürümü tanıtır.
- **LangTool:** Dil dosyalarını yönetir. `ModAPI/resources/langs/Language.XX.xaml` + `Language.XX.png` + `LangTool/langs.json` akışını kullanır. Yeni dil eklemek için:
  1. `Language.TR.xaml` kopyalanır (anahtarlar aynı kalır, değerler çevrilir),
  2. `Language.TR.png` bayrak eklenir,
  3. `ModAPI.csproj` içine `Content Include` olarak eklenir,
  4. `LangTool/langs.json` içine `builtin: true, active: true` ile eklenir.

### Debug / Release Derleme Ayrımı

- Debug: `File.Exists()` kontrolleri, ayrıntılı günlük.
- Release: PE başlığı + CLR doğrulaması (`FileValidator`), dijital imza Notu, derleme sağlama toplamı (`MD5`) engellemesi.

### Dosya Doğrulama

Oyun başlatılırken 3 adım çalışır:

1. **A — PE başlığı** (`IsValidGameExe()`): Bozuksa başlatma engellenir.
2. **B — Derleme sağlama toplamı** (MD5 vs `Versions.xml`): Uyuşmazsa başlatma engellenir.
3. **C — Dijital imza** (`HasDigitalSignature()`): İmza yoksa yalnızca günlüğe `Notice` yazılır, pencere çıkmaz, oyun başlar. Birçok bağımsız oyun imzasız dağıtıldığı için bu adım bilerek engelleyici değildir.

### Derleme Yeniden Eşleme Hattı

Mod DLL'leri Cecil ile yeniden yazılır, oyun referanslarına çözümlenir, `mods/` altına konuşlandırılır. Çözümleyici bulamazsa yedek (fallback) çözümleyici devreye girer.

### C# 7.3 Desteği

`libs/polyfills/` altında `AsyncBridge` + `TaskParallelLibrary` ile eski çerçeveye `async/await` çok dolgusu (polyfill) sağlanır.

---

## Kurulum

### Adım 1 — Gereksinimler

- Visual Studio 2022
- .NET Framework SDK 4.8 (ModAPI projeleri), 3.5 (yalnızca BaseModLib)
- NuGet: ModernWpf 0.9.6, AsyncBridge 0.3.1, TaskParallelLibrary 1.0.2856

### Adım 2 — ModAPI'yi Kurun

1. Bu depoyu klonlayın.
2. `ModAPI.sln` dosyasını Visual Studio 2022 ile açın.
3. `Release` + `AnyCPU` ile derleyin.
4. Çıktı `bin/Release/` altındadır. Arşivden veya geçici dizinden çalıştırmayın.

### Adım 3 — Steam Yolunu Yapılandırın (Ayarlar Sekmesi)

- `Steam bağlantısı` açıldığında yol kayıt defterinden (`HKCU\Software\Valve\Steam`) otomatik algılanır. Steam arayüz (overlay) desteği için oyun `Steam.exe -applaunch {AppId}` ile başlatılır.
- Kapalıyken yolu elle girersiniz. Açıkken metin kutusu yönetilir ve `Sıfırla` devre dışıdır.

### Adım 4 — Oyun Yollarını Yapılandırın (Ayarlar Sekmesi)

Her oyun için kurulum klasörünü seçip `Kaydet`e basın. Yol geçerli değilse `Sürüm Tablosunu Koru` onay kutusu devre dışı kalır ve ipucu nedenini açıklar.

### Adım 5 — Mod İndirin (İndirmeler Sekmesi)

Listeden oyun filtresiyle mod seçin, `İndir`e basın. Çevrimdışıysanız `.mod` dosyalarını elle `mods/{Oyun}/` altına koyun (örn. `mods/TheForest`, `mods/GH`).

### Adım 6 — Modları Uygulayın ve Oyunu Başlatın (Modlar Sekmesi)

Mod adının solundaki yuvarlak düğmeyle etkinleştirin, sağ alttaki `Oyunu başlat`a basın. Farklı oyunlara ait modlar birlikte seçilirse uyarı çıkar ve uyumsuz olanlar hariç tutulur.

---

## Sekmeler

### Hoş Geldiniz Sekmesi

`Hoş Geldiniz!` düğmesi ilk açılış penceresini istenildiği zaman yeniden açar. Bu modda düğme `Kapat` olur, ilk kurulum tekrar çalışmaz.

### Modlar Sekmesi

- Bilgi / Ayarlar alt sekmeleri, sürüm seçimi, tuş atamaları.
- `Oyunu başlat` doğrulamadan geçer (bölüm Mimari).

### İndirmeler Sekmesi

Ad, Yazar, Kategori, Oyun, İndirme sütunları; `Ara`, `Yenile`, `İndir`, `Bilgi`. Çevrimdışı başlık + elle kurulum açıklaması + `Bağlantıyı Yeniden Dene`.

### Geliştirme Sekmesi

Proje oluştur/kaldır, mod kütüphanesini yeniden oluştur, atanabilir tuşlar, dil listesi.

### Temalar Sekmesi

10 tema: Classic, Light, Dark, Diablo, Nebula, Sunset, Ocean, Nordic, Citrus, Bloom. Değişiklikten sonra yeniden başlatma istenir. Arka plan dokusu (maks 500 KB) ve liste genişlikleri `ui.cfg` içinde saklanır.

### Ayarlar Sekmesi

- Dil (Türkçe dahil 14 dil), Yazı Boyutu
- `Sürüm Tablosunu Koru`, `Steam bağlantısı`, `Geliştirici Günlüğü`, `Başlangıçta Günlükleri Temizle`, `Her Zaman Üstte`
- Her onay kutusunda AÇIK/KAPALI ipucu vardır.
- `Güncelle` düğmesi: Yeni sürümü denetler, indirir, değişiklik günlüğünü gösterir, `Bitti` sonrası `Updater.exe` ile yeniden başlatır. Başlangıçta otomatik zorunlu güncelleme yoktur.

---

## Dil Aracı (LangTool)

- Dil listesi, bayrak önizleme, anahtar düzenleme, İngilizce orijinal sütunu.
- `+ Ekle`, `Devre Dışı Bırak / Etkinleştir`, `Kaydet`, `Yerleşiğe Dönüştür`.
- Eksik/boş anahtar sayacı (`⚠ Eksik/Boş anahtarlar: {0}`), `✅ Tüm anahtarlar çevrildi`.

## Sürüm Aracı (VersionTool)

`Versions.xml` sağlama toplamlarını yeniler. Oyun güncellendiğinde:

1. Oyunun `Managed/*.dll` MD5 değerlerini hesaplayın,
2. `firstpass.dll` varsa önce onun hash'i olmak üzere birleştirin (GH, Subnautica, EscapeThePacific),
3. `firstpass.dll` yoksa (Raft) tek hash kullanın,
4. VersionTool ile `Versions.xml` içine yazın.

---

## Günlük Sistemi

- `ModAPI.log`: normal günlük.
- `ModAPI.dev.log`: yalnızca `Geliştirici Günlüğü` açıkken ayrıntılı günlük.
- `Başlangıçta Günlükleri Temizle` açıksa her başlatmada sıfırlanır, kapalıysa eklenir.
- Yakalanamayan istisnalar genel olarak günlüğe yazılır.

---

## v2.0.9623'te Neler Değişti

### Güncelleme Denetimi ve Uygulama — Başlatıcı Tarzı, Elle, Engellemesiz

- Ayarlar sekmesindeki çalışmayan `Güncelleme Ara` onay kutusu kaldırıldı, yerine tek `Güncelle` düğmesi geldi. Tıklanınca GitHub Releases API (`/repos/{owner}/ModAPI/releases/latest`) çağrılır, indirme/çıkarma başlatılır.
- `OperationPending` penceresine katlanabilir sürüm notları paneli eklendi. %100 olmadan `Bitti` etkinleşmez; `Bitti` `Updater.exe`'yi başlatıp ModAPI'yi kapatır.
- `--dev` ile çalıştırılmadıkça normal depo kullanılır (`UpdateRepoOwner`). Ayarlardaki `Geliştirici Günlüğü` depo seçimini etkilemez.
- Sürüm denetimi yalnızca düğmeye basıldığında çalışır, başlangıçta engellemez.

### Arayüz Düzeltmesi — Sürüm Notları Paneli Kaymıyordu

- `TextBox` `Hidden` kaydırma + `SizeToContent="WidthAndHeight"` birleşimi satırı tek satır yapıyordu. `TextBlock` + `ScrollViewer` + `ProgressBar.ActualWidth` genişliğiyle düzeltildi.

### Uçtan Uca Doğrulandı (Elle Test)

İndir → çıkar → onayla → yeniden başlat zinciri kukla sürümle test edildi. `App.xaml.cs` başlangıçta `_update` klasörünü temizlediği için test klasörü ModAPI çalışırken oluşturulmalıdır.

### "Sürüm Tablosunu Koru" — Artık Gerçekten Çalışana Kadar Devre Dışı

Oyun yolu geçersizken `VersionsData.Refresh()` zaten erken çıkıyordu; onay kutusu sessizce hiçbir şey yapmıyordu. Artık `CanUpdateVersionsTable` (`App.Game != null && App.Game.CheckGamePath()`) ile devre dışı + ipucu. Korece etiket `최신버전 유지` → `버전 테이블 유지` olarak düzeltildi.

### Genel Düzeltme — Classic Temada İpuçlarının Stili Yoktu

Fluent temalarda stilli `ToolTip` vardı, Classic `Dictionary.xaml` içinde yoktu ve beyaz sistem ipucu çıkıyordu. `Dictionary.xaml` içine opak `ToolTip` stili eklendi.

### İlk Açılış Penceresi Yeniden Tasarımı

- Steam / Sürüm Tablosu onay kutuları kaldırıldı (zaten Ayarlar'da var).
- Kaydırılabilir `Bu sürümdeki yenilikler` paneli eklendi (■/▸/• işaretleri, 13 dile çevrildi).
- `SubWindow` `SizeToContent="WidthAndHeight"` + `MaxWidth` temalarda farklı davrandığı için bu pencerede `SizeToContent="Height"` kullanıldı.
- Classic temada beyaz `NormalLabel` okunmadığı için yalnızca bu pencerede koyu düzeltme (`FirstSetup.ApplyClassicThemeTextFix()`).

### Bütünlük Denetimi — C Adımı Artık Her Açılışta Sormuyor

İmzasız oyunlarda (örn. Green Hell) her `Oyunu başlat` tıklamasında çıkan `imza yok` penceresi kaldırıldı. Yalnızca günlüğe yazılır. A/B adımları (PE + sağlama toplamı) hala engeller.

### Steam Bağlantısı — Otomatik Algılanan Yol ve Elle Düzenleme Hatası

- Açılınca kayıt defterinden otomatik doldurur, farklı sürücüleri destekler, `steam://validate/{AppId}` onarımı mevcuttur.
- `SteamAndGamePathsPanel.DataContext` atanmadığı için `CanEditSteamPathManually` çalışmıyor, `Sıfırla` etkin kalıyordu. Düzeltildi.
- Classic temada devre dışı düğmeler %40 opaklığa düşürülür.

### Tema Sistemi Birleştirme — Classic ↔ Fluent Eşitliği

- 9 `FluentStyles*.xaml` içinde olmayan `Slider` + `MultilingualTextField` için yeni paylaşımlı `FluentStylesShared.xaml` eklendi.
- Classic içinde olmayan `GridSplitter` Classic'e eklendi.
- Kullanılmayan `PasswordBox`, sosyal düğmeler, `TimeSlider` silinmedi, XML yorumla işaretlendi (orijinal yazar kodu korunur).
- Ölü `Dictionary.xaml` (Windows klasörü) ve `FluentStylesClassic.xaml` prototipi silindi.

### Ayarlar Sekmesindeki Diğer Onay Kutularına AÇIK/KAPALI İpuçları

`Steam Entegrasyonu`, `Geliştirici Günlükleri`, `Günlükleri Sıfırla`, `Her Zaman Üstte` için durum bazlı 8 yeni anahtar × 13 dil.

### Hoş Geldiniz Penceresi — Sürüm Notlarıyla Eşleşen Tam Metin

Kısa özet → `RELEASE_NOTES_2.0.9623` ile eşleşen tam bölüm listesi. Genişlik `Stretch` ile tema kaplamasına bırakıldı, sabit 450px kaldırıldı.

### Yeni / Güncellenen Dil Anahtarları

`Lang.Options.Buttons.Update`, `Lang.Windows.OperationPending.Tasks.Update.Done`, `Lang.Windows.NoUpdateAvailable.*`, `...UpdateVersionsTableDisabledHint/EnabledHint`, `...UseSteamEnabledHint/DisabledHint`, `...DevLog...`, `...ClearLogsOnStart...`, `...AlwaysOnTop...`, `Lang.Windows.FirstSetup.WhatsNewTitle/Text`, `...Buttons.Close`, `Lang.Mods.Welcome.Buttons.OpenWelcomePopup`.

Türkçe dahil tüm dillerde mevcuttur (bu PR ile 14 dil).

---

## Önceki Sürümler (Özet)

- **v2.0.9622:** Sağlama toplamı hesaplama birleştirildi.
- **v2.0.9621:** Steam kütüphane geneli otomatik algılama, yanlış oyun modu otomatik tespiti, Geliştirici Günlüğü / Başlangıçta Temizle, genel işlenmemiş istisna günlüğü, ilk açılış varsayılanları değişti.
- **v2.0.9620:** LangTool eklendi, oyun seçim penceresi, bütünlük doğrulama (yalnızca Release), `UpdateVersions()` / `FindMods()` / `StartGame()` tanı günlükleri, `Versions.xml` mimarisi.
- **v2.0.9613–9619:** Tema sistemi (10 tema), yazı tipi boyutu, `ui.cfg`, arka plan dokusu, İndirmeler sekmesi ve 13 dil, C# 7.3 çok dolgusu, derleme çözümleyici yedeği.
- **v2.0.9610–9612:** Çoklu oyun + Modlar yeniden tasarımı.
- **v2.0.9600:** İndirmeler sekmesi ilk sürüm.

Ayrıntılar için İngilizce `README.md` ve `Docs/RELEASE_NOTES_*` dosyalarına bakın.

---

## Derleme Gereksinimleri

| Gereksinim | Sürüm | Notlar |
|---|---|---|
| Visual Studio | 2022 |  |
| .NET Framework SDK | 4.8 | ModAPI projeleri |
| .NET Framework SDK | 3.5 | Yalnızca BaseModLib |
| ModernWpf | 0.9.6 | NuGet |
| AsyncBridge | 0.3.1 | NuGet — `libs/polyfills/` |
| TaskParallelLibrary | 1.0.2856 | NuGet — `libs/polyfills/` içinde `System.Threading.dll` |

---

## Lisans

GNU Genel Kamu Lisansı v3.0 — orijinal lisans izlenir.
