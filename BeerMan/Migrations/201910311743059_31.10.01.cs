namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _311001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(),
                        TwoFactorEnabled = c.Boolean(),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(),
                        AccessFailedCount = c.Int(),
                        NickName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Party_Id = c.Int(),
                        AspNetUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .Index(t => t.Party_Id)
                .Index(t => t.AspNetUsers_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryTime = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Adress = c.String(),
                        Status = c.String(),
                        CourierId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Couriers", t => t.CourierId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.CourierId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(),
                        IsPayment = c.Boolean(nullable: false),
                        AspNetUsersID = c.String(maxLength: 128),
                        PartyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersID)
                .ForeignKey("dbo.Parties", t => t.PartyId)
                .ForeignKey("dbo.Transactions", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AspNetUsersID)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartPartyDate = c.DateTime(nullable: false),
                        About = c.String(),
                        UserId = c.Int(nullable: false),
                        AspNetUser_Id = c.String(maxLength: 128),
                        AspNetUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetUsers_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        WalletId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wallets", t => t.WalletId)
                .Index(t => t.WalletId);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Coins = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);                       
            
            CreateTable(
                "dbo.DeliveryOrderAspNetUsers",
                c => new
                    {
                        DeliveryOrder_Id = c.Int(nullable: false),
                        AspNetUsers_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DeliveryOrder_Id, t.AspNetUsers_Id })
                .ForeignKey("dbo.DeliveryOrders", t => t.DeliveryOrder_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id, cascadeDelete: true)
                .Index(t => t.DeliveryOrder_Id)
                .Index(t => t.AspNetUsers_Id);
            
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
                "dbo.FoodOrders",
                c => new
                    {
                        Food_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_Id, t.Order_Id })
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Food_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Wallets", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parties", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeliveryOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Orders", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.AspNetUsers", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Parties", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Drinks", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Foods", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.FoodOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.FoodOrders", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.DrinkOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.DrinkOrders", "Drink_Id", "dbo.Drinks");
            DropForeignKey("dbo.Orders", "AspNetUsersID", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeliveryOrders", "CourierId", "dbo.Couriers");
            DropForeignKey("dbo.DeliveryOrderAspNetUsers", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeliveryOrderAspNetUsers", "DeliveryOrder_Id", "dbo.DeliveryOrders");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.FoodOrders", new[] { "Order_Id" });
            DropIndex("dbo.FoodOrders", new[] { "Food_Id" });
            DropIndex("dbo.DrinkOrders", new[] { "Order_Id" });
            DropIndex("dbo.DrinkOrders", new[] { "Drink_Id" });
            DropIndex("dbo.DeliveryOrderAspNetUsers", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.DeliveryOrderAspNetUsers", new[] { "DeliveryOrder_Id" });
            DropIndex("dbo.Wallets", new[] { "Id" });
            DropIndex("dbo.Transactions", new[] { "WalletId" });
            DropIndex("dbo.Parties", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.Parties", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Foods", new[] { "PhotoId" });
            DropIndex("dbo.Drinks", new[] { "PhotoId" });
            DropIndex("dbo.Orders", new[] { "PartyId" });
            DropIndex("dbo.Orders", new[] { "AspNetUsersID" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.DeliveryOrders", new[] { "OrderId" });
            DropIndex("dbo.DeliveryOrders", new[] { "CourierId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Party_Id" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.FoodOrders");
            DropTable("dbo.DrinkOrders");
            DropTable("dbo.DeliveryOrderAspNetUsers");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Wallets");
            DropTable("dbo.Transactions");
            DropTable("dbo.Parties");
            DropTable("dbo.Foods");
            DropTable("dbo.Photos");
            DropTable("dbo.Drinks");
            DropTable("dbo.Orders");
            DropTable("dbo.Couriers");
            DropTable("dbo.DeliveryOrders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
