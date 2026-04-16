using System.IO;
using Newtonsoft.Json.Linq;

namespace api_automation_framework.Core.Settings
{
    public static class ConfigManager
    {
        private static readonly JObject _config;

        /**
         * Static constructor to load configuration file.
         */
        static ConfigManager()
        {
            var json = File.ReadAllText("Config/appsettings.json");
            _config = JObject.Parse(json);
        }

        /**
         * Get Base URL from configuration.
         *
         * @return string BaseUrl
         */
        public static string GetBaseUrl()
        {
            return _config["BaseUrl"]?.ToString();
        }
    }
}   
