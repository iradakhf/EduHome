using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Image { get; set; }
        [StringLength(255)]
        public string Profession { get; set; }

        [StringLength(500)]
        public string About { get; set; }

        [StringLength(255)]
        public string Degree { get; set; }

        [StringLength(255)]
        public string Experience { get; set; }

        [StringLength(255)]
        public string Faculty { get; set; }

        [StringLength(255)]
        public string Hobbies { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Skype { get; set; }

        [StringLength(255)]
        public string FacebookUrl { get; set; }

        [StringLength(255)]
        public string PinterestUrl { get; set; }
        
        [StringLength(255)]
        public string VUrl { get; set; }

        [StringLength(255)]
        public string TwitterUrl { get; set; }

    }
}
