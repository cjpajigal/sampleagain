namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AffectedArea")]
    public partial class AffectedArea
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column("AffectedArea", Order = 1)]
        [StringLength(100)]
        public string AffectedArea1 { get; set; }
    }
}
