using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.WebObjects.Base
{
    public abstract class BasePage
    {
        protected By titleLocator;
        protected string title;

        protected BasePage(By titleLocator, string title)
        {
            this.titleLocator = titleLocator;
            this.title = title;
        }
    }
}