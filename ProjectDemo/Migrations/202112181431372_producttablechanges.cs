namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttablechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductQuantity", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "PrroductQuatity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PrroductQuatity", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "ProductQuantity");
        }
    }
}
