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
    public class digitalTermsAndConditions : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string TermsAndConditionsContentLocator = "/html/body/div[3]/div";        

        #region WebElement
        [FindsBy(How = How.XPath, Using = TermsAndConditionsContentLocator)]
        private IWebElement TermsAndConditionsContent;
        #endregion

        public digitalTermsAndConditions(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public Boolean isThePageTermsAndConditionsPage()
        {
            if (((IWebElement)TermsAndConditionsContent).Text.Contains("PLEASE READ THESE TERMS AND CONDITIONS CAREFULLY BEFORE USING THIS SITE"))
            {
                return true;
            }
            return false;
        }

        public int CheckContent()
        {
            string textContentInFile = File.ReadAllText("..\\..\\Resources\\TermsAndConditionsContent.txt");
            string textContentInWeb = ((IWebElement)TermsAndConditionsContent).Text;
            textContentInFile = textContentInFile.Replace("\r", "");
            textContentInFile = textContentInFile.Replace("\n", "").Trim();
            textContentInWeb = textContentInWeb.Replace("\r", "");
            textContentInWeb = textContentInWeb.Replace("\n", "").Trim();
            /*if (string.Compare(textContentInWeb, textContentInFile)!=0)
            {
                List<string> diff;
                IEnumerable<string> set1 = textContentInFile.Split(' ').Distinct();
                IEnumerable<string> set2 = textContentInWeb.Split(' ').Distinct();

                if (set2.Count() > set1.Count())
                {
                    diff = set2.Except(set1).ToList();
                }
                else
                {
                    diff = set1.Except(set2).ToList();
                }
                ObjectRepository.writer.WriteToLog("The difference is");
                string st="";
                foreach(string s in diff){
                    st = st + " " +s;
                }
                ObjectRepository.writer.WriteToLog(st);
                ObjectRepository.writer.FlushLog();
            }
             if (string.Compare(textContentInWeb, textContentInFile) != 0)
            {
                throw new AssertFailedException("Complete a Budget Calculator journey with Monthly Frequency test has failed", e);
            }
             */
            return string.Compare(textContentInWeb, textContentInFile);
                                   
        }
        #endregion

    }
}
