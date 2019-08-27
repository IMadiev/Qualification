using System;
using OpenQA.Selenium;

namespace Qualification.Source
{
    class LoginPage
    {
        By frame = By.XPath("//iframe");
        By loginSelector = By.Name("Login");
        By passwordSelector = By.Name("Password");
        By nextButtonSelector = By.XPath("//button[@data-test-id = 'next-button']");
        By submitButtonSelector = By.XPath("//button[@data-test-id = 'submit-button']");

        private Browser browser;
        private Elements element;

        public LoginPage(Browser browser)
        {
            this.browser = browser;
            if (!browser.checkURL("https://e.mail.ru/login"))
            {
                throw new Exception("Неверный url страницы логина");
            }
            element = new Elements(browser);
        }

        private void typeLogin(string username)
        {
            element.text(loginSelector).clear();
            element.text(loginSelector).sendKeys(username);
        }

        private void typePassword(string password)
        {
            element.text(passwordSelector).clear();
            element.text(passwordSelector).sendKeys(password);
        }

        private HomePage hitSubmitButton()
        {
            element.button(submitButtonSelector).click();
            browser.switchToDefault();
            return new HomePage(browser);
        }

        public HomePage login(string login, string password)
        {
            browser.switchTo(frame);
            typeLogin(login);
            typePassword(password);
            return hitSubmitButton();
        }
    }
}
