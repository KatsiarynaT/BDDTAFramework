using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebDriver;

namespace SeleniumWebDriverBasics.Decorator
{
    public class HighlighterDecoratorFrame : HighlighterDecorator
    {
        public HighlighterDecoratorFrame(Highlighter highlighter) : base(highlighter) { }

        public override void HighlightElement(IWebElement element)
        {
            base.HighlightElement(element);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
            executor.ExecuteScript("arguments[0].style.border='2px solid green'", element);
        }
    }
}