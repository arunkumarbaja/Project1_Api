using System.ComponentModel.DataAnnotations;

namespace Project1.Models.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email message cannot be empty")]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
