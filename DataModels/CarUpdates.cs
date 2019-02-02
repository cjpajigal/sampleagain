namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarUpdates")]
    public partial class CarUpdates
    {
        public int ID { get; set; }

        public int CarNumber { get; set; }

        [Required]
        [StringLength(4000)]
        public string Details { get; set; }

        [Column("DateCreated")]
        public DateTime? DateCreated { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

    }
}
