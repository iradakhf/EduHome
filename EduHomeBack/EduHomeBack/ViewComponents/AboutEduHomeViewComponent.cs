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
    public class AboutEduHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public AboutEduHomeViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           AboutEduHome about = await _context.AboutEduHomes.FirstOrDefaultAsync(n => n.IsDeleted == false);

            if (about == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(about));
        } 
    }
}
