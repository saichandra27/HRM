using HRM.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data
{
    [TrackChanges]
    public class PasswordHistory : ISoftDeleteable
    {
        public PasswordHistory()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual DateTime PwdChangeDate { get; set; }
        public virtual bool InUse { get; set; }
        public virtual string UserId { get; set; }
        public virtual User PwdOwner { get; set; }
        [SkipTracking]
        public bool IsDeleted { get; set; }
    }
}
