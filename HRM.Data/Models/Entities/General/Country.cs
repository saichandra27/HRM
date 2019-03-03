using HRM.Common;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.General
{
    public class Country : ISoftDeleteable
    {
        public Country()
        {

        }
        public int ID { get; set; }
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
