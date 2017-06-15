using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Digital.Settings;

namespace Digital.ComponentHelper
{
    public class DataEntryHelper
    {
        public static WebDriverWait helperWait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(30));

        public static void changeImplicitWaitTime(int seconds)
        {
            helperWait.Timeout = TimeSpan.FromSeconds(seconds);
        }

        public static void EnterText(string input, IWebElement element)
        {
            helperWait.Until(ExpectedConditions.ElementToBeClickable(element)).SendKeys(input);
        }

        public static void SelectFreqByValue(string frequency, IWebElement freqElement)
        {
            helperWait.Until(ExpectedConditions.ElementToBeClickable(freqElement));
            SelectElement selector = new SelectElement(freqElement);

            Thread.Sleep(250);
            selector.SelectByValue(frequency);
        }


        public static void SelectFreqByText(string frequency, IWebElement freqElement)
        {
            helperWait.Until(ExpectedConditions.ElementToBeClickable(freqElement));
            SelectElement selector = new SelectElement(freqElement);

            Thread.Sleep(250);
            selector.SelectByText(frequency);
        }

        public static void ButtonClick(IWebElement element)
        {
            helperWait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void WaitForElementByXpath(string elementLocator)
        {
            helperWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementLocator)));
        }

        public static void WaitForElementByCSS(string elementLocator)
        {
            helperWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(elementLocator)));
        }

        public static bool isElementVisible(string elementLocator, int noOfSecondsToWait)
        {
            helperWait.Timeout = TimeSpan.FromSeconds(noOfSecondsToWait);
            bool isVisible = isElementVisible(elementLocator);
            helperWait.Timeout = TimeSpan.FromSeconds(30);
            return isVisible;
        }

        public static bool isElementVisible(string elementLocator)
        {
            try
            {
                helperWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementLocator)));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
