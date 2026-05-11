// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Globalization;

namespace Clock;

internal static class LocalizationManager
{
    private static readonly Dictionary<string, Dictionary<string, string>> _translations = new()
    {
        ["en"] = new()
        {
            ["SettingsTitle"] = "Clock Settings",
            ["ShowSecondsLabel"] = "Show seconds",
            ["ShowSecondsDesc"] = "Show or hide seconds in the clock.",
            ["TimeFormatLabel"] = "Time format",
            ["TimeFormatDesc"] = "Choose how the time is displayed.",
            ["DateFormatLabel"] = "Date format",
            ["DateFormatDesc"] = "Choose how the date is displayed.",
            ["LanguageLabel"] = "Language",
            ["LanguageDesc"] = "Choose the UI language.",
            ["OpenNotifications"] = "Open Notification Center",
            ["OpenQuickSettings"] = "Open Quick Settings",
            ["CopyTime"] = "Copy time",
            ["CopyDate"] = "Copy date",
            ["TimeCopied"] = "Time copied: {0}",
            ["DateCopied"] = "Date copied: {0}",
            ["FormatShort"] = "Short",
            ["FormatFull"] = "Full",
            ["FormatISO"] = "ISO (YYYY-MM-DD)",
            ["Format12h"] = "12h (AM/PM)",
            ["Format24h"] = "24h",
            ["ShowAmPmLabel"] = "Show AM/PM",
            ["ShowAmPmDesc"] = "Show or hide the AM/PM indicator in 12h format.",
        },
        ["fr"] = new()
        {
            ["SettingsTitle"] = "Paramètres de l'horloge",
            ["ShowSecondsLabel"] = "Afficher les secondes",
            ["ShowSecondsDesc"] = "Affiche ou masque les secondes dans l'horloge.",
            ["TimeFormatLabel"] = "Format de l'heure",
            ["TimeFormatDesc"] = "Choisissez comment l'heure est affichée.",
            ["DateFormatLabel"] = "Format de la date",
            ["DateFormatDesc"] = "Choisissez comment la date est affichée.",
            ["LanguageLabel"] = "Langue",
            ["LanguageDesc"] = "Choisissez la langue de l'interface.",
            ["OpenNotifications"] = "Ouvrir le centre de notifications",
            ["OpenQuickSettings"] = "Ouvrir les paramètres rapides",
            ["CopyTime"] = "Copier l'heure",
            ["CopyDate"] = "Copier la date",
            ["TimeCopied"] = "Heure copiée : {0}",
            ["DateCopied"] = "Date copiée : {0}",
            ["FormatShort"] = "Format court",
            ["FormatFull"] = "Format complet",
            ["FormatISO"] = "ISO (AAAA-MM-JJ)",
            ["Format12h"] = "12h (AM/PM)",
            ["Format24h"] = "24h",
            ["ShowAmPmLabel"] = "Afficher AM/PM",
            ["ShowAmPmDesc"] = "Affiche ou masque l'indicateur AM/PM en format 12h.",
        }
    };

    public static string GetString(string key, string lang = "auto")
    {
        var targetLang = lang;
        if (targetLang == "auto")
        {
            targetLang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLowerInvariant();
        }

        if (!_translations.ContainsKey(targetLang))
        {
            targetLang = "en"; // Fallback to English
        }

        return _translations[targetLang].GetValueOrDefault(key, key);
    }
}
