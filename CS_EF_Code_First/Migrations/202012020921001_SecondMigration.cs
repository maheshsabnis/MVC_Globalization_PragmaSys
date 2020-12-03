namespace CS_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SubCategoryName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Products", "SalesTax", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SalesTax");
            DropColumn("dbo.Categories", "SubCategoryName");
        }
    }
}
