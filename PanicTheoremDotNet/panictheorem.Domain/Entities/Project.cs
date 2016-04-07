using panictheorem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Entities
{
    public class Project : IEntity
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "You must specify a project title.")]
        [StringLength(150, ErrorMessage = "This field cannot be more that 150 characters")]
        public string Title { get; set; }

        [StringLength(300, ErrorMessage = "This field cannot be more that 300 characters")]
        public string Subtitle { get; set; }

        [Display(Name = "Brief Description")]
        [Required(ErrorMessage = "You must give a brief description of the project.")]
        [StringLength(200, ErrorMessage = "This field cannot be more that 200 characters")]
        public string BriefDescription { get; set; }

        [Display(Name = "Detailed Description")]
        [Required(ErrorMessage = "You must give a detailed description of the project.")]
        [StringLength(400, ErrorMessage = "This field cannot be more that 400 characters")]
        public string DetailedDescription { get; set; }

        [Display(Name = "Project Details")]
        [Required(ErrorMessage = "You must specify the details of the project.")]
        [StringLength(2000, ErrorMessage = "This field cannot be more that 2000 characters")]
        public string ProjectDetails { get; set; }

        [Display(Name = "Design Details")]
        [Required(ErrorMessage = "You must describe the design details of the project.")]
        [StringLength(2000, ErrorMessage = "This field cannot be more that 2000 characters")]
        public string DesignDetails { get; set; }

        [Display(Name = "URL Segment")]
        [Required(ErrorMessage = "You must specify a url segment for the project.")]
        [RegularExpression("^[A-Za-z0-9-]*$", ErrorMessage = "URL Segments can only contain letters, numbers and dashes.")]
        [StringLength(100, ErrorMessage = "This field cannot be more that 100 characters")]
        public string UrlSegment { get; set; }

        [Display(Name = "Small Image URL")]
        [StringLength(100, ErrorMessage = "This field cannot be more that 100 characters")]
        public string SmallImageUrl { get; set; }

        [Display(Name = "Large Image Url")]
        [StringLength(100, ErrorMessage = "This field cannot be more that 100 characters")]
        public string LargeImageUrl { get; set; }

        [Display(Name = "Sort Order")]
        [Required(ErrorMessage = "You must specify a usort order.")]
        public int SortOrder { get; set; }

        //Navigation Properties
        public virtual List<Button> Buttons { get; set; }

        public List<Button> GetAccessButtons()
        {
            return Buttons.Where(o => o.ButtonType == (int)ButtonType.ProjectAccess).ToList();
        }

        public List<Button> GetSourceButtons()
        {
            return Buttons.Where(o => o.ButtonType == (int)ButtonType.ProjectSource).ToList();
        }
    }
}
