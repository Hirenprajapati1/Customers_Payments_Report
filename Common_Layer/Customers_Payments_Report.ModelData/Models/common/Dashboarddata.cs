using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.ModelData.Models.common
{
    public class Dashboarddata
    {
        public int TotelCustomer { get; set; }
        public int CustomerMonthly { get; set; }
        public int CustomerYearly { get; set; }

        public int TotelInvoices { get; set; }
        public int InvoiceMonthly { get; set; }
        public int InvoiceYearly { get; set; }

        public int TotelPayments { get; set; }
        public int PaymentsMonthly { get; set; }
        public int PaymentsYearly { get; set; }

        public Decimal TotelSeles { get; set; }
        public Decimal SalesMonthly { get; set; }
        public Decimal SalesYearly { get; set; }

        public Decimal TotelPaymentCollestions { get; set; }
        public Decimal PaymentCollestionsMonthly { get; set; }
        public Decimal PaymentCollestionsYearly { get; set; }

        public int CustomerMonthlyGrowth { get; set; }
        public int CustomerYearlyGrowth { get; set; }


        public int SalesMonthlyGrowth { get; set; }
        public int SalesYearlyGrowth { get; set; }

        public int PaymentCollestionsMonthlyGroth { get; set; }
        public int PaymentCollestionsYearlyGrowth { get; set; }

        //public decimal TotelDuePayments { get; set; }
        //public decimal DuePaymentsMonthly { get; set; }
        //public decimal DuePaymentsYearly { get; set; }
        //public int DuePaymentsMonthly1 { get; set; }
        //public int DuePaymentsYearly1 { get; set; }

    }
}
