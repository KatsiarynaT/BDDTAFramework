using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.Interfaces
{
    public interface IDriver
    {
        IWebDriver Driver { get; }
    }
}