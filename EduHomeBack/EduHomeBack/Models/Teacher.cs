using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class Teacher : BaseEntity
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Surname { get; set; }

        [StringLength(5000)]
        public string Image { get; set; }
   

        [StringLength(500)]
        [Required]
        [MinLength(100)]
        public string About { get; set; }

        [StringLength(255)]
        [Required]
        public string Degree { get; set; }

        [StringLength(255)]
        [Required]
        public string Experience { get; set; }

        [StringLength(255)]
        [Required]
        public string Faculty { get; set; }

        [StringLength(255)]
        [Required]
        public string Hobbies { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [StringLength(255)]
        [Required]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        [Required]
        public string Skype { get; set; }

        [StringLength(255)]
        [Required]
        public string FacebookUrl { get; set; }

        [StringLength(255)]
        [Required]
        public string PinterestUrl { get; set; }

        [StringLength(255)]
        [Required]
        public string VUrl { get; set; }

        [StringLength(255)]
        [Required]
        public string TwitterUrl { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        [NotMapped]
        public List<int> SkillIds { get; set; }

        public IEnumerable<TeacherSkill> TeacherSkills { get; set; }
        public IEnumerable<Course> Courses { get; set; }


    }
}
