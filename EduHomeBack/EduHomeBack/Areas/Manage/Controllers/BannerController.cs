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
    public class BannerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public BannerController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            Banner banner = await _appDbContext.Banners.FirstOrDefaultAsync(b => b.IsDeleted == false);
            return View(banner);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Banner banner = await _appDbContext.Banners.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);
            if (banner == null)
            {
                return NotFound("could not found");
            }
            return View(banner);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View(banner);
            }
            if (banner.Id != id)
            {
                return NotFound("banner not found");
            } 

            Banner dbBanner = await _appDbContext.Banners.FirstOrDefaultAsync(b => b.IsDeleted==false && b.Id == banner.Id);

            if (dbBanner == null)
            {
                return NotFound("no banner exists like this");
            }

            if (string.IsNullOrWhiteSpace(banner.Title))
            {
                ModelState.AddModelError("Title", "can not submit white space");
                return View(dbBanner);
            }
            if (banner.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            if (banner.File.ContentType != "image/png")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (banner.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }

            if (banner.File != null)
            {
                DeleteFileHelper.DeleteFile(_env, dbBanner.Image, "img", "banner");
                dbBanner.Image = banner.File.CreateFile(_env, "img", "banner");
            }

           

            dbBanner.Title = banner.Title.Trim();
            dbBanner.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbBanner.UpdatedBy = "System";

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
