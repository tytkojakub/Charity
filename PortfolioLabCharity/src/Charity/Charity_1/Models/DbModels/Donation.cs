using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class Donation
    {
        public int DonationId { get; set; }
        public int DonationQuantity { get; set; }
        public IList<Category> Categories { get; set; }
        public Institution Institution { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpComment { get; set; }
    }
}
