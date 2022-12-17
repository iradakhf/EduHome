﻿using EduHomeBack.DAL;
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
            event1.Description = event1.Description.Trim();
            event1.IsDeleted = false;
            event1.CreatedAt = DateTime.UtcNow.AddHours(4);
            event1.CreatedBy = "System";
            await _appDbContext.Events.AddAsync(event1);
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
