using EduHomeBack.DAL;
using EduHomeBack.Extension;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _appDbContext;

        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Teacher> teachers = await _appDbContext.Teachers
                 .Include(b => b.TeacherSkills)
                 .ThenInclude(t=>t.Skill)
                 .Include(t=>t.Position)
                 .Where(c => c.IsDeleted == false).ToListAsync();

            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Skill = await _appDbContext.Teachers.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            ViewBag.Skill = await _appDbContext.Skills.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            if (string.IsNullOrWhiteSpace(teacher.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View(teacher);
            }
            if (string.IsNullOrWhiteSpace(teacher.About))
            {
                ModelState.AddModelError("About", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Degree))
            {
                ModelState.AddModelError("Degree", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Email))
            {
                ModelState.AddModelError("Email", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Experience))
            {
                ModelState.AddModelError("Experience", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.FacebookUrl))
            {
                ModelState.AddModelError("FacebookUrl", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Faculty))
            {
                ModelState.AddModelError("Faculty", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Hobbies))
            {
                ModelState.AddModelError("Hobbies", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.PinterestUrl))
            {
                ModelState.AddModelError("PinterestUrl", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Skype))
            {
                ModelState.AddModelError("Skype", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.Surname))
            {
                ModelState.AddModelError("Surname", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.TwitterUrl))
            {
                ModelState.AddModelError("TwitterUrl", "the field is required");
                return View(teacher);

            }
            if (string.IsNullOrWhiteSpace(teacher.VUrl))
            {
                ModelState.AddModelError("VUrl", "the field is required");
                return View(teacher);

            }
            List<TeacherSkill> teacherSkills = new List<TeacherSkill>();
            foreach (int skillId in teacher.SkillIds)
            {
                if (teacher.SkillIds.Where(t => t == skillId).Count() > 1)
                {
                    ModelState.AddModelError("SkillIds", "only one same skill can be chosen");
                    return View(teacher);
                }
                if (!await _appDbContext.Skills.AnyAsync(t => t.Id == skillId))
                {
                    ModelState.AddModelError("SkillId", "Skill is not correctly chosen");
                    return View(teacher);
                }
                TeacherSkill teacherSkill = new TeacherSkill
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    SkillId = skillId
                };
                teacherSkills.Add(teacherSkill);
            }
            teacher.TeacherSkills = teacherSkills;

            foreach (int positionId in teacher.PositionIds)
            {
                if (!await _appDbContext.Positions.AnyAsync(t => t.Id == positionId))
                {
                    ModelState.AddModelError("PositionId", "Position is not correctly chosen");
                    return View(teacher);
                }
            }
          
            if (teacher.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            teacher.Image = teacher.File.CreateFile(_env, "img", "event");
            teacher.Name = teacher.Name.Trim();
            teacher.About = teacher.About.Trim();
            teacher.Degree = teacher.Degree.Trim();
            teacher.Email = teacher.Email.Trim();
            teacher.Experience = teacher.Experience.Trim();
            teacher.FacebookUrl = teacher.FacebookUrl.Trim();
            teacher.Faculty = teacher.Faculty.Trim();
            teacher.Hobbies = teacher.Hobbies.Trim();
            teacher.PhoneNumber = teacher.PhoneNumber.Trim();
            teacher.PinterestUrl = teacher.PinterestUrl.Trim();
            teacher.Surname = teacher.Surname.Trim();
            teacher.TwitterUrl = teacher.TwitterUrl.Trim();
            teacher.VUrl = teacher.VUrl.Trim();
            teacher.PositionId = teacher.PositionId;
            teacher.SkillIds = teacher.SkillIds;
            teacher.IsDeleted = false;
            teacher.CreatedAt = DateTime.UtcNow.AddHours(4);
            teacher.CreatedBy = "System";
            await _appDbContext.Teachers.AddAsync(teacher);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest("id can not be null");
        //    }
        //    Category category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound("category not found");
        //    }
        //    return View(category);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, Category category)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(category);
        //    }

        //    if (category.Id != id)
        //    {
        //        return BadRequest("id can not be null");
        //    }
        //    if (string.IsNullOrWhiteSpace(category.Name))
        //    {
        //        ModelState.AddModelError("Name", "Bosluq Olmamalidir");
        //        return View(category);
        //    }
        //    Category dbCategory = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

        //    if (dbCategory == null)
        //    {
        //        return NotFound("doesnt exist");
        //    }
        //    if (dbCategory.Name.Trim().ToLower() == category.Name.Trim().ToLower())
        //    {
        //        ModelState.AddModelError("Name", "please enter another name");
        //        return View(category);
        //    }

        //    if (await _appDbContext.Categories.AnyAsync(t => t.Id != id && t.Name.ToLower().Trim() == category.Name.ToLower().Trim()))
        //    {
        //        ModelState.AddModelError("Name", "Already Exists");
        //        return View(dbCategory);
        //    }
        //    dbCategory.Name = category.Name;
        //    dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
        //    dbCategory.UpdatedBy = "System";
        //    await _appDbContext.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
