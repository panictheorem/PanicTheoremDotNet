using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Highlight> HighlightRepository{ get; }

        IRepository<Project> ProjectRepository{ get; }

        IRepository<Button> ButtonRepository { get; }

        IRepository<Section> SectionRepository { get; }

        IRepository<SocialMediaIcon> SocialMediaIconRepository { get; }

        IRepository<BlogPost> BlogPostRepository { get; }

        IRepository<Label> LabelRepository { get; }

        IRepository<Author> AuthorRepository { get; }

        void Commit();
    }
}
