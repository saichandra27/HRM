using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Models
{
    public class LeaveTypeViewModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public string Title { get; set; }
    }
}