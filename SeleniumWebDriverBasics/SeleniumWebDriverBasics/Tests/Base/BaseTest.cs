using SeleniumWebDriverBasics.Entities;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects.Pages;

namespace SeleniumWebDriverBasics.Tests.Base
{
    public abstract class BaseTest
    {
        private readonly HomePage homePage = new HomePage();
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();

        [SetUp]
        public void TestSetup()
        {
            Browser.GetInstance();
            Browser.NavigateTo();
            Browser.MaximizeWindow();

            var login = Convert.ToString(Configuration.Login);
            var password = Convert.ToString(Configuration.Password);
            var user = new User(login, password);

            homePage.ClickOnLoginButton();
            loginPage.Login(user);
            homePage.WaitForComposeLinkIsVisible();
        }

        [TearDown]
        public virtual void CleanUp()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
            Browser.Quit();
        }
    }
}