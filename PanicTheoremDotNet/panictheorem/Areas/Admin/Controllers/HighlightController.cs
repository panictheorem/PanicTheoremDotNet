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
    public class HighlightController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HighlightController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.HighlightRepository.Rows.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Highlight highlight = unitOfWork.HighlightRepository.GetById(id);
            if (highlight == null)
            {
                return HttpNotFound();
            }
            return View(highlight);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HighlightId,Category,Heading,Body,ImageUrl")] Highlight highlight)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HighlightRepository.Add(highlight);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(highlight);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Highlight highlight = unitOfWork.HighlightRepository.GetById(id);
            if (highlight == null)
            {
                return HttpNotFound();
            }
            return View(highlight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HighlightId,Category,Heading,Body,ImageUrl")] Highlight highlight)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HighlightRepository.Update(highlight);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(highlight);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Highlight highlight = unitOfWork.HighlightRepository.GetById(id);
            if (highlight == null)
            {
                return HttpNotFound();
            }
            return View(highlight);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Highlight highlight = unitOfWork.HighlightRepository.GetById(id);
            unitOfWork.HighlightRepository.Delete(highlight);
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
