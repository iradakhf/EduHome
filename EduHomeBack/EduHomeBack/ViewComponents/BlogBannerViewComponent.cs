using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewComponents
{
    public class BlogBannerViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public BlogBannerViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Banner banner = await _context.Banners.FirstOrDefaultAsync(s => s.IsDeleted == false);

            if (banner == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(banner));
        }
    }
}

