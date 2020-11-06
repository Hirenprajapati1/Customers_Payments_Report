using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class ReportData
    {
        //public int YearInvoice { get; set; }
        //public int MonthInvoice { get; set; }
        //public int YearPay { get; set; }
        //public int MonthPay { get; set; }
        public DateTime DateOfMonthInvoice { get; set; }
        public DateTime DateOfMonthPay { get; set; }
        public DateTime DateOfMonth { get; set; } 
        //public DateTime MonthInvoice { get; set; }
        //public DateTime MonthPayment { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public Decimal NoOfInvoices { get; set; }
        public Decimal Sales { get; set; }
        public Decimal PaymentCollection { get; set; }
        public int No { get; set; }


    }
}
