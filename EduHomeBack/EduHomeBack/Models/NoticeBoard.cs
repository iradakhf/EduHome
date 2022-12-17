using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class NoticeBoard : BaseEntity
    {
  

        [Required]
        public DateTime Date { get; set; }

        [StringLength(400)]
        [Required]
        public string Text { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
