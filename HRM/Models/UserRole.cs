using HRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class UserRole
    {
        public IQueryable<Role> lstroles { get; set; }
        public IQueryable<HRMUser> lstusers { get; set; }
    }
}