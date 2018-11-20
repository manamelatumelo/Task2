using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace WebTest
{
    [TestClass]
    public class UserTests
    {
        IWebDriver chromeDriver;

        [TestInitialize]
        public void Init()
        {
            chromeDriver = new ChromeDriver();
        }

        [TestMethod]
        public void Test_user_exists()
        {
            //var name = "admin@comp.com";// "Tumelo";
            var LinkTo = "http://www.way2automation.com/angularjs-protractor/webtables/";

            chromeDriver.Navigate().GoToUrl(LinkTo);
            //"http://www.way2automation.com/angularjs-protractor/webtables/");

            var url = chromeDriver.Url;
            Assert.IsTrue(url == LinkTo);
        }

        [TestMethod]
        public void Test_Add_user()
        {

            //string[][] Data = new string[2][]
            //{
            //   [],[]
            //}


            string[,] data = new string[2, 8] {{"FName1", "LName1", "User1", "Pass1", "15", "2", "admin@mail.com","082555"},
                                               {"FName2", "LName2", "User2", "Pass1", "15", "1", "customer@mail.com","083444"} };


            chromeDriver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");


            var usernames = new List<string>();
            for (var x = 0; x < 2; x++)
            {
                var btn = chromeDriver.FindElement(By.ClassName("btn"));
                btn.Click();

                var element = chromeDriver.FindElement(By.Name("FirstName"));
                element.Clear();
                element.SendKeys(data[x, 0]);

                element = chromeDriver.FindElement(By.Name("LastName"));
                element.Clear();
                element.SendKeys(data[x, 1]);

                element = chromeDriver.FindElement(By.Name("UserName"));
                element.Clear();
                element.SendKeys(data[x, 2]);

                usernames.Add(data[x, 2]);

                element = chromeDriver.FindElement(By.Name("Password"));
                element.Clear();
                element.SendKeys(data[x, 3]);

                //chromeDriver.FindElement(By.Name("optionsRadios")).SendKeys(data[x, 4]);
                IWebElement CompanpanyoptionsRadio = chromeDriver.FindElement(By.CssSelector("input[value='" + data[x, 4] + "']"));
                CompanpanyoptionsRadio.Click();

                //chromeDriver.FindElement(By.Name("RoleId")).SendKeys(data[x, 5]);
                var roleSelect = chromeDriver.FindElement(By.Name("RoleId"));
                var selectElement = new SelectElement(roleSelect);
                selectElement.SelectByValue(data[x, 5]);



                element = chromeDriver.FindElement(By.Name("Email"));
                element.Clear();
                element.SendKeys(data[x, 6]);

                element = chromeDriver.FindElement(By.Name("Mobilephone"));
                element.Clear();
                element.SendKeys(data[x, 7]);

                var btnSave = chromeDriver.FindElement(By.ClassName("btn-success"));
                btnSave.Click();
            }

            //chromeDriver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");
            var rows = chromeDriver.FindElements(By.CssSelector("tbody > tr")).ToList();

            //data.ForEach(() =>
            //{
            //    usernames += m[2];
            //});

            var isFound = rows.Any(m => m.Text.ContainsAny(usernames.ToArray()));
            Assert.IsTrue(isFound);
        }






        [TestCleanup]
        public void Cleanup()
        {
            chromeDriver.Close();
        }
    }
}
