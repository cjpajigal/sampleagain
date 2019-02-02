using IncidentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentManagement
{
    public partial class AddMethodology : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calPropDate_SelectionChanged(object sender, EventArgs e)
        {
            txtStart.Text = calPropDate.SelectedDate.ToShortDateString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string strCarID = Request.QueryString["CarID"].ToString();
                Methodology met = new Methodology();
                met.CreateNewMethodology(strCarID, txtActivity.Text, txtStart.Text);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "javascript:RefreshParent();", true);
            }
            catch (Exception err)
            {
                Response.Write(err.ToString());
            }
            
        }
    }
}