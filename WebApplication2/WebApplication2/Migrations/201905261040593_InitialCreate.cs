namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Card = c.Int(nullable: false),
                        CardOwner = c.String(),
                        CVC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Comments = c.String(),
                        Invoice_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.Invoice_Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Invoice_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.Rent", "Invoice_Id", "dbo.Invoice");
            DropIndex("dbo.Rent", new[] { "Item_Id" });
            DropIndex("dbo.Rent", new[] { "Invoice_Id" });
            DropTable("dbo.Rent");
            DropTable("dbo.Item");
            DropTable("dbo.Invoice");
        }
    }
}
