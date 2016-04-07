using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Controllers
{
    public class BlogController : Controller
    {
        private IUnitOfWork unitOfWork;

        public BlogController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        private BlogModel blogModel;

        public ActionResult Index()
        {
            blogModel = new BlogModel(unitOfWork);
            return View(blogModel);
        }

        public ActionResult BlogPost(string urlSegment)
        {
            BlogPostModel blogPostModel = new BlogPostModel(unitOfWork, urlSegment);
            if (blogPostModel.BlogPost == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(blogPostModel);
        }
        public ActionResult Archive(int pageNumber = 1)
        {
            blogModel = new BlogModel(unitOfWork, pageNumber);
            if(pageNumber < 1 || pageNumber > blogModel.BlogPage.TotalNumberOfPages)
            {
                throw new HttpException(404, "Page Not Found");
            }
            RouteData.Values.Remove("pageNumber");
            return View(blogModel);
        }
        public ActionResult Labels(string urlSegment, int pageNumber = 1)
        {
            blogModel = new BlogModel(unitOfWork, urlSegment, pageNumber);
            if (pageNumber < 1 ||
                pageNumber > blogModel.BlogPage.TotalNumberOfPages ||
                blogModel.Labels.Where(l => l.UrlSegment == urlSegment).Count() == 0)
            {
                throw new HttpException(404, "Page Not Found");
            }
            RouteData.Values.Remove("pageNumber");
            return View(blogModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}