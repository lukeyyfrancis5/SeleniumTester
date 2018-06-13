using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://login.yahoo.com/";
            var pass = "Iloverice5";
            var email = "lukebrandonfrancis@yahoo.com";
            // Automated login pass xpath = "//*[@id='login - passwd']";

            var chromeDriver = new ChromeDriver();

            chromeDriver.Navigate().GoToUrl(url);

            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(90));

            //chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);


            IWebElement emailBox = chromeDriver.FindElement(By.XPath("//*[@id='login-username']"));
            emailBox.SendKeys(email);    
        
            IWebElement nextBox = chromeDriver.FindElement(By.XPath("//input[@id='login-signin']"));
            nextBox.Click();

            try
            {
                wait.Until(d => d.FindElement(By.Id("login-passwd")));
            }
            catch
            {
                Console.WriteLine("Invalid Username!");
            }

            IWebElement passBox = chromeDriver.FindElement(By.Id("login-passwd"));
            passBox.SendKeys(pass);
            passBox.SendKeys(Keys.Enter);
            chromeDriver.FindElement(By.TagName("body")).SendKeys(Keys.Escape);

            
            chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/");
            wait.Until(d => d.Url.StartsWith("https://finance.yahoo.com/"));

            Console.WriteLine("completed");
            
            IWebElement table = chromeDriver.FindElement(By.XPath("//*[@id='data-util-col']/section[2]/table/tbody"));
            Console.WriteLine(table);

            // tbody xpath -//*[@id="data-util-col"]/section[2]/table/tbody
            //ReadOnlyCollection<IWebElement> rows = table.FindElements(By.XPath("//tr"));

            //foreach(IWebElement row in rows)
            //{
            //    var Symbol = chromeDriver.FindElement(By.XPath("//*[@id='data-util-col']/section[2]/table/tbody/tr[2]/td[1]/a"));
            //}

            //Console.WriteLine(rows);

            // table xpath - //*[@id="data-util-col"]/section[2]/table
            /*
            IWebElement allRows = chromeDriver.FindElement(By.XPath("//tr"));

            List<Stocks> stockList = new List<Stocks>();

            foreach (var row in allRows)
            {
                var Symbol = chromeDriver.FindElement(By.XPath(""))
            }
            */
        }
    }
}
