using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.Decorator
{
    public abstract class Highlighter
    {
        public abstract void HighlightElement(IWebElement element);
    }
}