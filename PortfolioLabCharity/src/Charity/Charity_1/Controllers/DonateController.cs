using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using Charity.Services.Interfaces;
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

            var list = categoryService.GetAll();
            var list2 = institutionService.GetAll();
            DonationViewModel model = new DonationViewModel()
            {
                CategoriesList = list,
                InstitutionsList = list2
            };
            return View(model);

        }
        [HttpPost] //do zapisywania danych z formularza.
        public IActionResult Index([FromForm] DonationPostViewModel model)
        {
            try
            {//mapowanie modelu
                IList<Category> listCategories = new List<Category>();
                foreach (var item in model.Categories)
                {
                    listCategories.Add(categoryService.Get(int.Parse(item)));
                };

                Donation donation = new Donation()
                {
                    DonationQuantity = model.Bags,
                    Categories = listCategories,
                    Institution = institutionService.Get(int.Parse(model.Organization)), 
                    Street = model.Street,
                    City = model.City,
                    ZipCode = int.Parse(model.PostCode),
                    PickUpTime = DateTime.Parse(model.Data + " " + model.Time),
                    PickUpComment = model.MoreInfo
                };
                donationService.Create(donation);
            }
            catch(Exception e)
            {

                return View();
            }
            return View("../Donate/confirmation");


        }

        //// GET: Donate/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Donate/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Donate/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Donate/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Donate/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Donate/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Donate/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}