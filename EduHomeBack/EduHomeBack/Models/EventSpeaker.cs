using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class EventSpeaker
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }

    }
}
