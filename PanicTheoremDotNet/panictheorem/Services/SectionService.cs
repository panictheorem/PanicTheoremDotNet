using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace panictheorem.Services
{
    public class SectionService
    {
        public static Section GetHeaderSection(IUnitOfWork unitOfWork, int pageId)
        {
            return unitOfWork.SectionRepository.Rows.Where(o => o.WebPageId == pageId && o.SectionType == (int)SectionType.Header).FirstOrDefault();
        }

        public static Section GetMainSection(IUnitOfWork unitOfWork, int pageId)
        {
            return unitOfWork.SectionRepository.Rows.Where(o => o.WebPageId == pageId && o.SectionType == (int)SectionType.Main).FirstOrDefault();
        }

        public static IEnumerable<Section> GetContentSections(IUnitOfWork unitOfWork, int pageId)
        {
            return unitOfWork.SectionRepository.Rows.Where(o => o.WebPageId == pageId && o.SectionType == (int)SectionType.Content).ToList();
        }

        public static Section GetHighlights(IUnitOfWork unitOfWork, int pageId)
        {
            return unitOfWork.SectionRepository.Rows.Where(o => o.WebPageId == pageId && o.SectionType == (int)SectionType.Header).FirstOrDefault();
        }
    }
}