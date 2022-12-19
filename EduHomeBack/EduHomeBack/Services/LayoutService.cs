using EduHomeBack.DAL;
using EduHomeBack.Interfaces;
using EduHomeBack.Models;
using EduHomeBack.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Services
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
