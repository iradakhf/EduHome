﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class User : BaseEntity
    {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }
    }
}
