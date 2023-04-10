using OpenQA.Selenium;
using SeleniumWebDriverBasics.Entities;
using SeleniumWebDriverBasics.WebObjects.Base;

namespace SeleniumWebDriverBasics.WebObjects.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By loginFieldXpath = By.Id("passp-field-login");

        public LoginPage() : base(loginFieldXpath, "Login Field") { }

        private readonly BaseElement loginField = new BaseElement(loginFieldXpath);
        private readonly BaseElement loginButton = new BaseElement(By.Id("passp:sign-in"));
        private readonly BaseElement passwordField = new BaseElement(By.Id("passp-field-passwd"));
        private readonly BaseElement ActualLoginMessage = new BaseElement(By.XPath("//div[@class='passp-auth-screen passp-welcome-page']/h1/span"));

        public void EnterLogin(string login)
        {
            loginField.SendKeys(login);
        }

        public void ClickConfirmationButton()
        {
            loginButton.JSClick();
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void Login(User user)
        {
            EnterLogin(user.DataUser[0]);
            loginButton.HighlightElement();
            ClickConfirmationButton();
            EnterPassword(user.DataUser[1]);
            ClickConfirmationButton();
        }

        public string GetActualLoginMessage() => ActualLoginMessage.GetText();
    }
}