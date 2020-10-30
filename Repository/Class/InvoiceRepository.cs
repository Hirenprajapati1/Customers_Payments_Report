using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class InvoiceRepository : IInvoiceRepository
    {
        string str, str1;
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
                        //                Invoice1.Invoiceid = Invo.Invoiceid;
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

        #region ShowInvoiceNo
        public List<InvoiceData> ShowInvoiceNo()
        {
            List<InvoiceData> Invoices = new List<InvoiceData>();
            List<InvoiceData> Invoices1 = new List<InvoiceData>();
            using (var dBContext = new CustomersDatabaseContext())
            {

                //GetInvoiceNO
                InvoiceData Invoice1;
                foreach (var inv in dBContext.Invoice.ToList())
                {
                    Invoice1 = new InvoiceData();
                    Invoice1.InvoiceNo = inv.InvoiceNo;
                    Invoices.Add(Invoice1);
                }

                //     foreach (var Cust1 in dBContext.Customer.ToList())
                {
                    string s = "0";
                    int number = Convert.ToInt32(s);
                    number += 1;
                    str = "I" + number.ToString("D5");
                    X:
                    bool No = Invoices.Any(x => x.InvoiceNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        number += 1;
                        str = "I" + number.ToString("D5");
                        goto X;

                    }
                }

                InvoiceData Invoice2;
                Invoice2 = new InvoiceData();
                Invoice2.InvoiceNo = str;
                Invoices1.Add(Invoice2);
                return Invoices1;

            }
        }
        #endregion

        #region ShowInvoiceNoByTable
        public List<InvoiceData> ShowInvoiceNoByTable()
        {
            List<InvoiceData> Invoices = new List<InvoiceData>();
            List<InvoiceData> Invoices1 = new List<InvoiceData>();
            //List<AutoIncrimentNoData> Autos = new List<AutoIncrimentNoData>();
            using (var dBContext = new CustomersDatabaseContext())
            {
                InvoiceData Inv1;
                foreach (var inv in dBContext.Invoice.ToList())
                {
                    Inv1 = new InvoiceData();
                    Inv1.InvoiceNo = inv.InvoiceNo;
                    Invoices.Add(Inv1);
                }

                InvoiceData Invoice2;
                foreach (var Au in dBContext.AutoIncrimentNo.ToList())
                {
                    Invoice2 = new InvoiceData();
                    int num;
                    num = Convert.ToInt32(Au.LastInvoiceNo);
                    num += 1;

                    str = "I" + num.ToString("D5");
                    X:
                    bool No = Invoices.Any(x => x.InvoiceNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        num += 1;
                        str = "I" + num.ToString("D5");
                        goto X;

                    }
                    str1 = str.Substring(1);
                    Invoice2.InvoiceNo = str1;
                    Invoices1.Add(Invoice2);
                }

            }

            return Invoices1;

        }
        #endregion

        #region AddInvoice
        public int AddInvoice(InvoiceData InvoiceModel, string InvoiceNo)
        {
            int returnVal = 0;
            List<InvoiceData> invoices = new List<InvoiceData>();
            List<AutoIncrimentNoData> autos = new List<AutoIncrimentNoData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    InvoiceData Invoice1;
                    AutoIncrimentNo Auto1 = new AutoIncrimentNo();

                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        Invoice1 = new InvoiceData();
                        Invoice1.InvoiceNo = inv.InvoiceNo;
                        invoices.Add(Invoice1);
                    }
                    Invoice InvoiceEntity;

                    //Add Invoice
                    InvoiceEntity = new Invoice();

                    if (InvoiceModel.InvoiceNo == null)
                    {
                        //ShowInvoiceNo();
                        ShowInvoiceNoByTable();
                        InvoiceModel.InvoiceNo = str;
                    }
                    InvoiceEntity.InvoiceNo = InvoiceModel.InvoiceNo;
                    InvoiceEntity.InvoiceAmount = InvoiceModel.InvoiceAmount;
                    //InvoiceEntity.InvoiceDate = InvoiceModel.InvoiceDate;
                    if (InvoiceModel.InvoiceDate == DateTime.MinValue)
                    {
                        InvoiceEntity.InvoiceDate = DateTime.Now;
                    }
                    else
                    {
                        InvoiceEntity.InvoiceDate = InvoiceModel.InvoiceDate;
                    }
                    InvoiceEntity.PaymentDueDate = InvoiceEntity.InvoiceDate.AddDays(30);
                    InvoiceEntity.CustomerNo = InvoiceModel.CustomerNo;
                    InvoiceEntity.CreatedDate = DateTime.UtcNow;
                    InvoiceEntity.CreatedBy = InvoiceModel.CreatedBy;

                    //  InvoiceNo = InvoiceEntity.InvoiceNo;

                    if (dBContext.GeneralSettings.FirstOrDefault(x => x.Id == "1").AutoInvoiceNo == true)
                    {
                        int Num = Convert.ToInt32(InvoiceEntity.InvoiceNo.Substring(1));
                        string Num1 = Convert.ToString(Num);
                        foreach (var Au in dBContext.AutoIncrimentNo.ToList())
                        {

                            Auto1.LastCustomerNo = Au.LastCustomerNo;
                            Auto1.LastInvoiceNo = Num1;
                            Auto1.LastPaymentNo = Au.LastPaymentNo;
                            // autos.Add(Auto1);

                        }
                        var rows = from a1 in dBContext.AutoIncrimentNo
                                   select a1;
                        foreach (var row in rows)
                        {
                            if (row != null)
                            {
                                dBContext.AutoIncrimentNo.Remove(row);
                                //dbcontext.savechanges();
                            }
                        }
                        dBContext.AutoIncrimentNo.Add(Auto1);


                    }

                    bool InvoiceNoexist = invoices.Any(x => x.InvoiceNo == InvoiceEntity.InvoiceNo);
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

        #region AddInvoiceNoByUser
        public int AddInvoiceNoByUser(InvoiceData InvoiceModel)
        {
            int returnVal = 0;
            List<InvoiceData> Invoices = new List<InvoiceData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    InvoiceData Invoice1;

                    foreach (var Inv in dBContext.Invoice.ToList())
                    {
                        Invoice1 = new InvoiceData();
                        Invoice1.InvoiceNo = Inv.InvoiceNo;
                        Invoices.Add(Invoice1);
                    }
                    //AddInvoice
                    Invoice InvoiceEntity = new Invoice();
                    //if (InvoiceModel.InvoiceNo == null)
                    //{
                    //    //ShowInvoiceNo();
                    //    ShowInvoiceNoByTable();
                    //    InvoiceModel.InvoiceNo = str;
                    //}
                    InvoiceEntity.InvoiceNo = InvoiceModel.InvoiceNo;
                    InvoiceEntity.InvoiceAmount = InvoiceModel.InvoiceAmount;
                    //InvoiceEntity.InvoiceDate = InvoiceModel.InvoiceDate;
                    if (InvoiceModel.InvoiceDate == DateTime.MinValue)
                    {
                        InvoiceEntity.InvoiceDate = DateTime.UtcNow;
                    }
                    else
                    {
                        InvoiceEntity.InvoiceDate = InvoiceModel.InvoiceDate;
                    }
                    InvoiceEntity.PaymentDueDate = InvoiceEntity.InvoiceDate.AddDays(30);
                    InvoiceEntity.CustomerNo = InvoiceModel.CustomerNo;
                    InvoiceEntity.CreatedDate = DateTime.Now;
                    InvoiceEntity.CreatedBy = InvoiceModel.CreatedBy;

                    bool InvoiceNoexist = Invoices.Any(x => x.InvoiceNo == InvoiceEntity.InvoiceNo);
                    if (InvoiceNoexist == true)
                    {
                        returnVal = -1;
                    }
                    if (InvoiceNoexist == false)
                    {
                        dBContext.Invoice.Add(InvoiceEntity);
                        //     dBContext.AutoIncrimentNo.Add(Auto1);
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

        public InvoiceData GetInvoiceById(string no)
        {
            InvoiceData invoiceDatas = new InvoiceData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var Inv = dBContext.Invoice.Where(x => x.InvoiceNo == no).SingleOrDefault();
                    if (Inv != null)
                    {
                        //                  invoiceDatas.Invoiceid = Inv.Invoiceid;
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

        #region UpdateInvoice

        public int UpdateInvoice(InvoiceData EditInv)
        {
            List<InvoiceData> Invoices = new List<InvoiceData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    ////GetInvoice
                    //InvoiceData invoice1;
                    //foreach (var inv in dBContext1.Invoice.ToList())
                    //{
                    //    invoice1 = new InvoiceData();
                    //    invoice1.InvoiceNo = inv.InvoiceNo;
                    //    //invoice1.InvoiceAmount = inv.InvoiceAmount;
                    //    //invoice1.CustomerNo = inv.CustomerNo;
                    //    //invoice1.InvoiceDate = inv.InvoiceDate;
                    //    //invoice1.PaymentDueDate = inv.PaymentDueDate;
                    //    Invoices.Add(invoice1);
                    //}

                    Invoice InvoiceEntity = new Invoice();
                    InvoiceEntity = dBContext1.Invoice.FirstOrDefault(x => x.InvoiceNo == EditInv.InvoiceNo);
                    if (InvoiceEntity != null)
                    {
                        InvoiceEntity.CustomerNo = EditInv.CustomerNo;
                        InvoiceEntity.InvoiceNo = EditInv.InvoiceNo;
                        InvoiceEntity.InvoiceDate = EditInv.InvoiceDate;
                        InvoiceEntity.InvoiceAmount = EditInv.InvoiceAmount;
                        InvoiceEntity.PaymentDueDate = InvoiceEntity.InvoiceDate.AddDays(30);
                        InvoiceEntity.ModifyDate = DateTime.Now;
                        InvoiceEntity.ModifyBy = EditInv.ModifyBy;
                        dBContext1.Invoice.Update(InvoiceEntity);
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

        #region DeleteInvoice

        public int DeleteInvoice(string no)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {

                    Payment PaymentEntity = new Payment();
                    Invoice invoiceEntity = new Invoice();

                    invoiceEntity = dBContext1.Invoice.FirstOrDefault(x => x.InvoiceNo == no);
                    PaymentEntity = dBContext1.Payment.FirstOrDefault(x => x.InvoiceNo == no);
                    if (PaymentEntity == null)
                    {
                        if (invoiceEntity != null)
                        {
                            dBContext1.Invoice.Remove(invoiceEntity);
                        }
                        returnVal = dBContext1.SaveChanges();
                    }
                    else
                    {
                        returnVal = -1;
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

        #region DeleteByPaymentNo

        public int DeletePaymentByInvoiceNo(string no)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    #region old
                    //         dBContext1.ExecuteStoreCommand("DELETE FROM YOURTABLE WHERE CustomerID = {0}", customerId);

                    //var query = from c in dBContext1.Payment
                    //            where c.InvoiceNo == 
                    //            select c;

                    //query.Delete();
                    //var pays = dBContext1.Payment.Where(x => x.InvoiceNo == no);
                    //foreach(PaymentData pay in pays)
                    //{
                    //    dBContext1.Payment.DeleteObject();
                    //}
                    //dBContext1.Payment.RemoveRange(dBContext1.Payment.Where(x => x.PaymentNo == no));
                    //returnVal = dBContext1.SaveChanges();
                    #endregion
                    foreach (var Pay in dBContext1.Payment.ToList())
                    {
                        if (Pay.InvoiceNo == no)
                        {
                            dBContext1.Payment.Remove(dBContext1.Payment.FirstOrDefault(x => x.InvoiceNo == no));
                            returnVal = dBContext1.SaveChanges();
                        }
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

        #region ListPaymentDelete

        public List<PaymentData> ListPaymentDelete(string Inv_NO)
        {
            List<PaymentData> PaymentDelete = new List<PaymentData>();
            List<PaymentData> Payments = new List<PaymentData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    PaymentData Payment1;
                    foreach (var Pay in dBContext.Payment.ToList())
                    {
                        if (Pay != null)
                        {
                            Payment1 = new PaymentData();
                            //          Payment1.Paymentid = Pay.Paymentid;
                            Payment1.PaymentNo = Pay.PaymentNo;
                            Payment1.InvoiceNo = Pay.InvoiceNo;
                            Payment1.PaymentDate = Pay.PaymentDate;
                            Payment1.PaymentAmount = Pay.PaymentAmount;

                            var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == Pay.InvoiceNo);
                            if (inv != null)
                            {
                                var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                                if (Cust != null)
                                {
                                    Payment1.CustomerName = Cust.CustomerName;
                                }
                            }
                            Payments.Add(Payment1);
                        }
                    }
                    PaymentData payment11;
                    foreach (var a in Payments)
                    {
                        if (a.InvoiceNo == Inv_NO)
                        {
                            payment11 = new PaymentData();

                            payment11.InvoiceNo = a.InvoiceNo;
                            payment11.PaymentNo = a.PaymentNo;
                            payment11.PaymentAmount = a.PaymentAmount;
                            payment11.PaymentDate = a.PaymentDate;
                            payment11.CustomerName = a.CustomerName;
                            PaymentDelete.Add(payment11);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return PaymentDelete;
        }


        #endregion

    }
}
