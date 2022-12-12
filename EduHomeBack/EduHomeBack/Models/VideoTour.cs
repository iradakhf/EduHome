using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class VideoTour : BaseEntity
    {
        [StringLength(400)]
        public string VideoLink { get; set; }
    }
}
