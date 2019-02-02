namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_ManPower
    {
        public int ID { get; set; }

        public int CARID { get; set; }

        [Required]
        [StringLength(255)]
        public string Manpower { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }
    }
}
