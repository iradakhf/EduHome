using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Subscribe
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
