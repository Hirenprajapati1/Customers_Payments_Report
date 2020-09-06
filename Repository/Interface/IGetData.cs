using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface IGetData
    {
        public List<Models.common.ReportData> GetReportCallaction();

        #region Report
        //public List<Models.common.Report> GetReport();
        public List<Models.common.ReportData> GetReportPay();
        //public List<Models.common.CustomerReport> GetReportData();


        #endregion

        #region ListData
        public List<Models.common.CustomerData> GetCustomers();
        public List<Models.common.InvoiceData> GetInvoices();
        public List<Models.common.PaymentData> GetPayments();

        #endregion
    }
}
