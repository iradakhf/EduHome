using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Slider : BaseEntity
    {
        [StringLength(2000)]
        public string Title { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [StringLength(2000)]
        public string Image { get; set; }
        [StringLength(2000)]
        public string Link { get; set; }


    }
}
