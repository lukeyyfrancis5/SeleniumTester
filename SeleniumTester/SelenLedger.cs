using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    class SelenLedger
    {
        public int SelenLedgerId { get; set; }
        public DateTime Time { get; set; }
        public List<Stock> StocksL { get; set; }
    }
}
