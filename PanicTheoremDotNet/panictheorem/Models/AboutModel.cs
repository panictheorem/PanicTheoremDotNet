using panictheorem.Domain.Abstract;
using panictheorem.Domain.Entities;
using panictheorem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Models
{
    public class AboutModel
    {

        public int pageId;
        public Section HeaderSection { get; set; }
        public Section MainSection { get; set; }
        public List<Section> ContentSections { get; set; }

        public AboutModel(IUnitOfWork unitOfWork)
        {
            pageId = (int)WebPages.About;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            ContentSections = (List<Section>)SectionService.GetContentSections(unitOfWork, pageId);
        }
    }
}