namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _281001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsPayment", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsPayment");
        }
    }
}
