using System;
using OpenQA.Selenium;

namespace Qualification
{
    class NewMailPage
    {
        By recipientSelector = By.XPath("//*[@data-name = 'to']//input");
        By subjectSelector = By.XPath("//*[@class = 'container--3QXHv']//input");
        By mailBodySelector = By.XPath("//*[@role='textbox']");
        By sendMailSelector = By.XPath("//span[@title = 'Отправить']");
        By closeSelector = By.XPath("//span[@title = 'Закрыть']//*[@class = 'button2__ico']");

        private Browser browser;
        private Elements element;

        public NewMailPage(Browser browser)
        {
            this.browser = browser;
            if (!browser.checkURL("https://e.mail.ru/inbox"))
            {
                throw new Exception("Неверный url страницы");
            }
            element = new Elements(browser);
        }

        private void typeRecipient(string to)
        {
            element.text(recipientSelector).clear();
            element.text(recipientSelector).sendKeys(to);
        }

        private void typeSubject(string subject)
        {
            element.text(subjectSelector).clear();
            element.text(subjectSelector).sendKeys(subject);
        }

        private void typeMail(string mail)
        {
            element.text(mailBodySelector).clear();
            element.text(mailBodySelector).sendKeys(mail);
        }

        private void hitSendButton()
        {
            element.button(sendMailSelector).click();
        }

        private void hitCloseButton()
        {
            element.button(closeSelector).click();
        }

        public void sendMail(string to, string subject, string mail)
        {
            typeRecipient(to);
            typeSubject(subject);
            typeMail(mail);
            hitSendButton();
            hitCloseButton();
        }
    }
}
