using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EduHome.Models
{
    public class Course : BaseEntity
    {
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string About { get; set; }

        [StringLength(1000)]
        public string HowToApply { get; set; }

        [StringLength(1000)]
        public string Certification { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? FeatureId { get; set; }
        public Feature Feature { get; set; }

    }
}
