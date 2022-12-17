using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHomeBack.Helper;
using Microsoft.AspNetCore.Hosting;
using EduHomeBack.Extension;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            Testimonial testimonial = await _appDbContext.Testimonials
                .FirstOrDefaultAsync(b => b.IsDeleted == false);
            return View(testimonial);
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();

            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Testimonial testimonial = await _appDbContext.Testimonials
                .Include(t=>t.Position)
                .FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);
            if (testimonial == null)
            {
                return NotFound("could not found");
            }
            return View(testimonial);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Testimonial testimonial)
        {
            ViewBag.Position = await _appDbContext.Positions.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }
            if (testimonial.Id != id)
            {
                return NotFound("banner not found");
            }

            Testimonial dbTestimonial = await _appDbContext.Testimonials
                .FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == testimonial.Id);

            if (dbTestimonial == null)
            {
                return NotFound("no banner exists like this");
            }

            if (string.IsNullOrWhiteSpace(testimonial.Author))
            {
                ModelState.AddModelError("Author", "can not submit white space");
                return View(dbTestimonial);
            }
            if (string.IsNullOrWhiteSpace(testimonial.Description))
            {
                ModelState.AddModelError("Description", "can not submit white space");
                return View(dbTestimonial);
            }
            foreach (int positionId in testimonial.PositionIds)
            {
                if (!await _appDbContext.Positions.AnyAsync(t =>t.IsDeleted==false && t.Id == positionId))
                {
                    ModelState.AddModelError("PositionId", "Position is not correctly chosen");
                    return View(testimonial);
                }
            }
           
            if (testimonial.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            if (testimonial.File.ContentType != "image/png")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (testimonial.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }

            if (testimonial.File != null)
            {
                DeleteFileHelper.DeleteFile(_env, dbTestimonial.Image, "img", "banner");
                dbTestimonial.Image = testimonial.File.CreateFile(_env, "img", "banner");
            }



            dbTestimonial.Author = testimonial.Author.Trim();
            dbTestimonial.Description = testimonial.Description.Trim();
            dbTestimonial.Image = testimonial.File.CreateFile(_env, "img", "event");
            dbTestimonial.PositionId = testimonial.PositionId;
            dbTestimonial.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbTestimonial.UpdatedBy = "System";

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
