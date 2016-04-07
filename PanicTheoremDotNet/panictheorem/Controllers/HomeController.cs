using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Abstract;
using panictheorem.Models;
using panictheorem.Domain.Entities;

namespace panictheorem.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            HomeModel model = new HomeModel(unitOfWork);
            return View(model);
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