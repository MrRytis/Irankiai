namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontext4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "CVC", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoice", "CVC", c => c.Int(nullable: false));
        }
    }
}
