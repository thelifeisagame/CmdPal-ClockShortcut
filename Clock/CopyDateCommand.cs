// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

internal sealed partial class CopyDateCommand : InvokableCommand
{
    private readonly SettingsManager _settings;

    public CopyDateCommand(SettingsManager settings)
    {
        _settings = settings;
    }

    public override string Name => LocalizationManager.GetString("CopyDate", _settings.Language);

    public override IconInfo Icon => new("\uE787"); // Calendar icon

    public override CommandResult Invoke()
    {
        var now = DateTime.Now;
        var culture = _settings.Language == "auto" ? CultureInfo.CurrentCulture : new CultureInfo(_settings.Language);

        string dateFormat = _settings.DateFormat switch
        {
            "iso" => "yyyy-MM-dd",
            "short" => "dd/MM/yyyy",
            _ => "dddd d MMMM yyyy"
        };

        var text = now.ToString(dateFormat, culture);
        var message = string.Format(culture, LocalizationManager.GetString("DateCopied", _settings.Language), text);

        new CopyTextCommand(text).Invoke();
        return CommandResult.ShowToast(message);
    }
}
