using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class NoticeBoard : BaseEntity
    {
  

        public DateTime Date { get; set; }

        [StringLength(400)]
        public string Text { get; set; }


    }
}
