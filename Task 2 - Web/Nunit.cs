using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Task_2___Web
{
    class NUnit
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]

        public void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestNUnit()
        {
            driver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");
        }
        //[Test]
        //public void ValidateUser()
        //{
        //    driver.FindElement(By.)
        //}
        [TearDown]
        public void CloseBrower()
        {
            driver.Close();
        }
    }
}
