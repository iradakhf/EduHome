using EduHome.Models;
using EduHome.ViewModels.CourseV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders{ get; set; }
        public IEnumerable<CourseVM> CourseVMs { get; set; }
        public IEnumerable<NoticeBoard> NoticeBoards { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public IEnumerable<AboutEduHome> AboutEduHomes { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }



    }
}
