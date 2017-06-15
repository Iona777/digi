using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;


namespace Digital.PageObject
{
    public class digitalUmbracoMemberDetails : PageBase
    {
        private IWebDriver driver;

        public const string MembershipTabLocator = "//*[@href='#tab47']";
        public const string LowellTabLocator = "//*[@href='#tab1119']";
        public const string LogonTabLocator = "//*[@href='#tab1120']";
        public const string TokenDetailsTabLocator = "//*[@href='#tab1134']";
        public const string EmailTabLocator = "//*[@href='#tab1173']";
        public const string PropertiesTabLocator = "//*[@href='#tab0']";
        public const string IsMemberApprovedCheckboxLocator = "//*[@id='umbracoMemberApproved']";
        public const string IsMemberLockedOutCheckboxLocator = "//*[@id='umbracoMemberLockedOut']";
        public const string SaveButtonLocator = "//*[@class='btn btn-success']";
        public const string ChangePasswordButtonLocator = "//*[@class='btn btn-small']";
        public const string NewPasswordTextboxLocator = "//*[@name='password']";
        public const string ConfirmPasswordTextboxLocator = "//*[@name='confirmpassword']";
        public const string LastEditedTimeLocator = "//*[@id='tab0']/div/div/div/div[4]/ng-form/div/div[2]/div/div/div";
        public const string AvatarImageLocator = "//*[@id='avatar-img']";
        public const string LogoutButtonLocator = "//*[@class='umb-panel ng-scope']/div[1]/div/div/button";


        #region WebElement
        [FindsBy(How = How.XPath, Using = MembershipTabLocator)]
        private IWebElement MembershipTab;

        [FindsBy(How = How.XPath, Using = LowellTabLocator)]
        private IWebElement LowellTab;

        [FindsBy(How = How.XPath, Using = LogonTabLocator)]
        private IWebElement LogonTab;

        [FindsBy(How = How.XPath, Using = TokenDetailsTabLocator)]
        private IWebElement TokenDetailsTab;

        [FindsBy(How = How.XPath, Using = EmailTabLocator)]
        private IWebElement EmailTab;

        [FindsBy(How = How.XPath, Using = PropertiesTabLocator)]
        private IWebElement PropertiesTab;

        [FindsBy(How = How.XPath, Using = IsMemberApprovedCheckboxLocator)]
        private IWebElement IsMemberApprovedCheckbox;

        [FindsBy(How = How.XPath, Using = IsMemberLockedOutCheckboxLocator)]
        private IWebElement IsMemberLockedOutCheckbox;

        [FindsBy(How = How.XPath, Using = SaveButtonLocator)]
        private IWebElement SaveButton;

        [FindsBy(How = How.XPath, Using = ChangePasswordButtonLocator)]
        private IWebElement ChangePasswordButton;

        [FindsBy(How = How.XPath, Using = NewPasswordTextboxLocator)]
        private IWebElement NewPasswordTextbox;

        [FindsBy(How = How.XPath, Using = ConfirmPasswordTextboxLocator)]
        private IWebElement ConfirmPasswordTextbox;

        [FindsBy(How = How.XPath, Using = LastEditedTimeLocator)]
        private IWebElement LastEditedTime;

        [FindsBy(How = How.XPath, Using = AvatarImageLocator)]
        private IWebElement AvatarImage;

        [FindsBy(How = How.XPath, Using = LogoutButtonLocator)]
        private IWebElement LogoutButton;

        #endregion

        public digitalUmbracoMemberDetails(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public Boolean approveRegisteredUser()
        {
            DataEntryHelper.WaitForElementByXpath(PropertiesTabLocator);
            string lastEditedTime;
            PropertiesTab.Click();
            lastEditedTime = LastEditedTime.GetAttribute("innerText");
            MembershipTab.Click();
            if (IsMemberApprovedCheckbox.GetAttribute("checked") == null)
            {
                IsMemberApprovedCheckbox.Click();
                SaveButton.Click();
            }                        
            return isDataSaved(lastEditedTime);            
        }

        public void logout()
        {
            DataEntryHelper.ButtonClick(AvatarImage);
            DataEntryHelper.ButtonClick(LogoutButton);            
        }

        public Boolean isDataSaved(string lastEditedTime)
        {
            DataEntryHelper.WaitForElementByXpath(PropertiesTabLocator);
            PropertiesTab.Click();
            int i = 1;
            while ((LastEditedTime.GetAttribute("innerText")).Equals(lastEditedTime) && i < 4)
            {
                refresh();
                PropertiesTab.Click();
                lastEditedTime = LastEditedTime.GetAttribute("innerText");
                i++;
            }

            if (i == 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean resetPasswordForUser(string emailAddress, string password)
        {
            DataEntryHelper.WaitForElementByXpath(PropertiesTabLocator);
            PropertiesTab.Click();
            ChangePasswordButton.Click();
            NewPasswordTextbox.SendKeys(password);
            ConfirmPasswordTextbox.SendKeys(password);
            SaveButton.Click();

            string lastEditedTime;
            PropertiesTab.Click();
            lastEditedTime = LastEditedTime.GetAttribute("innerText");
            return isDataSaved(lastEditedTime);       
        }

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        #endregion
    }
}
