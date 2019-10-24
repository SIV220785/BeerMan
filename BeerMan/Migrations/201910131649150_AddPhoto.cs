namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Name", c => c.String());
            AddColumn("dbo.Photos", "Image", c => c.Binary());
            DropColumn("dbo.Photos", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Link", c => c.String());
            DropColumn("dbo.Photos", "Image");
            DropColumn("dbo.Photos", "Name");
        }
    }
}
