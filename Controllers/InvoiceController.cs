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

    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        [HttpGet("GetInvoices")]
        public List<InvoiceData> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }
        [HttpPost("AddInvoice")]
        public int AddInvoice([FromBody] InvoiceData InvoiceModel, string InvoiceNo)
        {
            return _invoiceRepository.AddInvoice(InvoiceModel, InvoiceNo);
        }

    }
}