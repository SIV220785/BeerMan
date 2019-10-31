namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _251002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drinks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Foods", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Photos", "Party_Id", "dbo.Parties");
            DropIndex("dbo.Drinks", new[] { "OrderId" });
            DropIndex("dbo.Photos", new[] { "Party_Id" });
            DropIndex("dbo.Foods", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Orders", name: "AspNetUsers_Id", newName: "AspNetUsersID");
            RenameColumn(table: "dbo.Drinks", name: "FotoId", newName: "PhotoId");
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsers_Id", newName: "IX_AspNetUsersID");
            RenameIndex(table: "dbo.Drinks", name: "IX_FotoId", newName: "IX_PhotoId");
            CreateTable(
                "dbo.DrinkOrders",
                c => new
                    {
                        Drink_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Drink_Id, t.Order_Id })
                .ForeignKey("dbo.Drinks", t => t.Drink_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Drink_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.OrdersFood",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.FoodId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.FoodId);
            
            AddColumn("dbo.Drinks", "Count", c => c.Int());
            AddColumn("dbo.Foods", "Count", c => c.Int());
            AddColumn("dbo.Foods", "PhotoId", c => c.Int());
            AlterColumn("dbo.Orders", "CreateDate", c => c.DateTime());
            CreateIndex("dbo.Foods", "PhotoId");
            AddForeignKey("dbo.Foods", "PhotoId", "dbo.Photos", "Id");
            DropColumn("dbo.Orders", "UserID");
            DropColumn("dbo.Drinks", "OrderId");
            DropColumn("dbo.Photos", "Party_Id");
            DropColumn("dbo.Foods", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Order_Id", c => c.Int());
            AddColumn("dbo.Photos", "Party_Id", c => c.Int());
            AddColumn("dbo.Drinks", "OrderId", c => c.Int());
            AddColumn("dbo.Orders", "UserID", c => c.Int());
            DropForeignKey("dbo.OrdersFood", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.OrdersFood", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Foods", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.DrinkOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.DrinkOrders", "Drink_Id", "dbo.Drinks");
            DropIndex("dbo.OrdersFood", new[] { "FoodId" });
            DropIndex("dbo.OrdersFood", new[] { "OrderId" });
            DropIndex("dbo.DrinkOrders", new[] { "Order_Id" });
            DropIndex("dbo.DrinkOrders", new[] { "Drink_Id" });
            DropIndex("dbo.Foods", new[] { "PhotoId" });
            AlterColumn("dbo.Orders", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Foods", "PhotoId");
            DropColumn("dbo.Foods", "Count");
            DropColumn("dbo.Drinks", "Count");
            DropTable("dbo.OrdersFood");
            DropTable("dbo.DrinkOrders");
            RenameIndex(table: "dbo.Drinks", name: "IX_PhotoId", newName: "IX_FotoId");
            RenameIndex(table: "dbo.Orders", name: "IX_AspNetUsersID", newName: "IX_AspNetUsers_Id");
            RenameColumn(table: "dbo.Drinks", name: "PhotoId", newName: "FotoId");
            RenameColumn(table: "dbo.Orders", name: "AspNetUsersID", newName: "AspNetUsers_Id");
            CreateIndex("dbo.Foods", "Order_Id");
            CreateIndex("dbo.Photos", "Party_Id");
            CreateIndex("dbo.Drinks", "OrderId");
            AddForeignKey("dbo.Photos", "Party_Id", "dbo.Parties", "Id");
            AddForeignKey("dbo.Foods", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Drinks", "OrderId", "dbo.Orders", "Id");
        }
    }
}
