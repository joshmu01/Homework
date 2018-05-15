using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Entities.Models
{
    public class UserModel
    {
        public int? UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }

        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Display(Name = "Admin Account?")]
        public bool UserIsAdmin { get; set; }

        [Display(Name = " Registered Classes")]
        public List<ClassModel> UserClasses { get; set; }

        public UserModel()
        {
            UserIsAdmin = false;
            UserClasses = new List<ClassModel>();
        }
    }
}