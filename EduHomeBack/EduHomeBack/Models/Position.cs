using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EduHomeBack.Models
{
    public class Position : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
    }
}
