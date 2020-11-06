using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class CustomerReport
    {

        public int No { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime DateOfMonth { get; set; }

        //public DateTime MonthInvoice { get; set; }
        //public DateTime MonthPayment { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int NoOfInvoices { get; set; }
        public int Sales { get; set; }
        public int PaymentCollection { get; set; }


    }
}
