using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace panictheorem.Helpers
{
    public static class BlogArchive
    {
        public static IHtmlString MonthYearListing(this HtmlHelper helper, BlogModel model)
        {
            StringBuilder blogArchiveDates = new StringBuilder();
            DateTime currDate = model.BlogPage.BlogPosts.FirstOrDefault().PostingDate;
            TagBuilder dateHeader = new TagBuilder("div");
            dateHeader.MergeAttribute("class", "date-header title");
            dateHeader.SetInnerText(currDate.ToString("MMMM")+ " " + currDate.Year);
            blogArchiveDates.Append(dateHeader.ToString());
            foreach(var blogPost in model.BlogPage.BlogPosts)
            {
                if (blogPost.PostingDate.Month == currDate.Month && blogPost.PostingDate.Year == currDate.Year)
                {
                    blogArchiveDates.Append(helper.Partial("_BlogPostDetails", blogPost));
                }
                else
                {
                    currDate = blogPost.PostingDate;
                    dateHeader.SetInnerText(currDate.ToString("MMMM") + " " + currDate.Year);
                    blogArchiveDates.Append(dateHeader);
                    blogArchiveDates.Append(helper.Partial("_BlogPostDetails", blogPost));
                }
            }

            return MvcHtmlString.Create(blogArchiveDates.ToString());
        }
    }
}