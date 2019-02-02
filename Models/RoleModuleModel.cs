using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Data;

namespace IncidentManagement.Models
{
    public class RoleModuleModel
    {

        public List<AspNetRole> GetRoles()
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var lstRoles = (from x in db.AspNetRoles
                                  select x).ToList();
                return lstRoles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Module> GetModules()
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var lstModules = (from x in db.Module
                                select x).ToList();
                return lstModules;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<RoleModule> GetRoleModule(string strRole)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var RoleModule = (from x in db.RoleModule
                              where x.RoleID == strRole
                              select x).ToList();
                return RoleModule;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteRoleMonitor(string strRole)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                List<RoleModule> lstRoleModule = db.RoleModule.Where(x => x.RoleID == strRole).ToList();
                db.RoleModule.RemoveRange(lstRoleModule);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void InsertRoleModules(string strRole, List<int> listModule)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                for (int i = 0; i < listModule.Count; i++)
                {
                    RoleModule objRoleModule = new RoleModule() { RoleID = strRole, ModuleID = listModule[i] };
                    db.RoleModule.Add(objRoleModule);
                    db.SaveChanges();
                }
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

        //public void DeleteUser(string sUserName)
        //{
        //    IncidentEntities db = new IncidentEntities();
        //    var user = db.AspNetUsers.Where(x => x.Id == sUserName).FirstOrDefault();
        //    if (user != null)
        //    {
        //        db.AspNetUsers.Remove(user);
        //        db.SaveChanges();
        //    }
        //}

    }

}