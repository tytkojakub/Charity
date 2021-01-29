using Charity.Models.DbModels;
using Charity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IDonationService
    {
        bool Create(DonationViewModel donation, List<string> categoriesId);
        Donation Get(string id);
        IList<Donation> GetAll();
        bool Update(Donation donation);
        bool Delete(string id);
        int Sum();
        IList<Donation> GetDonations(string id);



    }
}
