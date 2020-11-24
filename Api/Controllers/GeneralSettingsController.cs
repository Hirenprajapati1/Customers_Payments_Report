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

namespace Customers_Payments_Report.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class GeneralSettingsController : ControllerBase
    {
        private readonly IGeneralSettingsServices _generalSettingsServices;
        public GeneralSettingsController(IGeneralSettingsServices generalSettingsServices)
        {
            _generalSettingsServices = generalSettingsServices;
        }

        [HttpGet("ListGeneralSettings")]
        public List<GeneralSettingsData> ListGeneralSettings()
        {
            return _generalSettingsServices.ListGeneralSettings();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateGeneralSettings")]  
        public int UpdateGeneralSettings([FromBody] GeneralSettingsData EditGS, int id)
        {
            return _generalSettingsServices.UpdateGeneralSettings(EditGS,id );
        }

    }
}