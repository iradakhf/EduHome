using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHomeBack.Models
{
    public class Skill : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public List<int> TeacherIds { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
