namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pinsWorking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Boards", "Pin_Id", c => c.Int());
            AddColumn("dbo.Pins", "PlayerPin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pins", "Row_Id", c => c.Int());
            CreateIndex("dbo.Boards", "Pin_Id");
            CreateIndex("dbo.Pins", "Row_Id");
            AddForeignKey("dbo.Boards", "Pin_Id", "dbo.Pins", "Id");
            AddForeignKey("dbo.Pins", "Row_Id", "dbo.Rows", "Id");
            DropColumn("dbo.Boards", "Row");
            DropColumn("dbo.Pins", "Color");
            DropTable("dbo.Colors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Red = c.String(),
                        Green = c.String(),
                        Blue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pins", "Color", c => c.String());
            AddColumn("dbo.Boards", "Row", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pins", "Row_Id", "dbo.Rows");
            DropForeignKey("dbo.Boards", "Pin_Id", "dbo.Pins");
            DropIndex("dbo.Pins", new[] { "Row_Id" });
            DropIndex("dbo.Boards", new[] { "Pin_Id" });
            DropColumn("dbo.Pins", "Row_Id");
            DropColumn("dbo.Pins", "PlayerPin");
            DropColumn("dbo.Boards", "Pin_Id");
            DropTable("dbo.Rows");
        }
    }
}
