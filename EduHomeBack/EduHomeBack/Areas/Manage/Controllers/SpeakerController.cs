﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    public class SpeakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}