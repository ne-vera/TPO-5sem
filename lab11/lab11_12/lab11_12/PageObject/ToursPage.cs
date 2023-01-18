using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class ToursPage
    {
        private IWebDriver _driver;

        private readonly By _btnSelectCountry = By.XPath("//*[@id=\'left-search-tours\']/div[1]/div/span/span[1]/span/span[2]");
        private readonly By _inputCountry = By.XPath("//input[@class='select2-search__field']");
        private readonly By _searchResult = By.XPath("//sub[@class='other-currency']");
        private readonly By _btnCheapFirst = By.XPath("//*[@id=\"category-main\"]/div[2]/div[1]/label[2]");

        private readonly By _labelPriceByn = By.XPath("//span[@class='price']");

        private readonly By _btnPromotion = By.XPath("//*[@id=\"left-search-tours\"]/div[7]/div/label");

        private readonly By _btnHotTour = By.XPath("//*[@id=\"left-search-tours\"]/div[7]/div/div/div[1]/label");
        private readonly By _btnEarlyBooking = By.XPath("//*[@id=\"left-search-tours\"]/div[7]/div/div/div[2]/label");

        public ToursPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SetFiltersCheapFirst()
        {
            _driver.FindElement(_btnSelectCountry).Click();
            _driver.FindElement(_inputCountry).SendKeys("Россия");
            _driver.FindElement(_inputCountry).SendKeys(Keys.Enter);
            _driver.FindElement(_btnCheapFirst).Click();
        }

        public void SetFiltersPormotion()
        {
            _driver.FindElement(_btnSelectCountry).Click();
            _driver.FindElement(_inputCountry).SendKeys("Беларусь");
            _driver.FindElement(_inputCountry).SendKeys(Keys.Enter);

            _driver.FindElement(_btnPromotion).Click();
            _driver.FindElement(_btnHotTour).Click();
            _driver.FindElement(_btnEarlyBooking).Click();
        }

        public bool CheckSortAsc()
        {
            List<int> pricesList = new List<int>();
            foreach (var item in _driver.FindElements(_searchResult))
            {
                string resultString;
                resultString = Regex.Match(item.Text, @"\d+").Value;
                pricesList.Add(Int32.Parse(resultString));
            }
            var expectedOrder = pricesList.OrderBy(t => t);
            return pricesList.SequenceEqual(expectedOrder);
        }

        public bool CheckPriceLimit()
        {
            List<int> pricesList = new List<int>();
            foreach (var item in _driver.FindElements(_labelPriceByn))
            {
                string resultString;
                resultString = Regex.Match(item.Text, @"\d+").Value;
                pricesList.Add(Int32.Parse(resultString));
            }

            return pricesList.All(t => t <= 2000);
        }

        public bool ChechPromotions()
        {
            bool hotSelected = _driver.FindElement(By.XPath("//*[@id=\"hot\"]")).Selected;
            bool earlySelected = _driver.FindElement(By.XPath("//*[@id=\"earlybooking\"]")).Selected;

            return hotSelected && earlySelected;
        }
    }
}
