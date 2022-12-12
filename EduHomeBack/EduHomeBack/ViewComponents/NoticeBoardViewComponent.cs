using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewComponents
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
           NoticeBoard noticeBoards = await _context.NoticeBoards.FirstOrDefaultAsync(n => n.IsDeleted == false);
            if (noticeBoards == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(noticeBoards));
        }
    }
}
