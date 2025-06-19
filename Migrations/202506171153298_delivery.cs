namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delivery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightGrams = c.Int(nullable: false),
                        DishTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DishId)
                .ForeignKey("dbo.DishTypes", t => t.DishTypeId, cascadeDelete: true)
                .Index(t => t.DishTypeId);
            
            CreateTable(
                "dbo.DishTypes",
                c => new
                    {
                        DishTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.DishTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "DishTypeId", "dbo.DishTypes");
            DropIndex("dbo.Dishes", new[] { "DishTypeId" });
            DropTable("dbo.DishTypes");
            DropTable("dbo.Dishes");
        }
    }
}
