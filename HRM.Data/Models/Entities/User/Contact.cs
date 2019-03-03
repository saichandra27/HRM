using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Contact : ISoftDeleteable, IRecordInfo
    {
        private string hrmuser = string.Empty;
        private DateTime? dateCreated = null;
        private DateTime? dateModified = null;
        private string userid = string.Empty;
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        

        public Contact()
        {
        }

        public Contact(HRMDbContext dbcontext)
        {
            
        }

        public int ID { get; set; }

        public string AddressStree1 { get; set; }
        public string AddressStree2 { get; set; }
        public ICollection<City> CityId { get; set; }
        public virtual ICollection<State> StateId { get; set; }
        public virtual ICollection<Country> CountryId { get; set; }
        public string ZipCode { get; set; }
        public string HomeTelephone { get; set; }
        public string Mobile { get; set; }
        public string WorkTelephone { get; set; }
        public string PersonalEmailId { get; set; }
        public string OfficeEmailId { get; set; }
        public string Attachments { get; set; }
        [SkipTracking]
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }

        public string Createdby
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

        public DateTime? Created
        {
            get
            {
                return dateCreated.HasValue ? dateCreated.Value : DateTime.Now;
            }

            set
            {
                dateCreated = value;
            }
        }
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


    }
}
