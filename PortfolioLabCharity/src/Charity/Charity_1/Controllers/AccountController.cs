using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using Charity.Services;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
    public class AccountController : Controller
    {
        #region dependency injection
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserManagerService _userManagerService;
        private readonly IDonationService _donationService;

        public AccountController(SignInManager<AspNetUser> signInManager, UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager, IUserManagerService userManagerService, IDonationService donationService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userManagerService = userManagerService;
            _donationService = donationService;
        }
        #endregion
        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.Title = "Rejestracja";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration([FromForm]RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_userManagerService.IsEmailUnique(model.Email))
                {
                    TempData["warning_email"] = "Ten adres email jest już zarejestrowany";
                    return View(model);
                }

                var user = new AspNetUser() 
                {
                    Email = model.Email, 
                    UserName = model.Email, 
                };
                user.NormalizedEmail = user.Email.ToUpper();
                user.NormalizedUserName = user.UserName.ToUpper();


                try
                {
                    var createUserResult = await _userManager.CreateAsync(user, model.Password);
                    if (createUserResult.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        TempData["warning_regerror"] = "Wystąpił błąd";
                        return View(model);
                    }

                }
                catch (Exception e)
                {
                    throw new Exception("Database exception");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Strona logowania";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userManagerService.GetUserByEmail(model.Email);
            if (user == null)
            {
                TempData["warning_email"] = "Nie odnaleziono adresu e-mail";
                return View(model);
            }

            await _signInManager.SignOutAsync();
            var login = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
            if (login.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["warning_password"] = "Podano nieprawidowe hasło";
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DonationList()
        {
            ViewBag.Title = "Lista darów";
            var model = _donationService.GetAll();
            return View(model);
        }

    }
}