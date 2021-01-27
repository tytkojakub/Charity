using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage ="uzupełnij pole")]
        [Display(Prompt ="podaj hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage ="uzupełnij pole")]
        [Compare("Password")]
        [Display(Prompt = "powtórz hasło")]
        public string Password2 { get; set; }
    }
}
