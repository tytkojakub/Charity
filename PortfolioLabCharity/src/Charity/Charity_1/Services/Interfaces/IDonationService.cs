using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IDonationService
    {
        bool Create(Donation donation);
        Donation Get(int id);
        IList<Donation> GetAll();
        bool Update(Donation donation);
        bool Delete(int id);
        int Sum();
    }
}
