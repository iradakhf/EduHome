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
    public class AboutViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public AboutViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Settings> settings = await _context.Settings.Where(s => s.IsDeleted == false).ToListAsync();

            if (settings == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(settings));
        }
    }
}

