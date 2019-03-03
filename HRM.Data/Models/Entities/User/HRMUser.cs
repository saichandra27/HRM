using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRM.Data.Entities
{
    [TrackChanges]
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class HRMUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<HRMUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
            
        }
    //    public ICollection<Contact> Contacts { get; set; }
    //    public ICollection<Dependent> Dependents { get; set; }
        //public ICollection<Educaiton> Educaitons { get; set; }
        //public ICollection<EmergencyContact> EmergencyContacts { get; set; }
        //public ICollection<Immigration> Immigrations { get; set; }
        //public ICollection<Jobdetail> Jobs { get; set; }
        //public ICollection<Personal> Personals { get; set; }
        //public ICollection<Salary> Salaries { get; set; }
        //public ICollection<Subordinate> Subordinates { get; set; }
        //public ICollection<Supervisor> Supervisorss { get; set; }
        //public ICollection<UserIdentification> Identificationss { get; set; }
        //public ICollection<UserLanguage> Languages { get; set; }
        //public ICollection<UserSkill> Skills { get; set; }
        //public ICollection<WorkExperience> Experiences { get; set; }
       // public virtual Contact Contact { get; set; }
      //  public virtual Dependent Dependent { get; set; }
        //public virtual Educaiton Educaiton { get; set; }
        //public virtual EmergencyContact EmergencyContact { get; set; }
        //public virtual Jobdetail Jobdetail { get; set; }
        //public virtual Personal Personal { get; set; }
        //public virtual Salary Salary { get; set; }
        //public virtual Subordinate Subordinate { get; set; }
        //public virtual Supervisor Supervisor { get; set; }
        //public virtual UserIdentification UserIdentification { get; set; }
        //public virtual UserLanguage UserLanguage { get; set; }
        //public virtual UserSkill UserSkill { get; set; }
        //public virtual WorkExperience WorkExperience { get; set; }
    }
}
