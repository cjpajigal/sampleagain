using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using IncidentManagement.Models;

namespace IncidentManagement
{
    public partial class _Default : Page
    {
        string connString = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            if (!user.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }

            ////if (!Helpers.isManager(Context.User) && !Helpers.isOccEngineer(Context.User))
            ////{
            ////    btnAddCar.Visible = false;
            ////}
            btnAddCar.Visible = Convert.ToBoolean(Session["AddEditDeleteIncidents"]);

            if (!Page.IsPostBack)
            {
                SetOimSimCimDetails();
                grvActMonitor.DataSource = BindMonitoring();
                grvActMonitor.DataBind();
            }
        }

        private void SetOimSimCimDetails()
        {
            try
            {
                UserInfoModel objUserInfoModel = new UserInfoModel();
                DataModels.AspNetUser objAspNetUser = new DataModels.AspNetUser();
                objAspNetUser = objUserInfoModel.GetAspNetUserDetails(Context.User.Identity.Name);
                ViewState["UserID"] = objAspNetUser.Id;
                if (Helpers.isOIM(Context.User))
                    ViewState["UserType"] = "OIM";
                else if (Helpers.isSIM(Context.User))
                    ViewState["UserType"] = "SIM";
                else if (Helpers.isCIM(Context.User))
                    ViewState["UserType"] = "CIM";
                else
                    ViewState["UserType"] = "NonOSC";
            }
            catch (Exception err)
            {
                lblErr.Visible = true;
                lblErr.Text = "Error is " + err.Message.ToString();
            }
        }

        protected void grvActMonitor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grvActMonitor.Rows[e.NewEditIndex];
            int rowID = Convert.ToInt32(row.Cells[1].Text);
            string strStatus = row.Cells[6].Text;
            Response.Redirect("~/CarEdit.aspx?id=" + rowID + "&Status= " + strStatus);
        }

        protected void grvActMonitor_OnPreRender(object sender, EventArgs e)
        {
            //if (!Helpers.isManager(Context.User) && !Helpers.isOccEngineer(Context.User))
            //{
            //    grvActMonitor.Columns[0].Visible = false;
            //}

            //if (!Helpers.isOccEngineer(Context.User) && !Helpers.isOimSimCim(Context.User))
            //{
            //    grvActMonitor.Columns[8].Visible = false;
            //}
            grvActMonitor.Columns[0].Visible = Convert.ToBoolean(Session["AddEditDeleteIncidents"]);
            grvActMonitor.Columns[8].Visible = Convert.ToBoolean(Session["UpdateIncidents"]);
            //Convert.ToBoolean(Session["AddEditDeleteIncidents"]);
        }

        protected void grvActMonitor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grvActMonitor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grvActMonitor.EditIndex != e.Row.RowIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void grvActMonitor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateDetails")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grvActMonitor.Rows[index];
                    int rowID = Convert.ToInt32(row.Cells[1].Text);
                    string strStatus = row.Cells[6].Text;
                    Response.Redirect("~/EditCarDetails.aspx?id=" + rowID + "&IncidentStatus=" + strStatus, false);
                }
            }
            catch (Exception Err)
            {
                //throw;
            }
        }

        protected void grvActMonitor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intCarID = Convert.ToInt32(grvActMonitor.DataKeys[e.RowIndex].Value);

            //SqlConnection objConnection = new SqlConnection(connString);
            //SqlCommand cmd = new SqlCommand("DELETE FROM ActMonitor WHERE [CAR Number] = " + intCarID + "", objConnection);
            //objConnection.Open();
            //int temp = cmd.ExecuteNonQuery();
            //if (temp == 1)
            //{
            //    lblErr.Text = "Record deleted successfully";
            //}
            //objConnection.Close();
            try
            {
                ActMonitorModel objActMonitorModel = new ActMonitorModel();
                objActMonitorModel.DeleteIncident(intCarID);
                grvActMonitor.PageIndex = 0;
                grvActMonitor.DataSource = BindMonitoring();
                grvActMonitor.DataBind();
            }
            catch (Exception err)
            {
                lblErr.Text = "Error is " + err.ToString();
                lblErr.Visible = true;
            }
        }



        private DataTable BindMonitoring()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(connString);
                string query = "SELECT [CAR Number] AS CAR_Number , inci.Incident_Event as Incident, cls.Classification, activity.ActivityType AS Type_of_Activity,";
                query += "net.NetworkGrid_BA, act.Status, CASE  WHEN [Actual Date and Time of Service Interruption] IS NOT NULL THEN 'Red' ";
                query += "WHEN [Actual Date and Time of Completion] IS  NULL THEN 'Green' ";
                query += "WHEN [Actual Date and Time of Completion] IS NOT NULL AND DATEDIFF(HOUR, [Actual Date and Time of Start],GETDATE()) <= 8 THEN 'Yellow' ";
                query += "WHEN [Actual Date and Time of Completion] IS NOT NULL AND DATEDIFF(HOUR, [Actual Date and Time of Start],GETDATE()) > 8 THEN 'Red' END Color";
                query += " FROM ActMonitor act INNER JOIN Incident_Event inci on inci.ID = act.Incident INNER JOIN ActivityType activity on activity.ID = act.[Type of Activity] ";
                query += " INNER JOIN Classification cls on cls.ID = act.Classification INNER JOIN NetworkGrid_BA net on net.ID = act.[Network Grid/BA] where activity.IncidentID = inci.ID";
                
                if (Helpers.isOIM(Context.User))
                    query += " AND OIM = '" + ViewState["UserID"] + "'";
                else if (Helpers.isSIM(Context.User))
                    query += " AND SIM = '" + ViewState["UserID"] + "'";
                else if (Helpers.isCIM(Context.User))
                    query += " AND CIM = '" + ViewState["UserID"] + "'";

                query += " ORDER BY [CAR Number] DESC";
                SqlDataAdapter dap = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception err)
            {
                lblErr.Text = "Error is " + err.ToString();
                lblErr.Visible = true;
                return null;
            }
        }
        //Created by PS2019
        //Private Method to sorting for milestones
        protected void grdMilestones_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Descending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Asc";

            }
            else
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            DataView sortedView = new DataView(BindMonitoring());
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            Session["SortedView"] = sortedView;
            grvActMonitor.PageIndex = 0;
            grvActMonitor.DataSource = sortedView;
            grvActMonitor.DataBind();
        }

        //Created by PS2019
        //Private Method to set SortDirection
        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Descending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }


        protected void grvActMonitor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvActMonitor.PageIndex = e.NewPageIndex;
            if (Session["SortedView"] != null)
            {
                grvActMonitor.DataSource = Session["SortedView"];
                grvActMonitor.DataBind();
            }
            else
            {
                grvActMonitor.DataSource = BindMonitoring();
                grvActMonitor.DataBind();
            }
        }

        protected void ExcelBtn_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=IncidentsReport.xls");
            Response.ContentType = "application/excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

            grvActMonitor.HeaderRow.Style.Add("background-color", "White");
            foreach (TableCell tableCell in grvActMonitor.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#0000ff";
            }

            foreach (GridViewRow gridViewRow in grvActMonitor.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#add8e6";
                }

            }
            grvActMonitor.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }


        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CarAdd.aspx");
        }
    }
}