using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using TheLearningCenter.Database;

namespace TheLearningCenter.Models
{
    public class UserModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }
        public List<ClassModel> UserClasses { get; set; }

        public UserModel()
        {
            UserClasses = new List<ClassModel>();
        }
    }
}