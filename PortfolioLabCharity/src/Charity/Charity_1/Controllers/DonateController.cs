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

namespace Charity.Mvc.Controllers
{
    public class DonateController : Controller
    {
        #region Dependency Injection
        private readonly IDonationService donationService;
        private readonly IInstitutionService institutionService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<AspNetUser> userManager;
        public DonateController(IDonationService donationService, IInstitutionService institutionService, ICategoryService categoryService, UserManager<AspNetUser> userManager)
        {
            this.donationService = donationService;
            this.institutionService = institutionService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }
        #endregion


        public IActionResult Index()
        {
            ViewBag.Title = "Przekaż dary";
            try
            {
                var listCategory = categoryService.GetAll();
                var listInstitution = institutionService.GetAll();
                DonationViewModel model = new DonationViewModel()
                {
                };
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
        [HttpPost] //do zapisywania danych z formularza.
        public IActionResult Index([FromForm] DonationViewModel model)
        {
            ViewBag.Title = "Przekazano dary";
            try
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
                    model.User = userManager.FindByIdAsync(userId).Result;
                }
                model.Donation.Institution = institutionService.Get(model.InstitutionId.ToString());
                model.Donation.PickUpTime = model.PickUpDateOn.AddHours(model.PickUpTimeOn.Hour).AddMinutes(model.PickUpTimeOn.Hour);
                donationService.Create(model.Donation, list);
            }
            catch (Exception e)
            {
                return View();
            }
            return   View("confirmation");
        }
        [Authorize]
        public IActionResult DonationsList()
        {
            ViewBag.Title = "Lista darów";

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var donation = donationService.GetDonations(userId);
            return View(donation);
        }

        
    }
}