using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.BusinessLogic.Services;
using Customers_Payments_Report.BusinessLogic.Services.Concrete;

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customersServices)
        {
            _customerServices = customersServices;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ShowCustomerNo")]
        public List<CustomerData> ShowCustomerNo()
        {
            return _customerServices.ShowCustomerNo();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ShowCustomerNoByTable")]
        public List<CustomerData> ShowCustomerNoByTable()
        {
            return _customerServices.ShowCustomerNoByTable();
        }


        [HttpGet("GetCustomers")]
        public List<CustomerData> GetCustomers()
        {
            return _customerServices.GetCustomers();
        }


        //[HttpPost("AddCustomerNoByUser")]
        //public int AddCustomerNoByUser([FromBody] CustomerData cust)
        //{
        //    return _customerRepository.AddCustomerNoByUser(cust);
        //}
        [Authorize(Roles = "Admin")]
        [HttpPost("AddCustomer")]
        public int AddCustomer([FromBody] CustomerData cust, string CustomerNo)
        {
            return _customerServices.AddCustomer(cust, CustomerNo);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetCustomerById/{id}")]
        public CustomerData GetCustomerById(string id)
        {
            return _customerServices.GetCustomerById(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateCustomer/{id}")]
        public int UpdateCustomer([FromBody] CustomerData EditCust, string CustomerNo)
        {
            return _customerServices.UpdateCustomer(EditCust,CustomerNo);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCustomer/{id}")]
        public int DeleteCustomer(string id)
        {
            return _customerServices.DeleteCustomer(id);
        }

    }
}