using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.Qualification
{
    [TrackChanges]
    public class SkillTitle : ISoftDeleteable, IRecordInfo
    {
        HRMDbContext dbcontext;

        public SkillTitle()
        {
            dbcontext = new HRMDbContext();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
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
        private string GetUserId()
        {
            string username = HttpContext.Current.User.Identity.Name;
            HRMUser hrmuser = dbcontext.HRMUser.Where(usr => usr.UserName == username).FirstOrDefault();
            return hrmuser.Id;
        }
    }
}
