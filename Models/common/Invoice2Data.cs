using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class Invoice2Data
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public Decimal PaymentAmount { get; set; }
        public Decimal PaymentAmountRemening { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
