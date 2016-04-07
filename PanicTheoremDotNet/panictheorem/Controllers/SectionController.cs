using panictheorem.Domain.Entities;
using panictheorem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Controllers
{
    public class SectionController : Controller
    {
        public PartialViewResult MainSection(Section section, string functionName = "Main")
        {
            SectionModel sectionModel = new SectionModel
            {
                Section = section,
                FunctionName = functionName
            };
            return PartialView("_MainSection", sectionModel);
        }
	}
}