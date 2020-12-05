using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class DonationPostViewModel
    {
        public List<string> Categories { get; set; }
        public int Bags { get; set; }
        public string Organization { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Data { get; set; }
        public string Time { get; set; }
        public string MoreInfo { get; set; }

    }
}
