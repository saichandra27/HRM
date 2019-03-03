using HRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace HRM.Data.Entities.Job
{
    [TrackChanges]
    public class JobShifts : ISoftDeleteable, IRecordInfo
    {
        public JobShifts()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public string Title { get; set; }
        public double Hoursperday { get; set; }
        public string Attachments { get; set; }
        public List<HRMUser> AvailableEmployees { get; set; }
        [SkipTracking]
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
        [ScaffoldColumn(false)]
        public string Createdby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
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
            get { return datetime; }
            set { datetime = DateTime.Now; }
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
