using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AcumaticaTask
{
     class WebElement: Browser
    {
           

                public static void EnterText (IWebDriver _webDriver, string element, string value, string elementType)
            {
            switch (elementType)
                 {
                case "Id":
                    _webDriver.FindElement(By.Id(element)).SendKeys(value) ;
                    break;
                case "Name":
                    _webDriver.FindElement(By.Name(element)).SendKeys(value) ;
                    break;
                case "ClassName":
                    _webDriver.FindElement(By.ClassName(element)).SendKeys(value);
                    break;
                case "CssSelector":
                    _webDriver.FindElement(By.CssSelector(element)).SendKeys(value);
                    break;
                case "XPath":
                    _webDriver.FindElement(By.XPath(element)).SendKeys(value);
                    break;
                default:
                    throw new Exception(string.Format("Unknown element type: {0}.", elementType));
                } 
           }

        public static void ClickOnElement(IWebDriver _webDriver, string element, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    _webDriver.FindElement(By.Id(element)).Click();
                    break;
                case "Name":
                    _webDriver.FindElement(By.Name(element)).Click();
                    break;
                case "ClassName":
                    _webDriver.FindElement(By.ClassName(element)).Click();
                    break;
                case "XPath":
                    _webDriver.FindElement(By.XPath(element)).Click();
                    break;
                case "LinkText":
                    _webDriver.FindElement(By.LinkText(element)).Click();
                    break;
                case "CssSelector":
                    _webDriver.FindElement(By.CssSelector(element)).Click();
                    break;
                default:
                    throw new Exception(string.Format("Unknown element type: {0}.", elementType));
                    
            }
        }
    }
}
