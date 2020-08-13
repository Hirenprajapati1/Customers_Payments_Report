using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository
{
    public interface IGetData
    {
        #region Report
        public List<Models.common.Report> GetReport();
        #endregion

        #region ListData
        public List<Models.common.Customer> GetCustomers();
        public List<Models.common.Invoice> GetInvoices();
        public List<Models.common.Pyment> GetPayments();

        #endregion
    }
}
