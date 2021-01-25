using Charity.Context;
using Charity.Models.DbModels;
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
        public DonationService(CharityContext context)
        {
            _context = context;
        }
        #endregion 



        public bool Create(Donation donation, List<string> categoriesId)
        {
            donation.DonationId = Guid.NewGuid().ToString();
            _context.Donations.Add(donation);
            _context.SaveChanges();
            var donationsCategory = new List<DonationCategory>();
            foreach (var item in categoriesId)
            {
                donationsCategory.Add(new DonationCategory() {CategoryId = item, DonationId = donation.DonationId, Id = Guid.NewGuid().ToString()} );
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
            return _context.Donations.ToList();
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
