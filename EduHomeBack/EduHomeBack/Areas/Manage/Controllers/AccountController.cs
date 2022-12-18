using EduHomeBack.Areas.Manage.ViewModels.Account;
using EduHomeBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };
            if (await _userManager.Users.AnyAsync(u => u.NormalizedEmail == registerVM.Email.Trim().ToUpperInvariant()))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(registerVM);
            }
            if (await _userManager.Users.AnyAsync(u => u.NormalizedUserName == registerVM.UserName.Trim().ToUpperInvariant()))
            {
                ModelState.AddModelError("UserName", "Username already exists");
                return View(registerVM);
            }
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);

            }
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "email or password is wrong");
                return View(loginVM);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, loginVM.Password, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "email or password is wrong");
                return View(loginVM);
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "email or password is wrong");
                return View(loginVM);
            }

            await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberLater, true);
            return RedirectToAction("Index", "Dashboard", new { area = "manage" });

        }
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Email = "irade@gmail.com",
        //        Name = "Super",
        //        UserName = "SuperAdmin"

        //    };
        //    await _userManager.CreateAsync(appUser, "SuperAdmin123");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Ok();
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}
    }
}
