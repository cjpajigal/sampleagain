namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_WhatIFs
    {
        public int CARID { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string WhatIFs { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }
    }
}
