namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5b07d006-af85-4c35-b474-741d5ae2a1cb', N'guest@email.com', 0, N'AIHFERqg54kv2DAT9WQWX0ZlkOXFDoH2+DibmXNobw0t0PkTmfhWpVEKztDeLR1g5A==', N'7c881229-31a6-4f6e-9539-7451e996449f', NULL, 0, 0, NULL, 1, 0, N'guest@email.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cd90dfe5-e497-41cd-ae9f-044873eaa338', N'admin@email.com', 0, N'AKwIssYZ2wGm5++nj7WE8LR1Hps02YgywAiaMrCxgKvWNvBANubG3jsygo7wsKwH9w==', N'48d1f5c7-eab6-45af-9f1e-ef0fb7f51bd2', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'50f093c7-0193-48cf-8d67-19eb6b662a72', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cd90dfe5-e497-41cd-ae9f-044873eaa338', N'50f093c7-0193-48cf-8d67-19eb6b662a72')
");
        }
        
        public override void Down()
        {
        }
    }
}
