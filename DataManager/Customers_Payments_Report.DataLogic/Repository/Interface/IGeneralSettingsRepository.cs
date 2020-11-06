using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.DataLogic.Repository.Interface
{
    public interface IGeneralSettingsRepository
    {
        public List<GeneralSettingsData> ListGeneralSettings();
        public int UpdateGeneralSettings(GeneralSettingsData EditGS, int id);

    }
}
