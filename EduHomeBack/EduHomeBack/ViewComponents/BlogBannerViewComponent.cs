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
            Settings setting = await _context.Settings.FirstOrDefaultAsync(s => s.IsDeleted == false && s.Key == "Banner");

            if (setting == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(setting));
        }
    }
}

