using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage="You must provide your name."), Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide your email."), Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must include a message.")]
        public string Message { get; set; }
    }
}