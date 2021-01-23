using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        //Relationships
        public ICollection<DonationCategory> DonationCategory { get; set; }
    }
}
