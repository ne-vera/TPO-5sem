using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class NewPastebinPage : BasePage
    {
        public NewPastebinPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _firstLine = driver.FindElement(By.XPath("//div[@class='de1']"));
        private IList<IWebElement> _textFromInput = driver.FindElements(By.XPath("//li[@class='li1']"));

        public string GetTitle() => driver.Title;
        public string GetTextFromInput() => String.Join("", _textFromInput.Select(t => t.Text));
        public string GetFirstLine() => _firstLine.Text;
    }
}
