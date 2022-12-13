using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduHomeBack.Models
{
    public class Speaker : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Image { get; set; }



        public int PositionId { get; set; }
        public Position Position { get; set; }

    }
}
