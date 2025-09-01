IT Destek Uygulaması (IT‑Support)
<!-- Proje rozetleri -->








Bu depo, Windows platformu için geliştirilmiş basit bir IT destek talep uygulamasını içerir. Uygulama, kullanıcıların ad–soyad, departman ve problem açıklaması bilgilerini girerek IT destek ekibine e‑posta göndermesini sağlar. Arayüz WPF üzerinde tasarlanmıştır ve modern bir görünüm sunar.

Proje Bilgisi
Özellik	Değer
Platform	Windows (WPF)
.NET	8.0

Dil	C#
SMTP	Office 365 (varsayılan)
Özellikler

✅ Kullanıcı dostu form: Uygulamada ad–soyad, departman ve problem açıklaması için alanlar bulunur
. Bilgiler girilmeden gönderme tuşu devreye girmez
.

✉️ E‑posta ile bildirim: “Gönder” butonu ile girilen bilgiler Office 365 SMTP sunucusu üzerinden e‑posta olarak gönderilir
. Alıcı ve gönderici adresi App.config dosyasında şifreli olarak saklanır
.

🔐 AES şifreleme: E‑posta adresi ve parola, AesCrypto.EncryptString fonksiyonu ile AES algoritması kullanılarak şifrelenir
. Bu sayede hassas bilgiler açık olarak gitmez.

🎬 Yükleme animasyonu: Gönderme işlemi sırasında ekranda bir yükleme videosu gösterilir ve kullanıcıya başarılı/güncel durum mesajı verilir
.

🎨 Şık ve minimal arayüz: Pencere etrafında yumuşatılmış kenarlar, fade‑in/fade‑out animasyonları ve özel buton stilleri kullanılmıştır
.

Kurulum

Depoyu klonlayın:

git clone https://github.com/talhaozbay/IT-Support.git
cd IT-Support/IT-Support


Geliştirme ortamı: Bu proje .NET 8.0 ve WPF kullanır
. Visual Studio 2022/2025 veya dotnet CLI ile derlenebilir.

Uygulamayı açın: IT-Support.sln çözüm dosyasını Visual Studio’da açın veya terminalde dotnet build komutunu çalıştırın.

SMTP kimlik bilgilerini hazırlayın:

App.config dosyasında keyd ve keym anahtarları bulunmaktadır
. Bu alanlara şifrelenmiş e‑posta adresi ve parolanızı yazmanız gerekir.

Şifreleme için projedeki AesCrypto sınıfının EncryptString metodunu kullanabilirsiniz
. Aşağıda örnek bir C# kod parçası verilmiştir:

using IT_Support;
string email = "support@yourcompany.com";
string password = "Sifreniz123";
string encryptedEmail = AesCrypto.EncryptString(email);
string encryptedPassword = AesCrypto.EncryptString(password);
Console.WriteLine($"keyd: {encryptedEmail}\nkeym: {encryptedPassword}");


Ürettiğiniz keyd ve keym değerlerini App.config dosyasındaki ilgili alanlara yerleştirin.

SMTP sunucu ayarları: Uygulama varsayılan olarak Office 365 SMTP sunucusuna (smtp.office365.com, port 587) bağlanır
. Farklı bir sunucu kullanacaksanız SendMail metodunu güncelleyin.

Kullanım

Uygulamayı çalıştırın. Pencere açıldığında arayüzde ad–soyad, departman ve problem açıklaması giriş alanlarını göreceksiniz
.

Bilgilerinizi doldurup Gönder butonuna tıkladığınızda
, uygulama e‑posta gönderim işlemine başlayacaktır
. Eksik bilgi girerseniz kullanıcıya uyarı mesajı gösterilir
.

Gönderim tamamlandığında işlemin başarılı olduğuna dair bir bildirim alırsınız
.

Ekran Görüntüsü

Aşağıdaki ekran görüntüsü, uygulamanın ana penceresini göstermektedir (deponun kök dizinindeki IT-Destek-resize.png dosyasını kullanarak README’de görüntüleyebilirsiniz).

Katkıda Bulunma

Katkılar memnuniyetle kabul edilir. Yeni özellikler eklemek veya hataları düzeltmek için bir fork oluşturup, değişikliklerinizi yeni bir dalda yaparak pull request gönderebilirsiniz.

Lisans

Bu proje için özel bir lisans belirtilmemiştir. Kurumsal iç kullanım ve eğitim amaçlı olarak kullanılabilir.
