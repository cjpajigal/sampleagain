using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class Methodology
    {
        public void CreateNewMethodology(string carId, string activity, string datetime)
        {
            IncidentEntities db = new IncidentEntities();
            db.Details_Methodology.Add(new Details_Methodology { CARID = int.Parse(carId), Activity = activity, Start = DateTime.Parse(datetime), End = null, Duration = 0.0 });
            db.SaveChanges();
        }

    }
}