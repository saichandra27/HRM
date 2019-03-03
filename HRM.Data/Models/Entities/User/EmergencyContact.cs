using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class EmergencyContact : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public EmergencyContact()
        {
        }

        public EmergencyContact(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string HomeTelepone { get; set; }
        public string Mobile { get; set; }
        public string WorkTelephone { get; set; }
        public string Attachments { get; set; }
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
      
    }
}
