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
        public DonateController(IDonationService donationService, IInstitutionService institutionService, ICategoryService categoryService)
        {
            this.donationService = donationService;
            this.institutionService = institutionService;
            this.categoryService = categoryService;
        }
        #endregion

        public IActionResult Index()
        {
            ViewBag.Title = "Przekaż dary";
            try
            {
                var list = categoryService.GetAll();
                var list2 = institutionService.GetAll();
                DonationViewModel model = new DonationViewModel()
                {
                    CategoriesList = list,
                    InstitutionsList = list2
                };
                return View(model);
            }
            catch (Exception e) 
            {
                throw;
            }

        }
        [HttpPost] //do zapisywania danych z formularza.
        public IActionResult Index([FromForm] DonationPostViewModel model)
        {
            ViewBag.Title = "Przekazano dary";
            try
            {//mapowanie modelu
                IList<Category> listCategories = new List<Category>();
                foreach (var item in model.Categories)
                {
                    listCategories.Add(categoryService.Get(item));
                };

                Donation donation = new Donation()
                {
                    DonationQuantity = model.Bags,
                    Categories = listCategories,
                    Institution = institutionService.Get(model.Organization), 
                    Street = model.Street,
                    City = model.City,
                    ZipCode = model.PostCode,
                    PickUpTime = DateTime.Parse(model.Data + " " + model.Time),
                    PickUpComment = model.MoreInfo,
                    PhoneNumber = model.Phone               
                };
                donationService.Create(donation);
            }
            catch(Exception e)
            {
                return View();
            }
            return View("../Donate/confirmation");


        }
        [Authorize]
        public IActionResult DonationsList()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = donationService.GetDonations(userId);
            return View(model);
        }

        
    }
}