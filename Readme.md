# OTD Toggle Binding Plugin

A plugin for [OpenTabletDriver](https://opentabletdriver.net/) that adds two new binding types:

- **Toggle Key Binding** — press once for Key A, press again for Key B. Perfect for toggling between Brush (`B`) and Eraser (`E`) in Clip Studio Paint.
- **Hold Key Binding** — hold button to temporarily switch to Key B, release to return to Key A. Like a momentary eraser switch.

---

## Requirements

- OpenTabletDriver 0.6.x
- .NET SDK 8.0
- `xdotool` installed on your system

- OpenTabletDriver 0.6.x or later
- .NET SDK 8.0

This plugin now uses OpenTabletDriver's built-in virtual keyboard API, so no external key-sending utilities (like `xdotool`) are required.

---

## Build

```bash
git clone https://github.com/surue-s/otd-toggle-plugin
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
# Install via the CLI helper (if available)
otd installplugin ./bin/Release/net8.0/ToggleBinding.dll

# Or copy the DLL directly into your user plugins folder and restart the daemon
cp bin/Release/net8.0/ToggleBinding.dll ~/.config/OpenTabletDriver/Plugins/ToggleBinding/ToggleBinding.dll
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

- The plugin uses OpenTabletDriver's `IVirtualKeyboard` so no external key-sending tools are required.
- The **Hold Key Binding** mirrors momentary behavior (hold for eraser, release for brush).
- If keys are still not reaching apps inside Flatpak/Bottles, check focus and Flatpak portal permissions; we can add runtime logging to the bindings to diagnose.

---

## License

MIT
