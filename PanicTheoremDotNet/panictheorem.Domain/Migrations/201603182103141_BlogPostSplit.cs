namespace panictheorem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostSplit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPostContents",
                c => new
                    {
                        BlogPostContentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostContentId);
            
            AddColumn("dbo.BlogPosts", "BlogPostContent_BlogPostContentId", c => c.Int());
            CreateIndex("dbo.BlogPosts", "BlogPostContent_BlogPostContentId");
            AddForeignKey("dbo.BlogPosts", "BlogPostContent_BlogPostContentId", "dbo.BlogPostContents", "BlogPostContentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "BlogPostContent_BlogPostContentId", "dbo.BlogPostContents");
            DropIndex("dbo.BlogPosts", new[] { "BlogPostContent_BlogPostContentId" });
            DropColumn("dbo.BlogPosts", "BlogPostContent_BlogPostContentId");
            DropTable("dbo.BlogPostContents");
        }
    }
}
