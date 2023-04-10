using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebDriver;

namespace SeleniumWebDriverBasics.Decorator
{
    public class HighlighterBase : Highlighter
    {
        public override void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
            executor.ExecuteScript("arguments[0].style.background='yellow'", element);
        }
    }
}