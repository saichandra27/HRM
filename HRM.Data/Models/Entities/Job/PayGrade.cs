using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.Job
{
    public class PayGrade : ISoftDeleteable, IRecordInfo
    {
        public PayGrade()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public virtual ICollection<Grades> Title { get; set; }
        public virtual ICollection<Currency> Currency { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public string Attachments { get; set; }
        [SkipTracking]
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
        [ScaffoldColumn(false)]
        public string Createdby { get; set; }
        [ScaffoldColumn(false)]
        public string Modifiedby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        [ScaffoldColumn(false)]
        public DateTime? Created { get; set; }

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
        public virtual Currency CurrencyList { get; set; }
        public virtual Grades Grades { get; set; }
    }
}
