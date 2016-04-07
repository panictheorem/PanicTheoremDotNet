using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class BlogPostContent
    {
        [Key]
        public int BlogPostContentId { get; set; }

        [Required(ErrorMessage = "You must add content.")]
        public string Content { get; set; }
    }
}
