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
using Microsoft.AspNetCore.Authorization;

namespace EduHomeBack.Areas.Manage.Controllers
{

    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

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
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Teachers = await _appDbContext.Teachers.Where(c => c.IsDeleted == false).ToListAsync();
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
            if (course.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
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
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.CategoryId == course.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(course);
            }
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.TeacherId == course.TeacherId))
            {
                ModelState.AddModelError("TeacherId", "Teacher is not correctly chosen");
                return View(course);
            }
            if (course.TagIds==null)
            {
                ModelState.AddModelError("TagIds", "the field is required");
                return View(course);
            }
            List<CourseTag> courseTags = new List<CourseTag>();
            foreach (int tagId in course.TagIds)
            {
                if (course.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                    return View(course);
                }
                if (!await _appDbContext.Tags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                    return View(course);
                }
                CourseTag courseTag = new CourseTag
                {
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    CreatedBy = "Me",
                    IsDeleted = false,
                    TagId = tagId
                };
                courseTags.Add(courseTag);
            }
            course.CourseTags = courseTags;


            if (course.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }

            if (course.File.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (course.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
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
            course.CourseTags = course.CourseTags;
            course.TeacherId = course.TeacherId;
            course.CategoryId = course.CategoryId;
            await _appDbContext.Courses.AddAsync(course);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Teachers = await _appDbContext.Teachers.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (id == null) return BadRequest("bad request");
            Course course = await _appDbContext.Courses.FirstOrDefaultAsync(b => b.Id == id);
            if (course == null) return NotFound("not found");
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course)
        {
            ViewBag.Teachers = await _appDbContext.Teachers.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _appDbContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _appDbContext.Tags.Where(c => c.IsDeleted == false).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            if (id == null) return BadRequest("Bad Request");

            if (id != course.Id) return NotFound("Not Found");

            Course dbCourse = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCourse == null) return NotFound("Not Found");

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
            if (course.Description.Trim().Length < 80)
            {
                ModelState.AddModelError("Description", "the field should have more than 80 words");
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
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.CategoryId == course.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Categoriya is not correctly chosen");
                return View(course);
            }
            if (!await _appDbContext.Courses.AnyAsync(c => c.IsDeleted == false && c.TeacherId == course.TeacherId))
            {
                ModelState.AddModelError("TeacherId", "Teacher is not correctly chosen");
                return View(course);
            }
            if (course.CourseTags != null && course.CourseTags.Count() > 0)
            {

                List<CourseTag> courseTags = new List<CourseTag>();
                foreach (int tagId in course.TagIds)
                {
                    if (course.TagIds.Where(t => t == tagId).Count() > 1)
                    {
                        ModelState.AddModelError("TagIds", "only one same tag can be chosen");
                        return View(course);
                    }
                    if (!await _appDbContext.Tags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                    {
                        ModelState.AddModelError("TagIds", "Tag is not correctly chosen");
                        return View(course);
                    }
                    CourseTag courseTag = new CourseTag
                    {
                        UpdatedAt = DateTime.UtcNow.AddHours(4),
                        UpdatedBy = "Me",
                        IsDeleted = false,
                        TagId = tagId
                    };
                    courseTags.Add(courseTag);
                }

                course.CourseTags = courseTags;
            }

            if (course.File == null)
            {
                ModelState.AddModelError("File", "File is required");
                return View();
            }

            if (course.File.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("File", "file type should be jpeg or jpg");
                return View();
            }
            if (course.File.Length > 40000)
            {
                ModelState.AddModelError("File", "file length should be less than 40k");
                return View();
            }

            dbCourse.Image = course.File.CreateFile(_env, "img", "course");
            dbCourse.Name = course.Name.Trim();
            dbCourse.About = course.About.Trim();
            dbCourse.Assesments = course.Assesments.Trim();
            dbCourse.Certification = course.Certification.Trim();
            dbCourse.ClassDuration = course.ClassDuration.Trim();
            dbCourse.Description = course.Description.Trim();
            dbCourse.Duration = course.Duration.Trim();
            dbCourse.Fee = course.Fee;
            dbCourse.HowToApply = course.HowToApply.Trim();
            dbCourse.Language = course.Language.Trim();
            dbCourse.SkillLevel = course.SkillLevel.Trim();
            dbCourse.Starts = course.Starts;
            dbCourse.StudentsCount = course.StudentsCount;
            dbCourse.IsDeleted = false;
            dbCourse.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbCourse.UpdatedBy = "System";
            dbCourse.CourseTags = course.CourseTags;
            dbCourse.TeacherId = course.TeacherId;
            dbCourse.IsDeleted = false;
            dbCourse.CategoryId = course.CategoryId;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
          
            if (id == null) return BadRequest("bad request");

            Course course = await _appDbContext.Courses
                .Include(c => c.Category)
                .Include(e => e.CourseTags)
                .ThenInclude(c=>c.Tag)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted ==false);

            if (course == null) return NotFound("can not find");

            return View(course);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");
            IEnumerable<Course> courses = await _appDbContext.Courses.Where(b => b.IsDeleted == false).ToListAsync();
            if (courses.Count() < 7)
            {
                return RedirectToAction("Index");
            }
            Course course = await _appDbContext.Courses
               .Include(c => c.CourseTags)
               .ThenInclude(b => b.Tag)
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (course == null)
            {
                return NotFound("can not find course with this id");
            }
       
            course.IsDeleted = true;
            course.DeletedAt = DateTime.UtcNow.AddHours(4);
            course.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
