namespace BeerMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Count", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Count");
        }
    }
}
