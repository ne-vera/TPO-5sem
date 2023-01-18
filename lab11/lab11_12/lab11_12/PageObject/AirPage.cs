using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class AirPage
    {
        private IWebDriver _driver;

        public AirPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _btnAirPorts = By.XPath("//a[@href='/air/ports']");
        private readonly By _btnShopenPort = By.XPath("//a[@href='/air/ports/poland/WAW']");
        private readonly By _btnDate = By.XPath("//a[@class='cascoon-month-cell cascoon-month-cell--filled cascoon-month-cell--best']");
        private readonly By _btnMonth = By.XPath("//button[@class='cascoon-year-cell cascoon-year-cell--filled cascoon-year-cell--best']");

        public void ClickAirPorts()
        {
            _driver.FindElement(_btnAirPorts).Click();
        }

        public void ClickShopenPort() 
        {
            _driver.FindElement(_btnShopenPort).Click();
        }

        public void ClickBestPrice() 
        {   
            string js = string.Format("window.scroll(0, {0});", 1200);
            ((IJavaScriptExecutor)_driver).ExecuteScript(js);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnMonth));
            _driver.FindElement(_btnMonth).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(e => e.FindElement(_btnDate));
            _driver.FindElement(_btnDate).Click();
        }
    }
}
