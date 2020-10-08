using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
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
    public class GeneralSettingsController : ControllerBase
    {
        private readonly IGeneralSettingsRepository _generalSettingsRepository;
        public GeneralSettingsController(IGeneralSettingsRepository generalSettingsRepository)
        {
            _generalSettingsRepository = generalSettingsRepository;
        }

        [HttpGet("ListGeneralSettings")]
        public List<GeneralSettingsData> ListGeneralSettings()
        {
            return _generalSettingsRepository.ListGeneralSettings();
        }

        [HttpPost("UpdateGeneralSettings")]  
        public int UpdateGeneralSettings([FromBody] GeneralSettingsData EditGS, int id)
        {
            return _generalSettingsRepository.UpdateGeneralSettings(EditGS,id );
        }

    }
}