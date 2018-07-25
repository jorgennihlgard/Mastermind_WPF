namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boardedit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boards", "Pin_Id", "dbo.Pins");
            DropIndex("dbo.Boards", new[] { "Pin_Id" });
            DropColumn("dbo.Boards", "Pin_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boards", "Pin_Id", c => c.Int());
            CreateIndex("dbo.Boards", "Pin_Id");
            AddForeignKey("dbo.Boards", "Pin_Id", "dbo.Pins", "Id");
        }
    }
}
