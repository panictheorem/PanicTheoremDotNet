using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using panictheorem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class BlogModel
    {
        private int pageId;
        private int itemsPerPage = 10;

        public Section HeaderSection { get; set; }
        public Section MainSection { get; set; }
        public IEnumerable<BlogPost> BlogPosts{ get; set; }
        public IEnumerable<BlogPost> BlogPostsSubset { get; set; }
        [UIHint("Labels")]
        public IEnumerable<Label> Labels { get; set; }
        public Label SelectedLabel { get; set; }
        public int PageNumber { get; set; }
        public BlogPagingModel BlogPage { get; set; }

        //For Blog Index
        public BlogModel(IUnitOfWork unitOfWork)
        {
            pageId = (int)WebPages.Blog;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            BlogPosts = unitOfWork.BlogPostRepository.Rows.OrderByDescending(p => p.PostingDate).Take(10);
            Labels = unitOfWork.LabelRepository.Rows.ToList().ToList();
        }

        //For Labels
        public BlogModel(IUnitOfWork unitOfWork, string urlSegment, int pageNumber)
        {
            pageId = (int)WebPages.BlogArchive;
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            Labels = unitOfWork.LabelRepository.Rows.ToList();
            SelectedLabel = Labels.Where(l => l.UrlSegment.ToLower() == urlSegment.ToLower()).FirstOrDefault();
            BlogPage = PagingService.GetBlogPageListing(unitOfWork, "Labels", urlSegment, itemsPerPage, pageNumber);
        }
        //For Archive
        public BlogModel(IUnitOfWork unitOfWork, int pageNumber)
        {
            this.pageId = (int)WebPages.BlogArchive;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            BlogPage = PagingService.GetBlogPageListing(unitOfWork, "Archive", null, itemsPerPage, pageNumber);
            Labels = unitOfWork.LabelRepository.Rows.ToList();
        }
    }
}