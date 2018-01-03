using System;
using System.Configuration;

namespace Lesson01.Constants
{
    public static class Configurations
    {
        public static string[] SupportedLanguages
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("suppLangs").Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}