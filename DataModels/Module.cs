namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; }

        [StringLength(50)]
        public string ModuleDisplayName { get; set; }

    }
}
