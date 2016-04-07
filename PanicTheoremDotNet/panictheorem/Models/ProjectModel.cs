using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class ProjectModel
    {
        public Project Project { get; set;}
        public Section HeaderSection { get; set; }

        public ProjectModel(IUnitOfWork unitOfWork, string urlSegment)
        {
            Project = unitOfWork.ProjectRepository.Rows.Where(o => o.UrlSegment.ToUpper() == urlSegment.ToUpper()).FirstOrDefault();
            if (Project != null)
            {
                HeaderSection = new Section
                {
                    Title = Project.Title,
                    Body = Project.Subtitle
                };
            }
        }
    }
}