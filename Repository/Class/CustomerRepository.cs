using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Class
{
    public class CustomerRepository : ICustomerRepository
    {
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
                    CustomerEntity.CustomerNo = CustomerModel.CustomerNo;
                    CustomerEntity.CustomerName = CustomerModel.CustomerName;
                    Customerno = CustomerEntity.CustomerNo;

                    bool CustomerNoexist = Customers.Any(x => x.CustomerNo == Customerno);
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

    }
}
