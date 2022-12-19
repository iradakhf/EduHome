using EduHomeBack.ViewModels.AccountV;
using EduHomeBack.DAL;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EduHomeBack.Controllers
{
   
        public class AccountController : Controller
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly AppDbContext _context;
            public AccountController(RoleManager<IdentityRole> roleManager,
                UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
            {
                _roleManager = roleManager;
                _userManager = userManager;
                _signInManager = signInManager;
                _context = context;
            }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = new AppUser
            {
                Name = register.Name + " " + register.Surname,
                Email = register.Email,
                UserName = register.UserName
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, "Member");

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == login.Email.ToUpper());

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, login.Password, true, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(login);
            }

            return RedirectToAction("Index", "Home");
        }

      

    }

}
