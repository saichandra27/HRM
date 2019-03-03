using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.Organistion
{
    [TrackChanges]
    public class Organisation : ISoftDeleteable, IRecordInfo
    {
        HRMDbContext dbcontext;

        public Organisation()
        {
            dbcontext = new HRMDbContext();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Attachments { get; set; }
        public double EmployeeCount { get; set; }
        public string RegistrationNumber { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public ICollection<City> CityId { get; set; }
        public ICollection<State> StateId { get; set; }
        public ICollection<Country> CountryId { get; set; }
        public string ZipCode { get; set; }
        public string Notes { get; set; }
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
        private string GetUserId()
        {
            string username = HttpContext.Current.User.Identity.Name;
            HRMUser hrmuser = dbcontext.HRMUser.Where(usr => usr.UserName == username).FirstOrDefault();
            return hrmuser.Id;
        }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }
}
