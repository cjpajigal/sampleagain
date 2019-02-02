using IncidentManagement.DataModels;
using IncidentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace IncidentManagement
{
    public partial class Car2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    GetCarDetails(id);
                    disableCarDetails();
                }
            }

        }


        private void disableCarDetails()
        {
            if ( (Request.QueryString["Status"].ToString().Trim() == "Cancelled") || (Request.QueryString["Status"].ToString().Trim() == "Completed on time"))
            {
                ddlNetworkGrid.Enabled = false;
                ddlBusinessZone.Enabled = false;
                ddlDMZ.Enabled = false;
                ddlEquip.Enabled = false;
                ddlType.Enabled = false;
                ddlSize.Enabled = false;
                ddlClassification.Enabled = false;
                ddlEvent.Enabled = false;
                ddlAct.Enabled = false;
                ddlArea.Enabled = false;
                ddlContractor.Enabled = false;
                ddlMeans.Enabled = false;
                txtLocation.Enabled = false;
                txtMunicipality.Enabled = false;
                txtBrgy.Enabled = false;
                txtMRU.Enabled = false;
                txtDMA.Enabled = false;
                txtHousehold.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }
        // Created By PVMS
        // Get Details of Car
        public void GetCarDetails(int id)
        {
            try
            {
                ActMonitorModel actmonitormodel = new ActMonitorModel();
                ActMonitor actmonitor = actmonitormodel.RetrieveData(id);

                ddlNetworkGrid.SelectedValue = actmonitor.Network_Grid_BA.ToString();
                SetNetworkBusinessDMZ(actmonitor);

                txtRemarks.Text = actmonitor.Remarks__Comments;
                txtLocation.Text = actmonitor.Location;
                txtBrgy.Text = actmonitor.Affected_Barangay_s_;
                txtMunicipality.Text = actmonitor.Affected_Municipality;
                txtMRU.Text = actmonitor.List_of_Affected_MRUs;
                txtDMA.Text = actmonitor.List_of_Affected_DMAs;
                txtHousehold.Text = actmonitor.Number_of_Affected_Households.ToString();

                SetClassificationEvent(actmonitor);
                
                ddlEquip.SelectedValue = actmonitor.Equipment__Appurtenance.ToString();
                ddlType.SelectedValue = actmonitor.Type_of_Equipment_Appurtenance.ToString();
                ddlSize.SelectedValue = actmonitor.Size.ToString();
                ddlContractor.SelectedValue = actmonitor.Contractor.ToString();

            }
            catch (Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.ToString();
            }
            
        }

        // Created By PVMS
        // Set dropdownlist values for NetworkGrid, Business Zone, DMZ
        private void SetNetworkBusinessDMZ(ActMonitor actMonitor)
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                List<NetworkGrid_BA> objNetwork = objCarDetails.GetNetworkGrid();

                ddlNetworkGrid.DataSource = objNetwork;
                ddlNetworkGrid.DataValueField = "ID";
                ddlNetworkGrid.DataTextField = "NetworkGrid_BA1";
                ddlNetworkGrid.DataBind();
                ddlNetworkGrid.SelectedValue = actMonitor.Network_Grid_BA.ToString();

                List<BusinessZone_Grid> objBusiness = objCarDetails.GetBusinessZone(Convert.ToInt32(ddlNetworkGrid.SelectedValue));
                ddlBusinessZone.DataSource = objBusiness;
                ddlBusinessZone.DataValueField = "ID";
                ddlBusinessZone.DataTextField = "BusinessZone_Grid1";
                ddlBusinessZone.DataBind();
                ddlBusinessZone.SelectedValue = actMonitor.Business_Zone__Grid.ToString();

                List<DMZFacility> objDMZ = objCarDetails.GetDMZ(Convert.ToInt32(ddlBusinessZone.SelectedValue));
                ddlDMZ.DataSource = objDMZ;
                ddlDMZ.DataValueField = "ID";
                ddlDMZ.DataTextField = "DMZ_Facility";
                ddlDMZ.DataBind();
                ddlDMZ.SelectedValue = actMonitor.DMZ__Facility.ToString();
            }
            catch (Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.ToString();
            }
        }

        // Created By PVMS
        // Set dropdownlist values for Classification, Event, Activity Type
        private void SetClassificationEvent(ActMonitor actMonitor)
        {
            try {
                
                CarDetails objCarDetails = new CarDetails();

                List<Classification> objClassification = objCarDetails.GetClassification();

                ddlClassification.DataSource = objClassification;
                ddlClassification.DataValueField = "ID";
                ddlClassification.DataTextField = "Classification1";
                ddlClassification.DataBind();
                ddlClassification.SelectedValue = actMonitor.Classification.ToString();

                List<Incident_Event> objIncidentEvent = objCarDetails.GetIncidentEvent(Convert.ToInt32(ddlClassification.SelectedValue));
                ddlEvent.DataSource = objIncidentEvent;
                ddlEvent.DataValueField = "ID";
                ddlEvent.DataTextField = "Incident_Event1";
                ddlEvent.DataBind();
                ddlEvent.SelectedValue = actMonitor.Incident.ToString();

                List<ActivityType> objActivityType = objCarDetails.GetActivityType(Convert.ToInt32(ddlEvent.SelectedValue));
                ddlAct.DataSource = objActivityType;
                ddlAct.DataValueField = "ID";
                ddlAct.DataTextField = "ActivityType1";
                ddlAct.DataBind();
                ddlAct.SelectedValue = actMonitor.Type_of_Activity.ToString();
            }
            catch (Exception Err) {
                lblError.Visible = true;
                lblError.Text = Err.ToString();
            }
        }

        // Created By PVMS
        // Handle Select index change event for Clasfication dropdown
        protected void ddlClassification_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetails objCarDetails = new CarDetails();
            List<Incident_Event> objIncidentEvent = objCarDetails.GetIncidentEvent(Convert.ToInt32(ddlClassification.SelectedValue));
            ddlEvent.DataSource = objIncidentEvent;
            ddlEvent.DataValueField = "ID";
            ddlEvent.DataTextField = "Incident_Event1";
            ddlEvent.DataBind();

            List<ActivityType> objActivityType = objCarDetails.GetActivityType(Convert.ToInt32(ddlEvent.SelectedValue));
            ddlAct.DataSource = objActivityType;
            ddlAct.DataValueField = "ID";
            ddlAct.DataTextField = "ActivityType1";
            ddlAct.DataBind();
        }

        // Created By PVMS
        // Handle Select index change event for Event dropdown
        protected void ddlEvent_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetails objCarDetails = new CarDetails();
            List<ActivityType> objActivityType = objCarDetails.GetActivityType(Convert.ToInt32(ddlEvent.SelectedValue));
            ddlAct.DataSource = objActivityType;
            ddlAct.DataValueField = "ID";
            ddlAct.DataTextField = "ActivityType1";
            ddlAct.DataBind();
        }

        // Created By PVMS
        // Handle Select index change event for NetworkGrid dropdown
        protected void ddlNetworkGrid_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetails objCarDetails = new CarDetails();

            List<BusinessZone_Grid> objBusiness = objCarDetails.GetBusinessZone(Convert.ToInt32(ddlNetworkGrid.SelectedValue));
            ddlBusinessZone.DataSource = objBusiness;
            ddlBusinessZone.DataValueField = "ID";
            ddlBusinessZone.DataTextField = "BusinessZone_Grid1";
            ddlBusinessZone.DataBind();

            List<DMZFacility> objDMZ = objCarDetails.GetDMZ(Convert.ToInt32(ddlBusinessZone.SelectedValue));
            ddlDMZ.DataSource = objDMZ;
            ddlDMZ.DataValueField = "ID";
            ddlDMZ.DataTextField = "DMZ_Facility";
            ddlDMZ.DataBind();

        }

        // Created By PVMS
        // Handle Select index change event for BusinessZone dropdown
        protected void ddlBusinessZone_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetails objCarDetails = new CarDetails();
            List<DMZFacility> objDMZ = objCarDetails.GetDMZ(Convert.ToInt32(ddlBusinessZone.SelectedValue));
            ddlDMZ.DataSource = objDMZ;
            ddlDMZ.DataValueField = "ID";
            ddlDMZ.DataTextField = "DMZ_Facility";
            ddlDMZ.DataBind();
        }


        // Created By PVMS
        // Handle Click event for Submit button
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ActMonitorModel model = new ActMonitorModel();
            ActMonitor act = CreateActMonitor();

            int id = Convert.ToInt32(Request.QueryString["id"]);
            string strMsg = "";
            if (model.UpdateActMonitor(id, act, ref strMsg) == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Car details are updated sucessfully');window.location.href ='Default.aspx'", true); //window.location ='frmDisplayUsers.aspx';
                //Response.Redirect("~/Default.aspx");
            }
            else
                lblResult.Text = strMsg;
        }

        // Created By PVMS
        // Set values for ActMonitor
        private ActMonitor CreateActMonitor()
        {
            ActMonitor a = new ActMonitor();
            a.Scheduled_Today_ = System.DateTime.Now.ToString(); 
            a.Date_and_Time_of_CAR_Submission = System.DateTime.Now;
            a.Unique_CAR_ID = Guid.NewGuid().ToString(); 
            a.Network_Grid_BA = Convert.ToInt32(ddlNetworkGrid.SelectedValue);
            a.Business_Zone__Grid = Convert.ToInt32(ddlBusinessZone.SelectedValue);
            a.DMZ__Facility = Convert.ToInt32(ddlDMZ.SelectedValue);
            a.Location = txtLocation.Text;
            a.Affected_Barangay_s_ = txtBrgy.Text;
            a.Affected_Municipality = txtMunicipality.Text;
            a.List_of_Affected_MRUs = txtMRU.Text;
            a.List_of_Affected_DMAs = txtDMA.Text;
            if (txtHousehold.Text.ToString().Trim() == "")
            {
                a.Number_of_Affected_Households = 0;
            }
            else
            {
                a.Number_of_Affected_Households = Convert.ToInt32(txtHousehold.Text);
            }
            a.Classification = Convert.ToInt32(ddlClassification.SelectedValue);
            a.Incident = Convert.ToInt32(ddlEvent.SelectedValue);
            a.Type_of_Activity = Convert.ToInt32(ddlAct.SelectedValue);
            a.Equipment__Appurtenance = Convert.ToInt32(ddlEquip.SelectedValue);
            a.Type_of_Equipment_Appurtenance = Convert.ToInt32(ddlType.SelectedValue);
            a.Size = Convert.ToInt32(ddlSize.SelectedValue);
            a.Affected_Area = Convert.ToString(ddlArea.SelectedValue);
            a.Contractor = Convert.ToInt32(ddlContractor.SelectedValue);
            a.Means_of_Notification = ddlMeans.SelectedIndex;
            a.Need_Media_Advisory = 1;
            a.OIM = "OIM";
            a.SIM = "SIM";
            a.CIM = "CIM";
            a.Remarks__Comments = txtRemarks.Text;
            a.Prework_Completion = Convert.ToDateTime("1999-12-10");
            a.Interruption_of_Service = Convert.ToDateTime("2018-05-02");
            a.Physical_Completion = Convert.ToDateTime("2018-05-02");
            a.Return_of_Service = Convert.ToDateTime("2018-05-02");
            a.Duration = 1;
            a.Sender_Receiver__Date_Time = "sample";
            a.Classification1 = "sample";
            a.Status = "In Progress";
            //a.Actual_Date_and_Time_of_Start = Convert.ToDateTime("2018-05-02");
            //a.Actual_Date_and_Time_of_Completion = Convert.ToDateTime("2018-05-02");
            a.Actual_Date_and_Time_of_Service_Interruption = "Sample";
            a.Actual_Date_and_Time_of_Service_Return = Convert.ToDateTime("2018-05-02");
            a.Actual_Duration_of_Activity__in_hours_ = 100;
            a.Variance_in_Duration__Agreed_vs_Actual_ = 100;
            a.Reported_by_and_time_of_sign_on__ = "sample";
            a.Closed_out_by_and_time_of_sign_off = "sample";
            a.Initial_Alert_Level_ = "sample";
            a.Incident_Escalation___Yes_or_No_ = "yes";
            a.With_or_without_service_interruption___Yes_or_No_ = "yes";
            a.Duty__last_update_ = "sample";
            a.Findings = "sample";
            return a;
        }

        protected void ddlAct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Event_Selecting1(object sender, EventArgs e)
        {

        }
    }
}