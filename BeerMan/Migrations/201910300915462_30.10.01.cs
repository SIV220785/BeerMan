namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _301001 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wallets", "Coins");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wallets", "Coins", c => c.Int(nullable: false));
        }
    }
}
