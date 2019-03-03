using HRM.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.Module
{
    [TrackChanges]
    public class Module : ISoftDeleteable
    {
        public Module()
        {
        }
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<ModuleRole> Roles { get; set; }
        [SkipTracking]
        public bool IsDeleted { get; set; }
    }
}
