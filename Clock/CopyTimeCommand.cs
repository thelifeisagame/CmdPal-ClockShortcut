// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

internal sealed partial class CopyTimeCommand : InvokableCommand
{
    private readonly SettingsManager _settings;

    public CopyTimeCommand(SettingsManager settings)
    {
        _settings = settings;
    }

    public override string Name => LocalizationManager.GetString("CopyTime", _settings.Language);

    public override IconInfo Icon => new("\uE823"); // Clock icon

    public override CommandResult Invoke()
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

        var text = now.ToString(timeFormat, culture);
        var message = string.Format(culture, LocalizationManager.GetString("TimeCopied", _settings.Language), text);

        new CopyTextCommand(text).Invoke();
        return CommandResult.ShowToast(message);
    }
}
