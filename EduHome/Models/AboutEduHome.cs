using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class AboutEduHome : BaseEntity
    {
        [StringLength(500)]
        public string Key { get; set; }
        [StringLength(500)]
        public string Value { get; set; }


    }
}
