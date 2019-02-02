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
    public partial class Car : System.Web.UI.Page
    {
        string message;
        string userEmail;
        string userSMS;


        protected void Page_Load(object sender, EventArgs e)
        {
            Message();
            txtMessage.Text = message;
            Session["CARID"] = Request.QueryString["CARId"];
            if (IsPostBack != true)
                SetOimCIMSim();

        }

        private void SetOimCIMSim()
        {
            try
            {
                ddlOIM.DataSource = sdsOIM;
                ddlOIM.DataValueField = "IEM";
                ddlOIM.DataTextField = "UserName";
                ddlOIM.DataBind();
                string[] strOIM = ddlOIM.SelectedValue.ToString().Split('_');
                txtOimID.Text = strOIM[0];
                txtOIDemail.Text = strOIM[1];
                txtOIDnum.Text = strOIM[2];

                ddlCIM.DataSource = sdsCIM;
                ddlCIM.DataValueField = "IEM";
                ddlCIM.DataTextField = "UserName";
                ddlCIM.DataBind();
                string[] strCIM = ddlCIM.SelectedValue.ToString().Split('_');
                txtCimID.Text = strCIM[0];
                txtCIMemail.Text = strCIM[1];
                txtCIMnum.Text = strCIM[2];

                ddlSIM.DataSource = sdsSIM;
                ddlSIM.DataValueField = "IEM";
                ddlSIM.DataTextField = "UserName";
                ddlSIM.DataBind();
                string[] strSIM = ddlSIM.SelectedValue.ToString().Split('_');
                txtSimID.Text = strSIM[0];
                txtSIMemail.Text = strSIM[1];
                txtSIMnum.Text = strSIM[2];
            }
            catch (Exception err)
            {
                lblText.Text = err.Message;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ActMonitorModel model = new ActMonitorModel();
            ActMonitor act = CreateActMonitor();

            string strMsg = "";
            if (model.InsertActMonitor(act, ref strMsg) == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Car details are added sucessfully');window.location.href ='Default.aspx'", true); //window.location ='frmDisplayUsers.aspx';
                //Response.Redirect("~/Default.aspx");
            }
            else
                lblResult.Text = strMsg;

        }

        private ActMonitor CreateActMonitor()
        {
            ActMonitor a;

            if (Session["CARID"] == null)
            {
                a = new ActMonitor();
                a.Scheduled_Today_ = System.DateTime.Now.ToString(); //"9999-12-31"; // should be bool (yes / no)
                                                                     // a.Date_and_Time_of_CAR_Submission = Convert.ToDateTime("2018-05-02");
                a.Unique_CAR_ID = Guid.NewGuid().ToString(); //"sample"; // generate format ("first letters of incident" - "month" - "sequnce")
                a.Network_Grid_BA = Convert.ToInt32(ddlNetworkGrid.SelectedValue); // add in interface --done
                a.Business_Zone__Grid = Convert.ToInt32(ddlBusinessZone.SelectedValue); // add in interface --done
                a.DMZ__Facility = Convert.ToInt32(ddlDMZ.SelectedValue); // add in interface --done
                a.Location = txtLocation.Text;
                a.Affected_Barangay_s_ = txtBrgy.Text;
                a.Affected_Municipality = txtMunicipality.Text;
                a.List_of_Affected_MRUs = txtMRU.Text;
                a.List_of_Affected_DMAs = txtDMA.Text;
                if (txtHousehold.Text.Trim() == string.Empty)
                {
                    a.Number_of_Affected_Households = null;
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
                a.Affected_Area = ddlArea.SelectedValue;
                a.Contractor = Convert.ToInt32(ddlContractor.SelectedValue);
                a.Means_of_Notification = ddlMeans.SelectedIndex;
                a.Need_Media_Advisory = 1;
                a.OIM = txtOimID.Text;
                a.SIM = txtSimID.Text;
                a.CIM = txtCimID.Text;
                a.Remarks__Comments = txtRemarks.Text;
                a.Date_and_Time_of_CAR_Submission = DateTime.Now;
                a.Prework_Completion = null;// Convert.ToDateTime("1999-12-10"); //should be declared in details- milestone (add interface)
                a.Interruption_of_Service = null;// Convert.ToDateTime("2018-05-02"); //should be declared in details- milestone (add interface)
                a.Physical_Completion = null;// Convert.ToDateTime("2018-05-02"); //should be declared in details- milestone (add interface)
                a.Return_of_Service = null;// Convert.ToDateTime("2018-05-02"); //should be declared in details - milestones (add interface)
                a.Duration = null; //computatin            
                a.Sender_Receiver__Date_Time = null;// "sample";
                a.Classification1 = Convert.ToString(ddlClassification.SelectedItem);
                a.Status = "In Progress";// "sample"; // condition to default on "In-progess" --data avaiable in database -- checking throughtime of start and completion (declared vs actual)
                                         // a.Actual_Date_and_Time_of_Start = null;// Convert.ToDateTime("2018-05-02"); // through interface (new page) user will activate or through update
                                         //a.Actual_Date_and_Time_of_Completion = null;// Convert.ToDateTime("2018-05-02"); // through interface (new page) user will activate or through update
                a.Actual_Date_and_Time_of_Service_Interruption = null;// "Sample";// through interface (new page) user will activate or through update
                a.Actual_Date_and_Time_of_Service_Return = null;// Convert.ToDateTime("2018-05-02");// through interface (new page) user will activate or through update
                a.Actual_Duration_of_Activity__in_hours_ = null;// 100; // computation 
                a.Variance_in_Duration__Agreed_vs_Actual_ = null;// 100; // computaion
                a.Reported_by_and_time_of_sign_on__ = null;// "sample"; // fetch data of user login
                a.Closed_out_by_and_time_of_sign_off = null;// "sample"; // fetch data of user login - respinsible: OIM
                a.Initial_Alert_Level_ = null;// "sample"; // add code for conditions yellow and red alert based on affected area and incident
                a.Incident_Escalation___Yes_or_No_ = null;// "yes"; // check the ppt for conditon depends on incident
                a.With_or_without_service_interruption___Yes_or_No_ = null;// "yes"; // check the ppt for conditon depends on incident
                a.Duty__last_update_ = null;// "sample"; // fetch from update
                a.Findings = null;// "sample";

            }
            else
            {
                IncidentEntities dbEntities = new IncidentEntities();
                a = dbEntities.ActMonitors.Where(x => x.CAR_Number == Convert.ToInt32(Session["CARID"].ToString())).FirstOrDefault();



            }

            return a;


        }

        /* Added by S2019 */
        /* Selected Index change event for ddlOIM */
        protected void ddlOIM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strOIM = ddlOIM.SelectedValue.ToString().Split('_');
                txtOimID.Text = strOIM[0];
                txtOIDemail.Text = strOIM[1];
                txtOIDnum.Text = strOIM[2];
            }
            catch (Exception err)
            {
                lblText.Text = err.Message;
            }
        }

        /* Added by S2019 */
        /* Selected Index change event for ddlOIM */
        protected void ddlCIM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strCIM = ddlCIM.SelectedValue.ToString().Split('_');
                txtCimID.Text = strCIM[0];
                txtCIMemail.Text = strCIM[1];
                txtCIMnum.Text = strCIM[2];
            }
            catch (Exception err)
            {
                lblText.Text = err.Message;
            }
        }

        /* Added by S2019 */
        /* Selected Index change event for ddlOIM */
        protected void ddlSIM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strSIM = ddlSIM.SelectedValue.ToString().Split('_');
                txtSimID.Text = strSIM[0];
                txtSIMemail.Text = strSIM[1];
                txtSIMnum.Text = strSIM[2];
            }
            catch (Exception err)
            {
                lblText.Text = err.Message;
            }
        }

        protected void ddlAct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Event_Selecting1(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// email
        /// </summary>
        /// 
        public void Message()
        {

            message = "(" + "Yellow Alert DMZ" + "): " + ddlSize.SelectedItem + " " + ddlEvent.SelectedItem + " @ "
               + txtLocation.Text + "(" + ddlNetworkGrid.SelectedItem + " Grid DMZ " + ddlDMZ.SelectedItem +
               "). Date & Time Discovered / Reported - " + System.DateTime.Now.ToString() + " Root Cause - " + ddlEvent.SelectedItem
               + "." + " With customer impact(" + ddlArea.SelectedItem + " No.of AHH: " + txtHousehold.Text + " No Key Accounts / VIPs affected "
               + "). Status: " + "On - going" + " exposure by " + Context.User.Identity.Name + " " + "Estimated Date & Time of Completion -"
               + "Wednesday" + ".OIM: " + ddlOIM.SelectedItem + " / SIM: " + ddlSIM.SelectedItem + ".";


        }



        protected void emailBtnTry_Click(object sender, EventArgs e)
        {
            Message();
            EmailSend();
            emailClass em = new emailClass();
            em.NewHeadlessEmail("mnlwater48@gmail.com", "ZAQXSW789", userEmail, "Subject Text", message);


        }


        public void EmailSend()
        {
            UserInfoModel userInfo = new UserInfoModel();

            var user = Context.User.Identity;
            if (user.IsAuthenticated)
            {
                string userId = user.Name;
                userEmail = userInfo.GetAspNetUserDetails(userId).Email;
            }
        }


        public object itexmo(string Number, string Message, string API_CODE)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "https://www.itexmo.com/php_api/api.php";
                parameter.Add("1", Number);
                parameter.Add("2", Message);
                parameter.Add("3", API_CODE);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }




        protected void btnSmsSend_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (!String.IsNullOrEmpty(txtOIDnum.Text))
            {
                itexmo(txtOIDnum.Text, message, "TR-CHARM266096_2Z64Z");
                itexmo(txtCIMnum.Text, message, "TR-CHARM266096_2Z64Z");
                itexmo(txtSIMnum.Text, message, "TR-CHARM266096_2Z64Z");
                success = true;
            }
            if (success)
            {
                lblText.Text = "SMS was sent successfully";
            }
            //else
            //{
            //    lblText.Text = "Error num " + result + " was encountered";
            //}
        }

        public void SmsSend()
        {
            UserInfoModel userInfo = new UserInfoModel();

            var user = Context.User.Identity;
            if (user.IsAuthenticated)
            {
                string userId = user.Name;
                userSMS = userInfo.GetAspNetUserDetails(userId).PhoneNumber;
            }
        }

        protected void btnSmsSend_Click1(object sender, EventArgs e)
        {
            SmsSend();
            dynamic result = itexmo(userSMS, message, "TR-CHARM266096_2Z64Z");
            if (result == "0")
            {
                lblText.Text = "SMS Sent Successfully!";

            }
            else
            {
                lblText.Text = "Error num " + result + " was encountered";
            }
        }
    }
}