using System;

namespace Charity_1.Models
{
    public class ErrorViewModel
    {
        public string ErrorId { get; set; }

        public bool ShowErrorId => !string.IsNullOrEmpty(ErrorId);
    }
}