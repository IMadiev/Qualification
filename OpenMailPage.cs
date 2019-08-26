using System;
using OpenQA.Selenium;

namespace Qualification
{
    class OpenMailPage
    {
        string textXPATHSelector = "//div[@class = 'letter__body']//div[@textContent= '";
        By authorSelector = By.CssSelector(".letter__author>span");

        private Browser browser;
        private Elements element;

        public OpenMailPage(Browser browser)
        {
            this.browser = browser;
            if (!browser.checkURL("https://e.mail.ru/inbox"))
            {
                throw new Exception("Неверный url почтового ящика");
            }
            element = new Elements(browser);
        }

        public string getAuthor()
        {
            return browser.element(authorSelector).GetAttribute("title");
        }

        public bool checkText(string text)
        {
            try
            {
                browser.element(By.XPath(textXPATHSelector + text + "']"));
                return true;
            }
            catch (NoSuchElementException er)
            {
                Console.Out.WriteLine(er.StackTrace);
                return false;
            }
        }
    }
}
