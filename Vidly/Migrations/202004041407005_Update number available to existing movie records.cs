namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatenumberavailabletoexistingmovierecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET Num_Available = Num_in_Stock");
        }
        
        public override void Down()
        {
        }
    }
}
