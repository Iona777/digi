using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Digital.ComponentHelper
{
    public class RadioButtonHelper
    {
        private static IWebElement element;
        
        public static void ClickRadioButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        } 

        public static bool IsRadioButtonSelected(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string flag = element.GetAttribute("checked");

            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }

        //Overloaded version that takes the element rather than locator.
        public static bool IsRadioButtonSelected(IWebElement element)
        {
            string flag = element.GetAttribute("checked");

            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }

    }
}
