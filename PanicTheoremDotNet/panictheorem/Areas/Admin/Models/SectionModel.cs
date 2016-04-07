using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Areas.Admin.Models
{
    public class SectionModel
    {
        public Section Section { get; set; }
        public List<SelectListItem> SectionTypeSelectList { get; set; }
        public List<SelectListItem> WebPageSelectList { get; set; }
        public SelectList ButtonSelectList { get; set; }

        public SectionModel(IUnitOfWork unitOfWork) {
            SectionTypeSelectList = Enum.GetValues(typeof(SectionType)).Cast<SectionType>().Select(s =>
                                new SelectListItem
                                {
                                    Text = s.ToString(),
                                    Value = ((int)s).ToString()
                                }).ToList();
            WebPageSelectList = Enum.GetValues(typeof(WebPages)).Cast<WebPages>().Select(w =>
                                            new SelectListItem
                                            {
                                                Text = w.ToString(),
                                                Value = ((int)w).ToString()
                                            }).ToList();
            ButtonSelectList = new SelectList(unitOfWork.ButtonRepository.Rows, "ButtonId", "ButtonText");
        }
        public SectionModel(IUnitOfWork unitOfWork, int? id) : this(unitOfWork)
        {
            Section = unitOfWork.SectionRepository.Rows.Where(s => s.SectionId == id).FirstOrDefault();
        }
    }
}