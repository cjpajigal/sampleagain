namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_Methodology
    {
        public int ID { get; set; }

        public int CARID { get; set; }

        public int MethodologyNumber { get; set; }

        [StringLength(50)]
        public string Activity { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public double Duration { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }
    }
}
