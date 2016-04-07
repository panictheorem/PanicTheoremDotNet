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
    public class PortfolioModel
    {
        private int pageId;
        public Section HeaderSection { get; set; }
        public Section MainSection { get; set; }
        public IEnumerable<Project> Projects{ get; set; }
        public PortfolioModel(IUnitOfWork unitOfWork)
        {
            pageId = (int)WebPages.Portfolio;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            Projects = unitOfWork.ProjectRepository.Rows.OrderBy(p => p.SortOrder);
        }
    }
}