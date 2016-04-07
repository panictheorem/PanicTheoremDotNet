using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class BlogPost : IEntity
    {
        public BlogPost()
        {
            this.Labels = new HashSet<Label>();
        }
        public int BlogPostId { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "You must select an author.")]
        public int AuthorId { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "You add some content.")]
        public int BlogPostContentID { get; set; }

        [Display(Name = "Posting Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a date.")]
        public DateTime PostingDate { get; set; }

        [Required(ErrorMessage = "You must enter a title name.")]
        [StringLength(200, ErrorMessage = "This field cannot be more that 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must add content.")]
        public string Content { get; set; }

        [Display(Name = "URL Segement")]
        [Required(ErrorMessage = "You must specify a url segment.")]
        [RegularExpression("^[A-Za-z0-9-]*$", ErrorMessage = "URL Segments can only contain letters, numbers and dashes.")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string UrlSegment { get; set; }

        //Navigation Properties
        public virtual Author Author { get; set; }

        public virtual BlogPostContent BlogPostContent {get; set;}

        [UIHint("Labels")]
        public virtual ICollection<Label> Labels { get; set; }
    }
}
