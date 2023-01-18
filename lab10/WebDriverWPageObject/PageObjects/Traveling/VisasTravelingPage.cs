using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Traveling
{
    public class VisasTravelingPage : BasePage
    {
        public VisasTravelingPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        private IWebElement _btnSelectCountry;
        private IWebElement _btnSelectAustralia;
        private IWebElement _btnSelectArrivalType;
        private IWebElement _btnSelectOnce;
        private IWebElement _btnSelectArrivalGoal;
        public IWebElement _btnSelectBusiness;
        private IWebElement _btnSearchVisa;
        private IList<IWebElement> _visaSearchResults;

        public void SetVisaFilters()
        {
            _btnSelectCountry = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[1]/div/a[2]"));
            _btnSelectCountry.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _btnSelectAustralia = driver.FindElement(By.XPath("//a[text()='Австралия']"));
            _btnSelectAustralia.Click();

            _btnSelectArrivalType = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[2]/div/a[2]"));
            _btnSelectArrivalType.Click();

            _btnSelectOnce = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[2]/div/ul/div[1]/div/li[2]/a"));
            _btnSelectOnce.Click();

            _btnSelectArrivalGoal = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[3]/div/a[2]"));
            _btnSelectArrivalGoal.Click();

            _btnSelectBusiness = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[1]/div/div[3]/div/ul/div[1]/div/li[2]/a"));
            _btnSelectBusiness.Click();
        }

        public void ClickBtnSearchVisa()
        {
            _btnSearchVisa = driver.FindElement(By.XPath("//*[@id=\'main_search\']/form[1]/button"));
            _btnSearchVisa.Click();
        }

        public bool CheckVisaSearchResults()
        {
            _visaSearchResults = driver.FindElements(By.XPath("//span[@class='tour-section-tfName']"));
            return _visaSearchResults.Select(t => t.Text).All(t => t.ToLower().Contains("туристическая"));
        }
    }
}
