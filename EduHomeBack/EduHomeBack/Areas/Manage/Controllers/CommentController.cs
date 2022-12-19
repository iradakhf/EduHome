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
    [Area("Manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EventComments()
        {
            List<Comment> comments = _context.Comment.Include(c => c.AppUser)
                .Include(c => c.Event).Where(c => c.EventId != null).ToList();
            return View(comments);
        }

        public IActionResult CourseComments()
        {
            List<Comment> comments = _context.Comment
                .Include(c => c.AppUser).Include(c => c.Course)
                .Where(c => c.CourseId != null).ToList();
            return View(comments);
        }

        public IActionResult BlogComments()
        {
            List<Comment> comments = _context.Comment
                .Include(c => c.AppUser).Include(c => c.Blog)
                .Where(c => c.BlogId != null).ToList();
            return View(comments);
        }

        public IActionResult CommentInDetail(int? id)
        {
            if (id == null)
            {
                return BadRequest("bad request made");
            }
            Comment comment = _context.Comment.FirstOrDefault(c => c.Id == id);

            if (comment==null)
            {
                return NotFound("not found");
            }
            if (comment.EventId == null && comment.BlogId == null)
            {
                _context.SaveChanges();

                return RedirectToAction("CourseComments", "Comment");

            }
            if (comment.EventId == null && comment.CourseId == null)
            {
                _context.SaveChanges();

                return RedirectToAction("BlogComments", "Comment");
            }

            _context.SaveChanges();

            return RedirectToAction("EventComments", "Comment");



        }

    }
}
