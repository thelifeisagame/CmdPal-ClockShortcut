# PowerToys Command Palette - Clock Extension

Une extension élégante et personnalisable pour le dock de PowerToys Command Palette qui affiche l'heure et la date en direct.

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows%2010%20%2F%2011-brightgreen.svg)

## ✨ Fonctionnalités

- **Affichage en direct** : Heure et date affichées directement dans le dock.
- **Actions rapides (Clic Gauche)** : Ouvre le centre de notifications Windows (Win + N).
- **Menu Contextuel (Clic Droit)** :
  - Ouvrir les paramètres rapides (Win + A).
  - Copier l'heure actuelle.
  - Copier la date actuelle.
- **Personnalisation complète** :
  - Langues : Français, Anglais (détection automatique).
  - Format heure : 24h ou 12h (avec option AM/PM).
  - Affichage des secondes : On/Off.
  - Format date : Court (11/05/2026), Complet (Lundi 11 Mai 2026) ou ISO (2026-05-11).

## 🚀 Installation (Développement)

Pour l'instant, l'extension doit être enregistrée manuellement en tant qu'extension de développement :

1. **Prérequis** :
   - PowerToys installé (avec le Dock Command Palette activé).
   - [Mode Développeur](https://learn.microsoft.com/windows/apps/get-started/enable-your-device-for-development) activé dans les paramètres Windows.

2. **Compilation** :
   - Ouvrez la solution `Clock.sln` dans Visual Studio 2022.
   - Compilez en configuration **Debug** pour votre architecture (**x64** ou **ARM64**).

3. **Enregistrement** :
   Ouvrez PowerShell et exécutez la commande suivante (adaptez le chemin vers votre dossier de build) :
   ```powershell
   Add-AppxPackage -Path ".\Clock\bin\Debug\net9.0-windows10.0.26100.0\win-x64\AppxManifest.xml" -Register
   ```

4. **Chargement** :
   - Ouvrez la Command Palette de PowerToys.
   - Tapez `Reload` et choisissez **Reload Command Palette extensions**.
   - Cherchez "Clock" et épinglez-la au dock.

## 🛠️ Technologies utilisées

- C# / .NET 9
- WinUI 3 / Windows App SDK
- PowerToys Command Palette Extension SDK

## 📄 Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.
