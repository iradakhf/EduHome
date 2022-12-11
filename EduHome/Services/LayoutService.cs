using EduHome.DAL;
using EduHome.Interfaces;
using EduHome.Models;
using EduHome.ViewModels.CourseV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<string,string>> GetSettings()
        {
            return await _context.Settings.ToDictionaryAsync(s => s.Key, s=>s.Value);
        }
    }
}
