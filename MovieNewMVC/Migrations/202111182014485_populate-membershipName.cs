namespace MovieNewMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Memberships SET name='No' where id=1");
            Sql("UPDATE Memberships SET name='Monthly' where id=2");
            Sql("UPDATE Memberships SET name='ThreeMonthly' where id=3");
            Sql("UPDATE Memberships SET name='Yearly' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
