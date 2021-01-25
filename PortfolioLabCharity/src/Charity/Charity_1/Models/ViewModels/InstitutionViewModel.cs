using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class InstitutionViewModel
    {
        public string InstitutionId { get; set; }
        public string InstitutionTitle { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

    }
}
