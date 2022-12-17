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
    public class NoticeBoardController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public NoticeBoardController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<NoticeBoard> noticeBoards = await _appDbContext.NoticeBoards
                .Where(c => c.IsDeleted == false).ToListAsync();

            return View(noticeBoards);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticeBoard noticeBoard)
        {
            if (!ModelState.IsValid)
            {
                return View(noticeBoard);
            }

            if (string.IsNullOrWhiteSpace(noticeBoard.Text))
            {
                ModelState.AddModelError("Text", "the field can not be empty");
                return View();
            }
            if (string.IsNullOrWhiteSpace(noticeBoard.Date.ToString()))
            {
                ModelState.AddModelError("Date", "the field can not be empty");
                return View();
            }
           

            noticeBoard.Text = noticeBoard.Text.Trim();
            noticeBoard.IsDeleted = false;
            noticeBoard.CreatedAt = DateTime.UtcNow.AddHours(4);
            noticeBoard.CreatedBy = "System";
            await _appDbContext.NoticeBoards.AddAsync(noticeBoard);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("id can not be null");
            }
            NoticeBoard notice = await _appDbContext.NoticeBoards.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (notice == null)
            {
                return NotFound("notice board not found");
            }
            return View(notice);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, NoticeBoard notice)
        {

            if (!ModelState.IsValid)
            {
                return View(notice);
            }

            if (notice.Id != id)
            {
                return BadRequest("id can not be null");
            }
            if (string.IsNullOrWhiteSpace(notice.Text))
            {
                ModelState.AddModelError("Text", "Bosluq Olmamalidir");
                return View(notice);
            }
            if (string.IsNullOrWhiteSpace(notice.Date.ToString()))
            {
                ModelState.AddModelError("Date", "Bosluq Olmamalidir");
                return View(notice);
            }
            NoticeBoard dbNotice = await _appDbContext.NoticeBoards.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);

            if (dbNotice == null)
            {
                return NotFound("doesnt exist");
            }
          
            dbNotice.Text = notice.Text;
            dbNotice.UpdatedAt = DateTime.UtcNow.AddHours(4);
            dbNotice.UpdatedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("id can not be null");

            NoticeBoard noticeBoard = await _appDbContext.NoticeBoards
               .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);
            if (noticeBoard == null)
            {
                return NotFound("can not find blog with this id");
            }

            noticeBoard.IsDeleted = true;
            noticeBoard.DeletedAt = DateTime.UtcNow.AddHours(4);
            noticeBoard.DeletedBy = "System";
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
