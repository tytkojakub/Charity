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
        [Required(ErrorMessage ="Uzupełnij pole")]
        [Display(Prompt = "podaj email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="błędny format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz podać hasło")]
        [Display(Prompt = "podaj hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
