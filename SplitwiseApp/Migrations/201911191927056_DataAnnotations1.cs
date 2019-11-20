namespace SplitwiseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.frdlists", "friendname", c => c.String(nullable: false));
            AlterColumn("dbo.frdlists", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.frdlists", "Email", c => c.String());
            AlterColumn("dbo.frdlists", "friendname", c => c.String());
        }
    }
}
