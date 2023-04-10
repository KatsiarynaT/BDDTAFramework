using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumWebDriverBasics.Interfaces;

namespace SeleniumWebDriverBasics.WebDriver.DriverBrowserFactory
{
    public class RemoteChromeDriverBrowserFactory : IDriver
    {
        private IWebDriver driver = null;

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    var option = new ChromeOptions();
                    option.AddArgument("disable-infobars");
                    option.AddArgument("--no-sandbox");
                    driver = new RemoteWebDriver(new Uri("http://localhost:6656/wd/hub"), option.ToCapabilities());
                }

                return driver;
            }
        }
    }
}