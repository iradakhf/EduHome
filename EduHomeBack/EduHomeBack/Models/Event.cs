using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Event : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<EventTag> EventTags { get; set; }

        [NotMapped]
        public IEnumerable<int> TagIds { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
