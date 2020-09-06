using Customers_Payments_Report.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface IInvoiceRepository
    {
        public List<InvoiceData> GetInvoices();
        public int AddInvoice(InvoiceData InvoiceModel, string InvoiceNo);


    }
}
