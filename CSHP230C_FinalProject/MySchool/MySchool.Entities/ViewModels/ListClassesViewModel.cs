using System.ComponentModel.DataAnnotations;

namespace MySchool.Entities.ViewModels
{
    public class ListClassesViewModel
    {
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Description")]
        public string ClassDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ClassPrice { get; set; }
    }
}