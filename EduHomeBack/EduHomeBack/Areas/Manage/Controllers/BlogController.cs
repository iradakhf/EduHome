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
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _appDbContext.Blogs
                 .Include(b => b.Category)
                 .Include(b => b.BlogTags)
                 .ThenInclude(b=>b.Tag)
                 .Where(b => b.IsDeleted == false).ToListAsync();

            return View(blogs);
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
        public async Task<IActionResult> Create(Blog blog)
        {
            ViewBag.Category = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            if (string.IsNullOrWhiteSpace(blog.Title))
            {
                ModelState.AddModelError("Title", "the field can not be empty");
                return View(blog);
            }
            if (string.IsNullOrWhiteSpace(blog.Author))
            {
                ModelState.AddModelError("Author", "the field can not be empty");
                return View(blog);
            }
            if (string.IsNullOrWhiteSpace(blog.Date.ToString()))
            {
                ModelState.AddModelError("Date", "the field is required");
                return View(blog);

            }
            if (string.IsNullOrWhiteSpace(blog.Description))
            {
                ModelState.AddModelError("Description", "the field is required");
                return View(blog);

            }
            if (await _appDbContext.Blogs.AnyAsync(b => b.IsDeleted == false && b.Title.ToLower().Trim() == blog.Title.ToLower().Trim()))
            {
                ModelState.AddModelError("Title", "Title already exists");
                return View(blog);
            }
            if (!await _appDbContext.Blogs.AnyAsync(b => b.IsDeleted == false && b.CategoryId == blog.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(blog);
            }
            foreach (int tagId in blog.TagIds)
            {
                if (blog.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                    return View(blog);
                }
                if (!await _appDbContext.Tags.AnyAsync(t => t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                    return View(blog);
                }
            }
            if (blog.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            blog.Image = blog.File.CreateFile(_env, "img", "blog");
            blog.Title = blog.Title.Trim();
            blog.Author = blog.Author.Trim();
            blog.Date = blog.Date;
            blog.Description = blog.Description.Trim();
            blog.IsDeleted = false;
            blog.CreatedAt = DateTime.UtcNow.AddHours(4);
            blog.CreatedBy = "System";
            await _appDbContext.Blogs.AddAsync(blog);
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
