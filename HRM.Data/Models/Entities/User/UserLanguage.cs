using HRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRM.Data.Entities.Qualification;
using HRM.Data.Entities.General;
using System.Web;
using HRM.Data.DbContext;
using System.Linq;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class UserLanguage : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public UserLanguage()
        {
        }
        public UserLanguage(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public ICollection<Language> Title { get; set; }
        public Proficieny Proficieny { get; set; }
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
    public enum Proficieny
    {
        Elementaryproficiency = 1,
        Limitedworkingproficiency = 2,
        Professionalworkingproficiency = 3,
        Fullprofessionalproficiency = 4,
        Nativeorbilingualproficiency = 5
    }
}
