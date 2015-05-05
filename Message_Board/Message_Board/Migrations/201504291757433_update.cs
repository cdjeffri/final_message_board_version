namespace Message_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Title");
        }
    }
}
