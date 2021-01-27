using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Charity.Models;
using Charity.Services.Interfaces;
using Charity.Models.ViewModels;
using Charity_1.Models;

namespace Charity_1.Controllers
{
	public class HomeController : Controller
	{
		#region Dependency Injection
		private readonly IDonationService donationService;
		private readonly IInstitutionService institutionService;
		public HomeController(IDonationService donationService, IInstitutionService institutionService)
		{
			this.donationService = donationService;
			this.institutionService = institutionService;
		}
		#endregion

		public IActionResult Index()
		{
			ViewBag.Title = "Strona główna";
			HomeViewModel model = null;
			try
			{
				model = new HomeViewModel()
				{
					Sum = donationService.Sum(),
					Quantity = institutionService.InstitutionCount(),
					List = institutionService.GetAll()
				};
			}
			catch (Exception x) { }
			return View(model);
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { ErrorId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


	}
}
