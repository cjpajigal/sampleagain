namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Update")]
    public partial class Update
    {
        public int CARID { get; set; }

        public int ID { get; set; }

        public int UpdateNo { get; set; }

        public int UpdateTYPE { get; set; }

        public int Status { get; set; }

        [Column("Date Submitted")]
        public DateTime Date_Submitted { get; set; }

        [StringLength(50)]
        public string Nature { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string BusinessArea { get; set; }

        public int? IncidentDiscoveryReporter { get; set; }

        [StringLength(50)]
        public string RootCause { get; set; }

        [StringLength(50)]
        public string EffectsOnCustomers { get; set; }

        [StringLength(50)]
        public string SpecificAreasAffected { get; set; }

        public int? NoOfHouseholdsAffected { get; set; }

        [StringLength(50)]
        public string KeyAccounts_VIPsAffected { get; set; }

        [Column(TypeName = "text")]
        public string MediaExposure_ReputationRisk { get; set; }

        [Column(TypeName = "text")]
        public string InterimSolutions { get; set; }

        [Column(TypeName = "text")]
        public string PermanentSolution { get; set; }

        public DateTime? EstimatedDateandTimeofCompletion { get; set; }

        [StringLength(50)]
        public string OIM { get; set; }

        [StringLength(50)]
        public string SIM { get; set; }

        [StringLength(50)]
        public string CIM { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Updates { get; set; }

        public virtual ActMonitor ActMonitor { get; set; }

        public virtual Status Status1 { get; set; }

        public virtual Update_Type Update_Type { get; set; }
    }
}
