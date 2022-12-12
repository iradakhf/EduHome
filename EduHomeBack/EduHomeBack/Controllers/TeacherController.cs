using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHomeBack.Controllers
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
