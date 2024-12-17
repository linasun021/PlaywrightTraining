using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TrainingAutomationFramework.UI.Utilities;
using UITestProject.Models.Components.Dialogs;
using UITestProject.Models.Data;
using UITestProject.Models.Data.DTO;
using UITestProject.Models.Pages;
using UITestProject.Support;
using static System.Net.Mime.MediaTypeNames;

namespace UITestProject.StepDefinitions
{
    [Binding]
    public class LoginSteps : BaseSteps
    {

        public LoginSteps(IObjectContainer objectContainer, ISpecFlowOutputHelper specFlowOutputHelper) : base(objectContainer, specFlowOutputHelper) { }

        [Given(@"Home page has been load")]
        public void GivenHomePageHasBeenLoad()
        {
            //new HomePage(page).IsPageLoaded().Should().BeTrue();
            Assertions.Expect(new HomePage(page).JupiterPrimeLogo).ToBeVisibleAsync().Wait();
        }

        [When(@"I login via user (.*)")]
        public void WhenILoginUsingUserUser(string userKey)
        {
            User currentUser =TestDataLoader.LoadUser(userKey);
            specFlowOutputHelper.WriteLine($"Current user is {currentUser.UserName}");
            var homePage = new HomePage(page);
            var loginDialog = homePage.ClickLoginMenu();
            loginDialog.Login(currentUser.UserName, currentUser.Password);
        }


        [Then(@"User should see the incorrect login error message")]
        public void ThenUserShouldSeeTheIncorrectLoginErrorMessage()
        {
            //new LoginDialog<HomePage>(page, new HomePage(page)).VerifyLoginWarningDisplayed().Should().BeTrue();
            Assertions.Expect(new LoginDialog<HomePage>(page, new HomePage(page)).LoginWarning).ToBeVisibleAsync().Wait();
        }
    }

}
