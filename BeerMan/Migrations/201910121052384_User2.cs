namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropIndex("dbo.Wallets", new[] { "Id" });
            DropPrimaryKey("dbo.Wallets");
            AlterColumn("dbo.Wallets", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Wallets", "Id");
            CreateIndex("dbo.Wallets", "Id");
            AddForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets");
            DropIndex("dbo.Wallets", new[] { "Id" });
            DropPrimaryKey("dbo.Wallets");
            AlterColumn("dbo.Wallets", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Wallets", "Id");
            CreateIndex("dbo.Wallets", "Id");
            AddForeignKey("dbo.Transactions", "Wallet_Id", "dbo.Wallets", "Id");
        }
    }
}
