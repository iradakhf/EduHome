using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class NoticeBoard : BaseEntity
    {
        [StringLength(400)]
        public string VideoLink { get; set; }

        public DateTime Date { get; set; }

        [StringLength(400)]
        public string Text { get; set; }


    }
}
