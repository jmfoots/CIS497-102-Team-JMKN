using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppName.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserManager { get; }

        private SignInManager<AppUser> SignInManager { get; }

        private RoleManager<AppRole> RoleManager { get; }

        public AccountController(UserManager<AppUser> UserManager, SignInManager<AppUser> SignInManager, RoleManager<AppRole> RoleManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            this.RoleManager = RoleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ToLogin()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginInfo)
        {
            if ((loginInfo.Email == null) || (loginInfo.Password == null))
            {
                ModelState.AddModelError(string.Empty, $"Email or Password incorrect.");
                return View("Login", loginInfo);
            }

            var result = await SignInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, $"Email or Password incorrect.");
                return View("Login", loginInfo);
            }

            //Created roles using this
            /*var role1 = new AppRole();
            role1.Name = "Administrator";
            await RoleManager.CreateAsync(role1);

            var role2 = new AppRole();
            role2.Name = "Supervisor";
            await RoleManager.CreateAsync(role2);*/
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /*public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User Already Registered";

                AppUser user = await UserManager.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser";
                    user.Email = "TestUser@example.com";
                    user.AccountDeleted = false;
                    user.PasswordChanged = true;

                    IdentityResult result = await UserManager.CreateAsync(user, "Testing123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }*/
    }
}