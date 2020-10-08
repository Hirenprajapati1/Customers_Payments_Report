using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.Models.Entity
{
    public partial class Payment
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
