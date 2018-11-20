using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Task_2___Web
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver wd = new ChromeDriver();

           wd.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");
            //  wd.Navigate().GoToUrl("https://www.mamoletu.co.za");

        }
    }
}
