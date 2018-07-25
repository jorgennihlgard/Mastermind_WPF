namespace Mastermind_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pins", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pins", "Time", c => c.DateTime(nullable: false));
        }
    }
}
