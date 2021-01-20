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
        Category Get(string id);
        IList<Category> GetAll();
        bool Update(Category category);
        bool Delete(string id);
    }
}
