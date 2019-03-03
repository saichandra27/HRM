using HRM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Entities.General
{
    public class Currency : ISoftDeleteable
    {
        public Currency()
        {

        }
        public int ID { get; set; }
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
