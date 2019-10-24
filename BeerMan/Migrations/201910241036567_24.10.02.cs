namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _241002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "UserID", c => c.Int());
        }
    }
}
