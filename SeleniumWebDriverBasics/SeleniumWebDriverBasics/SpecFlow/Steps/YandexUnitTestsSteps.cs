using SeleniumWebDriverBasics.Entities;
using SeleniumWebDriverBasics.Utilities;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects.Pages;
using TechTalk.SpecFlow;

namespace SeleniumWebDriverBasics.SpecFlow.Steps
{
    [Binding]
    public sealed class YandexUnitTestsSteps
    {
        private readonly ScenarioContext senarioContext;
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();
        private readonly HomePage homePage = new HomePage();

        public YandexUnitTestsSteps(ScenarioContext senarioContext)
        {
            this.senarioContext = senarioContext;
        }

        [Given(@"I log in to yandex mail box")]
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

        private string actualAccountName;

        [When(@"I get the actual user name from User Account option")]
        public string GetActualAccountName()
        {
            actualAccountName = emailPage.GetActualUserName();
            return actualAccountName;
        }

        [Then(@"the actual user name should match the entered login")]
        public void ActualAndExpectedUserNameComparison()
        {
            Assert.AreEqual(ExpectedResults.expectedAccountName, actualAccountName);
        }

        [When(@"I create an email with '(.*)' and '(.*)'")]
        public void CreateAnEmail(string subject, string body)
        {
            emailPage.CreateEmail(subject, body);
        }

        [When(@"I save the created email to Drafts folder")]
        public void SaveEmailToDraftsFolder()
        {
            emailPage.SaveEmailToDraftFolder();
        }

        [When(@"I navigate to Drafts folder")]
        public void NavigateToDraftsFolder()
        {
            emailPage.GoToDraftEmails();
        }

        private string actualSubject;

        [When(@"get the actual subject")]
        public string GetTheActualSubject()
        {
            actualSubject = emailPage.GetActualSubject();
            return actualSubject;
        }

        [Then(@"the email with '(.*)' should present in the folder")]
        public void ActualAndExpectedSubjectComparison(string subject)
        {
            Assert.AreEqual(subject, actualSubject);
        }

        private string actualAddressee;

        [When(@"get the actual addressee")]
        public string GetTheActualAddressee()
        {
            actualAddressee = emailPage.GetActualAddressee();
            return actualAddressee;
        }

        private string actualBody;

        [When(@"get the actual body")]
        public string GetTheActualBody()
        {
            actualBody = emailPage.GetActualMessageBody();
            return actualBody;
        }

        [Then(@"the actual addresse, the '(.*)' and the '(.*)' from the draft email should match the entered")]
        public void ActualAndExpectedAddresseSubjectBody(string subject, string body)
        {
            Assert.AreEqual(ExpectedResults.expectedAddressee, actualAddressee);
            Assert.AreEqual(subject, actualSubject);
            Assert.AreEqual(body, actualBody);
        }

        [When(@"I send the created email")]
        public void SendTheCreatedEmail()
        {
            emailPage.SendCreatedEmail();
        }

        [When(@"I navigate to the Sent folder")]
        public void NavigateToSentFolder()
        {
            emailPage.GoToSentFolder();
        }

        [When(@"I send draft email")]
        public void SendDraftEmail()
        {
            emailPage.SendDraftEmail();
        }

        [When(@"I navigate to Trash folder")]
        public void NavigateToTrashFolder()
        {
            emailPage.GoToTrashFolder();
        }

        public string actualTrashInfoMessage;

        [When(@"get the actual trash info message")]
        public string GetTheActualTrashInfoMessage()
        {
            actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();
            return actualTrashInfoMessage;
        }

        [Then(@"the actual trash info message should match the expected")]
        public void ActualAndExpectedTrashInfoMessageComparison()
        {
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [When(@"I move the draft email to Trash folder")]
        public void MoveDraftEmailToTrashFolder()
        {
            emailPage.MoveDraftEmailToTrashFolder();
        }

        [When(@"I delete all emails")]
        public void DeleteAllEmails()
        {
            emailPage.DeleteAllEmails();
        }

        public string actualDraftInfoMessage;

        [When(@"get the actual draft info message")]
        public string GetTheActualDraftInfoMessage()
        {
            actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();
            return actualDraftInfoMessage;
        }

        [Then(@"the actual draft info message should match the expected")]
        public void ActualAndExpectedDraftInfoMessageComparison()
        {
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [When(@"I navigate to Logout page")]
        public void NavigateToLogoutPage()
        {
            emailPage.GoToSignOutForm();
        }

        public string actualLogoutTitle;

        [When(@"I get the actual title from Logout page")]
        public string GetTheActualTitleFromLogoutPage()
        {
            actualLogoutTitle = loginPage.GetActualLoginMessage();
            return actualLogoutTitle;
        }

        [Then(@"the expected logout title should be displayed")]
        public void ExpectedAndActualLogoutTitleComparison()
        {
            Assert.AreEqual(ExpectedResults.expectedTitleAfterLogout, actualLogoutTitle);
        }

        [AfterScenario]
        public static void CleanUp()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
            Browser.Quit();
        }
    }
}