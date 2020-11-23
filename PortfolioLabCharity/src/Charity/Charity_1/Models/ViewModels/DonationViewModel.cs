using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class DonationViewModel
    {
        public IList<Category> CategoriesList {get;set;}
        public Donation donation { get; set; }
        public IList <Institution> InstitutionsList { get; set; }
    }
}
