namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2410 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Drinks", name: "FotoId", newName: "PhotoId");
            RenameIndex(table: "dbo.Drinks", name: "IX_FotoId", newName: "IX_PhotoId");
            AddColumn("dbo.Drinks", "Count", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drinks", "Count");
            RenameIndex(table: "dbo.Drinks", name: "IX_PhotoId", newName: "IX_FotoId");
            RenameColumn(table: "dbo.Drinks", name: "PhotoId", newName: "FotoId");
        }
    }
}
