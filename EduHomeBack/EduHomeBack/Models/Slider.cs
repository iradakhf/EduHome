using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Slider : BaseEntity
    {
        [StringLength(2000)]
        [Required]
        public string Title { get; set; }
        [StringLength(2000)]
        [Required]
        public string Description { get; set; }
        [StringLength(2000)]
        public string Image { get; set; }
        [StringLength(2000)]
        [Required]
        public string Link { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }


    }
}
