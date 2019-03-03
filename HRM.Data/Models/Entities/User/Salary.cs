using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using HRM.Data.Entities.Job;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Salary : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Salary()
        {
        }

        public Salary(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public ICollection<PayGrade> PayGrade { get; set; }
        public ICollection<SalaryComponent> SalaryComponent { get; set; }
        public PayFrequency PayFrequency { get; set; }
        public ICollection<Currency> Currency { get; set; }
        public double Amount { get; set; }
        public string Comments { get; set; }
        public BankAccount BankAccountdetails { get; set; }
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

    public enum PayFrequency
    {
        Monthly = 1,
        Yearly = 2,
        Quarterly = 3,
        Weekly = 4,
        Others = 5
    }
}
