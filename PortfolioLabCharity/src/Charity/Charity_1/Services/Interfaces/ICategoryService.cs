using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface ICategoryService
    {
        bool Create(Category category);
        Category Get(int id);
        IList<Category> GetAll();
        bool Update(Category category);
        bool Delete(int id);
    }
}
