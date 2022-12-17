using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduHomeBack.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;

        private readonly IWebHostEnvironment _env;
        public CourseController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<Course> courses = await _appDbContext.Courses
                .Include(c => c.Category)
                .Include(c => c.Teacher)
                .Include(c => c.CourseTags)
                .ThenInclude(c => c.Tag)
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted==false).ToListAsync();
            ViewBag.Teachers = await _appDbContext.Teachers.Where(c => c.IsDeleted ==false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Teachers = await _appDbContext.Teachers.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            if (string.IsNullOrWhiteSpace(course.Name))
            {
                ModelState.AddModelError("Name", "the field can not be empty");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.About))
            {
                ModelState.AddModelError("About", "the field is required");
                return View(course);

            }
            if (string.IsNullOrWhiteSpace(course.Assesments))
            {
                ModelState.AddModelError("Assesments", "the field is required");
                return View(course);

            }
            if (string.IsNullOrWhiteSpace(course.Certification))
            {
                ModelState.AddModelError("Certification", "the field is required");
                return View(course);

            }
            if (string.IsNullOrWhiteSpace(course.ClassDuration))
            {
                ModelState.AddModelError("ClassDuration", "the field is required");
                return View(course);

            }
            if (string.IsNullOrWhiteSpace(course.Description))
            {
                ModelState.AddModelError("Description", "the field is required");
                return View(course);

            }
            if (string.IsNullOrWhiteSpace(course.Duration))
            {
                ModelState.AddModelError("Duration", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.Fee.ToString()))
            {
                ModelState.AddModelError("Fee", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.Language))
            {
                ModelState.AddModelError("Language", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.SkillLevel))
            {
                ModelState.AddModelError("SkillLevel", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.Starts.ToString()))
            {
                ModelState.AddModelError("Starts", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.HowToApply))
            {
                ModelState.AddModelError("HowToApply", "the field is required");
                return View(course);
            }
            if (string.IsNullOrWhiteSpace(course.StudentsCount.ToString()))
            {
                ModelState.AddModelError("StudentsCount", "the field is required");
                return View(course);
            }

            if (await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower().Trim() == course.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View(course);
            }
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted==false && c.CategoryId == course.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(course);
            }
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.TeacherId == course.TeacherId))
            {
                ModelState.AddModelError("TeacherId", "Teacher is not correctly chosen");
                return View(course);
            }
            foreach (int tagId in course.TagIds)
            {
                if (course.TagIds.Where(t => t== tagId).Count()>1)
                {
                    ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                    return View(course);
                }
                if (!await _appDbContext.Tags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                    return View(course);
                }
            }
           
            if (course.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }
            course.Image = course.File.CreateFile(_env, "img", "course");
            course.Name = course.Name.Trim();
            course.About = course.About.Trim();
            course.Assesments = course.Assesments.Trim();
            course.Certification = course.Certification.Trim();
            course.ClassDuration = course.ClassDuration.Trim();
            course.Description = course.Description.Trim();
            course.Duration = course.Duration.Trim();
            course.Fee = course.Fee;
            course.HowToApply = course.HowToApply.Trim();
            course.Language = course.Language.Trim();
            course.SkillLevel = course.SkillLevel.Trim();
            course.Starts = course.Starts;
            course.StudentsCount = course.StudentsCount;
            course.IsDeleted = false;
            course.CreatedAt = DateTime.UtcNow.AddHours(4);
            course.CreatedBy = "System";
            await _appDbContext.Courses.AddAsync(course);
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
