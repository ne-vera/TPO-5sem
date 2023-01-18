using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class BelarusPage
    {
        private IWebDriver _driver;
        private readonly By _btnType = By.XPath("//*[@id='search-belarus']/span/span[1]/span/span[2]");
        private readonly By _btnVilla = By.XPath("//ul[@id=\'select2-select-type-results\']/li[text()='Усадьба']");
        private readonly By _btnRegion = By.XPath("//*[@id=\"all\"]/div[1]/form/div[2]/span/span[1]/span/span[2]");
        private readonly By _btnMinskRegion = By.XPath("//ul[@id=\'select2-select-region-results\']/li[text()='Минская область']");
        private readonly By _inputGuestAmount = By.XPath("//*[@id=\"select-guests\"]");
        private readonly By _btnSearch = By.XPath("//*[@id=\"all\"]/div[1]/form/div[4]/button");
        private readonly By _labelHousingType = By.XPath("//p[@class='housing-type']");
        private readonly By _labelGuestsNum = By.XPath("//div[@class='additional-data']/span");
        private readonly By _btnSanatorium = By.XPath("//a[@href='/belarus/sanatoriums']");
        private readonly By _btnRespiratory = By.XPath("//*[@id=\"type-house\"]/div[1]/label");
        private readonly By _labelSanaotriumType = By.XPath("//*[@id=\"category-main\"]/header/div/div[2]/h1");

        public BelarusPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSanatorium()
        {
            _driver.FindElement(_btnSanatorium).Click();
        }
        public void ClickRespiratory() 
        {
            _driver.FindElement(_btnRespiratory).Click();
        }
        public bool CheckType()
        {
            return _driver.FindElement(_labelSanaotriumType).Text.Contains("органов дыхания");
        }

        public void SetFilters()
        {
            _driver.FindElement(_btnType).Click();
            _driver.FindElement(_btnVilla).Click();

            _driver.FindElement(_btnRegion).Click();
            _driver.FindElement(_btnMinskRegion).Click();

            _driver.FindElement(_inputGuestAmount).Click();
            _driver.FindElement(_inputGuestAmount).SendKeys("2");

            _driver.FindElement(_btnSearch).Click();
        }

        public bool CheckFilters()
        {
            bool housingType = _driver.FindElements(_labelHousingType).Select(t => t.Text).All(t => t.ToLower().Contains(""));

            List<int> guestsNumList = new List<int>();
            foreach (var item in _driver.FindElements(_labelGuestsNum))
            {
                string resultString;
                resultString = Regex.Match(item.Text, @"\d+").Value;
                guestsNumList.Add(Int32.Parse(resultString));
            }
            bool guestsNum = guestsNumList.All(t => t > 2);
            return housingType && guestsNum;
        }
    }
}
