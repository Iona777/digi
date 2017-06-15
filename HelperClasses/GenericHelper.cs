using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Digital.Settings;
using System.Drawing.Imaging;

namespace Digital.ComponentHelper
{
    public class GenericHelper
    {

        public static WebDriverWait genericHelperWait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(30));

        public static string GetFirstFewChars(string inputString, int noOfChars)
        {
            string returnString = inputString.Substring(0,noOfChars);
            return returnString;
        }

        //Used for situations such as needing to return the numeric valuefrom a string like "£1.25"
        public static string GetValueAfterPoundSymbol(string inputString)
        {
            int stringLength = inputString.Length;
            string returnString=null;

            if (inputString.Substring(0,1)=="£")
            {
                returnString = inputString.Substring(1,stringLength-1 );
            }
            else
            {
                returnString = inputString;
            }
            
            return returnString;
        }

        //Use this to check for presence of element when you have the locator rather than the element
        public static bool IsElementDisplayed(By locator)
        {
            try
            {
                genericHelperWait.Until(ExpectedConditions.ElementIsVisible(locator));
                return ObjectRepository.Driver.FindElement(locator).Displayed;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
        }

        //Use this to check for presence of element when you have the element rather than the locator
        public static bool IsElementClickable(IWebElement element)
        {
            try
            {
                genericHelperWait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
        }


        public static bool IsElementEnabled(By locator)
        {
            if (IsElementDisplayed(locator))
            {
                return ObjectRepository.Driver.FindElement(locator).Enabled;
            }
            else
            {
                return false;
            }
        }

        //Overloaded method. This version takes the locator as paramenter
        public static string GetElementText(By locator)
        {
            var element = GenericHelper.GetElement(locator);
            if (element.GetAttribute("value") == null)
                return String.Empty;

            return element.GetAttribute("value");
        }

        //Overloaded method. This version takes the element as paramenter
        public static string GetElementText(IWebElement element)
        {
            if (IsElementClickable(element))
            {
                if (element.GetAttribute("value") == null)
                    return String.Empty;
                
                return element.GetAttribute("value");
            }
            else
            {
                TimeoutException t = new TimeoutException("Could not get element text because wait timed out");
                throw t;
            }
        }


        //This method returns number within a string
        public static int getNumberFromString(string input)
        {
            var getNumbers = (from t in input
                              where char.IsDigit(t)
                              select t).ToArray();
            try
            {
                return int.Parse(new string(getNumbers));
            }catch(FormatException e){
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                throw new FormatException("There is no number in the string passed to this method");
            }            
        }


        //Used to get the element referred to by given locator. 
        public static IWebElement GetElement(By locator)
        {
            if (IsElementDisplayed(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        //Useful if you need screenshots as evidence
        public static void TakeScreenShot(string filename)
        {
            var camera = ObjectRepository.Driver.TakeScreenshot();
            
            filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            camera.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            return;
        }

        
    }
}
