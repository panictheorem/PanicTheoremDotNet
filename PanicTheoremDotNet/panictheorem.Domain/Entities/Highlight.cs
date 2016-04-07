using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Highlight : IEntity
    {
        public int HighlightId { get; set; }

        [StringLength(50, ErrorMessage = "This field cannot be more that 50 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "You must add a heading for the highlight.")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "You must add a body to the highlight.")]
        [StringLength(500, ErrorMessage = "This field cannot be more that 500 characters")]
        public string Body { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "You must specify an image url for the highlight.")]
        [StringLength(150, ErrorMessage = "This field cannot be more that 150 characters")]
        public string ImageUrl { get; set; }
    }
}
