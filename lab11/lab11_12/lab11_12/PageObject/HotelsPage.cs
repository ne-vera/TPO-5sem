using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class HotelsPage
    {
        private IWebDriver _driver;

        public HotelsPage(IWebDriver driver)
        {
            _driver = driver; 
        }

        private readonly By _btnSelectCountry = By.XPath("//*[@id=\"select2-select-country-container\"]");
        private readonly By _input = By.XPath("//input[@class='select2-search__field']");

        private readonly By _btnSelectCity = By.XPath("//*[@id=\"select2-select-city-container\"]");

        private readonly By _btnHotelLevel = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[1]/div/label");
        private readonly By _btnFiveStars = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[1]/div/div/div[1]/label/div");

        private readonly By _btnCoastline = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[2]/div/label");
        private readonly By _btnFirstCoastline = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[2]/div/div/div[1]/label");

        private readonly By _btnBeach = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[3]/div/label");
        private readonly By _btnSandBeach = By.XPath("//*[@id=\"hotel-search\"]/div[3]/div[3]/div/div/div[1]/label");

        private readonly By _labelLocation = By.XPath("//div[@class='category-breadcrumbs']");
        private readonly By _labelFeatures = By.XPath("//div[@class='data-in-icons-auto-width']");

        public void SetFilters()
        {
            _driver.FindElement(_btnSelectCountry).Click();
            _driver.FindElement(_input).SendKeys("Греция");
            _driver.FindElement(_input).SendKeys(Keys.Enter);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnSelectCity));
            _driver.FindElement(_btnSelectCity).Click();
            _driver.FindElement(_input).SendKeys("Закинф");
            _driver.FindElement(_input).SendKeys(Keys.Enter);

            _driver.FindElement(_btnHotelLevel).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnFiveStars));
            _driver.FindElement(_btnFiveStars).Click();

            _driver.FindElement(_btnCoastline).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnFirstCoastline));
            _driver.FindElement(_btnFirstCoastline).Click();

            _driver.FindElement(_btnBeach).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnSandBeach));
            _driver.FindElement(_btnSandBeach).Click();
        }

        public bool ChechHotels()
        {
            bool isGreece = _driver.FindElements(_labelLocation).Select(t=>t.Text).All(t => t.ToLower().Contains("греции"));
            bool isZakynthos = _driver.FindElements(_labelLocation).Select(t => t.Text).All(t => t.ToLower().Contains("закинф"));
            bool isFirstCoastline = _driver.FindElements(_labelFeatures).Select(t => t.Text).All(t => t.ToLower().Contains("1-ая линия"));
            bool isSandBeach = _driver.FindElements(_labelFeatures).Select(t => t.Text).All(t => t.ToLower().Contains("песчаный"));
            return isGreece && isFirstCoastline && isSandBeach;
        }
    }
}
