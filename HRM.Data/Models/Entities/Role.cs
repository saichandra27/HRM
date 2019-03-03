using HRM.Data.Entities.Module;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Entities
{
    [TrackChanges]
    public class Role : IdentityRole
    {
        [Required]
        public virtual bool InUse { get; set; }

        public virtual ICollection<ModuleRole> Modules { get; set; }
    }
}
