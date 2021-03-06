﻿using System;
using HRM.Common;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRM.Data.Entities.Job;
using HRM.Data.Entities.Qualification;
using HRM.Data.DbContext;
using System.Web;
using System.Linq;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Education : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Education()
        {
        }

        public Education(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public ICollection<EducationLevel> Title { get; set; }
        public string Institue { get; set; }
        public string Specializaiton { get; set; }
        public string Year { get; set; }
        public string Score { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
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
    }
}
