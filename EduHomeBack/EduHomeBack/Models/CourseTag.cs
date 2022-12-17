using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class CourseTag : BaseEntity
    {
        public int Id { get; set; }


        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }


    }
}
