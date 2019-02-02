using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using IncidentManagement.Models;
using IncidentManagement.DataModels;
using System.Collections.Generic;

namespace IncidentManagement.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(UserName.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        SetSessions();
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        private void SetSessions()
        {
            try
            {
                UserInfoModel objUserInfoModel = new UserInfoModel();
                Session["UserName"] = UserName.Text;
                Session["Role"] = objUserInfoModel.GetRole(UserName.Text);

                Session["UserManagement"] = objUserInfoModel.SetModuleUser(UserName.Text, "UserManagement"); 
                Session["RoleManagement"] = objUserInfoModel.SetModuleUser(UserName.Text, "RoleManagement");
                Session["GroupManagement"] = objUserInfoModel.SetModuleUser(UserName.Text, "GroupManagement");
                Session["AddEditDeleteIncidents"] = objUserInfoModel.SetModuleUser(UserName.Text, "AddEditDeleteIncidents");
                Session["AssignmentOfIncident"] = objUserInfoModel.SetModuleUser(UserName.Text, "AssignmentOfIncident");
                Session["InputProposedDateAndTime"] = objUserInfoModel.SetModuleUser(UserName.Text, "InputProposedDateAndTime");
                Session["UpdateIncidents"] = objUserInfoModel.SetModuleUser(UserName.Text, "UpdateIncidents");
                Session["CancelIncidents"] = objUserInfoModel.SetModuleUser(UserName.Text, "CancelIncidents");
                Session["ViewCharts"] = objUserInfoModel.SetModuleUser(UserName.Text, "ViewCharts");
            }
            catch (Exception Ex)
            {

            }
        }
    }
}