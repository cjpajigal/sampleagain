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
    public partial class AddValveManipulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveValveManipulation();
        }

        private void SaveValveManipulation()
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "alert('Hello!')", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "window.opener.location.reload();window.close();", true);
            try
            {
                Int32 intCarID = Convert.ToInt32(Request.QueryString["CarID"]);
                CarDetails objCarDetails = new CarDetails();
                Details_ValveManipulationTable objValveManipulation = new Details_ValveManipulationTable();

                objValveManipulation.CARID = Convert.ToInt32(Request.QueryString["CarID"]);
                objValveManipulation.Location = txtLocation.Text;
                objValveManipulation.Size = txtSize.Text;
                objValveManipulation.PresentStatus = txtPresentStatus.Text;
                objValveManipulation.Proposed_Status = txtProposedStatus.Text;
                objValveManipulation.Status_After_the_Activity = txtStatusAfActivity.Text;
                if (objCarDetails.AddValveManipulation(objValveManipulation) == true)
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