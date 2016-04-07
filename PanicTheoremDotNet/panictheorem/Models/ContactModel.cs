using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using panictheorem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class ContactModel
    {
        private int pageId;
        public Section MainSection { get; set; }
        public ContactForm ContactForm { get; set; }

        public ContactModel() { }

        public ContactModel(IUnitOfWork unitOfWork)
        {
            pageId = (int)WebPages.Contact;
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            ContactForm = new ContactForm();
        }
    }
}