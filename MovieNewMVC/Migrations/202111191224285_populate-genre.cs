namespace MovieNewMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT GENREs ON");
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Drama')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'Romantic')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'Family')");
            Sql("SET IDENTITY_INSERT GENREs OFF");
        }
        
        public override void Down()
        {
        }
    }
}
