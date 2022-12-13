using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Email { get; set; }
        [StringLength(200)]
        public string Subject { get; set; }
        [StringLength(3000)]
        public string Message { get; set; }


    }
}
