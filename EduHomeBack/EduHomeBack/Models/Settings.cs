using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EduHomeBack.Models
{
    public class Settings : BaseEntity
    {
        [StringLength(1000)]
        public string Key { get; set; }
        [StringLength(1000)]
        public string Value { get; set; }

    }
}
