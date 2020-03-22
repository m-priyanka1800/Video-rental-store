namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay as you go' WHERE ID = 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' WHERE ID = 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quarterly' WHERE ID = 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Annual' WHERE ID = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
