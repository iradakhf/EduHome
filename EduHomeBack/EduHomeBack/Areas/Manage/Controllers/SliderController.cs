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
            Slider slider = await _appDbContext.Sliders.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (slider == null)
            {
                return NotFound("slider not found");
            }
            return View(slider);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
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
           
            if (string.IsNullOrWhiteSpace(slider.Description))
            {
                ModelState.AddModelError("Description", "the field can not be empty");
                return View();
            }
            Slider dbslider = await _appDbContext.Sliders.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (dbslider == null)
            {
                return NotFound("doesnt exist");
            }
            if (dbslider.Title.Trim().ToLower() == slider.Title.Trim().ToLower())
            {
                ModelState.AddModelError("Title", "please enter another name");
                return View(slider);
            }

            if (await _appDbContext.Sliders.AnyAsync(t => t.Id != id && t.Title.ToLower().Trim() == slider.Title.ToLower().Trim()))
            {
                ModelState.AddModelError("Title", "Already Exists");
                return View(dbslider);
            }
            if (slider.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            if (slider.File.ContentType != "image/png")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (slider.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }

            if (slider.File != null)
            {
                DeleteFileHelper.DeleteFile(_env, dbslider.Image, "img", "banner");
                dbslider.Image = slider.File.CreateFile(_env, "img", "banner");
            }
       
            dbslider.Title = slider.Title.Trim();
            dbslider.Link = slider.Link.Trim();
            dbslider.Description = slider.Description.Trim();
            dbslider.IsDeleted = false;
            dbslider.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbslider.UpdatedBy = "System";
          
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");
            IEnumerable<Slider> sliders = await _appDbContext.Sliders.Where(b => b.IsDeleted == false).ToListAsync();
            if (sliders.Count() < 2)
            {
                return View();
            }
            Slider slider  = await _appDbContext.Sliders
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (slider == null)
            {
                return NotFound("can not find slider with this id");
            }

            slider.IsDeleted = true;
            slider.DeletedAt = DateTime.UtcNow.AddHours(4);
            slider.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
