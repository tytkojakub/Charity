using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class DonationViewModel
    {
        public List<CategoryViewModel> CategoriesList {get;set;}
        public Donation Donation { get; set; }
        public List <InstitutionViewModel> InstitutionsList { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Musisz wybrać odbiorcę")]
        public int InstitutionId { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Wprowadź datę")]
        public DateTime PickUpDateOn { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Wprowadź godzinę")]
        public DateTime PickUpTimeOn { get; set; }
        public AspNetUser User { get; set; }
        public string PickUpComment { get; set; }
    }
}
