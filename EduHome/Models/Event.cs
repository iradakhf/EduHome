using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EduHome.Models
{
    public class Event : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


    }
}
