using IncidentManagement.DataModels;
using IncidentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentManagement
{
    public partial class AddNewUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUpdateBy.Text = Session["UserName"].ToString();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveValveManipulation();
        }

        private void SaveValveManipulation()
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                CarUpdates objCarUpdates = new CarUpdates();

                objCarUpdates.CarNumber = Convert.ToInt32(Request.QueryString["CarID"]);
                objCarUpdates.CreatedBy = txtUpdateBy.Text;
                objCarUpdates.Details = txtDetails.Text;
                objCarUpdates.DateCreated = DateTime.Parse(System.DateTime.Now.ToString());
                if (objCarDetails.AddNewUpdates(objCarUpdates) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "javascript:RefreshParent();", true);
                }
                else
                {
                    lblErr.Text = "Error is with model";
                    lblErr.Visible = true;
                }
            }
            catch (Exception err)
            {
                lblErr.Text = "Error is " + err.ToString();
                lblErr.Visible = true;
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc1", "javascript:CloseMe();", true);
        }
    }
}