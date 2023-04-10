using OpenQA.Selenium;
using System.Drawing;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.Decorator;

namespace SeleniumWebDriverBasics.WebObjects.Base
{
    public class BaseElement : IWebElement
    {
        protected string name;
        protected By locator;
        protected IWebElement element;

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();

            return GetElement().Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                element = Browser.Driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                throw;
            }

            return element;
        }

        public ReadOnlyCollection<IWebElement> GetElements()
        {
            return Browser.Driver.FindElements(locator);
        }

        public void WaitForIsVisible()
        {
            new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void HighlightElement()
        {
            try
            {
                Browser.Driver.FindElement(locator);

                HighlighterBase highlighter= new HighlighterBase();
                HighlighterDecoratorFrame decoratorFrame = new HighlighterDecoratorFrame(highlighter);
                decoratorFrame.HighlightElement(this.GetElement());
            }
            catch
            {
                HighlighterBase highlighter = new HighlighterBase();
                highlighter.HighlightElement(this.GetElement());
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.Driver.FindElement(locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            GetElement().Click();
        }

        public int Count()
        {
            WaitForIsVisible();
            return Browser.Driver.FindElements(locator).Count();
        }

        public void JSClick()
        {
            WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
            executor.ExecuteScript("arguments[0].click()", GetElement());
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }
    }
}