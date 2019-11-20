namespace SplitwiseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.frdlists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        loginuser = c.String(),
                        friendname = c.String(),
                        Email = c.String(),
                        rupee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.frdlists");
        }
    }
}
