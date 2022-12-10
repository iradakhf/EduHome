﻿using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Teacher> teachers = await _context.Teachers.Where(a => a.IsDeleted == false).ToListAsync();

            if (teachers == null && teachers.Count() < 0)
            {
                return BadRequest();
            }
            return View(teachers);
        }
    }
}
