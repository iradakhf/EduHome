using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHomeBack.Models
{
    public class Tag : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }


        [NotMapped]
        public List<int> BlogIds { get; set; }
        [NotMapped]
        public List<int> EventIds { get; set; }
        [NotMapped]
        public List<int> CourseIds { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }

        public IEnumerable<EventTag> EventTags { get; set; }

        public IEnumerable<CourseTag> CourseTags { get; set; }


    }
}
