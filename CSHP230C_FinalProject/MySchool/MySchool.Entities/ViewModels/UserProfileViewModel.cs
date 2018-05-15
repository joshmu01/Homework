using System.ComponentModel.DataAnnotations;

namespace MySchool.Entities.ViewModels
{
    public class UserProfileViewModel
    {
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}