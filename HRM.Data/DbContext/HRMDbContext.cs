using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrackerEnabledDbContext.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HRM.Data.Entities;
using HRM.Data.DbConfiguration;
using HRM.Data.Entities.User;
using HRM.Data.Entities.Module;
using HRM.Data.Entities.Leaves;
using HRM.Data.Entities.Job;
using HRM.Data.Entities.Qualification;
using HRM.Data.Entities.General;
using HRM.Data.Entities.Organistion;

namespace HRM.Data.DbContext
{
    public class HRMDbContext : TrackerIdentityContext<IdentityUser>
    {
        private static Dictionary<Type, EntitySetBase> _mappingCache = new Dictionary<Type, EntitySetBase>();
        public HRMDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HRMDbContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //module table
            var module = modelBuilder.Entity<LeaveTypes>()
                .HasKey(a => a.ID)
                .Map(a =>
                {
                    a.Requires("IsDeleted").HasValue(false);
                    a.ToTable("LeaveTypes");
                })
                .Ignore(a => a.IsDeleted);
        }
        public virtual IDbSet<Role> Role { get; set; }
        public virtual IDbSet<Module> Module { get; set; }
        public virtual IDbSet<ModuleRole> ModuleRole { get; set; }
        public virtual IDbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual IDbSet<HRMUser> HRMUser { get; set; }
        public virtual IDbSet<Contact> Contact { get; set; }
        public virtual IDbSet<Dependent> Dependent { get; set; }
        public virtual IDbSet<JobTitle> JobTitle { get; set; }
        public virtual IDbSet<PayGrade> PayGrade { get; set; }
        public virtual IDbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual IDbSet<JobCategory> JobCategory { get; set; }
        public virtual IDbSet<Location> Location { get; set; }
        public virtual IDbSet<UserSkill> UserSkill { get; set; }
        public virtual IDbSet<Education> Education { get; set; }
        public virtual IDbSet<Certification> Certification { get; set; }
        public virtual IDbSet<EducationLevel> EducationLevel { get; set; }
        public virtual IDbSet<SkillTitle> SkillTitle { get; set; }
        public virtual IDbSet<Language> Language { get; set; }
        public virtual IDbSet<JobShifts> JobShifts { get; set; }
        public virtual IDbSet<City> City { get; set; }
        public virtual IDbSet<State> State { get; set; }
        public virtual IDbSet<Country> Country { get; set; }



        public static HRMDbContext Create()
        {
            return new HRMDbContext();
        }

        
    }
}
