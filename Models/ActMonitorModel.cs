using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class ActMonitorModel
    {
        public bool InsertActMonitor(ActMonitor actmonitor, ref string errMsg)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db.ActMonitors.Add(actmonitor);
                db.SaveChanges();
                var maxID = db.Details_Milestones.OrderByDescending(x => x.ID).FirstOrDefault().ID;
                Details_Milestones milestone1 = new Details_Milestones() { CarNo = actmonitor.CAR_Number, MilestoneNumber = 1, ID = maxID + 1 };
                Details_Milestones milestone2 = new Details_Milestones() { CarNo = actmonitor.CAR_Number, MilestoneNumber = 2, ID = maxID + 2 };
                Details_Milestones milestone3 = new Details_Milestones() { CarNo = actmonitor.CAR_Number, MilestoneNumber = 3, ID = maxID + 3 };
                Details_Milestones milestone4 = new Details_Milestones() { CarNo = actmonitor.CAR_Number, MilestoneNumber = 4, ID = maxID + 4 };
                db.Details_Milestones.Add(milestone1);
                db.Details_Milestones.Add(milestone2);
                db.Details_Milestones.Add(milestone3);
                db.Details_Milestones.Add(milestone4);

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                errMsg = "Error" + e;
                return false;
            }
        }

        public bool UpdateActMonitor(int id, ActMonitor actmonitor, ref string errMsg) //Tama bang ActMonitor yung primary key ng ActMonitor Table?
        {
            try
            {
                IncidentEntities db = new IncidentEntities();

                //Fetching

                ActMonitor a = db.ActMonitors.Find(id);

                //Lagay dito lahat ng parameter na need ichange :((


                a.Scheduled_Today_ = actmonitor.Scheduled_Today_;
                //a.Date_and_Time_of_CAR_Submission = actmonitor.Date_and_Time_of_CAR_Submission;
                a.Unique_CAR_ID = actmonitor.Unique_CAR_ID;
                a.Network_Grid_BA = actmonitor.Network_Grid_BA;
                a.Business_Zone__Grid = actmonitor.Business_Zone__Grid;
                a.DMZ__Facility = actmonitor.Business_Zone__Grid;
                a.Location = actmonitor.Location;
                a.Affected_Barangay_s_ = actmonitor.Affected_Barangay_s_;
                a.Affected_Municipality = actmonitor.Affected_Municipality;
                a.List_of_Affected_MRUs = actmonitor.List_of_Affected_MRUs;
                a.List_of_Affected_DMAs = actmonitor.List_of_Affected_DMAs;
                a.Number_of_Affected_Households = actmonitor.Number_of_Affected_Households;
                a.Need_Media_Advisory = actmonitor.Need_Media_Advisory;
                a.OIM = actmonitor.OIM;
                a.SIM = actmonitor.SIM;
                a.CIM = actmonitor.CIM;
                a.Remarks__Comments = actmonitor.Remarks__Comments;
                a.Prework_Completion = actmonitor.Prework_Completion;
                a.Interruption_of_Service = actmonitor.Interruption_of_Service;
                a.Physical_Completion = actmonitor.Physical_Completion;
                a.Return_of_Service = actmonitor.Return_of_Service;
                a.Duration = actmonitor.Duration;
                a.Sender_Receiver__Date_Time = actmonitor.Sender_Receiver__Date_Time;

                a.Status = actmonitor.Status;
                //a.Actual_Date_and_Time_of_Start = actmonitor.Actual_Date_and_Time_of_Start;
                //a.Actual_Date_and_Time_of_Completion = actmonitor.Actual_Date_and_Time_of_Completion;
                a.Actual_Date_and_Time_of_Service_Interruption = actmonitor.Actual_Date_and_Time_of_Service_Interruption;
                a.Actual_Date_and_Time_of_Service_Return = actmonitor.Actual_Date_and_Time_of_Service_Return;
                a.Actual_Duration_of_Activity__in_hours_ = actmonitor.Actual_Duration_of_Activity__in_hours_;
                a.Variance_in_Duration__Agreed_vs_Actual_ = actmonitor.Variance_in_Duration__Agreed_vs_Actual_;
                a.Reported_by_and_time_of_sign_on__ = actmonitor.Reported_by_and_time_of_sign_on__;
                a.Closed_out_by_and_time_of_sign_off = actmonitor.Closed_out_by_and_time_of_sign_off;
                a.Initial_Alert_Level_ = actmonitor.Initial_Alert_Level_;
                a.Incident_Escalation___Yes_or_No_ = actmonitor.With_or_without_service_interruption___Yes_or_No_;
                a.With_or_without_service_interruption___Yes_or_No_ = actmonitor.With_or_without_service_interruption___Yes_or_No_;
                a.Duty__last_update_ = actmonitor.Duty__last_update_;
                a.Findings = actmonitor.Findings;

                a.Classification = actmonitor.Classification;
                a.Incident = actmonitor.Incident;
                a.Type_of_Activity = actmonitor.Type_of_Activity;
                a.Equipment__Appurtenance = actmonitor.Equipment__Appurtenance;
                a.Type_of_Equipment_Appurtenance = actmonitor.Type_of_Equipment_Appurtenance;
                a.Size = actmonitor.Size;
                a.Affected_Area = actmonitor.Affected_Area;  //Di pa gagana kasi wala data source
                a.Contractor = actmonitor.Contractor;
                //a.Means_of_Notification = actmonitor.Means_of_Notification;  //Di pa gagana kasi wala table 

                db.SaveChanges();
                return true; //"Update successfully!";

            }
            catch (Exception e)
            {
                errMsg = "Error" + e;
                return false;
            }
        }


        public void UpdateActualStartDateTime(int id, string _UserName, ActMonitor objActMonitor) //Tama bang ActMonitor yung primary key ng ActMonitor Table?
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                ActMonitor _ActMonitor = db.ActMonitors.Find(id);
                _ActMonitor.Actual_Date_and_Time_of_Start = objActMonitor.Actual_Date_and_Time_of_Start;
                db.SaveChanges();

                //CarUpdates _CarUpdates = new CarUpdates();
                //_CarUpdates.CarNumber = id;
                //_CarUpdates.CreatedBy = _UserName;
                //_CarUpdates.Details = "As of " + objActMonitor.Actual_Date_and_Time_of_Start.ToString() + " Car Incident has been started";
                //_CarUpdates.DateCreated = objActMonitor.Actual_Date_and_Time_of_Start;
                //db.CarUpdates.Add(_CarUpdates);
                //db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public void CancelActMonitor(int id, string _UserName, ActMonitor objActMonitor)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                ActMonitor _ActMonitor = db.ActMonitors.Find(id);
                _ActMonitor.Status = objActMonitor.Status;
                _ActMonitor.Actual_Date_and_Time_of_Service_Interruption = objActMonitor.Actual_Date_and_Time_of_Service_Interruption;
                db.SaveChanges();

                CarUpdates _CarUpdates = new CarUpdates();
                _CarUpdates.CarNumber = id;
                _CarUpdates.CreatedBy = _UserName;
                _CarUpdates.Details = "As of " + objActMonitor.Actual_Date_and_Time_of_Service_Interruption.ToString() + " Car Incident has been Cancelled";
                _CarUpdates.DateCreated = DateTime.Parse(objActMonitor.Actual_Date_and_Time_of_Service_Interruption);
                db.CarUpdates.Add(_CarUpdates);
                db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public void UpdateActualCompletionDateTime(int id, string _UserName,ActMonitor objActMonitor)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                ActMonitor _ActMonitor = db.ActMonitors.Find(id);
                _ActMonitor.Actual_Date_and_Time_of_Completion = objActMonitor.Actual_Date_and_Time_of_Completion;
                _ActMonitor.Status = objActMonitor.Status;
                db.SaveChanges();

                CarUpdates _CarUpdates = new CarUpdates();
                _CarUpdates.CarNumber = id;
                _CarUpdates.CreatedBy = _UserName;
                _CarUpdates.Details = "As of " + objActMonitor.Actual_Date_and_Time_of_Completion.ToString() + " Car Incident has been completed";
                _CarUpdates.DateCreated = objActMonitor.Actual_Date_and_Time_of_Completion;
                db.CarUpdates.Add(_CarUpdates);
                db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public string DeleteActMonitor(int ActMonitor)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                ActMonitor actmonitor = db.ActMonitors.Find(ActMonitor);
                db.ActMonitors.Attach(actmonitor);
                db.ActMonitors.Remove(actmonitor);
                db.SaveChanges();
                return actmonitor.Incident + "was successfully removed";

            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public bool DeleteIncident(int carID)
        {
            bool success = false;
            IncidentEntities db = new IncidentEntities();
            ActMonitor objActMonitor = db.ActMonitors.Where(x => x.CAR_Number == carID).FirstOrDefault();
            List<Details_WhatIFs> objWhatIfs = db.Details_WhatIFs.Where(x => x.CARID == carID).ToList();
            List<Details_Materials> objMaterials = db.Details_Materials.Where(x => x.CARID == carID).ToList();
            List<Details_Health_Safety> objHealthSafety = db.Details_Health_Safety.Where(x => x.CARID == carID).ToList();
            List<Details_ToolsEquipment> objTools = db.Details_ToolsEquipment.Where(x => x.CARID == carID).ToList();
            List<Details_ManPower> objManPower = db.Details_ManPower.Where(x => x.CARID == carID).ToList();
            List<Details_Methodology> objMethodology = db.Details_Methodology.Where(x => x.CARID == carID).ToList();
            List<Details_ValveManipulationTable> objdtlValueManipulation = db.Details_ValveManipulationTable.Where(x => x.CARID == carID).ToList();
            db.Details_WhatIFs.RemoveRange(objWhatIfs);
            db.Details_Materials.RemoveRange(objMaterials);
            db.Details_Health_Safety.RemoveRange(objHealthSafety);
            db.Details_ToolsEquipment.RemoveRange(objTools);
            db.Details_ManPower.RemoveRange(objManPower);
            db.Details_Methodology.RemoveRange(objMethodology);
            db.Details_ValveManipulationTable.RemoveRange(objdtlValueManipulation);
            db.ActMonitors.Remove(objActMonitor);
            db.SaveChanges();
            return success;
        }

        public ActMonitor RetrieveData(int id)
        {
            try
            {
                using (IncidentEntities db = new IncidentEntities())
                {
                    ActMonitor actmonitor = db.ActMonitors.Find(id);
                    return actmonitor;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ActMonitor> GetAllData()
        {
            try
            {
                using (IncidentEntities db = new IncidentEntities())
                {
                    List<ActMonitor> actmonitor = (from x in db.ActMonitors
                                                   select x).ToList();
                    return actmonitor;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}