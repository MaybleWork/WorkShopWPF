namespace WorkShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.Orders", new[] { "RecipeID" });
            CreateTable(
                "dbo.MaterialInWorkShops",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.MaterialInWorkShops");
            CreateIndex("dbo.Orders", "RecipeID");
            AddForeignKey("dbo.Orders", "RecipeID", "dbo.Recipes", "ID");
        }
    }
}
