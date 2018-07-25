namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myFirstOnModel3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pins", t => t.Pin_Id)
                .Index(t => t.Pin_Id);
            
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        YPos = c.Int(nullable: false),
                        XPos = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "Pin_Id", "dbo.Pins");
            DropIndex("dbo.Boards", new[] { "Pin_Id" });
            DropTable("dbo.Pins");
            DropTable("dbo.Boards");
        }
    }
}
