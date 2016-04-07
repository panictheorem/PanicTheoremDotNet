using panictheorem.Domain.Abstract;
using panictheorem.Domain.Entities;
using RepoAndUnitOfWork.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PanicTheoremDbContext dbContext = new PanicTheoremDbContext();

        private IRepository<Highlight> highlightRepository;
        private IRepository<Project> projectRepository;
        private IRepository<Button> buttonRepository;
        private IRepository<Section> sectionRepository;
        private IRepository<SocialMediaIcon> socialMediaIconRepository;
        private IRepository<BlogPost> blogPostRepository;
        private IRepository<Label> labelRepository;
        private IRepository<Author> authorRepository;

        public IRepository<Highlight> HighlightRepository
        {
            get 
            {
                if (highlightRepository == null)
                {
                    highlightRepository = new Repository<Highlight>(dbContext);
                }
                return highlightRepository;
            }
        }

        public IRepository<Project> ProjectRepository
        {
            get
            {
                if (projectRepository == null)
                {
                    projectRepository = new Repository<Project>(dbContext);
                }
                return projectRepository;
            }
        }

        public IRepository<Button> ButtonRepository
        {
            get
            {
                if (buttonRepository == null)
                {
                    buttonRepository = new Repository<Button>(dbContext);
                }
                return buttonRepository;
            }
        }

        public IRepository<Section> SectionRepository
        {
            get
            {
                if (sectionRepository == null)
                {
                    sectionRepository = new Repository<Section>(dbContext);
                }
                return sectionRepository;
            }
        }

        public IRepository<SocialMediaIcon> SocialMediaIconRepository
        {
            get
            {
                if (socialMediaIconRepository == null)
                {
                    socialMediaIconRepository = new Repository<SocialMediaIcon>(dbContext);
                }
                return socialMediaIconRepository;
            }
        }
        public IRepository<BlogPost> BlogPostRepository
        {
            get
            {
                if (blogPostRepository == null)
                {
                    blogPostRepository = new BlogPostRepository(dbContext);
                }
                return blogPostRepository;
            }
        }

        public IRepository<Label> LabelRepository
        {
            get
            {
                if (labelRepository == null)
                {
                    labelRepository = new Repository<Label>(dbContext);
                }
                return labelRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new Repository<Author>(dbContext);
                }
                return authorRepository;
            }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
