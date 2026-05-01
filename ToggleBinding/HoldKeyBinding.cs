using System.Diagnostics;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;

namespace ToggleBinding;

[PluginIgnore]
public class HoldKeyBinding : IBinding
{
    [Property(nameof(DefaultKey))]
    [ToolTip("the key to send when held button is released (e.g., 'b' for brush)")]
    public string DefaultKey { get; set; } = "b";

    [Property(nameof(HoldKey))]
    [ToolTip("the key to send while holding the button (e.g., 'e' for eraser)")]
    public string HoldKey { get; set; } = "e";

    public void Press()
    {
        try
        {
            // send the hold key when button is pressed
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "xdotool",
                    Arguments = $"key {HoldKey}",
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
            Log.Write(nameof(HoldKeyBinding), $"failed to send hold key: {ex.Message}", LogLevel.Error);
        }
    }

    public void Release()
    {
        try
        {
            // send the default key when button is released to return to original state
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "xdotool",
                    Arguments = $"key {DefaultKey}",
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
            Log.Write(nameof(HoldKeyBinding), $"failed to send default key: {ex.Message}", LogLevel.Error);
        }
    }
}
