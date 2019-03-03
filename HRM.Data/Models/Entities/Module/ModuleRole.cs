using HRM.Common;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.Module
{
    public class ModuleRole : ISoftDeleteable
    {
        public int Id { get; set; }
        public virtual string RoleId { get; set; }
        public virtual int ModuleId { get; set; }
        [SkipTracking]
        public bool IsDeleted { get; set; }
    }
}
