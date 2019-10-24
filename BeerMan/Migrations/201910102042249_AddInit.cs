namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coins", "Wallet_Id", "dbo.Wallets");
            DropIndex("dbo.Coins", new[] { "Wallet_Id" });
            AddColumn("dbo.Wallets", "Coins", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Currency");
            DropTable("dbo.Coins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Coins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        WalletId = c.Int(nullable: false),
                        Wallet_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "Currency", c => c.String());
            DropColumn("dbo.Wallets", "Coins");
            CreateIndex("dbo.Coins", "Wallet_Id");
            AddForeignKey("dbo.Coins", "Wallet_Id", "dbo.Wallets", "Id");
        }
    }
}
