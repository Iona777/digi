﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Digital.Settings;

namespace Digital.ComponentHelper
{
    public class JavaScriptPopHelper
    {
        public static bool IsPopupPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopupText()
        {
            if (!IsPopupPresent())
                return String.Empty;
            return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeysOnOPopup(string text)
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
