using System;
using OpenQA.Selenium;

namespace Qualification
{
    class HomePage
    {
        By writeMailSelector = By.XPath("//span[@title = 'Написать письмо']");
        By mailSelector = By.CssSelector(".llc__subject_unread");
        By logoutSelector = By.XPath("//a[@title = 'выход']");

        private Browser browser;
        private Elements element;

        public HomePage(Browser browser)
        {
            this.browser = browser;
            if (!browser.checkURL("https://e.mail.ru/inbox"))
            {
                throw new Exception("Неверный url почтового ящика");
            }
            element = new Elements(browser);
        }

        public NewMailPage hitWriteButton()
        {
            element.button(writeMailSelector).click();
            return new NewMailPage(browser);
        }

        public void logout()
        {
            element.button(logoutSelector).click();
        }

        public OpenMailPage findMail(string subject)
        {
            try
            {
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements = browser.elements(mailSelector);
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Text == subject)
                    {
                        elements[i].Click();
                        return new OpenMailPage(browser);
                    }
                }
                throw new NoSuchElementException("Письма с заданной темой не найдено");
            }
            catch (NoSuchElementException er)
            {
                Console.Out.Write(er.StackTrace);
                return null;
            }
        }
    }
}
