using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumWebDriverBasics.Interfaces;

namespace SeleniumWebDriverBasics.WebDriver.DriverBrowserFactory
{
    public class FirefoxDriverBrowserFactory : IDriver
    {
        private IWebDriver driver = null;

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    var service = FirefoxDriverService.CreateDefaultService();
                    var options = new FirefoxOptions();
                    driver = new FirefoxDriver(service, options);
                }

                return driver;
            }
        }
    }
}