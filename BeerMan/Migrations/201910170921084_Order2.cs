namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Cost", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
