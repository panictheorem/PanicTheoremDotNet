using panictheorem.Attributes;
using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Models;
using panictheorem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Controllers
{
    public class ContactController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ContactController(IUnitOfWork iUnitOfWork)
        {
            unitOfWork = new UnitOfWork();
        }

        private ContactModel contactModel;

        public ActionResult Index()
        {
            contactModel = new ContactModel(unitOfWork);
            return View(contactModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidationAttribute]
        public async Task<PartialViewResult> Submit(ContactForm model, bool CaptchaValid)
        {
            bool isMessageSent = true;

            if (ModelState.IsValid && CaptchaValid)
            {
                try
                {
                    await EmailService.SendContactForm(model);
                }
                catch (Exception ex)
                {
                    isMessageSent = false;
                }
            }
            else
            {
                isMessageSent = false;
            }
            return PartialView("_SubmitMessage", (object)isMessageSent);
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