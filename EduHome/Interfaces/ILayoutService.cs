using EduHome.Models;
using EduHome.ViewModels.CourseV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Interfaces
{
   public interface ILayoutService
    {
        Task<IDictionary<string, string>> GetSettings();
    }
}
