using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class InvoiceRepository : IInvoiceRepository
    {
        #region ListInvoice
        public List<InvoiceData> GetInvoices()
        {
            List<InvoiceData> Invoices = new List<InvoiceData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    InvoiceData Invoice1;
                    foreach (var Invo in dBContext.Invoice.ToList())
                    {
                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Invo.CustomerNo);

                        Invoice1 = new InvoiceData();
                        Invoice1.Invoiceid = Invo.Invoiceid;
                        Invoice1.InvoiceNo = Invo.InvoiceNo;
                        Invoice1.CustomerNo = Invo.CustomerNo;
                        if (Cust != null)
                        {
                            Invoice1.CustomerName = Cust.CustomerName;
                        }

                        Invoice1.InvoiceDate = Invo.InvoiceDate;
                        Invoice1.InvoiceAmount = Invo.InvoiceAmount;
                        Invoice1.PaymentDueDate = Invo.PaymentDueDate;

                        Invoices.Add(Invoice1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return Invoices;
        }
        #endregion

        #region AddInvoice
        public int AddInvoice(InvoiceData InvoiceModel, string InvoiceNo)
        {
            int returnVal = 0;
            List<InvoiceData> invoices = new List<InvoiceData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    InvoiceData Invoice1;
                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        Invoice1 = new InvoiceData();
                        Invoice1.InvoiceNo = inv.InvoiceNo;
                        invoices.Add(Invoice1);
                    }
                    Invoice InvoiceEntity;
                    //Add Invoice
                    InvoiceEntity = new Invoice();
                    InvoiceEntity.InvoiceNo = InvoiceModel.InvoiceNo;
                    InvoiceEntity.InvoiceAmount = InvoiceModel.InvoiceAmount;
                    //InvoiceEntity.InvoiceDate = InvoiceModel.InvoiceDate;
                    InvoiceEntity.InvoiceDate = DateTime.UtcNow;
                    InvoiceEntity.PaymentDueDate = DateTime.UtcNow.AddDays(30);
                    InvoiceEntity.CustomerNo = InvoiceModel.CustomerNo;
                    InvoiceNo = InvoiceEntity.InvoiceNo;

                    bool InvoiceNoexist = invoices.Any(x => x.InvoiceNo == InvoiceNo);
                    if (InvoiceNoexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        dBContext.Invoice.Add(InvoiceEntity);
                        returnVal = dBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        #endregion

        #region GetInvoiceById

        public InvoiceData GetInvoiceById(int id)
        {
            InvoiceData invoiceDatas = new InvoiceData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var Inv = dBContext.Invoice.Where(x => x.Invoiceid == id).SingleOrDefault();
                    if (Inv != null)
                    {
                        invoiceDatas.Invoiceid = Inv.Invoiceid;
                        invoiceDatas.CustomerNo = Inv.CustomerNo;
                        invoiceDatas.InvoiceNo = Inv.InvoiceNo;
                        invoiceDatas.InvoiceDate = Inv.InvoiceDate;
                        invoiceDatas.InvoiceAmount = Inv.InvoiceAmount;
                        invoiceDatas.PaymentDueDate = Inv.PaymentDueDate;
                    }
                    return invoiceDatas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        #endregion

        #region DeleteInvoice

        public int DeleteInvoice(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Invoice invoiceEntity = new Invoice();
                    invoiceEntity = dBContext1.Invoice.FirstOrDefault(x => x.Invoiceid == Id);
                    if (invoiceEntity != null)
                    {
                        dBContext1.Invoice.Remove(invoiceEntity);
                    }
                    returnVal = dBContext1.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }


        #endregion

    }
}
