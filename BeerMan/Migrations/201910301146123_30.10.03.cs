namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _301003 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            DropColumn("dbo.Transactions", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "OrderId", c => c.Int());
            CreateIndex("dbo.Transactions", "OrderId");
            AddForeignKey("dbo.Transactions", "OrderId", "dbo.Orders", "Id");
        }
    }
}
