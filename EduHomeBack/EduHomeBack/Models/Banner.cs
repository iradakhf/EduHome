using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Banner : BaseEntity
    {
        [StringLength(255)]
        [Required]
        public string Title { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
