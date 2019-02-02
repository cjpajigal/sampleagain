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

namespace IncidentManagement.Account
{
    public partial class ManageRoles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }


        protected void AddRole(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                IdentityResult IdRoleResult;
                var roleMgr = new RoleManager<IdentityRole>(roleStore);
                if (!roleMgr.RoleExists(RoleName.Text) && !(RoleName.Text == string.Empty))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = RoleName.Text });
                }
                else
                {
                    FailureText.Text = "Role already exists.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }

        protected void grdUsers_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlRoles = (DropDownList)e.Row.FindControl("ddlRole");
                    ddlRoles.DataSourceID = "sdsRoles";
                    ddlRoles.DataValueField = "Id";
                    ddlRoles.DataTextField = "Name";
                    ddlRoles.DataBind();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddlRoles.SelectedValue = dr["Role"].ToString();
                    if (ddlRoles.SelectedValue == "")
                    {
                        ddlRoles.Items.Add(new ListItem { Text = "--Select--", Value = "-1", Selected = true });
                    }
                }
            }
        }

        protected void grdUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUsers.EditIndex = e.NewEditIndex;
            grdUsers.DataBind();
        }



        protected void grdUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddlRoles = (DropDownList)grdUsers.Rows[e.RowIndex].Cells[3].Controls[1];
            string userID = e.Keys[0].ToString();
            string userName = grdUsers.Rows[e.RowIndex].Cells[2].Text;

            using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())))
            using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
                sdsUsers.UpdateCommand = String.Format("Update AspNetUserRoles Set RoleId='{0}' where UserId='{1}'", ddlRoles.SelectedValue, userID);
                sdsUsers.DeleteCommand = String.Format("Delete from AspNetRoles where UserId='{0}'", userID);
                IList<string> currentRole = um.GetRoles(userID);
                if (currentRole.Count > 0)
                {
                    um.RemoveFromRoles(userID, currentRole[0]);
                }
                var userResult = um.AddToRole(userID, ddlRoles.SelectedItem.Text);
                if (!userResult.Succeeded)
                    throw new ApplicationException("Adding user '" + userName + "' to '" + ddlRoles.SelectedItem.Text + "' role failed with error(s): " + userResult.Errors);
            }
        }

        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userID = e.Keys[0].ToString();
            string userName = grdUsers.Rows[e.RowIndex].Cells[2].Text;

            using (var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())))
            using (var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
                UserInfoModel userinfo = new UserInfoModel();
                userinfo.DeleteUser(userID);
                grdUsers.DataBind();
            }
        }
    }
}
