using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class Donation
    {
        [Key]
        public string DonationId { get; set; }
        [Range(1,100,ErrorMessage ="odbieramy od 1 do 100 worków")]
        public int DonationQuantity { get; set; }
        
        [Required(ErrorMessage ="Podaj ulicę")]
        [StringLength(150,ErrorMessage ="Za długa nazwa")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Podaj miasto")]
        [StringLength(50, ErrorMessage = "Za długa nazwa")]
        public string City { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [StringLength(10, ErrorMessage = "Za długa nazwa")]
        public string ZipCode { get; set; }

        public DateTime PickUpTime { get; set; }

        [StringLength(500, ErrorMessage = "Za długi komentarz")]
        public string PickUpComment { get; set; }

        [StringLength(50, ErrorMessage = "Za długi numer")]
        public string PhoneNumber { get; set; }
        
        //Relationship
        public ICollection<DonationCategory> DonationCategory { get; set; }
        
        public AspNetUser User { get; set; }

        public Institution Institution { get; set; }
    }
}
