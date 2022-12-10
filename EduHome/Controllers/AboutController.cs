using EduHome.DAL;
using EduHome.ViewModels.About;
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
                Teachers = await _context.Teachers.Where(a => a.IsDeleted == false).ToListAsync(),
                Testimonials = await _context.Testimonials.Where(a => a.IsDeleted == false).ToListAsync(),
                NoticeBoards = await _context.NoticeBoards.Where(a => a.IsDeleted == false).ToListAsync()

            };
            if (aboutVM.AboutEduHomes == null && aboutVM.AboutEduHomes.Count() < 0)
            {
                return BadRequest();
            }
            if (aboutVM.Testimonials == null && aboutVM.Testimonials.Count() < 0)
            {
                return BadRequest();
            }
            if (aboutVM.NoticeBoards == null && aboutVM.NoticeBoards.Count() < 0)
            {
                return BadRequest();
            }
            if (aboutVM.Teachers == null && aboutVM.Teachers.Count() < 0)
            {
                return BadRequest();
            }
            return View(aboutVM);
        }

    }
}
