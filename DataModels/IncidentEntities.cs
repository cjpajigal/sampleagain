namespace IncidentManagement.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IncidentEntities : DbContext
    {
        public IncidentEntities()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<ActMonitor> ActMonitors { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BusinessZone_Grid> BusinessZone_Grid { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Details_Health_Safety> Details_Health_Safety { get; set; }
        public virtual DbSet<Details_ManPower> Details_ManPower { get; set; }
        public virtual DbSet<Details_Materials> Details_Materials { get; set; }
        public virtual DbSet<Details_Methodology> Details_Methodology { get; set; }
        public virtual DbSet<Details_Milestones> Details_Milestones { get; set; }
        public virtual DbSet<Details_SiteMap> Details_SiteMap { get; set; }
        public virtual DbSet<Details_ToolsEquipment> Details_ToolsEquipment { get; set; }
        public virtual DbSet<Details_ValveManipulationTable> Details_ValveManipulationTable { get; set; }
        public virtual DbSet<Details_WhatIFs> Details_WhatIFs { get; set; }
        public virtual DbSet<DMZFacility> DMZFacilities { get; set; }
        public virtual DbSet<Equipment_Appurtenance> Equipment_Appurtenances { get; set; }
        public virtual DbSet<Incident_Event> Incident_Event { get; set; }
        public virtual DbSet<LocByNum> LocByNums { get; set; }
        public virtual DbSet<NetworkGrid_BA> NetworkGrid_BA { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Type_> Type_ { get; set; }
        public virtual DbSet<Update> Updates { get; set; }
        public virtual DbSet<Update_Type> Update_Type { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<AffectedArea> AffectedAreas { get; set; }

        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<RoleModule> RoleModule { get; set; }
        public virtual DbSet<CarUpdates> CarUpdates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityType>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.ActivityType)
                .HasForeignKey(e => e.Type_of_Activity);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_Health_Safety)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_ManPower)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_Materials)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_Methodology)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_SiteMap)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_ToolsEquipment)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_ValveManipulationTable)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Details_WhatIFs)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            // PS2019
            //For Modules and RoleModules
            modelBuilder.Entity<Module>();

            modelBuilder.Entity<RoleModule>();

            modelBuilder.Entity<CarUpdates>();

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<ActMonitor>()
                .HasMany(e => e.Updates)
                .WithRequired(e => e.ActMonitor)
                .HasForeignKey(e => e.CARID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BusinessZone_Grid>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.BusinessZone_Grid)
                .HasForeignKey(e => e.Business_Zone__Grid);

            modelBuilder.Entity<BusinessZone_Grid>()
                .HasMany(e => e.DMZFacilities)
                .WithRequired(e => e.BusinessZone_Grid)
                .HasForeignKey(e => e.BusinessZoneID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Classification2)
                .HasForeignKey(e => e.Classification);

            modelBuilder.Entity<Classification>()
                .HasMany(e => e.Incident_Event)
                .WithRequired(e => e.Classification)
                .HasForeignKey(e => e.CatergoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Contractor1)
                .HasForeignKey(e => e.Contractor);

            modelBuilder.Entity<DMZFacility>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.DMZFacility)
                .HasForeignKey(e => e.DMZ__Facility);

            modelBuilder.Entity<Equipment_Appurtenance>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Equipment_Appurtenance)
                .HasForeignKey(e => e.Equipment__Appurtenance);

            modelBuilder.Entity<Incident_Event>()
                .Property(e => e.Incident_Event1)
                .IsUnicode(false);

            modelBuilder.Entity<Incident_Event>()
                .HasMany(e => e.ActivityTypes)
                .WithRequired(e => e.Incident_Event)
                .HasForeignKey(e => e.IncidentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Incident_Event>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Incident_Event)
                .HasForeignKey(e => e.Incident);

            modelBuilder.Entity<LocByNum>()
                .Property(e => e.Loc)
                .IsUnicode(false);

            modelBuilder.Entity<NetworkGrid_BA>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.NetworkGrid_BA)
                .HasForeignKey(e => e.Network_Grid_BA);

            modelBuilder.Entity<NetworkGrid_BA>()
                .HasMany(e => e.BusinessZone_Grid)
                .WithRequired(e => e.NetworkGrid_BA)
                .HasForeignKey(e => e.NetworkGridID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Size1)
                .HasForeignKey(e => e.Size);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Updates)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_>()
                .HasMany(e => e.ActMonitors)
                .WithOptional(e => e.Type_)
                .HasForeignKey(e => e.Type_of_Activity);

            modelBuilder.Entity<Update>()
                .Property(e => e.MediaExposure_ReputationRisk)
                .IsUnicode(false);

            modelBuilder.Entity<Update>()
                .Property(e => e.InterimSolutions)
                .IsUnicode(false);

            modelBuilder.Entity<Update>()
                .Property(e => e.PermanentSolution)
                .IsUnicode(false);

            modelBuilder.Entity<Update>()
                .Property(e => e.Updates)
                .IsUnicode(false);

            modelBuilder.Entity<Update_Type>()
                .HasMany(e => e.Updates)
                .WithRequired(e => e.Update_Type)
                .HasForeignKey(e => e.UpdateTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.MobileNum)
                .IsFixedLength();
        }
    }
}
