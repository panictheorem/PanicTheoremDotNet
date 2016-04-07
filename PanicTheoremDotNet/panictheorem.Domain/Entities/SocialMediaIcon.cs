using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class SocialMediaIcon : IEntity
    {
        public int SocialMediaIconId { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "You must specify a url for the social media icon.")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "You must specify a link for the social media icon.")]
        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string Link { get; set; }
    }
}
