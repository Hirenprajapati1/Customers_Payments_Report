using Customers_Payments_Report.DataLogic.Repository.Interface;
using Customers_Payments_Report.ModelData.Models.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers_Payments_Report.BusinessLogic.Services.Concrete
{
    public class AuthenticateServices : IAuthenticateServices
    {
        private IAuthenticateRepository _authenticateRepository;
        public AuthenticateServices(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }
        public int AddAdmin(AdminData AdminModel)
        {
            return _authenticateRepository.AddAdmin(AdminModel);
        }

        public AdminData Authenticate(AdminData Model)
        {
            return _authenticateRepository.Authenticate(Model);
        }

        public List<AdminData> GetAdmins()
        {
            return _authenticateRepository.GetAdmins();
        }
    }
}
