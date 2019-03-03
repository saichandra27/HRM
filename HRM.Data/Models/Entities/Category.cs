using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Models.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [UIHint("FileUpload")]
        [Required]
        public string ImageUrl { get; set; }
    }
}
