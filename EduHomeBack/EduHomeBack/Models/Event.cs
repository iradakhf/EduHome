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
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Image { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [StringLength(100)]
        [Required]
        public string Venue { get; set; }

        [StringLength(1000)]
        [Required]
        [MinLength(100)]
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

  
        public IEnumerable<EventTag> EventTags { get; set; }

        [NotMapped]
        public IEnumerable<int> TagIds { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        [NotMapped]
        public IEnumerable<EventSpeaker> EventSpeaker { get; set; }

    }
}
