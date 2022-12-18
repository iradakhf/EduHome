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
    [Authorize(Roles = "SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public SettingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Settings> settings = await _appDbContext.Settings
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(settings);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Settings setting = await _appDbContext.Settings.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (setting == null)
            {
                return NotFound("setting not found");
            }
            return View(setting);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Settings settings)
        {

            if (!ModelState.IsValid)
            {
                return View(settings);
            }

            if (settings.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(settings.Key))
            {
                ModelState.AddModelError("Key", "Bosluq Olmamalidir");
                return View(settings);
            }
            if (string.IsNullOrWhiteSpace(settings.Value))
            {
                ModelState.AddModelError("Value", "Bosluq Olmamalidir");
                return View(settings);
            }
            Settings dbSettings = await _appDbContext.Settings.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbSettings == null)
            {
                return NotFound("doesnt exist");
            }
            if (dbSettings.Value.Trim().ToLower() == settings.Value.Trim().ToLower())
            {
                ModelState.AddModelError("Value", "please enter another value");
                return View(settings);
            }
            if (dbSettings.Key.Trim().ToLower() == settings.Key.Trim().ToLower())
            {
                ModelState.AddModelError("Key", "please enter another key");
                return View(settings);
            }
            if (await _appDbContext.Settings.AnyAsync(t => t.Id != id && t.Key.ToLower().Trim() == settings.Key.ToLower().Trim()))
            {
                ModelState.AddModelError("Key", "Already Exists");
                return View(dbSettings);
            }

            dbSettings.Key = settings.Key;
            dbSettings.Value = settings.Value;
            dbSettings.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbSettings.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
