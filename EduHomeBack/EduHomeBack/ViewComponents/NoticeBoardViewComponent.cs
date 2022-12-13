using EduHomeBack.DAL;
using EduHomeBack.Models;
using EduHomeBack.ViewComponentModel.NoticeArea;
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
            NoticeAreaVM noticeArea = new NoticeAreaVM
            {
                noticeBoards = await _context.NoticeBoards.Where(n => n.IsDeleted == false).ToListAsync(),
                videoTour = await _context.VideoTour.FirstOrDefaultAsync(v => v.IsDeleted == false)
            };
       
            if (noticeArea == null)
            {
                return View("Not Found");
            }
            return View(await Task.FromResult(noticeArea));
        }
    }
}
