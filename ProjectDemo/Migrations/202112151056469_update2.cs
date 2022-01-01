namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RoleId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
        }
    }
}
