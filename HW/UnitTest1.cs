using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace HW
{
    public class Tests
    {
        private IWebDriver driver;
        //private WebDriverWait wait;

        [SetUp]
        public void TestFixtureSetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void LoginTest()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            var HomePage = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual("Home page", HomePage.Text);
        }
        [Test]
        public void AddProductTest()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'All Products')])[2]")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("Rosemary");
            driver.FindElement(By.Id("CategoryId")).Click();
            driver.FindElement(By.XPath("//option[contains(text(),'Beverages')]")).Click();
            driver.FindElement(By.Id("CategoryId")).Click();
            driver.FindElement(By.XPath("//option[contains(text(),'Bigfoot Breweries')]")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("17");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("2 boxes");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("23");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("40");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("10");
            driver.FindElement(By.CssSelector(".btn")).Click();
            var AllProducts = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual("All Products", AllProducts.Text);
        }

        [Test]
        public void FieldValueTest()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'All Products')])[2]")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Rosemary')])")).Click();
            var ProductName = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
            Assert.AreEqual("Rosemary", ProductName);
            var CategoryId = driver.FindElement(By.Id("CategoryId")).GetAttribute("value");
            Assert.AreEqual("1", CategoryId);
            var SupplierId = driver.FindElement(By.Id("SupplierId")).GetAttribute("value");
            Assert.AreEqual("16", SupplierId);
            var UnitPrice = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            Assert.AreEqual("17,0000", UnitPrice);
            var QuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value");
            Assert.AreEqual("2 boxes", QuantityPerUnit);
            var UnitsInStock = driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value");
            Assert.AreEqual("23", UnitsInStock);
            var UnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value");
            Assert.AreEqual("40", UnitsOnOrder);
            var ReorderLevel = driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value");
            Assert.AreEqual("10", ReorderLevel);
        }

        [Test]
        public void LogoutTest()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
            var Login = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual("Login", Login.Text);
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}