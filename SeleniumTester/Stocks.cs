using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string LastPrice { get; set; }
        public string Change { get; set; }
        public string PercentChange { get; set; }

        public Stock(string symbol, string name, string lastPrice, string change, string percentChange)
        {
            Symbol = symbol;
            Name = name;
            LastPrice = lastPrice;
            Change = change;
            PercentChange = percentChange;

        }


    }
}
