using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceServices(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        
        public int AddInvoice(InvoiceData InvoiceModel, string InvoiceNo)
        {
            return _invoiceRepository.AddInvoice(InvoiceModel,InvoiceNo);
        }

        public int AddInvoiceNoByUser(InvoiceData InvoiceModel)
        {
            return _invoiceRepository.AddInvoiceNoByUser(InvoiceModel);
        }

        public int DeleteInvoice(string no)
        {
            return _invoiceRepository.DeleteInvoice(no);
        }

        public int DeletePaymentByInvoiceNo(string no)
        {
            return _invoiceRepository.DeletePaymentByInvoiceNo(no);
        }

        public InvoiceData GetInvoiceById(string no)
        {
            return _invoiceRepository.GetInvoiceById(no);
        }

        public List<InvoiceData> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }

        public List<PaymentData> ListPaymentDelete(string Inv_NO)
        {
            return _invoiceRepository.ListPaymentDelete(Inv_NO);
        }

        public List<InvoiceData> ShowInvoiceNo()
        {
            return _invoiceRepository.ShowInvoiceNo();
        }

        public List<InvoiceData> ShowInvoiceNoByTable()
        {
            return _invoiceRepository.ShowInvoiceNoByTable();
        }

        public int UpdateInvoice(InvoiceData EditInv)
        {
            return _invoiceRepository.UpdateInvoice(EditInv);
        }
    }
}
