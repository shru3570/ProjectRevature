namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdcolumnadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserCreated");
        }
    }
}
