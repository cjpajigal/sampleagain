namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleModule")]
    public partial class RoleModule
    {
        public int RoleModuleID { get; set; }

        public string RoleID { get; set; }

        public int ModuleID { get; set; }

        //public virtual AspNetRole AspNetRole { get; set; }

        //public virtual Module Module { get; set; }

    }
}
