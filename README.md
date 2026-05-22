# LibraryAutomationSys
Library
# 📚 Kütüphane Otomasyon Sistemi / Library Management System

*[Click here for English version](#english-version)*

## 🇹🇷 Türkçe 

C# Console üzerinde geliştirilmiş, Nesne Yönelimli Programlama (OOP) ve **Tek Sorumluluk Prensibi (Single Responsibility)** temel alınarak katmanlı bir mimariyle tasarlanmış basit bir Kütüphane Yönetim Sistemidir. Veritabanı yerine verileri `.txt` dosyalarında saklayarak dosya okuma/yazma (I/O) işlemlerinin mantığını kavramayı hedefler.

### ✨ Özellikler
- **Üye İşlemleri:** Yeni üye ekleme, kayıtlı üyeleri listeleme ve üye silme.
- **Kitap İşlemleri:** Yeni kitap ekleme, mevcut kitapları listeleme ve kitap silme.
- **Veri Saklama:** Program kapansa bile veriler `Kitaplar.txt` ve `uyeler.txt` dosyalarında güvenle saklanır.
- **Güvenli Giriş:** Kullanıcı hatalı veri (metin yerine harf vb.) girdiğinde programın çökmesini engelleyen `TryParse` kontrolleri.

### 🏗️ Proje Mimarisi
Proje, her sınıfın tek bir işi yapması prensibine göre ayrılmıştır:
* **Modeller (`Kitap.cs`, `Uye.cs`):** Veri yapılarını (ID, Ad, Yazar vb.) tutar.
* **Arayüzler (`IKitapServis`, `IUyeServis`, `IDosyaServis`):** Servislerin hangi yeteneklere sahip olacağını belirler.
* **Yöneticiler (`KitapYoneticiC`, `UyeYoneticiC`):** İş kurallarını (Business Logic) işletir.
* **Dosya Yöneticisi (`DosyaYoneticisi`):** Sadece dosya okuma ve yazma işlerinden sorumludur. Diğer hiçbir sınıf doğrudan dosyaya müdahale edemez.

### 💡 Geliştirici Notu
Projenin `Main` (ana program) kısmındaki rutin işlemleri (menü döngüleri, konsol yazıları vb.) daha hızlı kodlamak için yapay zekadan destek aldım. Fakat projenin belkemiği olan **Interface (Arayüz)** yapısı, **Polymorphism (Çok Biçimlilik)** ve geri kalan tüm çekirdek işlemler ile mimari kurgu tamamen kendi tarafımdan kodlanmıştır.

### 🚀 Kurulum ve Kullanım
1. Projeyi bilgisayarınıza klonlayın.
2. Visual Studio veya destekleyen herhangi bir IDE (örn. VS Code) ile projeyi açın.
3. `Program.cs` dosyasını çalıştırın.
4. Dosyalar (`Kitaplar.txt` ve `uyeler.txt`) programın çalıştığı dizinde (`bin/Debug/net...`) otomatik olarak oluşturulacaktır.

---

<a name="english-version"></a>
## 🇬🇧 English

A simple Library Management System developed as a C# Console Application, designed with a layered architecture based on Object-Oriented Programming (OOP) and the **Single Responsibility Principle**. Instead of a database, it uses `.txt` files for data persistence to demonstrate file I/O operations.

### ✨ Features
- **Member Management:** Add new members, list registered members, and delete members by ID.
- **Book Management:** Add new books, list available books, and delete books by ID.
- **Data Persistence:** Data is safely stored in `Kitaplar.txt` and `uyeler.txt` files, surviving program restarts.
- **Error Handling:** Implements `TryParse` validations to prevent application crashes from invalid user inputs.

### 🏗️ Project Architecture
The project is structured ensuring each class has a single responsibility:
* **Models (`Kitap.cs`, `Uye.cs`):** Represents the data structures (ID, Name, Author, etc.).
* **Interfaces (`IKitapServis`, `IUyeServis`, `IDosyaServis`):** Defines the contracts for the services.
* **Managers (`KitapYoneticiC`, `UyeYoneticiC`):** Handles the core business logic.
* **File Manager (`DosyaYoneticisi`):** Strictly responsible for file read/write operations. No other class interacts directly with the file system.

### 💡 Developer's Note
I utilized AI to speed up the routine coding tasks and menu flows in the `Main` method. However, the core of the project—including the **Interfaces**, **Polymorphism**, and all other fundamental architectural operations—was coded entirely by myself.

### 🚀 Installation & Usage
1. Clone the repository to your local machine.
2. Open the project using Visual Studio or any compatible IDE (e.g., VS Code).
3. Run the `Program.cs` file.
4. The text files (`Kitaplar.txt` and `uyeler.txt`) will be automatically generated in the execution directory (`bin/Debug/net...`) upon adding the first records.
