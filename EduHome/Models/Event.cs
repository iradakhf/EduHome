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

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


    }
}
