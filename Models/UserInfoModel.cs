using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class UserInfoModel
    {
        public UserInformation GetUserInformation(string guId)
        {
            IncidentEntities db = new IncidentEntities();
            var info = (from x in db.UserInformations
                        where x.GUID == guId
                        select x).FirstOrDefault();
            return info;
        }

        public AspNetUser GetAspNetUserDetails(string sUserName)
        {
            IncidentEntities db = new IncidentEntities();
            var info = (from x in db.AspNetUsers
                        where x .UserName== sUserName
                        select x).FirstOrDefault();
            return info;
        }

        public string GetRole(string sUserName)
        {
            IncidentEntities db = new IncidentEntities();
            var UserInfo = (from x in db.AspNetUsers
                        where x.UserName == sUserName
                        select x).FirstOrDefault();
            return UserInfo.AspNetRoles.FirstOrDefault().Name;
        }


        public bool SetModuleUser(string sUserName, string sModuleName)
        {
            IncidentEntities db = new IncidentEntities();
            var UserInfo = (from x in db.AspNetUsers
                            where x.UserName == sUserName
                            select x).FirstOrDefault();
            var ModuleInfo = (from x in db.Module
                            where x.ModuleName == sModuleName
                              select x).FirstOrDefault();
            string strRoleId = UserInfo.AspNetRoles.FirstOrDefault().Id;
            var lstRoleModules = (from x in db.RoleModule
                            where x.RoleID == strRoleId && x.ModuleID == ModuleInfo.ID
                             select x).ToList();
            if (lstRoleModules.Count > 0)
                return true;
            else
                return false;
        }

        public void InsertUserDetail(UserInformation userInformation)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db.UserInformations.Add(userInformation);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var entityValidationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        HttpContext.Current.Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

                    }
                }
            }
        }


        public void DeleteUser(string sUserName)
        {
            IncidentEntities db = new IncidentEntities();
            var user = db.AspNetUsers.Where(x => x.Id == sUserName).FirstOrDefault();
            if (user != null)
            {
                db.AspNetUsers.Remove(user);
                db.SaveChanges();
            }
           // return db.AspNetUsers;
        }

       

    }

}