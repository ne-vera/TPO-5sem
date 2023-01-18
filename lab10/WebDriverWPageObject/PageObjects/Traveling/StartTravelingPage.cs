using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class StartTravelingPage : BasePage
    {
        public StartTravelingPage(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement _btnAgencies => driver.FindElement(By.XPath("//a[@href='/agencies']"));
        private IWebElement _btnVisas => driver.FindElement(By.XPath("//a[@href='/visas']"));
        public void ClickBtnAgencies() => _btnAgencies.Click();
        public void ClickBtnVisas() => _btnVisas.Click();
    }
}
