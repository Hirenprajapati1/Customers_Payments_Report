﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Customers_Payments_Report.Models.common;
using Customers_Payments_Report.Models.Entity;
using Customers_Payments_Report.Repository.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Customers_Payments_Report.Repository.Class
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly AppSetting _appSettings;
        public AuthenticateRepository(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        //private List<Admindata> users = new List<Admindata>()
        //{
        //    new Admindata{UserId = 1,FirstName="Hiren",LastName ="prajapati",
        //        UserName="Hiren",Password="1234"}
        //};

        #region AddAdmin
        public int AddAdmin(AdminData AdminModel)
        {
            int returnVal = 0;
            List<AdminData> Admins = new List<AdminData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetCustomerNO
                    AdminData Admin1;
                    foreach (var adm in dBContext.Admin.ToList())

                    {
                        Admin1 = new AdminData();
                        Admin1.username = adm.Name;
                        Admins.Add(Admin1);
                    }
                    //AddAdmin
                    Admin AdminEntity = new Admin();
                    AdminEntity.FirstName = AdminModel.FirstName;
                    AdminEntity.LastName = AdminModel.LastName;
                    AdminEntity.Name = AdminModel.username;
                    AdminEntity.Gender = AdminModel.Gender;
                    AdminEntity.Password = AdminModel.Password;
                    AdminEntity.Region = AdminModel.Region;
                    AdminEntity.CreatedDate = AdminModel.CreatedDate;
                    AdminEntity.ContactNo = AdminModel.ContactNo;
                    AdminEntity.Email = AdminModel.Email;
                    AdminEntity.CreatedDate = DateTime.Now;
                    bool AdminNameexist = Admins.Any(x => x.username.ToLower() == AdminEntity.Name.ToLower());
                    if (AdminNameexist == true)
                    {
                        returnVal = -1;
                    }

                    if (AdminNameexist == false)
                    {
                        dBContext.Admin.Add(AdminEntity);
                        returnVal = dBContext.SaveChanges();
                    }
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

        #region GetAdminByID

        public AdminData GetAdminByID(string name)
        {
            AdminData AdminDatas = new AdminData();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    var Adm = dBContext.Admin.Where(x => x.Name == name).SingleOrDefault();
                    if (Adm != null)
                    {
                        AdminDatas.username = Adm.Name;
                        AdminDatas.FirstName = Adm.FirstName;
                        AdminDatas.LastName = Adm.LastName;
                        AdminDatas.Region = Adm.Region;
                        AdminDatas.Gender = Adm.Gender;
                        AdminDatas.Email = Adm.Email;
                        AdminDatas.ContactNo = Adm.ContactNo;

                    }
                    return AdminDatas;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        #endregion


        #region EditAdmin

        public int UpdateAdmin(AdminData EditAdm)
        {
            List<AdminData> admins = new List<AdminData>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new CustomersDatabaseContext())
                {
                    Admin adminEntity = new Admin();
                    adminEntity = dBContext1.Admin.FirstOrDefault(x => x.Name == EditAdm.username);
                    if (adminEntity != null)
                    {
                        adminEntity.Name = EditAdm.username;
                        adminEntity.FirstName = EditAdm.FirstName;
                        adminEntity.LastName = EditAdm.LastName;
                        adminEntity.Email = EditAdm.Email;
                        adminEntity.ContactNo = EditAdm.ContactNo;
                        adminEntity.Region = EditAdm.Region;
                        adminEntity.Gender = EditAdm.Gender;
                        adminEntity.ModifyDate = DateTime.Now;
                        dBContext1.Admin.Update(adminEntity);
                    }
                    returnVal = dBContext1.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;

        }

        #endregion



        #region GetAdmin
        public List<AdminData> GetAdmins()
        {
            List<AdminData> Admins = new List<AdminData>();
            try
            {
                using (var dBContext = new CustomersDatabaseContext())
                {
                    //GetEmployee
                    AdminData Admin1;
                    foreach (var Adm in dBContext.Admin.ToList())
                    {
                        Admin1 = new AdminData();
                        //           Customer1.Customerid = Cu.Customerid;
                        Admin1.username = Adm.Name;
                        Admin1.FirstName = Adm.FirstName;
                        Admin1.LastName = Adm.LastName;
                        Admin1.Gender = Adm.Gender;
                        Admin1.Password = Adm.Password;
                        Admin1.Region = Adm.Region;

                        Admins.Add(Admin1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return Admins;
        }
        #endregion

        #region Authenticate Login
        public AdminData Authenticate(AdminData Model)
        {
            List<AdminData> users = new List<AdminData>();
    
            using (var dBContext = new CustomersDatabaseContext())
            {
                AdminData Admin1;
                foreach (var Adm in dBContext.Admin.ToList())
                {
                    Admin1 = new AdminData();
                    Admin1.username = Adm.Name;
                    Admin1.FirstName = Adm.FirstName;
                    Admin1.LastName = Adm.LastName;
                    Admin1.Region = Adm.Region;
                    Admin1.Gender = Adm.Gender;
                    Admin1.Password = Adm.Password;
                    users.Add(Admin1);
                }
            }

            var user = users.SingleOrDefault(x => x.username == Model.username && x.Password == Model.Password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    //new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddMinutes(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
        #endregion
    }
}
