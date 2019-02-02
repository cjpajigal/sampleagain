using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class ChartModel
    {

        public List<ChartData> getWeeklyIncidents(string timePeriod)
        {
            var procStatement = string.Empty;
            IncidentEntities db = new IncidentEntities();
            switch (timePeriod)
            {
                case "Monthly":
                    procStatement = "exec [dbo].[GetMonthlyIncidentData]";
                    break;
                case "Yearly":
                    procStatement = "exec [dbo].[GetYearlyIncidentData]";
                    break;
                default:
                    procStatement = "exec [dbo].[GetWeeklyIncidentData]";
                    break;

            }
            var q = db.Database.SqlQuery<ChartData>(procStatement).ToList();
            return q;
        }
        public List<IncidentChartModel> GetIncidents()
        {
            try
            {
                // getWeeklyIncidents();
                IncidentEntities db = new IncidentEntities();
                // IncidentEntities db = new IncidentEntities();
                // var incidents = db.ActMonitors.ToList();
                List<IncidentChartModel> lstChartModel = new List<IncidentChartModel>();
                var incidents1 = db.ActMonitors.GroupBy(x => SqlFunctions.DatePart("ww", x.Actual_Date_and_Time_of_Completion));

                var incidents = (from x in db.ActMonitors
                                 join y in db.ActivityTypes on x.Type_of_Activity equals y.ID
                                 select new { x.Status, x.Location, y.ActivityType1 }).ToList();

                foreach (var item in incidents)
                {
                    IncidentChartModel chart = new IncidentChartModel();
                    chart.Status = item.Status;
                    chart.Location = item.Location;
                    chart.ActivityType = item.ActivityType1;
                    lstChartModel.Add(chart);
                }

                return lstChartModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

    public class IncidentChartModel
    {
        public string Status { get; set; }
        public string Location { get; set; }
        public string ActivityType { get; set; }
    }

    public class ChartData
    {
        public string XValues { get; set; }
        public int YValues { get; set; }
        public string Series { get; set; }
    }
}