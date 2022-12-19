using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Comment : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Email { get; set; }
        [StringLength(200)]
        public string Subject { get; set; }
        [StringLength(3000)]
        public string Message { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public int? BlogId { get; set; }

        public Blog Blog { get; set; }


    }
}
