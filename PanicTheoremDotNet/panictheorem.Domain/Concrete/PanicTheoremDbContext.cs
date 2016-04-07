using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Concrete
{
    public class PanicTheoremDbContext : DbContext
    {
        public PanicTheoremDbContext() : base("PanicTheoremDbConnection") 
        {
        }

        public virtual DbSet<Highlight> Highlights { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Button> Buttons { get; set; }
        public virtual DbSet<SocialMediaIcon> SocialMediaIcons { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().
                HasMany(b => b.Labels).
                WithMany(l => l.BlogPosts).
                Map(
                    m => {
                        m.MapRightKey("LabelId");
                        m.MapLeftKey("BlogPostId");
                        m.ToTable("BlogPostLabels");
                    });
        }
    }
}
