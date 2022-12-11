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

            return View();
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
