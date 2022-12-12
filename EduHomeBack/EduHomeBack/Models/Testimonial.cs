using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Testimonial : BaseEntity
    {
        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(100)]
        public string AuthorPosition { get; set; }

    }
}
