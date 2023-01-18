using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class FellowsPage
    {
        private IWebDriver _driver;

        public FellowsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _btnAdvancedSearch = By.XPath("//span[text()='Расширенный поиск']");
        private readonly By _btnMyGender = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[2]/div/div[1]/div/a[2]");
        private readonly By _btnMyGenderMale = By.XPath("//*[@id=\"mCSB_5_container\"]/li[2]/a");
        private readonly By _btnFellowGender = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[2]/div/div[2]/div/a[2]");
        private readonly By _btnFellowGenderMale = By.XPath("//*[@id=\"mCSB_6_container\"]/li[2]/a");
        private readonly By _inputAgeFrom = By.XPath("//*[@id=\"f_age_from\"]");
        private readonly By _inputAgeTo = By.XPath("//*[@id=\"f_age_to\"]");
        private readonly By _btnDestination = By.XPath("/html/body/div[2]/div[2]/header/div/noindex/div/form[2]/div/div[5]/div/a[2]");
        private readonly By _btnDestinationEgypt = By.XPath("//*[@id=\"mCSB_7_container\"]/li[70]/a");
        private readonly By _btnSearch = By.XPath("//*[@id=\"main_search\"]/form[2]/button");
        private readonly By _labelFellowsAge = By.XPath("//div[@class='user_name']");

        public void SetFilters()
        {
            _driver.FindElement(_btnAdvancedSearch).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            _driver.FindElement(_btnMyGender).Click();
            _driver.FindElement(_btnMyGenderMale).Click();

            _driver.FindElement(_btnFellowGender).Click();
            _driver.FindElement(_btnFellowGenderMale).Click();

            _driver.FindElement(_inputAgeFrom).Click();
            _driver.FindElement(_inputAgeFrom).SendKeys("20");

            _driver.FindElement(_inputAgeTo).Click();
            _driver.FindElement(_inputAgeTo).SendKeys("30");

            //_driver.FindElement(_btnDestination).Click();

            //_driver.FindElement(_btnDestinationEgypt).Click();
            _driver.FindElement(_btnSearch).Click();
        }

        public bool CheckFellows()
        {
            List<int> agesList = new List<int>();
            foreach (var item in _driver.FindElements(_labelFellowsAge))
            {
                string resultString;
                resultString = Regex.Match(item.Text, @"\d+").Value;
                if (resultString != "")
                    agesList.Add(Int32.Parse(resultString));
            }

            return agesList.All(t => t <= 20 && t <= 30);
        }
    }
}
