using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    class SelenLedgerContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SelenLedger> SelenLedgers { get; set; }

    }
}
