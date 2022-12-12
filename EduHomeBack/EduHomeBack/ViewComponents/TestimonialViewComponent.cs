using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public TestimonialViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Testimonial> testimonials = await _context.Testimonials.Where(n => n.IsDeleted == false).ToListAsync();

            if (testimonials == null && testimonials.Count() < 0)
            {
                return View("Not Found");
            }

            return View(await Task.FromResult(testimonials));
        }

    }
}
