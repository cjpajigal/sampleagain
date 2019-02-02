namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Details_SiteMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CARID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(255)]
        public string SiteMap { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }
    }
}
