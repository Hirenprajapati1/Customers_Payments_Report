using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {      
            _customerRepository = customerRepository;
        }

        public int AddCustomer(CustomerData CustomerModel, string CustomerNo)
        {
            return _customerRepository.AddCustomer(CustomerModel, CustomerNo);
        }

        public int DeleteCustomer(string no)
        {
            return _customerRepository.DeleteCustomer(no);
        }

        public CustomerData GetCustomerById(string no)
        {
            return _customerRepository.GetCustomerById(no);
        }

        public List<CustomerData> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public List<CustomerData> ShowCustomerNo()
        {
            return _customerRepository.ShowCustomerNo();
        }

        public List<CustomerData> ShowCustomerNoByTable()
        {
            return _customerRepository.ShowCustomerNoByTable();
        }

        public int UpdateCustomer(CustomerData EditCust, string CustomerNo)
        {
            return _customerRepository.UpdateCustomer(EditCust, CustomerNo);
        }
    }
}
