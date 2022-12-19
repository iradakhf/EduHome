using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.CourseV;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        public CourseController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                Course = await _context.Courses.Include(c=>c.Comments).FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(string Subject, string Message, int? CourseId)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View();
            };

            if (string.IsNullOrWhiteSpace(Subject))
            {
                ModelState.AddModelError("Subject", "required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(Message))
            {
                ModelState.AddModelError("Message", "required");
                return View();
            }
            if (CourseId == null)
            {
                return NotFound("could not find");
            }
            Comment comnent = new Comment
            {
                AppUserId = user.Id,
                Name = user.Name,
                CourseId = CourseId,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Message = Message,
                Subject = Subject
            };
            _context.Comment.Add(comnent);
            _context.SaveChanges();
            IEnumerable<Course> courses = _context.Courses
                .Include(b => b.Comments)
                .Where(b => b.Id == CourseId);
            return View();


        }
    }
}
