using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository
{
    public interface IGetData
    {
        public List<Models.common.Report> GetReportCallaction();

        #region Report
        //public List<Models.common.Report> GetReport();
        public List<Models.common.Report> GetReportPay();
        //public List<Models.common.CustomerReport> GetReportData();


        #endregion

        #region ListData
        public List<Models.common.Customer> GetCustomers();
        public List<Models.common.Invoice> GetInvoices();
        public List<Models.common.Pyment> GetPayments();

        #endregion
    }
}
