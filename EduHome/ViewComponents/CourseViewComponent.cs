using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels.CourseV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public CourseViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<CourseVM> CourseVMs = await _context.Courses.Where(c => c.IsDeleted == false)
                 .Select(c => new CourseVM
                 {
                     Name = c.Name,
                     Image = c.Image,
                     Description = c.Description,
                     Id = c.Id
                 }).ToListAsync();
            return View(await Task.FromResult(CourseVMs));
        }
    }
}
