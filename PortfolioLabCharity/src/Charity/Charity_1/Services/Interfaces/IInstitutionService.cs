using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IInstitutionService
    {
        bool Create(Institution institution);
        Institution Get(int id);
        IList<Institution> GetAll();
        bool Update(Institution institution);
        bool Delete(int id);
        int InstitutionCount();
    }
}
