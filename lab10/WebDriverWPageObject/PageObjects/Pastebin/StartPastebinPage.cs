using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class StartPastebinPage : BasePage
    {
        public StartPastebinPage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement _btnSelectExpiration => driver.FindElement(By.Id("select2-postform-expiration-container"));
        private IWebElement _btn10Minutes => driver.FindElement(By.XPath("//li[text()='10 Minutes']"));
        private IWebElement _btnSelectSintaxHighlighting => driver.FindElement(By.Id("select2-postform-format-container"));
        private IWebElement _btnBash => driver.FindElement(By.XPath("//li[text()='Bash']"));
        private IWebElement _btnCreateNewPaste => driver.FindElement(By.XPath("//button[@class='btn -big']"));

        private IWebElement _inputTextArea => driver.FindElement(By.Id("postform-text"));
        private IWebElement _inputTitle => driver.FindElement(By.Id("postform-name"));

        public void ClickSelectExpiration() => _btnSelectExpiration.Click();
        public void ClickBtn10Minutes() => _btn10Minutes.Click();
        public void ClickSelectSintaxHighlighting() => _btnSelectSintaxHighlighting.Click();
        public void ClickBtnBash() => _btnBash.Click();
        public void ClickBtnCreateNewPaste() => _btnCreateNewPaste.Click();

        public void SendTextToInputTextArea(string text) => _inputTextArea.SendKeys(text);
        public void SendTextToTitle(string text) => _inputTitle.SendKeys(text);
    }
}
