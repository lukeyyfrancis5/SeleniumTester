using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://login.yahoo.com/";
            //var pass = "";
            // Automated login pass xpath = "//*[@id='login - passwd']";//*[@id="login-passwd"]

            var chromeDriver = new ChromeDriver();

            chromeDriver.Navigate().GoToUrl(url);

            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

            //IWebElement emailBox = chromeDriver.FindElement(By.XPath("//*[@id='login-username']"));
            //emailBox.SendKeys();

            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);

            IWebElement nextBox = chromeDriver.FindElement(By.XPath("//input[@id='login-signin']"));
            nextBox.Click();

            //chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);

            IWebElement passBox = chromeDriver.FindElement(By.Id("login-passwd"));
            passBox.SendKeys("Iloverice5");

            /*
            chromeDriver.FindElement(By.XPath("//input[@id='login-signin']")).Click();

            IWebElement passField = chromeDriver.FindElement(By.XPath("//*[@id='login - passwd']"));

            

            //chromeDriver.FindElement(By.XPath("//*[@id='login-signin']")).Click();
            */
        }
    }
}
