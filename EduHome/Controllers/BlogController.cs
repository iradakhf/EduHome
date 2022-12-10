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
                return BadRequest();
            }
            return View(blogs);
        }

    }
}
