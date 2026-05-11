// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

internal sealed partial class ClockPage : ListPage, IDisposable
{
    private readonly System.Timers.Timer _timer;
    private readonly SettingsManager _settings;

    public ClockPage(SettingsManager settings)
    {
        _settings = settings;
        Icon = new IconInfo("\uE823"); // Clock icon
        Title = "Clock";
        Name = "Open";

        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += (s, e) => RaiseItemsChanged();
        _timer.Start();

        _settings.SettingsChanged += (s, e) => RaiseItemsChanged();
    }

    public override IListItem[] GetItems()
    {
        var now = DateTime.Now;
        var culture = _settings.Language == "auto" ? CultureInfo.CurrentCulture : new CultureInfo(_settings.Language);

        string timeFormat;
        if (_settings.TimeFormat == "12h")
        {
            var ampm = _settings.ShowAmPm ? " tt" : string.Empty;
            timeFormat = _settings.ShowSeconds ? $"hh:mm:ss{ampm}" : $"hh:mm{ampm}";
        }
        else
        {
            timeFormat = _settings.ShowSeconds ? "HH:mm:ss" : "HH:mm";
        }

        string dateFormat = _settings.DateFormat switch
        {
            "iso" => "yyyy-MM-dd",
            "short" => "dd/MM/yyyy",
            _ => "dddd d MMMM yyyy"
        };

        return [
            new ListItem(new OpenNotificationCenterCommand(_settings.Language))
            {
                Title = now.ToString(timeFormat, culture),
                Subtitle = now.ToString(dateFormat, culture),
                MoreCommands = [
                    new CommandContextItem(new OpenQuickSettingsCommand(_settings.Language)),
                    new CommandContextItem(new CopyTimeCommand(_settings)),
                    new CommandContextItem(new CopyDateCommand(_settings))
                ]
            }
        ];
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}
