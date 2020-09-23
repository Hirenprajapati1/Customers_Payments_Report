using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class InvoiceData
    {
    //    public int Invoiceid { get; set; }
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }
        //public int InvoiceAmount { get; set; }
        public decimal InvoiceAmount { get; set; }

        public DateTime PaymentDueDate { get; set; }
    }
}
