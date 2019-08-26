using OpenQA.Selenium;

namespace Qualification
{
    class Elements
    {
        protected Browser browser;

        public Elements(Browser browser)
        {
            this.browser = browser;
        }

        public Text text(By selector)
        {
            return new Text(browser, selector);
        }
        public Button button(By selector)
        {
            return new Button(browser, selector);
        }


        public class Text
        {
            private IWebElement element;
            public Text(Browser browser, By selector)
            {
                this.element = browser.element(selector);
            }

            public void clear()
            {
                element.Clear();
            }

            public void sendKeys(string value)
            {
                element.SendKeys(value);
            }
        }
        public class Button
        {
            private IWebElement element;
            public Button(Browser browser, By selector)
            {
                this.element = browser.element(selector);
            }

            public void click()
            {
                element.Click();
            }
        }
    }
}
