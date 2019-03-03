using HRM.Common;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.General
{
    public class Nationality : ISoftDeleteable
    {
        public Nationality()
        {

        }
        public int ID { get; set; }
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
