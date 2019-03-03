﻿using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.Job
{
    [TrackChanges]
    public class EmploymentStatus : ISoftDeleteable, IRecordInfo
    {
        public EmploymentStatus()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }
        public int ID { get; set; }
        public string Title { get; set; }
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
        public DateTime ? Created
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        public DateTime ? Modified
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
