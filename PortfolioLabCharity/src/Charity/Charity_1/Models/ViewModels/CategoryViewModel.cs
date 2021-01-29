using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsChecked { get; set; }
    }
}
