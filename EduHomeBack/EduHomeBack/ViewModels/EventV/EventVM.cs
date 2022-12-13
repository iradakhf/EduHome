using EduHomeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewModels.EventV
{
    public class EventVM
    {

        public IEnumerable<Blog> Blogs { get; set; }
        public Event Event { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public Settings setting { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


    }
}
