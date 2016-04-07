using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Areas.Admin.Models
{
    public class ButtonListModel
    {
        public IEnumerable<Button> Buttons { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        public ButtonListModel(IUnitOfWork unitOfWork)
        {
            Buttons = unitOfWork.ButtonRepository.Rows;
            Projects = unitOfWork.ProjectRepository.Rows;
        }
    }
}