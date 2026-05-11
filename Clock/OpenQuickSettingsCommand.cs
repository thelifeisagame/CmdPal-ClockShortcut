// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

internal sealed partial class OpenQuickSettingsCommand : InvokableCommand
{
    private readonly string _lang;

    public OpenQuickSettingsCommand(string lang = "auto")
    {
        _lang = lang;
    }

    public override string Name => LocalizationManager.GetString("OpenQuickSettings", _lang);

    public override IconInfo Icon => new("\uE713"); // Settings icon

    public override string Id => "com.clock.open_quick_settings";

    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    private const byte VK_LWIN = 0x5B;
    private const byte VK_A = 0x41;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    public override CommandResult Invoke()
    {
        // Simulate Win + A
        keybd_event(VK_LWIN, 0, 0, 0);
        keybd_event(VK_A, 0, 0, 0);
        keybd_event(VK_A, 0, KEYEVENTF_KEYUP, 0);
        keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);

        return CommandResult.Dismiss();
    }
}
