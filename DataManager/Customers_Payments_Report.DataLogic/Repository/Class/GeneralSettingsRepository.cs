using Customers_Payments_Report.ModelData.Models.common;
using Customers_Payments_Report.DataLogic.Entity;
using Customers_Payments_Report.DataLogic.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Payments_Report.DataLogic.Repository.Class
{
    public class GeneralSettingsRepository : IGeneralSettingsRepository
    {
        #region ListGeneralSettings
        public List<GeneralSettingsData> ListGeneralSettings()
        {
            List<GeneralSettingsData> generalSettings = new List<GeneralSettingsData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    GeneralSettingsData Setting1;
                    foreach (var GS in dBContext.GeneralSettings.ToList())
                    {
                        Setting1 = new GeneralSettingsData();
                        //           Customer1.Customerid = Cu.Customerid;
                        Setting1.AutoCustomerNo = GS.AutoCustomerNo;
                        Setting1.AutoInvoiceNo = GS.AutoInvoiceNo;
                        Setting1.AutoPaymentNo = GS.AutoPaymentNo;
                        generalSettings.Add(Setting1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return generalSettings;
        }
        #endregion

        #region UpdateGeneralSettings

        public int UpdateGeneralSettings(GeneralSettingsData EditGS ,int id)
        {
            List<GeneralSettingsData> GeneralSettings = new List<GeneralSettingsData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    GeneralSettings generalSettingsEntity = new GeneralSettings();
                    EditGS.Id = "1";
                    generalSettingsEntity = dBContext1.GeneralSettings.FirstOrDefault(x => x.Id == EditGS.Id);
                    if (generalSettingsEntity != null)
                    {
                        generalSettingsEntity.AutoCustomerNo = EditGS.AutoCustomerNo;
                        generalSettingsEntity.AutoInvoiceNo = EditGS.AutoInvoiceNo;
                        generalSettingsEntity.AutoPaymentNo = EditGS.AutoPaymentNo;
                        dBContext1.GeneralSettings.Update(generalSettingsEntity);
                    }
                    returnVal = dBContext1.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;

        }

        #endregion


    }
}
