using System.Diagnostics;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;

namespace ToggleBinding;

public class ToggleKeyBinding : IStateBinding
{
    // tracks the current state for toggling between keys
    private bool _isKeyAActive = true;

    [Property(nameof(KeyA))]
    [ToolTip("the first key to send on press (e.g., 'b' for brush)")]
    public string KeyA { get; set; } = "b";

    [Property(nameof(KeyB))]
    [ToolTip("the second key to send on press (e.g., 'e' for eraser)")]
    public string KeyB { get; set; } = "e";

    public void Press(TabletReference tablet, IDeviceReport report)
    {
        // determine which key to send based on current state
        string keyToSend = _isKeyAActive ? KeyA : KeyB;

        try
        {
            // use xdotool to send the key
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "xdotool",
                    Arguments = $"key {keyToSend}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Log.Write(nameof(ToggleKeyBinding), $"failed to send key: {ex.Message}", LogLevel.Error);
        }

        // toggle the state for next press
        _isKeyAActive = !_isKeyAActive;
    }

    public void Release(TabletReference tablet, IDeviceReport report)
    {
        // nothing happens on release for toggle binding
    }
}
