using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Tag : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

    }
}
