using System.ComponentModel.DataAnnotations;

namespace MySchool.Entities.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Please enter your user name.")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}