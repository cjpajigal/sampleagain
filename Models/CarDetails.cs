using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace IncidentManagement.Models
{
    public class CarDetails
    {
        public CarDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Details_WhatIFs GetWhatIfDetails(int carID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var whatIf = (from x in db.Details_WhatIFs
                              where x.CARID == carID
                              select x).FirstOrDefault();
                return whatIf;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Details_Materials GetMaterials(int carID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varMaterial = (from x in db.Details_Materials
                                   where x.CARID == carID
                                   select x).FirstOrDefault();
                return varMaterial;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Details_ToolsEquipment GetToolsEquipments(int carID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varToolsEquipments = (from x in db.Details_ToolsEquipment
                                          where x.CARID == carID
                                          select x).FirstOrDefault();
                return varToolsEquipments;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Details_ManPower GetManPower(int carID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varManPower = (from x in db.Details_ManPower
                                   where x.CARID == carID
                                   select x).FirstOrDefault();
                return varManPower;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Details_Health_Safety GetHealthSafety(int carID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varHealthSafety = (from x in db.Details_Health_Safety
                                       where x.CARID == carID
                                       select x).FirstOrDefault();
                return varHealthSafety;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Classification> GetClassification()
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varClsfcn = (from x in db.Classifications
                                 select x).ToList();
                return varClsfcn;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Incident_Event> GetIncidentEvent(int intClsfcnID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varIncidentEvent = (from x in db.Incident_Event
                                        where x.CatergoryID == intClsfcnID
                                        select x).ToList();
                return varIncidentEvent;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ActivityType> GetActivityType(int Incident)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varActivityType = (from x in db.ActivityTypes
                                       where x.IncidentID == Incident
                                       select x).ToList();
                return varActivityType;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<NetworkGrid_BA> GetNetworkGrid()
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varNetworkGrid = (from x in db.NetworkGrid_BA
                                      select x).ToList();
                return varNetworkGrid;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BusinessZone_Grid> GetBusinessZone(int intNetworkGridID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varBusiness = (from x in db.BusinessZone_Grid
                                   where x.NetworkGridID == intNetworkGridID
                                   select x).ToList();
                return varBusiness;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<DMZFacility> GetDMZ(int intBusinessID)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                var varDMZ = (from x in db.DMZFacilities
                              where x.BusinessZoneID == intBusinessID
                              select x).ToList();
                return varDMZ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateMilestone(Details_Milestones _Milestones, string _UserName, string _Status)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db = new IncidentEntities();
                var varMilestone = (from x in db.Details_Milestones
                                    where x.CarNo == _Milestones.CarNo && x.MilestoneNumber == _Milestones.MilestoneNumber
                                    select x).FirstOrDefault();
                varMilestone.Actual = _Milestones.Actual;
                varMilestone.EndTime = _Milestones.EndTime;
                db.SaveChanges();

                CarUpdates _CarUpdates = new CarUpdates();
                _CarUpdates.CarNumber = _Milestones.CarNo;
                _CarUpdates.CreatedBy = _UserName;
                if (_Status =="Start")
                    _CarUpdates.Details = "As of " + _Milestones.Actual.ToString() + " Milestone " +  _Milestones.MilestoneNumber + " has been started";
                else
                    _CarUpdates.Details = "As of " + _Milestones.EndTime.ToString() + " Milestone " + _Milestones.MilestoneNumber + " has been completed";
                _CarUpdates.DateCreated = _Milestones.Actual;
                db.CarUpdates.Add(_CarUpdates);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool SetProposedDate(Details_Milestones objMilestone)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db = new IncidentEntities();
                var varMilestone = (from x in db.Details_Milestones
                                    where x.CarID == objMilestone.CarID
                                    select x).FirstOrDefault();
                varMilestone.Propsed = objMilestone.Propsed;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean AddNewUpdates(CarUpdates _CarUpdates)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db.CarUpdates.Add(_CarUpdates);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public Boolean AddValveManipulation(Details_ValveManipulationTable objValve)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                if (objValve.ID <= 0)
                {
                    objValve.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == objValve.CARID).FirstOrDefault();
                    db.Details_ValveManipulationTable.Add(objValve);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public void UpdateWhatIf(Details_WhatIFs whatIf)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                db = new IncidentEntities();
                if (whatIf.ID <= 0)
                {
                    whatIf.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == whatIf.CARID).FirstOrDefault();
                    db.Details_WhatIFs.Add(whatIf);
                    db.SaveChanges();
                }
                else
                {
                    var whatIfModel = (from x in db.Details_WhatIFs
                                       where x.CARID == whatIf.CARID
                                       select x).FirstOrDefault();
                    whatIfModel.WhatIFs = whatIf.WhatIFs;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateMaterials(Details_Materials objdtlMaterials)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                if (objdtlMaterials.ID <= 0)
                {
                    objdtlMaterials.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == objdtlMaterials.CARID).FirstOrDefault();
                    db.Details_Materials.Add(objdtlMaterials);
                    db.SaveChanges();
                }
                else
                {
                    var varMaterial = (from x in db.Details_Materials
                                       where x.CARID == objdtlMaterials.CARID
                                       select x).FirstOrDefault();
                    varMaterial.Materials = objdtlMaterials.Materials;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateToolsEquipments(Details_ToolsEquipment objToolsEquipments)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                if (objToolsEquipments.ID <= 0)
                {
                    objToolsEquipments.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == objToolsEquipments.CARID).FirstOrDefault();
                    db.Details_ToolsEquipment.Add(objToolsEquipments);
                    db.SaveChanges();
                }
                else
                {
                    var varToolsEquipments = (from x in db.Details_ToolsEquipment
                                              where x.CARID == objToolsEquipments.CARID
                                              select x).FirstOrDefault();
                    varToolsEquipments.Tools_Equipment = objToolsEquipments.Tools_Equipment;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateManPower(Details_ManPower objManPower)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                if (objManPower.ID <= 0)
                {
                    objManPower.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == objManPower.CARID).FirstOrDefault();
                    db.Details_ManPower.Add(objManPower);
                    db.SaveChanges();
                }
                else
                {
                    var varManPower = (from x in db.Details_ManPower
                                       where x.CARID == objManPower.CARID
                                       select x).FirstOrDefault();
                    varManPower.Manpower = objManPower.Manpower;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateHealthSafery(Details_Health_Safety objHealthSafety)
        {
            try
            {
                IncidentEntities db = new IncidentEntities();
                if (objHealthSafety.ID <= 0)
                {
                    objHealthSafety.ActMonitor = db.ActMonitors.Where(x => x.CAR_Number == objHealthSafety.CARID).FirstOrDefault();
                    db.Details_Health_Safety.Add(objHealthSafety);
                    db.SaveChanges();
                }
                else
                {
                    var varHealthSafety = (from x in db.Details_Health_Safety
                                           where x.CARID == objHealthSafety.CARID
                                           select x).FirstOrDefault();
                    varHealthSafety.Health_Safety = objHealthSafety.Health_Safety;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}