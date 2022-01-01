namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carttablecolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductAmount = c.Double(nullable: false),
                        ProductQuantity = c.Double(nullable: false),
                        Isdeleteted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
