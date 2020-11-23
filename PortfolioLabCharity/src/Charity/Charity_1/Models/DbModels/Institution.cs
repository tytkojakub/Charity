using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.DbModels
{
    public class Institution
    {
        [Required]
        public int InstitutionId { get; set; }
        [Required]
        public string InstitutionTitle { get; set; }
        public string Description { get; set; }
    }
}
