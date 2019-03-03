using HRM.Common;
using HRM.Data.Entities.General;
using HRM.Data.Entities.Job;
using HRM.Data.Entities.Organistion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.Job
{
    public class SalaryComponent
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
