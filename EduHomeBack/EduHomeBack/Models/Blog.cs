using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Blog : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(3000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
