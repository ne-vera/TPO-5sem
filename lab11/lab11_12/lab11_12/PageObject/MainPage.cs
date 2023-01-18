using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    internal class MainPage
    {
        private IWebDriver _driver;

        private readonly By _btnAgencies = By.XPath("//a[@href='/agencies']");
        private readonly By _btnVisas = By.XPath("//a[@href='/visas']");
        private readonly By _btnTours = By.XPath("//a[@href='/tours']");
        private readonly By _btnBelarus = By.XPath("//a[@href='/belarus']");
        private readonly By _btnFellows = By.XPath("//a[@href='/fellows']");
        private readonly By _btnAir = By.XPath("//a[@href='/air']");
        private readonly By _btnHotels = By.XPath("//a[@href='/hotels']");


        private readonly By _btnDestinationCountry = By.XPath("//span[text()='Где будем отдыхать']");
        private readonly By _btnAzerbaijan = By.XPath("//li[text()='Азербайджан']");

        private readonly By _btnDestinationCity = By.XPath("//*[@id=\"select2-select-city-container\"]/span"); 
        private readonly By _btnBaku = By.XPath("//li[text()='Баку']");

        private readonly By _btnDepartureCity = By.XPath("//span[text()='Откуда отправляемся']");
        private readonly By _btnFromMinsk = By.XPath("//li[text()='из Минска']");

        private readonly By _btnPrice = By.XPath("//span[text()='Стоимость']");
        private readonly By _btnPriceLimit = By.XPath("//li[text()='до 2 000 BYN']");

        private readonly By _btnSearch = By.XPath("//button[@class='btn js-filter-categories']");

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAgenciesButton()
        {
            _driver.FindElement(_btnAgencies).Click();
        }

        public void ClickVisasButton()
        {
            _driver.FindElement(_btnVisas).Click();
        }

        public void ClickToursButton()
        {
            _driver.FindElement(_btnTours).Click();
        }

        public void ClickBelarusButton()
        {
            _driver.FindElement(_btnBelarus).Click();
        }

        public void ClickFellowsButton()
        {
            _driver.FindElement(_btnFellows).Click();
        }

        public void ClickAirButton()
        {
            _driver.FindElement(_btnAir).Click();
        }

        public void ClickHotelsButton()
        {
            _driver.FindElement(_btnHotels).Click();
        }
        public void SetFilters()
        {
            _driver.FindElement(_btnDestinationCountry).Click();
            _driver.FindElement(_btnAzerbaijan).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(15)).Until(e => e.FindElement(_btnDestinationCity));
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Thread.Sleep(1000);

            _driver.FindElement(_btnDestinationCity).Click();
            _driver.FindElement(_btnBaku).Click();

            _driver.FindElement(_btnDepartureCity).Click();
            _driver.FindElement(_btnFromMinsk).Click();

            _driver.FindElement(_btnPrice).Click();
            _driver.FindElement(_btnPriceLimit).Click();

            _driver.FindElement(_btnSearch).Click();
        }
    }
}
