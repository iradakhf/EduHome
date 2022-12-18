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
                 .ThenInclude(b => b.Tag)
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
            if (blog.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
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
            List<BlogTag> blogTags = new List<BlogTag>();
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
                BlogTag blogTag = new BlogTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    TagId = tagId
                };
                blogTags.Add(blogTag);
            }
            blog.BlogTags = blogTags;

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
            blog.BlogTags = blog.BlogTags;
            blog.Category = blog.Category;
            blog.IsDeleted = false;
            blog.CreatedAt = DateTime.UtcNow.AddHours(4);
            blog.CreatedBy = "System";
            await _appDbContext.Blogs.AddAsync(blog);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (id == null) return BadRequest("bad request");
            Blog blog  = await _appDbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound("not found");
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            if (id == null) return BadRequest("Bad Request");

            if (id != blog.Id) return NotFound("Not Found");

            Blog dbBlog = await _appDbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (dbBlog == null) return NotFound("Not Found");

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
            if (blog.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
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
            if (await _appDbContext.Blogs.AnyAsync(b => b.Title.ToLower().Trim() == b.Title.ToLower().Trim() && b.Id != blog.Id))
            {
                ModelState.AddModelError("Title", "Alreade Exists");
                return View();
            }
            if (blog.BlogTags != null && blog.BlogTags.Count() > 0)
            {

                List<BlogTag> blogTags = new List<BlogTag>();
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
                    BlogTag blogTag = new BlogTag
                    {
                        UpdatedAt = DateTime.UtcNow.AddHours(4),
                        UpdatedBy = "Me",
                        IsDeleted = false,
                        TagId = tagId
                    };
                    blogTags.Add(blogTag);
                }
                blog.BlogTags = blogTags;
            }
            if (blog.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            dbBlog.Image = blog.File.CreateFile(_env, "img", "blog");
            dbBlog.Title = blog.Title.Trim();
            dbBlog.Author = blog.Author.Trim();
            dbBlog.Date = blog.Date;
            dbBlog.Description = blog.Description.Trim();
            dbBlog.IsDeleted = false;
            dbBlog.CreatedAt = DateTime.UtcNow.AddHours(4);
            dbBlog.CreatedBy = "System";
            dbBlog.CategoryId = blog.CategoryId;
            dbBlog.BlogTags = blog.BlogTags;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {

            if (id == null) return BadRequest("bad request");

            Blog blog = await _appDbContext.Blogs
                .Include(c => c.BlogTags)
                .ThenInclude(c => c.Tag)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);

            if (blog == null) return NotFound("can not find");

            return View(blog);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Blog blog = await _appDbContext.Blogs
               .Include(c => c.BlogTags)
               .ThenInclude(b => b.Tag)
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (blog == null)
            {
                return NotFound("can not find blog with this id");
            }
      
            blog.IsDeleted = true;
            blog.DeletedAt = DateTime.UtcNow.AddHours(4);
            blog.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
