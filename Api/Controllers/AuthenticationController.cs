using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers_Payments_Report.BusinessLogic.Services;

namespace Customers_Payments_Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class AuthenticationController : ControllerBase
    {

        private IAuthenticateServices _authenticateService;
        public AuthenticationController(IAuthenticateServices authenticateService)
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


   

    }
}