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
            if (id == null)
            {
                return BadRequest();
            }
            CourseVM courseVM = new CourseVM
            {
                Blogs = await _context.Blogs
                 .Where(b => b.IsDeleted == false).ToListAsync(),
                Courses = await _context.Courses.Where(c => c.IsDeleted == false).Include(c => c.Category).ToListAsync(),
                Categories = await _context.Categories.Include(c => c.Courses)
                 .Where(c => c.IsDeleted == false &&
                 c.Events.Any(e => e.CategoryId == c.Id)).ToListAsync(),
                Course = await _context.Courses.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
                Tags = await _context.Tags.Where(t => t.IsDeleted == false).Include(c => c.CourseTags)
                .ThenInclude(t=>t.Course)
                 .Where(t => t.IsDeleted == false &&
                 t.CourseTags.Any(c => c.TagId == t.Id)).ToListAsync(),
            };

            if (courseVM == null)
            {
                return NotFound();
            }
            return View(courseVM);
        }

        public async Task<IActionResult> Search(string text)
        {
            IEnumerable<CourseVM> courses = await _context.Courses.Where(c => c.IsDeleted == false
            && c.Name.ToLower().Contains(text.ToLower())
            || c.About.Contains(text.ToLower())
            || c.Description.Contains(text.ToLower())
            ).Take(5).Select(c => new CourseVM {
                Name = c.Name,
                Image = c.Image
            }).ToListAsync();

            return PartialView("_SearchCoursePartial",courses);
        }
    }
}
