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
using panictheorem.Domain.Abstract;

namespace panictheorem.Areas.Admin.Controllers
{
    [Authorize]
    public class SocialMediaIconController : Controller
    {
        private IUnitOfWork unitOfWork;

        public SocialMediaIconController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.SocialMediaIconRepository.Rows.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaIcon socialmediaicon = unitOfWork.SocialMediaIconRepository.GetById(id);
            if (socialmediaicon == null)
            {
                return HttpNotFound();
            }
            return View(socialmediaicon);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SocialMediaIconId,ImageUrl,Link")] SocialMediaIcon socialmediaicon)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SocialMediaIconRepository.Add(socialmediaicon);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(socialmediaicon);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaIcon socialmediaicon = unitOfWork.SocialMediaIconRepository.GetById(id);
            if (socialmediaicon == null)
            {
                return HttpNotFound();
            }
            return View(socialmediaicon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SocialMediaIconId,ImageUrl,Link")] SocialMediaIcon socialmediaicon)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SocialMediaIconRepository.Update(socialmediaicon);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(socialmediaicon);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaIcon socialmediaicon = unitOfWork.SocialMediaIconRepository.GetById(id);
            if (socialmediaicon == null)
            {
                return HttpNotFound();
            }
            return View(socialmediaicon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMediaIcon socialmediaicon = unitOfWork.SocialMediaIconRepository.GetById(id);
            unitOfWork.SocialMediaIconRepository.Delete(socialmediaicon);
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
