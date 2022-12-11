using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels.TeacherV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<TeacherVM> teachers = await _context.Teachers
                .Where(a => a.IsDeleted == false)
                .Select(t=> new TeacherVM { 
                    Id = t.Id,
                  Image = t.Image,
                  Name = t.Name,
                  Profession = t.Profession,
                  Surname = t.Surname,
                  TwitterUrl = t.TwitterUrl,
                  FacebookUrl = t.FacebookUrl,
                  VUrl = t.VUrl,
                  PinterestUrl = t.PinterestUrl
                })
                .ToListAsync();

            if (teachers == null && teachers.Count() < 0)
            {
                return NotFound();
            }
            return View(teachers);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Teacher teacher = await _context.Teachers.Include(T=>T.TeacherSkills)
                .ThenInclude(t=>t.Skill)
                .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
    }
}
