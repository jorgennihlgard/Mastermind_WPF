namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pinsWorkingAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "Row_Id", "dbo.Rows");
            DropIndex("dbo.Pins", new[] { "Row_Id" });
            DropColumn("dbo.Pins", "Row_Id");
            DropTable("dbo.Rows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pins", "Row_Id", c => c.Int());
            CreateIndex("dbo.Pins", "Row_Id");
            AddForeignKey("dbo.Pins", "Row_Id", "dbo.Rows", "Id");
        }
    }
}
