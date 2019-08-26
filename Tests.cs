using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace Qualification
{
    [TestFixture]
    class Tests
    {
        Browser browser;

        string browserName;
        string driverPath;
        string senderMail;
        string senderPassword;
        string recipientMail;
        string recipientPassword;

        [OneTimeSetUp]
        public void oneTimeSetup()
        {
            XDocument xml = XDocument.Load("configuration.xml");
            browserName = xml.Element("configuration").Element("browser").Attribute("name").Value;
            driverPath = xml.Element("configuration").Element("browser").Attribute("path").Value;
            senderMail = xml.Element("configuration").Element("userdata").Element("sender").Attribute("mail").Value;
            senderPassword = xml.Element("configuration").Element("userdata").Element("sender").Attribute("password").Value;
            recipientMail = xml.Element("configuration").Element("userdata").Element("recipient").Attribute("mail").Value;
            recipientPassword = xml.Element("configuration").Element("userdata").Element("recipient").Attribute("password").Value;
        }

        [SetUp]
        public void setup()
        {
            browser = new Browser(browserName, driverPath);
        }

        [TearDown]
        public void tearDown()
        {
            browser.close();
        }

        [OneTimeTearDown]
        public void oneTimeTearDown()
        {
        }

        [Test, Order(1)]
        public void sendMailTest()
        {
            browser.openURL("https://e.mail.ru/login");
            LoginPage loginPage = new LoginPage(browser);
            HomePage homePage = loginPage.login(senderMail, senderPassword);
            NewMailPage newMailPage = homePage.hitWriteButton();
            newMailPage.sendMail(recipientMail, "Тема", "Текст письма");
            homePage.logout();
        }

        [Test, Order(2)]
        public void openMailTest()
        {
            browser.openURL("https://e.mail.ru/login");
            LoginPage loginPage = new LoginPage(browser);
            HomePage homePage = loginPage.login(recipientMail, recipientPassword);
            OpenMailPage openMailPage = homePage.findMail("Тема");
            Assert.AreEqual(senderMail, openMailPage.getAuthor(), "Автор письма не соответствует ожиданиям");
            Assert.IsTrue(openMailPage.checkText("Текст письма"), "Текст письма не соответствует ожиданиям");
            homePage.logout();
        }
    }
}
