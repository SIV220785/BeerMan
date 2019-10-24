namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "AspNetUsers_Id", newName: "AspNetUsersID");
            RenameColumn(table: "dbo.Drinks", name: "FotoId", newName: "PhotoId");
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsers_Id", newName: "IX_AspNetUsersID");
            RenameIndex(table: "dbo.Drinks", name: "IX_FotoId", newName: "IX_PhotoId");
            AddColumn("dbo.Drinks", "Count", c => c.Int());
            DropColumn("dbo.Orders", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserID", c => c.Int());
            DropColumn("dbo.Drinks", "Count");
            RenameIndex(table: "dbo.Drinks", name: "IX_PhotoId", newName: "IX_FotoId");
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsersID", newName: "IX_AspNetUsers_Id");
            RenameColumn(table: "dbo.Drinks", name: "PhotoId", newName: "FotoId");
            RenameColumn(table: "dbo.Orders", name: "AspNetUsersID", newName: "AspNetUsers_Id");
        }
    }
}
