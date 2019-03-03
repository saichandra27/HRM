using HRM.Data.Entities.General;
using HRM.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Models
{
    public class UserViewModel
    {
        [Display(Name = "Address Stree1")]
        public string AddressStree1 { get; set; }
        [Display(Name = "Address Stree2")]
        public string AddressStree2 { get; set; }
        [Display(Name = "City")]
        public ICollection<City> City { get; set; }
        public virtual ICollection<State> State { get; set; }
        public virtual ICollection<Country> Country { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Home Telephone")]
        public string HomeTelephone { get; set; }
        public string Mobile { get; set; }
        [Display(Name = "Work Telephone")]
        public string WorkTelephone { get; set; }
        [Display(Name = "Personal Email")]
        public string PersonalEmailId { get; set; }
        [Display(Name = "Office Email")]
        public string OfficeEmailId { get; set; }
        [Display(Name = "Relative Name")]
        public string RelativeName { get; set; }
        public Relation Relationship { get; set; }
        [Display(Name = "Relative Name")]
        public string OtherRelationship { get; set; }
        [Display(Name = "National Identity Number")]
        public string NationalIdentityNumber { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Display(Name = "Other Information")]
        public string OtherInformation { get; set; }
    }
}
