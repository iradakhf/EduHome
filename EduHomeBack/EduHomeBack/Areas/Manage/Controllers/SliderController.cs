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
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _appDbContext.Sliders
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (string.IsNullOrWhiteSpace(slider.Title))
            {
                ModelState.AddModelError("Title", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Sliders.AnyAsync(p => p.IsDeleted == false
            && p.Title.ToLower().Trim() == slider.Title.ToLower().Trim()))
            {
                ModelState.AddModelError("Title", "Title already exists");
                return View();
            }
            if (string.IsNullOrWhiteSpace(slider.Description))
            {
                ModelState.AddModelError("Description", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Sliders.AnyAsync(p => p.IsDeleted == false
            && p.Description.ToLower().Trim() == slider.Description.ToLower().Trim()))
            {
                ModelState.AddModelError("Title", "Title already exists");
                return View();
            }
            if (slider.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            slider.Image = slider.File.CreateFile(_env, "img", "slider");
            slider.Title = slider.Title.Trim();
            slider.IsDeleted = false;
            slider.CreatedAt = DateTime.UtcNow.AddHours(4);
            slider.CreatedBy = "System";
            await _appDbContext.Sliders.AddAsync(slider);
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


    }
}
