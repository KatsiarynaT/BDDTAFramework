using System.Configuration;
using SeleniumWebDriverBasics.Utilities;

namespace SeleniumWebDriverBasics.WebDriver
{
    public class Configuration
    {
        public static BrowserList.BrowserType currentBrowser;

        public static string GetEnvironmentVar(string var, string defaultValue) => ConfigurationManager.AppSettings[var] ?? defaultValue;
        public static int ElementTimeout => Convert.ToInt32(GetEnvironmentVar("ElementTimeout", ""));
        public static bool Browser => Enum.TryParse(GetEnvironmentVar("Browser", ""), out currentBrowser);
        public static string StartUrl => GetEnvironmentVar("StartUrl", "");
        public static string Login => GetEnvironmentVar("Login", "");
        public static string Password => GetEnvironmentVar("Password", "");
    }
}