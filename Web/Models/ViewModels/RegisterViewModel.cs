using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "first cannot be empty")]
        [DisplayName("First Name")]
        public string? First_Name { get; set; }


        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last cannot be empty")]
        public string? Last_Name { get; set; }


        [Required(ErrorMessage = "Email message cannot be empty")]
        [EmailAddress]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Confirm Password cannot be empty")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password cannot be same")]
        public string? Confirm_Password { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string phonenumber { get; set; }




    }
}
