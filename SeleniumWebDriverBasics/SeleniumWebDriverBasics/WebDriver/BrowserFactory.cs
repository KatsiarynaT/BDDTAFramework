using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebDriver.DriverBrowserFactory;
using static SeleniumWebDriverBasics.Utilities.BrowserList;

namespace SeleniumWebDriverBasics.WebDriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(BrowserType type, int timeoutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        driver = new ChromeDriverBrowserFactory().Driver;
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        driver = new FirefoxDriverBrowserFactory().Driver;
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        driver = new RemoteFirefoxDriverBrowserFactory().Driver;
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        driver = new RemoteChromeDriverBrowserFactory().Driver;
                        break;
                    }
            }

            return driver;
        }
    }
}