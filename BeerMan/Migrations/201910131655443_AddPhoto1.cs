namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoto1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Id", "dbo.Foods");
            DropForeignKey("dbo.Drinks", "FotoId", "dbo.Photos");
            DropIndex("dbo.Photos", new[] { "Id" });
            DropPrimaryKey("dbo.Photos");
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Photos", "Id");
            AddForeignKey("dbo.Drinks", "FotoId", "dbo.Photos", "Id");
            DropColumn("dbo.Photos", "FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "FoodId", c => c.Int());
            DropForeignKey("dbo.Drinks", "FotoId", "dbo.Photos");
            DropPrimaryKey("dbo.Photos");
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Photos", "Id");
            CreateIndex("dbo.Photos", "Id");
            AddForeignKey("dbo.Drinks", "FotoId", "dbo.Photos", "Id");
            AddForeignKey("dbo.Photos", "Id", "dbo.Foods", "Id");
        }
    }
}
