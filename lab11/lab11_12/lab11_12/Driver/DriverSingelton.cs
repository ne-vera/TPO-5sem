using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Driver
{
    public class DriverSingelton
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }

            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
