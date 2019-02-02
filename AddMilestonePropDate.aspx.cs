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
    public partial class AddMilestonePropDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SetProposedDate();
        }

        protected void calPropDate_SelectionChanged(object sender, EventArgs e)
        {
            txtPropDate.Text = calPropDate.SelectedDate.ToShortDateString();
        }


        private void SetProposedDate()
        {
            try
            {
                Int32 intCarID = Convert.ToInt32(Request.QueryString["DtlID"]);
                CarDetails objCarDetails = new CarDetails();
                Details_Milestones objMileStones = new Details_Milestones();

                objMileStones.CarID = intCarID;
                objMileStones.Propsed = Convert.ToDateTime(txtPropDate.Text);
                //objValveManipulation.Size = txtSize.Text;
                //objValveManipulation.PresentStatus = txtPresentStatus.Text;
                //objValveManipulation.Proposed_Status = txtProposedStatus.Text;
                //objValveManipulation.Status_After_the_Activity = txtStatusAfActivity.Text;
                if (objCarDetails.SetProposedDate(objMileStones) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "javascript:RefreshParent();", true);
                }
                else
                {

                }
            }
            catch (Exception err)
            {

            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc1", "javascript:CloseMe();", true);
        }
    }
}