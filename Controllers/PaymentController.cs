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

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        [HttpGet("GetPayments")]
        public List<PaymentData> GetPayments()
        {
            return _paymentRepository.GetPayments();
        }
        [HttpPost("AddPayment")]
        public int AddPayment([FromBody] PaymentData PaymentModel, string PaymentNo)
        {
            return _paymentRepository.AddPayment(PaymentModel, PaymentNo);
        }

    }
}