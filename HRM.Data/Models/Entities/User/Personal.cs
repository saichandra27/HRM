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
    public class Personal : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Personal()
        {
        }

        public Personal(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string EmployeeId { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ICollection<Nationality> Nationality { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Designation { get; set; }
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

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced
    }
}
