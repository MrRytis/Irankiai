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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bid");
            DropTable("dbo.Auction");
            DropTable("dbo.Advert");
        }
    }
}
