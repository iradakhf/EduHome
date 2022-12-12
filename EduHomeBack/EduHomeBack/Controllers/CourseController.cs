using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.CourseV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
               
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public async Task<IActionResult> Search(string text)
        {
            IEnumerable<CourseVM> courses = await _context.Courses.Where(c => c.IsDeleted == false
            && c.Name.ToLower().Contains(text.ToLower())
            || c.Category.Name.ToLower().Contains(text.ToLower())
            || c.About.Contains(text.ToLower())
            || c.Description.Contains(text.ToLower())
            ).Skip(2).Take(5).Select(c => new CourseVM {
                Name = c.Name,
                Image = c.Image
            }).ToListAsync();

            return PartialView("_SearchPartial",courses);
        }
    }
}
