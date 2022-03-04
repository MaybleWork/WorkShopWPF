namespace WorkShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materials", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "Price", c => c.Int(nullable: false));
        }
    }
}
