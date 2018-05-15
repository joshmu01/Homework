using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Entities.Models
{
    public class ClassModel
    {
        public int? ClassId { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Description")]
        public string ClassDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ClassPrice { get; set; }

        [Display(Name = "Registered Students")]
        public List<UserModel> ClassUsers { get; set; }

        public ClassModel()
        {
            ClassUsers = new List<UserModel>();
        }
    }
}