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
    public class SectionController : Controller
    {
        private IUnitOfWork unitOfWork;

        public SectionController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.SectionRepository.Rows);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = unitOfWork.SectionRepository.GetById(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        public ActionResult Create()
        {
            return View(new SectionModel(unitOfWork));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="SectionId,WebPageId,SectionType,Title,Body,ImageUrl,ButtonId,SortOrder")] Section section)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SectionRepository.Add(section);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.ButtonId = new SelectList(unitOfWork.ButtonRepository.Rows, "ButtonId", "ButtonText", section.ButtonId);
            return View(section);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionModel sectionModel = new SectionModel(unitOfWork, id);
            if (sectionModel.Section == null)
            {
                return HttpNotFound();
            }
            return View(sectionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="SectionId,WebPageId,SectionType,Title,Body,ImageUrl,ButtonId,SortOrder")] Section section)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SectionRepository.Update(section);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ButtonId = new SelectList(unitOfWork.ButtonRepository.Rows, "ButtonId", "ButtonText", section.ButtonId);
            return View(section);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = unitOfWork.SectionRepository.GetById(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = unitOfWork.SectionRepository.GetById(id);
            unitOfWork.SectionRepository.Delete(section);
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
