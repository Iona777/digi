using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;


namespace Digital.PageObject
{
    public class digitalDDGuarantee : digitalNavigationBar
    {
        private IWebDriver driver;


        
        public const string DDGuaranteeContentLocator = "[src='https://testdigital.lowellgroup.co.uk/media/1057/dd.pdf']";        

        #region WebElement
        [FindsBy(How = How.CssSelector, Using = DDGuaranteeContentLocator)]
        private IWebElement DDGuaranteeContent;
        #endregion


        

        public digitalDDGuarantee(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public bool isThePageDDGuaranteePage(string ddGuaranteeURL)
        {
            string expectedSrc = ddGuaranteeURL;

            ////Need to switch to the DD Guarantee window to find the element
            ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[1]);

            IWebElement ddContent = driver.FindElement(By.Id("plugin"));
            String Value = ddContent.GetAttribute("src");

            //Close window and switch back
            ObjectRepository.Driver.Close();
            ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[0]);

            if (Value == expectedSrc)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion

    }
}
