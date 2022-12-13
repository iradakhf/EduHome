using EduHomeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.ViewModels.BlogV
{
    public class BlogVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
        public Settings setting { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
 

        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


    }
}
