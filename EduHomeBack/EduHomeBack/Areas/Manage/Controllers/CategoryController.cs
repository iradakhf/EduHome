using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _appDbContext.Categories
                .Include(c=>c.Blogs)
                .Include(c => c.Events)
                .Include(c => c.Courses)
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) {
                return View(category);
            }
            
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Categories.AnyAsync(c=>c.IsDeleted==false && c.Name.ToLower().Trim()==category.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View();
            }

            category.Name = category.Name.Trim();
            category.IsDeleted = false;
            category.CreatedAt = DateTime.UtcNow.AddHours(4);
            category.CreatedBy = "System";
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            } 
            Category category = await _appDbContext.Categories.FirstOrDefaultAsync(c=>c.IsDeleted==false && c.Id ==id);
            if (category == null)
            {
                return NotFound("category not found");
            }
                return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.Id != id)
            {
                return BadRequest("id can not be null");
            }
                if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(category);
            }
            Category dbCategory = await _appDbContext.Categories.FirstOrDefaultAsync(c =>c.IsDeleted==false && c.Id == id);

            if (dbCategory == null) {
                return NotFound("doesnt exist");
            }
            if (dbCategory.Name.Trim().ToLower()==category.Name.Trim().ToLower())
            {
                ModelState.AddModelError("Name", "please enter another name");
                return View(category);
            }

            if (await _appDbContext.Categories.AnyAsync(t => t.Id != id && t.Name.ToLower().Trim() 
            == category.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(dbCategory);
            }
            dbCategory.Name = category.Name;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbCategory.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Category category = await _appDbContext.Categories
               .Include(c => c.Blogs)
               .Include(c => c.Courses)
               .Include(c => c.Events)
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (category == null)
            {
                return NotFound("can not find category with this id");
            }
            if ((category.Blogs != null && category.Blogs.Count() > 0)
                || (category.Courses != null && category.Courses.Count() > 0)
                || (category.Events != null && category.Events.Count() > 0)
                || (category.Blogs != null && category.Blogs.Count() > 0))
            {
                TempData["Error"] = $"{id} li category siline bilmez";
                return RedirectToAction("Index");
            }
            else
            {
            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);
            category.DeletedBy = "System";

            }
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
