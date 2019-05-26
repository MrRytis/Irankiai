namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontext1 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Transport");
        }
    }
}
