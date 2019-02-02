using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using IncidentManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;
using IncidentManagement.DataModels;

namespace IncidentManagement.Account
{
    public partial class ManageRoleModules : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetRoles();
                GetModule();
                SetRoleModules();
            }
        }

        private void GetRoles()
        {
            RoleModuleModel objRoleModuleModel = new RoleModuleModel();
            List<AspNetRole> lstRoles = objRoleModuleModel.GetRoles();
            ddlRoles.DataSource = lstRoles;
            ddlRoles.DataValueField = "ID";
            ddlRoles.DataTextField = "Name";
            ddlRoles.DataBind();
        }


        private void GetModule()
        {
            RoleModuleModel objRoleModuleModel = new RoleModuleModel();
            List<Module> lstModules = objRoleModuleModel.GetModules();
            cbxRoleModules.DataSource = lstModules;
            cbxRoleModules.DataValueField = "ID";
            cbxRoleModules.DataTextField = "ModuleName";
            cbxRoleModules.DataBind();
        }
        
        // Handle Select index change event for Roles dropdown
        protected void ddlRoles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetRoleModules();
            DisplayEmail.Visible = false;
        }

        private void SetRoleModules()
        {
            RoleModuleModel objRoleModuleModel = new RoleModuleModel();
            List<RoleModule> lstRoleModule = objRoleModuleModel.GetRoleModule(ddlRoles.SelectedItem.Value);
            cbxRoleModules.ClearSelection();
            if (lstRoleModule.Count > 0)
            {
                for (int i = 0; i < cbxRoleModules.Items.Count; i++)
                {
                    for (int j = 0; j < lstRoleModule.Count; j++) // Loop through List with for
                    {
                        if (cbxRoleModules.Items[i].Value == lstRoleModule[j].ModuleID.ToString())
                        {
                            cbxRoleModules.Items[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        // Created by PS2019
        //To update module
        protected void UpdateModule(object sender, EventArgs e)
        {
            try
            {
                RoleModuleModel objRoleModuleModel = new RoleModuleModel();
                RoleModule objRoleModule = new RoleModule();
                objRoleModuleModel.DeleteRoleMonitor(ddlRoles.SelectedItem.Value);
                List<int> lstModules = new List<int>();
                for (int i = 0; i < cbxRoleModules.Items.Count; i++)
                {
                    if (cbxRoleModules.Items[i].Selected == true)
                        lstModules.Add(Convert.ToInt32(cbxRoleModules.Items[i].Value.ToString()));
                }
                objRoleModuleModel.InsertRoleModules(ddlRoles.SelectedItem.Value, lstModules);
                DisplayEmail.Visible = true;
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }
        }

        
    }

