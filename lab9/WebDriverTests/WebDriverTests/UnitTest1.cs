using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Collections.Generic;

namespace WebDriverTests
{
    public class Tests
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://pastebin.com");
        }

        [Test]
        public void ICanWinTest()
        {
            _chromeDriver.FindElement(By.XPath("//textarea[@id='postform-text']")).
                SendKeys("Hello from WebDriver");

            _chromeDriver.FindElement(By.XPath("//span[@id='select2-postform-expiration-container']")).Click();
            _chromeDriver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            _chromeDriver.FindElement(By.XPath("//input[@name='PostForm[name]']")).
                SendKeys("helloweb");

            _chromeDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();

            Assert.AreEqual(_chromeDriver.FindElement(By.XPath("//div[@class='de1']")).Text, "Hello from WebDriver");
        }

        [Test]
        public void BringItOnTest()
        {
            _chromeDriver.FindElement(By.XPath("//textarea[@id='postform-text']")).
                 SendKeys("git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")\ngit push origin master --force");

            _chromeDriver.FindElement(By.XPath("//span[@id='select2-postform-format-container']")).Click();
            _chromeDriver.FindElement(By.XPath("//li[text()='Bash']")).Click();

            _chromeDriver.FindElement(By.XPath("//input[@name='PostForm[name]']")).
                 SendKeys("how to gain dominance among developers");

            _chromeDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();

            var textArea = new List<string>() { "git config --global user.name  \"New Sheriff in Town\"", "git reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")", "git push origin master --force" };

            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            StringAssert.Contains("how to gain dominance among developers", _chromeDriver.Title);
            Assert.AreEqual(_chromeDriver.FindElement(By.XPath("//a[@class='btn -small h_800']")).Text, "Bash");
            Assert.AreEqual("git config --global user.name  \"New Sheriff in Town\"git reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")git push origin master --force", String.Join("",_chromeDriver.FindElements(By.XPath("//li[@class='li1']")).Select(t => t.Text)));
        }

        [Test]
        public void SearchAgencyByName()
        {
            _chromeDriver.Navigate().GoToUrl("https://traveling.by/");

            _chromeDriver.FindElement(By.XPath("//a[@href='/agencies']")).Click();

            _chromeDriver.FindElement(By.XPath("//input[@name='query']")).
                SendKeys("мастер");

            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            _chromeDriver.FindElement(By.XPath("//a[@class='srch-all srch-hotels']")).Click();

            Assert.IsTrue(_chromeDriver.FindElements(By.XPath("//div[@class='preview-info-box']/h3/a")).Select(t => t.Text).All(t => t.ToLower().Contains("мастер")));
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}