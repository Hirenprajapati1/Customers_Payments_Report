using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Models.common
{
    public class PaymentData
    {
        public int Paymentid { get; set; }

        public string PaymentNo { get; set; }
        public string CustomerName { get; set; }

        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
    }
}
