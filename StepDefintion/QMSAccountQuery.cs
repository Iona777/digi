using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Digital.ComponentHelper;
using Digital.PageObject;
using Digital.Settings;

namespace Digital.StepDefinition
{
    [Binding]
    public sealed class QMSAccountQuery
    {
//        private qmsAccountQuery_Login loginPage;
//        private qmsAccountQuery_Account accountPage;

        #region Given
        [Given(@"I am on ""(.*)""")]
        public void GivenIAmOn(string p0)
        {
            NavigationHelper.NavigateToUrl(p0);
            ObjectRepository.loginPage = new qmsAccountQuery_Login(ObjectRepository.Driver);
//            Thread.Sleep(1000);
        }

        #endregion

        #region When
        [When(@"I login")]
        public void WhenILogin()
        {
            ObjectRepository.accountPage = ObjectRepository.loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            Thread.Sleep(1000);
        }
        [When(@"I logout")]
        public void WhenILogout()
        {
            ObjectRepository.accountPage.Logout();
        }
        [When(@"I login ""(.*)""")]
        public void WhenILogin(string p0)
        {
            ObjectRepository.accountPage = ObjectRepository.loginPage.Login(p0, "focusit21");
            Thread.Sleep(1000);
        }

        #endregion

        #region Then
        [Then(@"the ""(.*)"" page is displayed")]
        public void ThenThePageIsDisplayed(string p0)
        {
            ObjectRepository.accountPage.CheckUrl(p0);
            Thread.Sleep(1000);
        }
        [Then(@"""(.*)"" is logged in")]
        public void ThenIsLoggedIn(string p0)
        {
            ScenarioContext.Current.Pending();
            Thread.Sleep(1000);
        }


        #endregion
    }
}
