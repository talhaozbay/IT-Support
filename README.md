# IT Support Application (IT-Support)

<!-- Project badges -->

This repository contains a simple **IT support request application** built for the Windows platform.  
The app allows users to enter their name, department, and a short problem description, and send this information via **email to the IT support team**.  
The interface is developed with **WPF**, providing a modern look and user experience.

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

- ✅ **User-friendly form**: Input fields for name, department, and problem description.  
  - The Send button is disabled until all required information is provided.  

- ✉️ **Email notification**:  
  - When the Send button is clicked, the information is sent via the **Office 365 SMTP** server.  
  - Sender and receiver addresses are stored encrypted in the **App.config** file.  

- 🔐 **AES encryption**:  
  - Uses the `AesCrypto.EncryptString` method to encrypt the email and password with the **AES algorithm**.  

- 🎬 **Loading animation**:  
  - A **loading animation** is shown during the sending process.  
  - Success or error messages are displayed to the user.  

- 🎨 **Sleek, minimal interface**:  
  - Rounded corners, fade-in/fade-out animations, and custom button styles.  

---

## ⚙️ Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/talhaozbay/IT-Support.git
   cd IT-Support/IT-Support
   ```

2. **Development environment**:  
   - The project targets **.NET 8.0**.  
   - It can be built using Visual Studio 2022/2025 or the `dotnet CLI`.  

3. **Open the solution**:  
   - Open `IT-Support.sln` in Visual Studio, or  
   - Run `dotnet build` from the command line.  

4. **Prepare SMTP credentials**:  
   - The `App.config` file contains **keyd** and **keym** settings.  
   - These must be replaced with your encrypted email address and password.  

   Example encryption:  

   ```csharp
   using IT_Support;

   string email = "support@yourcompany.com";
   string password = "YourPassword123";

   string encryptedEmail = AesCrypto.EncryptString(email);
   string encryptedPassword = AesCrypto.EncryptString(password);

   Console.WriteLine($"keyd: {encryptedEmail}\nkeym: {encryptedPassword}");
   ```

   - Place the generated `keyd` and `keym` values in the `<appSettings>` section of **App.config**.  

5. **SMTP server settings**:  
   - By default, the app uses `smtp.office365.com` (port 587).  
   - If you need another server, update the `SendMail` method in **MainWindow.xaml.cs**.  

---

## 🚀 Usage

1. Run the application.  
2. In the window, fill in the **Name, Department, and Problem Description** fields.  
3. Click the **Send** button.  
   - If required fields are missing, a warning will appear.  
   - A **loading animation** will play while the email is being sent.  
   - Once complete, a **success or error message** will be displayed.  

---

## 🖼️ Screenshot

The screenshot below shows the main window of the application:  
*(The `IT-Destek-resize.png` file located in the repo root is used here)*

---

## 🤝 Contributing

Contributions are welcome!  
If you would like to add new features or fix bugs:  

1. Fork the repository  
2. Create a new branch  
3. Submit a pull request  

---

## 📄 License

No specific license is provided for this project.  
It may be used internally for **corporate or educational purposes**.  
