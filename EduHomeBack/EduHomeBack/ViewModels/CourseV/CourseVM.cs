using EduHomeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewModels.CourseV
{
    public class CourseVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Course Course { get; set; }
        public Settings setting { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Course> Courses { get; set; }


        public IEnumerable<Category> Categories { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
     }
}
