using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AcumaticaTask
{
    class PageObject: WebElement
    {
           
        public class AccountPage
        {

            public AccountPage()
            {
                PageFactory.InitElements(_webDriver, this);
            }

            public PasswordPage FillAccauntPage (string accountName)
            {
                AccountField.SendKeys(accountName);
                btnNext.Click();
                                               
                return new PasswordPage();  
            }
            
            [FindsBy(How = How.Id, Using = "Email")]
            private IWebElement AccountField { get; set; }

            [FindsBy(How = How.Id, Using = "next")]
            private IWebElement btnNext { get; set; }

        }

        public class PasswordPage
        {
            public PasswordPage()
            {
                PageFactory.InitElements(_webDriver, this);
            }

            public MyAccountPage FillPasswordPage(string accountPassword)
            {
                exWait();
                PasswdField.SendKeys(accountPassword);
                btnSignIn.Click();
                
                return new MyAccountPage();
            }

            [FindsBy(How = How.Id, Using = "Passwd")]
            public IWebElement PasswdField { get; set; }

            [FindsBy(How = How.Id, Using = "signIn")]
            public IWebElement btnSignIn { get; set; }

        }

        public class MyAccountPage
        {
            public MyAccountPage()
            {
                PageFactory.InitElements(_webDriver, this);
            }

            [FindsBy(How = How.CssSelector, Using = "#gbwa > div:nth-child(1)")]
            public IWebElement btnAccountSettings { get; set; }

            [FindsBy(How = How.CssSelector, Using = "#gb23 > span:nth-child(5)")]
            public IWebElement btnMailBox { get; set; }

            public MailBoxPage OpenMailBox()
            {
                exWait();
                btnAccountSettings.Click();
                exWait();
                btnMailBox.Click();
                exWait();

                return new MailBoxPage();
            }

        }


        public class MailBoxPage
        {
            public MailBoxPage()
            {
                PageFactory.InitElements(_webDriver, this);
            }

            [FindsBy(How = How.CssSelector, Using = ".T-I-KE")]
            public IWebElement btnWrite { get; set; }

            [FindsBy(How = How.XPath, Using = "#gb > div.gb_Me.gb_Mf > div.gb_jb.gb_Mf.gb_R.gb_Lf.gb_T > div.gb_oc.gb_Mf.gb_R > div.gb_gb.gb_Oc.gb_Mf.gb_R.gb_g > div.gb_zc.gb_ib.gb_Mf.gb_R > a")]
            public IWebElement btnAccount { get; set; }

            [FindsBy(How = How.Id, Using = "gb_71")]
            public IWebElement btnLogOut { get; set; }

            public void LogOut()
            {
                btnAccount.Click();
                btnLogOut.Click();
            }

            public NewMessageWindow OpenNewMsgWindow()
            {
                exWait();
                btnWrite.Click();
                
                return new NewMessageWindow();
            }

        }

            public class NewMessageWindow
            {
                public NewMessageWindow()
                {
                    PageFactory.InitElements(_webDriver, this);
                }  
                
                [FindsBy(How = How.XPath, Using = "//textarea[@aria-label='Кому']")]
                public IWebElement fieldMailReciver { get; set; }

                [FindsBy(How = How.XPath, Using = "//input[@placeholder='Тема']")]
                public IWebElement fieldMailTheme { get; set; }
                
                [FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Тело письма')]")]
                public IWebElement fieldMsg { get; set; }
                
                [FindsBy(How = How.XPath, Using = "//div[@aria-label='Отправить ‪(Ctrl + Enter)‬']")]
                public IWebElement btnSendMsg { get; set; }

                [FindsBy(How = How.Id, Using = "#\\:5h")]
                public IWebElement btnClose { get; set; }

                public void SendMsg(string MailReciver, string MsgTheme, string MsgText) 
            {
                    exWait();
                    fieldMailReciver.SendKeys(MailReciver);
                    fieldMailTheme.Click();
                    fieldMailTheme.SendKeys(MsgTheme);
                    fieldMsg.Click();
                    fieldMsg.SendKeys(MsgText);                    
                    btnSendMsg.Click();
                }

                public void CloseMsgWindow()
                {
                    btnClose.Click();
                }
            }
        
    }
}
