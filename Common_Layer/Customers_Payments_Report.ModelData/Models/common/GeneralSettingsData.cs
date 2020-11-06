using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class GeneralSettingsData
    {
        public string Id { get; set; }
        public bool AutoCustomerNo { get; set; }
        public bool AutoInvoiceNo { get; set; }
        public bool AutoPaymentNo { get; set; }
    }
}
