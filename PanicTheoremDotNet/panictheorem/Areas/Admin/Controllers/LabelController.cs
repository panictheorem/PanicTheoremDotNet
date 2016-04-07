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
    public class LabelController : Controller
    {
        private IUnitOfWork unitOfWork;

        public LabelController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.LabelRepository.Rows.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = unitOfWork.LabelRepository.GetById(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LabelId,Name,UrlSegment")] Label label)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LabelRepository.Add(label);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(label);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = unitOfWork.LabelRepository.GetById(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LabelId,Name,UrlSegment")] Label label)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LabelRepository.Update(label);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(label);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = unitOfWork.LabelRepository.GetById(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Label label = unitOfWork.LabelRepository.GetById(id);
            unitOfWork.LabelRepository.Delete(label);
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
