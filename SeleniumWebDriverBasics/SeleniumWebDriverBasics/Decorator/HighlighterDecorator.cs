using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.Decorator
{
    public abstract class HighlighterDecorator : Highlighter
    {
        protected Highlighter highlighter;

        public HighlighterDecorator(Highlighter highlighter) 
        {
            this.highlighter = highlighter;
        }

        public override void HighlightElement(IWebElement element)
        {
            if (highlighter != null)
                highlighter.HighlightElement(element);
        }
    }
}