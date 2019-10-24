namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transac4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Foods", "FotoId", "dbo.Photos");
            DropForeignKey("dbo.Drinks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Foods", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Drinks", "FotoId", "dbo.Photos");
            DropIndex("dbo.Orders", new[] { "PartyId" });
            DropIndex("dbo.Drinks", new[] { "FotoId" });
            DropIndex("dbo.Drinks", new[] { "OrderId" });
            DropIndex("dbo.Photos", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.Foods", new[] { "FotoId" });
            DropIndex("dbo.Foods", new[] { "OrderId" });
            RenameColumn(table: "dbo.Foods", name: "OrderId", newName: "Order_Id");
            DropPrimaryKey("dbo.Photos");
            AddColumn("dbo.Photos", "FoodId", c => c.Int());
            AlterColumn("dbo.Orders", "UserID", c => c.Int());
            AlterColumn("dbo.Orders", "PartyId", c => c.Int());
            AlterColumn("dbo.Drinks", "FotoId", c => c.Int());
            AlterColumn("dbo.Drinks", "OrderId", c => c.Int());
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Foods", "Order_Id", c => c.Int());
            AddPrimaryKey("dbo.Photos", "Id");
            CreateIndex("dbo.Orders", "PartyId");
            CreateIndex("dbo.Drinks", "FotoId");
            CreateIndex("dbo.Drinks", "OrderId");
            CreateIndex("dbo.Photos", "Id");
            CreateIndex("dbo.Foods", "Order_Id");
            AddForeignKey("dbo.Photos", "Id", "dbo.Foods", "Id");
            AddForeignKey("dbo.Drinks", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.Foods", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "PartyId", "dbo.Parties", "Id");
            AddForeignKey("dbo.Drinks", "FotoId", "dbo.Photos", "Id");
            DropColumn("dbo.Photos", "UserID");
            DropColumn("dbo.Photos", "AspNetUsers_Id");
            DropColumn("dbo.Foods", "FotoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "FotoId", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "AspNetUsers_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Photos", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Drinks", "FotoId", "dbo.Photos");
            DropForeignKey("dbo.Orders", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Foods", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Drinks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Photos", "Id", "dbo.Foods");
            DropIndex("dbo.Foods", new[] { "Order_Id" });
            DropIndex("dbo.Photos", new[] { "Id" });
            DropIndex("dbo.Drinks", new[] { "OrderId" });
            DropIndex("dbo.Drinks", new[] { "FotoId" });
            DropIndex("dbo.Orders", new[] { "PartyId" });
            DropPrimaryKey("dbo.Photos");
            AlterColumn("dbo.Foods", "Order_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Drinks", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Drinks", "FotoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PartyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Photos", "FoodId");
            AddPrimaryKey("dbo.Photos", "Id");
            RenameColumn(table: "dbo.Foods", name: "Order_Id", newName: "OrderId");
            CreateIndex("dbo.Foods", "OrderId");
            CreateIndex("dbo.Foods", "FotoId");
            CreateIndex("dbo.Photos", "AspNetUsers_Id");
            CreateIndex("dbo.Drinks", "OrderId");
            CreateIndex("dbo.Drinks", "FotoId");
            CreateIndex("dbo.Orders", "PartyId");
            AddForeignKey("dbo.Drinks", "FotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "PartyId", "dbo.Parties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Foods", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drinks", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Foods", "FotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "AspNetUsers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
