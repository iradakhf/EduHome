using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EduHomeBack.Models
{
    public class Speaker : BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Surname { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [NotMapped]
        public List<int> EventIds { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }

    }
}
