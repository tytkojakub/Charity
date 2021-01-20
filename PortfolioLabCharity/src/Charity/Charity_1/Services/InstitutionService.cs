using Charity.Context;
using Charity.Models.DbModels;
using Charity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services
{
    public class InstitutionService : IInstitutionService
    {
        #region injection dependency

        private readonly CharityContext _context;
        public InstitutionService(CharityContext context)
        {
            _context = context;
        }
        #endregion 



        public bool Create(Institution institution)
        {
            _context.Institutions.Add(institution);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var institution = _context.Institutions.SingleOrDefault(b => b.InstitutionId == id);
            if (institution == null)
                return false;

            _context.Institutions.Remove(institution);
            return _context.SaveChanges() > 0;
        }

        public Institution Get(string id)
        {
            return _context.Institutions.SingleOrDefault(b => b.InstitutionId == id);
        }

        public IList<Institution> GetAll()
        {

            return _context.Institutions.ToList();
        }

        public bool Update(Institution institution)
        {
            _context.Institutions.Update(institution);
            return _context.SaveChanges() > 0;
        }
        public int InstitutionCount()
        {
            return _context.Institutions.Count();
        }


    }
}
