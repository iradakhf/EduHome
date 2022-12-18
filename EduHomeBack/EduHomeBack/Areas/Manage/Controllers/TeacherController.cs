using EduHomeBack.DAL;
using EduHomeBack.Extension;
using EduHomeBack.Helper;
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
           
                if (teacher.TeacherSkills != null && teacher.TeacherSkills.Count() > 0)
            {
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
            }
            else
            {
                ModelState.AddModelError("SkillIds", "the field is required");
                return View(teacher);
            }
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

            if (teacher.File.ContentType != "image/png")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (teacher.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }


            teacher.Image = teacher.File.CreateFile(_env, "img", "teacher");
            teacher.Name = teacher.Name.Trim();
            teacher.About = teacher.About.Trim();
            teacher.Degree = teacher.Degree.Trim();
            teacher.Email = teacher.Email.Trim();
            teacher.Experience = teacher.Experience.Trim();
            teacher.FacebookUrl = teacher.FacebookUrl.Trim();
            teacher.Faculty = teacher.Faculty.Trim();
            teacher.Hobbies = teacher.Hobbies.Trim();
            teacher.TeacherSkills = teacher.TeacherSkills;
            teacher.PhoneNumber = teacher.PhoneNumber.Trim();
            teacher.PinterestUrl = teacher.PinterestUrl.Trim();
            teacher.Surname = teacher.Surname.Trim();
            teacher.TwitterUrl = teacher.TwitterUrl.Trim();
            teacher.VUrl = teacher.VUrl.Trim();
            teacher.PositionId = teacher.PositionId;
            teacher.IsDeleted = false;
            teacher.CreatedAt = DateTime.UtcNow.AddHours(4);
            teacher.CreatedBy = "System";
            await _appDbContext.Teachers.AddAsync(teacher);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Skills = await _appDbContext.Skills.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();

            if (id == null) return BadRequest("bad request");
            Teacher teacher = await _appDbContext.Teachers.FirstOrDefaultAsync(b => b.Id == id);
            if (teacher == null) return NotFound("not found");
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Teacher teacher)
        {
            ViewBag.Skills = await _appDbContext.Skills.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            if (id != teacher.Id) return NotFound("Not Found");

            Teacher dbTeacher = await _appDbContext.Teachers.FirstOrDefaultAsync(c => c.Id == id);

            if (dbTeacher == null) return NotFound("Not Found");
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
            if (teacher.TeacherSkills != null && teacher.TeacherSkills.Count() > 0)
            {

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
                        UpdatedAt = DateTime.UtcNow.AddHours(4),
                        UpdatedBy = "Me",
                        IsDeleted = false,
                        SkillId = skillId
                    };
                    teacherSkills.Add(teacherSkill);
                }
                teacher.TeacherSkills = teacherSkills;
            }
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

            if (teacher.File.ContentType != "image/png")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (teacher.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }

            if (teacher.File != null)
            {
                DeleteFileHelper.DeleteFile(_env, teacher.Image, "img", "teacher");
                dbTeacher.Image = teacher.File.CreateFile(_env, "img", "teacher");
            }
    
            dbTeacher.Name = teacher.Name.Trim();
            dbTeacher.About = teacher.About.Trim();
            dbTeacher.Degree = teacher.Degree.Trim();
            dbTeacher.Email = teacher.Email.Trim();
            dbTeacher.Experience = teacher.Experience.Trim();
            dbTeacher.FacebookUrl = teacher.FacebookUrl.Trim();
            dbTeacher.Faculty = teacher.Faculty.Trim();
            dbTeacher.Hobbies = teacher.Hobbies.Trim();
            dbTeacher.PhoneNumber = teacher.PhoneNumber.Trim();
            dbTeacher.PinterestUrl = teacher.PinterestUrl.Trim();
            dbTeacher.Surname = teacher.Surname.Trim();
            dbTeacher.TwitterUrl = teacher.TwitterUrl.Trim();
            dbTeacher.VUrl = teacher.VUrl.Trim();
            dbTeacher.PositionId = teacher.PositionId;
            dbTeacher.TeacherSkills = teacher.TeacherSkills;
            dbTeacher.IsDeleted = false;
            dbTeacher.CreatedAt = DateTime.UtcNow.AddHours(4);
            dbTeacher.CreatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int? id)
        {

            if (id == null) return BadRequest("bad request");

            Teacher teacher = await _appDbContext.Teachers
                .Include(c => c.Position)
                .Include(c => c.TeacherSkills)
                .ThenInclude(c=>c.Skill)
                .Include(t=>t.Courses)
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);

            if (teacher == null) return NotFound("can not find");

            return View(teacher);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Teacher teacher = await _appDbContext.Teachers
               .Include(c => c.TeacherSkills)
               .ThenInclude(b => b.Skill)
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
         
            if (teacher == null)
            {
                return NotFound("can not find teacher with this id");
            }
          
            teacher.IsDeleted = true;
            teacher.DeletedAt = DateTime.UtcNow.AddHours(4);
            teacher.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
