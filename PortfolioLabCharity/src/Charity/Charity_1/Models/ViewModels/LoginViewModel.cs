using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Prompt = "podaj email")]
        public string Email { get; set; }
        [Required]
        [Display(Prompt = "podaj hasło")]
        public string Password { get; set; }
    }
}
