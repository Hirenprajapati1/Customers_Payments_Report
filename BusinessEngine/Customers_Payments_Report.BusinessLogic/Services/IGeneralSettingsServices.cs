using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services
{
    public interface IGeneralSettingsServices
    {
        public List<GeneralSettingsData> ListGeneralSettings();
        public int UpdateGeneralSettings(GeneralSettingsData EditGS, int id);
    }
}
