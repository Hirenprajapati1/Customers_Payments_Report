using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.DataLogic.Entity
{
    public partial class AutoIncrimentNo
    {
        public int Id { get; set; }
        public string LastCustomerNo { get; set; }
        public string LastInvoiceNo { get; set; }
        public string LastPaymentNo { get; set; }
    }
}
