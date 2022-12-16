using EduHomeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewComponentModel.NoticeArea
{
    public class NoticeAreaVM
    {
       public IEnumerable<NoticeBoard> noticeBoards { get; set; }
        public IEnumerable<Settings> settings { get; set; }

    }
}
