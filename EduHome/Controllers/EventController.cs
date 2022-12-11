using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
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
            IEnumerable<Event> events = await _context.Events.Where(c => c.IsDeleted == false).ToListAsync();
            if (events == null && events.Count() < 0)
            {
                return NotFound();
            }
            return View(events);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Event event1 = await _context.Events.FirstOrDefaultAsync(e => e.IsDeleted == false && e.Id == id);

            if (event1 == null)
            {
                return NotFound();
            }
            return View(event1);
        }

    }
}
