namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderBy", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderDetails", c => c.String());
            AddColumn("dbo.Orders", "Status", c => c.String());
            AddColumn("dbo.Orders", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DelivaryAddress", c => c.String());
            DropColumn("dbo.Orders", "ProductId");
            DropColumn("dbo.Orders", "ProductName");
            DropColumn("dbo.Orders", "ProductAmount");
            DropColumn("dbo.Orders", "ProductQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductQuantity", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "ProductAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "ProductName", c => c.String());
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "DelivaryAddress");
            DropColumn("dbo.Orders", "DeliveryDate");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "OrderDetails");
            DropColumn("dbo.Orders", "OrderBy");
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
