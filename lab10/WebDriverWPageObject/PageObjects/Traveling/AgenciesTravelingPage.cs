using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class AgenciesTravelingPage : BasePage
    {
        public AgenciesTravelingPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _inputQuery;
        private IWebElement _btnSearchHotels;
        private IList<IWebElement> _agenciesSearchResults;
        public void SendTextToQuery()
        {
            _inputQuery = driver.FindElement(By.XPath("//input[@name='query']"));
            _inputQuery.SendKeys("мастер");
        }
        public void ClickSearchHotels()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.XPath("//a[@class='srch-all srch-hotels']")));
            _btnSearchHotels = driver.FindElement(By.XPath("//a[@class='srch-all srch-hotels']"));
            _btnSearchHotels.Click();
        }

        public bool CheckAgenciesSearchResults()
        {
            _agenciesSearchResults = driver.FindElements(By.XPath("//div[@class='preview-info-box']/h3/a"));
            return _agenciesSearchResults.Select(t => t.Text).All(t => t.ToLower().Contains("мастер"));
        }
    }
}
