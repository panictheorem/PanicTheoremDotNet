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
    public class ProjectController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ProjectController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.ProjectRepository.Rows.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="ProjectId,Title,Subtitle,ProjectDetails,DesignDetails,UrlSegment,BriefDescription,DetailedDescription,SmallImageUrl,LargeImageUrl,SortOrder")] Project project)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProjectRepository.Add(project);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="ProjectId,Title,Subtitle,ProjectDetails,DesignDetails,UrlSegment,BriefDescription,DetailedDescription,SmallImageUrl,LargeImageUrl,SortOrder")] Project project)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProjectRepository.Update(project);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = unitOfWork.ProjectRepository.GetById(id);
            unitOfWork.ProjectRepository.Delete(project);
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
