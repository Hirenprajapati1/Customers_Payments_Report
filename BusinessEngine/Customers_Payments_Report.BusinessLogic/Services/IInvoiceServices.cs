﻿using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface IInvoiceServices
    {
        public List<InvoiceData> GetInvoices();
        public List<InvoiceData> ShowInvoiceNo();
        public List<PaymentData> ListPaymentDelete(string Inv_NO);
        public int AddInvoice(InvoiceData InvoiceModel, string InvoiceNo);
        public InvoiceData GetInvoiceById(string no);
        public int UpdateInvoice(InvoiceData EditInv);
        public int DeleteInvoice(string no);
        public int DeletePaymentByInvoiceNo(string no);
        public List<InvoiceData> ShowInvoiceNoByTable();
        public int AddInvoiceNoByUser(InvoiceData InvoiceModel);

    }
}
