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

    public class AuthenticationController : ControllerBase
    {

        private IAuthenticateRepository _authenticateService;
        public AuthenticationController(IAuthenticateRepository authenticateService)
        {
            _authenticateService = authenticateService;
        }

        #region Authenticate Login

        [HttpPost]
        public IActionResult Post([FromBody] AdminData Model)
        {
            var user = _authenticateService.Authenticate(Model);

            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });

            }
            else
            {
                return Ok(user);
            }
        }
        #endregion

        [HttpGet("GetAdminByID/{name}")]
        public AdminData GetAdminByID(string name)
        {
            return _authenticateService.GetAdminByID(name);

        }

        [HttpGet("GetAdmins")]
        public List<AdminData> GetAdmins()
        {
            return _authenticateService.GetAdmins();
        }

        [HttpPost("AddAdmin")]
        public int AddAdmin([FromBody] AdminData Ad)
        {
            return _authenticateService.AddAdmin(Ad);
        }


        [HttpPost("UpdateAdmin/{id}")]
        public int UpdateAdmin([FromBody] AdminData EditAdm)
        {
            return _authenticateService.UpdateAdmin(EditAdm);
        }

    }
}