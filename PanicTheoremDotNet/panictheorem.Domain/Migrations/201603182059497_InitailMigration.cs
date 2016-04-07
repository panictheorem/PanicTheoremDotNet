
namespace panictheorem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailMigration : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "ButtonId", "dbo.Buttons");
            DropForeignKey("dbo.Buttons", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BlogPostLabels", "LabelId", "dbo.Labels");
            DropForeignKey("dbo.BlogPostLabels", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPosts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BlogPostLabels", new[] { "LabelId" });
            DropIndex("dbo.BlogPostLabels", new[] { "BlogPostId" });
            DropIndex("dbo.Sections", new[] { "ButtonId" });
            DropIndex("dbo.Buttons", new[] { "ProjectId" });
            DropIndex("dbo.BlogPosts", new[] { "AuthorId" });
            DropTable("dbo.BlogPostLabels");
            DropTable("dbo.SocialMediaIcons");
            DropTable("dbo.Sections");
            DropTable("dbo.Projects");
            DropTable("dbo.Highlights");
            DropTable("dbo.Buttons");
            DropTable("dbo.Labels");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Authors");
        }
    }
}
