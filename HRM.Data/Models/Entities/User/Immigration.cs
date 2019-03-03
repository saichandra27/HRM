using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Immigration : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Immigration()
        {
        }

        public Immigration(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public Document Document { get; set; }
        public string Other { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExipryDate { get; set; }
        public string EligibleStatus { get; set; }
        public virtual ICollection<Country> Issuedby { get; set; }
        public string Comments { get; set; }
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
        public virtual Country Country { get; set; }
    }

    public enum Document
    {
        Passport = 1,
        Visa = 2,
        Others = 3
    }
}
