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

        [Range(1,100)]
        public int DonationQuantity { get; set; }
        
        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        public DateTime PickUpTime { get; set; }

        [StringLength(500)]
        public string PickUpComment { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }
        
        //Relationship
        public ICollection<DonationCategory> DonationCategory { get; set; }
        
        public AspNetUser User { get; set; }

        public Institution Institution { get; set; }
    }
}
