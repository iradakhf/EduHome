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
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;

        private readonly IWebHostEnvironment _env;
        public EventController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _appDbContext.Events
                 .Include(b => b.Category)
                 .Include(b => b.EventTags)
                 .ThenInclude(b => b.Tag)
                 .Where(c => c.IsDeleted == false).ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event event1)
        {
            ViewBag.Category = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(event1);
            }

            if (string.IsNullOrWhiteSpace(event1.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View(event1);
            }
            if (string.IsNullOrWhiteSpace(event1.Date.ToString()))
            {
                ModelState.AddModelError("Date", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.Description))
            {
                ModelState.AddModelError("Description", "the field is required");
                return View(event1);

            }
            if (event1.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
                return View(event1);
            }
            if (string.IsNullOrWhiteSpace(event1.EndTime.ToString()))
            {
                ModelState.AddModelError("EndTime", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.StartTime.ToString()))
            {
                ModelState.AddModelError("StartTime", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.Venue))
            {
                ModelState.AddModelError("Venue", "the field is required");
                return View(event1);

            }

            if (await _appDbContext.Events.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower()
            .Trim() == event1.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View(event1);
            }
            if (!await _appDbContext.Events.AnyAsync(c => c.IsDeleted == false && c.CategoryId == event1.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(event1);
            }
            List<EventTag> eventTags = new List<EventTag>();
            foreach (int tagId in event1.TagIds)
            {
                if (event1.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                    return View(event1);
                }
                if (!await _appDbContext.Tags.AnyAsync(t =>t.IsDeleted==false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                    return View(event1);
                }
                EventTag eventTag = new EventTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    TagId = tagId
                };
                eventTags.Add(eventTag);
            }
            event1.EventTags = eventTags;
            List<EventSpeaker> eventSpeakers = new List<EventSpeaker>();
            foreach (int speakerId in event1.SpeakerIds)
            {
                if (event1.SpeakerIds.Where(t => t == speakerId).Count() > 1)
                {
                    ModelState.AddModelError("SpeakerIds", "only one same tag can be chosen");
                    return View(event1);
                }
                if (!await _appDbContext.Speakers.AnyAsync(t => t.IsDeleted == false && t.Id == speakerId))
                {
                    ModelState.AddModelError("SpeakerIds", "SpeakerIds is not correctly chosen");
                    return View(event1);
                }
                EventSpeaker eventSpeaker = new EventSpeaker
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    SpeakerId = speakerId
                };
                eventSpeakers.Add(eventSpeaker);
            }
            event1.EventSpeakers = eventSpeakers;
            if (event1.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            event1.Image = event1.File.CreateFile(_env, "img", "event");
            event1.Name = event1.Name.Trim();
            event1.Venue = event1.Venue.Trim();
            event1.StartTime = event1.StartTime;
            event1.EndTime = event1.EndTime;
            event1.Category = event1.Category;
            event1.EventTags = event1.EventTags;
            event1.EventSpeakers = event1.EventSpeakers;
            event1.Description = event1.Description.Trim();
            event1.IsDeleted = false;
            event1.UpdatedAt = DateTime.UtcNow.AddHours(4);
            event1.UpdatedBy = "System";
            await _appDbContext.Events.AddAsync(event1);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (id == null) return BadRequest("bad request");
            Event event1 = await _appDbContext.Events.FirstOrDefaultAsync(b => b.Id == id);
            if (event1 == null) return NotFound("not found");
            return View(event1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Event event1)
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(event1);
            }

            if (id == null) return BadRequest("Bad Request");

            if (id != event1.Id) return NotFound("Not Found");

            Event dbEvent = await _appDbContext.Events.FirstOrDefaultAsync(b => b.Id == id);

            if (dbEvent == null) return NotFound("Not Found");

            if (string.IsNullOrWhiteSpace(event1.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View(event1);
            }
            if (string.IsNullOrWhiteSpace(event1.Date.ToString()))
            {
                ModelState.AddModelError("Date", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.Description))
            {
                ModelState.AddModelError("Description", "the field is required");
                return View(event1);

            }
            if (event1.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
                return View(event1);
            }
            if (string.IsNullOrWhiteSpace(event1.EndTime.ToString()))
            {
                ModelState.AddModelError("EndTime", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.StartTime.ToString()))
            {
                ModelState.AddModelError("StartTime", "the field is required");
                return View(event1);

            }
            if (string.IsNullOrWhiteSpace(event1.Venue))
            {
                ModelState.AddModelError("Venue", "the field is required");
                return View(event1);

            }

            if (await _appDbContext.Events.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower()
            .Trim() == event1.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View(event1);
            }
            if (!await _appDbContext.Events.AnyAsync(c => c.IsDeleted == false && c.CategoryId == event1.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(event1);
            }
            List<EventTag> eventTags = new List<EventTag>();
            foreach (int tagId in event1.TagIds)
            {
                if (event1.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                    return View(event1);
                }
                if (!await _appDbContext.Tags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                    return View(event1);
                }
                EventTag eventTag = new EventTag
                {
                   UpdatedAt = DateTime.UtcNow.AddHours(4),
                    UpdatedBy = "Me",
                    IsDeleted = false,
                    TagId = tagId
                };
                eventTags.Add(eventTag);
            }
            event1.EventTags = eventTags;
            List<EventSpeaker> eventSpeakers = new List<EventSpeaker>();
            foreach (int speakerId in event1.SpeakerIds)
            {
                if (event1.SpeakerIds.Where(t => t == speakerId).Count() > 1)
                {
                    ModelState.AddModelError("SpeakerIds", "only one same tag can be chosen");
                    return View(event1);
                }
                if (!await _appDbContext.Speakers.AnyAsync(t => t.IsDeleted == false && t.Id == speakerId))
                {
                    ModelState.AddModelError("SpeakerIds", "SpeakerIds is not correctly chosen");
                    return View(event1);
                }
                EventSpeaker eventSpeaker = new EventSpeaker
                {
                    UpdatedAt = DateTime.UtcNow.AddHours(4),
                    UpdatedBy = "Me",
                    IsDeleted = false,
                    SpeakerId = speakerId
                };
                eventSpeakers.Add(eventSpeaker);
            }
            event1.EventSpeakers = eventSpeakers;
            if (event1.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            dbEvent.Image = event1.File.CreateFile(_env, "img", "event");
            dbEvent.Name = event1.Name.Trim();
            dbEvent.Venue = event1.Venue.Trim();
            dbEvent.StartTime = event1.StartTime;
            dbEvent.EndTime = event1.EndTime;
            dbEvent.Category = event1.Category;
            dbEvent.EventTags = event1.EventTags;
            dbEvent.EventSpeakers = event1.EventSpeakers;
            dbEvent.Description = event1.Description.Trim();
            dbEvent.IsDeleted = false;
            dbEvent.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbEvent.UpdatedBy = "System";
            await _appDbContext.Events.AddAsync(dbEvent);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Event event1 = await _appDbContext.Events
               .Include(c => c.EventTags)
               .ThenInclude(b => b.Tag)
                 .Include(c => c.EventSpeakers)
               .ThenInclude(b => b.Speaker)
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (event1 == null)
            {
                return NotFound("can not find event with this id");
            }
            List<EventTag> eventTags = new List<EventTag>();
            foreach (int tagId in event1.TagIds)
            {

                if (event1.TagIds != null && event1.TagIds.Where(t => t == tagId).Count() > 0)
                {
                    EventTag eventTag = new EventTag
                    {
                        DeletedAt = DateTime.UtcNow.AddHours(4),
                        DeletedBy = "Me",
                        IsDeleted = true,
                    };
                    eventTags.Add(eventTag);
                }
            }
            List<EventSpeaker> eventSpeakers = new List<EventSpeaker>();
            foreach (int speakerId in event1.SpeakerIds)
            {

                if (event1.SpeakerIds != null && event1.SpeakerIds.Where(t => t == speakerId).Count() > 0)
                {
                    EventSpeaker eventSpeaker = new EventSpeaker
                    {
                        DeletedAt = DateTime.UtcNow.AddHours(4),
                        DeletedBy = "Me",
                        IsDeleted = true,
                    };
                    eventSpeakers.Add(eventSpeaker);
                }
            }
            event1.EventSpeakers = eventSpeakers;
            event1.EventTags = eventTags;
            event1.IsDeleted = true;
            event1.DeletedAt = DateTime.UtcNow.AddHours(4);
            event1.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
