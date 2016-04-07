namespace panictheorem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "BlogPostContent_BlogPostContentId", "dbo.BlogPostContents");
            DropIndex("dbo.BlogPosts", new[] { "BlogPostContent_BlogPostContentId" });
            RenameColumn(table: "dbo.BlogPosts", name: "BlogPostContent_BlogPostContentId", newName: "BlogPostContentID");
            AlterColumn("dbo.BlogPosts", "BlogPostContentID", c => c.Int(nullable: true, defaultValue: 0));
            CreateIndex("dbo.BlogPosts", "BlogPostContentID");
            AddForeignKey("dbo.BlogPosts", "BlogPostContentID", "dbo.BlogPostContents", "BlogPostContentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "BlogPostContentID", "dbo.BlogPostContents");
            DropIndex("dbo.BlogPosts", new[] { "BlogPostContentID" });
            AlterColumn("dbo.BlogPosts", "BlogPostContentID", c => c.Int());
            RenameColumn(table: "dbo.BlogPosts", name: "BlogPostContentID", newName: "BlogPostContent_BlogPostContentId");
            CreateIndex("dbo.BlogPosts", "BlogPostContent_BlogPostContentId");
            AddForeignKey("dbo.BlogPosts", "BlogPostContent_BlogPostContentId", "dbo.BlogPostContents", "BlogPostContentId");
        }
    }
}
