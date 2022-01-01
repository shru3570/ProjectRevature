namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RoleId");
        }
    }
}
