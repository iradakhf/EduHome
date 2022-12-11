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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Blog> blogs = await _context.Blogs.Where(a => a.IsDeleted == false).ToListAsync();

            if (blogs == null && blogs.Count() < 0)
            {
                return NotFound();
            }
            return View(blogs);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
    }
}
