using IncidentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IncidentManagement
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCharts();
            }
        }

        private void LoadCharts()
        {
            ChartModel model = new ChartModel();
            var incidents = model.GetIncidents();

            //chartCompare.Series[0].Points[0].YValues = new double[] { incidents.Where(x => x.Status.Contains("Completed")).Count() };
            //chartCompare.Series[1].Points[0].YValues = new double[] { incidents.Where(x => x.Status == "Delayed").Count() };

            List<ChartData> wIncidents = model.getWeeklyIncidents(ddlFrequency.SelectedValue);


            foreach (var series in wIncidents.Select(x => x.Series).Distinct())
            {
                var seriesData = wIncidents.Where(x => x.Series == series).ToList();
                chartCompare.Series.Add(new Series { Name = seriesData[0].Series });
                chartCompare.Legends.Add(new Legend { Name = seriesData[0].Series });
                foreach (var point in seriesData)
                {
                    chartCompare.Series[seriesData[0].Series].Points.Add(new DataPoint { AxisLabel = point.XValues, YValues = new double[] { point.YValues } });
                }
            }
            var incidentByLocation = incidents.GroupBy(x => x.Location).Select(group => new
            {
                Location = group.Key,
                Count = group.Count()
            });

            foreach (var item in incidentByLocation)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { item.Count };
                dp.AxisLabel = item.Location;
                chartIncidentByLocation.Series[0].Points.Add(dp);
            }

            var incidentByType = incidents.GroupBy(x => x.ActivityType).Select(group => new
            {
                Type = group.Key,
                Count = group.Count()
            });

            foreach (var item in incidentByType)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { item.Count };
                dp.AxisLabel = item.Type.ToString();
                chartIncidentType.Series[0].Points.Add(dp);
            }
            chartIncidentType.Series[0].SetCustomProperty("PieLabelStyle", "outside");

        }
        protected void ddlFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharts();
            //ChartModel model = new ChartModel();
            //List<ChartData> wIncidents = model.getWeeklyIncidents(ddlFrequency.SelectedValue);


            //foreach (var series in wIncidents.Select(x => x.Series).Distinct())
            //{
            //    var seriesData = wIncidents.Where(x => x.Series == series).ToList();
            //    chartCompare.Series.Add(new Series { Name = seriesData[0].Series });
            //    chartCompare.Legends.Add(new Legend { Name = seriesData[0].Series });
            //    foreach (var point in seriesData)
            //    {
            //        chartCompare.Series[seriesData[0].Series].Points.Add(new DataPoint { AxisLabel = point.XValues, YValues = new double[] { point.YValues } });
            //    }
            //}
        }
    }
}