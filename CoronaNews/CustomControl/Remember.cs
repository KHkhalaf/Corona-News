using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CoronaNews.CustomControl
{
    public static class Remember
    {
      
        public static void ClearEverything()
        {
            AppSettings.Clear();
        }

        private static ISettings AppSettings => CrossSettings.Current;

        private const string LanguageCodeKey = "LanguageCode";
        private static readonly string LanguageCodeDefault = string.Empty;
        public static string LanguageCode
        {
            get => AppSettings.GetValueOrDefault(LanguageCodeKey, LanguageCodeDefault);
            set => AppSettings.AddOrUpdateValue(LanguageCodeKey, value);
        }
    }
}
