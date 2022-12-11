using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels.CourseV;
using EduHome.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                CourseVMs = await _context.Courses.Where(c=>c.IsDeleted==false)
                .Select(c=> new CourseVM {
                    Name =c.Name,
                    Image = c.Image,
                    Description = c.Description,
                    Id = c.Id
                }).ToListAsync(),
                Blogs = await _context.Blogs.Where(b=>b.IsDeleted==false).ToListAsync(),
                Events = await _context.Events.Where(e => e.IsDeleted == false).ToListAsync(),
                NoticeBoards = await _context.NoticeBoards.Where(n => n.IsDeleted == false).ToListAsync(),
                AboutEduHomes = await _context.AboutEduHomes.Where(n => n.IsDeleted == false).ToListAsync(),
                Testimonials = await _context.Testimonials.Where(n => n.IsDeleted == false).ToListAsync()
            };
            if(homeVM.Sliders==null && homeVM.Sliders.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.CourseVMs == null && homeVM.CourseVMs.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.Blogs == null && homeVM.Blogs.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.Events == null && homeVM.Events.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.NoticeBoards == null && homeVM.NoticeBoards.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.AboutEduHomes == null && homeVM.AboutEduHomes.Count() < 0)
            {
                return NotFound();
            }
            if (homeVM.Testimonials == null && homeVM.Testimonials.Count() < 0)
            {
                return NotFound();
            }
            return View(homeVM);
        }

       
    }
}
