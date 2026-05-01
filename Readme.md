# OTD Toggle Binding Plugin

A plugin for [OpenTabletDriver](https://opentabletdriver.net/) that adds two new binding types:

- **Toggle Key Binding** — press once for Key A, press again for Key B. Perfect for toggling between Brush (`B`) and Eraser (`E`) in Clip Studio Paint.
- **Hold Key Binding** — hold button to temporarily switch to Key B, release to return to Key A. Like a momentary eraser switch.

---

## Requirements

- OpenTabletDriver 0.6.x
- .NET SDK 8.0
- `xdotool` installed on your system

```bash
# CachyOS / Arch
sudo pacman -S xdotool dotnet-sdk
```

---

## Build

```bash
git clone https://github.com/yourname/otd-toggle-plugin
cd otd-toggle-plugin/ToggleBinding

dotnet add package OpenTabletDriver.Plugin
dotnet build --configuration Release
```

The built DLL will be at:
```
bin/Release/net8.0/ToggleBinding.dll
```

---

## Install

```bash
otd installplugin ./bin/Release/net8.0/ToggleBinding.dll
systemctl --user restart opentabletdriver.service
```

---

## Usage in OTD GUI

1. Open `otd-gui`
2. Click on any pen button or express key binding
3. In the binding type dropdown you'll now see:
   - **Toggle Key Binding**
   - **Hold Key Binding**
4. Select one and configure your keys in the fields below

### Recommended setup for Clip Studio Paint (Brush/Eraser toggle):

**Toggle mode:**
| Field | Value |
|-------|-------|
| Key A | `b` (Brush) |
| Key B | `e` (Eraser) |

**Hold mode:**
| Field | Value |
|-------|-------|
| Default Key | `b` (Brush) |
| Hold Key | `e` (Eraser while held) |

---

## Notes

- Make sure `xdotool` is installed, otherwise key sending will fail
- The **Hold Key Binding** is closer to how the official XP Pen driver handles the eraser switch
- Pen tip blocking while holding a button is a hardware/firmware behavior — if it persists, it may need to be addressed at the OTD filter level

---

## License

MIT