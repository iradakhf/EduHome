using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]

    public class SkillController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public SkillController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Skill> skills = await _appDbContext.Skills
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(skills);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            if (string.IsNullOrWhiteSpace(skill.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Skills.AnyAsync(p => p.IsDeleted == false
            && p.Name.ToLower().Trim() == skill.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View();
            }

            skill.Name = skill.Name.Trim();
            skill.IsDeleted = false;
            skill.CreatedAt = DateTime.UtcNow.AddHours(4);
            skill.CreatedBy = "System";
            await _appDbContext.Skills.AddAsync(skill);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Skill skill = await _appDbContext.Skills.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (skill == null)
            {
                return NotFound("skill not found");
            }
            return View(skill);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Skill skill)
        {

            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            if (skill.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(skill.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(skill);
            }
            Skill dbSkill = await _appDbContext.Skills.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbSkill == null)
            {
                return NotFound("doesnt exist");
            }
            if (dbSkill.Name.Trim().ToLower() == skill.Name.Trim().ToLower())
            {
                ModelState.AddModelError("Name", "please enter another name");
                return View(skill);
            }
          
            if (await _appDbContext.Skills.AnyAsync(t => t.Id != id && t.Name.ToLower().Trim() == skill.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(dbSkill);
            }

            dbSkill.Name = skill.Name;
            dbSkill.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbSkill.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Skill skill = await _appDbContext.Skills
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (skill == null)
            {
                return NotFound("can not find skill with this id");
            }

            skill.IsDeleted = true;
            skill.DeletedAt = DateTime.UtcNow.AddHours(4);
            skill.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Add(int? id)
        {
            ViewBag.Teachers = await _appDbContext.Blogs.Where(c => c.IsDeleted == false).ToListAsync();
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Skill skill = await _appDbContext.Skills.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (skill == null)
            {
                return NotFound("skill not found");
            }
            return View(skill);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int? id, Skill skill)
        {
            ViewBag.Teachers = await _appDbContext.Blogs.Where(c => c.IsDeleted == false).ToListAsync();
            Skill dbskill = await _appDbContext.Skills.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbskill == null)
            {
                return NotFound("doesnt exist");
            }


            List<TeacherSkill> teacherSkills = new List<TeacherSkill>();

            if (skill.TeacherIds == null)
            {
                ModelState.AddModelError("TeacherIds", "the field is required");
                return View(skill);
            }
            foreach (int skillId in skill.TeacherIds)
            {
                if (skill.TeacherIds.Where(t => t == skillId).Count() > 1)
                {
                    ModelState.AddModelError("TeacherIds", "only one same teacher can be chosen");
                    return View(skill);
                }
                if (!await _appDbContext.Teachers.AnyAsync(t => t.Id == skillId))
                {
                    ModelState.AddModelError("TeacherIds", "Teacher is not correctly chosen");
                    return View(skillId);
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
            skill.TeacherSkills = teacherSkills;
            
            dbskill.TeacherSkills = skill.TeacherSkills;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
