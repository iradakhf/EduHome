using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.EventV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            EventVM eventVM = new EventVM
            {
                Blogs = await _context.Blogs
                 .Where(b => b.IsDeleted == false).ToListAsync(),
                Events = await _context.Events.Where(b => b.IsDeleted == false).Include(e=>e.Category).ToListAsync(),
                Categories = await _context.Categories.Include(c=>c.Events)
                 .Where(c => c.IsDeleted == false && 
                 c.Events.Any(e=>e.CategoryId == c.Id)).ToListAsync(),
                Event = await _context.Events.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
                Tags = await _context.Tags.Where(t => t.IsDeleted == false)
                .Include(t => t.EventTags)
                .ThenInclude(t => t.Event)
                 .Where(t => t.IsDeleted == false &&
                 t.EventTags.Any(e => e.TagId == t.Id)).ToListAsync(),
          
            };

            if (eventVM == null)
            {
                return NotFound();
            }
            return View(eventVM);
        }
        public async Task<IActionResult> Search(string text)
        {
            if (text == null)
            {
                return View();
            }
            IEnumerable<EventVM> eventVMs = await _context.Events.Where(e => e.IsDeleted == false
            && e.Name.ToLower().Contains(text.ToLower())
            || e.Description.Contains(text.ToLower())
            ).Take(5).Select(e => new EventVM
            {
                Name = e.Name,
                Description = e.Description,
                Image = e.Image
            }).ToListAsync();


            return PartialView("_SearchEventPartial", eventVMs);
        }
    }
}
