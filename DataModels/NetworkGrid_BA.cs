namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NetworkGrid_BA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NetworkGrid_BA()
        {
            ActMonitors = new HashSet<ActMonitor>();
            BusinessZone_Grid = new HashSet<BusinessZone_Grid>();
        }

        public int ID { get; set; }

        [Column("NetworkGrid_BA")]
        [Required]
        [StringLength(255)]
        public string NetworkGrid_BA1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActMonitor> ActMonitors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessZone_Grid> BusinessZone_Grid { get; set; }
    }
}
