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
    public class PortfolioController : Controller
    {
        private IUnitOfWork unitOfWork;
        private PortfolioModel portfolioModel;
        private ProjectModel projectModel;

        public PortfolioController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            portfolioModel = new PortfolioModel(unitOfWork);
            return View(portfolioModel);
        }

        public ActionResult Projects(string urlSegment)
        {
            projectModel = new ProjectModel(unitOfWork, urlSegment);
            if (projectModel.Project == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(projectModel);
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