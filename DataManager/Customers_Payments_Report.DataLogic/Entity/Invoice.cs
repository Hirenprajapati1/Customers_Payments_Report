using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.DataLogic.Entity
{
    public partial class Invoice
    {
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
