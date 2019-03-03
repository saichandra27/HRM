using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.Job
{
    [TrackChanges]
    public class JobTitle : ISoftDeleteable, IRecordInfo
    {
        public JobTitle()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [UIHint("FileUpload") ]
        public string Attachments { get; set; }
        
        [SkipTracking]
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
        [ScaffoldColumn(false)]
        public string Createdby
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        public string Modifiedby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        [ScaffoldColumn(false)]
        public DateTime? Created
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        public DateTime? Modified
        {
            get { return datetime; }
            set { datetime = DateTime.Now; }
        }

       

        private string hrmuser;
        private DateTime datetime;
        private string GetUserId()
        {
            return AppSession.UserId;
        }
    }
}
