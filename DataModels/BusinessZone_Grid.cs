namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusinessZone_Grid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusinessZone_Grid()
        {
            ActMonitors = new HashSet<ActMonitor>();
            DMZFacilities = new HashSet<DMZFacility>();
        }

        public int ID { get; set; }

        public int NetworkGridID { get; set; }

        [Column("BusinessZone_Grid")]
        [Required]
        [StringLength(255)]
        public string BusinessZone_Grid1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActMonitor> ActMonitors { get; set; }

        public virtual NetworkGrid_BA NetworkGrid_BA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMZFacility> DMZFacilities { get; set; }
    }
}
