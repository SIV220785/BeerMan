namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _241003 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "AspNetUsers_Id", newName: "AspNetUsersID");
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsers_Id", newName: "IX_AspNetUsersID");
            DropColumn("dbo.Orders", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserID", c => c.String());
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsersID", newName: "IX_AspNetUsers_Id");
            RenameColumn(table: "dbo.Orders", name: "AspNetUsersID", newName: "AspNetUsers_Id");
        }
    }
}
