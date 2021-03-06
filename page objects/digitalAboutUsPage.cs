﻿using System;
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
    public class digitalAboutUsPage : digitalNavigationBar
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = "//*[@id='layout-main']")]
        private IWebElement AboutUsText;

        #endregion

        public digitalAboutUsPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
    }
}
