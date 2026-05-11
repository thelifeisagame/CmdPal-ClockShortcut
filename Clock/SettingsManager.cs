// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Clock;

internal sealed class SettingsManager
{
    private readonly Settings _settings;

    public SettingsManager()
    {
        _settings = new Settings();
        UpdateSettingsContent();
        _settings.SettingsChanged += (s, e) => 
        {
            SettingsChanged?.Invoke(this, EventArgs.Empty);
        };
    }

    private void UpdateSettingsContent()
    {
        var lang = "auto"; // Default to auto for initial creation

        _settings.Add(new ChoiceSetSetting(
            "language",
            LocalizationManager.GetString("LanguageLabel", lang),
            LocalizationManager.GetString("LanguageDesc", lang),
            [
                new ChoiceSetSetting.Choice("Auto (System)", "auto"),
                new ChoiceSetSetting.Choice("English", "en"),
                new ChoiceSetSetting.Choice("Français", "fr"),
            ]));

        _settings.Add(new ToggleSetting(
            "showSeconds",
            LocalizationManager.GetString("ShowSecondsLabel", lang),
            LocalizationManager.GetString("ShowSecondsDesc", lang),
            true));

        _settings.Add(new ToggleSetting(
            "showAmPm",
            LocalizationManager.GetString("ShowAmPmLabel", lang),
            LocalizationManager.GetString("ShowAmPmDesc", lang),
            true));

        _settings.Add(new ChoiceSetSetting(
            "timeFormat",
            LocalizationManager.GetString("TimeFormatLabel", lang),
            LocalizationManager.GetString("TimeFormatDesc", lang),
            [
                new ChoiceSetSetting.Choice(LocalizationManager.GetString("Format24h", lang), "24h"),
                new ChoiceSetSetting.Choice(LocalizationManager.GetString("Format12h", lang), "12h"),
            ]));

        _settings.Add(new ChoiceSetSetting(
            "dateFormat",
            LocalizationManager.GetString("DateFormatLabel", lang),
            LocalizationManager.GetString("DateFormatDesc", lang),
            [
                new ChoiceSetSetting.Choice(LocalizationManager.GetString("FormatShort", lang), "short"),
                new ChoiceSetSetting.Choice(LocalizationManager.GetString("FormatFull", lang), "full"),
                new ChoiceSetSetting.Choice(LocalizationManager.GetString("FormatISO", lang), "iso"),
            ]));
    }

    public event EventHandler? SettingsChanged;

    public ICommandSettings Settings => _settings;

    public string Language => _settings.GetSetting<string>("language") ?? "auto";

    public bool ShowSeconds => _settings.GetSetting<bool>("showSeconds");

    public bool ShowAmPm => _settings.GetSetting<bool>("showAmPm");

    public string TimeFormat => _settings.GetSetting<string>("timeFormat") ?? "24h";

    public string DateFormat => _settings.GetSetting<string>("dateFormat") ?? "short";
}
