namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment Appurtenance")]
    public partial class Equipment_Appurtenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment_Appurtenance()
        {
            ActMonitors = new HashSet<ActMonitor>();
        }

        public int ID { get; set; }

        [Column("Equipment/Appurtenance")]
        [Required]
        [StringLength(255)]
        public string Equipment_Appurtenance1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActMonitor> ActMonitors { get; set; }
    }
}
