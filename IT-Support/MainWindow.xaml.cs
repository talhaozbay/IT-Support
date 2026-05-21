using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Configuration;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;


namespace IT_Support
{
    public partial class MainWindow : Window
    {
        private bool _isClosing = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Loader_MediaEnded(object sender, RoutedEventArgs e)
        {
            var player = Loader;
            player.Position = TimeSpan.Zero;
            player.Play();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _LoadingScreen.Visibility = Visibility.Hidden;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);

        }

        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing) return;

            e.Cancel = true;
            _isClosing = true;
            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5));
            fadeOut.Completed += (s, _) => this.Close();
            this.BeginAnimation(Window.OpacityProperty, fadeOut);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTXT.Text.Length <= 0 && departmentTXT.Text.Length <= 0)
            {
                MessageBox.Show("Lütfen Adınızı ve Departmanızı Giriniz.", "Eksik Bilgi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                _LoadingScreen.Visibility = Visibility.Visible;
                Loader.Play();
                string adSoyad = nameTXT.Text;
                string departman = departmentTXT.Text;
                string aciklama = requestTXT.Text;
                await Task.Run(() => SendMail(adSoyad, departman, aciklama));
                this.Close();
            }
        }
        private void SendMail(string adSoyad, string departman, string aciklama)
        {
            string hostname = Dns.GetHostName();

            try
            {
                string encryptedMail = ConfigurationManager.AppSettings["keyd"];
                string smtpMail = AesCrypto.DecryptString(encryptedMail);
                string encryptedPassword = ConfigurationManager.AppSettings["keym"];
                string smtpPassword = AesCrypto.DecryptString(encryptedPassword);
                string smtpHost = "smtp.office365.com";
                int smtpPort = int.Parse("587");

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(smtpHost);

                mail.From = new MailAddress(smtpMail);
                mail.To.Add(smtpMail);
                mail.Subject = "Yeni IT Destek Talebi";
                mail.Body = $"Ad Soyad: {adSoyad}\nDepartman: {departman}\nBilgisayar: {hostname}\n\nAçıklama:\n{aciklama}";

                smtpServer.Port = smtpPort;
                smtpServer.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show("Talebiniz başarıyla gönderildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + "Bilgisayarınızın internete bağlı olduğundan emin olun.\n" + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    public static class AesCrypto
    {
        private static readonly byte[] Key = {
        239, 194,  9, 238, 195,  71, 92,  39,
         81, 171, 67,   4, 224,  37, 83, 221,
         54, 140, 190,  82, 171,  70, 149,  20,
         95,  39, 128, 169, 202,  91, 242,  76
        };

        private static readonly byte[] IV = {
         11, 133, 176, 223,   6,  89, 239, 255,
        106, 118,  85,  55, 213, 183,  92, 247
        };

        public static string EncryptString(string plainText)
        {
            if (plainText == null)
                return null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);

                        byte[] encryptedBytes = msEncrypt.ToArray();

                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
        }

        public static string DecryptString(string cipherTextBase64)
        {
            if (cipherTextBase64 == null)
                return null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherTextBase64);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            string plaintext = srDecrypt.ReadToEnd();
                            return plaintext;
                        }
                    }
                }
            }
        }
    }
}
