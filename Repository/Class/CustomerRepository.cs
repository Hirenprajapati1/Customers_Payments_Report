using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class CustomerRepository : ICustomerRepository
    {
        string str;

        #region ListCustomers
        public List<CustomerData> GetCustomers()
        {
            List<CustomerData> Customers = new List<CustomerData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    CustomerData Customer1;
                    foreach (var Cu in dBContext.Customer.ToList())
                    {
                        Customer1 = new CustomerData();
                        //           Customer1.Customerid = Cu.Customerid;
                        Customer1.CustomerNo = Cu.CustomerNo;
                        Customer1.CustomerName = Cu.CustomerName;
                        Customers.Add(Customer1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return Customers;
        }
        #endregion

        #region ShowCustomerNo
        public List<CustomerData> ShowCustomerNo()
        {
            List<CustomerData> Customers = new List<CustomerData>();
            List<CustomerData> Customers1 = new List<CustomerData>();
            using (var dBContext = new CustomersDatabaseContext())
            {

                //GetCustomerNO
                CustomerData Customer1;
                foreach (var Cust in dBContext.Customer.ToList())
                {
                    Customer1 = new CustomerData();
                    Customer1.CustomerNo = Cust.CustomerNo;
                    Customers.Add(Customer1);
                }

                //     foreach (var Cust1 in dBContext.Customer.ToList())
                {
                    string s = "0";
                    int number = Convert.ToInt32(s);
                    number += 1;
                    str = "C" + number.ToString("D5");
                    X:
                    bool No = Customers.Any(x => x.CustomerNo == str);
                    if (No == true)
                    {
                        //   str = str.Substring(1);
                        number += 1;
                        str = "C" + number.ToString("D5");
                        goto X;

                    }
                }

                CustomerData Customer2;
                Customer2 = new CustomerData();
                Customer2.CustomerNo = str;
                Customers1.Add(Customer2);
                return Customers1;

            }
        }
        #endregion

        #region AddCustomer
        public int AddCustomer(CustomerData CustomerModel, string Customerno)
        {
            int returnVal = 0;
            List<CustomerData> Customers = new List<CustomerData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetCustomerNO
                    CustomerData Customer1;
                    foreach (var Cust in dBContext.Customer.ToList())
                    {
                        Customer1 = new CustomerData();
                        Customer1.CustomerNo = Cust.CustomerNo;
                        Customers.Add(Customer1);
                    }
                    //AddCustomer
                    Customer CustomerEntity = new Customer();
                    if (CustomerModel.CustomerNo == null)
                    {
                        ShowCustomerNo();
                        CustomerModel.CustomerNo = str;
                    }

                    CustomerEntity.CustomerNo = CustomerModel.CustomerNo;
                    CustomerEntity.CustomerName = CustomerModel.CustomerName;
                    //       Customerno = CustomerEntity.CustomerNo;

                    bool CustomerNoexist = Customers.Any(x => x.CustomerNo == CustomerEntity.CustomerNo);
                    if (CustomerNoexist == true)
                    {
                        returnVal = -1;
                    }

                    if (CustomerNoexist == false)
                    {
                        dBContext.Customer.Add(CustomerEntity);
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

        #region GetCustomerById

        public CustomerData GetCustomerById(string no)
        {
            CustomerData CustomerDatas = new CustomerData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var Cust = dBContext.Customer.Where(x => x.CustomerNo == no).SingleOrDefault();
                    if (Cust != null)
                    {
                        //            CustomerDatas.Customerid = Cust.Customerid;
                        CustomerDatas.CustomerNo = Cust.CustomerNo;
                        CustomerDatas.CustomerName = Cust.CustomerName;
                    }
                    return CustomerDatas;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        #endregion

        #region UpdateCustomer

        public int UpdateCustomer(CustomerData EditCust, string CustomerNo)
        {
            List<CustomerData> Customers = new List<CustomerData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    //// GetCustomer
                    // CustomerData Customer1;
                    // foreach (var cust in dBContext1.Customer.ToList())
                    // {
                    //     Customer1 = new CustomerData();
                    ////     Customer1.Customerid = cust.Customerid;
                    //     Customer1.CustomerNo = cust.CustomerNo;
                    //     Customers.Add(Customer1);
                    // }


                    Customer CustomerEntity = new Customer();
                    CustomerEntity = dBContext1.Customer.FirstOrDefault(x => x.CustomerNo == EditCust.CustomerNo);
                    if (CustomerEntity != null)
                    {
                        CustomerEntity.CustomerNo = EditCust.CustomerNo;
                        CustomerEntity.CustomerName = EditCust.CustomerName;
                        dBContext1.Customer.Update(CustomerEntity);
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

        #region DeleteCustomer

        public int DeleteCustomer(string no)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Customer customerEntity = new Customer();
                    Invoice invoiceEntity = new Invoice();
                    //        Payment paymentEntity = new Payment();
                    //  CustomerData DeleteCust = new CustomerData();
                    customerEntity = dBContext1.Customer.FirstOrDefault(x => x.CustomerNo == no);
                    invoiceEntity = dBContext1.Invoice.FirstOrDefault(x => x.CustomerNo == no);
                    //if (invoiceEntity != null)
                    //{
                    //    paymentEntity = dBContext1.Payment.FirstOrDefault(x => x.InvoiceNo == invoiceEntity.InvoiceNo);
                    //}

                    if (invoiceEntity == null)
                    {
                        if (customerEntity != null)
                        {
                            dBContext1.Customer.Remove(customerEntity);
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

        //#region ListInvPayDelete

        //public List<DeleteData> ListInvPayDelete(string Cust_NO)
        //{
        //    List<DeleteData> Datas = new List<DeleteData>();
        //    try
        //    {
        //        using (var dBContext = new CustomersDatabaseContext())
        //        {
        //            DeleteData Del1;
        //            foreach (var Inv in dBContext.Invoice.ToList())
        //            {
        //                Del1 = new DeleteData();
        //                if (Inv.CustomerNo == Cust_NO)
        //                {
        //                    var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Cust_NO);
        //                    if (Cust != null)
        //                    {
        //                        Del1.CustomerNo = Cust_NO;
        //                        Del1.CustomerName = Cust.CustomerName;
        //                        Del1.InvoiceNo = Inv.InvoiceNo;
        //                        Del1.InvoiceAmount = Inv.InvoiceAmount;
        //                        Del1.InvoiceDate = Inv.InvoiceDate;
        //                        Datas.Add(Del1);
        //                    }
        //                }
        //            }
        //            foreach (var PayInv in dBContext.Payment.ToList())
        //            {
        //                Del1 = new DeleteData();
        //                if (PayInv != null)
        //                {
        //                    var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == PayInv.InvoiceNo);
        //                    Report1.DateOfMonthPay = new DateTime(PayInv.PaymentDate.Year, PayInv.PaymentDate.Month, 11);
        //                    Report1.DateOfMonth = Report1.DateOfMonthPay;

        //                    if (inv != null)
        //                    {
        //                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
        //                        if (Cust != null)
        //                        {

        //                            Report1.CustomerNo = Cust.CustomerNo;
        //                            Report1.CustomerName = Cust.CustomerName;
        //                        }
        //                    }
        //                }
        //                Boolean b = false;

        //                foreach (var a in Reports)
        //                {
        //                    //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
        //                    if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
        //                    {
        //                        //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                        if (PayInv != null)
        //                        {
        //                            a.PaymentCollection = PayInv.PaymentAmount + a.PaymentCollection;
        //                        }
        //                        b = true;
        //                    }
        //                }
        //                if (b == false)
        //                {
        //                    // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                    if (PayInv != null)
        //                    {
        //                        Report1.PaymentCollection = PayInv.PaymentAmount;
        //                    }
        //                    Reports.Add(Report1);
        //                }


        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //throw;
        //    }
        //    return PaymentDelete;
        //}


        //#endregion


    }
}
