using Charity.Context;
using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using Charity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services
{
    public class DonationService : IDonationService
    {
        #region injection dependency

        private readonly CharityContext _context;
        private readonly IInstitutionService _institutionService;

        public DonationService(CharityContext context, IInstitutionService institutionService)
        {
            _institutionService = institutionService;
            _context = context;
        }
        #endregion 



        public bool Create(DonationViewModel donation, List<string> categoriesId)
        {
            var model = new Donation(); 
            
            model.Institution = _institutionService.Get(donation.InstitutionId.ToString());
            model.PickUpTime = donation.PickUpDateOn.AddHours(donation.PickUpTimeOn.Hour).AddMinutes(donation.PickUpTimeOn.Hour);
            model.DonationId = Guid.NewGuid().ToString();
            model.City = donation.City;
            model.DonationQuantity = donation.DonationQuantity;
            model.PhoneNumber = donation.PhoneNumber;
            model.Street = donation.Street;
            model.ZipCode = donation.ZipCode;
            model.PickUpComment = donation.PickUpComment;
            model.User = donation.User;

            _context.Donations.Add(model);
            _context.SaveChanges();
            var donationsCategory = new List<DonationCategory>();
            foreach (var item in categoriesId)
            {
                donationsCategory.Add(new DonationCategory() {CategoryId = item, DonationId = model.DonationId, Id = Guid.NewGuid().ToString()} );
            }
            _context.AddRange(donationsCategory);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var donation = _context.Donations.SingleOrDefault(b => b.DonationId == id);
            if (donation == null)
                return false;

            _context.Donations.Remove(donation);
            return _context.SaveChanges() > 0;
        }

        public Donation Get(string id)
        {
            return _context.Donations.SingleOrDefault(b => b.DonationId == id);
        }

        public IList<Donation> GetAll()
        {
            var donation = _context.Donations
                .OrderByDescending(d => d.PickUpTime)
                .Include(d => d.DonationCategory)
                .ThenInclude(c => c.Category)
                .Include(d => d.Institution);
            return donation.ToList();
        }

        public bool Update(Donation donation)
        {
            _context.Donations.Update(donation);
            return _context.SaveChanges() > 0;
        }
        public int Sum()
        {
            return _context.Donations.Select(d => d.DonationQuantity).Sum();
        }
        public IList<Donation> GetDonations(string id)
        {
            var donations = _context.Donations
                .Where(d => d.User.Id == id)
                .OrderByDescending(d => d.PickUpTime)
                .Include(d => d.DonationCategory)
                    .ThenInclude(e => e.Category)
                .Include(d => d.Institution);
            return donations.ToList();
        }
    }
}
