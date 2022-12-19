using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewModels.EventV;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        public EventController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                Event = await _context.Events.Include(e=>e.Comments).FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(string Subject, string Message, int? EventId)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View();
            };

            if (string.IsNullOrWhiteSpace(Subject))
            {
                ModelState.AddModelError("Subject", "required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(Message))
            {
                ModelState.AddModelError("Message", "required");
                return View();
            }
            if (EventId == null)
            {
                return NotFound("could find");
            }
            Comment comnent = new Comment
            {
                AppUserId = user.Id,
                Name = user.Name,
                EventId = EventId,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Message = Message,
                Subject = Subject
            };
            _context.Comment.Add(comnent);
            _context.SaveChanges();

            IEnumerable<Event> events = _context.Events
                .Include(b => b.Comments)
                .Where(b => b.Id == EventId);
            return View();


        }
    }
}
