namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "Color", c => c.String());
            AddColumn("dbo.Pins", "YPos", c => c.Int(nullable: false));
            AddColumn("dbo.Pins", "XPos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pins", "XPos");
            DropColumn("dbo.Pins", "YPos");
            DropColumn("dbo.Pins", "Color");
        }
    }
}
