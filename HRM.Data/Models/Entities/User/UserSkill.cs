using HRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRM.Data.Entities.Qualification;
using HRM.Data.DbContext;
using System.Web;
using System.Linq;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class UserSkill : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }
        HRMDbContext _dbcontext;
        public UserSkill()
        {
        }
        public UserSkill(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public ICollection<SkillTitle> Title { get; set; }
        public int YearsofExperience { get; set; }
        public string Version { get; set; }
        public string Comments { get; set; }
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
