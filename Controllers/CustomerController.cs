using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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


        [HttpGet("ShowCustomerNo")]
        public List<CustomerData> ShowCustomerNo()
        {
            return _customerRepository.ShowCustomerNo();
        }
    
        [HttpGet("ShowCustomerNoByTable")]
        public List<CustomerData> ShowCustomerNoByTable()
        {
            return _customerRepository.ShowCustomerNoByTable();
        }


        [HttpGet("GetCustomers")]
        public List<CustomerData> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }


        //[HttpPost("AddCustomerNoByUser")]
        //public int AddCustomerNoByUser([FromBody] CustomerData cust)
        //{
        //    return _customerRepository.AddCustomerNoByUser(cust);
        //}

        [HttpPost("AddCustomer")]
        public int AddCustomer([FromBody] CustomerData cust, string CustomerNo)
        {
            return _customerRepository.AddCustomer(cust, CustomerNo);
        }

        [HttpGet("GetCustomerById/{id}")]
        public CustomerData GetCustomerById(string id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        [HttpPost("UpdateCustomer/{id}")]
        public int UpdateCustomer([FromBody] CustomerData EditCust, string CustomerNo)
        {
            return _customerRepository.UpdateCustomer(EditCust,CustomerNo);
        }


        [HttpDelete("DeleteCustomer/{id}")]
        public int DeleteCustomer(string id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

    }
}