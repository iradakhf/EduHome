using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class AboutEduHome : BaseEntity
    {
        [StringLength(80)]
        public string Image { get; set; }

        [StringLength(800)]
        public string Text { get; set; }
        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Link { get; set; }

    }
}
