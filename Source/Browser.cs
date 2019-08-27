using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Qualification.Source
{
    class Browser
    {
        private IWebDriver driver;

        public Browser(string browserName, string path)
        {
            if (browserName == "Chrome")
            {
                driver = new ChromeDriver(path);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Manage().Window.Maximize();
            }
            else if (browserName == "Firefox")
            {
                driver = new FirefoxDriver(path);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Manage().Window.Maximize();
            }
            else
            {
                throw new Exception("Выбран некорректный браузер. Необходим Chrome или Firefox");
            }
        }

        public void openURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void close()
        {
            driver.Close();
        }

        public IWebElement element(By selector)
        {
            try
            {
                return driver.FindElement(selector);
            }
            catch (NoSuchElementException er)
            {
                Console.WriteLine(er.StackTrace);
                return null;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements(By selector)
        {
            try
            {
                return driver.FindElements(selector);
            }
            catch (NoSuchElementException er)
            {
                Console.WriteLine(er.StackTrace);
                return null;
            }
        }

        public bool checkURL(string substring)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(ExpectedConditions.UrlContains(substring));
                return true;
            }
            catch (WebDriverTimeoutException er)
            {
                Console.Out.Write(er.StackTrace);
                return false;
            }
        }

        public void switchTo(By selector)
        {
            driver.SwitchTo().Frame(driver.FindElement(selector));
        }

        public void switchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}

