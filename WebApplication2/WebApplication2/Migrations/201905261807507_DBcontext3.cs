namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontext3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rent", "Transport_Id", c => c.Int());
            CreateIndex("dbo.Rent", "Transport_Id");
            AddForeignKey("dbo.Rent", "Transport_Id", "dbo.Transport", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent", "Transport_Id", "dbo.Transport");
            DropIndex("dbo.Rent", new[] { "Transport_Id" });
            DropColumn("dbo.Rent", "Transport_Id");
        }
    }
}
