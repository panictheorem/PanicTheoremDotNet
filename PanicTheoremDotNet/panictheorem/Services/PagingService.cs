using panictheorem.Domain.Abstract;
using panictheorem.Domain.Entities;
using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Services
{
    public class PagingService
    {
        public static BlogPagingModel GetBlogPageListing(IUnitOfWork unitOfWork, string section, string urlSegment, int itemsPerPage, int page)
        {
            var allPosts = unitOfWork.BlogPostRepository.Rows.OrderByDescending(p => p.PostingDate).Where(b => b.Labels.Where(l => { if (urlSegment != null) { return l.UrlSegment.ToLower() == urlSegment.ToLower(); } return true; }).Count() > 0);
            int startingIndex = itemsPerPage * (page - 1);
            int numOfPages = 1;
            if (allPosts.Count() > 0)
            {
                numOfPages = (int)Math.Ceiling((double)(allPosts.Count()) / (double)itemsPerPage);
            }
            
            return new BlogPagingModel()
            {
                TotalNumberOfPages = numOfPages,
                CurrentPage = page,
                BlogPosts = allPosts.Skip(startingIndex).Take(itemsPerPage),
                PageSection = section,
                PageSubsection = urlSegment

            };
        }
    }
}