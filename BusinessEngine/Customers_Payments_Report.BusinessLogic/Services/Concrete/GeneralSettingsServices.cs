using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;
using Customers_Payments_Report.DataLogic.Repository.Interface;
namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class GeneralSettingsServices : IGeneralSettingsServices
    {
        private readonly IGeneralSettingsRepository _generalSettingsRepository;
        public GeneralSettingsServices(IGeneralSettingsRepository generalSettingsRepository)
        {
            _generalSettingsRepository = generalSettingsRepository;
        }
        public List<GeneralSettingsData> ListGeneralSettings()
        {
            return _generalSettingsRepository.ListGeneralSettings();
        }

        public int UpdateGeneralSettings(GeneralSettingsData EditGS, int id)
        {
            return _generalSettingsRepository.UpdateGeneralSettings(EditGS, id);
        }
    }
}
