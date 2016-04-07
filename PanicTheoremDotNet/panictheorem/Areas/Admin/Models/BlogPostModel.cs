using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Areas.Admin.Models
{
    public class BlogPostModel
    {
        public BlogPost BlogPost { get; set; }

        [Required(ErrorMessage = "You must specify one or more labels.")]
        public ICollection<int> LabelList { get; set; }


        public BlogPostModel()
        {

        }

        public BlogPostModel(IUnitOfWork unitOfWork, int? id)
        {
            BlogPost = unitOfWork.BlogPostRepository.GetById(id);
        }
    }
}