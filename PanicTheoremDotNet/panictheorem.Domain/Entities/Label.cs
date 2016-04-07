using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Label : IEntity
    {
        public Label()
        {
            BlogPosts = new HashSet<BlogPost>();
        }

        public int LabelId { get; set; }

        [Required(ErrorMessage = "You must specify a name for the label.")]
        [StringLength(50, ErrorMessage = "This field cannot be more that 50 characters")]
        public string Name { get; set; }

        [Display(Name = "URL Segment")]
        [Required(ErrorMessage = "You must specify a url segment for the label.")]
        [StringLength(100, ErrorMessage = "This field cannot be more that 100 characters")]
        public string UrlSegment { get; set; }

        //Navigation Properties
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
