using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.BlogV;
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
        public BlogController(AppDbContext context)
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

            BlogVM blogVM = new BlogVM
            {
           
                Blogs = await _context.Blogs.Where(b => b.IsDeleted == false).Include(e => e.Category).ToListAsync(),
                Categories = await _context.Categories.Include(c => c.Courses)
                 .Where(c => c.IsDeleted == false &&
                 c.Events.Any(e => e.CategoryId == c.Id)).ToListAsync(),
                Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
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
            if (text==null)
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
    }
}
