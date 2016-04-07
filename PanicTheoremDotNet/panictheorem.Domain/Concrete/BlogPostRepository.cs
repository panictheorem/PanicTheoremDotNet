using panictheorem.Domain.Abstract;
using panictheorem.Domain.Entities;
using RepoAndUnitOfWork.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Concrete
{
    public class BlogPostRepository : Repository<BlogPost>
    {
        public BlogPostRepository(PanicTheoremDbContext context):
            base(context)
        {
            dbSet = context.BlogPosts;
        }

        public override void Update(BlogPost blogPost)
        {
            var blogPostRecord = dbSet.Where(p => p.BlogPostId == blogPost.BlogPostId).FirstOrDefault();
            blogPostRecord.AuthorId = blogPost.AuthorId;
            blogPostRecord.Content = blogPost.Content;
            blogPostRecord.PostingDate = blogPost.PostingDate;
            blogPostRecord.Title = blogPost.Title;
            blogPostRecord.UrlSegment = blogPost.UrlSegment;
            blogPostRecord.Labels.Clear();

            foreach(var label in blogPost.Labels)
            {
                blogPostRecord.Labels.Add(label);
            }
            base.Update(blogPostRecord);
        }

        public override void Delete(BlogPost blogPost)
        {
            blogPost.Labels.Clear();//clear many to many navigation property
            base.Delete(blogPost);
        }
    }
}
