using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="email  cannot be empty")]
        public string?  Email { get; set; }

        [Required (ErrorMessage ="Password cannot be empty")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DisplayName("Remember Me")]   
        public bool RememberMe { get; set; }    


    }
}
