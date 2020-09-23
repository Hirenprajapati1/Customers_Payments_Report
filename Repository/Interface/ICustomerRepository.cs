using Customers_Payments_Report.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface ICustomerRepository
    {
        public List<CustomerData> ShowCustomerNo();
        public List<CustomerData> GetCustomers();
        public int AddCustomer(CustomerData CustomerModel, string CustomerNo);
        public CustomerData GetCustomerById(string no);
        public int UpdateCustomer(CustomerData EditCust, string CustomerNo);
        public int DeleteCustomer(string no);
    }
}
