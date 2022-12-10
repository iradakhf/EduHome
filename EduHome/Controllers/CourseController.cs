using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
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
            IEnumerable<Course> courses = await _context.Courses.Where(c=>c.IsDeleted==false).ToListAsync();
            if (courses == null && courses.Count() < 0)
            {
                return BadRequest();
            }
            return View(courses);
        }
        public async Task<IActionResult> Detail(int? id)
        {

            return View();
        }
    }
}
