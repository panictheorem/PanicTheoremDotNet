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
    public class HomeModel
    {
        private int pageId;
        public IEnumerable<Highlight> Highlights { get; set; }
        public Section HeaderSection { get; set; }
        public Section MainSection { get; set; }
        public IEnumerable<Section> ContentSections { get; set; }
        public IEnumerable<SocialMediaIcon> SocialMediaIcons { get; set; }

        public HomeModel(IUnitOfWork unitOfWork)
        {
            pageId = (int)WebPages.Home;
            HeaderSection = SectionService.GetHeaderSection(unitOfWork, pageId);
            MainSection = SectionService.GetMainSection(unitOfWork, pageId);
            ContentSections = (List<Section>)SectionService.GetContentSections(unitOfWork, pageId);
            Highlights = unitOfWork.HighlightRepository.Rows.ToList();
            SocialMediaIcons = unitOfWork.SocialMediaIconRepository.Rows.ToList();
        }
    }
}