namespace WebScraper1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleDBs", "ArticleUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleDBs", "ArticleUrl");
        }
    }
}
