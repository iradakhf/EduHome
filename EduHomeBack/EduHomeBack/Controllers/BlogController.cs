using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.BlogV;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
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

            BlogVM blogVM = new BlogVM
            {

                Blogs = await _context.Blogs.Where(b => b.IsDeleted == false).Include(e => e.Category).ToListAsync(),
                Categories = await _context.Categories.Include(c => c.Courses)
                 .Where(c => c.IsDeleted == false &&
                 c.Events.Any(e => e.CategoryId == c.Id)).ToListAsync(),
                Blog = await _context.Blogs.Include(b=>b.Comments).FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
                Tags = await _context.Tags.Where(t => t.IsDeleted == false).Include(c => c.BlogTags)
                .ThenInclude(t => t.Blog)
                 .Where(t => t.IsDeleted == false &&
                 t.BlogTags.Any(c => c.TagId == t.Id)).ToListAsync(),
            };

            if (blogVM == null)
            {
                return NotFound();
            }
            return View(blogVM);
        }
        public async Task<IActionResult> Search(string text)
        {
            if (text == null)
            {
                return View();
            }
            IEnumerable<BlogVM> blogs = await _context.Blogs.Where(b => b.IsDeleted == false
            && b.Title.ToLower().Contains(text.ToLower())
            || b.Description.Contains(text.ToLower())
            ).Take(5).Select(b => new BlogVM
            {
                Title = b.Title,
                Description = b.Description,
                Image = b.Image
            }).ToListAsync();


            return PartialView("_SearchBlogPartial", blogs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(string Subject, string Message, int? BlogId)
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
            if (BlogId == null)
            {
                return NotFound("could find");
            }
            Comment comnent = new Comment
            {
                AppUserId = user.Id,
                Name = user.Name,
                BlogId = BlogId,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Message = Message,
                Subject = Subject
            };
            _context.Comment.Add(comnent);
            _context.SaveChanges();
            IEnumerable<Blog> blogs = _context.Blogs
                .Include(b => b.Comments)
                .Where(b => b.Id == BlogId);
            return View();


        }

    }
}
