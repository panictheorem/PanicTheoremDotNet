using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using panictheorem.Domain.Entities;
using panictheorem.Domain.Concrete;
using panictheorem.Areas.Admin.Models;
using panictheorem.Domain.Abstract;

namespace panictheorem.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private IUnitOfWork unitOfWork;

        public BlogController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var blogposts = unitOfWork.BlogPostRepository.Rows;
            return View(blogposts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogpost = unitOfWork.BlogPostRepository.GetById(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(unitOfWork.AuthorRepository.Rows, "AuthorId", "FullName");
            ViewBag.Labels = new SelectList(unitOfWork.LabelRepository.Rows, "LabelId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(BlogPostModel blogPostModel)
        {
            if (ModelState.IsValid)
            {
                blogPostModel.BlogPost.Labels = unitOfWork.LabelRepository.Rows.Where(l => blogPostModel.LabelList.Contains(l.LabelId)).ToList();
                unitOfWork.BlogPostRepository.Add(blogPostModel.BlogPost);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(blogPostModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostModel blogPostModel = new BlogPostModel(unitOfWork, id);
            if (blogPostModel.BlogPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(unitOfWork.AuthorRepository.Rows, "AuthorId", "FullName", blogPostModel.BlogPost.AuthorId);
            ViewBag.Labels = new SelectList(unitOfWork.LabelRepository.Rows, "LabelId", "Name", blogPostModel.BlogPost.Labels);
            return View(blogPostModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(BlogPostModel blogPostModel)
        {
            if (ModelState.IsValid)
            {
                blogPostModel.BlogPost.Labels = unitOfWork.LabelRepository.Rows.Where(l => blogPostModel.LabelList.Contains(l.LabelId)).ToList();
                unitOfWork.BlogPostRepository.Update(blogPostModel.BlogPost);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(blogPostModel.BlogPost);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogpost = unitOfWork.BlogPostRepository.GetById(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogpost = unitOfWork.BlogPostRepository.GetById(id);
            unitOfWork.BlogPostRepository.Delete(blogpost);
            unitOfWork.Commit();
            return RedirectToAction("Index");
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
