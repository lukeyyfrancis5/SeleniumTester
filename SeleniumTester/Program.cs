using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var chromeDriver = new ChromeDriver();
            try
            {
                var url = "https://login.yahoo.com/";
                var pass = "Iloverice5";
                var email = "lukebrandonfrancis@yahoo.com";
                // Automated login pass xpath = "//*[@id='login - passwd']";

                chromeDriver.Navigate().GoToUrl(url);

                var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(120));
                chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);

                IWebElement emailBox = chromeDriver.FindElement(By.XPath("//*[@id='login-username']"));
                emailBox.SendKeys(email);

                IWebElement nextBox = chromeDriver.FindElement(By.XPath("//input[@id='login-signin']"));
                nextBox.Click();

                wait.Until(d => d.FindElement(By.Id("login-passwd")));
                IWebElement passBox = chromeDriver.FindElement(By.Id("login-passwd"));
                passBox.SendKeys(pass);
                passBox.SendKeys(Keys.Enter);

                chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/");

                Console.WriteLine("Completed !");


                //  //section[2]/table/tbody/tr[*]/td[2]
                //  //*[@id="data-util-col"]/section[2]/table/tbody/tr[2]

                using (var db = new SelenLedgerContext())
                {
                    List<Stock> stocksList = new List<Stock>();
                    for (var row = 2;
                        row < chromeDriver.FindElements(By.XPath("//section[2]/table/tbody/tr[*]")).Count;
                        row++)
                    {
                        Console.WriteLine(row.ToString());
                        var stockSymbol =
                            chromeDriver.FindElement(By.XPath("//section[2]/table/tbody/tr[" + row + "]/td[1]/a")).Text;

                        var stockName =
                            chromeDriver.FindElement(By.XPath("//section[2]/table/tbody/tr[" + row + "]/td[1]/p")).Text;

                        var stockLPrice =
                            chromeDriver.FindElement(By.XPath("//section[2]/table/tbody/tr[" + row + "]/td[2]")).Text;

                        var stockChange =
                            chromeDriver.FindElement(By.XPath("//section[2]/table/tbody/tr[" + row + "]/td[3]/span")).Text;

                        var stockPChange =
                            chromeDriver.FindElement(By.XPath("//section[2]/table/tbody/tr[" + row + "]/td[4]/span")).Text;

                        Stock stock = new Stock(stockSymbol, stockName, stockLPrice, stockChange, stockPChange);
                        stocksList.Add(stock);
                    }

                    /*
                    ReadOnlyCollection<IWebElement> SymbolColumn =
                        chromeDriver.FindElementsByXPath("//table/tbody/tr[*]/td[1]");
                    ReadOnlyCollection<IWebElement> LastPriceColumn =
                        chromeDriver.FindElementsByXPath("//table/tbody/tr[*]/td[2]");
                    ReadOnlyCollection<IWebElement> ChangeColumn =
                        chromeDriver.FindElementsByXPath("//table/tbody/tr[*]/td[3]");
                    ReadOnlyCollection<IWebElement> ChangePercentColumn =
                        chromeDriver.FindElementsByXPath("//table/tbody/tr[*]/td[4]");

                    for (var index = 1; index < SymbolColumn.Count; index++)
                    {
                        var Symbol = SymbolColumn[index].Text.Split('\r')[0];
                        var Name = SymbolColumn[index].Text.Split('\n')[1];

                        Stock stock = new Stock(Symbol, Name, LastPriceColumn[index].Text, ChangeColumn[index].Text,
                            ChangePercentColumn[index].Text);
                        stocksList.Add(stock);
                        Console.WriteLine(Symbol);
                    }
                    */

                    var ledger = new SelenLedger
                    {
                        StocksL = stocksList,
                        Time = DateTime.Now
                    };
                    db.SelenLedgers.Add(ledger);
                    db.SaveChanges();
                }
                chromeDriver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("PROGRAM FAILURE:\n" + e);
                chromeDriver.Quit();
            }
        }
    } 
}

