using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRM.Data
{
    [TrackChanges]
    public class User : IdentityUser
    {
        [StringLength(66)]
        public virtual string DisplayName { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime? PwdLastChangedDate { get; set; }
        public ICollection<PasswordHistory> PwdHistories { get; set; }
        [StringLength(128)]
        [Required]
        public string AgencyId { get; set; }
        [StringLength(128)]
        public string LockedOutReasonId { get; set; }
        [Required]
        public bool InUse { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        [NotMapped]
        public bool IsLocked
        {
            get
            {
                if (LockoutEndDateUtc.HasValue)
                {
                    return (DateTime.Now > LockoutEndDateUtc.Value) ? false : true;
                }
                else
                    return false;
            }
        }
    }
}
