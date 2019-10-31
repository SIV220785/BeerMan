namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aspUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
        }
    }
}
