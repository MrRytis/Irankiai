namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advert",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valid_from = c.DateTime(nullable: false),
                        Valid_to = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 10),
                        Price = c.Double(nullable: false),
                        Status = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 10),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Card = c.String(nullable: false, maxLength: 6),
                        CardConfirm = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Card = c.Int(nullable: false),
                        CardOwner = c.String(nullable: false),
                        CVC = c.Int(),
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
                        Transport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.Invoice_Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .ForeignKey("dbo.Transport", t => t.Transport_Id)
                .Index(t => t.Invoice_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Transport_Id);
            
            CreateTable(
                "dbo.Transport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pickup_Time = c.DateTime(nullable: false),
                        Delivery_Time = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent", "Transport_Id", "dbo.Transport");
            DropForeignKey("dbo.Rent", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.Rent", "Invoice_Id", "dbo.Invoice");
            DropIndex("dbo.Rent", new[] { "Transport_Id" });
            DropIndex("dbo.Rent", new[] { "Item_Id" });
            DropIndex("dbo.Rent", new[] { "Invoice_Id" });
            DropTable("dbo.Transport");
            DropTable("dbo.Rent");
            DropTable("dbo.Item");
            DropTable("dbo.Invoice");
            DropTable("dbo.Bid");
            DropTable("dbo.Auction");
            DropTable("dbo.Advert");
        }
    }
}
