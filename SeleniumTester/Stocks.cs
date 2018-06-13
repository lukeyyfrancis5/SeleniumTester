using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    class Stocks
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int LastPrice { get; set; }
        public int Change { get; set; }
        public int PercentChange { get; set; }
    }
}
