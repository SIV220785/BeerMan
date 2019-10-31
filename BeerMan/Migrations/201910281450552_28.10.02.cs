namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _281002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "IsPayment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "IsPayment", c => c.Boolean());
        }
    }
}
