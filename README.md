# IT Support Application (IT-Support)

<!-- Project badges -->

Bu repository, Windows platformu için geliştirilmiş basit bir **IT destek talep uygulamasını** içerir.  
Uygulama, kullanıcıların ad, departman ve kısa problem açıklaması girerek bu bilgileri **IT destek ekibine e-posta ile göndermelerini** sağlar.  
Arayüz **WPF** ile geliştirilmiş olup modern bir görünüm ve kullanıcı deneyimi sunar.

---

## 📌 Project Info

| Attribute | Value        |
|-----------|--------------|
| Platform  | Windows (WPF)|
| .NET      | 8.0          |
| Language  | C#           |
| SMTP      | Office 365 (default) |

---

## ✨ Features

- ✅ **User-friendly form**: Ad, departman ve problem açıklaması için giriş alanları.  
  - Gönder butonu, zorunlu bilgiler doldurulana kadar pasif durumda olur.  

- ✉️ **Email notification**:  
  - Gönder butonuna tıklandığında bilgiler **Office 365 SMTP** sunucusu üzerinden e-posta ile gönderilir.  
  - Gönderen ve alıcı adresleri **App.config** dosyasında şifrelenmiş şekilde saklanır.  

- 🔐 **AES encryption**:  
  - `AesCrypto.EncryptString` yöntemi ile e-posta ve şifre **AES algoritması** ile şifrelenir.  

- 🎬 **Loading animation**:  
  - Gönderim sürecinde **yükleniyor animasyonu** gösterilir.  
  - Başarı veya hata mesajları kullanıcıya bildirilir.  

- 🎨 **Sleek, minimal interface**:  
  - Yuvarlatılmış köşeler, fade-in/fade-out animasyonlar ve özel buton stilleri.  

---

## ⚙️ Installation

1. Repository’yi klonlayın:

   ```bash
   git clone https://github.com/talhaozbay/IT-Support.git
   cd IT-Support/IT-Support
   ```

2. **Development environment**:  
   - Proje **.NET 8.0** hedefler.  
   - Visual Studio 2022/2025 veya `dotnet CLI` ile build edilebilir.  

3. **Solution’ı açın**:  
   - `IT-Support.sln` dosyasını Visual Studio’da açın veya  
   - Komut satırından `dotnet build` çalıştırın.  

4. **SMTP credentials hazırlayın**:  
   - `App.config` içinde **keyd** ve **keym** ayarları vardır.  
   - Bunlar, şifrelenmiş e-posta adresi ve şifre ile değiştirilmelidir.  

   Örnek şifreleme:  

   ```csharp
   using IT_Support;

   string email = "support@yourcompany.com";
   string password = "YourPassword123";

   string encryptedEmail = AesCrypto.EncryptString(email);
   string encryptedPassword = AesCrypto.EncryptString(password);

   Console.WriteLine($"keyd: {encryptedEmail}\nkeym: {encryptedPassword}");
   ```

   - Üretilen `keyd` ve `keym` değerlerini **App.config** içindeki `<appSettings>` bölümüne yerleştirin.  

5. **SMTP server settings**:  
   - Varsayılan olarak `smtp.office365.com` (port 587) kullanılır.  
   - Farklı bir sunucu gerekirse `MainWindow.xaml.cs` içindeki `SendMail` metodu düzenlenmelidir.  

---

## 🚀 Usage

1. Uygulamayı çalıştırın.  
2. Açılan pencerede **Ad, Departman ve Problem Açıklaması** alanlarını doldurun.  
3. **Send** butonuna tıklayın.  
   - Eksik bilgi varsa uyarı çıkar.  
   - Gönderim süresince **yükleniyor animasyonu** oynar.  
   - İşlem tamamlandığında **başarı veya hata mesajı** görüntülenir.  

---

## 🖼️ Screenshot

Aşağıdaki görsel uygulamanın ana penceresini göstermektedir:  
*(Repo kökünde bulunan `IT-Destek-resize.png` dosyası kullanılmaktadır)*

---

## 🤝 Contributing

Katkılar memnuniyetle karşılanır!  
Yeni özellik eklemek veya hata düzeltmek isterseniz:  

1. Repository’yi fork’layın  
2. Yeni bir branch oluşturun  
3. Pull request gönderin  

---

## 📄 License

Bu proje için özel bir lisans belirtilmemiştir.  
**Kurumsal veya eğitim amaçlı** dahili kullanım için serbesttir.  
