using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class BlogPagingModel
    {
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public string PageSection { get; set; }
        public string PageSubsection { get; set; }
    }
}