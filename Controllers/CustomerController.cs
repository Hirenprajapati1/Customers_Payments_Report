using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet("GetCustomers")]
        public List<CustomerData> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        [HttpPost("AddCustomer")]
        public int AddCustomer([FromBody] CustomerData cust, string CustomerNo)
        {
            return _customerRepository.AddCustomer(cust, CustomerNo);
        }

    }
}