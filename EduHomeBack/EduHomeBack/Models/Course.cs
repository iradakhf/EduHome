using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EduHomeBack.Models
{
    public class Course : BaseEntity
    {
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string About { get; set; }

        [StringLength(1000)]
        public string HowToApply { get; set; }

        [StringLength(1000)]
        public string Certification { get; set; }

        public DateTime? Starts { get; set; }

        [StringLength(99)]
        public string Duration { get; set; }

        [StringLength(99)]
        public string ClassDuration { get; set; }

        [StringLength(500)]
        public string SkillLevel { get; set; }

        [StringLength(40)]
        public string Language { get; set; }

        public int StudentsCount { get; set; }

        [StringLength(500)]
        public string Assesments { get; set; }

        public double Fee { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }


    }
}
