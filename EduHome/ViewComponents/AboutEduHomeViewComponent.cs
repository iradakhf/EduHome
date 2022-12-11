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
    public class AboutEduHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public AboutEduHomeViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<AboutEduHome> about = await _context.AboutEduHomes.Where(n => n.IsDeleted == false).ToListAsync();

            if (about == null && about.Count() < 0)
            {
                return View("Not Found");
            }
            return View(about);
        } 
    }
}
