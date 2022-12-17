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
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;
        public SpeakerController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Speaker> speakers = await _appDbContext.Speakers
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(speakers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return View(speaker);
            }

            if (string.IsNullOrWhiteSpace(speaker.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View();
            }
           
            if (string.IsNullOrWhiteSpace(speaker.Surname))
            {
                ModelState.AddModelError("Surname", "the field can not be empty");
                return View();
            }
            
            if (speaker.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            if (!await _appDbContext.Speakers.AnyAsync(c => c.IsDeleted == false && c.PositionId == speaker.PositionId))
            {
                ModelState.AddModelError("Position", "Position is not correctly chosen");
                return View(speaker);
            }
            speaker.Image = speaker.File.CreateFile(_env, "img", "speaker");
            speaker.Name = speaker.Name.Trim();
            speaker.Surname = speaker.Surname.Trim();
            speaker.CreatedAt = DateTime.UtcNow.AddHours(4);
            speaker.CreatedBy = "System";
            await _appDbContext.Speakers.AddAsync(speaker);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Speaker speaker = await _appDbContext.Speakers.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (speaker == null)
            {
                return NotFound("speaker not found");
            }
            return View(speaker);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Speaker speaker)
        {

            if (!ModelState.IsValid)
            {
                return View(speaker);
            }

            if (speaker.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(speaker.Name))
            {
                ModelState.AddModelError("Name", "should not be empty");
                return View(speaker);
            }
            if (string.IsNullOrWhiteSpace(speaker.Surname))
            {
                ModelState.AddModelError("Surname", "should not be empty");
                return View(speaker);
            }
            if (string.IsNullOrWhiteSpace(speaker.Surname))
            {
                ModelState.AddModelError("Surname", "should not be empty");
                return View(speaker);
            }
            
            Speaker dbSpeaker = await _appDbContext.Speakers.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbSpeaker == null)
            {
                return NotFound("doesnt exist");
            }
            dbSpeaker.Name = speaker.Name;
            dbSpeaker.Surname = speaker.Surname;
            dbSpeaker.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbSpeaker.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
