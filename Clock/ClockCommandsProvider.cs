// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

public partial class ClockCommandsProvider : CommandProvider
{
    private readonly SettingsManager _settingsManager = new();
    private readonly ICommandItem[] _commands;

    public ClockCommandsProvider()
    {
        Id = "com.clock.extension";
        DisplayName = "Clock";
        Icon = new IconInfo("\uE823"); // Clock icon
        Settings = _settingsManager.Settings;
        _commands = [
            new CommandItem(new ClockPage(_settingsManager)) { Title = DisplayName },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

    public override ICommandItem[]? GetDockBands()
    {
        var band = new WrappedDockItem([new ClockDockBand(_settingsManager)], "com.clock.dockband", "Clock");
        band.Icon = null;
        return [band];
    }
}
