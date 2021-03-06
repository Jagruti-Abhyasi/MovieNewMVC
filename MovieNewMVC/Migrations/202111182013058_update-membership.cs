namespace MovieNewMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Name");
        }
    }
}
