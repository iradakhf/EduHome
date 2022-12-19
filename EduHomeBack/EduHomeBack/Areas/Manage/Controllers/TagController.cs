using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Authorization;
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

    public class TagController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TagController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _appDbContext.Tags
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            if (string.IsNullOrWhiteSpace(tag.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View();
            }
            if (await _appDbContext.Tags.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower().Trim() == tag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View();
            }

            tag.Name = tag.Name.Trim();
            tag.IsDeleted = false;
            tag.CreatedAt = DateTime.UtcNow.AddHours(4);
            tag.CreatedBy = "System";
            await _appDbContext.Tags.AddAsync(tag);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Tag tag = await _appDbContext.Tags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (tag == null)
            {
                return NotFound("tag not found");
            }
            return View(tag);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Tag tag)
        {

            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            if (tag.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(tag.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(tag);
            }
            Tag dbTag = await _appDbContext.Tags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbTag == null)
            {
                return NotFound("doesnt exist");
            }
            if (dbTag.Name.Trim().ToLower() == tag.Name.Trim().ToLower())
            {
                ModelState.AddModelError("Name", "please enter another name");
                return View(tag);
            }

            if (await _appDbContext.Tags.AnyAsync(t => t.Id != id && t.Name.ToLower().Trim()
            == tag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(dbTag);
            }
            dbTag.Name = tag.Name;
            dbTag.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbTag.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            Tag tag = await _appDbContext.Tags
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (tag == null)
            {
                return NotFound("can not find tag with this id");
            }
            tag.IsDeleted = true;
            tag.DeletedAt = DateTime.UtcNow.AddHours(4);
            tag.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Add(int? id)
        {
            ViewBag.Blogs = await _appDbContext.Blogs.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Events = await _appDbContext.Events.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Courses = await _appDbContext.Courses.Where(c => c.IsDeleted == false).ToListAsync();
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            Tag tag = await _appDbContext.Tags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (tag == null)
            {
                return NotFound("tag not found");
            }
            return View(tag);
      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int? id, Tag tag)
        {
            ViewBag.Blogs = await _appDbContext.Blogs.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Events = await _appDbContext.Events.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Courses = await _appDbContext.Courses.Where(c => c.IsDeleted == false).ToListAsync();
            Tag dbTag = await _appDbContext.Tags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbTag == null)
            {
                return NotFound("doesnt exist");
            }
         
           
                List<BlogTag> blogTags = new List<BlogTag>();
       
            if (tag.BlogIds == null)
            {
                ModelState.AddModelError("BlogIds", "the field is required");
                return View(tag);
            }
            foreach (int blogId in tag.BlogIds)
                {
                    if (tag.BlogIds.Where(t => t == blogId).Count() > 1)
                    {
                        ModelState.AddModelError("BlogIds", "only one same blog can be chosen");
                        return View(tag);
                    }
                    if (!await _appDbContext.Blogs.AnyAsync(t => t.Id == blogId))
                    {
                        ModelState.AddModelError("BlogIds", "Blog is not correctly chosen");
                        return View(tag);
                    }
                    BlogTag blogTag = new BlogTag
                    {
                        CreatedAt = DateTime.UtcNow.AddHours(4),
                        CreatedBy = "Me",
                        IsDeleted = false,
                        BlogId = blogId
                    };
                    blogTags.Add(blogTag);
                }
                tag.BlogTags = blogTags;

            
            List<EventTag> eventTags = new List<EventTag>();
            if (tag.EventIds ==null)
            {
                ModelState.AddModelError("EventIds", "the field is required");
                return View(tag);
            }
            foreach (int eventId in (tag.EventIds))
            {
                if (tag.EventIds.Where(t => t == eventId).Count() > 1)
                {
                    ModelState.AddModelError("BlogIds", "only one same blog can be chosen");
                    return View(tag);
                }
                if (!await _appDbContext.Events.AnyAsync(t => t.Id == eventId))
                {
                    ModelState.AddModelError("EventIds", "Event is not correctly chosen");
                    return View(tag);
                }
                EventTag eventTag = new EventTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    EventId = eventId
                };
           
                eventTags.Add(eventTag);
            }
            tag.EventTags = eventTags;
           
            List<CourseTag> courseTags = new List<CourseTag>();
            if (tag.CourseIds == null)
            {
                ModelState.AddModelError("CourseIds", "the field is required");
                return View(tag);
            }
            foreach (int courseId in tag.CourseIds)
            {
                if (tag.CourseIds.Where(t => t == courseId).Count() > 1)
                {
                    ModelState.AddModelError("CourseIds", "only one same blog can be chosen");
                    return View(tag);
                }
                if (!await _appDbContext.Courses.AnyAsync(t => t.Id == courseId))
                {
                    ModelState.AddModelError("CourseIds", "Course is not correctly chosen");
                    return View(tag);
                }
                CourseTag courseTag = new CourseTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    CourseId = courseId
                };
                courseTags.Add(courseTag);
            }
            tag.CourseTags = courseTags;

          

            dbTag.BlogTags = tag.BlogTags;
                dbTag.CourseTags = tag.CourseTags;
            dbTag.EventTags = tag.EventTags;
           
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
