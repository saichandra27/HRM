
using HRM.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Data.Entities.General
{
    public class City : ISoftDeleteable
    {
        public City()
        {

        }
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<State> StateId { get; set; }
        public virtual ICollection<Country> CountryId { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
