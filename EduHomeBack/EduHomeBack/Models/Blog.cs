using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Blog : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
