
# PowerToys Command Palette - Clock Extension

An elegant and customizable clock extension for the PowerToys Command Palette dock that displays live time and date.
[demo1.webm](https://github.com/user-attachments/assets/393a5b71-26bb-4922-8e68-fa26481a6a9f)
[demo2.webm](https://github.com/user-attachments/assets/3f908535-d565-4204-b0b9-879f8cd4284d)

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows%2010%20%2F%2011-brightgreen.svg)

## ✨ Features

- **Live Display**: Time and date shown directly in the dock.
- **Quick Actions (Left Click)**: Opens the Windows Notification Center (Win + N).
- **Context Menu (Right Click)**:
  - Open Quick Settings (Win + A).
  - Copy current time.
  - Copy current date.
- **Full Customization**:
  - Languages: English, French (auto-detected).
  - Time Format: 24h or 12h (with optional AM/PM toggle).
  - Seconds Display: Toggle on/off.
  - Date Format: Short (11/05/2026), Full (Monday, May 11, 2026), or ISO (2026-05-11).

## 🚀 Installation

### Option 1: Using a Release ZIP (Easiest)
1. Download the latest release `.zip` file from the [Releases](https://github.com/YOUR_USERNAME/PowerToys-Clock-Extension/releases) page.
2. Extract the ZIP to a permanent folder on your PC.
3. Open PowerShell as an Administrator in that folder.
4. Run the following command to register the extension:
   ```powershell
   Add-AppxPackage -Path ".\AppxManifest.xml" -Register
   ```
5. In PowerToys Command Palette, run the `Reload` command -> **Reload Command Palette extensions**.

### Option 2: Build from Source
1. **Prerequisites**:
   - [PowerToys](https://github.com/microsoft/PowerToys) installed with Command Palette Dock enabled.
   - [Developer Mode](https://learn.microsoft.com/windows/apps/get-started/enable-your-device-for-development) enabled in Windows Settings.
   - [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed.

2. **Clone the repository**:
   ```bash
   git clone https://github.com/YOUR_USERNAME/PowerToys-Clock-Extension.git
   cd PowerToys-Clock-Extension
   ```

3. **Build**:
   You can build using Visual Studio 2022 or via the CLI:
   ```powershell
   dotnet build Clock\Clock.csproj -c Debug -r win-x64
   ```
   *(Change `win-x64` to `win-arm64` if you are on an ARM device)*.

4. **Register**:
   ```powershell
   Add-AppxPackage -Path ".\Clock\bin\Debug\net9.0-windows10.0.26100.0\win-x64\AppxManifest.xml" -Register
   ```

5. **Load**:
   - Open Command Palette.
   - Run `Reload` -> **Reload Command Palette extensions**.
   - Search for "Clock" and pin it to your dock.

## 🛠️ Built With

- C# / .NET 9
- WinUI 3 / Windows App SDK
- PowerToys Command Palette Extension SDK

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
