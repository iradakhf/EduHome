using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHomeBack.Models
{
    public class Testimonial : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Author { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }


    }
}
