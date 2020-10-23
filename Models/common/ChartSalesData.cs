using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class ChartSalesData
    {
        public DateTime Dates { get; set; }
        public DateTime Month { get; set; }

        //public int Month { get; set; }
        //public int Year { get; set; }
        public Decimal Sales { get; set; }
        public Decimal PaymentCollection { get; set; }
    }
}
