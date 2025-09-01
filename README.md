# IT Support Application (IT-Support)

<!-- Project badges -->

Bu repository, Windows platformu için geliştirilmiş basit bir IT destek talep uygulamasını içerir.  
Kullanıcılar ad, departman ve kısa problem açıklaması girerek bu bilgileri IT destek ekibine e-posta ile gönderebilir.  
Arayüz WPF ile geliştirilmiştir ve modern bir görünüm sunar.

---

## 📊 Project Info

| Attribute | Value          |
|-----------|----------------|
| Platform  | Windows (WPF)  |
| .NET      | 8.0            |
| Language  | C#             |
| SMTP      | Office 365     |

---

## ✨ Features

- ✅ **User-friendly form**: Ad, departman ve problem açıklaması alanları içerir. Gönder düğmesi gerekli bilgiler girilene kadar pasif kalır.  
- ✉️ **Email notification**: Gönder butonuna tıklandığında bilgiler Office 365 SMTP sunucusu üzerinden e-posta ile gönderilir. Gönderen ve alıcı adresleri `App.config` dosyasında şifrelenmiş olarak saklanır.  
- 🔐 **AES encryption**: Uygulama, AES algoritmasını kullanarak e-posta adresi ve şifreyi şifreler (`AesCrypto.EncryptString`).  
- 🎬 **Loading animation**: E-posta gönderilirken yükleniyor animasyonu gösterilir, işlem sonunda başarı veya hata mesajı görüntülenir.  
- 🎨 **Sleek, minimal interface**: Yuvarlatılmış köşeler, fade-in/fade-out animasyonlar ve özel buton stilleri içerir.  

---

## 🛠 Installation

1. Repoyu klonlayın:
   ```bash
   git clone https://github.com/talhaozbay/IT-Support.git
   cd IT-Support/IT-Support
