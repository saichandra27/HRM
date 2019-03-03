using HRM.Common;
using System;
using System.ComponentModel.DataAnnotations;


namespace HRM.Data.Entities.Leaves
{
    [TrackChanges]
    public class LeaveTypes : ISoftDeleteable, IRecordInfo
    {
        public LeaveTypes()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }

        private string hrmuser = string.Empty;
        private DateTime? dateCreated = null;
        private DateTime? dateModified = null;
        private string userid = string.Empty;
        private string GetUserId()
        {
            return AppSession.UserId;
        }
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        [SkipTracking]
        public bool IsDeleted
        {
            get; set;
        }
        public string Title { get; set; }
        #region RecordInfo
        [ScaffoldColumn(false)]
        public string Createdby
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        public string Modifiedby
        {
            get
            {
                return !string.IsNullOrEmpty(hrmuser) ? hrmuser : GetUserId();
            }
            set
            {
                hrmuser = GetUserId();
            }
        }
        [ScaffoldColumn(false)]
        public string UserId
        {
            get
            {
                return !string.IsNullOrEmpty(userid) ? userid : GetUserId();
            }
            set
            {
                userid = value;
            }
        }
        [ScaffoldColumn(false)]
        public DateTime? Created
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        public DateTime? Modified
        {
            get
            {
                return dateModified.HasValue ? dateModified.Value : DateTime.Now;
            }

            set
            {
                dateCreated = value;
            }
        }
        public string Attachments { get; set; }
        #endregion
    }
}
