using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Controllers
{
    public class AboutController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AboutController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            AboutModel aboutModel = new AboutModel(unitOfWork);
            return View(aboutModel);
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