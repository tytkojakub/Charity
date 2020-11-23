using Charity.Context;
using Charity.Models.DbModels;
using Charity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services
{
    public class CategoryService : ICategoryService
    {
        #region injection dependency

        private readonly CharityContext _context;
        public CategoryService(CharityContext context)
        {
            _context = context;
        }
        #endregion 



        public bool Create(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(b => b.CategoryId == id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }

        public Category Get(int id)
        {
            return _context.Categories.SingleOrDefault(b => b.CategoryId == id);
        }

        public IList<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public bool Update(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges() > 0;
        }
    }
}
