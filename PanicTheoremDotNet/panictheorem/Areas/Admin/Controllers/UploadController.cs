using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Areas.Admin.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}