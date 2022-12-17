using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHomeBack.Models
{
    public class Category : BaseEntity
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
       
        [NotMapped]
        public IEnumerable<Blog> Blogs { get; set; }

        [NotMapped]
        public IEnumerable<Event> Events { get; set; }

        [NotMapped]
        public IEnumerable<Course> Courses { get; set; }
    }
}
