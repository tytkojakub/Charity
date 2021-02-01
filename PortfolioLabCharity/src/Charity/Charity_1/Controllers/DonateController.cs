using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Charity.Models.ViewModels.DonationViewModel;
using System.Text.RegularExpressions;

namespace Charity.Mvc.Controllers
{
    public class DonateController : Controller
    {
        #region Dependency Injection
        private readonly IDonationService _donationService;
        private readonly IInstitutionService _institutionService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AspNetUser> _userManager;
        public DonateController(IDonationService donationService, IInstitutionService institutionService, ICategoryService categoryService, UserManager<AspNetUser> userManager)
        {
            this._donationService = donationService;
            this._institutionService = institutionService;
            this._categoryService = categoryService;
            this._userManager = userManager;
        }
        #endregion

        private List<string> _errors;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Przekaż dary";
            try
            {
                var listCategory = _categoryService.GetAll();
                var listInstitution = _institutionService.GetAll();
                DonationViewModel model = new DonationViewModel();
                model.CategoriesList = new List<CategoryViewModel>();
                foreach(var item in listCategory)
                {
                    model.CategoriesList.Add(new CategoryViewModel() { CategoryId = item.CategoryId, CategoryName = item.CategoryName});
                }
                model.InstitutionsList = new List<InstitutionViewModel>();
                foreach(var item in listInstitution)
                {
                    model.InstitutionsList.Add(new InstitutionViewModel() { InstitutionId = item.InstitutionId, InstitutionTitle = item.InstitutionTitle, Description = item.Description});
                }
                return View(model);
            }
            catch (Exception e) 
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult Index([FromForm] DonationViewModel model)
        {
            ViewBag.Title = "Przekazano dary";
            if (!ModelState.IsValid)
            {
                return View(model); 
            }
            if (IsModelValid(model, out _errors))
            {
                var list = new List<string>();
                foreach (var item in model.CategoriesList)
                {
                    if (item.IsChecked == true)
                    {
                        list.Add(item.CategoryId);
                    }
                }
                if (User.Identity.IsAuthenticated)
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    model.User = _userManager.FindByIdAsync(userId).Result;
                }
                
                _donationService.Create(model, list);
                return View("confirmation");
            }
            _errors.ForEach(e => ModelState.AddModelError("", e));
            return View(model);
        }

        [NonAction]
        private bool IsModelValid(DonationViewModel model, out List<string> errors)
        {
            errors = new List<string>();
            if (!model.CategoriesList.Any(c => c.IsChecked))
            {
                errors.Add("Zaznacz przynajmniej jedną kategorię");
            }
            if (model.PhoneNumber != null)
            {
                if (!IsPhoneNumberValid(model.PhoneNumber))
                {
                    errors.Add("Sprawdź numer telefonu. Dozwolone znaki: 0-9, '+- .'. Przykład: 0048.123 456 789");
                }
            }
            if (!(model.PickUpDateOn > DateTime.Now.AddDays(2)))
            {
                errors.Add("Wyznacz termin nie wcześniej niż za 3 dni");
            }
            return errors.Count == 0;
        }
        [NonAction]
        private bool IsPhoneNumberValid(string numberToCheck)
        {
            Regex regex = new Regex(pattern: @"^((00|\+)[1-9]\d)?[\- \.]?[1-9]\d{2}[\- \.]?\d{3}[\- \.]?\d{3}$");
            return regex.IsMatch(numberToCheck);
        }
    }
}