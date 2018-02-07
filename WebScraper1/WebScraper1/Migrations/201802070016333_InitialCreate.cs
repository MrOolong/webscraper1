namespace WebScraper1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleDBs",
                c => new
                    {
                        IDKey = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(),
                    })
                .PrimaryKey(t => t.IDKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleDBs");
        }
    }
}
