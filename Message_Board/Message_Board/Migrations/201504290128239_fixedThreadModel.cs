namespace Message_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedThreadModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Threads", "ThreadID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "ThreadID", c => c.String());
        }
    }
}
