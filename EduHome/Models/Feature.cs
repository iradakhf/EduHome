using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Feature : BaseEntity
    {
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


    }
}
