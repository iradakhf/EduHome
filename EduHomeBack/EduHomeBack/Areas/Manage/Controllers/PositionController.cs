using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public PositionController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Position> positions = await _appDbContext.Positions
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(positions);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View(position);
            }

            if (string.IsNullOrWhiteSpace(position.Name))
            {
                ModelState.AddModelError("Position", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Positions.AnyAsync(p => p.IsDeleted == false && p.Name.ToLower().Trim() == position.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View();
            }

            position.Name = position.Name.Trim();
            position.IsDeleted = false;
            position.CreatedAt = DateTime.UtcNow.AddHours(4);
            position.CreatedBy = "System";
            await _appDbContext.Positions.AddAsync(position);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Position position = await _appDbContext.Positions.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (position == null)
            {
                return NotFound("position not found");
            }
            return View(position);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Position position)
        {

            if (!ModelState.IsValid)
            {
                return View(position);
            }

            if (position.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(position.Name))
            {
                ModelState.AddModelError("Position", "Bosluq Olmamalidir");
                return View(position);
            }
            Position dbPosition = await _appDbContext.Positions.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbPosition == null)
            {
                return NotFound("doesnt exist");
            }
            if (dbPosition.Name.Trim().ToLower() == position.Name.Trim().ToLower())
            {
                ModelState.AddModelError("Name", "please enter another name");
                return View(position);
            }

            if (await _appDbContext.Positions.AnyAsync(t => t.Id != id && t.Name.ToLower().Trim() == position.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(dbPosition);
            }
            dbPosition.Name = position.Name;
            dbPosition.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbPosition.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
