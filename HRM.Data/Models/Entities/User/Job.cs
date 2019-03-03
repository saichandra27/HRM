using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using HRM.Data.Entities.Job;
using HRM.Data.Entities.Organistion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Jobdetail : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Jobdetail()
        {
        }

        public Jobdetail(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public string JobTitle { get; set; }
        public string JobSpecification { get; set; }
        public ICollection<EmploymentStatus> EmploymentStatus { get; set; }
        public ICollection<JobCategory> JobCategory { get; set; }
        public ICollection<Location> Location { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Contractdetails { get; set; }
        [SkipTracking]
        public bool IsDeleted { get; set; }
        public string Createdby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        public string Modifiedby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        public DateTime? Created
        {
            get { return datetime; }
            set { datetime = DateTime.Now; }
        }
        public DateTime? Modified
        {
            get { return datetime; }
            set { datetime = DateTime.Now; }
        }

        private string hrmuser;
        private DateTime datetime;
       
        public string Attachments { get; set; }
    }
}
