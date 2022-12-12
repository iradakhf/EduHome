using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Skill : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
