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
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
    public async Task<IActionResult> Index()
    {
        IEnumerable<User> users = await _context.Users.Where(u=>u.IsDeleted==false).ToListAsync();

        return View();
    }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (await _context.Users.AnyAsync(u => u.Name.ToLower() == user.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View();
            }

            user.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest("Bad request");
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("Not Found");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (id == null) return BadRequest("bad request");

            if (id != user.Id) return NotFound("not found");

            User dbuse = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (dbuse == null) return NotFound();

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                ModelState.AddModelError("Name", "can not be empty");
                return View();
            }

            if (await _context.Users.AnyAsync(u => u.Name.ToLower() == user.Name.ToLower() && u.Id != user.Id))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View();
            }

            dbuse.Name = user.Name;
            dbuse.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbuse.UpdatedBy = "me";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("bad request");

            User dbuse = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (dbuse == null) return NotFound("not found");

            dbuse.IsDeleted = true;
            dbuse.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

          
            return View();
        }

    }




}
