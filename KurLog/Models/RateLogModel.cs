using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurLog.Models
{
    public class RateLogModel
    {
        public string LogDate { get; set; }
        public string ApiUpdateDate { get; set; }
        public string DollarBuying { get; set; }
        public string DollarSales { get; set; }
        public string EuroBuying { get; set; }
        public string EuroSales { get; set; }
        public string SilverBuying { get; set; }
        public string SilverSales { get; set; }
        public string GoldBuying { get; set; }
        public string GoldSales { get; set; }
    }
}
