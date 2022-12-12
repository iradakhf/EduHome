using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Tag : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

    }
}
