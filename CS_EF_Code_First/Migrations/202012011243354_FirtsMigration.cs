namespace CS_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirtsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryRowId = c.Int(nullable: false, identity: true),
                        CategoryId = c.String(nullable: false, maxLength: 200),
                        CategoryName = c.String(nullable: false, maxLength: 200),
                        BasePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryRowId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductRowId = c.Int(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 200),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        CategoryRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductRowId)
                .ForeignKey("dbo.Categories", t => t.CategoryRowId, cascadeDelete: true)
                .Index(t => t.CategoryRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryRowId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryRowId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
