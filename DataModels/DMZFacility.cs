namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMZFacility")]
    public partial class DMZFacility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMZFacility()
        {
            ActMonitors = new HashSet<ActMonitor>();
        }

        public int ID { get; set; }

        public int BusinessZoneID { get; set; }

        [Required]
        [StringLength(255)]
        public string DMZ_Facility { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActMonitor> ActMonitors { get; set; }

        public virtual BusinessZone_Grid BusinessZone_Grid { get; set; }
    }
}
