using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheLearningCenter.Models
{
    public class ClassModel
    {
        public int? ClassId { get; set; }

        [Display(Name = "Name")]
        public string ClassName { get; set; }

        [Display(Name = "Description")]
        public string ClassDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ClassPrice { get; set; }

    }
}