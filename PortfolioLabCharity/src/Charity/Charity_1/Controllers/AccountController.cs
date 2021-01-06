using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using Charity.Services.Interfaces;
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

        public AccountController(SignInManager<AspNetUser> signInManager, UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager, IUserManagerService userManagerService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userManagerService = userManagerService;
        }
        #endregion
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration([FromBody]RegistrationViewModel model)
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
    }
}