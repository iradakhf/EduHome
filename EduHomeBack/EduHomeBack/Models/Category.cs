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
       
        public IEnumerable<Blog> Blogs { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
