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
            Testimonial testimonial = await _context.Testimonials.Include(T=>T.Position).FirstOrDefaultAsync(n => n.IsDeleted == false);

            if (testimonial == null)
            {
                return View("Not Found");
            }

            return View(await Task.FromResult(testimonial));
        }

    }
}
