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
    public class ButtonController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ButtonController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(new ButtonListModel(unitOfWork));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonModel buttonModel = new ButtonModel(unitOfWork, id);
            if (buttonModel.Button == null)
            {
                return HttpNotFound();
            }
            return View(buttonModel);
        }

        public ActionResult Create()
        {

            ViewBag.ButtonTypes = Enum.GetValues(typeof(ButtonType)).Cast<ButtonType>().Select(b => new SelectListItem
            {
                Text = b.ToString(),
                Value = ((int)b).ToString()
            }).ToList();
            ViewBag.ProjectId = new SelectList(unitOfWork.ProjectRepository.Rows, "ProjectId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ButtonId,ProjectId,ButtonText,Link,ButtonType")] Button button)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ButtonRepository.Add(button);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(button);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonModel buttonModel = new ButtonModel(unitOfWork, id);
            if (buttonModel.Button == null)
            {
                return HttpNotFound();
            }

            return View(buttonModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ButtonId,ProjectId,ButtonText,Link,ButtonType")] Button button)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ButtonRepository.Update(button);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(button);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonModel buttonModel = new ButtonModel(unitOfWork, id);
            if (buttonModel.Button == null)
            {
                return HttpNotFound();
            }
            return View(buttonModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Button button = unitOfWork.ButtonRepository.GetById(id);
            unitOfWork.ButtonRepository.Delete(button);
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
