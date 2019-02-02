using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IncidentManagement.Models;
using System.Data;

namespace IncidentManagement
{
    public partial class EditCarDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["MileStoneStatus"] = "In Progress";
                ViewState["IncidentStatus"] = Request.QueryString["IncidentStatus"].ToString();
                txtCarID.Text = Request.QueryString["ID"];
                sdsMilestoneSource.SelectParameters.Add("CarNo", Request.QueryString["ID"]);
                sdsValveManipulation.SelectParameters.Add("CarID", Request.QueryString["ID"]);
                sdsMethodology.SelectParameters.Add("CarID", Request.QueryString["ID"]);
                sdsUpdates.SelectParameters.Add("CarID", Request.QueryString["ID"]);
                grdMilestones.DataBind();
                GetWhatIfs();
                GetMaterialsToolsEquipments();
                GetManPowerHealthSafety();
                CancelMileStone();
                ShowHideEditMilestone();
                if (ViewState["IncidentStatus"].ToString() == "Delayed" || ViewState["IncidentStatus"].ToString() == "Completed on time")
                    disableScreen();
            }
        }

        /* Written by PS2019*/
        /* Refresh Milestone grid when proposed date is set from popup screen */
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            grdMilestones.DataBind();
            ShowHideEditMilestone();
        }


        /* Written by PS2019*/
        /* Disable screen for cancel and complete */
        private void disableScreen()
        {
            btnNewValve.Disabled = true;
            btnNewMehotdology.Disabled = true;
            txtWhatIfs.Enabled = false;
            btnSaveWhatIf.Enabled = false;
            txtMaterial.Enabled = false;
            txtToolsEquipment.Enabled = false;
            btnSaveMatToolsEquip.Enabled = false;
            txtManPower.Enabled = false;
            txtHealthySafety.Enabled = false;
            btnSaveManPowerHealthSafety.Enabled = false;
            grdValve.Columns[0].Visible = false;
            btnNewUpdate.Disabled = true;
        }

        private void ShowHideEditMilestone()
        {
            ////if (Helpers.isOccEngineer(Context.User))
           if (Convert.ToBoolean(Session["InputProposedDateAndTime"]))
                {
                for (int i = 0; i < grdMilestones.Rows.Count; i++)
                {
                    string proposedDate = grdMilestones.Rows[i].Cells[1].Text;
                    LinkButton editButton = (LinkButton)grdMilestones.Rows[i].Cells[8].Controls[0];
                    if ((!String.IsNullOrEmpty(proposedDate)) && (!proposedDate.Contains("&nbsp")))
                        editButton.Visible = false;
                }
            }

        }

        protected void AddRowBtn_Click(object sender, EventArgs e)
        {
            TableRow tRows = new TableRow();

        }

        protected void AddRowMethodBtn_Click(object sender, EventArgs e)
        {

            TextBox tbox = new TextBox();
            TableRow tRows = new TableRow();
            //Methodology.Rows.Add(tRows);
        }

        #region "MileStones"

        //Created by PS2019
        //Handle PreRender event
        protected void grdMilestones_OnPreRender(object sender, EventArgs e)
        {
            //if (!Helpers.isOccEngineer(Context.User))
         if (!Convert.ToBoolean(Session["InputProposedDateAndTime"]))
            {
                grdMilestones.Columns[8].Visible = false;
            }
        }

        //Created by PS2019
        //Handle RowDataBound event for MileStone grid for assigining initial values
        protected void grdMilestones_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex != -1)
            {
                string proposedDate = e.Row.Cells[1].Text.ToString();
                string StartDate = e.Row.Cells[2].Text.ToString();
                string EndDate = e.Row.Cells[3].Text.ToString();
                Button buttonControl = (Button)e.Row.Cells[6].Controls[0];
                Button buttonCancel = (Button)e.Row.Cells[7].Controls[0];
                if (!String.IsNullOrEmpty(proposedDate) && !proposedDate.Contains("&nbsp"))
                {
                    (buttonControl).Text = "Start";
                    (buttonControl).Enabled = true;
                    e.Row.Cells[5].Text = "";
                }
                else
                {
                    buttonControl.Visible = false;
                }

                if ((StartDate != "&nbsp;") && (e.Row.RowIndex != 3))
                {
                    (buttonControl).Text = "Cancel";
                    (buttonControl).Enabled = true;
                    (buttonCancel).Visible = false;
                }
                else if ((StartDate != "&nbsp;") && (e.Row.RowIndex == 3))
                {
                    (buttonControl).Text = "Complete";
                    (buttonControl).Enabled = true;
                    //Purpose of this view state to perform complete operation on last milestone
                    ViewState["MileStoneStatus"] = "Complete";
                }

                if ((StartDate != "&nbsp;") && (EndDate == "&nbsp;") && (e.Row.RowIndex == 3))
                    (buttonCancel).Visible = true;
                else
                    (buttonCancel).Visible = false;

                if ((StartDate != "&nbsp;") && (e.Row.Cells[3].Text.ToString() != "&nbsp;") && (StartDate != "") && (e.Row.Cells[3].Text.ToString() != ""))
                {
                    if ((DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Days > 0)
                        e.Row.Cells[4].Text = (DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Days.ToString() + "  days";
                    else if ((DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Hours > 0)
                        e.Row.Cells[4].Text = (DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Hours.ToString() + "  hours";
                    else if ((DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Minutes > 0)
                        e.Row.Cells[4].Text = (DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Minutes.ToString() + "  minutes";
                    else
                        e.Row.Cells[4].Text = Convert.ToString((DateTime.Parse(e.Row.Cells[3].Text) - DateTime.Parse(e.Row.Cells[2].Text)).Seconds) + "  seconds"; ;


                    (buttonControl).Enabled = false;
                    TimeSpan timespan = DateTime.Parse(e.Row.Cells[1].Text) - DateTime.Parse(e.Row.Cells[2].Text);
                    if (timespan.TotalDays > 0)
                    {
                        e.Row.Cells[5].Text = "Completed on time";
                        (buttonControl).Text = "Completed on time";
                    }
                    else
                    {
                        e.Row.Cells[5].Text = "Delayed";
                        (buttonControl).Text = "Delayed";
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && grdMilestones.EditIndex != e.Row.RowIndex)
            {
                GridView myGrid = (GridView)sender; // the gridview
                string intCarDtlID = myGrid.DataKeys[e.Row.RowIndex].Value.ToString();
                string strUrl = "AddMilestonePropDate.aspx?DtlID=" + intCarDtlID;
                (e.Row.Cells[8].Controls[0] as LinkButton).Attributes["onclick"] = "javascript:return OpenMilestonePDate('" + strUrl + "'); ";
            }
            CancelMileStone();
        }

        //Created by PS2019
        //Handle RowCommand event for MileStone grid for handling Start/Complete operation
        protected void grdMilestones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdMilestones.Rows[index];
            CarDetails objCarDetails = new CarDetails();
            Details_Milestones objdtlMilestone = new Details_Milestones();
            Button buttonCancel = (Button)row.Cells[7].Controls[0];
            Button buttonControl = (Button)row.Cells[6].Controls[0];
            if (e.CommandName == "Start")
            {
                switch (((Button)row.Cells[6].Controls[0]).Text)
                {
                    case "Cancel":
                        CancelMileStone(row.Cells[2].Text.ToString());
                        break;
                    default:
                        if (ViewState["MileStoneStatus"].ToString() != "Complete")
                        {
                            row.Cells[5].Text = "In progress";
                            row.Cells[2].Text = System.DateTime.Now.ToString();
                            row.Cells[4].Text = SetDuration(DateTime.Now, DateTime.Parse(row.Cells[2].Text));
                            ((Button)row.Cells[6].Controls[0]).Text = "Cancel";
                            UpdateMileStone(Convert.ToInt32(row.Cells[0].Text), DateTime.Parse(row.Cells[2].Text), DateTime.Parse("1/1/0001"));
                        }

                        if (index == 0)
                        {
                            UpdateActualStartDateTime(DateTime.Parse(row.Cells[2].Text));
                        }
                        else if (index == 1)
                        {
                            ((Button)grdMilestones.Rows[0].Cells[6].Controls[0]).Text = "Completed on time";
                            ((Button)grdMilestones.Rows[0].Cells[6].Controls[0]).Enabled = false;
                            grdMilestones.Rows[0].Cells[3].Text = System.DateTime.Now.ToString();
                            grdMilestones.Rows[0].Cells[4].Text = Convert.ToString((DateTime.Parse(grdMilestones.Rows[0].Cells[3].Text) - DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text)).Seconds);
                            SetStatus(DateTime.Parse(grdMilestones.Rows[0].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text), 0);
                            UpdateMileStone(Convert.ToInt32(grdMilestones.Rows[0].Cells[0].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[3].Text));
                            grdMilestones.Rows[0].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[0].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text));
                        }
                        else if (index == 2)
                        {
                            ((Button)grdMilestones.Rows[0].Cells[6].Controls[0]).Text = "Completed on time";
                            ((Button)grdMilestones.Rows[0].Cells[6].Controls[0]).Enabled = false;
                            ((Button)grdMilestones.Rows[1].Cells[6].Controls[0]).Text = "Completed on time";
                            ((Button)grdMilestones.Rows[1].Cells[6].Controls[0]).Enabled = false;
                            grdMilestones.Rows[1].Cells[3].Text = System.DateTime.Now.ToString();
                            grdMilestones.Rows[1].Cells[4].Text = Convert.ToString((DateTime.Parse(grdMilestones.Rows[1].Cells[3].Text) - DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text)).Seconds);

                            SetStatus(DateTime.Parse(grdMilestones.Rows[0].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text), 0);
                            SetStatus(DateTime.Parse(grdMilestones.Rows[1].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text), 1);
                            UpdateMileStone(Convert.ToInt32(grdMilestones.Rows[1].Cells[0].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[3].Text));

                            grdMilestones.Rows[0].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[0].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text));
                            grdMilestones.Rows[1].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[1].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text));
                        }
                        else if (index == 3)
                        {

                            ((Button)grdMilestones.Rows[0].Cells[6].Controls[0]).Enabled = false;
                            ((Button)grdMilestones.Rows[1].Cells[6].Controls[0]).Enabled = false;
                            ((Button)grdMilestones.Rows[2].Cells[6].Controls[0]).Enabled = false;
                            ((Button)grdMilestones.Rows[3].Cells[6].Controls[0]).Text = "Complete";
                            
                            SetStatus(DateTime.Parse(grdMilestones.Rows[0].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text), 0);
                            SetStatus(DateTime.Parse(grdMilestones.Rows[1].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text), 1);
                            SetStatus(DateTime.Parse(grdMilestones.Rows[2].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[2].Cells[2].Text), 2);

                            if (ViewState["MileStoneStatus"].ToString() == "Complete")
                            {
                                row.Cells[3].Text = System.DateTime.Now.ToString();
                                row.Cells[4].Text = SetDuration(DateTime.Now, DateTime.Parse(row.Cells[2].Text));
                                SetStatus(DateTime.Parse(grdMilestones.Rows[3].Cells[1].Text), DateTime.Parse(grdMilestones.Rows[3].Cells[2].Text), 3);
                                ((Button)grdMilestones.Rows[3].Cells[6].Controls[0]).Enabled = false;
                                buttonCancel.Visible = false;
                                ActMonitorModel model = new ActMonitorModel();
                                ActMonitor objActMonitor = new ActMonitor();
                                int id = Convert.ToInt32(txtCarID.Text);
                                objActMonitor.CAR_Number = Convert.ToInt32(txtCarID.Text);
                                objActMonitor.Actual_Date_and_Time_of_Completion = DateTime.Parse(System.DateTime.Now.ToString());
                                if ((grdMilestones.Rows[0].Cells[5].Text == "Delayed") || (grdMilestones.Rows[1].Cells[5].Text == "Delayed") ||
                                    (grdMilestones.Rows[2].Cells[5].Text == "Delayed") || (grdMilestones.Rows[3].Cells[5].Text == "Delayed"))
                                      objActMonitor.Status = "Delayed";
                                else
                                    objActMonitor.Status = "Completed on time";
                                UpdateMileStone(Convert.ToInt32(row.Cells[0].Text), DateTime.Parse(row.Cells[2].Text), DateTime.Parse(System.DateTime.Now.ToString()));
                                model.UpdateActualCompletionDateTime(id, Session["UserName"].ToString(), objActMonitor);
                                grvUpdates.DataBind();
                                disableScreen();
                            }
                            else
                            {
                                buttonCancel.Visible = true;
                                grdMilestones.Rows[2].Cells[3].Text = System.DateTime.Now.ToString();
                                grdMilestones.Rows[2].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[2].Cells[3].Text), DateTime.Parse(row.Cells[2].Text));
                                grdMilestones.Rows[0].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[0].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[0].Cells[2].Text));
                                grdMilestones.Rows[1].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[1].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[1].Cells[2].Text));
                                grdMilestones.Rows[2].Cells[4].Text = SetDuration(DateTime.Parse(grdMilestones.Rows[2].Cells[3].Text), DateTime.Parse(grdMilestones.Rows[2].Cells[2].Text));
                                UpdateMileStone(Convert.ToInt32(grdMilestones.Rows[2].Cells[0].Text), DateTime.Parse(grdMilestones.Rows[2].Cells[2].Text), DateTime.Parse(grdMilestones.Rows[2].Cells[3].Text));
                                ViewState["MileStoneStatus"] = "Complete";
                            }
                        }
                        break;
                }
            }
            else if (e.CommandName == "Cancel")
            {
                  CancelMileStone(row.Cells[2].Text.ToString());
            }
            hidTAB.Value = "#tab0default";
        }

        /* Written by PS2019*/
        /* Cancel Milestone */
        private void CancelMileStone()
        {
            if (ViewState["IncidentStatus"].ToString() == "Cancelled")
            {
                for (int i = 0; i < grdMilestones.Rows.Count; i++)
                {
                    ((Button)grdMilestones.Rows[i].Cells[6].Controls[0]).Enabled = false;
                    ((Button)grdMilestones.Rows[i].Cells[6].Controls[0]).Text = "Cancelled";
                    grdMilestones.Rows[i].Cells[5].Text = "Cancelled";
                    ((Button)grdMilestones.Rows[i].Cells[7].Controls[0]).Visible = false;
                    ((LinkButton)grdMilestones.Rows[i].Cells[8].Controls[0]).Visible = false;
                }
                disableScreen();
            }
        }


        /* Written by PS2019*/
        /* Cancel Milestone with Database operation */
        private void CancelMileStone(string _ActualDTServIntrp)
        {
            ActMonitorModel oActMonitorModel = new ActMonitorModel();
            ActMonitor oActMonitor = new ActMonitor();
            oActMonitor.CAR_Number = Convert.ToInt32(txtCarID.Text);
            oActMonitor.Actual_Date_and_Time_of_Service_Interruption = _ActualDTServIntrp;
            oActMonitor.Status = "Cancelled";
            oActMonitorModel.CancelActMonitor(Convert.ToInt32(txtCarID.Text), Session["UserName"].ToString(), oActMonitor);
            ViewState["IncidentStatus"] = "Cancelled";
            CancelMileStone();
            grvUpdates.DataBind();
        }

        //Created by PS2019
        //Private Method to update milestone
        private void UpdateMileStone(int intMilestone, DateTime dtActual, DateTime dtEndDate)
        {
            CarDetails objCarDetails = new CarDetails();
            Details_Milestones objdtlMilestone = new Details_Milestones();
            objdtlMilestone.CarNo = Convert.ToInt32(Request.QueryString["ID"].ToString());
            objdtlMilestone.MilestoneNumber = intMilestone;
            objdtlMilestone.Actual = dtActual;
            if (dtEndDate != DateTime.Parse("1/1/0001"))
            {
                objdtlMilestone.EndTime = dtEndDate;
                objCarDetails.UpdateMilestone(objdtlMilestone, Session["UserName"].ToString(), "Complete");
            }
            else
            {
                objCarDetails.UpdateMilestone(objdtlMilestone, Session["UserName"].ToString(), "Start");
            }
            
            grvUpdates.DataBind();
        }

        //Created by PS2019
        //Private Method to update Actual Start Date
        private void UpdateActualStartDateTime(DateTime dtActual)
        {
            ActMonitorModel model = new ActMonitorModel();
            ActMonitor objActMonitor = new ActMonitor();
            objActMonitor.CAR_Number = Convert.ToInt32(txtCarID.Text);
            objActMonitor.Actual_Date_and_Time_of_Start = dtActual;
            int id = Convert.ToInt32(txtCarID.Text);
            model.UpdateActualStartDateTime(id, Session["UserName"].ToString(), objActMonitor);
        }

        //Created by PS2019
        //Private Method to set duration
        private void SetStatus(DateTime proposedDate, DateTime ActualDate, int RowNumber)
        {
            try
            {
                TimeSpan timespan = proposedDate - ActualDate;
                if (timespan.TotalDays > 0)
                {
                    ((Button)grdMilestones.Rows[RowNumber].Cells[6].Controls[0]).Text = "Completed on time";
                    grdMilestones.Rows[RowNumber].Cells[5].Text = "Completed on time";
                }
                else
                {
                    ((Button)grdMilestones.Rows[RowNumber].Cells[6].Controls[0]).Text = "Delayed";
                    grdMilestones.Rows[RowNumber].Cells[5].Text = "Delayed";
                }
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        //Created by PS2019
        //Private Method to set duration
        private string SetDuration(DateTime ActualDate, DateTime proposedDate)
        {
            try
            {
                if ((ActualDate - proposedDate).Days > 0)
                    return (ActualDate - proposedDate).Days.ToString() + "  days";
                else if ((ActualDate - proposedDate).Hours > 0)
                    return (ActualDate - proposedDate).Hours.ToString() + "  hours";
                else if ((ActualDate - proposedDate).Minutes > 0)
                    return (ActualDate - proposedDate).Minutes.ToString() + "  minutes";
                else
                    return (ActualDate - proposedDate).Seconds.ToString() + "  seconds";
            }
            catch (Exception err)
            {
                Console.Write(err);
                return "";
                
            }
        }
        #endregion

        /* Written by PS2019 */
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grdValve.EditIndex != e.Row.RowIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
                //hidTAB.Value = "#tab2default";
            }
        }

        protected void grdValve_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grdValve.Rows[e.NewEditIndex];
            int rowID = Convert.ToInt32(row.Cells[1].Text);
            //Response.Redirect("~/AddValveManipulation.aspx?id=" + rowID);
            hidTAB.Value = "#tab2default";
        }

        protected void btnSaveWhatIf_Click(object sender, EventArgs e)
        {
            SaveWhatIfs();
            hidTAB.Value = "#tab4default";
        }

        protected void btnSaveMatToolsEquip_Click(object sender, EventArgs e)
        {
            SaveMaterialsToolsEquipments();
            hidTAB.Value = "#tab5default";
        }

        protected void btnSaveManPowerHealthSafety_Click(object sender, EventArgs e)
        {
            SaveManpowerHealthSafety();
            hidTAB.Value = "#tab6default";
        }

        /* Written by PS2019 */
        /* Save What Ifs */
        private void SaveWhatIfs()
        {
            try
            {
                CarDetails objCarDetailsWhatIf = new CarDetails();
                Details_WhatIFs objDetailsWhatIFs = new Details_WhatIFs();
                objDetailsWhatIFs.CARID = Convert.ToInt16(Request.QueryString["ID"]);
                objDetailsWhatIFs.WhatIFs = txtWhatIfs.Text;
                if (ViewState["WhatIfID"] != null)
                {
                    objDetailsWhatIFs.ID = Convert.ToInt16(ViewState["WhatIfID"]);
                }
                objCarDetailsWhatIf.UpdateWhatIf(objDetailsWhatIFs);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        /* Written by PS2019 */
        /* Save Materials and ToolsEquipments */
        private void SaveMaterialsToolsEquipments()
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                Details_Materials objMaterials = new Details_Materials();
                Details_ToolsEquipment objToolsEquipments = new Details_ToolsEquipment();
                objMaterials.CARID = Convert.ToInt16(Request.QueryString["ID"]);
                objMaterials.Materials = txtMaterial.Text;

                objToolsEquipments.CARID = Convert.ToInt16(Request.QueryString["ID"]);
                objToolsEquipments.Tools_Equipment = txtToolsEquipment.Text;

                if (ViewState["MaterialID"] != null)
                {
                    objMaterials.ID = Convert.ToInt16(ViewState["MaterialID"]);
                }

                if (ViewState["ToolsEquipmentsID"] != null)
                {
                    objToolsEquipments.ID = Convert.ToInt16(ViewState["ToolsEquipmentsID"]);
                }

                objCarDetails.UpdateMaterials(objMaterials);
                objCarDetails.UpdateToolsEquipments(objToolsEquipments);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        /* Written by PS2019*/
        /* Save PowerHealth and Safety */
        private void SaveManpowerHealthSafety()
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                Details_ManPower objManPower = new Details_ManPower();
                Details_Health_Safety objHealthSafety = new Details_Health_Safety();
                objManPower.CARID = Convert.ToInt16(Request.QueryString["ID"]);
                objManPower.Manpower = txtManPower.Text;

                objHealthSafety.CARID = Convert.ToInt16(Request.QueryString["ID"]);
                objHealthSafety.Health_Safety = txtHealthySafety.Text;

                if (ViewState["ManPowerID"] != null)
                {
                    objManPower.ID = Convert.ToInt16(ViewState["ManPowerID"]);
                }

                if (ViewState["HealthSafetyID"] != null)
                {
                    objHealthSafety.ID = Convert.ToInt16(ViewState["HealthSafetyID"]);
                }
                objCarDetails.UpdateManPower(objManPower);
                objCarDetails.UpdateHealthSafery(objHealthSafety);
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        /* Written by PS2019*/
        /* Get What Ifs */
        private void GetWhatIfs()
        {
            try
            {
                CarDetails objCarDetailsWhatIf = new CarDetails();
                Details_WhatIFs objDetailsWhatIFs = new Details_WhatIFs();
                objDetailsWhatIFs = objCarDetailsWhatIf.GetWhatIfDetails(Convert.ToInt16(Request.QueryString["ID"]));
                txtWhatIfs.Text = objDetailsWhatIFs.WhatIFs;
                ViewState["WhatIfID"] = objDetailsWhatIFs.ID;
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        /* Written by PS2019*/
        /* Get Materials tools Equipments */
        private void GetMaterialsToolsEquipments()
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                Details_Materials objMaterials = new Details_Materials();
                Details_ToolsEquipment objToolsEquipments = new Details_ToolsEquipment();
                objMaterials = objCarDetails.GetMaterials(Convert.ToInt16(Request.QueryString["ID"]));
                objToolsEquipments = objCarDetails.GetToolsEquipments(Convert.ToInt16(Request.QueryString["ID"]));
                txtMaterial.Text = objMaterials.Materials;
                txtToolsEquipment.Text = objToolsEquipments.Tools_Equipment;
                ViewState["MaterialID"] = objMaterials.ID;
                ViewState["ToolsEquipmentsID"] = objToolsEquipments.ID;
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

        /* Written by PS2019*/
        /* Get ManPower Health Safety */
        private void GetManPowerHealthSafety()
        {
            try
            {
                CarDetails objCarDetails = new CarDetails();
                Details_ManPower objManPower = new Details_ManPower();
                Details_Health_Safety objHealthSafety = new Details_Health_Safety();
                objManPower = objCarDetails.GetManPower(Convert.ToInt16(Request.QueryString["ID"]));
                objHealthSafety = objCarDetails.GetHealthSafety(Convert.ToInt16(Request.QueryString["ID"]));
                txtManPower.Text = objManPower.Manpower;
                txtHealthySafety.Text = objHealthSafety.Health_Safety;
                ViewState["ManPowerID"] = objManPower.ID;
                ViewState["HealthSafetyID"] = objHealthSafety.ID;
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
        }

    }
}