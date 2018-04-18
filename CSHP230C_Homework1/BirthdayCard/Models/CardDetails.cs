using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirthdayCard.Models
{
    public class CardDetails
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string ToName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's name.")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's email address.")]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Please enter a birthday message.")]
        public string BirthdayMessage { get; set; }
    }
}