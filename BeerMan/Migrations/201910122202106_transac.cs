namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transac : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            DropIndex("dbo.Transactions", new[] { "Wallet_Id" });
            DropColumn("dbo.Transactions", "WalletId");
            RenameColumn(table: "dbo.Transactions", name: "Wallet_Id", newName: "WalletId");
            AlterColumn("dbo.Transactions", "WalletId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Transactions", "OrderId", c => c.Int());
            CreateIndex("dbo.Transactions", "WalletId");
            CreateIndex("dbo.Transactions", "OrderId");
            AddForeignKey("dbo.Transactions", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            DropIndex("dbo.Transactions", new[] { "WalletId" });
            AlterColumn("dbo.Transactions", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "WalletId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Transactions", name: "WalletId", newName: "Wallet_Id");
            AddColumn("dbo.Transactions", "WalletId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Wallet_Id");
            CreateIndex("dbo.Transactions", "OrderId");
            AddForeignKey("dbo.Transactions", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
