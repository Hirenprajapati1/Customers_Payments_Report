using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class ReportData1
    {
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public Decimal TotelInvoiceAmount { get; set; }
        public Decimal TotelPaymentAmount { get; set; }
        public Decimal RemeningPayment { get; set; }

    }
}
