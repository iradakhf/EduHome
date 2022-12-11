using EduHome.DAL;
using EduHome.ViewModels.About;
using EduHome.ViewModels.TeacherV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                AboutEduHomes = await _context.AboutEduHomes.Where(a => a.IsDeleted == false).ToListAsync(),
                Teachers = await _context.Teachers.Where(a => a.IsDeleted == false)
                .Select(t => new TeacherVM
                {
                    Image = t.Image,
                    Name = t.Name,
                    Profession = t.Profession,
                    Surname = t.Surname,
                    TwitterUrl = t.TwitterUrl,
                    FacebookUrl = t.FacebookUrl,
                    VUrl = t.VUrl,
                    PinterestUrl = t.PinterestUrl
                })
                .ToListAsync(),
                Testimonials = await _context.Testimonials.Where(a => a.IsDeleted == false).ToListAsync(),
                NoticeBoards = await _context.NoticeBoards.Where(a => a.IsDeleted == false).ToListAsync()

            };
            if (aboutVM.AboutEduHomes == null && aboutVM.AboutEduHomes.Count() < 0)
            {
                return NotFound();
            }
            if (aboutVM.Testimonials == null && aboutVM.Testimonials.Count() < 0)
            {
                return NotFound();
            }
            if (aboutVM.NoticeBoards == null && aboutVM.NoticeBoards.Count() < 0)
            {
                return NotFound();
            }
            if (aboutVM.Teachers == null && aboutVM.Teachers.Count() < 0)
            {
                return NotFound();
            }
            return View(aboutVM);
        }

    }
}
