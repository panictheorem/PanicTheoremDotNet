using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Author : IEntity
    {
        public int AuthorId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage="You must enter a first name.")]
        [StringLength(75, ErrorMessage = "This field cannot be more that 75 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter a last name.")]
        [StringLength(75, ErrorMessage = "This field cannot be more that 75 characters")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
