using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface ICustomerServices
    {
        public List<CustomerData> ShowCustomerNo();
        public List<CustomerData> GetCustomers();
        public int AddCustomer(CustomerData CustomerModel, string CustomerNo);
        public CustomerData GetCustomerById(string no);
        public int UpdateCustomer(CustomerData EditCust, string CustomerNo);
        public int DeleteCustomer(string no);
        public List<CustomerData> ShowCustomerNoByTable();
    }
}
