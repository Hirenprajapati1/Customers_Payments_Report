using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Customers_Payments_Report.Models;
using Customers_Payments_Report.Models.Entity;

namespace Customers_Payments_Report.Repository
{
    public class GetData : IGetData
    {
        #region ReportPayfinaloutput

        public List<Models.common.Report> GetReportPay()
        {
            List<Models.common.Report> Reports = new List<Models.common.Report>();
            #region Comment
            //List<Models.common.Report> ReportData = new List<Models.common.Report>();
            //List<Models.common.Pyment> Payments = new List<Models.common.Pyment>();
            //List<Models.common.Invoice> Invoices = new List<Models.common.Invoice>();
            //List<Models.common.Customer> Customers = new List<Models.common.Customer>();
            #endregion
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    Models.common.Report Report1;
                    int i = 0;
                    foreach (var Inv in dBContext.Invoice.ToList())
                    {
                        Report1 = new Models.common.Report();
                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo);
                        #region Comment
                        //i++;
                        //Report1.No = i;

                        //Report1.YearInvoice = (Inv.InvoiceDate).Year;
                        //Report1.MonthInvoice = (Inv.InvoiceDate).Month;
                        //Report1.MonthInvoice = Inv.InvoiceDate.Month;
                        //Report1.YearInvoice = Inv.InvoiceDate.Year;
                        //Report1.MonthPay = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Month;
                        //Report1.YearPay = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Year;
                        //Report1.DateOfMonthInvoice = new DateTime(Report1.YearInvoice, Report1.MonthInvoice, 11);
                        //Report1.DateOfMonthPay = new DateTime(Report1.YearPay, Report1.MonthPay, 11);
                        #endregion
                        Report1.DateOfMonthInvoice = new DateTime(Inv.InvoiceDate.Year, Inv.InvoiceDate.Month, 11);

                        Report1.DateOfMonth = Report1.DateOfMonthInvoice;

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Inv.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Report1.NoOfInvoices = 1;
                        //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if (a.DateOfMonthInvoice == Report1.DateOfMonthInvoice && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                a.Sales = Inv.InvoiceAmount + a.Sales;
                                a.NoOfInvoices = a.NoOfInvoices + 1;
                                b = true;
                            }


                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            Report1.Sales = Inv.InvoiceAmount;
                            i++;
                            Report1.No = i;
                            Reports.Add(Report1);
                        }

                    }
                    //  var inv = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo);
                    foreach (var PayInv in dBContext.Pyment.ToList())
                    {
                        Report1 = new Models.common.Report();
                        var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == PayInv.InvoiceNo);

                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                        if (PayInv != null)
                        {
                            Report1.DateOfMonthPay = new DateTime(PayInv.PaymentDate.Year, PayInv.PaymentDate.Month, 11);
                            Report1.DateOfMonth = Report1.DateOfMonthPay;
                        }

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Cust.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                if (PayInv != null)
                                {
                                    a.PaymentCollection = PayInv.PaymentAmount + a.PaymentCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            if (PayInv != null)
                            {
                                Report1.PaymentCollection = PayInv.PaymentAmount;
                            }
                            Reports.Add(Report1);
                        }

                    }

                    #region Old
                    //foreach (var Inv in dBContext.Invoice.ToList())
                    //{
                    //    var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo);
                    //    Report1 = new Models.common.Report();

                    //    Report1.CustomerNo = Inv.CustomerNo;
                    //    if(Cust != null)
                    //    {
                    //        Report1.CustomerName = Cust.CustomerName;
                    //    }

                    //    var payinv = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo);
                    //    //if (Report1.CustomerNo == "C00002" && payinv.PaymentDate.Month == 3)
                    //    //{
                    //    //    break;
                    //    //}

                    //    if (payinv != null)
                    //    {
                    //        #region Comment
                    //        //Report1.MonthPay = payinv.PaymentDate.Month;
                    //        //Report1.YearPay = payinv.PaymentDate.Year;
                    //        //Report1.DateOfMonthPay = new DateTime(Report1.YearPay, Report1.MonthPay, 11);
                    //        #endregion
                    //        Report1.DateOfMonthPay = new DateTime(payinv.PaymentDate.Year, payinv.PaymentDate.Month, 11);
                    //    }
                    //    #region comment
                    //    //Report1.MonthPay = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Month;
                    //    //Report1.YearPay = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Year;
                    //    //Report1.DateOfMonthInvoice = new DateTime(Report1.YearInvoice, Report1.MonthInvoice, 11);
                    //    #endregion
                    //    Boolean b = false;

                    //    foreach (var a in Reports)
                    //    {
                    //        //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                    //        if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
                    //        {

                    //            if (payinv != null)
                    //            { 
                    //            a.PaymentCollection = a.PaymentCollection + payinv.PaymentAmount;
                    //            }
                    //            #region Comment
                    //            //a.PaymentCollection = a.PaymentCollection + payinv.PaymentAmount;
                    //            //a.Sales = Inv.InvoiceAmount + a.Sales;
                    //            //a.NoOfInvoices = a.NoOfInvoices + 1;
                    //            #endregion
                    //            b = true;
                    //        }
                    //    }
                    //    if(b == false)
                    //    {
                    //        Report1.DateOfMonth = Report1.DateOfMonthPay;

                    //        //Report1.DateOfMonth=Report1.DateOfMonthPay;
                    //        if(payinv != null)
                    //        {
                    //        Report1.PaymentCollection = payinv.PaymentAmount;
                    //        }
                    //        Reports.Add(Report1);

                    //    }
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();
            return Reports;
        }

        #endregion

        #region Callaction
        public List<Models.common.Report> GetReportCallaction()
        {
            List<Models.common.Report> Reports = new List<Models.common.Report>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    Models.common.Report Report1;
                    foreach (var PayInv in dBContext.Pyment.ToList())
                    {
                        Report1 = new Models.common.Report();
                        var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == PayInv.InvoiceNo);

                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                        if(PayInv != null)
                        {
                            Report1.DateOfMonthPay = new DateTime(PayInv.PaymentDate.Year, PayInv.PaymentDate.Month, 11);
                            Report1.DateOfMonth = Report1.DateOfMonthPay;
                        }

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Cust.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if (a.DateOfMonthPay == Report1.DateOfMonthPay && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                             if(PayInv != null)
                                {
                                    a.PaymentCollection = PayInv.PaymentAmount + a.PaymentCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            if(PayInv != null)
                            {
                                Report1.PaymentCollection = PayInv.PaymentAmount;
                            }
                            Reports.Add(Report1);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();
            return Reports;
        }
        #endregion

        #region Report
        //public List<Models.common.Report> GetReport()
        //{
        //    List<Models.common.Report> Reports = new List<Models.common.Report>();
        //    List<Models.common.Report> ReportData = new List<Models.common.Report>();
        //    //List<Models.common.Pyment> Payments = new List<Models.common.Pyment>();
        //    //List<Models.common.Invoice> Invoices = new List<Models.common.Invoice>();
        //    //List<Models.common.Customer> Customers = new List<Models.common.Customer>();

        //    try
        //    {
        //        using (var dBContext = new CustomersDatabaseContext())
        //        {
        //            //GetEmployee
        //            Models.common.Report Report1;
        //            int i = 0;
        //            foreach (var Inv in dBContext.Invoice.ToList())
        //            {
        //                Report1 = new Models.common.Report();
        //                //i++;
        //                //Report1.No = i;

        //                Report1.YearInvoice = (Inv.InvoiceDate).Year;
        //                Report1.MonthInvoice = (Inv.InvoiceDate).Month;
        //                //Report1.Month = (dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate).Month;
        //                //Report1.Year = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Year;
        //                Report1.DateOfMonth = new DateTime(Report1.YearInvoice, Report1.MonthInvoice, 15);
        //                //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
        //                Report1.CustomerNo = Inv.CustomerNo;
        //                Report1.CustomerName = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo).CustomerName;
        //                Report1.NoOfInvoices = 1;
        //                //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                Boolean b = false;
        //                foreach (var a in Reports)
        //                {
        //                    //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
        //                    if (a.DateOfMonth == Report1.DateOfMonth && a.CustomerNo == Report1.CustomerNo)
        //                    {
        //                        //a.PaymentCollection = a.PaymentCollection;
        //                        a.Sales = Inv.InvoiceAmount + a.Sales;
        //                        a.NoOfInvoices = a.NoOfInvoices + 1;
        //                        b = true;
        //                    }
        //                }
        //                if (b == false)
        //                {
        //                    // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                    Report1.Sales = Inv.InvoiceAmount;
        //                }
        //                //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                //Report1.PaymentDate = Pay.PaymentDate;
        //                //Report1.PaymentAmount = Pay.PaymentAmount;

        //                //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;
        //                if (b == false)
        //                {
        //                    i++;
        //                    Report1.No = i;

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

        //    //var result = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e =>e.CustomerName);

        //    //foreach(var d1 in result)
        //    //{

        //    //}
        //    //List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();
        //    Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();

        //    return Reports;
        //}
        //#endregion

        //#region  GetReportData
        //public List<Models.common.CustomerReport> GetReportData()
        //{
        //    List<Models.common.CustomerReport> Reports = new List<Models.common.CustomerReport>();
        //    List<Models.common.CustomerReport> ReportData = new List<Models.common.CustomerReport>();

        //    try
        //    {
        //        using (var dBContext = new CustomersDatabaseContext())
        //        {

        //            Models.common.CustomerReport Report1;
        //            int i = 0;
        //            int year1 = 2019;
        //            int month1 = 1;
        //            foreach (var Inv in dBContext.Invoice.ToList())
        //            {
        //                Report1 = new Models.common.CustomerReport();
        //                //i++;
        //                //Report1.No = i;
        //                if (Inv.InvoiceNo == null && dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount == 0)
        //                {
        //                    if (month1 == 12)
        //                    {
        //                        month1 = 0;
        //                        year1 = year1 + 1;
        //                    }
        //                    month1 = month1 + 1;
        //                }
        //                Report1.Month = month1;
        //                Report1.Year = year1;

        //                //Report1.Year = (Inv.InvoiceDate).Year;
        //                //Report1.Month = (Inv.InvoiceDate).Month;

        //                //Report1.Month = (dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate).Month;
        //                //Report1.Year = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate.Year;
        //                Report1.DateOfMonth = new DateTime(Report1.Year, Report1.Month, 15);

        //                //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
        //                Report1.CustomerNo = Inv.CustomerNo;
        //                Report1.CustomerName = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo).CustomerName;
        //                Report1.NoOfInvoices = 1;
        //                //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                Boolean b = false;
        //                foreach (var a in Reports)
        //                {
        //                    //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
        //                    if (a.Month == month1 && a.Year == year1 && a.CustomerNo == Report1.CustomerNo)
        //                    {
        //                        //a.PaymentCollection = a.PaymentCollection;
        //                        a.Sales = Inv.InvoiceAmount + a.Sales;
        //                        a.NoOfInvoices = a.NoOfInvoices + 1;
        //                        b = true;
        //                    }
        //                }
        //                if (b == false)
        //                {
        //                    // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                    Report1.Sales = Inv.InvoiceAmount;
        //                }
        //                //Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
        //                //Report1.PaymentDate = Pay.PaymentDate;
        //                //Report1.PaymentAmount = Pay.PaymentAmount;

        //                //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;
        //                if (b == false)
        //                {
        //                    i++;
        //                    Report1.No = i;

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

        //    //var result = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e =>e.CustomerName);

        //    //foreach(var d1 in result)
        //    //{

        //    //}
        //    //List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();
        //    Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();

        //    return Reports;
        //}
        #endregion

        #region ListData
        public List<Models.common.Customer> GetCustomers()
        {
            List<Models.common.Customer> Customers = new List<Models.common.Customer>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    Models.common.Customer Customer1;
                    foreach (var Cu in dBContext.Customer.ToList())
                    {
                        Customer1 = new Models.common.Customer();
                        Customer1.CustomerNo = Cu.CustomerNo;
                        Customer1.CustomerName = Cu.CustomerName;

                        //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;

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
        public List<Models.common.Invoice> GetInvoices()
        {
            List<Models.common.Invoice> Invoices = new List<Models.common.Invoice>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    Models.common.Invoice Invoice1;
                    foreach (var Invo in dBContext.Invoice.ToList())
                    {
                        Invoice1 = new Models.common.Invoice();
                        Invoice1.InvoiceNo = Invo.InvoiceNo;
                        Invoice1.CustomerNo = Invo.CustomerNo;
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
        public List<Models.common.Pyment> GetPayments()
        {
            List<Models.common.Pyment> Payments = new List<Models.common.Pyment>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    Models.common.Pyment Payment1;
                    foreach (var Pay in dBContext.Pyment.ToList())
                    {
                        Payment1 = new Models.common.Pyment();
                        Payment1.PaymentNo = Pay.PaymentNo;
                        Payment1.InvoiceNo = Pay.InvoiceNo;
                        Payment1.PaymentDate = Pay.PaymentDate;
                        Payment1.PaymentAmount = Pay.PaymentAmount;

                        //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;

                        Payments.Add(Payment1);

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

        #region a
        //public List<Models.common.Report> GetReport()
        //{
        //    List<Models.common.Report> Reports = new List<Models.common.Report>();
        //    try
        //    {
        //        using (var dBContext = new CustomersDatabaseContext())
        //        {
        //            //List<Customer> customers = dBContext.Customer.ToList();
        //            //List<Invoice> invoices = dBContext.Invoice.ToList();
        //            //List<Pyment> pyments = dBContext.Pyment.ToList();

        //            var Reportinfo = (
        //                from Inv in dBContext.Invoice
        //                join Cust in dBContext.Customer on Inv.CustomerNo equals Cust.CustomerNo
        //                join Py in dBContext.Pyment on Inv.InvoiceNo equals Py.InvoiceNo
        //                select new
        //                {

        //                }
        //                );
        //            ////GetEmployee
        //            //Models.common.Report Report1;
        //            //foreach (var Rep in dBContext.Pyment.ToList())
        //            //{
        //            //    Report1 = new Models.common.Report();
        //            //    Report1.MonthInvoice = Pay.PaymentNo;
        //            //    Report1.InvoiceNo = Pay.InvoiceNo;
        //            //    Report1.PaymentDate = Pay.PaymentDate;
        //            //    Report1.PaymentAmount = Pay.PaymentAmount;

        //            //    //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;

        //            //    Payments.Add(Payment1);

        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //throw;
        //    }
        //    return Reports;
        //}
        #endregion

    }
}
