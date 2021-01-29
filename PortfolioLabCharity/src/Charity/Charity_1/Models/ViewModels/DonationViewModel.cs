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
        public List<InstitutionViewModel> InstitutionsList { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Musisz wybrać odbiorcę")]
        public int InstitutionId { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Wprowadź datę")]
        public DateTime PickUpDateOn { get; set; }

        [DataType(DataType.Time, ErrorMessage ="Wprowadź godzinę")]
        public DateTime PickUpTimeOn { get; set; }
        public AspNetUser User { get; set; }

        [StringLength(500, ErrorMessage = "Za długi komentarz")]
        public string PickUpComment { get; set; }

        [Required(ErrorMessage ="Podaj numer telefonu")]
        [StringLength(50, ErrorMessage = "Za długi numer")]
        public string PhoneNumber { get; set; }
        
        [Range(1, 100, ErrorMessage = "odbieramy od 1 do 100 worków")]
        public int DonationQuantity { get; set; }

        [Required(ErrorMessage = "Podaj ulicę")]
        [StringLength(150, ErrorMessage = "Za długa nazwa")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Podaj miasto")]
        [StringLength(50, ErrorMessage = "Za długa nazwa")]
        public string City { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [StringLength(10, ErrorMessage = "Za długa nazwa")]
        public string ZipCode { get; set; }
    }
}
