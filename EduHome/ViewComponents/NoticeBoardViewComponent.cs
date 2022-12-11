using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NoticeBoardViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public NoticeBoardViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<NoticeBoard> noticeBoards = await _context.NoticeBoards.Where(n => n.IsDeleted == false).ToListAsync();
            if (noticeBoards == null && noticeBoards.Count() < 0)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(noticeBoards));
        }
    }
}
