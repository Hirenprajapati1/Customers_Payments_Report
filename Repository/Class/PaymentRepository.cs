using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class PaymentRepository : IPaymentRepository
    {
        #region ListPayments
        public List<PaymentData> GetPayments()
        {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return Payments;
        }
        #endregion
        string str, str1;
        #region ShowPaymentNo
        public List<PaymentData> ShowPaymentNo()
        {
            List<PaymentData> Invoices = new List<PaymentData>();
            List<PaymentData> Invoices1 = new List<PaymentData>();
            using (var dBContext = new CustomersDatabaseContext())
            {

                //GetPaymentNO
                PaymentData Payment1;
                foreach (var pay in dBContext.Payment.ToList())
                {
                    Payment1 = new PaymentData();
                    Payment1.PaymentNo = pay.PaymentNo;
                    Invoices.Add(Payment1);
                }

                //     foreach (var Cust1 in dBContext.Customer.ToList())
                {
                    string s = "0";
                    int number = Convert.ToInt32(s);
                    number += 1;
                    str = "P" + number.ToString("D5");
                    X:
                    bool No = Invoices.Any(x => x.PaymentNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        number += 1;
                        str = "P" + number.ToString("D5");
                        goto X;

                    }
                }

                PaymentData Payment2;
                Payment2 = new PaymentData();
                Payment2.PaymentNo = str;
                Invoices1.Add(Payment2);
                return Invoices1;

            }
        }
        #endregion

        #region AddPayment
        public int AddPayment(PaymentData PaymentModel)
        {
            int returnVal = 0;
            List<PaymentData> invoices = new List<PaymentData>();
            List<AutoIncrimentNoData> autos = new List<AutoIncrimentNoData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetPayment
                    PaymentData Payment1;
                    foreach (var pay in dBContext.Payment.ToList())
                    {
                        Payment1 = new PaymentData();
                        Payment1.PaymentNo = pay.PaymentNo;
                        invoices.Add(Payment1);
                    }
                    Payment PaymentEntity;
                    //Add Invoice
                    PaymentEntity = new Payment();
                    if (PaymentModel.PaymentNo == null)
                    {
                        //   ShowPaymentNo();
                        ShowPaymentNoByTable();
                        PaymentModel.PaymentNo = str;
                    }

                    PaymentEntity.PaymentNo = PaymentModel.PaymentNo;
                    PaymentEntity.InvoiceNo = PaymentModel.InvoiceNo;
                    PaymentEntity.PaymentAmount = PaymentModel.PaymentAmount;
                    if (PaymentModel.PaymentDate == DateTime.MinValue)
                    {
                        PaymentEntity.PaymentDate = DateTime.Now;
                    }
                    else
                    {
                        PaymentEntity.PaymentDate = PaymentModel.PaymentDate;
                    }

                    PaymentEntity.CreatedDate = DateTime.Now;
                    PaymentEntity.CreatedBy = PaymentModel.CreatedBy;


                    // PaymentNo = PaymentEntity.PaymentNo;

                    if (dBContext.GeneralSettings.FirstOrDefault(x => x.Id == "1").AutoPaymentNo == true)
                    {
                        int Num = Convert.ToInt32(PaymentEntity.PaymentNo.Substring(1));
                        string Num1 = Convert.ToString(Num);
                        AutoIncrimentNo Auto1 = new AutoIncrimentNo();

                        foreach (var Au in dBContext.AutoIncrimentNo.ToList())
                        {

                            Auto1.LastCustomerNo = Au.LastCustomerNo;
                            Auto1.LastInvoiceNo = Au.LastInvoiceNo;
                            Auto1.LastPaymentNo = Num1;
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

                    bool PaymentNoxist = invoices.Any(x => x.PaymentNo == PaymentEntity.PaymentNo);
                    if (PaymentNoxist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        dBContext.Payment.Add(PaymentEntity);
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

        #region AddPaymentNoByUser
        public int AddPaymentNoByUser(PaymentData PaymentModel)
        {
            int returnVal = 0;
            List<PaymentData> Payments = new List<PaymentData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    PaymentData payment1;

                    foreach (var Pay in dBContext.Payment.ToList())
                    {
                        payment1 = new PaymentData();
                        payment1.PaymentNo = Pay.PaymentNo;
                        Payments.Add(payment1);
                    }
                    //AddInvoice
                    Payment PaymentEntity = new Payment();
                    //if (InvoiceModel.InvoiceNo == null)
                    //{
                    //    //ShowInvoiceNo();
                    //    ShowInvoiceNoByTable();
                    //    InvoiceModel.InvoiceNo = str;
                    //}
                    PaymentEntity.PaymentNo = PaymentModel.PaymentNo;
                    PaymentEntity.InvoiceNo = PaymentModel.InvoiceNo;
                    PaymentEntity.PaymentAmount = PaymentModel.PaymentAmount;
                    if (PaymentModel.PaymentDate == DateTime.MinValue)
                    {
                        PaymentEntity.PaymentDate = DateTime.UtcNow;
                    }
                    else
                    {
                        PaymentEntity.PaymentDate = PaymentModel.PaymentDate;
                    }
                    PaymentEntity.CreatedDate = DateTime.UtcNow;
                    PaymentEntity.CreatedBy = PaymentModel.CreatedBy;



                    bool InvoiceNoexist = Payments.Any(x => x.PaymentNo == PaymentEntity.PaymentNo);
                    if (InvoiceNoexist == true)
                    {
                        returnVal = -1;
                    }
                    if (InvoiceNoexist == false)
                    {
                        dBContext.Payment.Add(PaymentEntity);
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

        #region GetPaymentById

        public PaymentData GetPaymentById(string no)
        {
            PaymentData PaymentDatas = new PaymentData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var pay = dBContext.Payment.Where(x => x.PaymentNo == no).SingleOrDefault();
                    if (pay != null)
                    {
                        //             PaymentDatas.Paymentid = pay.Paymentid;
                        PaymentDatas.PaymentNo = pay.PaymentNo;
                        PaymentDatas.InvoiceNo = pay.InvoiceNo;
                        PaymentDatas.PaymentDate = pay.PaymentDate;
                        PaymentDatas.PaymentAmount = pay.PaymentAmount;
                    }
                    return PaymentDatas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        #endregion

        #region UpdatePayment

        public int UpdatePayment(PaymentData Editpay)
        {
            List<PaymentData> Payments = new List<PaymentData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    //GetPayment
                    //PaymentData Payment1;
                    //foreach (var Pay in dBContext1.Payment.ToList())
                    //{
                    //    Payment1 = new PaymentData();
                    //    Payment1.PaymentNo = Pay.PaymentNo;
                    //    //invoice1.InvoiceAmount = inv.InvoiceAmount;
                    //    //invoice1.CustomerNo = inv.CustomerNo;
                    //    //invoice1.InvoiceDate = inv.InvoiceDate;
                    //    //invoice1.PaymentDueDate = inv.PaymentDueDate;
                    //    Payments.Add(Payment1);
                    //}

                    Payment PaymentEntity = new Payment();
                    PaymentEntity = dBContext1.Payment.FirstOrDefault(x => x.PaymentNo == Editpay.PaymentNo);
                    if (PaymentEntity != null)
                    {
                        PaymentEntity.PaymentNo = Editpay.PaymentNo;
                        PaymentEntity.InvoiceNo = Editpay.InvoiceNo;
                        PaymentEntity.PaymentAmount = Editpay.PaymentAmount;
                        //if(Editpay.PaymentDate == DateTime.MinValue)
                        //{
                        //    PaymentEntity.PaymentDate = DateTime.UtcNow;
                        //}
                        //else
                        //{ 
                        PaymentEntity.PaymentDate = Editpay.PaymentDate;
                        //}
                        PaymentEntity.ModifyDate = DateTime.Now;
                        PaymentEntity.ModifyBy = Editpay.ModifyBy;

                        dBContext1.Payment.Update(PaymentEntity);
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

        #region DeletePayment

        public int DeletePayment(string no)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Payment paymentEntity = new Payment();
                    paymentEntity = dBContext1.Payment.FirstOrDefault(x => x.PaymentNo == no);
                    if (paymentEntity != null)
                    {
                        dBContext1.Payment.Remove(paymentEntity);
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

        #region GetInvoiceNoByCustomerNo
        public List<InvoiceData> GetInvoiceNoByCustomerNo(string no)
        {
            List<InvoiceData> Invoices = new List<InvoiceData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    InvoiceData Invoice1;
                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        if (inv.CustomerNo == no)
                        {
                            Invoice1 = new InvoiceData();
                            Invoice1.InvoiceNo = inv.InvoiceNo;
                            Invoices.Add(Invoice1);
                        }
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

        #region GetInvoiceDetailsByNo
        public List<Invoice2Data> GetInvoiceDetailsByNo(string no)
        {
            List<Invoice2Data> Invoices = new List<Invoice2Data>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    Invoice2Data Invoice1;
                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        if (inv.InvoiceNo == no)
                        {
                            Invoice1 = new Invoice2Data();
                            Invoice1.InvoiceNo = inv.InvoiceNo;
                            Invoice1.InvoiceAmount = inv.InvoiceAmount;
                            Invoice1.InvoiceDate = inv.InvoiceDate;
                            Invoice1.PaymentDueDate = inv.PaymentDueDate;
                            Invoices.Add(Invoice1);
                        }
                    }
                    foreach (var pay in dBContext.Payment.ToList())
                    {
                        foreach (var a in Invoices)
                        {
                            if (pay.InvoiceNo == no)
                            {
                                a.PaymentAmount = a.PaymentAmount + pay.PaymentAmount;
                            }
                        }
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

        #region GetCustNoByInvNo
        string a;

        public List<CustomerData> GetCustNoByInvNo(string no)
        {
            List<CustomerData> Customers = new List<CustomerData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    CustomerData C1;
                    foreach (var inv in dBContext.Invoice.ToList())
                    {
                        if (inv.InvoiceNo == no)
                        {
                            C1 = new CustomerData();
                            C1.CustomerNo = inv.CustomerNo;
                            Customers.Add(C1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Customers;
        }
        #endregion

        #region ShowPaymentNoByTable
        public List<PaymentData> ShowPaymentNoByTable()
        {
            List<PaymentData> Payments = new List<PaymentData>();
            List<PaymentData> Payments1 = new List<PaymentData>();
            //List<AutoIncrimentNoData> Autos = new List<AutoIncrimentNoData>();
            using (var dBContext = new CustomersDatabaseContext())
            {
                PaymentData Pay1;
                foreach (var pay in dBContext.Payment.ToList())
                {
                    Pay1 = new PaymentData();
                    Pay1.PaymentNo = pay.PaymentNo;
                    Payments.Add(Pay1);
                }

                PaymentData Payment2;
                foreach (var Au in dBContext.AutoIncrimentNo.ToList())
                {
                    Payment2 = new PaymentData();
                    int num;
                    num = Convert.ToInt32(Au.LastPaymentNo);
                    num += 1;

                    str = "P" + num.ToString("D5");
                    X:
                    bool No = Payments.Any(x => x.PaymentNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        num += 1;
                        str = "P" + num.ToString("D5");
                        goto X;

                    }
                    str1 = str.Substring(1);
                    Payment2.PaymentNo = str1;
                    Payments1.Add(Payment2);
                }

            }

            return Payments1;

        }
        #endregion

    }
}
