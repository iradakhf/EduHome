using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Course : BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(2500)]
        [Required]
        [MinLength(100)]
        public string Description { get; set; }

        [StringLength(1000)]
        [Required]
        public string About { get; set; }

        [StringLength(1000)]
        [Required]
        public string HowToApply { get; set; }

        [StringLength(1000)]
        [Required]
        public string Certification { get; set; }

        public DateTime? Starts { get; set; }

        [StringLength(99)]
        [Required]
        public string Duration { get; set; }

        [StringLength(99)]
        [Required]
        public string ClassDuration { get; set; }

        [StringLength(500)]
        [Required]
        public string SkillLevel { get; set; }

        [StringLength(40)]
        [Required]
        public string Language { get; set; }

        [Required]
        public int StudentsCount { get; set; }

        [StringLength(500)]
        [Required]
        public string Assesments { get; set; }

        [Required]
        public double Fee { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public IEnumerable<CourseTag> CourseTags { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }



    }
}
