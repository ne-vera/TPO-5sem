using Framework.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    [TestFixture]
    internal class Tests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://traveling.by/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        //Кейс 1 Корректность упорядочивания по возрастанию цены
        public void SortToursAsc()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickToursButton();

            ToursPage toursPage = new ToursPage(_driver);
            toursPage.SetFiltersCheapFirst();

            Assert.That(toursPage.CheckSortAsc());
        }

        [Test]
        //Кейс 2 Поиск усадьб по заданной области
        public void SearchVillasByGuests()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickBelarusButton();

            BelarusPage belarusPage = new BelarusPage(_driver);
            belarusPage.SetFilters();

            Assert.That(belarusPage.CheckFilters());
        }

        [Test]
        //Кейс 3 Поиск отелей по заданным фильтрам
        public void SearchHotels()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickHotelsButton();

            HotelsPage hotelsPage = new HotelsPage(_driver);
            hotelsPage.SetFilters();
            Assert.That(hotelsPage.ChechHotels());
        }

        [Test]
        //Кейс 4 Поиск туров с ограничением цены
        public void SearchToursByPrice()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.SetFilters();

            ToursPage toursPage = new ToursPage(_driver);
            Assert.That(toursPage.CheckPriceLimit());
        }

        [Test]
        //Кейс 5 Выбор нескольких акций
        public void SearchToursByPromotion()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickToursButton();

            ToursPage toursPage = new ToursPage(_driver);
            toursPage.SetFiltersPormotion();

            Assert.That(toursPage.ChechPromotions());
        }

        [Test]
        //Кейс 6 Поиск виз с заданной целью пребывания
        public void SearchVisasByGoal()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickVisasButton();

            VisasPage visasPage = new VisasPage(_driver);

            visasPage.SetVisaFilters();
            visasPage.ClickBtnSearchVisa();

            Assert.That(visasPage.CheckVisaSearchResults());
        }
        [Test]
        //Кейс 7 Поиск попутчиков по расширенному поиску
        public void SearchFellows() 
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickFellowsButton();

            FellowsPage fellowsPage = new FellowsPage(_driver);
            fellowsPage.SetFilters();

            Assert.That(fellowsPage.CheckFellows());
        }

        [Test]
        //Кейс 8 Поиск турфирмы по названию
        public void SearchAgencyByName()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickAgenciesButton();

            AgenciesPage agenciesPage = new AgenciesPage(_driver);
            agenciesPage.SendTextToQuery();
            agenciesPage.ClickSearchHotels();
            Assert.That(agenciesPage.CheckAgenciesSearchResults());
        }

        [Test]
        //Кейс 9 Поиск санаториев по заданным фильтрам
        public void SearchSanatorium() 
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickBelarusButton();

            BelarusPage belarusPage = new BelarusPage(_driver);
            belarusPage.ClickSanatorium();
            belarusPage.ClickRespiratory();

            Assert.That(belarusPage.CheckType());
        }

        [Test]
        //Кейс 10 Поиск авиабилетов по аэропорту
        public void SearchFlightTickets()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.ClickAirButton();

            AirPage airPage = new AirPage(_driver);
            airPage.ClickAirPorts();
            airPage.ClickShopenPort();
            airPage.ClickBestPrice();
        }
    }
}
