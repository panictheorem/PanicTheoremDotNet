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
    public class ButtonModel
    {
        public Button Button { get; set; }
        public Project Project { get; set; }
        public List<SelectListItem> ButtonTypeSelectList { get; set; }
        public SelectList ProjectSelectList { get; set; }
        public ButtonModel(IUnitOfWork unitOfWork, int? id)
        {
            Button = unitOfWork.ButtonRepository.Rows.Where(b => b.ButtonId == id).FirstOrDefault();
            Project = unitOfWork.ProjectRepository.Rows.Where(p => p.ProjectId == Button.ProjectId).FirstOrDefault();
            ButtonTypeSelectList = Enum.GetValues(typeof(ButtonType)).Cast<ButtonType>().Select(b => new SelectListItem
            {
                Text = b.ToString(),
                Value = ((int)b).ToString()
            }).ToList();
            ProjectSelectList = new SelectList(unitOfWork.ProjectRepository.Rows, "ProjectId", "Title");
        }
    }
}