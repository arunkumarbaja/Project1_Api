using System.ComponentModel.DataAnnotations;

namespace Project1.Models.ViewModels
{
    public class ChangePasswordViewModel
    {

        [Required(ErrorMessage = "error message cannot be empty")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email message cannot be empty")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Current Password cannot be empty")]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string Current_Password { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New Password cannot be null")]
        [DataType(DataType.Password)]
        public string? New_Password { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "Confirm new Password cannot be empty")]
        [DataType(DataType.Password)]
        [Compare("New_Password", ErrorMessage = "New Password and confirm new password cannot be diffrent")]
        public string? Confirm_New_Password { get; set; }

    }
}
