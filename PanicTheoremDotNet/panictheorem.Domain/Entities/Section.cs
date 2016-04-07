using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Section : IEntity
    {
        public int SectionId { get; set; }

        [Display(Name = "Web Page")]
        [Required(ErrorMessage = "You must specify a webpage for the section.")]
        public int WebPageId  { get; set; }

        [Display(Name = "Section Type")]
        [Required(ErrorMessage = "You must specify the type of the section.")]
        public int SectionType { get; set; }

        [StringLength(100, ErrorMessage = "This field cannot be more that 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "This field cannot be more that 500 characters")]
        public string Body { get; set; }

        [Display(Name = "Image URL")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string ImageUrl { get; set; }

        [Display(Name = "Button")]
        public int? ButtonId { get; set; }

        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }

        //Navigation Properties
        public virtual Button Button { get; set; }
    }

    public enum SectionType
    {
        Main,
        Content,
        Header
    }
}
