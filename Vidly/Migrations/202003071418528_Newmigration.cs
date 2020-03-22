namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "RelaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "RelaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
