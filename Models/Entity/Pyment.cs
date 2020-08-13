using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.Models.Entity
{
    public partial class Pyment
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
    }
}
