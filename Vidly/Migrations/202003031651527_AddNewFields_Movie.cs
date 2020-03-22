namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFields_Movie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreID", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "RelaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Num_in_Stock", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropColumn("dbo.Movies", "Num_in_Stock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "RelaseDate");
            DropColumn("dbo.Movies", "GenreID");
        }
    }
}
