namespace WorkShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeMaterials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        RecipeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.MaterialID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID)
                .Index(t => t.MaterialID)
                .Index(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeMaterials", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeMaterials", "MaterialID", "dbo.Materials");
            DropForeignKey("dbo.Orders", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeMaterials", new[] { "RecipeID" });
            DropIndex("dbo.RecipeMaterials", new[] { "MaterialID" });
            DropIndex("dbo.Orders", new[] { "RecipeID" });
            DropTable("dbo.RecipeMaterials");
            DropTable("dbo.Recipes");
            DropTable("dbo.Orders");
            DropTable("dbo.Materials");
        }
    }
}
