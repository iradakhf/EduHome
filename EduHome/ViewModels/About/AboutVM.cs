using EduHome.Models;
using EduHome.ViewModels.TeacherV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels.About
{
    public class AboutVM
    {
        public IEnumerable<AboutEduHome> AboutEduHomes { get; set; }
        public IEnumerable<TeacherVM> Teachers { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public IEnumerable<NoticeBoard> NoticeBoards { get; set; }
     
    }
}
