using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }

        public double ProgressPercentage { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
