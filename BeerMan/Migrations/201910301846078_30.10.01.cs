namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _301001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            AddColumn("dbo.Orders", "TransactionId", c => c.Int());
            AlterColumn("dbo.Transactions", "TransactionDate", c => c.DateTime());
            CreateIndex("dbo.Orders", "TransactionId");
            AddForeignKey("dbo.Orders", "TransactionId", "dbo.Transactions", "Id");
            DropColumn("dbo.Wallets", "Coins");
            DropColumn("dbo.Transactions", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "OrderId", c => c.Int());
            AddColumn("dbo.Wallets", "Coins", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Orders", new[] { "TransactionId" });
            AlterColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "TransactionId");
            CreateIndex("dbo.Transactions", "OrderId");
            AddForeignKey("dbo.Transactions", "OrderId", "dbo.Orders", "Id");
        }
    }
}
