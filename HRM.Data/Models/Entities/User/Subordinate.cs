using System;
using HRM.Common;
using System.ComponentModel.DataAnnotations;
using System.Web;
using HRM.Data.DbContext;
using System.Linq;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Subordinate : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Subordinate()
        {
        }

        public Subordinate(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public HRMUser SubordinateName { get; set; }
        public ReportingMethod ReportingMethod { get; set; }
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