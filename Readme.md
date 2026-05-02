# OTD Toggle Binding Plugin

A plugin for [OpenTabletDriver](https://opentabletdriver.net/) that adds two new binding types:

- **Toggle Key Binding** — press once for Key A, press again for Key B. Perfect for toggling between Brush (`B`) and Eraser (`E`) in Clip Studio Paint.
- **Hold Key Binding** — hold button to temporarily switch to Key B, release to return to Key A. Like a momentary eraser switch.

---

## What You Need
 
- **OpenTabletDriver** must be installed. You can get it at https://opentabletdriver.net
- **xdotool** must be installed on Linux. This is a small tool that sends keyboard presses to your computer. Install it with the command for your system:
  On Arch Linux or CachyOS:
  ```
  sudo pacman -S xdotool
  ```
 
  On Ubuntu or Debian:
  ```
  sudo apt install xdotool
  ```
 
  On Fedora:
  ```
  sudo dnf install xdotool
  ```
 
> **Note for Windows and Mac users:** xdotool does not work on Windows or Mac. Because of this the plugin will not send keys on those systems right now. This is a known limitation and a fix is planned. For now this plugin only fully works on Linux.
 
---
 
## How to Install the Plugin
 
First download the  **ToggleBinding.dll** from the latest release.
 
Then follow the steps for your system below.
 
---
 
### Linux
 
**Option 1: Use the install command**
 
Open a terminal and run:
```
otd installplugin /path/to/ToggleBinding.dll
```
Replace `/path/to/ToggleBinding.dll` with the actual location of the file on your computer.
 
Then restart OpenTabletDriver:
```
systemctl --user restart opentabletdriver.service
```
 
**Option 2: Copy the file manually**
 
If the install command does not work you can copy the file directly. Open a terminal and run:
```
mkdir -p ~/.config/OpenTabletDriver/Plugins/TogglePlugin
cp /path/to/ToggleBinding.dll ~/.config/OpenTabletDriver/Plugins/TogglePlugin/
```
Then restart OpenTabletDriver:
```
systemctl --user restart opentabletdriver.service
```
 
---
 
### Mac
 
**Option 1: Use the install command**
 
Open Terminal and run:
```
otd installplugin /path/to/ToggleBinding.dll
```
Then restart OpenTabletDriver from the menu bar icon at the top of your screen.
 
**Option 2: Copy the file manually**
 
Open Terminal and run:
```
mkdir -p ~/Library/Application\ Support/OpenTabletDriver/Plugins/TogglePlugin
cp /path/to/ToggleBinding.dll ~/Library/Application\ Support/OpenTabletDriver/Plugins/TogglePlugin/
```
Then restart OpenTabletDriver from the menu bar icon.
 
---
 
### Windows
 
**Option 1: Use the install command**
 
Open Command Prompt in the folder where ToggleBinding.dll is saved and run:
```
otd installplugin ToggleBinding.dll
```
Then restart OpenTabletDriver from the system tray icon in the bottom right of your screen.
 
**Option 2: Copy the file manually**
 
Open File Explorer and go to this folder:
```
%APPDATA%\OpenTabletDriver\Plugins\
```
Create a new folder inside called `TogglePlugin` and paste the `ToggleBinding.dll` file into it. Then restart OpenTabletDriver from the system tray icon.
 
---
 
## How to Use It
 
1. Open OpenTabletDriver
2. Click on any pen button or express key binding in the settings
3. Click the dropdown that shows the binding type
4. You will now see two new options: **Toggle Key Binding** and **Hold Key Binding**
**Toggle Key Binding** means press once to switch to one tool and press again to switch back.
 
**Hold Key Binding** means hold the button to temporarily use another tool and let go to return to the previous one.
 
### Recommended Setup for Clip Studio Paint
 
| Setting | Value |
|---|---|
| Key A | `b` (this is the brush tool) |
| Key B | `e` (this is the eraser tool) |
 
This is the same way the official tablet drivers work.
 
---
 
## How to Uninstall
 
Run this command on Linux or Mac:
```
otd uninstallplugin TogglePlugin
```
Then restart OpenTabletDriver.
 
On Windows open the Plugins folder at `%APPDATA%\OpenTabletDriver\Plugins\` and delete the `TogglePlugin` folder. Then restart OpenTabletDriver.
 
---
 
## License
 
MIT
