using Charity.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class HomeViewModel
    {
        public IList<Institution> List { get; set; }
        public int Quantity { get; set; }
        public int Sum { get; set; }
    }
}
