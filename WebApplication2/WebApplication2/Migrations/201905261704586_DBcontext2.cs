namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcontext2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "CardOwner", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoice", "CardOwner", c => c.String());
        }
    }
}
