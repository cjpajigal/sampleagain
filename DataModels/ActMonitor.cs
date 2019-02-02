namespace IncidentManagement.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActMonitor")]
    public partial class ActMonitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActMonitor()
        {
            Details_Health_Safety = new HashSet<Details_Health_Safety>();
            Details_ManPower = new HashSet<Details_ManPower>();
            Details_Materials = new HashSet<Details_Materials>();
            Details_Methodology = new HashSet<Details_Methodology>();
            Details_SiteMap = new HashSet<Details_SiteMap>();
            Details_ToolsEquipment = new HashSet<Details_ToolsEquipment>();
            Details_ValveManipulationTable = new HashSet<Details_ValveManipulationTable>();
            Details_WhatIFs = new HashSet<Details_WhatIFs>();
            Updates = new HashSet<Update>();
        }

        [Key]
        [Column("CAR Number")]
        public int CAR_Number { get; set; }

        [Column("Scheduled Today?")]
        [StringLength(255)]
        public string Scheduled_Today_ { get; set; }

        [Column("Date and Time of CAR Submission", TypeName = "datetime2")]
        public DateTime? Date_and_Time_of_CAR_Submission { get; set; }

        [Column("Unique CAR ID")]
        [StringLength(255)]
        public string Unique_CAR_ID { get; set; }

        [Column("Network Grid/BA")]
        public int? Network_Grid_BA { get; set; }

        [Column("Business Zone/ Grid")]
        public int? Business_Zone__Grid { get; set; }

        [Column("DMZ/ Facility")]
        public int? DMZ__Facility { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column("Affected Barangay/s ")]
        [StringLength(255)]
        public string Affected_Barangay_s_ { get; set; }

        [Column("Affected Municipality")]
        [StringLength(255)]
        public string Affected_Municipality { get; set; }

        [Column("List of Affected MRUs")]
        [StringLength(255)]
        public string List_of_Affected_MRUs { get; set; }

        [Column("List of Affected DMAs")]
        [StringLength(255)]
        public string List_of_Affected_DMAs { get; set; }

        [Column("Number of Affected Households")]
        public int? Number_of_Affected_Households { get; set; }

        public int? Classification { get; set; }

        public int? Incident { get; set; }

        [Column("Type of Activity")]
        public int? Type_of_Activity { get; set; }

        [Column("Equipment/ Appurtenance")]
        public int? Equipment__Appurtenance { get; set; }

        [Column("Type of Equipment/Appurtenance")]
        public int? Type_of_Equipment_Appurtenance { get; set; }

        public int? Size { get; set; }

        [Column("Affected Area")]
        [StringLength(255)]
        public string Affected_Area { get; set; }

        public int? Contractor { get; set; }

        [Column("Means of Notification")]
        public int? Means_of_Notification { get; set; }

        [Column("Need Media Advisory")]
        public int? Need_Media_Advisory { get; set; }

        [StringLength(255)]
        public string OIM { get; set; }

        [StringLength(255)]
        public string SIM { get; set; }

        [StringLength(255)]
        public string CIM { get; set; }

        [Column("Remarks/_Comments")]
        [StringLength(255)]
        public string Remarks__Comments { get; set; }

        [Column("Prework Completion")]
        public DateTime? Prework_Completion { get; set; }

        [Column("Interruption of Service")]
        public DateTime? Interruption_of_Service { get; set; }

        [Column("Physical Completion")]
        public DateTime? Physical_Completion { get; set; }

        [Column("Return of Service")]
        public DateTime? Return_of_Service { get; set; }

        public double? Duration { get; set; }

        [Column("Sender/Receiver/_Date-Time")]
        [StringLength(255)]
        public string Sender_Receiver__Date_Time { get; set; }

        [StringLength(255)]
        public string Classification1 { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [Column("Actual Date and Time of Start")]
        public DateTime? Actual_Date_and_Time_of_Start { get; set; }

        [Column("Actual Date and Time of Service Interruption")]
        [StringLength(255)]
        public string Actual_Date_and_Time_of_Service_Interruption { get; set; }

        [Column("Actual Date and Time of Completion")]
        public DateTime? Actual_Date_and_Time_of_Completion { get; set; }

        [Column("Actual Date and Time of Service Return")]
        public DateTime? Actual_Date_and_Time_of_Service_Return { get; set; }

        [Column("Actual Duration of Activity (in hours)")]
        public double? Actual_Duration_of_Activity__in_hours_ { get; set; }

        [Column("Variance in Duration (Agreed vs Actual)")]
        public double? Variance_in_Duration__Agreed_vs_Actual_ { get; set; }

        [Column("Reported by and time of sign-on _")]
        [StringLength(255)]
        public string Reported_by_and_time_of_sign_on__ { get; set; }

        [Column("Closed-out by and time of_sign-off")]
        [StringLength(255)]
        public string Closed_out_by_and_time_of_sign_off { get; set; }

        [Column("Initial Alert Level_")]
        [StringLength(255)]
        public string Initial_Alert_Level_ { get; set; }

        [Column("Incident Escalation_ (Yes or No)")]
        [StringLength(255)]
        public string Incident_Escalation___Yes_or_No_ { get; set; }

        [Column("With or without service interruption _(Yes or No)")]
        [StringLength(255)]
        public string With_or_without_service_interruption___Yes_or_No_ { get; set; }

        [Column("Duty (last update)")]
        [StringLength(255)]
        public string Duty__last_update_ { get; set; }

        [StringLength(255)]
        public string Findings { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual BusinessZone_Grid BusinessZone_Grid { get; set; }

        public virtual Classification Classification2 { get; set; }

        public virtual Contractor Contractor1 { get; set; }

        public virtual DMZFacility DMZFacility { get; set; }

        public virtual Equipment_Appurtenance Equipment_Appurtenance { get; set; }

        public virtual Incident_Event Incident_Event { get; set; }

        public virtual NetworkGrid_BA NetworkGrid_BA { get; set; }

        public virtual Size Size1 { get; set; }

        public virtual Type_ Type_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_Health_Safety> Details_Health_Safety { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_ManPower> Details_ManPower { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_Materials> Details_Materials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_Methodology> Details_Methodology { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_SiteMap> Details_SiteMap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_ToolsEquipment> Details_ToolsEquipment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_ValveManipulationTable> Details_ValveManipulationTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details_WhatIFs> Details_WhatIFs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Update> Updates { get; set; }
    }
}
