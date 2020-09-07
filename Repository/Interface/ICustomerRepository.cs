using Customers_Payments_Report.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.Repository.Interface
{
    public interface ICustomerRepository
    {
        public List<CustomerData> GetCustomers();
        public int AddCustomer(CustomerData CustomerModel, string CustomerNo);
        public CustomerData GetCustomerById(int id);
        public int DeleteCustomer(int Id);
    }
}
