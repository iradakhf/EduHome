using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public BlogViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Blog> blogs = await _context.Blogs.Where(b => b.IsDeleted == false).ToListAsync();
            if (blogs == null && blogs.Count() < 0)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(blogs));
        }
       
    }
}
