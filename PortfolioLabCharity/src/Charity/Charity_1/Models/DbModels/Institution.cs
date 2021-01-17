using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class Institution
    {
        [Key]
        public int InstitutionId { get; set; }
        [StringLength(150)]
        public string InstitutionTitle { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        //Relationships
        public ICollection<Donation> Donations { get; set; }
    }
}
