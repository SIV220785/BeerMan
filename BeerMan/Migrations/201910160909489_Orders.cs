namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Foods", name: "Order_Id", newName: "OrderId");
            RenameIndex(table: "dbo.Foods", name: "IX_Order_Id", newName: "IX_OrderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Foods", name: "IX_OrderId", newName: "IX_Order_Id");
            RenameColumn(table: "dbo.Foods", name: "OrderId", newName: "Order_Id");
        }
    }
}
