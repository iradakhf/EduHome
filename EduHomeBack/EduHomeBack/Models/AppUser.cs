using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
