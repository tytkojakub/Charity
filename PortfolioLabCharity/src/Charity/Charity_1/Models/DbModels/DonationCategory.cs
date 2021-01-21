using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class DonationCategory
    {
        [Key]
        public string Id { get; set; }
        public string DonationId { get; set; }
        public string CategoryId { get; set; }
        //Relationships
        [ForeignKey("DonationId")]
        public Donation Donation { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
