using HRM.Common;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.General
{
  
    public class Language : ISoftDeleteable
    {
        public Language()
        {

        }
        public int ID { get; set; }
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
