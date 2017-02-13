using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcumaticaTask;
using System.Xml;


namespace AcumaticaTask
{
    class Tests: PageObject
    {
       

        static void Main(string[] args)
        {
            TestParams testparams = new TestParams();

            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load("C:\\Users\\Roman\\Desktop\\AcumaticaTask\\XMLFile1.xml");
            XmlElement xRoot = Xdoc.DocumentElement;
            foreach (XmlElement xNode in xRoot)
            {
                XmlNode browser = xNode.Attributes.GetNamedItem("browser");
                testparams._BrowserName = browser.Value;

                foreach (XmlNode chilnode in xNode.ChildNodes)
                {
                    if (chilnode.Name == "UserName")
                        testparams._UserName = chilnode.InnerText;
                    if (chilnode.Name == "Passwd")
                        testparams._Passwd = chilnode.InnerText;
                    if (chilnode.Name == "MsgReciever")
                        testparams._MsgReciever = chilnode.InnerText;
                }
            }

            
            OpenBrowser(testparams._BrowserName);
            Navigate("https://accounts.google.com/");


            AccountPage fillAcccountName = new AccountPage();
            PasswordPage nameAccount = fillAcccountName.FillAccauntPage(testparams._UserName);
            MyAccountPage login = nameAccount.FillPasswordPage(testparams._Passwd);
            MailBoxPage MsgBoxPage = login.OpenMailBox();
            NewMessageWindow MsgWindow = MsgBoxPage.OpenNewMsgWindow();
            MsgWindow.SendMsg(testparams._MsgReciever, "Возьмите меня на работу =)", "MsgTxt");

            OpenBrowser(testparams._BrowserName);
            Navigate("https://accounts.google.com/");

            //First commit with GitHub

            QuitBrowser();

        }
    }
}
