using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class AgenciesPage
    {
        private IWebDriver _driver;
        private readonly By _inputQuery = By.XPath("//input[@name='query']");
        private readonly By _btnSearchAgencies = By.XPath("//a[@class='srch-all srch-hotels']");
        private readonly By _agenciesSearchResult = By.XPath("//div[@class='preview-info-box']/h3/a");


        public AgenciesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendTextToQuery()
        {
            _driver.FindElement(_inputQuery).Click();
            _driver.FindElement(_inputQuery).SendKeys("мастер");
        }

        public void ClickSearchHotels()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.XPath("//a[@class='srch-all srch-hotels']")));
            _driver.FindElement(_btnSearchAgencies).Click();
        }

        public bool CheckAgenciesSearchResults()
        {
            return _driver.FindElements(_agenciesSearchResult).Select(t => t.Text).All(t => t.ToLower().Contains("мастер"));
        }
    }
}
