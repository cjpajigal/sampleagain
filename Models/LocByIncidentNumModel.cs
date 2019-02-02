using IncidentManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
   
        public class LocByIncidentNumModel
        {
            public List<LocByNum> GetIncidentLocationReport()
            {
                try
                {
                    using (IncidentEntities db = new IncidentEntities())
                    {
                        var locbynum = (from x in db.LocByNums
                                        select x);
                        /*from p in myTable
                        where p.Used = "N"
                        group p by p.PartID into gp
                        select new
                        {
                            PartID = gp.PartID,
                            InstanceCount = gp.Count(),
                        }*/



                        return locbynum.ToList(); ;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
