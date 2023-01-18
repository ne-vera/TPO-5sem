using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class VisasPage
    {
        private IWebDriver _driver;

        private readonly By _btnSelectCountry = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[1]/div/a[2]");
        private readonly By _btnSelectAustralia = By.XPath("//a[text()='Австралия']");
        private readonly By _btnSelectArrivalType = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[2]/div/a[2]");
        private readonly By _btnSelectOnce = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[2]/div/ul/div[1]/div/li[2]/a");
        private readonly By _btnSelectArrivalGoal = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[3]/div/a[2]");
        private readonly By _btnSelectBusiness = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[3]/div/ul/div[1]/div/li[2]/a");
        private readonly By _btnSearchVisa = By.XPath("//*[@id=\'main_search\']/form[1]/button");
        private readonly By _searchResults = By.XPath("//span[@class='tour-section-tfName']");

        public VisasPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SetVisaFilters()
        {
            _driver.FindElement(_btnSelectCountry).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(_btnSelectAustralia).Click();

            _driver.FindElement(_btnSelectArrivalType).Click();
            _driver.FindElement(_btnSelectOnce).Click();

            _driver.FindElement(_btnSelectArrivalGoal).Click();
            _driver.FindElement(_btnSelectBusiness).Click();

        }

        public void ClickBtnSearchVisa()
        {
            _driver.FindElement(_btnSearchVisa).Click();
        }

        public bool CheckVisaSearchResults()
        {
            return _driver.FindElements(_searchResults).Select(t => t.Text).All(t => t.ToLower().Contains("туристическая"));
        }
    }
}
