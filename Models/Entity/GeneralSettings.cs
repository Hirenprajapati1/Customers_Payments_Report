using System;
using System.Collections.Generic;

namespace Customers_Payments_Report.Models.Entity
{
    public partial class GeneralSettings
    {
        public string Id { get; set; }
        public bool AutoCustomerNo { get; set; }
        public bool AutoInvoiceNo { get; set; }
        public bool AutoPaymentNo { get; set; }
    }
}
