using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AcumaticaTask
{
    class Browser
    {
        protected static IWebDriver _webDriver;
        
        public static IWebDriver OpenBrowser(string BrowserName)
        {
            
            if (_webDriver != null) return _webDriver;

            switch (BrowserName)
            {
                case "Firefox":
                    _webDriver = new FirefoxDriver();
                    break;
                case "Chrome":
                    _webDriver = new ChromeDriver();
                    break;
                default:
                    throw new Exception(string.Format("Unknown browser selected: {0}.", BrowserName));
            }

            _webDriver.Manage().Window.Maximize();
            
            return _webDriver;
        }

     
        public static void QuitBrowser()
        {
            if (_webDriver == null) return;

            _webDriver.Quit();
            _webDriver = null;
        }

        public static void Navigate(string URL)
        {
            _webDriver.Navigate().GoToUrl(URL);
        }

        public static string GetTitle
        { get { return _webDriver.Title; } }

        public static void SwitchFrame(string FrameLocator, string TypeOfLocator)
        {
            string frameLocator;
            switch (TypeOfLocator)
            {
                case "Id":
                    
                        frameLocator = FrameLocator;
                        break;
                    
                case "ClassName":
                    
                        frameLocator = FrameLocator;
                        break;
                    
                default:
                    throw new Exception(string.Format("Unknown TypeOfLocator: {0}", TypeOfLocator)); 
            }

            _webDriver.SwitchTo().Frame(frameLocator);
        }

        public static void Wait(double time)
        {
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(time));
        }

        public static void exWait()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public static void pageLoadWait(double time)
        {
            _webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(time));
        }
    }
}
