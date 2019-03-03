using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRM.Data.Entities.Organistion
{
    [TrackChanges]
    public class Location : ISoftDeleteable, IRecordInfo
    {
        public Location()
        {
            Modifiedby = GetUserId();
            Modified = DateTime.Now;
        }
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Attachments { get; set; }
        public ICollection<State> CityId { get; set; }
        public ICollection<City> StateId { get; set; }
        public ICollection<Country> CountryId { get; set; }
        public string Address{ get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string Notes { get; set; }
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
        private DateTime? datetime;
        private string GetUserId()
        {
            return AppSession.UserId;
        }
    }
}
