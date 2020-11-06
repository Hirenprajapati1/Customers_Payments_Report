using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class barchartData
    {
        public DateTime MonthYear { get; set; }
        public DateTime Month { get; set; }
        public DateTime year { get; set; }
        public Decimal Sales { get; set; }
        public Decimal PaymentCollection { get; set; }

    }
}
