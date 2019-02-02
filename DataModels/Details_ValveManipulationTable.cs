namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_ValveManipulationTable
    {
        public int ID { get; set; }

        public int CARID { get; set; }

        public int ValveNumber { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string PresentStatus { get; set; }

        [Column("Proposed Status")]
        [StringLength(50)]
        public string Proposed_Status { get; set; }

        [Column("Status After the Activity")]
        [StringLength(50)]
        public string Status_After_the_Activity { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }
    }
}
