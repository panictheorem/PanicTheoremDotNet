using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Button : IEntity
    {
        public int ButtonId { get; set; }

        [Display(Name = "Project")]
        public int? ProjectId { get; set; }

        [Display(Name = "Button Text")]
        [Required(ErrorMessage = "You must specify text for the button.")]
        [StringLength(150, ErrorMessage = "This field cannot be more that 150 characters")]
        public string ButtonText { get; set; }

        [Required(ErrorMessage = "You must specify a link for the button.")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string Link { get; set; }

        [Display(Name = "Button Type")]
        public int ButtonType { get; set; }
    }

    public enum ButtonType
    {
        ProjectAccess,
        ProjectSource,
        Resume,
        Other
    }
}
