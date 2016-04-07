using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using panictheorem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class BlogPostModel
    {
        private int pageId;

        public Section HeaderSection { get; set; }
        public BlogPost BlogPost { get; set; }

        public BlogPostModel(IUnitOfWork unitOfWork, string blogPostUrlSegment)
        {
            pageId = (int)WebPages.Blog;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            BlogPost = unitOfWork.BlogPostRepository.Rows.Where(b => b.UrlSegment.ToLower() == blogPostUrlSegment.ToLower()).FirstOrDefault();
        }
    }
}