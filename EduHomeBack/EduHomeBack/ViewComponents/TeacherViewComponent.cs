using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.TeacherV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewComponents
{
    public class TeacherViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public TeacherViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<TeacherVM> teachers = await _context.Teachers.Include(t=>t.Position)
                .Where(a => a.IsDeleted == false)
                .Select(t => new TeacherVM
                {
                    Id = t.Id,
                    Image = t.Image,
                    Name = t.Name,
                    Surname = t.Surname,
                    TwitterUrl = t.TwitterUrl,
                    FacebookUrl = t.FacebookUrl,
                    VUrl = t.VUrl,
                    PinterestUrl = t.PinterestUrl
                })
                .ToListAsync();

            if (teachers == null && teachers.Count() < 0)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(teachers));
        }
    }
}
